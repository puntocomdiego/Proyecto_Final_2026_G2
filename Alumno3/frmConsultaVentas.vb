Imports System.Data.OleDb

Public Class frmConsultaVentas

    Private datos As New VentaDatos()
    Private detalle As New DetalleDatos()

    Private Sub frmConsultaVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AplicarEstiloFormulario(Me, "Consultar Ventas")
        AplicarEstiloGrilla(dgvConsulta)


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