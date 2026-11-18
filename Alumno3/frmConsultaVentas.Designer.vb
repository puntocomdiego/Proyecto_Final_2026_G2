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
        btnConsultar = New Button()
        dtpFecha1 = New DateTimePicker()
        dtpFecha2 = New DateTimePicker()
        cboCliente = New ComboBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        GroupBox1 = New GroupBox()
        GroupBox2 = New GroupBox()
        GroupBox3 = New GroupBox()
        btnExportar = New Button()
        rbtExel = New RadioButton()
        rbtPDF = New RadioButton()
        CType(dgvConsulta, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        GroupBox2.SuspendLayout()
        GroupBox3.SuspendLayout()
        SuspendLayout()
        ' 
        ' dgvConsulta
        ' 
        dgvConsulta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvConsulta.Location = New Point(12, 175)
        dgvConsulta.Name = "dgvConsulta"
        dgvConsulta.Size = New Size(600, 173)
        dgvConsulta.TabIndex = 0
        ' 
        ' btnCerrar
        ' 
        btnCerrar.Location = New Point(518, 22)
        btnCerrar.Name = "btnCerrar"
        btnCerrar.Size = New Size(75, 23)
        btnCerrar.TabIndex = 1
        btnCerrar.Text = "Cerrar"
        btnCerrar.UseVisualStyleBackColor = True
        ' 
        ' btnNuevo
        ' 
        btnNuevo.Location = New Point(284, 22)
        btnNuevo.Name = "btnNuevo"
        btnNuevo.Size = New Size(113, 23)
        btnNuevo.TabIndex = 2
        btnNuevo.Text = "Nueva Consulta"
        btnNuevo.UseVisualStyleBackColor = True
        ' 
        ' btnCliente
        ' 
        btnCliente.Location = New Point(146, 22)
        btnCliente.Name = "btnCliente"
        btnCliente.Size = New Size(113, 23)
        btnCliente.TabIndex = 3
        btnCliente.Text = "Consultar Cliente"
        btnCliente.UseVisualStyleBackColor = True
        ' 
        ' btnConsultar
        ' 
        btnConsultar.Location = New Point(8, 22)
        btnConsultar.Name = "btnConsultar"
        btnConsultar.Size = New Size(113, 23)
        btnConsultar.TabIndex = 4
        btnConsultar.Text = "Consultar Fecha"
        btnConsultar.UseVisualStyleBackColor = True
        ' 
        ' dtpFecha1
        ' 
        dtpFecha1.Format = DateTimePickerFormat.Short
        dtpFecha1.Location = New Point(23, 80)
        dtpFecha1.Name = "dtpFecha1"
        dtpFecha1.Size = New Size(117, 23)
        dtpFecha1.TabIndex = 5
        dtpFecha1.Value = New Date(2026, 11, 10, 21, 23, 46, 0)
        ' 
        ' dtpFecha2
        ' 
        dtpFecha2.Format = DateTimePickerFormat.Short
        dtpFecha2.Location = New Point(23, 119)
        dtpFecha2.Name = "dtpFecha2"
        dtpFecha2.Size = New Size(117, 23)
        dtpFecha2.TabIndex = 6
        ' 
        ' cboCliente
        ' 
        cboCliente.FormattingEnabled = True
        cboCliente.Location = New Point(204, 80)
        cboCliente.Name = "cboCliente"
        cboCliente.Size = New Size(154, 23)
        cboCliente.TabIndex = 7
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(48, 46)
        Label1.Name = "Label1"
        Label1.Size = New Size(67, 15)
        Label1.TabIndex = 8
        Label1.Text = "Por Fechas:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(249, 46)
        Label2.Name = "Label2"
        Label2.Size = New Size(65, 15)
        Label2.TabIndex = 9
        Label2.Text = "Por Cliente"
        ' 
        ' Label3
        ' 
        Label3.BackColor = Color.Transparent
        Label3.Location = New Point(6, 9)
        Label3.Name = "Label3"
        Label3.Size = New Size(359, 28)
        Label3.TabIndex = 10
        Label3.Text = "Consultar Ventas"
        Label3.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(btnConsultar)
        GroupBox1.Controls.Add(btnCerrar)
        GroupBox1.Controls.Add(btnNuevo)
        GroupBox1.Controls.Add(btnCliente)
        GroupBox1.Location = New Point(15, 354)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(597, 75)
        GroupBox1.TabIndex = 11
        GroupBox1.TabStop = False
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(Label3)
        GroupBox2.Controls.Add(dtpFecha1)
        GroupBox2.Controls.Add(Label2)
        GroupBox2.Controls.Add(dtpFecha2)
        GroupBox2.Controls.Add(Label1)
        GroupBox2.Controls.Add(cboCliente)
        GroupBox2.Location = New Point(12, 12)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(371, 157)
        GroupBox2.TabIndex = 12
        GroupBox2.TabStop = False
        ' 
        ' GroupBox3
        ' 
        GroupBox3.Controls.Add(btnExportar)
        GroupBox3.Controls.Add(rbtExel)
        GroupBox3.Controls.Add(rbtPDF)
        GroupBox3.Location = New Point(389, 12)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New Size(223, 113)
        GroupBox3.TabIndex = 13
        GroupBox3.TabStop = False
        GroupBox3.Text = "Exportar"
        ' 
        ' btnExportar
        ' 
        btnExportar.Location = New Point(84, 51)
        btnExportar.Name = "btnExportar"
        btnExportar.Size = New Size(113, 23)
        btnExportar.TabIndex = 5
        btnExportar.Text = "Exportar ..."
        btnExportar.UseVisualStyleBackColor = True
        ' 
        ' rbtExel
        ' 
        rbtExel.AutoSize = True
        rbtExel.Location = New Point(17, 69)
        rbtExel.Name = "rbtExel"
        rbtExel.Size = New Size(46, 19)
        rbtExel.TabIndex = 1
        rbtExel.TabStop = True
        rbtExel.Text = "Exel"
        rbtExel.UseVisualStyleBackColor = True
        ' 
        ' rbtPDF
        ' 
        rbtPDF.AutoSize = True
        rbtPDF.Location = New Point(17, 35)
        rbtPDF.Name = "rbtPDF"
        rbtPDF.Size = New Size(46, 19)
        rbtPDF.TabIndex = 0
        rbtPDF.TabStop = True
        rbtPDF.Text = "PDF"
        rbtPDF.UseVisualStyleBackColor = True
        ' 
        ' frmConsultaVentas
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(624, 439)
        Controls.Add(GroupBox3)
        Controls.Add(GroupBox1)
        Controls.Add(dgvConsulta)
        Controls.Add(GroupBox2)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "frmConsultaVentas"
        Text = "frmConsultaVentas"
        CType(dgvConsulta, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        GroupBox3.ResumeLayout(False)
        GroupBox3.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents dgvConsulta As DataGridView
    Friend WithEvents btnCerrar As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents btnCliente As Button
    Friend WithEvents btnConsultar As Button
    Friend WithEvents dtpFecha1 As DateTimePicker
    Friend WithEvents dtpFecha2 As DateTimePicker
    Friend WithEvents cboCliente As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnExportar As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents rbtExel As RadioButton
    Friend WithEvents rbtPDF As RadioButton
End Class
