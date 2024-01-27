Imports System.Data.Entity.Core
Imports System.Data.SQLite

Module BaseDeDatos

    Public Structure Alumno
        Public Id As Integer
        Public Nombre As String
        Public Apellidos As String
        Public Direccion As String
        Public Localidad As String
        Public Movil As String
        Public Email As String
        Public FechaNacimiento As DateOnly
        Public Nacionalidad As String
    End Structure

    Public Conexion As SQLiteConnection
    Public RutaBaseDeDatos As String = "Clase.db"
    Public AdaptadorDatosAlumnos As SQLiteDataAdapter
    Public DatosAlumnos As DataSet = New DataSet

    Public Sub Conectar()

        Conexion = New SQLiteConnection("Data Source=" + RutaBaseDeDatos + "; Version=3")

        Try

            Conexion.Open()

        Catch ex As Exception

            MsgBox(ex.ToString)

        End Try

    End Sub

    Public Function LeerDatosAlumnos() As DataSet

        Dim Query As String = "select Id, Nombre, Apellidos, Direccion, Localidad, Movil, Email, FechaNacimiento, Nacionalidad from Alumnos"

        AdaptadorDatosAlumnos = New SQLiteDataAdapter(Query, Conexion)

        DatosAlumnos.Clear()

        AdaptadorDatosAlumnos.Fill(DatosAlumnos, “Alumnos")

        Return DatosAlumnos

    End Function

    Public Function LeerDatosAlumnoBuscado(Alumno As Alumno) As Alumno

        Dim Query As String = "select Id, Nombre, Apellidos, Direccion, Localidad, Movil, Email, FechaNacimiento, Nacionalidad from Alumnos where Id = @Id"

        Dim Comando = New SQLiteCommand(Query, Conexion)

        Comando.Parameters.AddWithValue("@Id", Alumno.Id)

        Dim Lector As SQLiteDataReader = Comando.ExecuteReader()

        Dim AlumnoBuscado As New Alumno

        If Lector.Read() Then
            AlumnoBuscado.Id = Lector.GetInt32(0)
            AlumnoBuscado.Nombre = Lector.GetString(1)
            AlumnoBuscado.Apellidos = Lector.GetString(2)
            AlumnoBuscado.Direccion = Lector.GetString(3)
            AlumnoBuscado.Localidad = Lector.GetString(4)
            AlumnoBuscado.Movil = Lector.GetString(5)
            AlumnoBuscado.Email = Lector.GetString(6)
            AlumnoBuscado.FechaNacimiento = DateOnly.FromDateTime(Lector.GetDateTime(7))
            AlumnoBuscado.Nacionalidad = Lector.GetString(8)
        End If

        Lector.Close()

        Return AlumnoBuscado

    End Function

    Public Sub AgregarAlumno(Alumno As Alumno)

        Dim Insert As String = "Insert into Alumnos (Nombre, Apellidos, Direccion, Localidad, Movil, Email, FechaNacimiento, Nacionalidad) values (@Nombre, @Apellidos, @Direccion, @Localidad, @Movil, @Email, @FechaNacimiento, @Nacionalidad)"

        Dim Comando = New SQLiteCommand(Insert, Conexion)
        AdaptadorDatosAlumnos.InsertCommand = Comando

        Comando.Parameters.AddWithValue("@Nombre", Alumno.Nombre)
        Comando.Parameters.AddWithValue("@Apellidos", Alumno.Apellidos)
        Comando.Parameters.AddWithValue("@Direccion", Alumno.Direccion)
        Comando.Parameters.AddWithValue("@Localidad", Alumno.Localidad)
        Comando.Parameters.AddWithValue("@Movil", Alumno.Movil)
        Comando.Parameters.AddWithValue("@Email", Alumno.Email)
        Comando.Parameters.AddWithValue("@FechaNacimiento", Alumno.FechaNacimiento.ToString("yyyy-MM-dd"))
        Comando.Parameters.AddWithValue("@Nacionalidad", Alumno.Nacionalidad)

        Comando.ExecuteNonQuery()

    End Sub

    Public Sub EliminarAlumno(Alumno As Alumno)

        Dim Delete As String = "delete from Alumnos where Id = @Id"

        Dim Comando = New SQLiteCommand(Delete, Conexion)

        AdaptadorDatosAlumnos.DeleteCommand = Comando

        Comando.Parameters.AddWithValue("@Id", Alumno.Id)

        Comando.ExecuteNonQuery()

    End Sub

    Public Sub ModificarAlumno(Alumno As Alumno)

        Dim Update As String = "update Alumnos set Nombre = @Nombre, Apellidos = @Apellidos, Direccion = @Direccion, Localidad = @Localidad, Movil = @Movil, Email = @Email, FechaNacimiento = @FechaNacimiento, Nacionalidad = @Nacionalidad where Id = @Id"

        Dim Comando = New SQLiteCommand(Update, Conexion)
        AdaptadorDatosAlumnos.UpdateCommand = Comando

        Comando.Parameters.AddWithValue("@Nombre", Alumno.Nombre)
        Comando.Parameters.AddWithValue("@Apellidos", Alumno.Apellidos)
        Comando.Parameters.AddWithValue("@Direccion", Alumno.Direccion)
        Comando.Parameters.AddWithValue("@Localidad", Alumno.Localidad)
        Comando.Parameters.AddWithValue("@Movil", Alumno.Movil)
        Comando.Parameters.AddWithValue("@Email", Alumno.Email)
        Comando.Parameters.AddWithValue("@FechaNacimiento", Alumno.FechaNacimiento.ToString("yyyy-MM-dd"))
        Comando.Parameters.AddWithValue("@Nacionalidad", Alumno.Nacionalidad)
        Comando.Parameters.AddWithValue("@Id", Alumno.Id)

        Comando.ExecuteNonQuery()

    End Sub

    Public Sub Desconectar()

        If Conexion.State = ConnectionState.Open Then

            Conexion.Close()

        Else

            MsgBox("No se puede cerrar")

        End If

    End Sub

End Module
