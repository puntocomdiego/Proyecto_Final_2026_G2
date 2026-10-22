Imports System.Data.OleDb

Public Class TemporalDatos

    Private Shared ReadOnly ruta As String =
IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Comercial.accdb")
    Private Shared ReadOnly cadenaConexion As String =
    $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={ruta};"


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
            Dim sql As String = "INSERT INTO Temp (IdProducto, Descripcion, Cantidad) VALUES (?, ?, ?)"
            '"INSERT INTO Temp (IdProducto, Descripcion, Cantidad, PrecioUnita, Subtotal, MetodoPago) VALUES (?, ?, ?, ?, ?, ?)"

            Using cmd As New OleDbCommand(sql, cn)
                cmd.Parameters.AddWithValue("?", t.IdProducto)
                cmd.Parameters.AddWithValue("?", t.Descripcion)
                cmd.Parameters.AddWithValue("?", t.Cantidad)
                'cmd.Parameters.AddWithValue("?", t.PrecioUnita)
                'cmd.Parameters.AddWithValue("?", t.Subtotal)
                'cmd.Parameters.AddWithValue("?", t.MetodoPago)
                cn.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using

    End Function

End Class
