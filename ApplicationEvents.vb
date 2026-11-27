Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.

    ' **NEW** ApplyApplicationDefaults: Raised when the application queries default values to be set for the application.

    ' Example:
    ' Private Sub MyApplication_ApplyApplicationDefaults(sender As Object, e As ApplyApplicationDefaultsEventArgs) Handles Me.ApplyApplicationDefaults
    '
    '   ' Setting the application-wide default Font:
    '   e.Font = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Regular)
    '
    '   ' Setting the HighDpiMode for the Application:
    '   e.HighDpiMode = HighDpiMode.PerMonitorV2
    '
    '   ' If a splash dialog is used, this sets the minimum display time:
    '   e.MinimumSplashScreenDisplayTime = 4000
    ' End Sub

    Partial Friend Class MyApplication
        Private Sub MyApplication_Startup(sender As Object, e As ApplicationServices.StartupEventArgs) Handles Me.Startup
            If BaseDeDatos.Existe() Then Exit Sub

            Dim respuesta = MessageBox.Show(
         "No se encontró la base de datos:" & vbCrLf & BaseDeDatos.Ruta & vbCrLf & vbCrLf &
         "¿Desea crearla ahora a partir del script CrearBD.sql?",
         "Base de datos no encontrada", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If respuesta = DialogResult.No Then
                MessageBox.Show("El programa no puede funcionar sin la base de datos y se cerrará.",
                         "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
                Exit Sub
            End If

            Try
                BaseDeDatos.Crear()
                MessageBox.Show("La base de datos se creó correctamente.",
                         "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("No se pudo crear la base de datos:" & vbCrLf & ex.Message,
                         "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                e.Cancel = True
            End Try
        End Sub
    End Class
End Namespace
