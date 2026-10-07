Imports System.Text.RegularExpressions
Public Class frmClientes
    ' Un solo objeto de acceso a datos para todo el formulario
    Private datos As New Cliente_datos()
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnFin.Click
        Me.Close()
    End Sub
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        ' 1. Validamos que las cajas no estén vacías
        If Not DatosValidos() Then Exit Sub

        Try
            ' 2. Armamos el cliente con los datos de la pantalla
            Dim nuevoCliente As New Cliente(
                txtDocumento.Text.Trim(),
                txtNombre.Text.Trim(),
                txtApellido.Text.Trim(),
                txtTelefono.Text.Trim(),
                txtEmail.Text.Trim(),
                txtDireccion.Text.Trim(),
                Nothing,
                True
            )

            ' 3. Usamos la capa de datos para guardar al cliente
            If datos.Agregar(nuevoCliente) Then
                MessageBox.Show("¡Cliente guardado en la base de datos con éxito!")
            Else
                MessageBox.Show("No se pudo guardar el cliente.")
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub
    ' Función para validar formato de email
    Private Function validar_mail(ByVal smail As String) As Boolean
        Return Regex.IsMatch(smail, "^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$")
    End Function

    ' Función matemática para validar Cédula de Identidad Uruguaya
    Private Function valida_ci(ByVal cedula As String) As Boolean
        Dim clave(7) As Byte
        Dim a As String
        Dim b As String
        Dim c As Double
        Dim d As Byte
        Dim i As Byte

        If cedula.Length < 8 Then
            MessageBox.Show("Cédula incompleta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDocumento.Focus()
            txtDocumento.SelectAll()
            Return False
        Else
            clave(1) = 2 : clave(2) = 9 : clave(3) = 8 : clave(4) = 7
            clave(5) = 6 : clave(6) = 3 : clave(7) = 4
            c = 0
            For i = 1 To 7
                a = Mid(cedula, i, 1)
                b = a * clave(i)
                c = c + Val(Mid(b, Len(b), 1))
            Next i

            If Val(Mid(c, 2, 1)) = 0 Then
                d = 0
            Else
                d = 10 - Val(Mid(c, 2, 1))
            End If

            If d <> Val(Mid(cedula, 8, 1)) Then
                MessageBox.Show("Cédula incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtDocumento.Focus()
                Return False
            End If

            Return True
        End If
    End Function
    Private Function DatosValidos() As Boolean
        ' Habilitar las codificaciones clásicas de Windows (Encoding 1252) para usar StrConv
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance)

        ' === 1. Validar Documento (Cédula) ===
        txtDocumento.Text = Trim(txtDocumento.Text)
        ' === 1. Validar Documento (Cédula) ===
        txtDocumento.Text = Trim(txtDocumento.Text)
        If txtDocumento.Text = "" Then
            MessageBox.Show("Por favor, ingresá el documento del cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDocumento.Focus()
            Return False
        End If
        ' Verificamos que sea una cédula válida
        If valida_ci(txtDocumento.Text) = False Then
            'MsgBox("Cédula incorrecta", MsgBoxStyle.Exclamation, "Error")
            Return False
        End If

        ' === 2. Validar Nombre ===
        txtNombre.Text = Trim(txtNombre.Text)
        If txtNombre.Text = "" Then
            MessageBox.Show("Nombre incompleto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNombre.Focus()
            Return False
        End If
        ' Convierte la primera letra en mayúscula automáticamente
        txtNombre.Text = StrConv(txtNombre.Text, VbStrConv.ProperCase)

        ' === 3. Validar Apellido ===
        txtApellido.Text = Trim(txtApellido.Text)
        If txtApellido.Text = "" Then
            MessageBox.Show("Apellido incompleto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtApellido.Focus()
            Return False
        End If
        ' Convierte la primera letra en mayúscula automáticamente
        txtApellido.Text = StrConv(txtApellido.Text, VbStrConv.ProperCase)

        ' === 4. Validar Teléfono ===
        txtTelefono.Text = Trim(txtTelefono.Text)
        If txtTelefono.Text = "" Then
            MessageBox.Show("Teléfono incompleto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtTelefono.Focus()
            Return False
        End If

        ' === 5. Validar E-Mail ===
        txtEmail.Text = Trim(txtEmail.Text)
        If txtEmail.Text = "" Then
            MessageBox.Show("Escriba la dirección e-mail.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtEmail.Focus()
            Return False
        Else
            If validar_mail(txtEmail.Text) = False Then
                MessageBox.Show("Dirección e-mail incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtEmail.Focus()
                txtEmail.SelectAll()
                Return False
            End If
        End If

        ' === 6. Validar Dirección ===
        txtDireccion.Text = Trim(txtDireccion.Text)
        If txtDireccion.Text = "" Then
            MessageBox.Show("Dirección incompleta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDireccion.Focus()
            Return False
        End If

        Return True
    End Function
End Class