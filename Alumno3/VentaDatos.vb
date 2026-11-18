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
    Public Function ObtenerVentasFecha(fechaInicio As Date, fechaFin As Date) As DataTable
        Dim dt As New DataTable()
        Dim sql As String = "SELECT IdVenta, Fecha, IdCliente, Total, FormaPago " &
                            "FROM Ventas " &
                            "WHERE Ventas.Fecha >= ? AND Ventas.Fecha < ? " &
                            "ORDER BY Ventas.Fecha DESC;"

        Using cn As New OleDbConnection(CadenaConexion)
            cn.Open()
            Using cmd As New OleDbCommand(sql, cn)
                cmd.Parameters.Add("?", OleDbType.Date).Value = fechaInicio.Date
                cmd.Parameters.Add("?", OleDbType.Date).Value = fechaFin.Date.AddDays(1) ' Agregar un día para incluir la fecha de fin
                Using da As New OleDbDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    Public Function ObtenerVentasCliente(idCliente As Integer) As DataTable
        Dim dt As New DataTable()
        Dim sql As String = "SELECT IdVenta, Fecha, IdCliente, Total, FormaPago " &
                            "FROM Ventas " &
                            "WHERE Ventas.IdCliente = ? " &
                            "ORDER BY Ventas.Fecha DESC;"
        Using cn As New OleDbConnection(CadenaConexion)
            cn.Open()
            Using cmd As New OleDbCommand(sql, cn)
                cmd.Parameters.Add("?", OleDbType.Integer).Value = idCliente
                Using da As New OleDbDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using

        Return dt
    End Function

End Class