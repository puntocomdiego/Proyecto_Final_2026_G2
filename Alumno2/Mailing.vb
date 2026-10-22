Imports System.Net.Mail
Imports System.ComponentModel

Public Class Mailing
    ' Acceso a la base de datos
    Private datos As New Cliente_datos()

    ' Regla del proyecto: Credenciales ocultas en el código
    Private miCorreo As String = "jorgemiraballes@gmail.com"
    Private miClaveApp As String = "muoz bdia byfz cqhc"

    ' Objetos para el correo y el cartero asincrónico
    Private WithEvents clienteSmtp As New SmtpClient("smtp.gmail.com")
    Private correo As MailMessage
    Private rutaAdjunto As String = ""

    ' ===== 1. CARGA INICIAL =====
    Private Sub Mailing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarClientes()
        lblEstado.Text = "Esperando para enviar..."
    End Sub

    Private Sub CargarClientes()
        Try
            cmbClientes.Items.Clear()
            ' Opción masiva obligatoria
            cmbClientes.Items.Add("-> ENVIAR A TODOS LOS CLIENTES <-")

            Dim dt As DataTable = datos.Listar()

            For Each fila As DataRow In dt.Rows
                Dim activo As Boolean = If(IsDBNull(fila("Activo")), False, Convert.ToBoolean(fila("Activo")))
                Dim email As String = If(IsDBNull(fila("Email")), "", fila("Email").ToString().Trim())
                Dim nombreCompleto As String = fila("Nombre").ToString().Trim() & " " & fila("Apellido").ToString().Trim()

                If activo AndAlso email <> "" Then
                    cmbClientes.Items.Add(nombreCompleto & " <" & email & ">")
                End If
            Next

            If cmbClientes.Items.Count > 0 Then cmbClientes.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show("Error al cargar clientes: " & ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ===== 2. ADJUNTAR PDF =====
    Private Sub btnAdjuntar_Click(sender As Object, e As EventArgs) Handles btnAdjuntar.Click
        Dim ofdPdf As New OpenFileDialog()
        ofdPdf.Filter = "Archivos PDF (*.pdf)|*.pdf"
        ofdPdf.Title = "Seleccionar PDF de ofertas"

        If ofdPdf.ShowDialog() = DialogResult.OK Then
            rutaAdjunto = ofdPdf.FileName
            ' Asumiendo que tu etiqueta debajo del botón se llama lblAdjunto
            lblAdjunto.Text = ofdPdf.SafeFileName
        End If
    End Sub

    ' ===== 3. PREPARACIÓN Y ENVÍO =====
    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        ' Validaciones básicas
        If txtAsunto.Text.Trim() = "" Or txtCuerpo.Text.Trim() = "" Then
            MessageBox.Show("El asunto y el mensaje son obligatorios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            correo = New MailMessage()
            correo.From = New MailAddress(miCorreo)
            correo.Subject = txtAsunto.Text.Trim()
            correo.Body = txtCuerpo.Text.Trim()

            ' Adjuntar archivo si el usuario seleccionó uno
            If rutaAdjunto <> "" AndAlso IO.File.Exists(rutaAdjunto) Then
                correo.Attachments.Add(New Attachment(rutaAdjunto))
            End If

            ' Lógica de destinatarios
            If cmbClientes.SelectedIndex = 0 Then
                ' ENVIAR A TODOS: Recorremos desde el índice 1 hacia adelante y usamos CCO
                For i As Integer = 1 To cmbClientes.Items.Count - 1
                    Dim correoDestino As String = ExtraerEmail(cmbClientes.Items(i).ToString())
                    If EsMailValido(correoDestino) Then
                        correo.Bcc.Add(correoDestino)
                    End If
                Next
            Else
                ' ENVIAR A UNO: Extraemos el correo del elemento seleccionado y usamos TO
                Dim correoDestino As String = ExtraerEmail(cmbClientes.SelectedItem.ToString())
                If EsMailValido(correoDestino) Then
                    correo.To.Add(correoDestino)
                Else
                    MessageBox.Show("El formato del correo de este cliente no es válido.")
                    Exit Sub
                End If
            End If

            ' Configuración estricta según rúbrica del proyecto
            clienteSmtp.Port = 587
            clienteSmtp.EnableSsl = True
            clienteSmtp.Credentials = New Net.NetworkCredential(miCorreo, miClaveApp)

            ' UI y Envío asincrónico
            lblEstado.Text = "🚀 Enviando... (Puedes cancelar)"
            lblEstado.ForeColor = Color.Blue
            btnEnviar.Enabled = False
            btnCancelar.Enabled = True

            clienteSmtp.SendAsync(correo, "EnvioOfertas")

        Catch ex As Exception
            MessageBox.Show("Error al preparar el correo: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnEnviar.Enabled = True
        End Try
    End Sub

    ' ===== 4. CANCELACIÓN Y RESPUESTA DEL SERVIDOR =====
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        clienteSmtp.SendAsyncCancel()
        lblEstado.Text = "🛑 Cancelación solicitada..."
        lblEstado.ForeColor = Color.Orange
    End Sub

    Private Sub clienteSmtp_SendCompleted(sender As Object, e As AsyncCompletedEventArgs) Handles clienteSmtp.SendCompleted
        If e.Cancelled Then
            lblEstado.Text = "🚫 Envío Cancelado por el usuario."
            lblEstado.ForeColor = Color.Red
        ElseIf e.Error IsNot Nothing Then
            lblEstado.Text = "❌ Error en el envío."
            lblEstado.ForeColor = Color.Red
            MessageBox.Show(e.Error.Message, "Fallo SMTP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            lblEstado.Text = "✅ ¡Llegó a destino!"
            lblEstado.ForeColor = Color.Green
            MessageBox.Show("Ofertas enviadas correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Limpiamos los campos tras el éxito
            txtAsunto.Clear()
            txtCuerpo.Clear()
            rutaAdjunto = ""
            lblAdjunto.Text = "Ningún archivo adjunto..."
            cmbClientes.SelectedIndex = 0
        End If

        ' Rehabilitar botones y limpiar memoria
        btnEnviar.Enabled = True
        btnCancelar.Enabled = False
        If correo IsNot Nothing Then correo.Dispose()
    End Sub

    ' ===== 5. FUNCIONES AUXILIARES =====
    ' Extrae únicamente lo que está entre < y > en el ComboBox
    Private Function ExtraerEmail(texto As String) As String
        Try
            Dim partes() As String = texto.Split("<"c)
            If partes.Length > 1 Then
                Return partes(1).Replace(">", "").Trim()
            End If
            Return ""
        Catch
            Return ""
        End Try
    End Function

    Private Function EsMailValido(ByVal direccion As String) As Boolean
        Try
            Dim prueba As New System.Net.Mail.MailAddress(direccion)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class