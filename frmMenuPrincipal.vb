Imports System.Windows.Forms

Public Class frmMenuPrincipal

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a new instance of the child form.

    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)

    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        '  Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.

    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub ProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductosToolStripMenuItem.Click
        Dim f As New frmProductos
        f.MdiParent = Me
        f.Show()

    End Sub

    Private Sub ClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem.Click
        Dim f As New frmClientes
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub VentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentasToolStripMenuItem.Click
        Dim f As New frmVenta
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub CategoriasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CategoriasToolStripMenuItem.Click
        Dim f As New frmCategorias
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub ConsultaDeVentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaDeVentasToolStripMenuItem.Click
        Dim f As New frmConsultaVentas
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub frmMenuPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub RespaldarYRestaurarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RespaldarYRestaurarToolStripMenuItem.Click


        Try
            sfdRespaldo.Filter = "Base de datos Access|*.accdb"
            sfdRespaldo.InitialDirectory = BaseDeDatos.CarpetaRespaldos()
            sfdRespaldo.FileName = $"Comercial_{Date.Now:yyyy-MM-dd_HHmm}.accdb"
            If sfdRespaldo.ShowDialog() <> DialogResult.OK Then Exit Sub

            BaseDeDatos.Respaldar(sfdRespaldo.FileName)

            Dim mensaje = "Respaldo guardado en:" & vbCrLf & sfdRespaldo.FileName
            If BaseDeDatos.CarpetaGoogleDrive() IsNot Nothing AndAlso
        sfdRespaldo.FileName.StartsWith(BaseDeDatos.CarpetaGoogleDrive(), StringComparison.OrdinalIgnoreCase) Then
                mensaje &= vbCrLf & vbCrLf & "Google Drive lo subirá a la nube automáticamente."
            End If
            MessageBox.Show(mensaje, "Respaldo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("No se pudo hacer el respaldo: " & ex.Message,
                     "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



    End Sub
End Class
