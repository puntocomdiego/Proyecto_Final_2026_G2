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
        btnAgregar = New Button()
        btnModificar = New Button()
        btnEliminar = New Button()
        btnLimpiar = New Button()
        dgvCategorias = New DataGridView()
        GroupBox1.SuspendLayout()
        CType(dgvCategorias, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(18, 40)
        Label1.Name = "Label1"
        Label1.Size = New Size(71, 21)
        Label1.TabIndex = 0
        Label1.Text = "Nombre:"
        ' 
        ' txtNombre
        ' 
        txtNombre.Font = New Font("Segoe UI", 12F)
        txtNombre.Location = New Point(95, 37)
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New Size(248, 29)
        txtNombre.TabIndex = 1
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(txtNombre)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Font = New Font("Segoe UI", 12F)
        GroupBox1.Location = New Point(28, 29)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(463, 91)
        GroupBox1.TabIndex = 2
        GroupBox1.TabStop = False
        GroupBox1.Text = "Datos de la Categoría:"
        ' 
        ' btnAgregar
        ' 
        btnAgregar.Font = New Font("Segoe UI", 12F)
        btnAgregar.Location = New Point(28, 144)
        btnAgregar.Name = "btnAgregar"
        btnAgregar.Size = New Size(89, 39)
        btnAgregar.TabIndex = 14
        btnAgregar.Text = "Agregar"
        btnAgregar.UseVisualStyleBackColor = True
        ' 
        ' btnModificar
        ' 
        btnModificar.Font = New Font("Segoe UI", 12F)
        btnModificar.Location = New Point(155, 144)
        btnModificar.Name = "btnModificar"
        btnModificar.Size = New Size(89, 39)
        btnModificar.TabIndex = 15
        btnModificar.Text = "Modificar"
        btnModificar.UseVisualStyleBackColor = True
        ' 
        ' btnEliminar
        ' 
        btnEliminar.Font = New Font("Segoe UI", 12F)
        btnEliminar.Location = New Point(282, 144)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(89, 39)
        btnEliminar.TabIndex = 16
        btnEliminar.Text = "Eliminar"
        btnEliminar.UseVisualStyleBackColor = True
        ' 
        ' btnLimpiar
        ' 
        btnLimpiar.Font = New Font("Segoe UI", 12F)
        btnLimpiar.Location = New Point(402, 144)
        btnLimpiar.Name = "btnLimpiar"
        btnLimpiar.Size = New Size(89, 39)
        btnLimpiar.TabIndex = 17
        btnLimpiar.Text = "Limpiar"
        btnLimpiar.UseVisualStyleBackColor = True
        ' 
        ' dgvCategorias
        ' 
        dgvCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvCategorias.Location = New Point(28, 210)
        dgvCategorias.Name = "dgvCategorias"
        dgvCategorias.Size = New Size(463, 216)
        dgvCategorias.TabIndex = 18
        ' 
        ' frmCategorias
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(524, 450)
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
End Class
