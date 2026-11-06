Imports System.IO
'Imports System.Net.Mime.MediaTypeNames
'Imports System.Reflection.Metadata
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports Excel = Microsoft.Office.Interop.Excel
Imports iFont = iTextSharp.text.Font

Public Class frmProductos
    Private idProductoSeleccionado As Integer = -1
    Private datos As New Cls_ProductoDatos()
    Private ruta As String = String.Empty
    Private tablaActual As DataTable

    Private Sub frmProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarCategorias()
        ConfigurarGrilla()
        MostrarProductos(datos.ListarProductos())
    End Sub
    Private Sub CargarCategorias()
        Try
            Dim consulta As String = "SELECT Categorias.IdCategoria, Categorias.Nombre " _
+ "From Categorias " _
+ "Order By Categorias.Nombre;"
            Dim dt As DataTable = datos.Listar

            cmbCategorias.DataSource = dt
            cmbCategorias.DisplayMember = "Nombre"
            cmbCategorias.ValueMember = "IdCategoria"
            cmbCategorias.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show("Error al cargar las categorías: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ConfigurarGrilla()
        dgvProductos.AutoGenerateColumns = True
        dgvProductos.ReadOnly = True
        dgvProductos.AllowUserToAddRows = False
        dgvProductos.MultiSelect = False
        dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub
    Private Sub MostrarProductos(dt As DataTable)
        dgvProductos.DataSource = dt

        If dt.Rows.Count = 0 Then Exit Sub

        dgvProductos.Columns("Codigo").HeaderText = "Código"
        dgvProductos.Columns("Descripcion").HeaderText = "Descripción"
        dgvProductos.Columns("StockMinimo").HeaderText = "Stock Mínimo"
        dgvProductos.Columns("Precio").HeaderText = "Precio"
        dgvProductos.Columns("Stock").HeaderText = "Stock Disponible"
        dgvProductos.Columns("Precio").DefaultCellStyle.Format = "C2"
        dgvProductos.Columns("Precio").DefaultCellStyle.FormatProvider =
            Globalization.CultureInfo.GetCultureInfo("es-UY")
    End Sub

    Private Sub Limpiar()
        txtCodigo.Clear()
        txtDescripcion.Clear()
        txtPrecio.Clear()
        txtBuscar.Clear()
        txtBuscar.Visible = False
        btnBuscar.Visible = True
        txtStock.Clear()
        txtStockminimo.Clear()
    End Sub
    Private Sub VerificarStockMinimo()
        If Not dgvProductos.Columns.Contains("Stock") OrElse
        Not dgvProductos.Columns.Contains("StockMinimo") Then Exit Sub

        For Each row As DataGridViewRow In dgvProductos.Rows
            If row.IsNewRow Then Continue For

            Dim valorStock As Object = row.Cells("Stock").Value
            Dim valorMinimo As Object = row.Cells("StockMinimo").Value

            ' Color.Empty devuelve la fila al color normal de la grilla
            row.DefaultCellStyle.BackColor = Color.Empty

            If valorStock Is Nothing OrElse IsDBNull(valorStock) OrElse
            valorMinimo Is Nothing OrElse IsDBNull(valorMinimo) Then Continue For

            If Convert.ToInt32(valorStock) <= Convert.ToInt32(valorMinimo) Then
                row.DefaultCellStyle.BackColor = Color.LightCoral
            End If
        Next
    End Sub
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If Not DatosValidos() Then Exit Sub
        Try
            Dim p As New Cls_Producto()
            p.Codigo = txtCodigo.Text.Trim()
            p.Descripcion = txtDescripcion.Text.Trim()
            p.Precio = Decimal.Parse(txtPrecio.Text)
            p.Stock = Integer.Parse(txtStock.Text)
            p.StockMinimo = Integer.Parse(txtStockminimo.Text)
            p.IdCategoria = Convert.ToInt32(cmbCategorias.SelectedValue)
            p.Activo = True

            If datos.Agregar(p) Then
                MostrarProductos(datos.ListarProductos())
                MsgBox("Producto agregado correctamente.", MsgBoxStyle.Information, "Éxito")
            End If
        Catch ex As Exception
            MessageBox.Show("No se pudo agregar el producto: " & ex.Message)
        End Try
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        txtBuscar.Clear()
        txtBuscar.Visible = False
        btnok.Visible = False
        btnBuscar.Enabled = True
        LimpiarCampos()
        MsgBox("Se han limpiado los campos del formulario.", MsgBoxStyle.Information, "Campos Limpiados")
    End Sub

    Private Sub LimpiarCampos()
        idProductoSeleccionado = -1
        txtCodigo.Clear()
        txtDescripcion.Clear()
        txtPrecio.Clear()
        txtStock.Clear()
        txtStockminimo.Clear()
        cmbCategorias.SelectedIndex = -1
        txtCodigo.Focus()
        btnEliminar.Enabled = False
        btnModificar.Enabled = False
        btnAgregar.Enabled = False
        chkActivo.Visible = False

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        txtBuscar.Visible = True
        btnBuscar.Enabled = False
        btnok.Visible = True
    End Sub

    Private Function DatosValidos() As Boolean
        If txtCodigo.Text.Trim() = "" Then
            MessageBox.Show("Ingresá el código por favor.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCodigo.Focus()
            Return False
        End If

        If txtDescripcion.Text.Trim() = "" Then
            MessageBox.Show("Ingresá la descripción por favor.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDescripcion.Focus()
            Return False
        End If

        Dim p As Decimal
        If Not Decimal.TryParse(txtPrecio.Text, p) Then
            MessageBox.Show("El precio debe ser un número válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPrecio.Focus()
            Return False
        End If

        Dim s As Integer
        If Not Integer.TryParse(txtStock.Text, s) Then
            MessageBox.Show("El stock debe ser un número entero válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtStock.Focus()
            Return False
        End If

        Dim sm As Integer
        If Not Integer.TryParse(txtStockminimo.Text, sm) Then
            MessageBox.Show("El stock mínimo debe ser un número entero válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtStockminimo.Focus()
            Return False
        End If

        If cmbCategorias.SelectedIndex = -1 Then
            MessageBox.Show("Seleccioná una categoría por favor.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbCategorias.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If idProductoSeleccionado = -1 Then
            MessageBox.Show("Seleccione un producto de la grilla para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If Not DatosValidos() Then Exit Sub
        Try
            Dim p As New Cls_Producto()
            p.IdProducto = idProductoSeleccionado
            p.Codigo = txtCodigo.Text.Trim()
            p.Descripcion = txtDescripcion.Text.Trim()
            p.Precio = Decimal.Parse(txtPrecio.Text)
            p.Stock = Integer.Parse(txtStock.Text)
            p.StockMinimo = Integer.Parse(txtStockminimo.Text)
            p.IdCategoria = Convert.ToInt32(cmbCategorias.SelectedValue)
            p.Activo = chkActivo.Checked

            If datos.Modificar(p) Then
                MessageBox.Show("Producto modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                MostrarProductos(datos.ListarProductos())
                LimpiarCampos()
                idProductoSeleccionado = -1
                btnEliminar.Enabled = False
                chkActivo.Visible = False
            Else
                MessageBox.Show("No se pudo realizar la modificación en la base de datos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("No se pudo modificar el producto: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If txtCodigo.Text.Trim() = "" Then
            MessageBox.Show("Seleccione o ingrese el código del producto a eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If MessageBox.Show("¿Eliminar el producto seleccionado?", "Confirmar",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
        Try
            If datos.Eliminar(txtCodigo.Text.Trim()) Then
                MostrarProductos(datos.ListarProductos())
                Limpiar()
                MsgBox("Producto eliminado correctamente.", MsgBoxStyle.Information, "Éxito")
            End If
        Catch ex As Exception
            MessageBox.Show("No se pudo eliminar el producto: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvProductos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvProductos.Rows(e.RowIndex)

            idProductoSeleccionado = Convert.ToInt32(row.Cells("IdProducto").Value)
            txtCodigo.Text = row.Cells("Codigo").Value.ToString()
            txtDescripcion.Text = row.Cells("Descripcion").Value.ToString()
            txtPrecio.Text = row.Cells("Precio").Value.ToString()
            txtStock.Text = row.Cells("Stock").Value.ToString()
            txtStockminimo.Text = row.Cells("StockMinimo").Value.ToString()

            If row.Cells("Nombre").Value IsNot Nothing Then
                cmbCategorias.Text = row.Cells("Nombre").Value.ToString()
            End If
            If row.Cells("Activo").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("Activo").Value) Then
                chkActivo.Checked = Convert.ToBoolean(row.Cells("Activo").Value)
            End If

            btnEliminar.Enabled = True
            btnModificar.Enabled = True
            chkActivo.Visible = True
        End If
    End Sub
    Private Sub dgvProductos_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvProductos.MouseDown
        Dim hitTest As DataGridView.HitTestInfo = dgvProductos.HitTest(e.X, e.Y)
        If hitTest.Type = DataGridViewHitTestType.None Then
            dgvProductos.ClearSelection()
            idProductoSeleccionado = -1
            LimpiarCampos()
        End If
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        'opción 1: Filtrar la grilla directamente

        'Try
        '    If dgvProductos.DataSource IsNot Nothing Then
        '        Dim dt As DataTable = CType(dgvProductos.DataSource, DataTable)
        '        Dim dv As DataView = dt.DefaultView
        '        Dim filtro As String = txtBuscar.Text.Trim()

        '        If filtro = "" Then
        '            dv.RowFilter = String.Empty
        '        Else
        '            dv.RowFilter = "Descripcion LIKE '%" & filtro & "%' OR Codigo LIKE '%" & filtro & "%'"
        '        End If
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        'End Try

        '---------------------------------------------------------------------------------------------------------

        'opcion 2: Buscar en la base de datos y actualizar la grilla

        Try
            Dim dt As DataTable = datos.Buscar(txtBuscar.Text.Trim())

            dgvProductos.DataSource = dt

            If dt.Rows.Count > 0 Then
            End If
        Catch ex As Exception
            MessageBox.Show("Error en la búsqueda: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnok_Click(sender As Object, e As EventArgs) Handles btnok.Click
        txtBuscar.Visible = False
        btnBuscar.Enabled = True
        btnok.Visible = False
        txtBuscar.Text = String.Empty
    End Sub

    Private Sub txtCodigo_GotFocus(sender As Object, e As EventArgs) Handles txtCodigo.GotFocus
        txtCodigo.BackColor = Color.LightGreen
    End Sub
    Private Sub txtCodigo_LostFocus(sender As Object, e As EventArgs) Handles txtCodigo.LostFocus
        txtCodigo.BackColor = Color.White
    End Sub
    Private Sub txtDescripcion_GotFocus(sender As Object, e As EventArgs) Handles txtDescripcion.GotFocus
        txtDescripcion.BackColor = Color.LightGreen
    End Sub
    Private Sub txtDescripcion_LostFocus(sender As Object, e As EventArgs) Handles txtDescripcion.LostFocus
        txtDescripcion.BackColor = Color.White
    End Sub
    Private Sub txtPrecio_GotFocus(sender As Object, e As EventArgs) Handles txtPrecio.GotFocus
        txtPrecio.BackColor = Color.LightGreen
    End Sub
    Private Sub txtPrecio_LostFocus(sender As Object, e As EventArgs) Handles txtPrecio.LostFocus
        txtPrecio.BackColor = Color.White
    End Sub
    Private Sub txtStock_GotFocus(sender As Object, e As EventArgs) Handles txtStock.GotFocus
        txtStock.BackColor = Color.LightGreen
    End Sub
    Private Sub txtStock_LostFocus(sender As Object, e As EventArgs) Handles txtStock.LostFocus
        txtStock.BackColor = Color.White
    End Sub
    Private Sub txtStockminimo_GotFocus(sender As Object, e As EventArgs) Handles txtStockminimo.GotFocus
        txtStockminimo.BackColor = Color.LightGreen
        btnAgregar.Enabled = True
    End Sub
    Private Sub txtStockminimo_LostFocus(sender As Object, e As EventArgs) Handles txtStockminimo.LostFocus
        txtStockminimo.BackColor = Color.White
    End Sub

    Private Sub btnFin_Click(sender As Object, e As EventArgs) Handles btnFin.Click
        Close()
        MsgBox("Gracias por utilizar el programa!", MsgBoxStyle.Information, "Fin del programa")
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarCampos()
        txtCodigo.Focus()
        MsgBox("Ingrese los datos del nuevo producto y luego presione el botón 'Agregar'.", MsgBoxStyle.Information, "Nuevo Producto")
        btnAgregar.Enabled = True
    End Sub

    Private Sub dgvProductos_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvProductos.DataBindingComplete
        VerificarStockMinimo()
    End Sub
    Private Sub txtCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigo.KeyPress
        If InStr("0123456789" & Chr(8), e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        If Chr(13) = e.KeyChar Then
            txtDescripcion.Focus()
        End If
    End Sub
    Private Sub txtdescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescripcion.KeyPress
        If InStr("0123456789ZXCVBNMASDFGHJKLQWERTYUIOPzxcvbnmasdfghjklqwertyuiopáíéúóúñÁÉÍÓÚÑ " & Chr(8), e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        If Chr(13) = e.KeyChar Then
            txtPrecio.Focus()
        End If
    End Sub
    Private Sub txtprecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        If InStr("0123456789" & Chr(8), e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        If Chr(13) = e.KeyChar Then
            txtStock.Focus()
        End If
    End Sub
    Private Sub txtStock_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtStock.KeyPress
        If InStr("0123456789" & Chr(8), e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        If Chr(13) = e.KeyChar Then
            txtStockminimo.Focus()
        End If
    End Sub
    Private Sub txtStockminimo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtStockminimo.KeyPress
        If InStr("0123456789" & Chr(8), e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        If Chr(13) = e.KeyChar Then
            btnAgregar.PerformClick()
        End If
    End Sub
    Private Sub txtbuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If InStr("0123456789ZXCVBNMASDFGHJKLQWERTYUIOPzxcvbnmasdfghjklqwertyuiopáíéúóúñÁÉÍÓÚÑ " & Chr(8), e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        If Chr(13) = e.KeyChar Then
            btnok.PerformClick()
        End If
    End Sub

    Private Sub rdexcel_CheckedChanged(sender As Object, e As EventArgs) Handles rdexcel.CheckedChanged
        If rdexcel.Checked Then
            btnexportar.Enabled = True
        End If
    End Sub

    Private Sub rdpdf_CheckedChanged(sender As Object, e As EventArgs) Handles rdpdf.CheckedChanged
        If rdpdf.Checked Then
            btnexportar.Enabled = True
        End If
    End Sub

    Private Sub btnexportar_Click(sender As Object, e As EventArgs) Handles btnexportar.Click

        If rdpdf.Checked = True Then

            ' A4 en HORIZONTAL: para 10 columnas se lee mucho mejor que en vertical.
            ' Márgenes: izq, der, sup, inf.
            Dim document As New Document(PageSize.A4.Rotate(), 36, 36, 50, 55)

            Dim ruta As String

            FolderBrowserDialog1.ShowDialog()
            ruta = FolderBrowserDialog1.SelectedPath()
            ruta = ruta + "\datos.pdf"
            Dim f As String = Format(Now.Date, "dd-MM-yy")
            'filename = ruta + "\" + ComboBox1.Text + "-" + f + ".pdf"

            Try
                Using fs As New FileStream(ruta, FileMode.Create)
                    Dim writer As PdfWriter = PdfWriter.GetInstance(document, fs)
                    writer.PageEvent = New piedepagina()   ' <- activa el pie con numeración
                    document.Open()

                    ExportarDatosPDF(document)

                    document.Close()
                End Using

                MsgBox("PDF generado correctamente.", MsgBoxStyle.Information)
                Process.Start(ruta)  ' abre el PDF (opcional)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        If rdexcel.Checked = True Then
            Using sfd As New SaveFileDialog()
                sfd.Filter = "Archivo de Excel (*.xlsx)|*.xlsx"
                sfd.FileName = cmbCategorias.SelectedItem.ToString() & ".xlsx"

                If sfd.ShowDialog() = DialogResult.OK Then
                    ExportarAExcel(tablaActual, sfd.FileName)
                End If
            End Using
        End If

        If tablaActual Is Nothing OrElse tablaActual.Rows.Count = 0 Then
            MessageBox.Show("Seleccione una opción para Exportar.", "Aviso",
                     MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
    End Sub

    Public Sub ExportarDatosPDF(ByVal document As Document)
        Try

            ' ---- Paleta ----
            Dim colorTitulo As New BaseColor(41, 84, 148)     ' azul
            Dim colorHeader As New BaseColor(41, 84, 148)
            Dim colorZebra As New BaseColor(238, 242, 248)    ' gris muy claro
            Dim colorBorde As New BaseColor(210, 210, 210)
            Dim colorTotalBg As New BaseColor(222, 230, 242)

            ' ---- Fuentes reutilizables (esto reemplaza el Font.Name = "Tahoma" roto) ----


            Dim fTitulo As iFont = FontFactory.GetFont("Helvetica", 20, iFont.BOLD, colorTitulo)
            Dim fSub As iFont = FontFactory.GetFont("Helvetica", 11, iFont.NORMAL, BaseColor.GRAY)
            Dim fHeader As iFont = FontFactory.GetFont("Helvetica", 9, iFont.BOLD, BaseColor.WHITE)
            Dim fCelda As iFont = FontFactory.GetFont("Helvetica", 9, iFont.NORMAL, New BaseColor(40, 40, 40))
            Dim fTotal As iFont = FontFactory.GetFont("Helvetica", 9, iFont.BOLD, colorTitulo)

            ' ---- Configuración: qué columnas sumar y cuáles son dinero ----
            '      (se comparan contra el HeaderText de cada columna)
            Dim columnasTotal As String() = {"Cantidad", "Importe", "Costo"}
            Dim columnasMoneda As String() = {"Importe", "Costo"}

            ' ---- Encabezado del documento ----
            Dim encabezado As New Paragraph("Listado de ventas", fTitulo)
            encabezado.SpacingAfter = 4
            document.Add(encabezado)

            document.Add(New Paragraph("Ventas de: " & cmbCategorias.Text, fSub))

            Dim texto As New Paragraph("Fecha de exportación: " & Now.ToString("dd/MM/yyyy"), fSub)
            texto.SpacingAfter = 14
            document.Add(texto)

            ' ---- Tabla ----
            Dim datatable As New PdfPTable(dgvProductos.ColumnCount)
            datatable.SetWidths(GetColumnasSize(dgvProductos))
            datatable.WidthPercentage = 100
            datatable.SpacingBefore = 4

            ' Precalcular banderas por columna
            Dim esTotalizable(dgvProductos.ColumnCount - 1) As Boolean
            Dim esMoneda(dgvProductos.ColumnCount - 1) As Boolean
            For j As Integer = 0 To dgvProductos.ColumnCount - 1
                Dim h As String = dgvProductos.Columns(j).HeaderText
                esTotalizable(j) = Array.IndexOf(columnasTotal, h) >= 0
                esMoneda(j) = Array.IndexOf(columnasMoneda, h) >= 0
            Next

            ' ---- Fila de encabezado de columnas ----
            For j As Integer = 0 To dgvProductos.ColumnCount - 1
                Dim c As New PdfPCell(New Phrase(dgvProductos.Columns(j).HeaderText, fHeader))
                c.BackgroundColor = colorHeader
                c.HorizontalAlignment = Element.ALIGN_CENTER
                c.VerticalAlignment = Element.ALIGN_MIDDLE
                c.Padding = 6
                c.BorderColor = BaseColor.WHITE
                datatable.AddCell(c)
            Next
            datatable.HeaderRows = 1   ' se repite el encabezado en cada página
            ' ---- Filas de datos ----
            Dim sumas(dgvProductos.ColumnCount - 1) As Double
            For i As Integer = 0 To dgvProductos.RowCount - 2   ' -2: se saltea la fila nueva vacía del grid
                Dim fondo As BaseColor = If(i Mod 2 = 0, BaseColor.WHITE, colorZebra)

                For j As Integer = 0 To dgvProductos.ColumnCount - 1
                    Dim valor As Object = dgvProductos(j, i).Value

                    Dim c As New PdfPCell(New Phrase(FormatearValor(valor, esMoneda(j)), fCelda))
                    c.BackgroundColor = fondo
                    c.Padding = 5
                    c.HorizontalAlignment = AlinearPorTipo(valor)
                    c.VerticalAlignment = Element.ALIGN_MIDDLE
                    c.BorderColor = colorBorde
                    datatable.AddCell(c)
                    ' Acumular para el total
                    If esTotalizable(j) Then
                        Dim n As Double
                        If valor IsNot Nothing AndAlso Double.TryParse(valor.ToString(), n) Then
                            sumas(j) += n
                        End If
                    End If
                Next
            Next
            ' ---- Fila de TOTAL (una celda por columna, así siempre cuadra) ----
            Dim primeraTotal As Integer = Array.FindIndex(esTotalizable, Function(x) x)
            Dim idxEtiqueta As Integer = If(primeraTotal > 0, primeraTotal - 1, 0)

            For j As Integer = 0 To dgvProductos.ColumnCount - 1
                Dim txt As String = ""
                If esTotalizable(j) Then
                    txt = If(esMoneda(j), Format(sumas(j), "$ #,##0.00"), Format(sumas(j), "#,##0"))
                ElseIf j = idxEtiqueta Then
                    txt = "TOTAL"
                End If

                Dim c As New PdfPCell(New Phrase(txt, fTotal))
                c.BackgroundColor = colorTotalBg
                c.HorizontalAlignment = Element.ALIGN_RIGHT
                c.Padding = 6
                c.BorderColor = colorBorde
                datatable.AddCell(c)
            Next

            document.Add(datatable)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ExportarAExcel(dt As DataTable, rutaDestino As String)
        Dim excelApp As Excel.Application = Nothing
        Dim libro As Excel.Workbook = Nothing
        Dim hoja As Excel.Worksheet = Nothing

        Try
            excelApp = New Excel.Application()
            libro = excelApp.Workbooks.Add()
            hoja = CType(libro.Worksheets(1), Excel.Worksheet)

            ' Encabezados de columnas
            For col As Integer = 0 To dt.Columns.Count - 1
                hoja.Cells(1, col + 1) = dt.Columns(col).ColumnName
            Next

            ' Datos
            For fila As Integer = 0 To dt.Rows.Count - 1
                For col As Integer = 0 To dt.Columns.Count - 1
                    hoja.Cells(fila + 2, col + 1) = dt.Rows(fila)(col).ToString()
                Next
                Application.DoEvents()
            Next

            hoja.Columns.AutoFit()

            libro.SaveAs(rutaDestino)
            MessageBox.Show("Datos exportados correctamente a: " & rutaDestino,
                         "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error al exportar a Excel: " & ex.Message, "Error",
                         MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

            libro?.Close()
            excelApp?.Quit()

            If hoja IsNot Nothing Then ReleaseObject(hoja)
            If libro IsNot Nothing Then ReleaseObject(libro)
            If excelApp IsNot Nothing Then ReleaseObject(excelApp)
        End Try
    End Sub
    Public Function GetColumnasSize(ByVal dg As DataGridView) As Single()
        Dim values As Single() = New Single(dg.ColumnCount - 1) {}
        For i As Integer = 0 To dg.ColumnCount - 1
            values(i) = CSng(dg.Columns(i).Width)
        Next
        Return values
    End Function
    Private Sub ReleaseObject(obj As Object)
        Try
            Runtime.InteropServices.Marshal.ReleaseComObject(obj)
        Catch
        Finally
            obj = Nothing
        End Try
    End Sub
    Private Function AlinearPorTipo(ByVal valor As Object) As Integer
        If valor Is Nothing OrElse IsDBNull(valor) Then Return Element.ALIGN_LEFT
        If TypeOf valor Is DateTime Then Return Element.ALIGN_CENTER

        Dim n As Double
        If Double.TryParse(valor.ToString(), n) Then Return Element.ALIGN_RIGHT

        Return Element.ALIGN_LEFT
    End Function
    Private Function FormatearValor(ByVal valor As Object, ByVal esMoneda As Boolean) As String
        If valor Is Nothing OrElse IsDBNull(valor) Then Return ""

        If TypeOf valor Is DateTime Then
            Return CDate(valor).ToString("dd/MM/yyyy")
        End If

        Dim n As Double
        If Double.TryParse(valor.ToString(), n) Then
            If esMoneda Then Return Format(n, "$ #,##0.00")
        End If

        Return valor.ToString()
    End Function
End Class