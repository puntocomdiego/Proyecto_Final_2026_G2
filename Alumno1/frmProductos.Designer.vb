<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductos
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
        txtCodigo = New TextBox()
        txtDescripcion = New TextBox()
        txtPrecio = New TextBox()
        txtStock = New TextBox()
        cmbCategorias = New ComboBox()
        txtStockminimo = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        btnAgregar = New Button()
        btnModificar = New Button()
        btnEliminar = New Button()
        btnLimpiar = New Button()
        dgvProductos = New DataGridView()
        btnBuscar = New Button()
        txtBuscar = New TextBox()
        btnok = New Button()
        btnNuevo = New Button()
        btnFin = New Button()
        chkActivo = New CheckBox()
        FolderBrowserDialog1 = New FolderBrowserDialog()
        btnexportar = New Button()
        rdpdf = New RadioButton()
        rdexcel = New RadioButton()
        GroupBox1 = New GroupBox()
        CType(dgvProductos, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' txtCodigo
        ' 
        txtCodigo.Font = New Font("Segoe UI", 12F)
        txtCodigo.Location = New Point(151, 65)
        txtCodigo.Name = "txtCodigo"
        txtCodigo.Size = New Size(205, 29)
        txtCodigo.TabIndex = 0
        ' 
        ' txtDescripcion
        ' 
        txtDescripcion.Font = New Font("Segoe UI", 12F)
        txtDescripcion.Location = New Point(151, 100)
        txtDescripcion.Name = "txtDescripcion"
        txtDescripcion.Size = New Size(205, 29)
        txtDescripcion.TabIndex = 1
        ' 
        ' txtPrecio
        ' 
        txtPrecio.Font = New Font("Segoe UI", 12F)
        txtPrecio.Location = New Point(524, 28)
        txtPrecio.Name = "txtPrecio"
        txtPrecio.Size = New Size(205, 29)
        txtPrecio.TabIndex = 2
        ' 
        ' txtStock
        ' 
        txtStock.Font = New Font("Segoe UI", 12F)
        txtStock.Location = New Point(524, 63)
        txtStock.Name = "txtStock"
        txtStock.Size = New Size(205, 29)
        txtStock.TabIndex = 3
        ' 
        ' cmbCategorias
        ' 
        cmbCategorias.Font = New Font("Segoe UI", 12F)
        cmbCategorias.FormattingEnabled = True
        cmbCategorias.Location = New Point(151, 28)
        cmbCategorias.Name = "cmbCategorias"
        cmbCategorias.Size = New Size(205, 29)
        cmbCategorias.TabIndex = 4
        ' 
        ' txtStockminimo
        ' 
        txtStockminimo.Font = New Font("Segoe UI", 12F)
        txtStockminimo.Location = New Point(524, 98)
        txtStockminimo.Name = "txtStockminimo"
        txtStockminimo.Size = New Size(205, 29)
        txtStockminimo.TabIndex = 5
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.Location = New Point(32, 68)
        Label1.Name = "Label1"
        Label1.Size = New Size(63, 21)
        Label1.TabIndex = 6
        Label1.Text = "Código:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F)
        Label2.Location = New Point(31, 103)
        Label2.Name = "Label2"
        Label2.Size = New Size(94, 21)
        Label2.TabIndex = 7
        Label2.Text = "Descripción:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F)
        Label3.Location = New Point(405, 31)
        Label3.Name = "Label3"
        Label3.Size = New Size(56, 21)
        Label3.TabIndex = 8
        Label3.Text = "Precio:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 12F)
        Label4.Location = New Point(405, 66)
        Label4.Name = "Label4"
        Label4.Size = New Size(50, 21)
        Label4.TabIndex = 9
        Label4.Text = "Stock:"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 12F)
        Label5.Location = New Point(404, 101)
        Label5.Name = "Label5"
        Label5.Size = New Size(108, 21)
        Label5.TabIndex = 10
        Label5.Text = "Stock Mínimo:"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 12F)
        Label6.Location = New Point(32, 31)
        Label6.Name = "Label6"
        Label6.Size = New Size(80, 21)
        Label6.TabIndex = 11
        Label6.Text = "Categoria:"
        ' 
        ' btnAgregar
        ' 
        btnAgregar.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnAgregar.Enabled = False
        btnAgregar.Font = New Font("Berlin Sans FB Demi", 12F)
        btnAgregar.Location = New Point(263, 424)
        btnAgregar.Name = "btnAgregar"
        btnAgregar.Size = New Size(120, 36)
        btnAgregar.TabIndex = 13
        btnAgregar.Text = "Agregar"
        btnAgregar.UseVisualStyleBackColor = True
        ' 
        ' btnModificar
        ' 
        btnModificar.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnModificar.Enabled = False
        btnModificar.Font = New Font("Berlin Sans FB Demi", 12F)
        btnModificar.Location = New Point(389, 424)
        btnModificar.Name = "btnModificar"
        btnModificar.Size = New Size(120, 36)
        btnModificar.TabIndex = 14
        btnModificar.Text = "Modificar"
        btnModificar.UseVisualStyleBackColor = True
        ' 
        ' btnEliminar
        ' 
        btnEliminar.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnEliminar.Enabled = False
        btnEliminar.Font = New Font("Berlin Sans FB Demi", 12F)
        btnEliminar.Location = New Point(641, 424)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(120, 36)
        btnEliminar.TabIndex = 15
        btnEliminar.Text = "Eliminar"
        btnEliminar.UseVisualStyleBackColor = True
        ' 
        ' btnLimpiar
        ' 
        btnLimpiar.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnLimpiar.Font = New Font("Berlin Sans FB Demi", 12F)
        btnLimpiar.Location = New Point(515, 424)
        btnLimpiar.Name = "btnLimpiar"
        btnLimpiar.Size = New Size(120, 36)
        btnLimpiar.TabIndex = 16
        btnLimpiar.Text = "Limpiar"
        btnLimpiar.UseVisualStyleBackColor = True
        ' 
        ' dgvProductos
        ' 
        dgvProductos.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvProductos.Location = New Point(11, 147)
        dgvProductos.Name = "dgvProductos"
        dgvProductos.Size = New Size(761, 259)
        dgvProductos.TabIndex = 18
        ' 
        ' btnBuscar
        ' 
        btnBuscar.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnBuscar.Font = New Font("Berlin Sans FB Demi", 12F)
        btnBuscar.Location = New Point(11, 424)
        btnBuscar.Name = "btnBuscar"
        btnBuscar.Size = New Size(120, 36)
        btnBuscar.TabIndex = 19
        btnBuscar.Text = "Buscar"
        btnBuscar.UseVisualStyleBackColor = True
        ' 
        ' txtBuscar
        ' 
        txtBuscar.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        txtBuscar.Font = New Font("Segoe UI", 12F)
        txtBuscar.Location = New Point(58, 466)
        txtBuscar.Name = "txtBuscar"
        txtBuscar.Size = New Size(205, 29)
        txtBuscar.TabIndex = 20
        txtBuscar.Visible = False
        ' 
        ' btnok
        ' 
        btnok.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnok.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        btnok.Font = New Font("Berlin Sans FB Demi", 12F)
        btnok.Location = New Point(12, 466)
        btnok.Name = "btnok"
        btnok.Size = New Size(40, 29)
        btnok.TabIndex = 21
        btnok.Text = "OK"
        btnok.UseVisualStyleBackColor = False
        btnok.Visible = False
        ' 
        ' btnNuevo
        ' 
        btnNuevo.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnNuevo.Font = New Font("Berlin Sans FB Demi", 12F)
        btnNuevo.Location = New Point(137, 424)
        btnNuevo.Name = "btnNuevo"
        btnNuevo.Size = New Size(120, 36)
        btnNuevo.TabIndex = 22
        btnNuevo.Text = "Nuevo"
        btnNuevo.UseVisualStyleBackColor = True
        ' 
        ' btnFin
        ' 
        btnFin.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnFin.Font = New Font("Berlin Sans FB Demi", 12F)
        btnFin.Location = New Point(647, 510)
        btnFin.Name = "btnFin"
        btnFin.Size = New Size(125, 39)
        btnFin.TabIndex = 23
        btnFin.Text = "Fin"
        btnFin.UseVisualStyleBackColor = True
        ' 
        ' chkActivo
        ' 
        chkActivo.AutoSize = True
        chkActivo.Font = New Font("Berlin Sans FB Demi", 12F)
        chkActivo.Location = New Point(411, 466)
        chkActivo.Name = "chkActivo"
        chkActivo.Size = New Size(73, 22)
        chkActivo.TabIndex = 24
        chkActivo.Text = "Activo"
        chkActivo.UseVisualStyleBackColor = True
        chkActivo.Visible = False
        ' 
        ' btnexportar
        ' 
        btnexportar.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnexportar.Enabled = False
        btnexportar.Font = New Font("Berlin Sans FB Demi", 12F)
        btnexportar.Location = New Point(12, 501)
        btnexportar.Name = "btnexportar"
        btnexportar.Size = New Size(120, 36)
        btnexportar.TabIndex = 25
        btnexportar.Text = "Exportar"
        btnexportar.UseVisualStyleBackColor = True
        ' 
        ' rdpdf
        ' 
        rdpdf.AutoSize = True
        rdpdf.Font = New Font("Berlin Sans FB Demi", 12F)
        rdpdf.Location = New Point(138, 508)
        rdpdf.Name = "rdpdf"
        rdpdf.Size = New Size(56, 22)
        rdpdf.TabIndex = 28
        rdpdf.TabStop = True
        rdpdf.Text = "PDF"
        rdpdf.UseVisualStyleBackColor = True
        ' 
        ' rdexcel
        ' 
        rdexcel.AutoSize = True
        rdexcel.Font = New Font("Berlin Sans FB Demi", 12F)
        rdexcel.Location = New Point(200, 508)
        rdexcel.Name = "rdexcel"
        rdexcel.Size = New Size(61, 22)
        rdexcel.TabIndex = 29
        rdexcel.TabStop = True
        rdexcel.Text = "XLSX"
        rdexcel.UseVisualStyleBackColor = True
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(cmbCategorias)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(txtStockminimo)
        GroupBox1.Controls.Add(txtStock)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(txtPrecio)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(txtDescripcion)
        GroupBox1.Controls.Add(Label5)
        GroupBox1.Controls.Add(Label6)
        GroupBox1.Controls.Add(txtCodigo)
        GroupBox1.Font = New Font("Segoe UI", 12F)
        GroupBox1.Location = New Point(11, 0)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(761, 144)
        GroupBox1.TabIndex = 30
        GroupBox1.TabStop = False
        GroupBox1.Text = "Datos del Producto:"
        ' 
        ' frmProductos
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(784, 561)
        Controls.Add(rdexcel)
        Controls.Add(rdpdf)
        Controls.Add(txtBuscar)
        Controls.Add(btnexportar)
        Controls.Add(chkActivo)
        Controls.Add(btnFin)
        Controls.Add(btnNuevo)
        Controls.Add(btnok)
        Controls.Add(btnBuscar)
        Controls.Add(dgvProductos)
        Controls.Add(btnLimpiar)
        Controls.Add(btnEliminar)
        Controls.Add(btnModificar)
        Controls.Add(btnAgregar)
        Controls.Add(GroupBox1)
        Name = "frmProductos"
        Text = "frmProductos"
        CType(dgvProductos, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtCodigo As TextBox
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents txtPrecio As TextBox
    Friend WithEvents txtStock As TextBox
    Friend WithEvents cmbCategorias As ComboBox
    Friend WithEvents txtStockminimo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents btnAgregar As Button
    Friend WithEvents btnModificar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents dgvProductos As DataGridView
    Friend WithEvents btnBuscar As Button
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents btnok As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents btnFin As Button
    Friend WithEvents chkActivo As CheckBox
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents btnexportar As Button
    Friend WithEvents rdpdf As RadioButton
    Friend WithEvents rdexcel As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
End Class
