Public Class frmProductos
    Private idProductoSeleccionado As Integer = -1
    Private datos As New Cls_ProductoDatos()
    Private ruta As String = String.Empty

    Private Sub frmProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'CargarCategorias()
        ConfigurarGrilla()
        MostrarProductos(datos.Listar())
    End Sub
    'Private Sub CargarCategorias()
    '    Try
    '        Dim consulta As String = "SELECT IdCategoria, Nombre FROM Categorias"
    '        Dim dt As DataTable = datos.Consulta

    '        cmbCategorias.DataSource = dt
    '        cmbCategorias.DisplayMember = "Nombre"
    '        cmbCategorias.ValueMember = "IdCategoria"
    '        cmbCategorias.SelectedIndex = -1
    '    Catch ex As Exception
    '        MessageBox.Show("Error al cargar las categorías: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
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

        dgvProductos.Columns("codigo").HeaderText = "Código"
        dgvProductos.Columns("descripcion").HeaderText = "Descripción"
        dgvProductos.Columns("stockminimo").HeaderText = "Stock Mínimo"
        dgvProductos.Columns("precio").HeaderText = "Precio"
        dgvProductos.Columns("stock").HeaderText = "Stock Disponible"
        dgvProductos.Columns("precio").DefaultCellStyle.Format = "C2"
        dgvProductos.Columns("precio").DefaultCellStyle.FormatProvider =
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
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If Not DatosValidos() Then Exit Sub
        Try
            Dim p As New Cls_Producto(txtDescripcion.Text.Trim(),
                                  Decimal.Parse(txtPrecio.Text), ruta)
            If datos.Agregar(p) Then          ' el objeto datos hace el trabajo 
                MostrarProductos(datos.Listar())
                Limpiar()
            End If
        Catch ex As Exception
            MessageBox.Show("No se pudo agregar el producto: " & ex.Message)
        End Try
    End Sub

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
        MostrarProductos(datos.Buscar(txtBuscar.Text.Trim()))
    End Sub
    Private Function DatosValidos() As Boolean
        If txtDescripcion.Text.Trim() = "" Then
            MessageBox.Show("Ingresá la descripción.")
            Return False
        End If
        Dim p As Decimal
        If Not Decimal.TryParse(txtPrecio.Text, p) Then
            MessageBox.Show("El precio debe ser un número válido.")
            Return False
        End If
        Return True
    End Function

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If txtCodigo.Text = "" Then Exit Sub
        If Not DatosValidos() Then Exit Sub
        Try
            Dim p As New Cls_Producto(txtDescripcion.Text.Trim(),
                                  Decimal.Parse(txtPrecio.Text), ruta)
            p.Codigo = Integer.Parse(txtCodigo.Text)
            If datos.Modificar(p) Then MostrarProductos(datos.Listar())
        Catch ex As Exception
            MessageBox.Show("No se pudo modificar el producto: " & ex.Message)
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If txtCodigo.Text = "" Then Exit Sub
        If MessageBox.Show("¿Eliminar el producto seleccionado?", "Confirmar",
                           MessageBoxButtons.YesNo) = DialogResult.No Then Exit Sub
        Try
            If datos.Eliminar(Integer.Parse(txtCodigo.Text)) Then
                MostrarProductos(datos.Listar())
                Limpiar()
            End If
        Catch ex As Exception
            MessageBox.Show("No se pudo eliminar el producto: " & ex.Message)
        End Try
    End Sub

    Private Sub dgvProductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellContentClick

    End Sub
End Class