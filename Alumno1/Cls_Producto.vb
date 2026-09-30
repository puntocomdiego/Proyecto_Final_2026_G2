Public Class Cls_Producto
    Public Property IdProducto As Integer
    Public Property Codigo As String
    Public Property Descripcion As String
    Public Property Precio As Decimal
    Public Property Stock As Integer
    Public Property StockMinimo As Integer
    Public Property IdCategoria As Integer
    Public Property Activo As Boolean

    Public Sub New()
    End Sub

    Public Sub New(descripcion As String, precio As Decimal, foto As String)
        Me.Codigo = Codigo
        Me.Descripcion = descripcion
        Me.Precio = precio
        Me.Stock = Stock
        Me.StockMinimo = StockMinimo
        Me.IdCategoria = IdCategoria
        Me.Activo = True
    End Sub
End Class
