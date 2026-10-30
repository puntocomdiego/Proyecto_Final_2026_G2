Imports System.Data.OleDb

Public Class TemporalDatos


    Public Function Listar() As DataTable
        Dim dt As New DataTable()
        Using cn As New OleDbConnection(cadenaConexion)
            Dim sql As String = "SELECT Temp.IdProducto, Temp.Descripcion, Temp.Cantidad, Temp.PrecioUnita, Temp.Subtotal " _
                              + "FROM Temp ORDER BY Temp.Descripcion DESC;"
            Using da As New OleDbDataAdapter(sql, cn)
                da.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

    Public Function Agregar(t As Temporal) As Boolean

        Using cn As New OleDbConnection(cadenaConexion)
            Dim sql As String = "INSERT INTO Temp (IdProducto, Descripcion, Cantidad, PrecioUnita, subtotal) VALUES (?, ?, ?, ?, ?)"

            Using cmd As New OleDbCommand(sql, cn)
                cmd.Parameters.AddWithValue("?", t.IdProducto)
                cmd.Parameters.AddWithValue("?", t.Descripcion)
                cmd.Parameters.AddWithValue("?", t.Cantidad)
                cmd.Parameters.AddWithValue("?", t.PrecioUnita)
                cmd.Parameters.AddWithValue("?", t.Subtotal)

                cn.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using

    End Function

    Public Function Editar(t As Temporal) As Boolean
        Using cn As New OleDbConnection(CadenaConexion)
            Dim sql As String = "UPDATE Temp SET Descripcion = ?, Cantidad = ?, PrecioUnita = ?, Subtotal = ? WHERE IdProducto = ?"
            Using cmd As New OleDbCommand(sql, cn)
                cmd.Parameters.AddWithValue("?", t.Descripcion)
                cmd.Parameters.AddWithValue("?", t.Cantidad)
                cmd.Parameters.AddWithValue("?", t.PrecioUnita)
                cmd.Parameters.AddWithValue("?", t.Subtotal)
                cmd.Parameters.AddWithValue("?", t.IdProducto)
                cn.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function

    Public Function Eliminar(idProducto As Integer) As Boolean
        Using cn As New OleDbConnection(CadenaConexion)
            Dim sql As String = "DELETE FROM Temp WHERE IdProducto = ?"
            Using cmd As New OleDbCommand(sql, cn)
                cmd.Parameters.AddWithValue("?", idProducto)
                cn.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function

    Public Function Limpiar() As Boolean
        Using cn As New OleDbConnection(CadenaConexion)
            Dim sql As String = "DELETE FROM Temp"
            Using cmd As New OleDbCommand(sql, cn)
                cn.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function

End Class
