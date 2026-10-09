Public Class Temp

    Public Property IdProducto As Integer
    Public Property Descripcion As String
    Public Property Cantidad As Decimal
    Public Property PrecioUnita As Decimal
    Public Property Subtotal As Decimal


    Public Sub New()


    End Sub

    Public Sub New(IdProducto As Integer, Descripcion As String, Cantidad As Decimal, PrecioUnita As Decimal, Subtotal As Decimal)

        Me.IdProducto = IdProducto
        Me.Descripcion = Descripcion
        Me.Cantidad = Cantidad
        Me.PrecioUnita = PrecioUnita
        Me.Subtotal = Subtotal

    End Sub

End Class
