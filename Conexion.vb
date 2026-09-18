Module Conexion
    Public ReadOnly Ruta As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "nombre_de_la_base.accdb")
    Public ReadOnly CadenaConexion As String = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Ruta};"
End Module
