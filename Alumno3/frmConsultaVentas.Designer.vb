<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaVentas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaVentas))
        dgvConsulta = New DataGridView()
        btnCerrar = New Button()
        btnNuevo = New Button()
        btnCliente = New Button()
        btnFecha = New Button()
        dtpFecha1 = New DateTimePicker()
        dtpFecha2 = New DateTimePicker()
        cboCliente = New ComboBox()
        Label1 = New Label()
        Label2 = New Label()
        GroupBox2 = New GroupBox()
        GroupBox3 = New GroupBox()
        btnExportar = New Button()
        rbtExel = New RadioButton()
        rbtPDF = New RadioButton()
        Panel2 = New Panel()
        Panel3 = New Panel()
        Label6 = New Label()
        Panel1 = New Panel()
        CType(dgvConsulta, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox2.SuspendLayout()
        GroupBox3.SuspendLayout()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' dgvConsulta
        ' 
        dgvConsulta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvConsulta.Location = New Point(12, 198)
        dgvConsulta.Name = "dgvConsulta"
        dgvConsulta.Size = New Size(600, 249)
        dgvConsulta.TabIndex = 0
        ' 
        ' btnCerrar
        ' 
        btnCerrar.BackColor = SystemColors.ButtonHighlight
        btnCerrar.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold)
        btnCerrar.Location = New Point(489, 15)
        btnCerrar.Name = "btnCerrar"
        btnCerrar.Size = New Size(120, 41)
        btnCerrar.TabIndex = 10
        btnCerrar.Text = "Cerrar"
        btnCerrar.UseVisualStyleBackColor = False
        ' 
        ' btnNuevo
        ' 
        btnNuevo.BackColor = SystemColors.ButtonHighlight
        btnNuevo.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold)
        btnNuevo.Location = New Point(314, 15)
        btnNuevo.Name = "btnNuevo"
        btnNuevo.Size = New Size(145, 41)
        btnNuevo.TabIndex = 9
        btnNuevo.Text = "Nueva Consulta"
        btnNuevo.UseVisualStyleBackColor = False
        ' 
        ' btnCliente
        ' 
        btnCliente.BackColor = SystemColors.ButtonHighlight
        btnCliente.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold)
        btnCliente.Location = New Point(163, 15)
        btnCliente.Name = "btnCliente"
        btnCliente.Size = New Size(145, 41)
        btnCliente.TabIndex = 2
        btnCliente.Text = "Cliente"
        btnCliente.UseVisualStyleBackColor = False
        ' 
        ' btnFecha
        ' 
        btnFecha.BackColor = SystemColors.ButtonHighlight
        btnFecha.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold)
        btnFecha.Location = New Point(12, 15)
        btnFecha.Name = "btnFecha"
        btnFecha.Size = New Size(145, 41)
        btnFecha.TabIndex = 1
        btnFecha.Text = "Fechas"
        btnFecha.UseVisualStyleBackColor = False
        ' 
        ' dtpFecha1
        ' 
        dtpFecha1.Enabled = False
        dtpFecha1.Format = DateTimePickerFormat.Short
        dtpFecha1.Location = New Point(14, 53)
        dtpFecha1.Name = "dtpFecha1"
        dtpFecha1.Size = New Size(117, 25)
        dtpFecha1.TabIndex = 3
        dtpFecha1.Value = New Date(2026, 11, 10, 21, 23, 46, 0)
        ' 
        ' dtpFecha2
        ' 
        dtpFecha2.Enabled = False
        dtpFecha2.Format = DateTimePickerFormat.Short
        dtpFecha2.Location = New Point(14, 97)
        dtpFecha2.Name = "dtpFecha2"
        dtpFecha2.Size = New Size(117, 25)
        dtpFecha2.TabIndex = 4
        ' 
        ' cboCliente
        ' 
        cboCliente.Enabled = False
        cboCliente.FormattingEnabled = True
        cboCliente.Location = New Point(166, 53)
        cboCliente.Name = "cboCliente"
        cboCliente.Size = New Size(199, 25)
        cboCliente.TabIndex = 5
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Semibold", 11F, FontStyle.Bold)
        Label1.Location = New Point(45, 15)
        Label1.Name = "Label1"
        Label1.Size = New Size(55, 20)
        Label1.TabIndex = 8
        Label1.Text = "Fechas"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI Semibold", 11F, FontStyle.Bold)
        Label2.Location = New Point(237, 15)
        Label2.Name = "Label2"
        Label2.Size = New Size(56, 20)
        Label2.TabIndex = 9
        Label2.Text = "Cliente"
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(dtpFecha1)
        GroupBox2.Controls.Add(Label2)
        GroupBox2.Controls.Add(dtpFecha2)
        GroupBox2.Controls.Add(Label1)
        GroupBox2.Controls.Add(cboCliente)
        GroupBox2.Location = New Point(12, 63)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(371, 128)
        GroupBox2.TabIndex = 12
        GroupBox2.TabStop = False
        ' 
        ' GroupBox3
        ' 
        GroupBox3.Controls.Add(btnExportar)
        GroupBox3.Controls.Add(rbtExel)
        GroupBox3.Controls.Add(rbtPDF)
        GroupBox3.Location = New Point(389, 70)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New Size(223, 121)
        GroupBox3.TabIndex = 13
        GroupBox3.TabStop = False
        GroupBox3.Text = "Exportar"
        ' 
        ' btnExportar
        ' 
        btnExportar.BackColor = SystemColors.ButtonHighlight
        btnExportar.Enabled = False
        btnExportar.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold)
        btnExportar.Location = New Point(84, 46)
        btnExportar.Name = "btnExportar"
        btnExportar.Size = New Size(120, 41)
        btnExportar.TabIndex = 8
        btnExportar.Text = "Exportar ..."
        btnExportar.UseVisualStyleBackColor = False
        ' 
        ' rbtExel
        ' 
        rbtExel.AutoSize = True
        rbtExel.Font = New Font("Segoe UI", 10F)
        rbtExel.Location = New Point(17, 67)
        rbtExel.Name = "rbtExel"
        rbtExel.Size = New Size(50, 23)
        rbtExel.TabIndex = 7
        rbtExel.TabStop = True
        rbtExel.Text = "Exel"
        rbtExel.UseVisualStyleBackColor = True
        ' 
        ' rbtPDF
        ' 
        rbtPDF.AutoSize = True
        rbtPDF.Font = New Font("Segoe UI", 10F)
        rbtPDF.Location = New Point(17, 28)
        rbtPDF.Name = "rbtPDF"
        rbtPDF.Size = New Size(52, 23)
        rbtPDF.TabIndex = 6
        rbtPDF.TabStop = True
        rbtPDF.Text = "PDF"
        rbtPDF.UseVisualStyleBackColor = True
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = SystemColors.Highlight
        Panel2.Controls.Add(Panel3)
        Panel2.Dock = DockStyle.Top
        Panel2.ForeColor = SystemColors.MenuHighlight
        Panel2.Location = New Point(0, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(624, 67)
        Panel2.TabIndex = 21
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = SystemColors.ActiveCaptionText
        Panel3.Controls.Add(Label6)
        Panel3.Dock = DockStyle.Top
        Panel3.Location = New Point(0, 0)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(624, 63)
        Panel3.TabIndex = 0
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = SystemColors.HighlightText
        Label6.Location = New Point(12, 10)
        Label6.Name = "Label6"
        Label6.Size = New Size(173, 30)
        Label6.TabIndex = 21
        Label6.Text = "Consultar Ventas"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.ButtonHighlight
        Panel1.Controls.Add(btnFecha)
        Panel1.Controls.Add(btnCerrar)
        Panel1.Controls.Add(btnCliente)
        Panel1.Controls.Add(btnNuevo)
        Panel1.Dock = DockStyle.Bottom
        Panel1.Location = New Point(0, 453)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(624, 69)
        Panel1.TabIndex = 22
        ' 
        ' frmConsultaVentas
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = btnCerrar
        ClientSize = New Size(624, 522)
        Controls.Add(Panel1)
        Controls.Add(Panel2)
        Controls.Add(GroupBox3)
        Controls.Add(dgvConsulta)
        Controls.Add(GroupBox2)
        Font = New Font("Segoe UI", 10F)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        Name = "frmConsultaVentas"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Consultar Ventas"
        CType(dgvConsulta, ComponentModel.ISupportInitialize).EndInit()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        GroupBox3.ResumeLayout(False)
        GroupBox3.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        Panel1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents dgvConsulta As DataGridView
    Friend WithEvents btnCerrar As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents btnCliente As Button
    Friend WithEvents btnFecha As Button
    Friend WithEvents dtpFecha1 As DateTimePicker
    Friend WithEvents dtpFecha2 As DateTimePicker
    Friend WithEvents cboCliente As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnExportar As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents rbtExel As RadioButton
    Friend WithEvents rbtPDF As RadioButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel1 As Panel
End Class
