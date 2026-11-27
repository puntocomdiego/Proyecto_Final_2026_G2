Imports System.Data.OleDb
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Reflection.Emit
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iFont = iTextSharp.text.Font
Imports System.Linq
Imports ClosedXML.Excel

Public Class frmConsultaVentas

    Private datos As New VentaDatos()
    Private detalle As New DetalleDatos()

    Dim bcerrar As Boolean = False

    Private Sub frmConsultaVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '== ESTILOS ==

        AplicarEstiloFormulario(Me, "Consultar Ventas")
        AplicarEstiloGrilla(dgvConsulta)
        TextStyle()

        BotonPrimario(btnFecha)
        BotonPrimario(btnCliente)

        BotonSecundario(btnNuevo)
        BotonSecundario(btnCerrar)

        Panel1.BackColor = Color.White
        Panel2.BackColor = ColorCeleste
        Panel3.BackColor = ColorNegro


        '= CARGA DE DATOS ==

        CargarClientes()
        'dgvBase(New DataTable())
        btnNuevo_Click(sender, e)

    End Sub

    '== FUNCIONES ==

    Private Sub TextStyle()

        Label1.Font = FuenteBase
        Label2.Font = FuenteBase

        Label6.Font = FuenteTitulo

    End Sub

    Private Sub CargarClientes()

        cboCliente.Items.Clear()

        Try
            Using cn As New OleDbConnection(CadenaConexion)
                cn.Open()

                Dim sql As String = "SELECT IdCliente, Apellido, Nombre " &
                                    "FROM Clientes " &
                                    "ORDER BY Apellido DESC;"


                Dim da As New OleDb.OleDbDataAdapter(sql, CadenaConexion)
                Dim dt As New DataTable
                da.Fill(dt)

                Dim fila As DataRow = dt.NewRow()
                fila("IdCliente") = 0
                fila("Apellido") = "-- Seleccione un cliente --"
                fila("Nombre") = ""

                dt.Rows.InsertAt(fila, 0)

                dt.Columns.Add("NombreCompleto", GetType(String))

                For Each dr As DataRow In dt.Rows
                    If CInt(dr("IdCliente")) = 0 Then
                        dr("NombreCompleto") = "-- Seleccione un cliente --"

                    Else

                        dr("NombreCompleto") = dr("Apellido").ToString() & ", " & dr("Nombre").ToString()

                    End If

                Next

                cboCliente.DataSource = dt
                cboCliente.DisplayMember = "NombreCompleto"
                cboCliente.ValueMember = "IdCliente"
                cboCliente.SelectedIndex = 0
            End Using


        Catch ex As Exception
            MessageBox.Show("Error al cargar clientes " & ex.Message, "Error",
                         MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub MostrarDatos(dt As DataTable)

        dgvConsulta.DataSource = dt

        dgvConsulta.Columns("Cliente").DisplayIndex = 1
        dgvConsulta.Columns("Total").DisplayIndex = 2
        dgvConsulta.Columns("FormaPago").DisplayIndex = 3

        dgvConsulta.Columns("IdVenta").HeaderText = "ID"
        dgvConsulta.Columns("IdVenta").Visible = False

        dgvConsulta.Columns("Fecha").HeaderText = "Fecha"
        dgvConsulta.Columns("Cliente").HeaderText = "Cliente"

        dgvConsulta.Columns("Total").HeaderText = "Total"
        dgvConsulta.Columns("Total").DefaultCellStyle.Format = "C2"
        dgvConsulta.Columns("Total").DefaultCellStyle.FormatProvider =
        Globalization.CultureInfo.GetCultureInfo("es-UY")

        dgvConsulta.Columns("FormaPago").HeaderText = "Forma de Pago"

    End Sub

    Private Sub CargarVenta(idVenta As Integer)
        Try

            If cboCliente.SelectedIndex <= 0 Then

                dgvConsulta.DataSource = Nothing

                Return
            End If

            Dim idCliente As Integer = CInt(cboCliente.SelectedValue)
            MostrarDatos(datos.ObtenerVentasCliente(idCliente))

        Catch ex As Exception
            MessageBox.Show("Error al cargar el detalle de la venta: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub dgvBase(dt As DataTable)

        dt.Columns.Add("Fecha", GetType(Date))
        dt.Columns.Add("Cliente", GetType(Integer))
        dt.Columns.Add("Total", GetType(Decimal))
        dt.Columns.Add("Forma de Pago", GetType(String))

        dgvConsulta.DataSource = dt

    End Sub

    Private Sub ConsultaFechas()


        dgvBase(New DataTable())

        Dim fechaInicio As Date = dtpFecha1.Value
        Dim fechaFin As Date = dtpFecha2.Value

        MostrarDatos(datos.ObtenerVentasFecha(fechaInicio, fechaFin))

    End Sub

    Private Sub ConsultarCliente()

        dgvBase(New DataTable())
        CargarVenta(CInt(cboCliente.SelectedValue))

    End Sub

    Public Function GetColumnasSize(ByVal columnasVisibles As List(Of DataGridViewColumn)) As Single()

        Dim values As Single() = New Single(columnasVisibles.Count - 1) {}

        For i As Integer = 0 To columnasVisibles.Count - 1
            values(i) = CSng(columnasVisibles(i).Width)
        Next

        Return values

    End Function

    Private Function FormatearValor(ByVal valor As Object, ByVal esMoneda As Boolean) As String
        If valor Is Nothing OrElse IsDBNull(valor) Then Return ""

        If TypeOf valor Is DateTime Then
            Return CDate(valor).ToString("dd/MM/yyyy")   ' saca el " 0:00:00"
        End If

        Dim n As Double
        If Double.TryParse(valor.ToString(), n) Then
            If esMoneda Then Return Format(n, "$ #,##0.00") ' ej: $ 6.650,00
            Return valor.ToString()                          ' Id, Cantidad: tal cual
        End If

        Return valor.ToString()
    End Function

    Private Function AlinearPorTipo(ByVal valor As Object) As Integer
        If valor Is Nothing OrElse IsDBNull(valor) Then Return Element.ALIGN_LEFT
        If TypeOf valor Is DateTime Then Return Element.ALIGN_CENTER

        Dim n As Double
        If Double.TryParse(valor.ToString(), n) Then Return Element.ALIGN_RIGHT

        Return Element.ALIGN_LEFT
    End Function

    Private Sub ReleaseObject(obj As Object)
        Try
            Runtime.InteropServices.Marshal.ReleaseComObject(obj)
        Catch
        Finally
            obj = Nothing
        End Try
    End Sub

    '== FUNCIONES DE EXPORTAR ==

    Public Sub ExportarDatosPDF(ByVal document As Document)


        Try
            ' ---- Paleta ----
            Dim colorTitulo As New BaseColor(41, 84, 148)     ' azul
            Dim colorHeader As New BaseColor(41, 84, 148)
            Dim colorZebra As New BaseColor(238, 242, 248)    ' gris muy claro
            Dim colorBorde As New BaseColor(210, 210, 210)
            Dim colorTotalBg As New BaseColor(222, 230, 242)

            ' ---- Fuentes reutilizables ----
            Dim fTitulo As iFont = FontFactory.GetFont("Helvetica", 20, iFont.BOLD, colorTitulo)
            Dim fSub As iFont = FontFactory.GetFont("Helvetica", 11, iFont.NORMAL, BaseColor.GRAY)
            Dim fHeader As iFont = FontFactory.GetFont("Helvetica", 9, iFont.BOLD, BaseColor.WHITE)
            Dim fCelda As iFont = FontFactory.GetFont("Helvetica", 9, iFont.NORMAL, New BaseColor(40, 40, 40))
            Dim fTotal As iFont = FontFactory.GetFont("Helvetica", 9, iFont.BOLD, colorTitulo)

            ' ---- Configuración: qué columnas sumar y cuáles son dinero ----
            Dim columnasTotal As String() = {"Total"}
            Dim columnasMoneda As String() = {"Total"}

            ' ---- Encabezado del documento ----
            Dim encabezado As New Paragraph("Listado de ventas", fTitulo)
            encabezado.SpacingAfter = 4
            document.Add(encabezado)

            If cboCliente.Enabled = False Then
                document.Add(New Paragraph("Ventas desde: " & dtpFecha1.Text & " hasta: " & dtpFecha2.Text, fSub))
            ElseIf cboCliente.Enabled = True Then
                document.Add(New Paragraph("Ventas a: " & cboCliente.Text, fSub))
            End If

            Dim texto As New Paragraph("Fecha de exportación: " & Now.ToString("dd/MM/yyyy"), fSub)
            texto.SpacingAfter = 14
            document.Add(texto)

            ' ---- Tabla ----
            ' Obtener únicamente las columnas visibles
            Dim columnasVisibles = dgvConsulta.Columns.
        Cast(Of DataGridViewColumn)().
        Where(Function(c) c.Visible).
        ToList()

            Dim cantidadColumnas As Integer = columnasVisibles.Count

            If cantidadColumnas = 0 Then
                Throw New Exception("No hay columnas visibles para exportar.")
            End If

            Dim tabla As New PdfPTable(cantidadColumnas)
            tabla.SetWidths(GetColumnasSize(columnasVisibles))
            tabla.WidthPercentage = 100
            tabla.SpacingBefore = 4

            ' ---- Precalcular banderas por columna ----
            Dim esTotalizable(cantidadColumnas - 1) As Boolean
            Dim esMoneda(cantidadColumnas - 1) As Boolean

            For j As Integer = 0 To cantidadColumnas - 1
                Dim h As String = columnasVisibles(j).HeaderText

                esTotalizable(j) = Array.IndexOf(columnasTotal, h) >= 0
                esMoneda(j) = Array.IndexOf(columnasMoneda, h) >= 0
            Next

            ' ---- Fila de encabezado de columnas ----
            For j As Integer = 0 To cantidadColumnas - 1

                Dim c As New PdfPCell(New Phrase(columnasVisibles(j).HeaderText, fHeader))

                c.BackgroundColor = colorHeader
                c.HorizontalAlignment = Element.ALIGN_CENTER
                c.VerticalAlignment = Element.ALIGN_MIDDLE
                c.Padding = 6
                c.BorderColor = BaseColor.WHITE

                tabla.AddCell(c)
            Next

            tabla.HeaderRows = 1

            ' ---- Filas de datos ----
            Dim sumas(cantidadColumnas - 1) As Double
            Dim indiceFila As Integer = 0

            For Each fila As DataGridViewRow In dgvConsulta.Rows

                ' Omitir únicamente la fila nueva y vacía
                If Not fila.IsNewRow Then

                    Dim fondo As BaseColor = If(indiceFila Mod 2 = 0, BaseColor.WHITE, colorZebra)

                    For j As Integer = 0 To cantidadColumnas - 1

                        Dim valor As Object = fila.Cells(columnasVisibles(j).Index).Value
                        Dim c As New PdfPCell(New Phrase(FormatearValor(valor, esMoneda(j)), fCelda))

                        c.BackgroundColor = fondo
                        c.Padding = 5
                        c.HorizontalAlignment = AlinearPorTipo(valor)
                        c.VerticalAlignment = Element.ALIGN_MIDDLE
                        c.BorderColor = colorBorde

                        tabla.AddCell(c)

                        If esTotalizable(j) Then

                            Dim n As Double

                            If valor IsNot Nothing AndAlso Double.TryParse(valor.ToString(), n) Then
                                sumas(j) += n
                            End If

                        End If
                    Next

                    indiceFila += 1

                End If
            Next

            ' ---- Fila de TOTAL ----
            Dim primeraTotal As Integer = Array.FindIndex(esTotalizable, Function(x) x)
            Dim idxEtiqueta As Integer = If(primeraTotal > 0, primeraTotal - 1, 0)

            For j As Integer = 0 To cantidadColumnas - 1

                Dim txt As String = ""

                If esTotalizable(j) Then
                    txt = If(esMoneda(j),
                     Format(sumas(j), "$ #,##0.00"),
                     Format(sumas(j), "#,##0"))
                ElseIf j = idxEtiqueta Then
                    txt = "TOTAL EN VENTAS"
                End If

                Dim c As New PdfPCell(New Phrase(txt, fTotal))

                c.BackgroundColor = colorTotalBg
                c.HorizontalAlignment = Element.ALIGN_RIGHT
                c.Padding = 6
                c.BorderColor = colorBorde

                tabla.AddCell(c)
            Next

            document.Add(tabla)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Public Sub ExportarAExcel(ByVal dg As DataGridView, ByVal rutaDestino As String)

        Try
            ' Obtener columnas visibles
            Dim columnasVisibles = dg.Columns.
        Cast(Of DataGridViewColumn)().
        Where(Function(c) c.Visible).
        ToList()

            Dim cantidadColumnas As Integer = columnasVisibles.Count

            If cantidadColumnas = 0 Then
                MessageBox.Show("No hay columnas visibles para exportar.")
                Return
            End If

            Using libro As New XLWorkbook()

                Dim hoja = libro.Worksheets.Add("Datos")

                ' ---- Título ----
                hoja.Cell(1, 1).Value = "Listado de ventas"

                With hoja.Range(1, 1, 1, cantidadColumnas)
                    .Merge()
                    .Style.Font.Bold = True
                    .Style.Font.FontSize = 20
                    .Style.Font.FontColor = XLColor.FromHtml("#295494")
                End With

                ' ---- Subtítulo según el filtro ----
                Dim subtitulo As String = ""

                If cboCliente.Enabled = False Then

                    subtitulo = "Ventas desde: " & dtpFecha1.Text &
                        " hasta: " & dtpFecha2.Text

                Else

                    subtitulo = "Ventas a: " & cboCliente.Text

                End If

                hoja.Cell(2, 1).Value = subtitulo
                hoja.Range(2, 1, 2, cantidadColumnas).Merge()

                ' ---- Fecha de exportación ----
                hoja.Cell(3, 1).Value =
            "Fecha de exportación: " & Now.ToString("dd/MM/yyyy")

                hoja.Range(3, 1, 3, cantidadColumnas).Merge()

                ' ---- Encabezados ----
                Dim filaEncabezado As Integer = 5

                For j As Integer = 0 To cantidadColumnas - 1

                    Dim celda = hoja.Cell(filaEncabezado, j + 1)

                    celda.Value = columnasVisibles(j).HeaderText

                    celda.Style.Font.Bold = True
                    celda.Style.Font.FontColor = XLColor.White
                    celda.Style.Fill.BackgroundColor =
                XLColor.FromHtml("#295494")

                    celda.Style.Alignment.Horizontal =
                XLAlignmentHorizontalValues.Center

                    celda.Style.Alignment.Vertical =
                XLAlignmentVerticalValues.Center

                Next

                ' ---- Datos ----
                Dim filaExcel As Integer = filaEncabezado + 1

                ' Determinar la última fila real del DataGridView
                Dim cantidadFilas As Integer = dg.Rows.Count

                If dg.AllowUserToAddRows Then
                    cantidadFilas -= 1
                End If

                For i As Integer = 0 To cantidadFilas - 1

                    Dim fila As DataGridViewRow = dg.Rows(i)

                    For j As Integer = 0 To cantidadColumnas - 1

                        Dim valor As Object =
                    fila.Cells(columnasVisibles(j).Index).Value

                        If valor IsNot Nothing AndAlso Not IsDBNull(valor) Then

                            Dim celda = hoja.Cell(filaExcel, j + 1)

                            If TypeOf valor Is DateTime Then

                                celda.Value = CType(valor, DateTime)
                                celda.Style.DateFormat.Format = "dd/MM/yyyy"

                            ElseIf TypeOf valor Is Decimal OrElse
                           TypeOf valor Is Double OrElse
                           TypeOf valor Is Integer OrElse
                           TypeOf valor Is Long Then

                                celda.Value = Convert.ToDouble(valor)

                            Else

                                celda.Value = valor.ToString()

                            End If

                        End If

                    Next

                    ' Filas alternadas
                    If filaExcel Mod 2 = 0 Then

                        hoja.Range(filaExcel, 1,
                           filaExcel, cantidadColumnas).
                           Style.Fill.BackgroundColor =
                           XLColor.FromHtml("#EEF2F8")

                    End If

                    filaExcel += 1

                Next

                ' ---- Calcular totales ----
                Dim columnasTotal As String() = {"Total"}

                Dim primeraTotal As Integer = -1

                For j As Integer = 0 To cantidadColumnas - 1

                    If Array.IndexOf(columnasTotal,
                             columnasVisibles(j).HeaderText) >= 0 Then

                        primeraTotal = j
                        Exit For

                    End If

                Next

                ' ---- Fila de TOTAL ----
                Dim filaTotal As Integer = filaExcel

                If primeraTotal >= 0 Then

                    Dim suma As Decimal = 0

                    For i As Integer = filaEncabezado + 1 To filaExcel - 1

                        Dim valor = hoja.Cell(i, primeraTotal + 1).Value

                        If Not valor.IsBlank Then

                            Dim numero As Decimal

                            If Decimal.TryParse(valor.ToString(), numero) Then
                                suma += numero
                            End If

                        End If

                    Next

                    Dim idxEtiqueta As Integer =
                If(primeraTotal > 0, primeraTotal - 1, 0)

                    hoja.Cell(filaTotal, primeraTotal + 1).Value = suma

                    hoja.Cell(filaTotal, primeraTotal + 1).
                Style.NumberFormat.Format = "$ #,##0.00"

                    hoja.Cell(filaTotal, idxEtiqueta + 1).Value =
                "TOTAL EN VENTAS"

                    With hoja.Range(filaTotal, 1,
                            filaTotal, cantidadColumnas)

                        .Style.Font.Bold = True
                        .Style.Font.FontColor =
                    XLColor.FromHtml("#295494")

                        .Style.Fill.BackgroundColor =
                    XLColor.FromHtml("#DEE6F2")

                        .Style.Border.TopBorder =
                    XLBorderStyleValues.Thin

                    End With

                End If

                ' ---- Ajustes finales ----

                hoja.Columns().AdjustToContents()

                ' Inmovilizar encabezados
                hoja.SheetView.FreezeRows(filaEncabezado)

                ' Bordes de la tabla
                If filaTotal > filaEncabezado Then

                    With hoja.Range(filaEncabezado, 1,
                            filaTotal, cantidadColumnas)

                        .Style.Border.OutsideBorder =
                    XLBorderStyleValues.Thin

                        .Style.Border.InsideBorder =
                    XLBorderStyleValues.Thin

                    End With

                End If

                ' Guardar archivo
                libro.SaveAs(rutaDestino)

            End Using

            MessageBox.Show(
        "Datos exportados correctamente a: " & rutaDestino,
        "Éxito",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information)

        Catch ex As Exception

            MessageBox.Show(
        ex.ToString(),
        "Error al exportar a Excel",
        MessageBoxButtons.OK,
        MessageBoxIcon.Error)

        End Try

    End Sub

    '== CONTROLES ==

    Private Sub btnFecha_Click(sender As Object, e As EventArgs) Handles btnFecha.Click

        If dtpFecha1.Enabled = False Then
            dtpFecha1.Enabled = True
            dtpFecha2.Enabled = True

            btnCliente.Enabled = False
            btnExportar.Enabled = True

        End If

    End Sub

    Private Sub cboCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCliente.SelectedIndexChanged

        If cboCliente.SelectedIndex = 0 Then

            dgvBase(New DataTable())
            btnExportar.Enabled = False
            rbtExel.Enabled = False
            rbtPDF.Enabled = False

        Else

            ConsultarCliente()
            btnExportar.Enabled = True
            rbtExel.Enabled = True
            rbtPDF.Enabled = True

        End If

    End Sub

    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click

        If cboCliente.Enabled = False Then

            cboCliente.Enabled = True

            btnFecha.Enabled = False

        End If

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click

        cboCliente.Enabled = False
        cboCliente.SelectedIndex = 0

        dtpFecha1.Enabled = False
        dtpFecha2.Enabled = False
        dtpFecha1.Value = Date.Now
        dtpFecha2.Value = Date.Now

        btnFecha.Enabled = True
        btnCliente.Enabled = True

        btnExportar.Enabled = False

        rbtExel.Checked = False
        rbtExel.Enabled = False

        rbtPDF.Checked = False
        rbtPDF.Enabled = False

        dgvBase(New DataTable)

    End Sub

    Private Sub dtpFecha1_ValueChanged(sender As Object, e As EventArgs) Handles dtpFecha1.ValueChanged

        If dtpFecha1.Enabled = True Then

            If dtpFecha1.Value > dtpFecha2.Value Then
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dtpFecha1.Value = dtpFecha2.Value
                Return
            End If

            ConsultaFechas()

            btnExportar.Enabled = True
            rbtExel.Enabled = True
            rbtPDF.Enabled = True

        End If

    End Sub

    Private Sub dtpFecha2_ValueChanged(sender As Object, e As EventArgs) Handles dtpFecha2.ValueChanged

        If dtpFecha2.Enabled = True Then

            If dtpFecha2.Value < dtpFecha1.Value Then
                MessageBox.Show("La fecha de fin no puede ser menor que la fecha de inicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dtpFecha2.Value = dtpFecha1.Value
                Return

            ElseIf dtpFecha2.Value > Date.Now Then
                MessageBox.Show("La fecha de fin no puede ser mayor que la fecha actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dtpFecha2.Value = Date.Now
                Return

            End If

            ConsultaFechas()

            btnExportar.Enabled = True
            rbtExel.Enabled = True
            rbtPDF.Enabled = True
        End If

    End Sub

    '== EXPORTAR ==

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click

        Try

            If dgvConsulta.Rows.Count = 0 Then
                MessageBox.Show("No hay datos para exportar.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            If rbtExel.Checked = False AndAlso rbtPDF.Checked = False Then
                MessageBox.Show("Seleccione un formato de exportación.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return

            ElseIf rbtPDF.Checked = True Then

                Using sfd As New SaveFileDialog()
                    sfd.Filter = "Archivos PDF (*.pdf)|*.pdf"
                    sfd.Title = "Guardar como archivo PDF"
                    sfd.FileName = "Listado de Ventas_" & Date.Now.ToString("yyyy-MM-dd_HH-mm") & ".pdf"
                    If sfd.ShowDialog() = DialogResult.OK Then
                        Dim document As New Document(PageSize.A4, 36, 36, 36, 36)
                        Dim pdfWriter As PdfWriter = pdfWriter.GetInstance(document, New FileStream(sfd.FileName, FileMode.Create))
                        document.Open()
                        pdfWriter.PageEvent = New piedepagina()
                        ExportarDatosPDF(document)
                        document.Close()
                        MessageBox.Show("Datos exportados correctamente a: " & sfd.FileName,
                                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                End Using

            ElseIf rbtExel.Checked = True Then

                Using sfd As New SaveFileDialog()
                    sfd.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
                    sfd.Title = "Guardar como archivo de Excel"
                    sfd.DefaultExt = "xlsx"
                    sfd.AddExtension = True
                    sfd.FileName = "Listado de Ventas_" & Date.Now.ToString("yyyy-MM-dd_HH-mm") & ".xlsx"
                    If sfd.ShowDialog() = DialogResult.OK Then
                        ExportarAExcel(dgvConsulta, sfd.FileName)
                    End If
                End Using

            End If

        Catch ex As Exception

            MessageBox.Show("Error al exportar los datos: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub rbtPDF_CheckedChanged(sender As Object, e As EventArgs) Handles rbtPDF.CheckedChanged

        If rbtPDF.Checked Then
            rbtExel.Checked = False
        End If


    End Sub

    Private Sub rbtExel_CheckedChanged(sender As Object, e As EventArgs) Handles rbtExel.CheckedChanged

        If rbtExel.Checked Then
            rbtPDF.Checked = False
        End If

    End Sub


    '== CERRAR ==

    Private Sub frmConsultaVentas_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If bcerrar = False Then

            Dim respuesta As DialogResult

            respuesta = MessageBox.Show("¿Estás seguro que deseas salir?",
                                    "Confirmar cierre",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question)

            If respuesta = DialogResult.No Then

                e.Cancel = True

            End If

        End If

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click

        Try

            Dim respuesta As DialogResult

            respuesta = MessageBox.Show("¿Estás seguro que deseas salir?", "Confirmar cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If respuesta = DialogResult.Yes Then
                bcerrar = True
                Close()

            Else

                bcerrar = False

            End If

        Catch ex As Exception

            MsgBox("Error al cerrar la venta: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

End Class