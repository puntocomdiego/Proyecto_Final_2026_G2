Public Class frmCategorias
    Private idCategoriaSeleccionada As Integer = -1
    Private datos As New Cls_CategoriasDatos()

    Private Sub frmCategorias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarGrilla()
        MostrarCategorias(datos.Listar())
        BotonPrimario(Me.btnAgregar)
        BotonSecundario(Me.btnModificar)
        BotonSecundario(Me.btnLimpiar)
        BotonSecundario(Me.btnNuevo)
        BotonPeligro(Me.btnEliminar)
        BotonSecundario(Me.btnfin)
        AplicarEstiloGrilla(dgvCategorias)
        AplicarEstiloFormulario(Me, "Gestión de Categorías")
    End Sub

    Private Sub ConfigurarGrilla()
        dgvCategorias.AutoGenerateColumns = True
        dgvCategorias.ReadOnly = True
        dgvCategorias.AllowUserToAddRows = False
        dgvCategorias.MultiSelect = False
        dgvCategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub MostrarCategorias(dt As DataTable)
        dgvCategorias.DataSource = dt

        If dt.Rows.Count = 0 Then Exit Sub

        If dgvCategorias.Columns.Contains("IdCategoria") Then
            dgvCategorias.Columns("IdCategoria").HeaderText = "ID Categoría"
        End If
        If dgvCategorias.Columns.Contains("Nombre") Then
            dgvCategorias.Columns("Nombre").HeaderText = "Nombre de Categoría"
        End If
    End Sub

    Private Sub Limpiar()
        txtNombre.Clear()
        txtNombre.Focus()
        dgvCategorias.ClearSelection()
        idCategoriaSeleccionada = -1
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If Not DatosValidos() Then Exit Sub
        Try
            Dim c As New Cls_Categorias(txtNombre.Text.Trim())
            If datos.Agregar(c) Then
                MostrarCategorias(datos.Listar())
                Limpiar()
                MessageBox.Show("Categoría agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("No se pudo agregar la categoría: " & ex.Message)
        End Try
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Limpiar()
        MsgBox("Se han limpiado los campos del formulario.", MsgBoxStyle.Information, "Campos Limpiados")
    End Sub

    Private Function DatosValidos() As Boolean
        If txtNombre.Text.Trim() = "" Then
            MessageBox.Show("Ingresá el nombre de la categoría.")
            Return False
        End If
        Return True
    End Function

    Private Sub dgvCategorias_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCategorias.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvCategorias.Rows(e.RowIndex)
            idCategoriaSeleccionada = Convert.ToInt32(row.Cells("IdCategoria").Value)
            txtNombre.Text = row.Cells("Nombre").Value.ToString()
            txtID.Text = idCategoriaSeleccionada.ToString()
        End If
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If idCategoriaSeleccionada = -1 Then
            MessageBox.Show("Seleccione una categoría de la grilla.")
            Return
        End If
        If Not DatosValidos() Then Exit Sub
        Try
            Dim c As New Cls_Categorias()
            c.IdCategoria = idCategoriaSeleccionada
            c.Nombre = txtNombre.Text.Trim()

            If datos.Modificar(c) Then
                MostrarCategorias(datos.Listar())
                Limpiar()
                MessageBox.Show("Categoría modificada correctamente.", "Modificación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("No se pudo modificar la categoría: " & ex.Message)
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If idCategoriaSeleccionada = -1 Then
            MessageBox.Show("Seleccione una categoría de la grilla.")
            Return
        End If
        If MessageBox.Show("¿Eliminar la categoría seleccionada?", "Confirmar",
                           MessageBoxButtons.YesNo) = DialogResult.No Then Exit Sub
        Try
            If datos.Eliminar(idCategoriaSeleccionada) Then
                MostrarCategorias(datos.Listar())
                Limpiar()
            End If
        Catch ex As Exception
            MessageBox.Show("No se pudo eliminar la categoría (puede tener productos asociados): " & ex.Message)
        End Try
    End Sub

    Private Sub btnfin_Click(sender As Object, e As EventArgs) Handles btnfin.Click
        MessageBox.Show("Gracias por usar el Programa.", "Cerrado", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Limpiar()
        txtNombre.Focus()
        MsgBox("Ingrese el nombre de la categoría nueva y luego presione el botón 'Agregar'.", MsgBoxStyle.Information, "Nueva Categoría")
        btnAgregar.Enabled = True
    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        If Chr(13) = e.KeyChar Then
            btnAgregar.PerformClick()
        End If
    End Sub
End Class