Imports System.Data.OleDb
Imports System.Reflection.Emit

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