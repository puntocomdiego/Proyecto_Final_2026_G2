<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMailing
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        cmbClientes = New ComboBox()
        txtAsunto = New TextBox()
        txtCuerpo = New TextBox()
        btnAdjuntar = New Button()
        txtAdjunto = New TextBox()
        ofdPdf = New OpenFileDialog()
        btnEnviar = New Button()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        btnCancelar = New Button()
        lblEstado = New Label()
        btnCerrar = New Button()
        lblInfoAuto = New Label()
        btnCargarOtro = New Button()
        Panel1 = New Panel()
        Label4 = New Label()
        Panel2 = New Panel()
        Panel3 = New Panel()
        Panel1.SuspendLayout()
        Panel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' cmbClientes
        ' 
        cmbClientes.FormattingEnabled = True
        cmbClientes.Location = New Point(221, 103)
        cmbClientes.Name = "cmbClientes"
        cmbClientes.Size = New Size(345, 28)
        cmbClientes.TabIndex = 0
        ' 
        ' txtAsunto
        ' 
        txtAsunto.Location = New Point(221, 137)
        txtAsunto.Name = "txtAsunto"
        txtAsunto.Size = New Size(345, 27)
        txtAsunto.TabIndex = 1
        ' 
        ' txtCuerpo
        ' 
        txtCuerpo.Location = New Point(221, 170)
        txtCuerpo.Multiline = True
        txtCuerpo.Name = "txtCuerpo"
        txtCuerpo.Size = New Size(345, 94)
        txtCuerpo.TabIndex = 2
        ' 
        ' btnAdjuntar
        ' 
        btnAdjuntar.Location = New Point(334, 287)
        btnAdjuntar.Name = "btnAdjuntar"
        btnAdjuntar.Size = New Size(123, 60)
        btnAdjuntar.TabIndex = 3
        btnAdjuntar.Text = "Adjuntar PDF de ofertas"
        btnAdjuntar.UseVisualStyleBackColor = True
        ' 
        ' txtAdjunto
        ' 
        txtAdjunto.Location = New Point(12, 304)
        txtAdjunto.Name = "txtAdjunto"
        txtAdjunto.ReadOnly = True
        txtAdjunto.Size = New Size(316, 27)
        txtAdjunto.TabIndex = 4
        txtAdjunto.Text = "Ningún archivo adjunto..."
        ' 
        ' ofdPdf
        ' 
        ofdPdf.FileName = "OpenFileDialog1"
        ' 
        ' btnEnviar
        ' 
        btnEnviar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnEnviar.Location = New Point(12, 12)
        btnEnviar.Name = "btnEnviar"
        btnEnviar.Size = New Size(160, 44)
        btnEnviar.TabIndex = 5
        btnEnviar.Text = "&Enviar correo"
        btnEnviar.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.Location = New Point(74, 103)
        Label1.Name = "Label1"
        Label1.Size = New Size(141, 28)
        Label1.TabIndex = 6
        Label1.Text = "PARA (Cliente):"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F)
        Label2.Location = New Point(122, 137)
        Label2.Name = "Label2"
        Label2.Size = New Size(93, 28)
        Label2.TabIndex = 7
        Label2.Text = "ASUNTO:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F)
        Label3.Location = New Point(1, 170)
        Label3.Name = "Label3"
        Label3.Size = New Size(214, 28)
        Label3.TabIndex = 8
        Label3.Text = "MENSAJE DE OFERTAS:"
        ' 
        ' btnCancelar
        ' 
        btnCancelar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnCancelar.Location = New Point(178, 16)
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Size = New Size(120, 36)
        btnCancelar.TabIndex = 9
        btnCancelar.Text = "&Cancelar"
        btnCancelar.UseVisualStyleBackColor = True
        ' 
        ' lblEstado
        ' 
        lblEstado.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        lblEstado.AutoSize = True
        lblEstado.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblEstado.Location = New Point(12, 374)
        lblEstado.Name = "lblEstado"
        lblEstado.Size = New Size(257, 31)
        lblEstado.TabIndex = 10
        lblEstado.Text = "Esperando para enviar..."
        ' 
        ' btnCerrar
        ' 
        btnCerrar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnCerrar.Location = New Point(490, 16)
        btnCerrar.Name = "btnCerrar"
        btnCerrar.Size = New Size(120, 36)
        btnCerrar.TabIndex = 11
        btnCerrar.Text = "&Cerrar"
        btnCerrar.UseVisualStyleBackColor = True
        ' 
        ' lblInfoAuto
        ' 
        lblInfoAuto.AutoSize = True
        lblInfoAuto.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblInfoAuto.ForeColor = Color.FromArgb(CByte(90), CByte(90), CByte(102))
        lblInfoAuto.Location = New Point(12, 342)
        lblInfoAuto.Name = "lblInfoAuto"
        lblInfoAuto.Size = New Size(336, 20)
        lblInfoAuto.TabIndex = 12
        lblInfoAuto.Text = "Catálogo de este mes cargado automáticamente."
        lblInfoAuto.Visible = False
        ' 
        ' btnCargarOtro
        ' 
        btnCargarOtro.Location = New Point(463, 287)
        btnCargarOtro.Name = "btnCargarOtro"
        btnCargarOtro.Size = New Size(123, 60)
        btnCargarOtro.TabIndex = 13
        btnCargarOtro.Text = "Elegir otro"
        btnCargarOtro.UseVisualStyleBackColor = True
        btnCargarOtro.Visible = False
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.Black
        Panel1.Controls.Add(Label4)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(622, 56)
        Panel1.TabIndex = 14
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.White
        Label4.Font = New Font("Segoe UI", 16F)
        Label4.Location = New Point(12, 9)
        Label4.Name = "Label4"
        Label4.Size = New Size(107, 37)
        Label4.TabIndex = 0
        Label4.Text = "Mailing"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.FromArgb(CByte(0), CByte(192), CByte(192))
        Panel2.Dock = DockStyle.Top
        Panel2.ForeColor = SystemColors.ActiveCaption
        Panel2.Location = New Point(0, 56)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(622, 3)
        Panel2.TabIndex = 15
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.White
        Panel3.Controls.Add(btnEnviar)
        Panel3.Controls.Add(btnCancelar)
        Panel3.Controls.Add(btnCerrar)
        Panel3.Dock = DockStyle.Bottom
        Panel3.Location = New Point(0, 365)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(622, 68)
        Panel3.TabIndex = 16
        ' 
        ' frmMailing
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(622, 433)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(btnCargarOtro)
        Controls.Add(lblInfoAuto)
        Controls.Add(lblEstado)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(txtAdjunto)
        Controls.Add(btnAdjuntar)
        Controls.Add(txtCuerpo)
        Controls.Add(txtAsunto)
        Controls.Add(cmbClientes)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Name = "frmMailing"
        Text = "frmMailing"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel3.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents cmbClientes As ComboBox
    Friend WithEvents txtAsunto As TextBox
    Friend WithEvents txtCuerpo As TextBox
    Friend WithEvents btnAdjuntar As Button
    Friend WithEvents txtAdjunto As TextBox
    Friend WithEvents ofdPdf As OpenFileDialog
    Friend WithEvents btnEnviar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnCancelar As Button
    Friend WithEvents lblEstado As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblInfoAuto As Label
    Friend WithEvents btnCargarOtro As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
End Class
