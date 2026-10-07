Imports System.Text.RegularExpressions

Public Class frmClientes
    ' Un solo objeto de acceso a datos para todo el formulario
    Private datos As New Cliente_datos()
    ' Variable CLAVE para recordar a quién modificar/eliminar
    Private idClienteSeleccionado As Integer = 0


    Private Sub ConfigurarGrilla()
        dgvClientes.ReadOnly = True
        dgvClientes.AllowUserToAddRows = False
        dgvClientes.MultiSelect = False
        dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub MostrarClientes(dt As DataTable)
        dgvClientes.DataSource = dt

        If dt.Rows.Count = 0 Then Exit Sub

        ' Ocultamos el ID porque es un dato interno
        If dgvClientes.Columns.Contains("IdCliente") Then
            dgvClientes.Columns("IdCliente").Visible = False
        End If

        dgvClientes.Columns("Documento").HeaderText = "Documento"
        dgvClientes.Columns("Nombre").HeaderText = "Nombre"
        dgvClientes.Columns("Apellido").HeaderText = "Apellido"
        dgvClientes.Columns("Telefono").HeaderText = "Teléfono"
        dgvClientes.Columns("Email").HeaderText = "E-mail"
        dgvClientes.Columns("Direccion").HeaderText = "Dirección"
        dgvClientes.Columns("Activo").HeaderText = "Activo"

        ' --- LA SOLUCIÓN DEFINITIVA ---
        ' Obligamos a la grilla a soltar cualquier celda y fila seleccionada
        dgvClientes.CurrentCell = Nothing
    End Sub

    ' ===== MÉTODO PARA LIMPIAR LAS CAJAS =====
    Private Sub Limpiar()
        txtDocumento.Clear()
        txtNombre.Clear()
        txtApellido.Clear()
        txtTelefono.Clear()
        txtEmail.Clear()
        txtDireccion.Clear()
        idClienteSeleccionado = 0 ' Olvidamos el ID al limpiar
        txtDocumento.Focus()
    End Sub

    ' ===== CARGA DE LA PANTALLA =====
    Private Sub frmClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Habilitar las codificaciones clásicas de Windows (Encoding 1252)
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance)

        ConfigurarGrilla()
        MostrarClientes(datos.Listar())

        ' Forzamos a que arranque todo vacío y sin seleccionar al abrir la pantalla
        Limpiar()
    End Sub

    ' ===== EVENTO AL SELECCIONAR UNA FILA DE LA GRILLA =====
    Private Sub dgvClientes_SelectionChanged(sender As Object, e As EventArgs) Handles dgvClientes.SelectionChanged
        If dgvClientes.CurrentRow Is Nothing Then Exit Sub

        Try
            ' Atrapamos el ID oculto.
            idClienteSeleccionado = Convert.ToInt32(dgvClientes.CurrentRow.Cells("IdCliente").Value)

            ' Pasamos los datos a las cajas de texto
            txtDocumento.Text = dgvClientes.CurrentRow.Cells("Documento").Value.ToString()
            txtNombre.Text = dgvClientes.CurrentRow.Cells("Nombre").Value.ToString()
            txtApellido.Text = dgvClientes.CurrentRow.Cells("Apellido").Value.ToString()
            txtTelefono.Text = dgvClientes.CurrentRow.Cells("Telefono").Value.ToString()
            txtEmail.Text = dgvClientes.CurrentRow.Cells("Email").Value.ToString()
            txtDireccion.Text = dgvClientes.CurrentRow.Cells("Direccion").Value.ToString()

        Catch ex As Exception
            ' ¡Quitamos el silenciador para descubrir el problema real!
            MessageBox.Show("Error al leer los datos de la fila: " & ex.Message, "Modo Diagnóstico", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ===== BOTÓN AGREGAR =====
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If Not DatosValidos() Then Exit Sub

        ' ANTI-REPETIDOS
        If datos.ExisteDocumento(txtDocumento.Text.Trim(), 0) Then
            MessageBox.Show("Ese documento ya está registrado en la base de datos.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDocumento.Focus()
            Exit Sub
        End If

        Try
            Dim nuevoCliente As New Cliente(
                txtDocumento.Text.Trim(), txtNombre.Text.Trim(), txtApellido.Text.Trim(),
                txtTelefono.Text.Trim(), txtEmail.Text.Trim(), txtDireccion.Text.Trim(), Nothing, True
            )

            If datos.Agregar(nuevoCliente) Then
                MessageBox.Show("¡Cliente guardado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                MostrarClientes(datos.Listar())
                Limpiar()
            Else
                MessageBox.Show("No se pudo guardar el cliente.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error al agregar: " & ex.Message)
        End Try
    End Sub

    ' ===== BOTÓN MODIFICAR =====
    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If idClienteSeleccionado = 0 Then
            MessageBox.Show("Seleccioná un cliente de la grilla.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If Not DatosValidos() Then Exit Sub

        ' ANTI-REPETIDOS (excluyendo al propio cliente que estamos modificando)
        If datos.ExisteDocumento(txtDocumento.Text.Trim(), idClienteSeleccionado) Then
            MessageBox.Show("Ese documento ya pertenece a otro cliente.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDocumento.Focus()
            Exit Sub
        End If

        Try
            Dim c As New Cliente(
                txtDocumento.Text.Trim(), txtNombre.Text.Trim(), txtApellido.Text.Trim(),
                txtTelefono.Text.Trim(), txtEmail.Text.Trim(), txtDireccion.Text.Trim(), Nothing, True
            )
            c.IdCliente = idClienteSeleccionado

            If datos.Modificar(c) Then
                MessageBox.Show("¡Cliente modificado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                MostrarClientes(datos.Listar())
                Limpiar()
            Else
                MessageBox.Show("No se pudo modificar el cliente.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error al modificar: " & ex.Message)
        End Try
    End Sub

    ' ===== BOTÓN ELIMINAR =====
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If idClienteSeleccionado = 0 Then
            MessageBox.Show("Seleccioná un cliente de la grilla.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If MessageBox.Show("¿Estás seguro de eliminar este cliente?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                If datos.Eliminar(idClienteSeleccionado) Then
                    MessageBox.Show("¡Cliente eliminado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    MostrarClientes(datos.Listar())
                    Limpiar()
                End If
            Catch ex As Exception
                MessageBox.Show("Error al eliminar: " & ex.Message)
            End Try
        End If
    End Sub

    ' ===== BOTÓN FIN =====
    Private Sub btnFin_Click(sender As Object, e As EventArgs) Handles btnFin.Click
        Me.Close()
    End Sub

    ' ===== FUNCIÓN PRINCIPAL DE VALIDACIÓN =====
    Private Function DatosValidos() As Boolean
        ' === 1. Validar Documento (Cédula) ===
        txtDocumento.Text = Trim(txtDocumento.Text)
        If txtDocumento.Text = "" Then
            MessageBox.Show("Por favor, ingresá el documento del cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDocumento.Focus()
            Return False
        End If

        If Not valida_ci(txtDocumento.Text) Then
            Return False
        End If

        ' === 2. Validar Nombre ===
        txtNombre.Text = Trim(txtNombre.Text)
        If txtNombre.Text = "" Then
            MessageBox.Show("Nombre incompleto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNombre.Focus()
            Return False
        End If
        txtNombre.Text = StrConv(txtNombre.Text, VbStrConv.ProperCase)

        ' === 3. Validar Apellido ===
        txtApellido.Text = Trim(txtApellido.Text)
        If txtApellido.Text = "" Then
            MessageBox.Show("Apellido incompleto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtApellido.Focus()
            Return False
        End If
        txtApellido.Text = StrConv(txtApellido.Text, VbStrConv.ProperCase)

        ' === 4. Validar Teléfono ===
        txtTelefono.Text = Trim(txtTelefono.Text)
        If txtTelefono.Text = "" Then
            MessageBox.Show("Teléfono incompleto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtTelefono.Focus()
            Return False
        End If

        ' === 5. Validar E-Mail ===
        txtEmail.Text = Trim(txtEmail.Text)
        If txtEmail.Text = "" Then
            MessageBox.Show("Escriba la dirección e-mail.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtEmail.Focus()
            Return False
        Else
            If Not validar_mail(txtEmail.Text) Then
                MessageBox.Show("Dirección e-mail incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtEmail.Focus()
                txtEmail.SelectAll()
                Return False
            End If
        End If

        ' === 6. Validar Dirección ===
        txtDireccion.Text = Trim(txtDireccion.Text)
        If txtDireccion.Text = "" Then
            MessageBox.Show("Dirección incompleta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDireccion.Focus()
            Return False
        End If

        Return True
    End Function

    ' ===== FUNCIONES AUXILIARES DE VALIDACIÓN =====
    Private Function validar_mail(ByVal smail As String) As Boolean
        Return Regex.IsMatch(smail, "^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$")
    End Function

    Private Function valida_ci(ByVal cedula As String) As Boolean
        Dim clave(7) As Byte
        Dim a As String
        Dim b As String
        Dim c As Double
        Dim d As Byte
        Dim i As Byte

        If cedula.Length < 8 Then
            MessageBox.Show("Cédula incompleta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDocumento.Focus()
            txtDocumento.SelectAll()
            Return False
        Else
            clave(1) = 2 : clave(2) = 9 : clave(3) = 8 : clave(4) = 7
            clave(5) = 6 : clave(6) = 3 : clave(7) = 4
            c = 0
            For i = 1 To 7
                a = Mid(cedula, i, 1)
                b = a * clave(i)
                c = c + Val(Mid(b, Len(b), 1))
            Next i

            If Val(Mid(c, 2, 1)) = 0 Then
                d = 0
            Else
                d = 10 - Val(Mid(c, 2, 1))
            End If

            If d <> Val(Mid(cedula, 8, 1)) Then
                MessageBox.Show("Cédula incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtDocumento.Focus()
                Return False
            End If

            Return True
        End If
    End Function
End Class