Module Estilos
    ' --- Paleta de marca ---
    Public ReadOnly ColorNegro As Color = Color.FromArgb(8, 8, 14)
    Public ReadOnly ColorCeleste As Color = Color.FromArgb(0, 158, 255)
    Public ReadOnly ColorAmarillo As Color = Color.FromArgb(255, 208, 0)
    Public ReadOnly ColorGrisTexto As Color = Color.FromArgb(90, 90, 102)
    Public ReadOnly ColorFondo As Color = Color.FromArgb(244, 246, 248)
    Public ReadOnly ColorBorde As Color = Color.FromArgb(208, 213, 221)
    Public ReadOnly ColorPeligro As Color = Color.FromArgb(217, 45, 32)
    Public ReadOnly ColorExito As Color = Color.FromArgb(18, 183, 106)

    ' --- Tipografía ---
    Public ReadOnly FuenteBase As New Font("Segoe UI", 10.0F)
    Public ReadOnly FuenteBoton As New Font("Segoe UI Semibold", 10.0F)
    Public ReadOnly FuenteTitulo As New Font("Segoe UI Semibold", 16.0F)

    ' --- Tamaños de botón ---
    Public ReadOnly TamBoton As New Size(120, 36)
    Public ReadOnly TamBotonGrande As New Size(160, 44)

    Public Sub AplicarEstiloFormulario(frm As Form, titulo As String)
        frm.BackColor = ColorFondo
        frm.Font = FuenteBase
        frm.Text = "Puntocom · " & titulo
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.FormBorderStyle = FormBorderStyle.FixedSingle
        frm.MaximizeBox = False
    End Sub

    Private Sub EstiloBase(btn As Button)
        btn.FlatStyle = FlatStyle.Flat
        btn.UseVisualStyleBackColor = False
        btn.Font = FuenteBoton
        btn.Cursor = Cursors.Hand
        If btn.Size <> TamBotonGrande Then btn.Size = TamBoton
    End Sub

    Public Sub BotonPrimario(btn As Button)
        EstiloBase(btn)
        btn.BackColor = ColorCeleste
        btn.ForeColor = ColorNegro
        btn.FlatAppearance.BorderSize = 0
        btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 134, 217)
    End Sub

    Public Sub BotonSecundario(btn As Button)
        EstiloBase(btn)
        btn.BackColor = Color.White
        btn.ForeColor = ColorNegro
        btn.FlatAppearance.BorderSize = 1
        btn.FlatAppearance.BorderColor = ColorBorde
        btn.FlatAppearance.MouseOverBackColor = ColorFondo
    End Sub

    Public Sub BotonPeligro(btn As Button)
        EstiloBase(btn)
        btn.BackColor = ColorPeligro
        btn.ForeColor = Color.White
        btn.FlatAppearance.BorderSize = 0
        btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(180, 35, 24)
    End Sub

    Public Sub AplicarEstiloGrilla(dgv As DataGridView)
        dgv.BackgroundColor = Color.White
        dgv.BorderStyle = BorderStyle.None
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgv.GridColor = ColorBorde
        dgv.RowHeadersVisible = False
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.MultiSelect = False
        dgv.ReadOnly = True
        dgv.AllowUserToAddRows = False
        dgv.AllowUserToDeleteRows = False
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv.EnableHeadersVisualStyles = False
        dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgv.ColumnHeadersHeight = 36
        dgv.RowTemplate.Height = 32
        With dgv.ColumnHeadersDefaultCellStyle
            .BackColor = ColorNegro
            .ForeColor = Color.White
            .Font = FuenteBoton
            .SelectionBackColor = ColorNegro
        End With
        With dgv.DefaultCellStyle
            .Font = FuenteBase
            .ForeColor = ColorNegro
            .SelectionBackColor = ColorCeleste
            .SelectionForeColor = ColorNegro
        End With
        dgv.AlternatingRowsDefaultCellStyle.BackColor = ColorFondo
    End Sub

End Module
