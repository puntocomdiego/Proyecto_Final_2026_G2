Imports System.Data.OleDb
Imports System.Runtime

Public Class frmVenta

    Private Shared ReadOnly ruta As String =
IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Comercial.accdb")
    Private Shared ReadOnly cadenaConexion As String =
    $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={ruta};"

    Private datos As New VentaDatos()
    Private temporal As New TemporalDatos()

    Private Sub frmVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CargarClientes()
        CargarCategorias()
        ConfigurarGrilla()
        MostrarCompras(temporal.Listar())

    End Sub

    Private Sub CargarClientes()

        cboCliente.Items.Clear()

        Try
            Using cn As New OleDbConnection(cadenaConexion)
                cn.Open()

                Dim sql As String = "SELECT Clientes.IdCliente, Clientes.Apellido, Clientes.Nombre " _
                                  + "FROM Clientes ORDER By Clientes.Apellido DESC; "


                Dim da As New OleDb.OleDbDataAdapter(sql, cadenaConexion)
                Dim dt As New DataTable
                da.Fill(dt)


                cboCliente.Items.Clear()
                cboCliente.Items.Add("-- Seleccione un cliente --")


                For i = 0 To dt.Rows.Count - 1
                    Dim dr As DataRow
                    dr = dt.Rows(i)
                    cboCliente.Items.Add(dr(1) & ", " & dr(2))
                Next

                cboCliente.SelectedIndex = 0
            End Using


        Catch ex As Exception
            MessageBox.Show("Error al cargar clientes " & ex.Message, "Error",
                         MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub CargarCategorias()

        cboCategoria.Items.Clear()

        Try
            Using cn As New OleDbConnection(cadenaConexion)
                cn.Open()

                Dim sql As String = "SELECT IdCategoria ,Nombre FROM Categorias ; "

                Dim da As New OleDb.OleDbDataAdapter(sql, cadenaConexion)
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

            Using cn As New OleDbConnection(cadenaConexion)
                cn.Open()
                Dim sql As String = "SELECT IdProducto, Descripcion " _
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
                dt.Rows.InsertAt(fila, 0)

                cboDescripcion.DataSource = dt
                cboDescripcion.DisplayMember = "Descripcion"
                cboDescripcion.ValueMember = "IdProducto"
                cboDescripcion.SelectedIndex = 0

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
    End Sub

    Private Sub ConfigurarGrilla()
        dgvTemp.ReadOnly = True
        dgvTemp.AllowUserToAddRows = False
        dgvTemp.MultiSelect = False
        dgvTemp.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvTemp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    '===========================

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

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click

        Try
            Dim t As New Temporal(cboDescripcion.SelectedValue, cboDescripcion.Text, CDec(txtCantidad.Text), 0, 0)

            If temporal.Agregar(t) Then

                'Llamar otra funcion para extraer los datos del producto seleccionado y calcular el subtotal
                'Aca se puede agregar un mensaje de confirmacion de que se agrego correctamente el producto

                MostrarCompras(temporal.Listar())
            End If
        Catch ex As Exception
            MessageBox.Show("No se pudo agregar el producto: " & ex.Message)
        End Try

    End Sub
End Class