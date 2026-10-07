Public Class Venta

    Public Property Cliente As Integer
    Public Property Categoria As String
    Public Property Poducto As String
    Public Property Cantidad As Decimal

    Public Sub New()


    End Sub

    Public Sub New(cliente As Integer, categoria As String, producto As String, cantidad As Decimal)
        Me.Cliente = cliente
        Me.Categoria = categoria
        Me.Poducto = producto
        Me.Cantidad = cantidad
    End Sub

End Class
