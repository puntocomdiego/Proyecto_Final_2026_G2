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
    Private Function DatosValidos() As Boolean
        If txtDocumento.Text.Trim() = "" Then
            MessageBox.Show("Por favor, ingresá el documento del cliente.")
            txtDocumento.Focus()
            Return False
        End If

        If txtNombre.Text.Trim() = "" Then
            MessageBox.Show("Por favor, ingresá el nombre.")
            txtNombre.Focus()
            Return False
        End If

        If txtApellido.Text.Trim() = "" Then
            MessageBox.Show("Por favor, ingresá el apellido.")
            txtApellido.Focus()
            Return False
        End If

        Return True
    End Function
End Class