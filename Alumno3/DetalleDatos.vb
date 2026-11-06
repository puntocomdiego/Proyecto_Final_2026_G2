Imports System.Data.OleDb

Public Class DetalleDatos

    Public Function Agregar(d As Detalle, cn As OleDbConnection, trans As OleDbTransaction) As Boolean

        Dim sql As String = "INSERT INTO DetalleVentas " &
                            "(IdVenta, IdProducto, Cantidad, PrecioUnitario, Subtotal) " &
                            "VALUES (?, ?, ?, ?, ?)"

        Using cmd As New OleDbCommand(sql, cn, trans)
            cmd.Parameters.AddWithValue("?", d.IdVenta)
            cmd.Parameters.AddWithValue("?", d.IdProducto)
            cmd.Parameters.AddWithValue("?", d.Cantidad)
            cmd.Parameters.AddWithValue("?", d.PrecioUnita)
            cmd.Parameters.AddWithValue("?", d.Subtotal)

            Return cmd.ExecuteNonQuery() > 0
        End Using

    End Function

End Class
