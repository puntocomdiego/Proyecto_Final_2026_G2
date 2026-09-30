Public Class frmProductos
    Private idProductoSeleccionado As Integer = -1

    Private Sub frmProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarCategorias()
        CargarGrillaProductos()
    End Sub

    Private Sub CargarCategorias()
        Try
            Dim consulta As String = "SELECT IdCategoria, Nombre FROM Categorias"
            Dim dt As DataTable = Conexion.Consultar(consulta)

            cmbCategorias.DataSource = dt
            cmbCategorias.DisplayMember = "Nombre"
            cmbCategorias.ValueMember = "IdCategoria"
            cmbCategorias.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show("Error al cargar las categorías: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' 2. Cargar los productos en el DataGridView
    Private Sub CargarGrillaProductos()
        Try
            Dim consulta As String = "SELECT IdProducto, Codigo, Descripcion, Precio, Stock, StockMinimo, IdCategoria, Activo FROM Productos WHERE Activo = True"
            dgvProductos.DataSource = Conexion.Consultar(consulta)

            ' Aplicar alerta visual si hay stock bajo
            VerificarStockMinimo()
        Catch ex As Exception
            MessageBox.Show("Error al cargar los productos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' 3. Alerta de Stock Mínimo (Requisito del Alumno A)
    Private Sub VerificarStockMinimo()
        For Each row As DataGridViewRow In dgvProductos.Rows
            If Not row.IsNewRow Then
                Dim stock As Integer = Convert.ToInt32(row.Cells("Stock").Value)
                Dim stockMin As Integer = Convert.ToInt32(row.Cells("StockMinimo").Value)

                If stock <= stockMin Then
                    row.DefaultCellStyle.BackColor = Color.LightCoral ' Pinta de rojo claro si está en riesgo
                End If
            End If
        Next
    End Sub

    ' 4. Botón Agregar / Guardar (Alta)
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If txtCodigo.Text = "" Or txtDescripcion.Text = "" Or txtPrecio.Text = "" Or txtStock.Text = "" Then
            MessageBox.Show("Por favor complete los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim precioStr As String = txtPrecio.Text.Replace(",", ".") ' Asegurar formato decimal para Access
            Dim sql As String = $"INSERT INTO Productos (Codigo, Descripcion, Precio, Stock, StockMinimo, IdCategoria, Activo) " &
                                $"VALUES ('{txtCodigo.Text}', '{txtDescripcion.Text}', {precioStr}, {txtStock.Text}, {txtStockminimo.Text}, {cmbCategorias.SelectedValue}, True)"

            Conexion.Ejecutar(sql)
            MessageBox.Show("Producto agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

            CargarGrillaProductos()
            LimpiarCampos()
        Catch ex As Exception
            MessageBox.Show("Error al guardar el producto: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' 5. Seleccionar un producto de la grilla para pasarlo a los controles
    Private Sub dgvProductos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvProductos.Rows(e.RowIndex)

            idProductoSeleccionado = Convert.ToInt32(row.Cells("IdProducto").Value)
            txtCodigo.Text = row.Cells("Codigo").Value.ToString()
            txtDescripcion.Text = row.Cells("Descripcion").Value.ToString()
            txtPrecio.Text = row.Cells("Precio").Value.ToString()
            txtStock.Text = row.Cells("Stock").Value.ToString()
            txtStockminimo.Text = row.Cells("StockMinimo").Value.ToString()
            cmbCategorias.SelectedValue = row.Cells("IdCategoria").Value
        End If
    End Sub

    ' 6. Botón Modificar
    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If idProductoSeleccionado = -1 Then
            MessageBox.Show("Seleccione un producto de la grilla para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim precioStr As String = txtPrecio.Text.Replace(",", ".")
            Dim sql As String = $"UPDATE Productos SET Codigo = '{txtCodigo.Text}', " &
                                $"Descripcion = '{txtDescripcion.Text}', " &
                                $"Precio = {precioStr}, " &
                                $"Stock = {txtStock.Text}, " &
                                $"StockMinimo = {txtStockminimo.Text}, " &
                                $"IdCategoria = {cmbCategorias.SelectedValue} " &
                                $"WHERE IdProducto = {idProductoSeleccionado}"

            Conexion.Ejecutar(sql)
            MessageBox.Show("Producto modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

            CargarGrillaProductos()
            LimpiarCampos()
        Catch ex As Exception
            MessageBox.Show("Error al modificar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' 7. Botón Eliminar (Baja lógica)
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If idProductoSeleccionado = -1 Then
            MessageBox.Show("Seleccione un producto para dar de baja.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If MessageBox.Show("¿Está seguro de dar de baja este producto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                ' Baja lógica cambiando Activo a False
                Dim sql As String = $"UPDATE Productos SET Activo = False WHERE IdProducto = {idProductoSeleccionado}"
                Conexion.Ejecutar(sql)

                MessageBox.Show("Producto dado de baja.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CargarGrillaProductos()
                LimpiarCampos()
            Catch ex As Exception
                MessageBox.Show("Error al eliminar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' 8. Botón Limpiar
    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        LimpiarCampos()
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
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        txtBuscar.Visible = True
        btnBuscar.Visible = False

    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged

        Try
            Dim textoFiltro As String = txtBuscar.Text.Trim()

            Dim consulta As String = "SELECT IdProducto, Codigo, Descripcion, Precio, Stock, StockMinimo, IdCategoria, Activo " &
                                 "FROM Productos " &
                                 "WHERE Activo = True AND (Descripcion LIKE '%" & textoFiltro & "%' OR Codigo LIKE '%" & textoFiltro & "%')"

            Dim dt As DataTable = Conexion.Consultar(consulta)
            dgvProductos.DataSource = dt

            VerificarStockMinimo()

        Catch ex As Exception
            MessageBox.Show("Error al filtrar los productos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class