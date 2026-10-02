Imports System.Data.OleDb

Public Class Cliente_datos

    ' Recibe un Cliente (c) y lo guarda en la base de datos
    Public Function Agregar(c As Cliente) As Boolean
        ' Usamos la cadena de conexión que ya tienes configurada
        Using cn As New OleDbConnection(Conexion.CadenaConexion)
            Dim sql As String = "INSERT INTO Clientes (Documento, Nombre, Apellido, Telefono, Email, Direccion, Activo) VALUES (?, ?, ?, ?, ?, ?, ?)"

            Using cmd As New OleDbCommand(sql, cn)
                ' Leemos los datos del cliente "c" que nos pasaron
                cmd.Parameters.AddWithValue("?", c.Documento)
                cmd.Parameters.AddWithValue("?", c.Nombre)
                cmd.Parameters.AddWithValue("?", c.Apellido)
                cmd.Parameters.AddWithValue("?", c.Telefono)
                cmd.Parameters.AddWithValue("?", c.Email)
                cmd.Parameters.AddWithValue("?", c.Direccion)
                cmd.Parameters.AddWithValue("?", c.Activo)

                cn.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function

End Class