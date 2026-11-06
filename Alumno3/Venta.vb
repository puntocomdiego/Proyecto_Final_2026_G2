Public Class Venta

    Public Property Fecha As Date
    Public Property Cliente As Integer
    Public Property Total As Decimal
    Public Property FormaPago As String

    Public Sub New()


    End Sub

    Public Sub New(Fecha As Date, Cliente As Integer, Total As Decimal, FormaPago As String)

        Me.Fecha = Fecha
        Me.Cliente = Cliente
        Me.Total = Total
        Me.FormaPago = FormaPago
    End Sub

End Class
