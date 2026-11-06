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
        dgvConsulta = New DataGridView()
        btnCerrar = New Button()
        Button2 = New Button()
        Button3 = New Button()
        btnConsultar = New Button()
        dtpFecha1 = New DateTimePicker()
        dtpFecha2 = New DateTimePicker()
        cboCliente = New ComboBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        CType(dgvConsulta, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' dgvConsulta
        ' 
        dgvConsulta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvConsulta.Location = New Point(12, 186)
        dgvConsulta.Name = "dgvConsulta"
        dgvConsulta.Size = New Size(531, 252)
        dgvConsulta.TabIndex = 0
        ' 
        ' btnCerrar
        ' 
        btnCerrar.Location = New Point(640, 287)
        btnCerrar.Name = "btnCerrar"
        btnCerrar.Size = New Size(75, 23)
        btnCerrar.TabIndex = 1
        btnCerrar.Text = "Cerrar"
        btnCerrar.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(640, 160)
        Button2.Name = "Button2"
        Button2.Size = New Size(75, 23)
        Button2.TabIndex = 2
        Button2.Text = "Button2"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(640, 117)
        Button3.Name = "Button3"
        Button3.Size = New Size(75, 23)
        Button3.TabIndex = 3
        Button3.Text = "Button3"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' btnConsultar
        ' 
        btnConsultar.Location = New Point(640, 72)
        btnConsultar.Name = "btnConsultar"
        btnConsultar.Size = New Size(75, 23)
        btnConsultar.TabIndex = 4
        btnConsultar.Text = "Button4"
        btnConsultar.UseVisualStyleBackColor = True
        ' 
        ' dtpFecha1
        ' 
        dtpFecha1.Format = DateTimePickerFormat.Short
        dtpFecha1.Location = New Point(30, 106)
        dtpFecha1.Name = "dtpFecha1"
        dtpFecha1.Size = New Size(117, 23)
        dtpFecha1.TabIndex = 5
        ' 
        ' dtpFecha2
        ' 
        dtpFecha2.Format = DateTimePickerFormat.Short
        dtpFecha2.Location = New Point(30, 145)
        dtpFecha2.Name = "dtpFecha2"
        dtpFecha2.Size = New Size(117, 23)
        dtpFecha2.TabIndex = 6
        ' 
        ' cboCliente
        ' 
        cboCliente.FormattingEnabled = True
        cboCliente.Location = New Point(202, 106)
        cboCliente.Name = "cboCliente"
        cboCliente.Size = New Size(154, 23)
        cboCliente.TabIndex = 7
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(55, 72)
        Label1.Name = "Label1"
        Label1.Size = New Size(67, 15)
        Label1.TabIndex = 8
        Label1.Text = "Por Fechas:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(247, 72)
        Label2.Name = "Label2"
        Label2.Size = New Size(65, 15)
        Label2.TabIndex = 9
        Label2.Text = "Por Cliente"
        ' 
        ' Label3
        ' 
        Label3.Location = New Point(30, 19)
        Label3.Name = "Label3"
        Label3.Size = New Size(326, 28)
        Label3.TabIndex = 10
        Label3.Text = "Consultar Ventas"
        Label3.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' frmConsultaVentas
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(cboCliente)
        Controls.Add(dtpFecha2)
        Controls.Add(dtpFecha1)
        Controls.Add(btnConsultar)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(btnCerrar)
        Controls.Add(dgvConsulta)
        Name = "frmConsultaVentas"
        Text = "frmConsultaVentas"
        CType(dgvConsulta, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents dgvConsulta As DataGridView
    Friend WithEvents btnCerrar As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents btnConsultar As Button
    Friend WithEvents dtpFecha1 As DateTimePicker
    Friend WithEvents dtpFecha2 As DateTimePicker
    Friend WithEvents cboCliente As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
