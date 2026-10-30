Public Class DetalleDatos

    Public Property IdVenta As Integer
    Public Property IdProducto As Integer
    Public Property Cantidad As Decimal
    Public Property PrecioUnita As Decimal
    Public Property Subtotal As Decimal

    Public Sub New()

    End Sub

    Public Sub New(IdVenta As Integer, IdProducto As Integer, Cantidad As Decimal, PrecioUnita As Decimal, Subtotal As Decimal)

        Me.IdVenta = IdVenta
        Me.IdProducto = IdProducto
        Me.Cantidad = Cantidad
        Me.PrecioUnita = PrecioUnita
        Me.Subtotal = Subtotal

    End Sub

End Class
