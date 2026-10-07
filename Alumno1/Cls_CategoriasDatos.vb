Imports System.Data.OleDb
Public Class Cls_CategoriasDatos
    Private Shared ReadOnly ruta As String =
        IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "comercial.accdb")
    Private Shared ReadOnly cadenaConexion As String =
        $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={ruta};"

    Public Function Agregar(c As Cls_Categorias) As Boolean
        Using cn As New OleDbConnection(cadenaConexion)
            Dim sql As String = "INSERT INTO Categorias (Nombre) VALUES (?)"
            Using cmd As New OleDbCommand(sql, cn)
                cmd.Parameters.AddWithValue("?", c.Nombre)
                cn.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function

    Public Function Modificar(c As Cls_Categorias) As Boolean
        Using cn As New OleDbConnection(cadenaConexion)
            Dim sql As String = "UPDATE Categorias SET Nombre = ? WHERE IdCategoria = ?"
            Using cmd As New OleDbCommand(sql, cn)
                cmd.Parameters.AddWithValue("?", c.Nombre)
                cmd.Parameters.AddWithValue("?", c.IdCategoria)
                cn.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function
    Public Function Eliminar(idCategoria As Integer) As Boolean
        Using cn As New OleDbConnection(cadenaConexion)
            Dim sql As String = "DELETE FROM Categorias WHERE IdCategoria = ?"
            Using cmd As New OleDbCommand(sql, cn)
                cmd.Parameters.AddWithValue("?", idCategoria)
                cn.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function
    Public Function Listar() As DataTable
        Dim dt As New DataTable()
        Using cn As New OleDbConnection(cadenaConexion)
            Dim sql As String = "SELECT Categorias.IdCategoria, Categorias.Nombre " _
+ "FROM Categorias " _
+ "ORDER BY Categorias.IdCategoria;"

            Using da As New OleDbDataAdapter(sql, cn)
                da.Fill(dt)
            End Using
        End Using
        Return dt
    End Function
End Class
