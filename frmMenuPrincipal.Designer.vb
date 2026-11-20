<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMenuPrincipal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMenuPrincipal))
        MenuStrip = New MenuStrip()
        FileMenu = New ToolStripMenuItem()
        ExitToolStripMenuItem = New ToolStripMenuItem()
        MenuToolStripMenuItem = New ToolStripMenuItem()
        ProductosToolStripMenuItem = New ToolStripMenuItem()
        ClientesToolStripMenuItem = New ToolStripMenuItem()
        VentasToolStripMenuItem = New ToolStripMenuItem()
        CategoriasToolStripMenuItem = New ToolStripMenuItem()
        ConsultaDeVentasToolStripMenuItem = New ToolStripMenuItem()
        RespaldarYRestaurarToolStripMenuItem = New ToolStripMenuItem()
        RestaurarToolStripMenuItem = New ToolStripMenuItem()
        StatusStrip = New StatusStrip()
        ToolStripStatusLabel = New ToolStripStatusLabel()
        ToolTip = New ToolTip(components)
        sfdRespaldo = New SaveFileDialog()
        MenuStrip.SuspendLayout()
        StatusStrip.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStrip
        ' 
        MenuStrip.ImageScalingSize = New Size(20, 20)
        MenuStrip.Items.AddRange(New ToolStripItem() {FileMenu, MenuToolStripMenuItem})
        MenuStrip.Location = New Point(0, 0)
        MenuStrip.Name = "MenuStrip"
        MenuStrip.Padding = New Padding(7, 2, 0, 2)
        MenuStrip.Size = New Size(871, 24)
        MenuStrip.TabIndex = 5
        MenuStrip.Text = "MenuStrip"
        ' 
        ' FileMenu
        ' 
        FileMenu.DropDownItems.AddRange(New ToolStripItem() {ExitToolStripMenuItem})
        FileMenu.ImageTransparentColor = SystemColors.ActiveBorder
        FileMenu.Name = "FileMenu"
        FileMenu.Size = New Size(60, 20)
        FileMenu.Text = "&Archivo"
        ' 
        ' ExitToolStripMenuItem
        ' 
        ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        ExitToolStripMenuItem.Size = New Size(96, 22)
        ExitToolStripMenuItem.Text = "S&alir"
        ' 
        ' MenuToolStripMenuItem
        ' 
        MenuToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ProductosToolStripMenuItem, ClientesToolStripMenuItem, VentasToolStripMenuItem, CategoriasToolStripMenuItem, ConsultaDeVentasToolStripMenuItem, RespaldarYRestaurarToolStripMenuItem, RestaurarToolStripMenuItem})
        MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        MenuToolStripMenuItem.Size = New Size(50, 20)
        MenuToolStripMenuItem.Text = "M&enu"
        ' 
        ' ProductosToolStripMenuItem
        ' 
        ProductosToolStripMenuItem.Name = "ProductosToolStripMenuItem"
        ProductosToolStripMenuItem.Size = New Size(180, 22)
        ProductosToolStripMenuItem.Text = "Productos"
        ' 
        ' ClientesToolStripMenuItem
        ' 
        ClientesToolStripMenuItem.Name = "ClientesToolStripMenuItem"
        ClientesToolStripMenuItem.Size = New Size(180, 22)
        ClientesToolStripMenuItem.Text = "Clientes"
        ' 
        ' VentasToolStripMenuItem
        ' 
        VentasToolStripMenuItem.Name = "VentasToolStripMenuItem"
        VentasToolStripMenuItem.Size = New Size(180, 22)
        VentasToolStripMenuItem.Text = "Ventas"
        ' 
        ' CategoriasToolStripMenuItem
        ' 
        CategoriasToolStripMenuItem.Name = "CategoriasToolStripMenuItem"
        CategoriasToolStripMenuItem.Size = New Size(180, 22)
        CategoriasToolStripMenuItem.Text = "Categorias"
        ' 
        ' ConsultaDeVentasToolStripMenuItem
        ' 
        ConsultaDeVentasToolStripMenuItem.Name = "ConsultaDeVentasToolStripMenuItem"
        ConsultaDeVentasToolStripMenuItem.Size = New Size(180, 22)
        ConsultaDeVentasToolStripMenuItem.Text = "Consulta de ventas"
        ' 
        ' RespaldarYRestaurarToolStripMenuItem
        ' 
        RespaldarYRestaurarToolStripMenuItem.Name = "RespaldarYRestaurarToolStripMenuItem"
        RespaldarYRestaurarToolStripMenuItem.Size = New Size(180, 22)
        RespaldarYRestaurarToolStripMenuItem.Text = "Respaldar"
        ' 
        ' RestaurarToolStripMenuItem
        ' 
        RestaurarToolStripMenuItem.Name = "RestaurarToolStripMenuItem"
        RestaurarToolStripMenuItem.Size = New Size(180, 22)
        RestaurarToolStripMenuItem.Text = "Restaurar"
        ' 
        ' StatusStrip
        ' 
        StatusStrip.ImageScalingSize = New Size(20, 20)
        StatusStrip.Items.AddRange(New ToolStripItem() {ToolStripStatusLabel})
        StatusStrip.Location = New Point(0, 501)
        StatusStrip.Name = "StatusStrip"
        StatusStrip.Padding = New Padding(1, 0, 17, 0)
        StatusStrip.Size = New Size(871, 22)
        StatusStrip.TabIndex = 7
        StatusStrip.Text = "StatusStrip"
        ' 
        ' ToolStripStatusLabel
        ' 
        ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        ToolStripStatusLabel.Size = New Size(39, 17)
        ToolStripStatusLabel.Text = "Status"
        ' 
        ' frmMenuPrincipal
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(871, 523)
        Controls.Add(MenuStrip)
        Controls.Add(StatusStrip)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        IsMdiContainer = True
        MainMenuStrip = MenuStrip
        Margin = New Padding(4)
        Name = "frmMenuPrincipal"
        Text = "Proyecto Integrador."
        WindowState = FormWindowState.Maximized
        MenuStrip.ResumeLayout(False)
        MenuStrip.PerformLayout()
        StatusStrip.ResumeLayout(False)
        StatusStrip.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProductosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClientesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VentasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CategoriasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConsultaDeVentasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RespaldarYRestaurarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RestaurarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents sfdRespaldo As SaveFileDialog

End Class
