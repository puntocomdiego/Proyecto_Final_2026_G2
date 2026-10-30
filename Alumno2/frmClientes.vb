Imports System.Text.RegularExpressions

Public Class frmClientes
    ' Un solo objeto de acceso a datos para todo el formulario
    Private datos As New Cliente_datos()
    ' Variable CLAVE para recordar a quién modificar/eliminar
    Private idClienteSeleccionado As Integer = 0
    ' Estado interno de la pantalla: "" | "NUEVO" | "MODIFICAR"
    Private _modo As String = ""

    ' ===== CARGA DEL FORMULARIO =====
    Private Sub frmClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance)
        ConfigurarGrilla()
        MostrarClientes(datos.Listar())
        EstadoInicial()
    End Sub

    ' ===== CONTROL DE ESTADOS Y BOTONES =====
    Private Sub EstadoInicial()
        Limpiar()
        HabilitarCampos(False)
        SetBotones(nuevo:=True, agregar:=False, modificar:=False, cancelar:=False, eliminar:=False)
        btnModificar.Text = "MODIFICAR"
        _modo = ""
    End Sub

    Private Sub HabilitarCampos(habilitar As Boolean)
        txtDocumento.Enabled = habilitar
        txtNombre.Enabled = habilitar
        txtApellido.Enabled = habilitar
        txtTelefono.Enabled = habilitar
        txtEmail.Enabled = habilitar
        txtDireccion.Enabled = habilitar
    End Sub

    Private Sub SetBotones(nuevo As Boolean, agregar As Boolean, modificar As Boolean, cancelar As Boolean, eliminar As Boolean)
        btnNuevo.Enabled = nuevo
        btnAgregar.Enabled = agregar
        btnModificar.Enabled = modificar
        btnCancelar.Enabled = cancelar
        btnEliminar.Enabled = eliminar
    End Sub

    Private Sub Limpiar()
        txtDocumento.Clear()
        txtNombre.Clear()
        txtApellido.Clear()
        txtTelefono.Clear()
        txtEmail.Clear()
        txtDireccion.Clear()
        idClienteSeleccionado = 0
        dgvClientes.ClearSelection()
    End Sub

    ' ===== BOTONES NUEVO Y CANCELAR =====
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Limpiar()
        HabilitarCampos(True)
        _modo = "NUEVO"
        SetBotones(nuevo:=False, agregar:=True, modificar:=False, cancelar:=True, eliminar:=False)
        txtDocumento.Focus()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        EstadoInicial()
    End Sub

    ' ===== MÉTODOS DE LA GRILLA =====
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

        ' Obligamos a la grilla a soltar cualquier celda y fila seleccionada automáticamente
        dgvClientes.CurrentCell = Nothing
    End Sub

    ' Usamos CellClick para asegurar que solo cargue datos cuando el usuario haga un clic real
    Private Sub dgvClientes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClientes.CellClick
        If e.RowIndex < 0 Then Exit Sub ' Ignorar si hacen clic en los títulos de las columnas
        If dgvClientes.CurrentRow Is Nothing Then Exit Sub

        Try
            idClienteSeleccionado = Convert.ToInt32(dgvClientes.CurrentRow.Cells("IdCliente").Value)
            txtDocumento.Text = dgvClientes.CurrentRow.Cells("Documento").Value.ToString()
            txtNombre.Text = dgvClientes.CurrentRow.Cells("Nombre").Value.ToString()
            txtApellido.Text = dgvClientes.CurrentRow.Cells("Apellido").Value.ToString()
            txtTelefono.Text = dgvClientes.CurrentRow.Cells("Telefono").Value.ToString()
            txtEmail.Text = dgvClientes.CurrentRow.Cells("Email").Value.ToString()
            txtDireccion.Text = dgvClientes.CurrentRow.Cells("Direccion").Value.ToString()

            ' Al seleccionar, bloqueamos edición y habilitamos acciones
            _modo = ""
            btnModificar.Text = "MODIFICAR"
            HabilitarCampos(False)
            SetBotones(nuevo:=True, agregar:=False, modificar:=True, cancelar:=True, eliminar:=True)
        Catch ex As Exception
            MessageBox.Show("Error al leer los datos: " & ex.Message)
        End Try
    End Sub

    ' ===== BOTÓN AGREGAR =====
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If Not DatosValidos() Then Exit Sub

        If datos.ExisteDocumento(txtDocumento.Text.Trim(), 0) Then
            MessageBox.Show("Ese documento ya está registrado.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                EstadoInicial()
            Else
                MessageBox.Show("No se pudo guardar el cliente.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error al agregar: " & ex.Message)
        End Try
    End Sub

    ' ===== BOTÓN MODIFICAR =====
    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If _modo <> "MODIFICAR" Then
            ' --- 1. Activar el modo de edición ---
            HabilitarCampos(True)
            txtDocumento.Enabled = False ' Bloqueamos la cédula para que no se cambie accidentalmente
            _modo = "MODIFICAR"
            btnModificar.Text = "GUARDAR"
            SetBotones(nuevo:=False, agregar:=False, modificar:=True, cancelar:=True, eliminar:=False)
        Else
            ' --- 2. Ejecutar el guardado de los cambios ---
            If Not DatosValidos() Then Exit Sub

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
                    EstadoInicial()
                Else
                    MessageBox.Show("No se pudo modificar el cliente.")
                End If
            Catch ex As Exception
                MessageBox.Show("Error al modificar: " & ex.Message)
            End Try
        End If
    End Sub

    ' ===== BOTÓN ELIMINAR =====
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If MessageBox.Show("¿Estás seguro de eliminar este cliente?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                If datos.Eliminar(idClienteSeleccionado) Then
                    MessageBox.Show("¡Cliente eliminado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    MostrarClientes(datos.Listar())
                    EstadoInicial()
                End If
            Catch ex As Exception
                MessageBox.Show("Error al eliminar: " & ex.Message)
            End Try
        End If
    End Sub

    ' ===== BOTÓN FIN =====
    Private Sub btnFin_Click(sender As Object, e As EventArgs) Handles btnFin.Click
        MsgBox("¡Gracias por usar el sistema!", MsgBoxStyle.Information, "Cierre de la aplicación")
        Close
    End Sub

    ' ===== FUNCIÓN PRINCIPAL DE VALIDACIÓN =====
    Private Function DatosValidos() As Boolean
        ' === 1. Validar Documento (Cédula) ===
        ' Al ser un MaskedTextBox, extraemos ÚNICAMENTE los números.
        ' Esto ignora puntos, guiones, espacios y guiones bajos (_) automáticamente.
        Dim cedulaLimpia As String = Regex.Replace(txtDocumento.Text, "[^\d]", "")

        If cedulaLimpia = "" Then
            MessageBox.Show("Por favor, ingresá el documento del cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDocumento.Focus()
            Return False
        End If

        ' Si es una cédula antigua de menos de 8 números, la rellena con ceros a la izquierda
        cedulaLimpia = cedulaLimpia.PadLeft(8, "0"c)

        ' Enviamos a la matemática la variable perfectamente limpia
        If Not valida_ci(cedulaLimpia) Then
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
            MsgBox("Cédula incompleta", MsgBoxStyle.Exclamation, "Error")
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
                MsgBox("Cédula incorrecta", MsgBoxStyle.Exclamation, "Error")
                txtDocumento.Focus()
                Return False
            End If

            Return True
        End If
    End Function


    Private Sub btnmail_Click(sender As Object, e As EventArgs) Handles btnmail.Click
        ' Abrimos la pantalla de Mailing
        Dim ventanaMail As New frmMailing()
        ventanaMail.MdiParent = Me.MdiParent
        ventanaMail.Show()

        ' Ocultamos la pantalla actual de Clientes
        Me.Hide()
    End Sub
End Class