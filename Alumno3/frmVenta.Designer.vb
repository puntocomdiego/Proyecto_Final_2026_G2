<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVenta
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
        btnConfirmar = New Button()
        Label1 = New Label()
        cboCliente = New ComboBox()
        cboCategoria = New ComboBox()
        Label2 = New Label()
        Label3 = New Label()
        txtCantidad = New TextBox()
        dgvVenta = New DataGridView()
        btnAgregar = New Button()
        btnNuevo = New Button()
        btnEliminar = New Button()
        cboProducto = New ComboBox()
        btnEditar = New Button()
        GroupBox1 = New GroupBox()
        Label4 = New Label()
        CType(dgvVenta, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnConfirmar
        ' 
        btnConfirmar.BackColor = SystemColors.GradientInactiveCaption
        btnConfirmar.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold)
        btnConfirmar.Location = New Point(8, 22)
        btnConfirmar.Name = "btnConfirmar"
        btnConfirmar.Size = New Size(144, 66)
        btnConfirmar.TabIndex = 0
        btnConfirmar.Text = "Confirmar Venta"
        btnConfirmar.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Semibold", 11F, FontStyle.Bold)
        Label1.Location = New Point(36, 24)
        Label1.Name = "Label1"
        Label1.Size = New Size(60, 20)
        Label1.TabIndex = 1
        Label1.Text = "Cliente:"
        ' 
        ' cboCliente
        ' 
        cboCliente.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        cboCliente.FormattingEnabled = True
        cboCliente.Location = New Point(102, 21)
        cboCliente.Name = "cboCliente"
        cboCliente.Size = New Size(164, 23)
        cboCliente.TabIndex = 2
        ' 
        ' cboCategoria
        ' 
        cboCategoria.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        cboCategoria.FormattingEnabled = True
        cboCategoria.Location = New Point(102, 56)
        cboCategoria.Name = "cboCategoria"
        cboCategoria.Size = New Size(164, 23)
        cboCategoria.TabIndex = 4
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI Semibold", 11F, FontStyle.Bold)
        Label2.Location = New Point(17, 59)
        Label2.Name = "Label2"
        Label2.Size = New Size(79, 20)
        Label2.TabIndex = 3
        Label2.Text = "Categoria:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI Semibold", 11F, FontStyle.Bold)
        Label3.Location = New Point(284, 88)
        Label3.Name = "Label3"
        Label3.Size = New Size(74, 20)
        Label3.TabIndex = 5
        Label3.Text = "Cantidad:"
        ' 
        ' txtCantidad
        ' 
        txtCantidad.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        txtCantidad.Location = New Point(358, 87)
        txtCantidad.Name = "txtCantidad"
        txtCantidad.Size = New Size(65, 23)
        txtCantidad.TabIndex = 6
        ' 
        ' dgvVenta
        ' 
        dgvVenta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvVenta.Location = New Point(12, 125)
        dgvVenta.Name = "dgvVenta"
        dgvVenta.Size = New Size(537, 313)
        dgvVenta.TabIndex = 7
        ' 
        ' btnAgregar
        ' 
        btnAgregar.BackColor = SystemColors.GradientInactiveCaption
        btnAgregar.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold)
        btnAgregar.Location = New Point(330, 24)
        btnAgregar.Name = "btnAgregar"
        btnAgregar.Size = New Size(122, 44)
        btnAgregar.TabIndex = 8
        btnAgregar.Text = "Agregar"
        btnAgregar.UseVisualStyleBackColor = False
        ' 
        ' btnNuevo
        ' 
        btnNuevo.BackColor = SystemColors.GradientInactiveCaption
        btnNuevo.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold)
        btnNuevo.Location = New Point(577, 12)
        btnNuevo.Name = "btnNuevo"
        btnNuevo.Size = New Size(144, 53)
        btnNuevo.TabIndex = 9
        btnNuevo.Text = "Nueva Venta"
        btnNuevo.UseVisualStyleBackColor = False
        ' 
        ' btnEliminar
        ' 
        btnEliminar.BackColor = SystemColors.GradientInactiveCaption
        btnEliminar.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold)
        btnEliminar.Location = New Point(8, 176)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(144, 37)
        btnEliminar.TabIndex = 10
        btnEliminar.Text = "Eliminar"
        btnEliminar.UseVisualStyleBackColor = False
        ' 
        ' cboProducto
        ' 
        cboProducto.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        cboProducto.FormattingEnabled = True
        cboProducto.Location = New Point(102, 85)
        cboProducto.Name = "cboProducto"
        cboProducto.Size = New Size(164, 23)
        cboProducto.TabIndex = 11
        ' 
        ' btnEditar
        ' 
        btnEditar.BackColor = SystemColors.GradientInactiveCaption
        btnEditar.DialogResult = DialogResult.Continue
        btnEditar.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold)
        btnEditar.Location = New Point(8, 124)
        btnEditar.Name = "btnEditar"
        btnEditar.Size = New Size(144, 37)
        btnEditar.TabIndex = 12
        btnEditar.Text = "Editar"
        btnEditar.UseVisualStyleBackColor = False
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(btnEditar)
        GroupBox1.Controls.Add(btnConfirmar)
        GroupBox1.Controls.Add(btnEliminar)
        GroupBox1.Location = New Point(569, 113)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(158, 238)
        GroupBox1.TabIndex = 13
        GroupBox1.TabStop = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI Semibold", 11F, FontStyle.Bold)
        Label4.Location = New Point(20, 88)
        Label4.Name = "Label4"
        Label4.Size = New Size(76, 20)
        Label4.TabIndex = 14
        Label4.Text = "Producto:"
        ' 
        ' frmVenta
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(745, 450)
        Controls.Add(Label4)
        Controls.Add(GroupBox1)
        Controls.Add(cboProducto)
        Controls.Add(btnNuevo)
        Controls.Add(btnAgregar)
        Controls.Add(dgvVenta)
        Controls.Add(txtCantidad)
        Controls.Add(Label3)
        Controls.Add(cboCategoria)
        Controls.Add(Label2)
        Controls.Add(cboCliente)
        Controls.Add(Label1)
        Name = "frmVenta"
        Text = "frmVenta"
        CType(dgvVenta, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnConfirmar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents cboCliente As ComboBox
    Friend WithEvents cboCategoria As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents dgvVenta As DataGridView
    Friend WithEvents btnAgregar As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents cboProducto As ComboBox
    Friend WithEvents btnEditar As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label4 As Label
End Class
