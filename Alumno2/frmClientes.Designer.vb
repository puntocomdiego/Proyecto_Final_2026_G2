<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmClientes
    ' Un solo objeto de acceso a datos para todo el formulario
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
        GroupBox2 = New GroupBox()
        txtDocumento = New MaskedTextBox()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        txtDireccion = New TextBox()
        txtEmail = New TextBox()
        txtTelefono = New TextBox()
        txtApellido = New TextBox()
        txtNombre = New TextBox()
        btnmail = New Button()
        btnNuevo = New Button()
        btnEliminar = New Button()
        btnModificar = New Button()
        btnAgregar = New Button()
        btnCancelar = New Button()
        dgvClientes = New DataGridView()
        Label7 = New Label()
        Panel1 = New Panel()
        Panel2 = New Panel()
        Panel3 = New Panel()
        GroupBox2.SuspendLayout()
        CType(dgvClientes, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        Panel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        GroupBox2.Controls.Add(txtDocumento)
        GroupBox2.Controls.Add(Label6)
        GroupBox2.Controls.Add(Label5)
        GroupBox2.Controls.Add(Label4)
        GroupBox2.Controls.Add(Label3)
        GroupBox2.Controls.Add(Label2)
        GroupBox2.Controls.Add(Label1)
        GroupBox2.Controls.Add(txtDireccion)
        GroupBox2.Controls.Add(txtEmail)
        GroupBox2.Controls.Add(txtTelefono)
        GroupBox2.Controls.Add(txtApellido)
        GroupBox2.Controls.Add(txtNombre)
        GroupBox2.Font = New Font("Segoe UI", 10.2F)
        GroupBox2.Location = New Point(12, 65)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(413, 300)
        GroupBox2.TabIndex = 27
        GroupBox2.TabStop = False
        GroupBox2.Text = "Cliente"
        ' 
        ' txtDocumento
        ' 
        txtDocumento.Font = New Font("Segoe UI", 10.2F)
        txtDocumento.Location = New Point(142, 32)
        txtDocumento.Mask = "0.000.000-0"
        txtDocumento.Name = "txtDocumento"
        txtDocumento.Size = New Size(265, 30)
        txtDocumento.TabIndex = 1
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 10.2F)
        Label6.Location = New Point(7, 39)
        Label6.Name = "Label6"
        Label6.Size = New Size(104, 23)
        Label6.TabIndex = 20
        Label6.Text = "Documento:"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 10.2F)
        Label5.Location = New Point(7, 265)
        Label5.Name = "Label5"
        Label5.Size = New Size(85, 23)
        Label5.TabIndex = 17
        Label5.Text = "Dirección:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 10.2F)
        Label4.Location = New Point(7, 219)
        Label4.Name = "Label4"
        Label4.Size = New Size(55, 23)
        Label4.TabIndex = 16
        Label4.Text = "Email:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 10.2F)
        Label3.Location = New Point(7, 173)
        Label3.Name = "Label3"
        Label3.Size = New Size(78, 23)
        Label3.TabIndex = 15
        Label3.Text = "Teléfono:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10.2F)
        Label2.Location = New Point(7, 127)
        Label2.Name = "Label2"
        Label2.Size = New Size(76, 23)
        Label2.TabIndex = 14
        Label2.Text = "Apellido:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 10.2F)
        Label1.Location = New Point(7, 81)
        Label1.Name = "Label1"
        Label1.Size = New Size(77, 23)
        Label1.TabIndex = 13
        Label1.Text = "Nombre:"
        ' 
        ' txtDireccion
        ' 
        txtDireccion.Font = New Font("Segoe UI", 10.2F)
        txtDireccion.Location = New Point(140, 262)
        txtDireccion.Name = "txtDireccion"
        txtDireccion.Size = New Size(265, 30)
        txtDireccion.TabIndex = 6
        ' 
        ' txtEmail
        ' 
        txtEmail.Font = New Font("Segoe UI", 10.2F)
        txtEmail.Location = New Point(140, 216)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(265, 30)
        txtEmail.TabIndex = 5
        ' 
        ' txtTelefono
        ' 
        txtTelefono.Font = New Font("Segoe UI", 10.2F)
        txtTelefono.Location = New Point(140, 170)
        txtTelefono.Name = "txtTelefono"
        txtTelefono.Size = New Size(265, 30)
        txtTelefono.TabIndex = 4
        ' 
        ' txtApellido
        ' 
        txtApellido.Font = New Font("Segoe UI", 10.2F)
        txtApellido.Location = New Point(140, 124)
        txtApellido.Name = "txtApellido"
        txtApellido.Size = New Size(265, 30)
        txtApellido.TabIndex = 3
        ' 
        ' txtNombre
        ' 
        txtNombre.Font = New Font("Segoe UI", 10.2F)
        txtNombre.Location = New Point(140, 78)
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New Size(265, 30)
        txtNombre.TabIndex = 2
        ' 
        ' btnmail
        ' 
        btnmail.Font = New Font("Segoe UI", 10.2F)
        btnmail.Location = New Point(650, 323)
        btnmail.Name = "btnmail"
        btnmail.Size = New Size(120, 36)
        btnmail.TabIndex = 12
        btnmail.Text = "Ma&iling"
        btnmail.UseVisualStyleBackColor = True
        ' 
        ' btnNuevo
        ' 
        btnNuevo.Font = New Font("Segoe UI", 10.2F)
        btnNuevo.Location = New Point(12, 20)
        btnNuevo.Name = "btnNuevo"
        btnNuevo.Size = New Size(120, 36)
        btnNuevo.TabIndex = 7
        btnNuevo.TabStop = False
        btnNuevo.Text = "&Nuevo"
        btnNuevo.UseVisualStyleBackColor = True
        ' 
        ' btnEliminar
        ' 
        btnEliminar.Font = New Font("Segoe UI", 10.2F)
        btnEliminar.Location = New Point(390, 20)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(120, 36)
        btnEliminar.TabIndex = 11
        btnEliminar.Text = "&Eliminar"
        btnEliminar.UseVisualStyleBackColor = True
        ' 
        ' btnModificar
        ' 
        btnModificar.Font = New Font("Segoe UI", 10.2F)
        btnModificar.Location = New Point(264, 20)
        btnModificar.Name = "btnModificar"
        btnModificar.Size = New Size(120, 36)
        btnModificar.TabIndex = 9
        btnModificar.Text = "&Modificar"
        btnModificar.UseVisualStyleBackColor = True
        ' 
        ' btnAgregar
        ' 
        btnAgregar.Font = New Font("Segoe UI", 10.2F)
        btnAgregar.Location = New Point(138, 20)
        btnAgregar.Name = "btnAgregar"
        btnAgregar.Size = New Size(120, 36)
        btnAgregar.TabIndex = 8
        btnAgregar.Text = "&Guardar"
        btnAgregar.UseVisualStyleBackColor = True
        ' 
        ' btnCancelar
        ' 
        btnCancelar.Font = New Font("Segoe UI", 10.2F)
        btnCancelar.Location = New Point(650, 20)
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Size = New Size(120, 36)
        btnCancelar.TabIndex = 10
        btnCancelar.Text = "&Cancelar"
        btnCancelar.UseVisualStyleBackColor = True
        ' 
        ' dgvClientes
        ' 
        dgvClientes.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvClientes.Location = New Point(12, 371)
        dgvClientes.Name = "dgvClientes"
        dgvClientes.RowHeadersWidth = 51
        dgvClientes.Size = New Size(758, 108)
        dgvClientes.TabIndex = 25
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.White
        Label7.Font = New Font("Segoe UI", 16F)
        Label7.Location = New Point(12, 9)
        Label7.Name = "Label7"
        Label7.Size = New Size(111, 37)
        Label7.TabIndex = 0
        Label7.Text = "Clientes"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.Black
        Panel1.Controls.Add(Label7)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 3)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(782, 56)
        Panel1.TabIndex = 30
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.FromArgb(CByte(0), CByte(192), CByte(192))
        Panel2.Dock = DockStyle.Top
        Panel2.ForeColor = SystemColors.ActiveCaption
        Panel2.Location = New Point(0, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(782, 3)
        Panel2.TabIndex = 31
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.White
        Panel3.Controls.Add(btnCancelar)
        Panel3.Controls.Add(btnEliminar)
        Panel3.Controls.Add(btnNuevo)
        Panel3.Controls.Add(btnModificar)
        Panel3.Controls.Add(btnAgregar)
        Panel3.Dock = DockStyle.Bottom
        Panel3.Location = New Point(0, 485)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(782, 68)
        Panel3.TabIndex = 32
        ' 
        ' frmClientes
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(782, 553)
        Controls.Add(btnmail)
        Controls.Add(Panel3)
        Controls.Add(Panel1)
        Controls.Add(Panel2)
        Controls.Add(GroupBox2)
        Controls.Add(dgvClientes)
        Name = "frmClientes"
        Text = "frmClientes"
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        CType(dgvClientes, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel3.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents picFoto As PictureBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtDocumento As MaskedTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDireccion As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtTelefono As TextBox
    Friend WithEvents txtApellido As TextBox
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents btnmail As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnModificar As Button
    Friend WithEvents btnAgregar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents dgvClientes As DataGridView
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel

End Class
