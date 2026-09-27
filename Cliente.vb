Imports System.Data.OleDb
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

    ' ===== Métodos de la Base de Datos =====
    Public Function Agregar() As Boolean
        Using cn As New OleDbConnection(Conexion.CadenaConexion)
            Dim sql As String = "INSERT INTO Clientes (Documento, Nombre, Apellido, Telefono, Email, Direccion, Activo) VALUES (?, ?, ?, ?, ?, ?, ?)"
            Using cmd As New OleDbCommand(sql, cn)
                cmd.Parameters.AddWithValue("?", Me.Documento)
                cmd.Parameters.AddWithValue("?", Me.Nombre)
                cmd.Parameters.AddWithValue("?", Me.Apellido)
                cmd.Parameters.AddWithValue("?", Me.Telefono)
                cmd.Parameters.AddWithValue("?", Me.Email)
                cmd.Parameters.AddWithValue("?", Me.Direccion)
                cmd.Parameters.AddWithValue("?", Me.Activo)

                cn.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function
End Class