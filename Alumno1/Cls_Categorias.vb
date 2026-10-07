Public Class Cls_Categorias
    Public Property IdCategoria As Integer
    Public Property Nombre As String

    Public Sub New()
    End Sub

    Public Sub New(nombre As String)
        Me.Nombre = nombre
    End Sub
End Class
