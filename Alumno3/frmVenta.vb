Imports System.Data.OleDb
Imports System.Runtime
Imports System.Runtime.InteropServices.JavaScript.JSType

Public Class frmVenta

    Private datos As New VentaDatos()
    Private temporal As New TemporalDatos()
    Private detalle As New DetalleDatos()

    Private Sub frmVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CargarClientes()
        CargarCategorias()
        ConfigurarGrilla()
        MostrarCompras(temporal.Listar())

    End Sub

    '== FUNCIONES ==

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

    Private Sub CargarCategorias()

        Try
            Using cn As New OleDbConnection(CadenaConexion)
                cn.Open()

                Dim sql As String = "SELECT IdCategoria ,Nombre FROM Categorias ; "

                Dim da As New OleDb.OleDbDataAdapter(sql, CadenaConexion)
                Dim dt As New DataTable
                da.Fill(dt)

                cboCategoria.Items.Clear()

                Dim fila As DataRow = dt.NewRow()
                fila("IdCategoria") = 0
                fila("Nombre") = "-- Seleccione una categoria --"
                dt.Rows.InsertAt(fila, 0)

                ' Vincular los datos al ComboBox

                cboCategoria.DataSource = dt
                cboCategoria.DisplayMember = "Nombre"
                cboCategoria.ValueMember = "IdCategoria"

                cboCategoria.SelectedIndex = 0

                If cboCategoria.SelectedIndex <= 0 Then
                    Return
                End If

                Dim idCategoria As Integer = Convert.ToInt32(cboCategoria.SelectedValue)

            End Using


        Catch ex As Exception
            MessageBox.Show("Error al cargar categorias " & ex.Message, "Error",
                         MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub CargarProductos()
        Try

            If cboCategoria.SelectedIndex <= 0 Then
                cboDescripcion.DataSource = Nothing
                cboDescripcion.Items.Clear()
                Return

            End If

            Dim idCategoria As Integer = Convert.ToInt32(cboCategoria.SelectedValue)

            Using cn As New OleDbConnection(CadenaConexion)
                cn.Open()
                Dim sql As String = "SELECT IdProducto, Descripcion, Precio " _
                                  + "FROM Productos " _
                                  + "WHERE IdCategoria = ? " _
                                  + "ORDER By Descripcion DESC;"

                Dim da As New OleDb.OleDbDataAdapter(sql, cn)
                da.SelectCommand.Parameters.AddWithValue("?", idCategoria)
                Dim dt As New DataTable
                da.Fill(dt)

                Dim fila As DataRow = dt.NewRow()
                fila("IdProducto") = 0
                fila("Descripcion") = "-- Seleccione un producto --"
                fila("Precio") = 0D
                dt.Rows.InsertAt(fila, 0)

                cboDescripcion.DataSource = dt
                cboDescripcion.DisplayMember = "Descripcion"
                cboDescripcion.ValueMember = "IdProducto"
                cboDescripcion.SelectedValue = 0

                cboDescripcion.SelectedIndex = 0
            End Using

        Catch ex As Exception
            MessageBox.Show("Error al cargar productos " & ex.Message, "Error",
                         MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub MostrarCompras(dt As DataTable)
        dgvTemp.DataSource = dt
        dgvTemp.Columns("IdProducto").HeaderText = "ID"
        dgvTemp.Columns("IdProducto").Visible = False

        dgvTemp.Columns("Descripcion").HeaderText = "Producto"
        dgvTemp.Columns("Cantidad").HeaderText = "Cantidad"

        dgvTemp.Columns("PrecioUnita").HeaderText = "Precio Unitario"
        dgvTemp.Columns("PrecioUnita").DefaultCellStyle.Format = "C2"
        dgvTemp.Columns("PrecioUnita").DefaultCellStyle.FormatProvider =
        Globalization.CultureInfo.GetCultureInfo("es-UY")

        dgvTemp.Columns("Subtotal").HeaderText = "Subtotal"
        dgvTemp.Columns("Subtotal").DefaultCellStyle.Format = "C2"
        dgvTemp.Columns("Subtotal").DefaultCellStyle.FormatProvider =
        Globalization.CultureInfo.GetCultureInfo("es-UY")

        ActualizarBotones()
        MetodoPagoVisible()
    End Sub

    Private Sub ConfigurarGrilla()
        dgvTemp.BackgroundColor = Color.White
        dgvTemp.BorderStyle = BorderStyle.None
        dgvTemp.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvTemp.GridColor = Color.FromArgb(208, 213, 221)
        dgvTemp.RowHeadersVisible = False
        dgvTemp.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvTemp.MultiSelect = False
        dgvTemp.ReadOnly = True
        dgvTemp.AllowUserToAddRows = False
        dgvTemp.AllowUserToDeleteRows = False
        dgvTemp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvTemp.EnableHeadersVisualStyles = False

        dgvTemp.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 37, 41)
        dgvTemp.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvTemp.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI semibold", 10, FontStyle.Bold, GraphicsUnit.Point, 36)

        dgvTemp.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(244, 246, 248)
        dgvTemp.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 157, 255)
        dgvTemp.DefaultCellStyle.SelectionForeColor = Color.Black
        dgvTemp.RowTemplate.Height = 32

    End Sub

    Private Function CalcularTotalVenta() As Decimal

        Dim total As Decimal = 0D

        For Each r As DataGridViewRow In dgvTemp.Rows

            If Not r.IsNewRow Then
                total += CDec(r.Cells("Subtotal").Value)
            End If

        Next

        lblTotal.Text = total.ToString("C2", Globalization.CultureInfo.GetCultureInfo("es-UY"))

        Return total

    End Function

    Private Sub ActualizarBotones()

        Dim hayProductos As Boolean = dgvTemp.Rows.Count > 0
        Dim Seleccion As Boolean = dgvTemp.SelectedRows.Count > 0

        btnEditar.Enabled = hayProductos AndAlso Seleccion
        btnEliminar.Enabled = hayProductos AndAlso Seleccion

    End Sub

    Private Sub ActualizarBotonVenta()

        btnConfirmar.Enabled =
        rbtDebito.Checked OrElse
        rbtTransf.Checked OrElse
        rbtCredito.Checked OrElse
        rbtEfectivo.Checked

    End Sub

    Private Sub MetodoPago_CheckedChanged(sender As Object, e As EventArgs) Handles rbtDebito.CheckedChanged, rbtTransf.CheckedChanged, rbtCredito.CheckedChanged, rbtEfectivo.CheckedChanged

        ActualizarBotonVenta()

    End Sub

    Private Sub MetodoPagoVisible()

        Dim hayProductos As Boolean = dgvTemp.Rows.Count > 0

        rbtCredito.Enabled = hayProductos
        rbtTransf.Enabled = hayProductos
        rbtEfectivo.Enabled = hayProductos
        rbtDebito.Enabled = hayProductos

    End Sub

    Private Sub LimpiarMetodoPago()
        rbtDebito.Checked = False
        rbtTransf.Checked = False
        rbtCredito.Checked = False
        rbtEfectivo.Checked = False
    End Sub

    Private Function MetodoPago() As String

        If rbtDebito.Checked Then
            Return "Débito"

        ElseIf rbtTransf.Checked Then
            Return "Transferencia"

        ElseIf rbtCredito.Checked Then
            Return "Crédito"

        ElseIf rbtEfectivo.Checked Then
            Return "Efectivo"

        Else
            MessageBox.Show("Seleccione un método de pago.")
            Return ""
        End If

    End Function

    Private Sub RestarStock(idProducto As Integer, cantidad As Integer)
        Try
            Using cn As New OleDbConnection(CadenaConexion)
                cn.Open()
                Dim sql As String = "UPDATE Productos SET Stock = Stock - ? WHERE IdProducto = ? "
                Using cmd As New OleDbCommand(sql, cn)
                    cmd.Parameters.AddWithValue("?", cantidad)
                    cmd.Parameters.AddWithValue("?", idProducto)
                    cmd.ExecuteNonQuery()

                End Using

            End Using

        Catch ex As Exception
            MessageBox.Show("Error al restar stock: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '== CONTROLES ==

    Private Sub cboCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCliente.SelectedIndexChanged

        If cboCliente.SelectedIndex = 0 Then

            cboCategoria.Enabled = False
            cboDescripcion.Enabled = False
            txtCantidad.Enabled = False

        Else

            cboCategoria.Enabled = True
            cboDescripcion.Enabled = True
            txtCantidad.Enabled = True

        End If

    End Sub

    Private Sub cboCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCategoria.SelectedIndexChanged

        CargarProductos()

        If cboCategoria.SelectedIndex = 0 Then

            cboDescripcion.Enabled = False
            txtCantidad.Enabled = False

        Else

            cboDescripcion.Enabled = True
            txtCantidad.Enabled = True

        End If



    End Sub

    Private Sub txtCantidad_TextChanged(sender As Object, e As EventArgs) Handles txtCantidad.TextChanged

        If txtCantidad.Text = "" Then
            btnAgregar.Enabled = False
        Else
            btnAgregar.Enabled = True
        End If

    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress

        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub

    Private Sub dgvTemp_SelectionChanged(sender As Object, e As EventArgs) Handles dgvTemp.SelectionChanged

        ActualizarBotones()
        MetodoPagoVisible()

    End Sub

    '== AGREGAR Y CONFIRMAR VENTA ==

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click

        Try
            If cboDescripcion.SelectedIndex = 0 Then
                MessageBox.Show("Seleccione un producto.") : Return
            End If

            Dim cantidad As Integer
            If Not Integer.TryParse(txtCantidad.Text, cantidad) OrElse cantidad <= 0 Then
                MessageBox.Show("Ingrese una cantidad válida.") : txtCantidad.Focus() : Return
            End If

            Dim fila As DataRowView = DirectCast(cboDescripcion.SelectedItem, DataRowView)
            Dim id As Integer = CInt(fila("IdProducto"))
            Dim nombre As String = fila("Descripcion").ToString()
            Dim cantidadIngresada As Integer = CInt(txtCantidad.Text)
            Dim precio As Decimal = CDec(fila("Precio"))


            Dim t As New Temporal(id, nombre, cantidadIngresada, precio, cantidadIngresada * precio)

            For Each r As DataGridViewRow In dgvTemp.Rows

                If CInt(r.Cells("IdProducto").Value) = id Then

                    MessageBox.Show("El producto ya está en la lista.")

                    Exit Sub

                End If

            Next

            If temporal.Agregar(t) Then

                MostrarCompras(temporal.Listar())
                CalcularTotalVenta()

                If cboCliente.Enabled Then

                    cboCliente.Enabled = False

                End If

                cboDescripcion.SelectedIndex = 0
                cboCategoria.Focus()
                txtCantidad.Text = ""

            End If

        Catch ex As Exception
            MessageBox.Show("No se pudo agregar el producto: " & ex.Message)
        End Try

    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click

        Try

            If dgvTemp.Rows.Count = 0 Then

                MessageBox.Show("No hay productos para confirmar la venta.")

                Return
            End If

            If cboCliente.SelectedValue Is Nothing OrElse cboCliente.SelectedIndex <= 0 OrElse Convert.ToInt32(cboCliente.SelectedValue) = 0 Then

                MessageBox.Show("Seleccione un cliente.")

                Return
            End If
            Dim idCliente As Integer = Convert.ToInt32(cboCliente.SelectedValue)

            'Obtener el método de pago seleccionado
            Dim formaPago As String = MetodoPago()
            If formaPago = "" Then Return

            'Calcular el total de la venta
            Dim totalVenta As Decimal = CalcularTotalVenta()
            If totalVenta <= 0 Then
                MessageBox.Show("El total de la venta debe ser mayor a cero.")
                Return
            End If

            'Mostrar un mensaje de confirmación con el total y el método de pago
            Dim respuesta As DialogResult = MessageBox.Show(
            "¿Desea confirmar esta venta?" & vbCrLf &
            "Total: " & totalVenta.ToString("C2", Globalization.CultureInfo.GetCultureInfo("es-UY")) & vbCrLf &
            "Método de pago: " & formaPago,
            "Confirmar venta",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)

            If respuesta <> DialogResult.Yes Then Return


            ' Crear la venta y los detalles de la venta en la base de datos

            Using cn As New OleDbConnection(CadenaConexion)
                cn.Open()
                Using trans As OleDbTransaction = cn.BeginTransaction()
                    Try
                        Dim venta As New Venta(DateTime.Now, idCliente, totalVenta, formaPago)
                        Dim idVenta As Integer = datos.Agregar(venta, cn, trans)
                        For Each r As DataGridViewRow In dgvTemp.Rows
                            If Not r.IsNewRow Then
                                Dim detalleVenta As New Detalle(
                                    idVenta,
                                    CInt(r.Cells("IdProducto").Value),
                                    CInt(r.Cells("Cantidad").Value),
                                    CDec(r.Cells("PrecioUnita").Value),
                                    CDec(r.Cells("Subtotal").Value))
                                detalle.Agregar(detalleVenta, cn, trans)

                                ' Restar el stock del producto
                                RestarStock(detalleVenta.IdProducto, detalleVenta.Cantidad)

                            End If
                        Next
                        trans.Commit()
                        MessageBox.Show("Venta confirmada con éxito.")


                        btnNuevo.PerformClick()


                    Catch ex As Exception
                        trans.Rollback()
                        MessageBox.Show("Error al confirmar la venta: " & ex.Message)
                    End Try
                End Using
            End Using

        Catch ex As Exception

            MsgBox("Error al confirmar la venta: " & ex.Message, MsgBoxStyle.Critical, "Error")

        End Try

    End Sub

    '== EDITORES DE DATOS ==

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        Dim idProducto As Integer = CInt(dgvTemp.SelectedRows(0).Cells("IdProducto").Value)

        If temporal.Eliminar(idProducto) Then

            MostrarCompras(temporal.Listar())

            CalcularTotalVenta()

        End If

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click

        cboCliente.SelectedIndex = 0
        cboCliente.Enabled = True
        cboCategoria.SelectedIndex = 0
        txtCantidad.Text = ""

        LimpiarMetodoPago()
        lblTotal.Text = "$0,00"

        CargarClientes()
        CargarCategorias()
        temporal.Limpiar()
        MostrarCompras(temporal.Listar())


    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click

        Try

            If dgvTemp.SelectedRows.Count = 0 Then

                MessageBox.Show("Seleccione un producto para editar.")

                Return
            End If

            Dim filaSeleccionada As DataGridViewRow = dgvTemp.SelectedRows(0)
            Dim id As Integer = CInt(filaSeleccionada.Cells("IdProducto").Value)
            Dim nombre As String = filaSeleccionada.Cells("Descripcion").Value.ToString()
            Dim cantidadActual As Integer = CInt(filaSeleccionada.Cells("Cantidad").Value)
            Dim precio As Decimal = CDec(filaSeleccionada.Cells("PrecioUnita").Value)


            Dim Mensaje As String = "           Producto: " & nombre & vbCrLf &
                                    "           Precio unitario: " & precio.ToString("C2") & vbCrLf &
                                    "           Cantidad actual: " & cantidadActual.ToString() & vbCrLf &
                                    "           Ingrese la nueva cantidad:"

            Dim nuevoValor As String = InputBox(Mensaje, "Editar cantidad de producto",
                                                 cantidadActual.ToString())

            If String.IsNullOrWhiteSpace(nuevoValor) Then Return

            Dim nuevaCantidad As Integer

            If Not Integer.TryParse(nuevoValor, nuevaCantidad) OrElse nuevaCantidad <= 0 Then
                MessageBox.Show("Ingrese una cantidad válida.") : Return
            End If


            Dim t As New Temporal(id, nombre, nuevaCantidad, precio, nuevaCantidad * precio)

            If temporal.Editar(t) Then

                MostrarCompras(temporal.Listar())
                CalcularTotalVenta()

            Else
                MessageBox.Show("No se pudo encontrar el producto.")

            End If

        Catch ex As Exception

            MsgBox("Error al editar el producto: " & ex.Message, MsgBoxStyle.Critical, "Error")

        End Try

    End Sub

    '== BOTON CERRAR ==

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click

        Try

            Dim respuesta As DialogResult

            respuesta = MessageBox.Show("¿Estás seguro que deseas salir?", "Confirmar cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If respuesta = DialogResult.Yes Then
                Me.Close()

            End If

        Catch ex As Exception

            MsgBox("Error al cerrar la venta: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

End Class