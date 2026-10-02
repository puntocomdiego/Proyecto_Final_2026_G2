Public Class Cliente
    ' ===== Propiedades =====
    Public Property IdCliente As Integer
    Public Property Documento As String
    Public Property Nombre As String
    Public Property Apellido As String
    Public Property Telefono As String
    Public Property Email As String
    Public Property Direccion As String
    Public Property Foto As Byte()
    Public Property Activo As Boolean

    ' ===== Constructores =====
    Public Sub New()
    End Sub

    Public Sub New(documento As String, nombre As String, apellido As String, telefono As String, email As String, direccion As String, foto As Byte(), activo As Boolean)
        Me.Documento = documento
        Me.Nombre = nombre
        Me.Apellido = apellido
        Me.Telefono = telefono
        Me.Email = email
        Me.Direccion = direccion
        Me.Foto = foto
        Me.Activo = activo
    End Sub
End Class