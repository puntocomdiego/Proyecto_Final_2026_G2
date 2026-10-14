Imports System.Data.OleDb

Public Class TempDatos

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

End Class
