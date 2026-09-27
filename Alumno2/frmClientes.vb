Public Class frmClientes
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnFin.Click
        Me.Close()
    End Sub
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
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

            If nuevoCliente.Agregar() Then
                MessageBox.Show("¡Cliente guardado en la base de datos con éxito!")
            Else
                MessageBox.Show("No se pudo guardar el cliente.")
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub
End Class