Public Class frmProductos
    Private idProductoSeleccionado As Integer = -1
    Private datos As New Cls_ProductoDatos()
    Private ruta As String = String.Empty

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
End Class