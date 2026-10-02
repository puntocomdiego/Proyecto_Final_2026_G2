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
        picFoto = New PictureBox()
        dgvClientes = New DataGridView()
        btnCargarFoto = New Button()
        btnAgregar = New Button()
        btnModificar = New Button()
        btnEliminar = New Button()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        txtDocumento = New TextBox()
        CType(picFoto, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvClientes, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnFin
        ' 
        btnFin.Location = New Point(581, 396)
        btnFin.Name = "btnFin"
        btnFin.Size = New Size(207, 42)
        btnFin.TabIndex = 0
        btnFin.Text = "Fin"
        btnFin.UseVisualStyleBackColor = True
        ' 
        ' txtNombre
        ' 
        txtNombre.Location = New Point(194, 50)
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New Size(279, 27)
        txtNombre.TabIndex = 1
        ' 
        ' txtApellido
        ' 
        txtApellido.Location = New Point(194, 83)
        txtApellido.Name = "txtApellido"
        txtApellido.Size = New Size(279, 27)
        txtApellido.TabIndex = 2
        ' 
        ' txtTelefono
        ' 
        txtTelefono.Location = New Point(194, 116)
        txtTelefono.Name = "txtTelefono"
        txtTelefono.Size = New Size(279, 27)
        txtTelefono.TabIndex = 3
        ' 
        ' txtEmail
        ' 
        txtEmail.Location = New Point(194, 149)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(279, 27)
        txtEmail.TabIndex = 4
        ' 
        ' txtDireccion
        ' 
        txtDireccion.Location = New Point(194, 185)
        txtDireccion.Name = "txtDireccion"
        txtDireccion.Size = New Size(279, 27)
        txtDireccion.TabIndex = 5
        ' 
        ' picFoto
        ' 
        picFoto.Location = New Point(479, 12)
        picFoto.Name = "picFoto"
        picFoto.Size = New Size(151, 142)
        picFoto.TabIndex = 7
        picFoto.TabStop = False
        ' 
        ' dgvClientes
        ' 
        dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvClientes.Location = New Point(12, 219)
        dgvClientes.Name = "dgvClientes"
        dgvClientes.RowHeadersWidth = 51
        dgvClientes.Size = New Size(776, 171)
        dgvClientes.TabIndex = 8
        ' 
        ' btnCargarFoto
        ' 
        btnCargarFoto.Location = New Point(479, 160)
        btnCargarFoto.Name = "btnCargarFoto"
        btnCargarFoto.Size = New Size(152, 53)
        btnCargarFoto.TabIndex = 9
        btnCargarFoto.Text = "CARGAR FOTO"
        btnCargarFoto.UseVisualStyleBackColor = True
        ' 
        ' btnAgregar
        ' 
        btnAgregar.Location = New Point(636, 12)
        btnAgregar.Name = "btnAgregar"
        btnAgregar.Size = New Size(152, 53)
        btnAgregar.TabIndex = 10
        btnAgregar.Text = "AGREGAR"
        btnAgregar.UseVisualStyleBackColor = True
        ' 
        ' btnModificar
        ' 
        btnModificar.Location = New Point(636, 78)
        btnModificar.Name = "btnModificar"
        btnModificar.Size = New Size(152, 53)
        btnModificar.TabIndex = 11
        btnModificar.Text = "MODIFICAR"
        btnModificar.UseVisualStyleBackColor = True
        ' 
        ' btnEliminar
        ' 
        btnEliminar.Location = New Point(636, 160)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(152, 53)
        btnEliminar.TabIndex = 12
        btnEliminar.Text = "ELIMINAR"
        btnEliminar.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 53)
        Label1.Name = "Label1"
        Label1.Size = New Size(67, 20)
        Label1.TabIndex = 13
        Label1.Text = "Nombre:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(12, 86)
        Label2.Name = "Label2"
        Label2.Size = New Size(69, 20)
        Label2.TabIndex = 14
        Label2.Text = "Apellido:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(12, 119)
        Label3.Name = "Label3"
        Label3.Size = New Size(70, 20)
        Label3.TabIndex = 15
        Label3.Text = "Teléfono:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(12, 152)
        Label4.Name = "Label4"
        Label4.Size = New Size(49, 20)
        Label4.TabIndex = 16
        Label4.Text = "Email:"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(12, 192)
        Label5.Name = "Label5"
        Label5.Size = New Size(75, 20)
        Label5.TabIndex = 17
        Label5.Text = "Dirección:"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(12, 19)
        Label6.Name = "Label6"
        Label6.Size = New Size(90, 20)
        Label6.TabIndex = 20
        Label6.Text = "Documento:"
        ' 
        ' txtDocumento
        ' 
        txtDocumento.Location = New Point(194, 12)
        txtDocumento.Name = "txtDocumento"
        txtDocumento.Size = New Size(279, 27)
        txtDocumento.TabIndex = 19
        ' 
        ' frmClientes
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Label6)
        Controls.Add(txtDocumento)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(btnEliminar)
        Controls.Add(btnModificar)
        Controls.Add(btnAgregar)
        Controls.Add(btnCargarFoto)
        Controls.Add(dgvClientes)
        Controls.Add(picFoto)
        Controls.Add(txtDireccion)
        Controls.Add(txtEmail)
        Controls.Add(txtTelefono)
        Controls.Add(txtApellido)
        Controls.Add(txtNombre)
        Controls.Add(btnFin)
        Name = "frmClientes"
        Text = "frmClientes"
        CType(picFoto, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvClientes, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnFin As Button
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents txtApellido As TextBox
    Friend WithEvents txtTelefono As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtDireccion As TextBox
    Friend WithEvents picFoto As PictureBox
    Friend WithEvents dgvClientes As DataGridView
    Friend WithEvents btnCargarFoto As Button
    Friend WithEvents btnAgregar As Button
    Friend WithEvents btnModificar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtDocumento As TextBox

End Class
