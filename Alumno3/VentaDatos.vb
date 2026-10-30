Imports System.Data.OleDb

Public Class VentaDatos

    Public Function Agregar(v As Venta, cn As OleDbConnection, trans As OleDbTransaction) As Integer

        Dim sql As String = "INSERT INTO Ventas (Fecha, IdCliente, Total, FormaPago) " &
                            "VALUES (?, ?, ?, ?)"

        Using cmd As New OleDbCommand(sql, cn, trans)
            cmd.Parameters.Add("?", OleDbType.Date).Value = v.Fecha
            cmd.Parameters.Add("?", OleDbType.Integer).Value = v.Cliente
            cmd.Parameters.Add("?", OleDbType.Currency).Value = v.Total
            cmd.Parameters.Add("?", OleDbType.VarWChar, 20).Value = v.FormaPago

            cmd.ExecuteNonQuery()
        End Using

        Using cmdId As New OleDbCommand(
        "SELECT @@IDENTITY", cn, trans)

            Return Convert.ToInt32(cmdId.ExecuteScalar())
        End Using

    End Function

End Class