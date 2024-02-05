Imports System.Data.Entity.Core
Imports System.Data.SQLite

Module BaseDeDatos

    '                                       '
    '   ESTRUCTURA DE LAS TABLAS DE LA BD   '
    '                                       '


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

    Public Structure Asignatura
        Public Id As Integer
        Public Nombre As String
        Public Aula As String
        Public Profesor As Integer
    End Structure

    Public Structure Profesor
        Public Id As Integer
        Public Nombre As String
        Public Apellidos As String
        Public Departamento As String
    End Structure

    Public Conexion As SQLiteConnection
    Public RutaBaseDeDatos As String = "Clase.db"
    Public AdaptadorDatosAlumnos As SQLiteDataAdapter
    Public AdaptadorDatosAsignaturas As SQLiteDataAdapter
    Public AdaptadorDatosProfesores As SQLiteDataAdapter
    Public DatosAlumnos As DataSet = New DataSet
    Public DatosAsignaturas As DataSet = New DataSet
    Public DatosProfesores As DataSet = New DataSet


    Public Sub Conectar()

        Conexion = New SQLiteConnection("Data Source=" + RutaBaseDeDatos + "; Version=3")

        Try

            Conexion.Open()

        Catch ex As Exception

            MsgBox(ex.ToString)

        End Try

    End Sub

    Public Sub Desconectar()

        If Conexion.State = ConnectionState.Open Then

            Conexion.Close()

        Else

            MsgBox("No se puede cerrar")

        End If

    End Sub

    '                                       '
    '   GESTION DE LA TABLA DE ALUMNOS      '
    '                                       '

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

    Public Sub EliminarAlumno(Alumno As Alumno)

        Dim Delete As String = "delete from Alumnos where Id = @Id"

        Dim Comando = New SQLiteCommand(Delete, Conexion)

        AdaptadorDatosAlumnos.DeleteCommand = Comando

        Comando.Parameters.AddWithValue("@Id", Alumno.Id)

        Comando.ExecuteNonQuery()

    End Sub

    '                                       '
    '   GESTION DE LA TABLA DE ASIGNATURAS  '
    '                                       '

    Public Function LeerDatosAsignaturas() As DataSet

        Dim Query As String = "select Id, Nombre, Aula, Profesor from Asignaturas"

        AdaptadorDatosAsignaturas = New SQLiteDataAdapter(Query, Conexion)

        DatosAsignaturas.Clear()

        AdaptadorDatosAsignaturas.Fill(DatosAsignaturas, "Asignaturas")

        Return DatosAsignaturas

    End Function

    Public Function LeerDatosAsignaturaBuscada(Asignatura As Asignatura) As Asignatura

        Dim Query As String = "select Id, Nombre, Aula, Profesor from Asignaturas where Id = @Id"

        Dim Comando = New SQLiteCommand(Query, Conexion)

        Comando.Parameters.AddWithValue("@Id", Asignatura.Id)

        Dim Lector As SQLiteDataReader = Comando.ExecuteReader()

        Dim AsignaturaBuscada As New Asignatura

        If Lector.Read() Then
            AsignaturaBuscada.Id = Lector.GetInt32(0)
            AsignaturaBuscada.Nombre = Lector.GetString(1)
            AsignaturaBuscada.Aula = Lector.GetString(2)
            AsignaturaBuscada.Profesor = Lector.GetInt32(3)
        End If

        Lector.Close()

        Return AsignaturaBuscada
    End Function

    Public Sub AgregarAsignatura(Asignatura As Asignatura)

        Dim Insert As String = "Insert into Asignaturas (Nombre, Aula, Profesor) values (@Nombre, @Aula, @Profesor)"

        Dim Comando = New SQLiteCommand(Insert, Conexion)

        Comando.Parameters.AddWithValue("@Nombre", Asignatura.Nombre)
        Comando.Parameters.AddWithValue("@Aula", Asignatura.Aula)
        Comando.Parameters.AddWithValue("@Profesor", Asignatura.Profesor)

        Comando.ExecuteNonQuery()

    End Sub

    Public Sub ModificarAsignatura(Asignatura As Asignatura)

        Dim Update As String = "update Asignaturas set Nombre = @Nombre, Aula = @Aula, Profesor = @Profesor where Id = @Id"

        Dim Comando = New SQLiteCommand(Update, Conexion)

        AdaptadorDatosAsignaturas.UpdateCommand = Comando

        Comando.Parameters.AddWithValue("@Nombre", Asignatura.Nombre)
        Comando.Parameters.AddWithValue("@Aula", Asignatura.Aula)
        Comando.Parameters.AddWithValue("@Profesor", Asignatura.Profesor)
        Comando.Parameters.AddWithValue("@Id", Asignatura.Id)

        Comando.ExecuteNonQuery()

    End Sub

    Public Sub EliminarAsignatura(Asignatura As Asignatura)

        Dim Delete As String = "delete from Asignaturas where Id = @Id"

        Dim Comando = New SQLiteCommand(Delete, Conexion)

        Comando.Parameters.AddWithValue("@Id", Asignatura.Id)

        Comando.ExecuteNonQuery()

    End Sub

    '                                       '
    '   GESTION DE LA TABLA DE PROFESORES   '
    '                                       '

    Public Function LeerDatosProfesores() As DataSet

        Dim Query As String = "select Id, Nombre, Apellidos, Departamento from Profesores"

        AdaptadorDatosProfesores = New SQLiteDataAdapter(Query, Conexion)

        DatosProfesores.Clear()

        AdaptadorDatosProfesores.Fill(DatosProfesores, "Profesores")

        Return DatosProfesores

    End Function

    Public Function LeerDatosProfesorBuscado(Profesor As Profesor) As Profesor

        Dim Query As String = "select Id, Nombre, Apellidos, Departamento from Profesores where Id = @Id"

        Dim Comando = New SQLiteCommand(Query, Conexion)

        Comando.Parameters.AddWithValue("@Id", Profesor.Id)

        Dim Lector As SQLiteDataReader = Comando.ExecuteReader()

        Dim ProfesorBuscado As New Profesor

        If Lector.Read() Then
            ProfesorBuscado.Id = Lector.GetInt32(0)
            ProfesorBuscado.Nombre = Lector.GetString(1)
            ProfesorBuscado.Apellidos = Lector.GetString(2)
            ProfesorBuscado.Departamento = Lector.GetString(3)
        End If

        Lector.Close()

        Return ProfesorBuscado

    End Function

    Public Sub AgregarProfesor(Profesor As Profesor)

        Dim Insert As String = "Insert into Profesores (Nombre, Apellidos, Departamento) values (@Nombre, @Apellidos, @Departamento)"

        Dim Comando = New SQLiteCommand(Insert, Conexion)

        Comando.Parameters.AddWithValue("@Nombre", Profesor.Nombre)
        Comando.Parameters.AddWithValue("@Apellidos", Profesor.Apellidos)
        Comando.Parameters.AddWithValue("@Departamento", Profesor.Departamento)

        Comando.ExecuteNonQuery()

    End Sub

    Public Sub ModificarProfesor(Profesor As Profesor)

        Dim Update As String = "update Profesores set Nombre = @Nombre, Apellidos = @Apellidos, Departamento = @Departamento where Id = @Id"

        Dim Comando = New SQLiteCommand(Update, Conexion)

        AdaptadorDatosProfesores.UpdateCommand = Comando

        Comando.Parameters.AddWithValue("@Nombre", Profesor.Nombre)
        Comando.Parameters.AddWithValue("@Apellidos", Profesor.Apellidos)
        Comando.Parameters.AddWithValue("@Departamento", Profesor.Departamento)
        Comando.Parameters.AddWithValue("@Id", Profesor.Id)

        Comando.ExecuteNonQuery()

    End Sub

    Public Sub EliminarProfesor(Profesor As Profesor)

        Dim Delete As String = "delete from Profesores where Id = @Id"

        Dim Comando = New SQLiteCommand(Delete, Conexion)

        Comando.Parameters.AddWithValue("@Id", Profesor.Id)

        Comando.ExecuteNonQuery()

    End Sub

End Module
