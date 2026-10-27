<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Mailing
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        cmbClientes = New ComboBox()
        txtAsunto = New TextBox()
        txtCuerpo = New TextBox()
        btnAdjuntar = New Button()
        lblAdjunto = New TextBox()
        ofdPdf = New OpenFileDialog()
        btnEnviar = New Button()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        btnCancelar = New Button()
        lblEstado = New Label()
        SuspendLayout()
        ' 
        ' cmbClientes
        ' 
        cmbClientes.FormattingEnabled = True
        cmbClientes.Location = New Point(234, 51)
        cmbClientes.Name = "cmbClientes"
        cmbClientes.Size = New Size(345, 28)
        cmbClientes.TabIndex = 0
        ' 
        ' txtAsunto
        ' 
        txtAsunto.Location = New Point(234, 85)
        txtAsunto.Name = "txtAsunto"
        txtAsunto.Size = New Size(345, 27)
        txtAsunto.TabIndex = 1
        ' 
        ' txtCuerpo
        ' 
        txtCuerpo.Location = New Point(234, 118)
        txtCuerpo.Multiline = True
        txtCuerpo.Name = "txtCuerpo"
        txtCuerpo.Size = New Size(345, 94)
        txtCuerpo.TabIndex = 2
        ' 
        ' btnAdjuntar
        ' 
        btnAdjuntar.Location = New Point(24, 223)
        btnAdjuntar.Name = "btnAdjuntar"
        btnAdjuntar.Size = New Size(123, 60)
        btnAdjuntar.TabIndex = 3
        btnAdjuntar.Text = "Adjuntar PDF de ofertas"
        btnAdjuntar.UseVisualStyleBackColor = True
        ' 
        ' lblAdjunto
        ' 
        lblAdjunto.Location = New Point(24, 289)
        lblAdjunto.Name = "lblAdjunto"
        lblAdjunto.Size = New Size(345, 27)
        lblAdjunto.TabIndex = 4
        lblAdjunto.Text = "Ningún archivo adjunto..."
        ' 
        ' ofdPdf
        ' 
        ofdPdf.FileName = "OpenFileDialog1"
        ' 
        ' btnEnviar
        ' 
        btnEnviar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnEnviar.Location = New Point(576, 258)
        btnEnviar.Name = "btnEnviar"
        btnEnviar.Size = New Size(212, 87)
        btnEnviar.TabIndex = 5
        btnEnviar.Text = "ENVIAR CORREO"
        btnEnviar.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.Location = New Point(87, 51)
        Label1.Name = "Label1"
        Label1.Size = New Size(141, 28)
        Label1.TabIndex = 6
        Label1.Text = "PARA (Cliente):"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F)
        Label2.Location = New Point(135, 85)
        Label2.Name = "Label2"
        Label2.Size = New Size(93, 28)
        Label2.TabIndex = 7
        Label2.Text = "ASUNTO:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F)
        Label3.Location = New Point(14, 118)
        Label3.Name = "Label3"
        Label3.Size = New Size(214, 28)
        Label3.TabIndex = 8
        Label3.Text = "MENSAJE DE OFERTAS:"
        ' 
        ' btnCancelar
        ' 
        btnCancelar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnCancelar.Location = New Point(576, 351)
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Size = New Size(212, 87)
        btnCancelar.TabIndex = 9
        btnCancelar.Text = "CANCELAR ENVÍO"
        btnCancelar.UseVisualStyleBackColor = True
        ' 
        ' lblEstado
        ' 
        lblEstado.AutoSize = True
        lblEstado.Location = New Point(24, 351)
        lblEstado.Name = "lblEstado"
        lblEstado.Size = New Size(166, 20)
        lblEstado.TabIndex = 10
        lblEstado.Text = "Esperando para enviar..."
        ' 
        ' Mailing
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(lblEstado)
        Controls.Add(btnCancelar)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(btnEnviar)
        Controls.Add(lblAdjunto)
        Controls.Add(btnAdjuntar)
        Controls.Add(txtCuerpo)
        Controls.Add(txtAsunto)
        Controls.Add(cmbClientes)
        Name = "Mailing"
        Text = "Mailing"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents cmbClientes As ComboBox
    Friend WithEvents txtAsunto As TextBox
    Friend WithEvents txtCuerpo As TextBox
    Friend WithEvents btnAdjuntar As Button
    Friend WithEvents lblAdjunto As TextBox
    Friend WithEvents ofdPdf As OpenFileDialog
    Friend WithEvents btnEnviar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnCancelar As Button
    Friend WithEvents lblEstado As Label
End Class
