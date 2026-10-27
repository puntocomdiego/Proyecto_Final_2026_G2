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
        btnFin = New Button()
        txtNombre = New TextBox()
        txtApellido = New TextBox()
        txtTelefono = New TextBox()
        txtEmail = New TextBox()
        txtDireccion = New TextBox()
        dgvClientes = New DataGridView()
        btnCancelar = New Button()
        btnAgregar = New Button()
        btnModificar = New Button()
        btnEliminar = New Button()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        txtDocumento = New MaskedTextBox()
        btnNuevo = New Button()
        GroupBox1 = New GroupBox()
        GroupBox2 = New GroupBox()
        CType(dgvClientes, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        GroupBox2.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnFin
        ' 
        btnFin.Font = New Font("Stencil", 13F, FontStyle.Bold)
        btnFin.Location = New Point(17, 256)
        btnFin.Name = "btnFin"
        btnFin.Size = New Size(140, 40)
        btnFin.TabIndex = 0
        btnFin.Text = "&Fin"
        btnFin.UseVisualStyleBackColor = True
        ' 
        ' txtNombre
        ' 
        txtNombre.Font = New Font("Arial Rounded MT Bold", 12F)
        txtNombre.Location = New Point(142, 68)
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New Size(265, 31)
        txtNombre.TabIndex = 1
        ' 
        ' txtApellido
        ' 
        txtApellido.Font = New Font("Arial Rounded MT Bold", 12F)
        txtApellido.Location = New Point(142, 105)
        txtApellido.Name = "txtApellido"
        txtApellido.Size = New Size(265, 31)
        txtApellido.TabIndex = 2
        ' 
        ' txtTelefono
        ' 
        txtTelefono.Font = New Font("Arial Rounded MT Bold", 12F)
        txtTelefono.Location = New Point(142, 142)
        txtTelefono.Name = "txtTelefono"
        txtTelefono.Size = New Size(265, 31)
        txtTelefono.TabIndex = 3
        ' 
        ' txtEmail
        ' 
        txtEmail.Font = New Font("Arial Rounded MT Bold", 12F)
        txtEmail.Location = New Point(142, 179)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(265, 31)
        txtEmail.TabIndex = 4
        ' 
        ' txtDireccion
        ' 
        txtDireccion.Font = New Font("Arial Rounded MT Bold", 12F)
        txtDireccion.Location = New Point(142, 216)
        txtDireccion.Name = "txtDireccion"
        txtDireccion.Size = New Size(265, 31)
        txtDireccion.TabIndex = 5
        ' 
        ' dgvClientes
        ' 
        dgvClientes.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvClientes.Location = New Point(12, 333)
        dgvClientes.Name = "dgvClientes"
        dgvClientes.RowHeadersWidth = 51
        dgvClientes.Size = New Size(596, 257)
        dgvClientes.TabIndex = 8
        ' 
        ' btnCancelar
        ' 
        btnCancelar.Font = New Font("Stencil", 13F, FontStyle.Bold)
        btnCancelar.Location = New Point(17, 164)
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Size = New Size(140, 40)
        btnCancelar.TabIndex = 9
        btnCancelar.Text = "&CANCELAR"
        btnCancelar.UseVisualStyleBackColor = True
        ' 
        ' btnAgregar
        ' 
        btnAgregar.Font = New Font("Stencil", 13F, FontStyle.Bold)
        btnAgregar.Location = New Point(17, 72)
        btnAgregar.Name = "btnAgregar"
        btnAgregar.Size = New Size(140, 40)
        btnAgregar.TabIndex = 10
        btnAgregar.Text = "&AGREGAR"
        btnAgregar.UseVisualStyleBackColor = True
        ' 
        ' btnModificar
        ' 
        btnModificar.Font = New Font("Stencil", 13F, FontStyle.Bold)
        btnModificar.Location = New Point(17, 118)
        btnModificar.Name = "btnModificar"
        btnModificar.Size = New Size(140, 40)
        btnModificar.TabIndex = 11
        btnModificar.Text = "&MODIFICAR"
        btnModificar.UseVisualStyleBackColor = True
        ' 
        ' btnEliminar
        ' 
        btnEliminar.Font = New Font("Stencil", 13F, FontStyle.Bold)
        btnEliminar.Location = New Point(17, 210)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(140, 40)
        btnEliminar.TabIndex = 12
        btnEliminar.Text = "ELIMINAR"
        btnEliminar.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial Rounded MT Bold", 12F)
        Label1.Location = New Point(6, 76)
        Label1.Name = "Label1"
        Label1.Size = New Size(95, 23)
        Label1.TabIndex = 13
        Label1.Text = "Nombre:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Arial Rounded MT Bold", 12F)
        Label2.Location = New Point(6, 113)
        Label2.Name = "Label2"
        Label2.Size = New Size(95, 23)
        Label2.TabIndex = 14
        Label2.Text = "Apellido:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Arial Rounded MT Bold", 12F)
        Label3.Location = New Point(6, 150)
        Label3.Name = "Label3"
        Label3.Size = New Size(101, 23)
        Label3.TabIndex = 15
        Label3.Text = "Teléfono:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Arial Rounded MT Bold", 12F)
        Label4.Location = New Point(6, 187)
        Label4.Name = "Label4"
        Label4.Size = New Size(69, 23)
        Label4.TabIndex = 16
        Label4.Text = "Email:"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Arial Rounded MT Bold", 12F)
        Label5.Location = New Point(6, 224)
        Label5.Name = "Label5"
        Label5.Size = New Size(110, 23)
        Label5.TabIndex = 17
        Label5.Text = "Dirección:"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(6, 39)
        Label6.Name = "Label6"
        Label6.Size = New Size(128, 23)
        Label6.TabIndex = 20
        Label6.Text = "Documento:"
        ' 
        ' txtDocumento
        ' 
        txtDocumento.Font = New Font("Arial Rounded MT Bold", 12F)
        txtDocumento.Location = New Point(142, 31)
        txtDocumento.Mask = "0.000.000-0"
        txtDocumento.Name = "txtDocumento"
        txtDocumento.Size = New Size(265, 31)
        txtDocumento.TabIndex = 21
        ' 
        ' btnNuevo
        ' 
        btnNuevo.Font = New Font("Stencil", 13F, FontStyle.Bold)
        btnNuevo.Location = New Point(17, 26)
        btnNuevo.Name = "btnNuevo"
        btnNuevo.Size = New Size(140, 40)
        btnNuevo.TabIndex = 22
        btnNuevo.TabStop = False
        btnNuevo.Text = "&NUEVO"
        btnNuevo.UseVisualStyleBackColor = True
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        GroupBox1.Controls.Add(btnNuevo)
        GroupBox1.Controls.Add(btnEliminar)
        GroupBox1.Controls.Add(btnModificar)
        GroupBox1.Controls.Add(btnAgregar)
        GroupBox1.Controls.Add(btnCancelar)
        GroupBox1.Controls.Add(btnFin)
        GroupBox1.Location = New Point(431, 12)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(177, 315)
        GroupBox1.TabIndex = 23
        GroupBox1.TabStop = False
        GroupBox1.Text = "Acciones"
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
        GroupBox2.Location = New Point(12, 12)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(413, 272)
        GroupBox2.TabIndex = 24
        GroupBox2.TabStop = False
        GroupBox2.Text = "Cliente"
        ' 
        ' frmClientes
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(620, 602)
        Controls.Add(GroupBox2)
        Controls.Add(GroupBox1)
        Controls.Add(dgvClientes)
        Name = "frmClientes"
        Text = "frmClientes"
        CType(dgvClientes, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnFin As Button
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents txtApellido As TextBox
    Friend WithEvents txtTelefono As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtDireccion As TextBox
    Friend WithEvents picFoto As PictureBox
    Friend WithEvents dgvClientes As DataGridView
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnAgregar As Button
    Friend WithEvents btnModificar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtDocumento As MaskedTextBox
    Friend WithEvents btnNuevo As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox

End Class
