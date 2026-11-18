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
        btnAgregar = New Button()
        btnNuevo = New Button()
        btnEliminar = New Button()
        cboDescripcion = New ComboBox()
        btnEditar = New Button()
        GroupBox1 = New GroupBox()
        lblTotal = New Label()
        Label5 = New Label()
        GroupBox2 = New GroupBox()
        rbtEfectivo = New RadioButton()
        rbtTransf = New RadioButton()
        rbtCredito = New RadioButton()
        rbtDebito = New RadioButton()
        btnCerrar = New Button()
        Label4 = New Label()
        dgvTemp = New DataGridView()
        btnConsulta = New Button()
        Panel1 = New Panel()
        GroupBox3 = New GroupBox()
        Panel2 = New Panel()
        Panel3 = New Panel()
        Label6 = New Label()
        GroupBox1.SuspendLayout()
        GroupBox2.SuspendLayout()
        CType(dgvTemp, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        GroupBox3.SuspendLayout()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnConfirmar
        ' 
        btnConfirmar.BackColor = SystemColors.ButtonHighlight
        btnConfirmar.Enabled = False
        btnConfirmar.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold)
        btnConfirmar.Location = New Point(16, 182)
        btnConfirmar.Name = "btnConfirmar"
        btnConfirmar.Size = New Size(160, 44)
        btnConfirmar.TabIndex = 11
        btnConfirmar.Text = "Confirmar Venta"
        btnConfirmar.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Semibold", 11F, FontStyle.Bold)
        Label1.Location = New Point(28, 21)
        Label1.Name = "Label1"
        Label1.Size = New Size(60, 20)
        Label1.TabIndex = 1
        Label1.Text = "Cliente:"
        ' 
        ' cboCliente
        ' 
        cboCliente.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        cboCliente.FormattingEnabled = True
        cboCliente.Location = New Point(94, 18)
        cboCliente.Name = "cboCliente"
        cboCliente.Size = New Size(164, 23)
        cboCliente.TabIndex = 2
        ' 
        ' cboCategoria
        ' 
        cboCategoria.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        cboCategoria.FormattingEnabled = True
        cboCategoria.Location = New Point(362, 15)
        cboCategoria.Name = "cboCategoria"
        cboCategoria.Size = New Size(164, 23)
        cboCategoria.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI Semibold", 11F, FontStyle.Bold)
        Label2.Location = New Point(277, 18)
        Label2.Name = "Label2"
        Label2.Size = New Size(79, 20)
        Label2.TabIndex = 3
        Label2.Text = "Categoria:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI Semibold", 11F, FontStyle.Bold)
        Label3.Location = New Point(282, 86)
        Label3.Name = "Label3"
        Label3.Size = New Size(74, 20)
        Label3.TabIndex = 5
        Label3.Text = "Cantidad:"
        ' 
        ' txtCantidad
        ' 
        txtCantidad.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        txtCantidad.Location = New Point(362, 86)
        txtCantidad.Name = "txtCantidad"
        txtCantidad.Size = New Size(46, 23)
        txtCantidad.TabIndex = 5
        ' 
        ' btnAgregar
        ' 
        btnAgregar.BackColor = SystemColors.ButtonHighlight
        btnAgregar.Enabled = False
        btnAgregar.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold)
        btnAgregar.Location = New Point(598, 24)
        btnAgregar.Name = "btnAgregar"
        btnAgregar.Size = New Size(120, 36)
        btnAgregar.TabIndex = 6
        btnAgregar.Text = "Agregar"
        btnAgregar.UseVisualStyleBackColor = False
        ' 
        ' btnNuevo
        ' 
        btnNuevo.BackColor = SystemColors.ButtonHighlight
        btnNuevo.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold)
        btnNuevo.Location = New Point(12, 15)
        btnNuevo.Name = "btnNuevo"
        btnNuevo.Size = New Size(120, 36)
        btnNuevo.TabIndex = 1
        btnNuevo.Text = "Nuevo"
        btnNuevo.UseVisualStyleBackColor = False
        ' 
        ' btnEliminar
        ' 
        btnEliminar.BackColor = SystemColors.ButtonHighlight
        btnEliminar.Enabled = False
        btnEliminar.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold)
        btnEliminar.Location = New Point(264, 15)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(120, 36)
        btnEliminar.TabIndex = 13
        btnEliminar.Text = "Eliminar"
        btnEliminar.UseVisualStyleBackColor = False
        ' 
        ' cboDescripcion
        ' 
        cboDescripcion.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        cboDescripcion.FormattingEnabled = True
        cboDescripcion.Location = New Point(362, 48)
        cboDescripcion.Name = "cboDescripcion"
        cboDescripcion.Size = New Size(164, 23)
        cboDescripcion.TabIndex = 4
        ' 
        ' btnEditar
        ' 
        btnEditar.BackColor = SystemColors.ButtonHighlight
        btnEditar.DialogResult = DialogResult.Continue
        btnEditar.Enabled = False
        btnEditar.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold)
        btnEditar.Location = New Point(138, 15)
        btnEditar.Name = "btnEditar"
        btnEditar.Size = New Size(120, 36)
        btnEditar.TabIndex = 12
        btnEditar.Text = "Editar"
        btnEditar.UseVisualStyleBackColor = False
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(lblTotal)
        GroupBox1.Controls.Add(Label5)
        GroupBox1.Controls.Add(GroupBox2)
        GroupBox1.Controls.Add(btnConfirmar)
        GroupBox1.Location = New Point(581, 192)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(193, 242)
        GroupBox1.TabIndex = 13
        GroupBox1.TabStop = False
        ' 
        ' lblTotal
        ' 
        lblTotal.Font = New Font("Segoe UI Semibold", 14F, FontStyle.Bold)
        lblTotal.Location = New Point(6, 60)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(181, 23)
        lblTotal.TabIndex = 17
        lblTotal.Text = "$ 00.0"
        lblTotal.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label5
        ' 
        Label5.Font = New Font("Segoe UI Semibold", 11F, FontStyle.Bold)
        Label5.Location = New Point(6, 21)
        Label5.Name = "Label5"
        Label5.Size = New Size(181, 20)
        Label5.TabIndex = 17
        Label5.Text = "TOTAL:"
        Label5.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(rbtEfectivo)
        GroupBox2.Controls.Add(rbtTransf)
        GroupBox2.Controls.Add(rbtCredito)
        GroupBox2.Controls.Add(rbtDebito)
        GroupBox2.Location = New Point(6, 91)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(181, 85)
        GroupBox2.TabIndex = 13
        GroupBox2.TabStop = False
        GroupBox2.Text = "Metodo de Pago"
        ' 
        ' rbtEfectivo
        ' 
        rbtEfectivo.AutoSize = True
        rbtEfectivo.Enabled = False
        rbtEfectivo.Location = New Point(79, 53)
        rbtEfectivo.Name = "rbtEfectivo"
        rbtEfectivo.Size = New Size(74, 23)
        rbtEfectivo.TabIndex = 10
        rbtEfectivo.TabStop = True
        rbtEfectivo.Text = "Efectivo"
        rbtEfectivo.UseVisualStyleBackColor = True
        ' 
        ' rbtTransf
        ' 
        rbtTransf.Enabled = False
        rbtTransf.Location = New Point(79, 25)
        rbtTransf.Name = "rbtTransf"
        rbtTransf.Size = New Size(106, 23)
        rbtTransf.TabIndex = 8
        rbtTransf.TabStop = True
        rbtTransf.Text = "Transferencia"
        rbtTransf.UseVisualStyleBackColor = True
        ' 
        ' rbtCredito
        ' 
        rbtCredito.AutoSize = True
        rbtCredito.Enabled = False
        rbtCredito.Location = New Point(10, 53)
        rbtCredito.Name = "rbtCredito"
        rbtCredito.Size = New Size(72, 23)
        rbtCredito.TabIndex = 9
        rbtCredito.TabStop = True
        rbtCredito.Text = "Crédito"
        rbtCredito.UseVisualStyleBackColor = True
        ' 
        ' rbtDebito
        ' 
        rbtDebito.AutoSize = True
        rbtDebito.Enabled = False
        rbtDebito.Location = New Point(10, 25)
        rbtDebito.Name = "rbtDebito"
        rbtDebito.Size = New Size(68, 23)
        rbtDebito.TabIndex = 7
        rbtDebito.TabStop = True
        rbtDebito.Text = "Débito"
        rbtDebito.UseVisualStyleBackColor = True
        ' 
        ' btnCerrar
        ' 
        btnCerrar.BackColor = SystemColors.ButtonHighlight
        btnCerrar.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold)
        btnCerrar.Location = New Point(654, 15)
        btnCerrar.Name = "btnCerrar"
        btnCerrar.Size = New Size(120, 36)
        btnCerrar.TabIndex = 14
        btnCerrar.Text = "Cerrar"
        btnCerrar.UseVisualStyleBackColor = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI Semibold", 11F, FontStyle.Bold)
        Label4.Location = New Point(280, 51)
        Label4.Name = "Label4"
        Label4.Size = New Size(76, 20)
        Label4.TabIndex = 14
        Label4.Text = "Producto:"
        ' 
        ' dgvTemp
        ' 
        dgvTemp.AllowUserToAddRows = False
        dgvTemp.AllowUserToDeleteRows = False
        dgvTemp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvTemp.BorderStyle = BorderStyle.None
        dgvTemp.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvTemp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvTemp.EnableHeadersVisualStyles = False
        dgvTemp.Location = New Point(12, 192)
        dgvTemp.MultiSelect = False
        dgvTemp.Name = "dgvTemp"
        dgvTemp.ReadOnly = True
        dgvTemp.RowHeadersVisible = False
        dgvTemp.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgvTemp.RowTemplate.Height = 32
        dgvTemp.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvTemp.Size = New Size(561, 305)
        dgvTemp.TabIndex = 16
        ' 
        ' btnConsulta
        ' 
        btnConsulta.BackColor = SystemColors.ButtonHighlight
        btnConsulta.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold)
        btnConsulta.Location = New Point(390, 15)
        btnConsulta.Name = "btnConsulta"
        btnConsulta.Size = New Size(140, 36)
        btnConsulta.TabIndex = 17
        btnConsulta.Text = "Consultar Ventas"
        btnConsulta.UseVisualStyleBackColor = False
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.ButtonHighlight
        Panel1.Controls.Add(btnConsulta)
        Panel1.Controls.Add(btnCerrar)
        Panel1.Controls.Add(btnNuevo)
        Panel1.Controls.Add(btnEditar)
        Panel1.Controls.Add(btnEliminar)
        Panel1.Dock = DockStyle.Bottom
        Panel1.Location = New Point(0, 500)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(784, 61)
        Panel1.TabIndex = 18
        ' 
        ' GroupBox3
        ' 
        GroupBox3.Controls.Add(btnAgregar)
        GroupBox3.Controls.Add(Label4)
        GroupBox3.Controls.Add(Label1)
        GroupBox3.Controls.Add(cboCliente)
        GroupBox3.Controls.Add(cboDescripcion)
        GroupBox3.Controls.Add(Label2)
        GroupBox3.Controls.Add(cboCategoria)
        GroupBox3.Controls.Add(txtCantidad)
        GroupBox3.Controls.Add(Label3)
        GroupBox3.Location = New Point(12, 62)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New Size(762, 124)
        GroupBox3.TabIndex = 19
        GroupBox3.TabStop = False
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = SystemColors.Highlight
        Panel2.Controls.Add(Panel3)
        Panel2.Dock = DockStyle.Top
        Panel2.ForeColor = SystemColors.MenuHighlight
        Panel2.Location = New Point(0, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(784, 59)
        Panel2.TabIndex = 20
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = SystemColors.ActiveCaptionText
        Panel3.Controls.Add(Label6)
        Panel3.Dock = DockStyle.Top
        Panel3.Location = New Point(0, 0)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(784, 56)
        Panel3.TabIndex = 0
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = SystemColors.HighlightText
        Label6.Location = New Point(12, 9)
        Label6.Name = "Label6"
        Label6.Size = New Size(67, 30)
        Label6.TabIndex = 21
        Label6.Text = "Venta"
        ' 
        ' frmVenta
        ' 
        AcceptButton = btnAgregar
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.Control
        CancelButton = btnCerrar
        ClientSize = New Size(784, 561)
        Controls.Add(Panel2)
        Controls.Add(dgvTemp)
        Controls.Add(GroupBox1)
        Controls.Add(Panel1)
        Controls.Add(GroupBox3)
        Font = New Font("Segoe UI", 10F)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "frmVenta"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Ventas"
        GroupBox1.ResumeLayout(False)
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        CType(dgvTemp, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        GroupBox3.ResumeLayout(False)
        GroupBox3.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnConfirmar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents cboCliente As ComboBox
    Friend WithEvents cboCategoria As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents btnAgregar As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents cboDescripcion As ComboBox
    Friend WithEvents btnEditar As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents rbtCredito As RadioButton
    Friend WithEvents rbtDebito As RadioButton
    Friend WithEvents dgvTemp As DataGridView
    Friend WithEvents lblTotal As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents rbtEfectivo As RadioButton
    Friend WithEvents rbtTransf As RadioButton
    Friend WithEvents btnCerrar As Button
    Friend WithEvents btnConsulta As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label6 As Label
End Class
