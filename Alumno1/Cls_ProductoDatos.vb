Imports System.Data.OleDb

Public Class Cls_ProductoDatos
    Private Shared ReadOnly ruta As String =
        IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "comercial.accdb")
    Private Shared ReadOnly cadenaConexion As String =
        $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={ruta};"
    Public Function Agregar(p As Cls_Producto) As Boolean
        Using cn As New OleDbConnection(cadenaConexion)
            Dim sql As String =
                "INSERT INTO Productos (descripcion, precio, stock, stockminimo, codigo, idcategorias, activo) VALUES (?, ?, ?, ?, ?, ?, ?)"
            Using cmd As New OleDbCommand(sql, cn)
                cmd.Parameters.AddWithValue("?", p.Descripcion)
                cmd.Parameters.AddWithValue("?", p.Precio)
                cmd.Parameters.AddWithValue("?", p.Codigo)
                cmd.Parameters.AddWithValue("?", p.Stock)
                cmd.Parameters.AddWithValue("?", p.StockMinimo)
                cmd.Parameters.AddWithValue("?", p.IdCategoria)
                cmd.Parameters.AddWithValue("?", p.Activo)
                cn.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function
    Public Function Modificar(p As Cls_Producto) As Boolean
        Using cn As New OleDbConnection(cadenaConexion)
            Dim sql As String =
                "UPDATE Productos SET descripcion = ?, precio = ?, stock = ?, stockminimo = ?, idcategorias = ?, activo = ? WHERE codigo = ?"
            Using cmd As New OleDbCommand(sql, cn)
                cmd.Parameters.AddWithValue("?", p.Descripcion)
                cmd.Parameters.AddWithValue("?", p.Precio)
                cmd.Parameters.AddWithValue("?", p.Stock)
                cmd.Parameters.AddWithValue("?", p.Codigo)
                cmd.Parameters.AddWithValue("?", p.StockMinimo)
                cmd.Parameters.AddWithValue("?", p.IdCategoria)
                cmd.Parameters.AddWithValue("?", p.Activo)
                cn.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function
    Public Function Eliminar(codigo As Integer) As Boolean
        Using cn As New OleDbConnection(cadenaConexion)
            Dim sql As String = "DELETE FROM Productos WHERE codigo = ?"
            Using cmd As New OleDbCommand(sql, cn)
                cmd.Parameters.AddWithValue("?", codigo)
                cn.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function
    Public Function Buscar(texto As String) As DataTable
        Dim dt As New DataTable()
        Using cn As New OleDbConnection(cadenaConexion)
            Dim sql As String =
                "SELECT codigo, descripcion, precio, stock, stockminimo, idcategorias, activo " _
                + "FROM Productos " _
               + "WHERE descripcion LIKE ? ORDER BY descripcion"
            Using cmd As New OleDbCommand(sql, cn)
                cmd.Parameters.AddWithValue("?", "%" & texto & "%")
                Using da As New OleDbDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function
    Public Function Listar() As DataTable
        Dim dt As New DataTable()
        Using cn As New OleDbConnection(cadenaConexion)
            Dim sql As String =
                "SELECT codigo, descripcion, precio, stock, stockminimo, idcategorias, activo " _
                + "FROM Productos ORDER BY descripcion"
            Using da As New OleDbDataAdapter(sql, cn)
                da.Fill(dt)
            End Using
        End Using
        Return dt
    End Function
End Class
