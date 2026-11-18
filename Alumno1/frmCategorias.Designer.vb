<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCategorias
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
        Label1 = New Label()
        txtNombre = New TextBox()
        GroupBox1 = New GroupBox()
        txtID = New TextBox()
        Label2 = New Label()
        btnAgregar = New Button()
        btnModificar = New Button()
        btnEliminar = New Button()
        btnLimpiar = New Button()
        dgvCategorias = New DataGridView()
        btnfin = New Button()
        Panel1 = New Panel()
        Label3 = New Label()
        Panel2 = New Panel()
        btnNuevo = New Button()
        GroupBox1.SuspendLayout()
        CType(dgvCategorias, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(28, 29)
        Label1.Name = "Label1"
        Label1.Size = New Size(71, 21)
        Label1.TabIndex = 0
        Label1.Text = "Nombre:"
        ' 
        ' txtNombre
        ' 
        txtNombre.Font = New Font("Segoe UI", 12F)
        txtNombre.Location = New Point(105, 26)
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New Size(188, 29)
        txtNombre.TabIndex = 1
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(txtID)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(txtNombre)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Font = New Font("Segoe UI", 12F)
        GroupBox1.Location = New Point(12, 66)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(600, 71)
        GroupBox1.TabIndex = 2
        GroupBox1.TabStop = False
        GroupBox1.Text = "Datos de la Categoría:"
        ' 
        ' txtID
        ' 
        txtID.Font = New Font("Segoe UI", 12F)
        txtID.Location = New Point(393, 26)
        txtID.Name = "txtID"
        txtID.ReadOnly = True
        txtID.Size = New Size(101, 29)
        txtID.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(359, 29)
        Label2.Name = "Label2"
        Label2.Size = New Size(28, 21)
        Label2.TabIndex = 2
        Label2.Text = "ID:"
        ' 
        ' btnAgregar
        ' 
        btnAgregar.Font = New Font("Segoe UI", 12F)
        btnAgregar.Location = New Point(130, 348)
        btnAgregar.Name = "btnAgregar"
        btnAgregar.Size = New Size(120, 36)
        btnAgregar.TabIndex = 14
        btnAgregar.Text = "Agregar"
        btnAgregar.UseVisualStyleBackColor = True
        ' 
        ' btnModificar
        ' 
        btnModificar.Font = New Font("Segoe UI", 12F)
        btnModificar.Location = New Point(252, 348)
        btnModificar.Name = "btnModificar"
        btnModificar.Size = New Size(120, 36)
        btnModificar.TabIndex = 15
        btnModificar.Text = "Modificar"
        btnModificar.UseVisualStyleBackColor = True
        ' 
        ' btnEliminar
        ' 
        btnEliminar.Font = New Font("Segoe UI", 12F)
        btnEliminar.Location = New Point(374, 348)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(120, 36)
        btnEliminar.TabIndex = 16
        btnEliminar.Text = "Eliminar"
        btnEliminar.UseVisualStyleBackColor = True
        ' 
        ' btnLimpiar
        ' 
        btnLimpiar.Font = New Font("Segoe UI", 12F)
        btnLimpiar.Location = New Point(496, 348)
        btnLimpiar.Name = "btnLimpiar"
        btnLimpiar.Size = New Size(120, 36)
        btnLimpiar.TabIndex = 17
        btnLimpiar.Text = "Limpiar"
        btnLimpiar.UseVisualStyleBackColor = True
        ' 
        ' dgvCategorias
        ' 
        dgvCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvCategorias.Location = New Point(12, 146)
        dgvCategorias.Name = "dgvCategorias"
        dgvCategorias.Size = New Size(600, 194)
        dgvCategorias.TabIndex = 18
        ' 
        ' btnfin
        ' 
        btnfin.Font = New Font("Segoe UI", 12F)
        btnfin.Location = New Point(496, 393)
        btnfin.Name = "btnfin"
        btnfin.Size = New Size(120, 36)
        btnfin.TabIndex = 19
        btnfin.Text = "Cerrar"
        btnfin.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Panel1.BackColor = SystemColors.ActiveCaptionText
        Panel1.Controls.Add(Label3)
        Panel1.Location = New Point(-2, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(627, 56)
        Panel1.TabIndex = 32
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 16F, FontStyle.Bold)
        Label3.ForeColor = Color.White
        Label3.Location = New Point(14, 12)
        Label3.Name = "Label3"
        Label3.Size = New Size(241, 30)
        Label3.TabIndex = 4
        Label3.Text = "Gestión de Categorías"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = SystemColors.Highlight
        Panel2.Location = New Point(-2, 55)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(627, 3)
        Panel2.TabIndex = 33
        ' 
        ' btnNuevo
        ' 
        btnNuevo.Font = New Font("Segoe UI", 12F)
        btnNuevo.Location = New Point(8, 348)
        btnNuevo.Name = "btnNuevo"
        btnNuevo.Size = New Size(120, 36)
        btnNuevo.TabIndex = 34
        btnNuevo.Text = "Nuevo"
        btnNuevo.UseVisualStyleBackColor = True
        ' 
        ' frmCategorias
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = btnfin
        ClientSize = New Size(624, 441)
        Controls.Add(btnNuevo)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(btnfin)
        Controls.Add(dgvCategorias)
        Controls.Add(btnLimpiar)
        Controls.Add(btnEliminar)
        Controls.Add(btnModificar)
        Controls.Add(btnAgregar)
        Controls.Add(GroupBox1)
        Name = "frmCategorias"
        Text = "frmCategorias"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(dgvCategorias, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnAgregar As Button
    Friend WithEvents btnModificar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents dgvCategorias As DataGridView
    Friend WithEvents btnfin As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtID As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnNuevo As Button
End Class
