Public Class frmCategorias
    Private idCategoriaSeleccionada As Integer = -1
    Private datos As New Cls_CategoriasDatos()
    Dim bcerrar As Boolean = False

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
        txtID.Clear()
        txtNombre.Clear()
        txtNombre.Enabled = False
        btnModificar.Enabled = False
        btnAgregar.Enabled = False
        btnEliminar.Enabled = False
        dgvCategorias.ClearSelection()
        idCategoriaSeleccionada = -1
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If Not DatosValidos() Then Exit Sub
        Try
            Dim existe As Boolean = False
            For Each row As DataGridViewRow In dgvCategorias.Rows
                If row.Cells("Nombre").Value IsNot Nothing AndAlso
                   row.Cells("Nombre").Value.ToString().Trim().ToLower() = txtNombre.Text.Trim().ToLower() Then
                    existe = True
                    Exit For
                End If
            Next

            If existe Then
                MessageBox.Show("La categoría ya existe en el sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtNombre.Focus()
                txtNombre.SelectAll()
            Else
                Dim c As New Cls_Categorias(txtNombre.Text.Trim())

                If datos.Agregar(c) Then
                    MostrarCategorias(datos.Listar())
                    Limpiar()
                    MessageBox.Show("Categoría agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
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
            txtNombre.Enabled = True
            btnModificar.Enabled = True
            btnEliminar.Enabled = True
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
        Dim respuesta As DialogResult = MessageBox.Show("¿Desea salir del Programa?", "Confirmar",
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        bcerrar = True
        If respuesta = DialogResult.Yes Then
            bcerrar = True
            Me.Close()
            MsgBox("Gracias por utilizar el programa!", MsgBoxStyle.Information, "Fin del programa")
        Else
            bcerrar = False
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Limpiar()
        txtNombre.Enabled = True
        txtNombre.Focus()
        MsgBox("Ingrese el nombre de la categoría nueva y luego presione el botón 'Agregar'.", MsgBoxStyle.Information, "Nueva Categoría")
        btnAgregar.Enabled = True
    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        If Chr(13) = e.KeyChar Then
            btnAgregar.PerformClick()
        End If
    End Sub

    Private Sub frmCategorias_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If bcerrar = False Then
            Dim respuesta As DialogResult = MessageBox.Show("¿Desea salir del Programa?", "Confirmar",
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If respuesta = DialogResult.No Then
                e.Cancel = True
            Else
                MsgBox("Gracias por utilizar el programa!", MsgBoxStyle.Information, "Fin del programa")
            End If
        End If
    End Sub

    Private Sub txtNombre_GotFocus(sender As Object, e As EventArgs) Handles txtNombre.GotFocus
        txtNombre.BackColor = Color.LightGreen
    End Sub

    Private Sub txtNombre_LostFocus(sender As Object, e As EventArgs) Handles txtNombre.LostFocus
        txtNombre.BackColor = Color.White
    End Sub
    Private Sub dgvCategorias_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvCategorias.MouseDown
        Dim hitTest As DataGridView.HitTestInfo = dgvCategorias.HitTest(e.X, e.Y)
        If hitTest.Type = DataGridViewHitTestType.None Then
            dgvCategorias.ClearSelection()
            idCategoriaSeleccionada = -1
            Limpiar()
        End If
    End Sub
End Class