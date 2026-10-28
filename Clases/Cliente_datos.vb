Imports System.Data.OleDb

Public Class Cliente_datos

    ' Recibe un Cliente (c) y lo guarda
    Public Function Agregar(c As Cliente) As Boolean
        Using cn As New OleDbConnection(Conexion.CadenaConexion)
            Dim sql As String = "INSERT INTO Clientes (Documento, Nombre, Apellido, Telefono, Email, Direccion, Activo) VALUES (?, ?, ?, ?, ?, ?, ?)"
            Using cmd As New OleDbCommand(sql, cn)
                cmd.Parameters.AddWithValue("?", c.Documento)
                cmd.Parameters.AddWithValue("?", c.Nombre)
                cmd.Parameters.AddWithValue("?", c.Apellido)
                cmd.Parameters.AddWithValue("?", c.Telefono)
                cmd.Parameters.AddWithValue("?", c.Email)
                cmd.Parameters.AddWithValue("?", c.Direccion)
                cmd.Parameters.AddWithValue("?", c.Activo)
                cn.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function

    ' Recibe un Cliente (con su ID) y lo modifica
    Public Function Modificar(c As Cliente) As Boolean
        Using cn As New OleDbConnection(Conexion.CadenaConexion)
            Dim sql As String = "UPDATE Clientes SET Documento = ?, Nombre = ?, Apellido = ?, Telefono = ?, Email = ?, Direccion = ?, Activo = ? WHERE IdCliente = ?"
            Using cmd As New OleDbCommand(sql, cn)
                cmd.Parameters.AddWithValue("?", c.Documento)
                cmd.Parameters.AddWithValue("?", c.Nombre)
                cmd.Parameters.AddWithValue("?", c.Apellido)
                cmd.Parameters.AddWithValue("?", c.Telefono)
                cmd.Parameters.AddWithValue("?", c.Email)
                cmd.Parameters.AddWithValue("?", c.Direccion)
                cmd.Parameters.AddWithValue("?", c.Activo)
                cmd.Parameters.AddWithValue("?", c.IdCliente)
                cn.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function

    ' Elimina por ID
    Public Function Eliminar(idCliente As Integer) As Boolean
        Using cn As New OleDbConnection(Conexion.CadenaConexion)
            Dim sql As String = "DELETE FROM Clientes WHERE IdCliente = ?"
            Using cmd As New OleDbCommand(sql, cn)
                cmd.Parameters.AddWithValue("?", idCliente)
                cn.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function

    ' Devuelve todos los clientes
    Public Function Listar() As DataTable
        Dim dt As New DataTable()
        Using cn As New OleDbConnection(Conexion.CadenaConexion)
            Dim sql As String = "SELECT IdCliente, Documento, Nombre, Apellido, Telefono, Email, Direccion, Activo FROM Clientes ORDER BY Apellido, Nombre"
            Using da As New OleDbDataAdapter(sql, cn)
                da.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

    ' Devuelve clientes que coinciden con el texto
    Public Function Buscar(texto As String) As DataTable
        Dim dt As New DataTable()
        Using cn As New OleDbConnection(Conexion.CadenaConexion)
            Dim sql As String = "SELECT IdCliente, Documento, Nombre, Apellido, Telefono, Email, Direccion, Activo FROM Clientes WHERE Apellido LIKE ? ORDER BY Apellido, Nombre"
            Using cmd As New OleDbCommand(sql, cn)
                cmd.Parameters.AddWithValue("?", "%" & texto & "%")
                Using da As New OleDbDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    ' Verifica si el documento ya está registrado (para evitar duplicados)
    Public Function ExisteDocumento(documento As String, idExcluir As Integer) As Boolean
        Using cn As New OleDbConnection(Conexion.CadenaConexion)
            Dim sql As String = "SELECT COUNT(*) FROM Clientes WHERE Documento = ? AND IdCliente <> ?"
            Using cmd As New OleDbCommand(sql, cn)
                cmd.Parameters.AddWithValue("?", documento)
                cmd.Parameters.AddWithValue("?", idExcluir)
                cn.Open()
                Return Convert.ToInt32(cmd.ExecuteScalar()) > 0
            End Using
        End Using
    End Function

End Class