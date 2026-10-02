Imports System.Data.OleDb

Public Class frmVenta

    Private Shared ReadOnly ruta As String =
IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Comercial.accdb")
    Private Shared ReadOnly cadenaConexion As String =
    $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={ruta};"

    Private datos As New VentaDatos()

    Private Sub frmVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CargarClientes()

    End Sub

    Private Sub CargarClientes()

        cboCliente.Items.Clear()

        Try
            Using cn As New OleDbConnection(cadenaConexion)
                cn.Open()

                Dim sql As String = "SELECT Clientes.Apellido, Clientes.Nombre " _
                                  + "FROM Clientes ORDER By Clientes.Apellido DESC; "


                Dim da As New OleDb.OleDbDataAdapter(sql, cadenaConexion)
                Dim dt As New DataTable
                da.Fill(dt)


                cboCliente.Items.Clear()
                cboCliente.Items.Add("-- Seleccione un cliente --")


                For i = 0 To dt.Rows.Count - 1
                    Dim dr As DataRow
                    dr = dt.Rows(i)
                    cboCliente.Items.Add(dr(0) & ", " & dr(1))
                Next

                cboCliente.SelectedIndex = 0
            End Using


        Catch ex As Exception
            MessageBox.Show("Error al cargar clientes " & ex.Message, "Error",
                         MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cboCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCliente.SelectedIndexChanged

        If cboCliente.SelectedIndex = 0 Then

            Label2.Visible = False
            Label3.Visible = False
            Label4.Visible = False

            cboCategoria.Visible = False
            cboProducto.Visible = False
            txtCantidad.Visible = False

        Else

            Label2.Visible = True
            Label3.Visible = True
            Label4.Visible = True

            cboCategoria.Visible = True
            cboProducto.Visible = True
            txtCantidad.Visible = True

        End If

    End Sub
End Class