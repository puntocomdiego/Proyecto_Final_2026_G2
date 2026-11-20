Imports System.Data.OleDb
Public Class BaseDeDatos
    Public Shared ReadOnly Ruta As String =
    IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "comercial.accdb")
    Public Shared ReadOnly RutaScript As String =
    IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CrearBD.sql")
    Public Shared ReadOnly CadenaConexion As String =
    $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Ruta};"

    Public Shared Function Existe() As Boolean
        Return IO.File.Exists(Ruta)
    End Function

    ' Crea el archivo .accdb vacío y ejecuta las sentencias del script SQL
    Public Shared Sub Crear()
        If Not IO.File.Exists(RutaScript) Then
            Throw New IO.FileNotFoundException("No se encontró el script de creación.", RutaScript)
        End If

        ' 1) Crear el archivo vacío con ADOX (late binding, no hace falta agregar referencias)
        Dim catalogo As Object = CreateObject("ADOX.Catalog")
        Dim conexion As Object = catalogo.Create(CadenaConexion)
        conexion.Close()

        ' 2) Ejecutar el script, una sentencia por vez (Access no acepta varias juntas)
        Try
            Using cn As New OleDbConnection(CadenaConexion)
                cn.Open()
                For Each sentencia In LeerSentencias(RutaScript)
                    Using cmd As New OleDbCommand(sentencia, cn)
                        cmd.ExecuteNonQuery()
                    End Using
                Next
            End Using
        Catch
            ' Si el script falla, no dejamos una base a medio crear
            OleDbConnection.ReleaseObjectPool()
            GC.Collect()
            GC.WaitForPendingFinalizers()
            IO.File.Delete(Ruta)
            Throw
        End Try
    End Sub

    ' Copia la base al destino indicado (sobrescribe si ya existe)
    Public Shared Sub Respaldar(destino As String)
        ' Libera las conexiones que OleDb mantiene abiertas en el pool
        OleDbConnection.ReleaseObjectPool()
        IO.File.Copy(Ruta, destino, True)
    End Sub

    ' Verifica que el archivo sea una base válida para este programa
    Public Shared Function EsRespaldoValido(archivo As String) As Boolean
        Try
            Using cn As New OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={archivo};Mode=Read;")
                cn.Open()

                Using cmdCat As New OleDbCommand("SELECT TOP 1 IdCategoria, Nombre FROM Categorias", cn)
                    cmdCat.ExecuteReader().Close()
                End Using

                Using cmdCli As New OleDbCommand("SELECT TOP 1 IdCliente, Documento, Nombre, Apellido, Telefono, Email, Direccion, Activo FROM Clientes", cn)
                    cmdCli.ExecuteReader().Close()
                End Using

                Using cmdDet As New OleDbCommand("SELECT TOP 1 IdDetalle, IdVenta, IdProducto, Cantidad, PrecioUnitario, Subtotal FROM DetalleVentas", cn)
                    cmdDet.ExecuteReader().Close()
                End Using

                Using cmdProd As New OleDbCommand("SELECT TOP 1 IdProducto, Codigo, Descripcion, Precio, Stock, StockMinimo, Activo FROM Productos", cn)
                    cmdProd.ExecuteReader().Close()
                End Using

                Using cmdTemp As New OleDbCommand("SELECT TOP 1 ID, IdVentas, IdProducto, Descripcion, Cantidad, PrecioUnita, Subtotal FROM Temp", cn)
                    cmdTemp.ExecuteReader().Close()
                End Using

                Using cmdVen As New OleDbCommand("SELECT TOP 1 IdVenta, Fecha, IdCliente, Total, FormaPago FROM Ventas", cn)
                    cmdVen.ExecuteReader().Close()
                End Using
            End Using
            Return True
        Catch
            Return False
        End Try
    End Function

    ' Reemplaza la base actual por el respaldo. Antes guarda una copia de la
    ' base actual por si el usuario se arrepiente. Devuelve la ruta de esa copia.
    Public Shared Function Restaurar(respaldo As String) As String
        Dim copiaSeguridad As String = Nothing
        If Existe() Then
            copiaSeguridad = IO.Path.Combine(CarpetaRespaldos(),
            $"Datos_antes_de_restaurar_{Date.Now:yyyy-MM-dd_HHmmss}.accdb")
            Respaldar(copiaSeguridad)
        End If

        OleDbConnection.ReleaseObjectPool()
        IO.File.Copy(respaldo, Ruta, True)
        Return copiaSeguridad
    End Function

    ' Carpeta sugerida para los respaldos: dentro de Google Drive si está
    ' instalado "Google Drive para escritorio", si no en Mis Documentos
    Public Shared Function CarpetaRespaldos() As String
        Dim baseCarpeta As String = CarpetaGoogleDrive()
        If baseCarpeta Is Nothing Then
            baseCarpeta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        End If
        Dim carpeta = IO.Path.Combine(baseCarpeta, "Respaldos Proyecto_G2")
        IO.Directory.CreateDirectory(carpeta)
        Return carpeta
    End Function

    ' Google Drive para escritorio monta una unidad (normalmente G:) con la carpeta "Mi unidad"
    Public Shared Function CarpetaGoogleDrive() As String
        For Each unidad In IO.DriveInfo.GetDrives()
            If Not unidad.IsReady Then Continue For
            For Each nombre In {"Mi unidad", "My Drive"}
                Dim ruta = IO.Path.Combine(unidad.RootDirectory.FullName, nombre)
                If IO.Directory.Exists(ruta) Then Return ruta
            Next
        Next
        Return Nothing
    End Function

    ' Quita los comentarios (--) y separa el script por punto y coma
    Private Shared Function LeerSentencias(archivo As String) As List(Of String)
        Dim lineas = IO.File.ReadAllLines(archivo).
        Where(Function(l) Not l.Trim().StartsWith("--"))
        Return String.Join(Environment.NewLine, lineas).
        Split(";"c).
        Select(Function(s) s.Trim()).
        Where(Function(s) s <> "").
        ToList()
    End Function
End Class
