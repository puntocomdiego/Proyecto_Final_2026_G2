Imports System.Data.OleDb

Public Class Cls_ProductoDatos
    Private Shared ReadOnly ruta As String =
        IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "comercial.accdb")
    Private Shared ReadOnly cadenaConexion As String =
        $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={ruta};"
    Public Function Agregar(p As Cls_Producto) As Boolean
        Using cn As New OleDbConnection(cadenaConexion)
            Dim sql As String =
                "INSERT INTO Productos ( Descripcion, Codigo, Precio, Stock, StockMinimo, IdCategoria, Activo) VALUES (?, ?, ?, ?, ?, ?, ?)"
            Using cmd As New OleDbCommand(sql, cn)
                cmd.Parameters.AddWithValue("?", p.Descripcion)
                cmd.Parameters.AddWithValue("?", p.Codigo)
                cmd.Parameters.AddWithValue("?", p.Precio)
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
            Dim sql As String = "UPDATE Productos SET Descripcion = ?, Codigo = ?, Precio = ?, Stock = ?, StockMinimo = ?, IdCategoria = ?, Activo = ? WHERE Codigo = ?"

            Using cmd As New OleDbCommand(sql, cn)
                cmd.Parameters.AddWithValue("?", p.Descripcion)
                cmd.Parameters.AddWithValue("?", p.Codigo)
                cmd.Parameters.AddWithValue("?", p.Precio)
                cmd.Parameters.AddWithValue("?", p.Stock)
                cmd.Parameters.AddWithValue("?", p.StockMinimo)
                cmd.Parameters.AddWithValue("?", p.IdCategoria)
                cmd.Parameters.AddWithValue("?", p.Activo)
                cmd.Parameters.AddWithValue("?", p.Codigo)

                cn.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function
    Public Function Eliminar(codigo As Integer) As Boolean
        Using cn As New OleDbConnection(cadenaConexion)
            Dim sql As String = "DELETE FROM Productos WHERE Codigo = ?"
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
                "SELECT Productos.Descripcion " _
+ "From Categorias INNER Join Productos On Categorias.IdCategoria = Productos.IdCategoria " _
+ "Order By Productos.Descripcion;"

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
                "SELECT Categorias.IdCategoria, Categorias.Nombre " _
+ "From Categorias " _
+ "Order By Categorias.Nombre;"

            Using da As New OleDbDataAdapter(sql, cn)
                da.Fill(dt)
            End Using
        End Using
        Return dt
    End Function
    Public Function ListarProductos() As DataTable
        Dim dt As New DataTable()
        Using cn As New OleDbConnection(cadenaConexion)
            Dim sql As String =
                "SELECT Productos.IdProducto, Productos.Codigo, Productos.Descripcion, Productos.Precio, Productos.Stock, Productos.StockMinimo, Categorias.Nombre, Productos.Activo " _
+ "FROM Categorias INNER JOIN Productos ON Categorias.IdCategoria = Productos.IdCategoria " _
+ "ORDER BY Productos.IdProducto;"

            Using da As New OleDbDataAdapter(sql, cn)
                da.Fill(dt)
            End Using
        End Using
        Return dt
    End Function
End Class
