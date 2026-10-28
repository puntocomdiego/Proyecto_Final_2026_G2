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
        btnexportar = New Button()
        CheckBox1 = New CheckBox()
        CheckBox2 = New CheckBox()
        CType(dgvProductos, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtCodigo
        ' 
        txtCodigo.Font = New Font("Segoe UI", 12F)
        txtCodigo.Location = New Point(131, 62)
        txtCodigo.Name = "txtCodigo"
        txtCodigo.Size = New Size(205, 29)
        txtCodigo.TabIndex = 0
        ' 
        ' txtDescripcion
        ' 
        txtDescripcion.Font = New Font("Segoe UI", 12F)
        txtDescripcion.Location = New Point(131, 97)
        txtDescripcion.Name = "txtDescripcion"
        txtDescripcion.Size = New Size(205, 29)
        txtDescripcion.TabIndex = 1
        ' 
        ' txtPrecio
        ' 
        txtPrecio.Font = New Font("Segoe UI", 12F)
        txtPrecio.Location = New Point(131, 132)
        txtPrecio.Name = "txtPrecio"
        txtPrecio.Size = New Size(205, 29)
        txtPrecio.TabIndex = 2
        ' 
        ' txtStock
        ' 
        txtStock.Font = New Font("Segoe UI", 12F)
        txtStock.Location = New Point(131, 167)
        txtStock.Name = "txtStock"
        txtStock.Size = New Size(205, 29)
        txtStock.TabIndex = 3
        ' 
        ' cmbCategorias
        ' 
        cmbCategorias.Font = New Font("Segoe UI", 12F)
        cmbCategorias.FormattingEnabled = True
        cmbCategorias.Location = New Point(131, 25)
        cmbCategorias.Name = "cmbCategorias"
        cmbCategorias.Size = New Size(205, 29)
        cmbCategorias.TabIndex = 4
        ' 
        ' txtStockminimo
        ' 
        txtStockminimo.Font = New Font("Segoe UI", 12F)
        txtStockminimo.Location = New Point(131, 202)
        txtStockminimo.Name = "txtStockminimo"
        txtStockminimo.Size = New Size(205, 29)
        txtStockminimo.TabIndex = 5
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.Location = New Point(12, 65)
        Label1.Name = "Label1"
        Label1.Size = New Size(63, 21)
        Label1.TabIndex = 6
        Label1.Text = "Código:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F)
        Label2.Location = New Point(11, 100)
        Label2.Name = "Label2"
        Label2.Size = New Size(94, 21)
        Label2.TabIndex = 7
        Label2.Text = "Descripción:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F)
        Label3.Location = New Point(12, 135)
        Label3.Name = "Label3"
        Label3.Size = New Size(56, 21)
        Label3.TabIndex = 8
        Label3.Text = "Precio:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 12F)
        Label4.Location = New Point(12, 170)
        Label4.Name = "Label4"
        Label4.Size = New Size(50, 21)
        Label4.TabIndex = 9
        Label4.Text = "Stock:"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 12F)
        Label5.Location = New Point(11, 205)
        Label5.Name = "Label5"
        Label5.Size = New Size(108, 21)
        Label5.TabIndex = 10
        Label5.Text = "Stock Mínimo:"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 12F)
        Label6.Location = New Point(12, 28)
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
        btnAgregar.Location = New Point(483, 61)
        btnAgregar.Name = "btnAgregar"
        btnAgregar.Size = New Size(125, 39)
        btnAgregar.TabIndex = 13
        btnAgregar.Text = "Agregar"
        btnAgregar.UseVisualStyleBackColor = True
        ' 
        ' btnModificar
        ' 
        btnModificar.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnModificar.Enabled = False
        btnModificar.Font = New Font("Berlin Sans FB Demi", 12F)
        btnModificar.Location = New Point(352, 106)
        btnModificar.Name = "btnModificar"
        btnModificar.Size = New Size(125, 39)
        btnModificar.TabIndex = 14
        btnModificar.Text = "Modificar"
        btnModificar.UseVisualStyleBackColor = True
        ' 
        ' btnEliminar
        ' 
        btnEliminar.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnEliminar.Enabled = False
        btnEliminar.Font = New Font("Berlin Sans FB Demi", 12F)
        btnEliminar.Location = New Point(483, 106)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(125, 39)
        btnEliminar.TabIndex = 15
        btnEliminar.Text = "Eliminar"
        btnEliminar.UseVisualStyleBackColor = True
        ' 
        ' btnLimpiar
        ' 
        btnLimpiar.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnLimpiar.Font = New Font("Berlin Sans FB Demi", 12F)
        btnLimpiar.Location = New Point(352, 61)
        btnLimpiar.Name = "btnLimpiar"
        btnLimpiar.Size = New Size(125, 39)
        btnLimpiar.TabIndex = 16
        btnLimpiar.Text = "Limpiar"
        btnLimpiar.UseVisualStyleBackColor = True
        ' 
        ' dgvProductos
        ' 
        dgvProductos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvProductos.Location = New Point(11, 254)
        dgvProductos.Name = "dgvProductos"
        dgvProductos.Size = New Size(596, 216)
        dgvProductos.TabIndex = 18
        ' 
        ' btnBuscar
        ' 
        btnBuscar.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnBuscar.Font = New Font("Berlin Sans FB Demi", 12F)
        btnBuscar.Location = New Point(352, 16)
        btnBuscar.Name = "btnBuscar"
        btnBuscar.Size = New Size(125, 39)
        btnBuscar.TabIndex = 19
        btnBuscar.Text = "Buscar"
        btnBuscar.UseVisualStyleBackColor = True
        ' 
        ' txtBuscar
        ' 
        txtBuscar.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        txtBuscar.Font = New Font("Segoe UI", 12F)
        txtBuscar.Location = New Point(403, 174)
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
        btnok.Location = New Point(357, 174)
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
        btnNuevo.Location = New Point(483, 16)
        btnNuevo.Name = "btnNuevo"
        btnNuevo.Size = New Size(125, 39)
        btnNuevo.TabIndex = 22
        btnNuevo.Text = "Nuevo"
        btnNuevo.UseVisualStyleBackColor = True
        ' 
        ' btnFin
        ' 
        btnFin.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnFin.Font = New Font("Berlin Sans FB Demi", 12F)
        btnFin.Location = New Point(482, 476)
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
        chkActivo.Location = New Point(373, 147)
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
        btnexportar.Font = New Font("Berlin Sans FB Demi", 12F)
        btnexportar.Location = New Point(482, 209)
        btnexportar.Name = "btnexportar"
        btnexportar.Size = New Size(125, 39)
        btnexportar.TabIndex = 25
        btnexportar.Text = "Exportar"
        btnexportar.UseVisualStyleBackColor = True
        ' 
        ' CheckBox1
        ' 
        CheckBox1.AutoSize = True
        CheckBox1.Font = New Font("Berlin Sans FB Demi", 12F)
        CheckBox1.Location = New Point(352, 218)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(57, 22)
        CheckBox1.TabIndex = 26
        CheckBox1.Text = "PDF"
        CheckBox1.UseVisualStyleBackColor = True
        CheckBox1.Visible = False
        ' 
        ' CheckBox2
        ' 
        CheckBox2.AutoSize = True
        CheckBox2.Font = New Font("Berlin Sans FB Demi", 12F)
        CheckBox2.Location = New Point(415, 218)
        CheckBox2.Name = "CheckBox2"
        CheckBox2.Size = New Size(62, 22)
        CheckBox2.TabIndex = 27
        CheckBox2.Text = "XSLX"
        CheckBox2.UseVisualStyleBackColor = True
        CheckBox2.Visible = False
        ' 
        ' frmProductos
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(629, 518)
        Controls.Add(CheckBox2)
        Controls.Add(CheckBox1)
        Controls.Add(txtBuscar)
        Controls.Add(btnexportar)
        Controls.Add(chkActivo)
        Controls.Add(btnFin)
        Controls.Add(btnNuevo)
        Controls.Add(btnok)
        Controls.Add(btnBuscar)
        Controls.Add(Label6)
        Controls.Add(dgvProductos)
        Controls.Add(txtCodigo)
        Controls.Add(btnLimpiar)
        Controls.Add(Label5)
        Controls.Add(btnEliminar)
        Controls.Add(txtDescripcion)
        Controls.Add(Label4)
        Controls.Add(btnModificar)
        Controls.Add(txtPrecio)
        Controls.Add(btnAgregar)
        Controls.Add(Label3)
        Controls.Add(txtStock)
        Controls.Add(txtStockminimo)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(cmbCategorias)
        Name = "frmProductos"
        Text = "frmProductos"
        CType(dgvProductos, ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents btnexportar As Button
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
End Class
