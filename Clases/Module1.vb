Module Module1
    Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)

        'Using s As New FRM_SPLASH()
        's.ShowDialog() ' El splash se cerrará solo después de 5s
        'End Using

        Application.Run(New frmMenuPrincipal()) ' Reemplaza FRM_MAIN por tu formulario principal
    End Sub
End Module
