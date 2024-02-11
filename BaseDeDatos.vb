Imports System.Data.SQLite

''' <summary>
''' Módulo que gestiona la conexión y operaciones en la base de datos SQLite.
''' </summary>
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

    Public Structure Nota
        Public Alumno As Integer
        Public Asignatura As Integer
        Public Nota1 As Single
        Public Nota2 As Single
        Public Nota3 As Single
        Public NotaFinal As Single
    End Structure

    '                                       '
    '   VARIABLES                           '
    '                                       '

    Public Conexion As SQLiteConnection
    Public RutaBaseDeDatos As String = "Clase.db"
    Public AdaptadorDatosAlumnos As SQLiteDataAdapter
    Public AdaptadorDatosAsignaturas As SQLiteDataAdapter
    Public AdaptadorDatosProfesores As SQLiteDataAdapter
    Public AdaptadorDatosNotas As SQLiteDataAdapter
    Public DatosAlumnos As DataSet = New DataSet
    Public DatosAsignaturas As DataSet = New DataSet
    Public DatosProfesores As DataSet = New DataSet
    Public DatosNotas As DataSet = New DataSet

    ''' <summary>
    ''' Establece la conexión con la base de datos SQLite.
    ''' </summary>
    Public Sub Conectar()

        ' Crea una nueva conexión SQLite utilizando la ruta especificada
        Conexion = New SQLiteConnection("Data Source=" + RutaBaseDeDatos + "; Version=3")

        Try

            ' Intenta abrir la conexión
            Conexion.Open()

        Catch ex As Exception

            ' Muestra un mensaje de error si la conexión falla
            MsgBox("No se pudo conectar con la base de datos")

        End Try

    End Sub

    ''' <summary>
    ''' Cierra la conexión con la base de datos SQLite.
    ''' </summary>
    Public Sub Desconectar()

        If Conexion.State = ConnectionState.Open Then

            Conexion.Close()

        Else

            ' Muestra un mensaje si la conexión no está abierta
            MsgBox("No se puede cerrar")

        End If

    End Sub

    '                                       '
    '   GESTION DE LA TABLA DE ALUMNOS      '
    '                                       '

    ''' <summary>
    ''' Lee los datos de todos los alumnos desde la base de datos.
    ''' </summary>
    ''' <returns>Un conjunto de datos que contiene la información de los alumnos.</returns>
    Public Function LeerDatosAlumnos() As DataSet

        ' Query para seleccionar todos los campos de la tabla Alumnos
        Dim Query As String = "select Id, Nombre, Apellidos, Direccion, Localidad, Movil, Email, FechaNacimiento, Nacionalidad from Alumnos"

        ' Crea un adaptador de datos SQLite y ejecuta la consulta
        AdaptadorDatosAlumnos = New SQLiteDataAdapter(Query, Conexion)

        ' Limpia los datos actuales del conjunto de datos
        DatosAlumnos.Clear()

        ' Llena el conjunto de datos con los resultados de la consulta
        AdaptadorDatosAlumnos.Fill(DatosAlumnos, "Alumnos")

        ' Retorna el conjunto de datos que contiene la información de los alumnos
        Return DatosAlumnos

    End Function

    ''' <summary>
    ''' Lee los datos de un alumno específico desde la base de datos.
    ''' </summary>
    ''' <param name="Alumno">El alumno a buscar.</param>
    ''' <returns>Los datos del alumno encontrado.</returns>
    Public Function LeerDatosAlumnoBuscado(Alumno As Alumno) As Alumno

        ' Query para seleccionar los campos de un alumno específico basado en su Id
        Dim Query As String = "select Id, Nombre, Apellidos, Direccion, Localidad, Movil, Email, FechaNacimiento, Nacionalidad from Alumnos where Id = @Id"

        ' Crea un comando SQLite con la consulta y los parámetros necesarios
        Dim Comando = New SQLiteCommand(Query, Conexion)

        Comando.Parameters.AddWithValue("@Id", Alumno.Id)

        ' Ejecuta la consulta y obtiene el lector de datos
        Dim Lector As SQLiteDataReader = Comando.ExecuteReader()

        ' Crea una instancia de la estructura Alumno para almacenar los datos encontrados
        Dim AlumnoBuscado As New Alumno

        ' Si se encuentra un registro, se asignan los datos al objeto AlumnoBuscado
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

        ' Cierra el lector de datos
        Lector.Close()

        ' Retorna el alumno encontrado
        Return AlumnoBuscado

    End Function

    ''' <summary>
    ''' Agrega un nuevo alumno a la base de datos.
    ''' </summary>
    ''' <param name="Alumno">El objeto Alumno que se va a agregar.</param>
    Public Sub AgregarAlumno(Alumno As Alumno)

        ' Consulta SQL para insertar un nuevo registro en la tabla Alumnos
        Dim Insert As String = "Insert into Alumnos (Nombre, Apellidos, Direccion, Localidad, Movil, Email, FechaNacimiento, Nacionalidad) values (@Nombre, @Apellidos, @Direccion, @Localidad, @Movil, @Email, @FechaNacimiento, @Nacionalidad)"

        ' Crea un comando SQLite con la consulta y los parámetros necesarios
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

        ' Ejecuta el comando para agregar el nuevo alumno a la base de datos
        Comando.ExecuteNonQuery()

    End Sub

    ''' <summary>
    ''' Modifica los datos de un alumno en la base de datos.
    ''' </summary>
    ''' <param name="Alumno">El objeto Alumno con los datos modificados.</param>
    Public Sub ModificarAlumno(Alumno As Alumno)

        ' Consulta SQL para actualizar los datos de un alumno específico en la tabla Alumnos
        Dim Update As String = "update Alumnos set Nombre = @Nombre, Apellidos = @Apellidos, Direccion = @Direccion, Localidad = @Localidad, Movil = @Movil, Email = @Email, FechaNacimiento = @FechaNacimiento, Nacionalidad = @Nacionalidad where Id = @Id"

        ' Crea un comando SQLite con la consulta y los parámetros necesarios
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

        ' Ejecuta el comando para modificar los datos del alumno en la base de datos
        Comando.ExecuteNonQuery()

    End Sub

    ''' <summary>
    ''' Elimina un alumno de la base de datos.
    ''' </summary>
    ''' <param name="Alumno">El objeto Alumno que se va a eliminar.</param>
    Public Sub EliminarAlumno(Alumno As Alumno)

        ' Consulta SQL para eliminar un registro de la tabla Alumnos basado en su Id
        Dim Delete As String = "delete from Alumnos where Id = @Id"

        ' Crea un comando SQLite con la consulta y los parámetros necesarios
        Dim Comando = New SQLiteCommand(Delete, Conexion)

        AdaptadorDatosAlumnos.DeleteCommand = Comando

        Comando.Parameters.AddWithValue("@Id", Alumno.Id)

        ' Ejecuta el comando para eliminar el alumno de la base de datos
        Comando.ExecuteNonQuery()

    End Sub

    '                                       '
    '   GESTION DE LA TABLA DE ASIGNATURAS  '
    '                                       '

    ''' <summary>
    ''' Lee todos los datos de la tabla de Asignaturas y los devuelve en un DataSet.
    ''' </summary>
    ''' <returns>Un DataSet que contiene todos los datos de la tabla de Asignaturas.</returns>
    Public Function LeerDatosAsignaturas() As DataSet

        ' Consulta SQL para seleccionar todos los campos de la tabla de Asignaturas
        Dim Query As String = "select Id, Nombre, Aula, Profesor from Asignaturas"

        ' Crear un nuevo adaptador de datos SQLite con la consulta y la conexión existente
        AdaptadorDatosAsignaturas = New SQLiteDataAdapter(Query, Conexion)

        ' Limpiar cualquier dato existente en el DataSet
        DatosAsignaturas.Clear()

        ' Llenar el DataSet con los datos obtenidos del adaptador
        AdaptadorDatosAsignaturas.Fill(DatosAsignaturas, "Asignaturas")

        ' Devolver el DataSet lleno
        Return DatosAsignaturas

    End Function

    ''' <summary>
    ''' Lee los datos de una asignatura específica en base a su ID y devuelve un objeto Asignatura.
    ''' </summary>
    ''' <param name="Asignatura">El objeto Asignatura con el ID de la asignatura a buscar.</param>
    ''' <returns>Un objeto Asignatura con los datos de la asignatura buscada.</returns>
    Public Function LeerDatosAsignaturaBuscada(Asignatura As Asignatura) As Asignatura

        ' Consulta SQL para seleccionar los campos de la tabla de Asignaturas donde el ID coincide con el proporcionado
        Dim Query As String = "select Id, Nombre, Aula, Profesor from Asignaturas where Id = @Id"

        ' Crear un nuevo comando SQLite con la consulta y la conexión existente
        Dim Comando = New SQLiteCommand(Query, Conexion)

        ' Agregar el parámetro de ID al comando
        Comando.Parameters.AddWithValue("@Id", Asignatura.Id)

        ' Ejecutar la consulta y obtener un lector de datos
        Dim Lector As SQLiteDataReader = Comando.ExecuteReader()

        ' Crear un nuevo objeto Asignatura para almacenar los datos buscados
        Dim AsignaturaBuscada As New Asignatura

        ' Comprobar si se encontraron datos y, si es así, leerlos y almacenarlos en el objeto AsignaturaBuscada
        If Lector.Read() Then

            AsignaturaBuscada.Id = Lector.GetInt32(0)
            AsignaturaBuscada.Nombre = Lector.GetString(1)
            AsignaturaBuscada.Aula = Lector.GetString(2)
            AsignaturaBuscada.Profesor = Lector.GetInt32(3)

        End If

        ' Cerrar el lector de datos
        Lector.Close()

        ' Devolver el objeto AsignaturaBuscada con los datos obtenidos
        Return AsignaturaBuscada

    End Function

    ''' <summary>
    ''' Agrega una nueva asignatura a la base de datos.
    ''' </summary>
    ''' <param name="Asignatura">El objeto Asignatura que contiene los datos de la nueva asignatura a agregar.</param>
    Public Sub AgregarAsignatura(Asignatura As Asignatura)

        ' Consulta SQL para insertar un nuevo registro en la tabla de Asignaturas con los datos de la nueva asignatura
        Dim Insert As String = "Insert into Asignaturas (Nombre, Aula, Profesor) values (@Nombre, @Aula, @Profesor)"

        ' Crear un nuevo comando SQLite con la consulta y la conexión existente
        Dim Comando = New SQLiteCommand(Insert, Conexion)

        AdaptadorDatosAsignaturas.InsertCommand = Comando

        ' Agregar los parámetros necesarios al comando
        Comando.Parameters.AddWithValue("@Nombre", Asignatura.Nombre)
        Comando.Parameters.AddWithValue("@Aula", Asignatura.Aula)
        Comando.Parameters.AddWithValue("@Profesor", Asignatura.Profesor)

        ' Ejecutar el comando para insertar la nueva asignatura en la base de datos
        Comando.ExecuteNonQuery()

    End Sub

    ''' <summary>
    ''' Modifica los datos de una asignatura existente en la base de datos.
    ''' </summary>
    ''' <param name="Asignatura">El objeto Asignatura con los datos actualizados de la asignatura.</param>
    Public Sub ModificarAsignatura(Asignatura As Asignatura)

        ' Consulta SQL para actualizar los datos de la asignatura en la tabla de Asignaturas
        Dim Update As String = "update Asignaturas set Nombre = @Nombre, Aula = @Aula, Profesor = @Profesor where Id = @Id"

        ' Crear un nuevo comando SQLite con la consulta y la conexión existente
        Dim Comando = New SQLiteCommand(Update, Conexion)

        AdaptadorDatosAsignaturas.UpdateCommand = Comando

        ' Agregar los parámetros necesarios al comando
        Comando.Parameters.AddWithValue("@Nombre", Asignatura.Nombre)
        Comando.Parameters.AddWithValue("@Aula", Asignatura.Aula)
        Comando.Parameters.AddWithValue("@Profesor", Asignatura.Profesor)
        Comando.Parameters.AddWithValue("@Id", Asignatura.Id)

        ' Ejecutar el comando para actualizar los datos de la asignatura en la base de datos
        Comando.ExecuteNonQuery()

    End Sub

    ''' <summary>
    ''' Elimina una asignatura existente de la base de datos.
    ''' </summary>
    ''' <param name="Asignatura">El objeto Asignatura que representa la asignatura a eliminar.</param>
    Public Sub EliminarAsignatura(Asignatura As Asignatura)

        ' Consulta SQL para eliminar la asignatura de la tabla de Asignaturas
        Dim Delete As String = "delete from Asignaturas where Id = @Id"

        ' Crear un nuevo comando SQLite con la consulta y la conexión existente
        Dim Comando = New SQLiteCommand(Delete, Conexion)

        AdaptadorDatosAsignaturas.DeleteCommand = Comando

        ' Agregar el parámetro de ID al comando
        Comando.Parameters.AddWithValue("@Id", Asignatura.Id)

        ' Ejecutar el comando para eliminar la asignatura de la base de datos
        Comando.ExecuteNonQuery()

    End Sub

    '                                       '
    '   GESTION DE LA TABLA DE PROFESORES   '
    '                                       '

    ''' <summary>
    ''' Lee todos los datos de la tabla de Profesores y los devuelve en un DataSet.
    ''' </summary>
    ''' <returns>Un DataSet que contiene todos los datos de la tabla de Profesores.</returns>
    Public Function LeerDatosProfesores() As DataSet

        ' Consulta SQL para seleccionar todos los campos de la tabla de Profesores
        Dim Query As String = "select Id, Nombre, Apellidos, Departamento from Profesores"

        ' Crear un nuevo adaptador de datos SQLite con la consulta y la conexión existente
        AdaptadorDatosProfesores = New SQLiteDataAdapter(Query, Conexion)

        ' Limpiar cualquier dato existente en el DataSet
        DatosProfesores.Clear()

        ' Llenar el DataSet con los datos obtenidos del adaptador
        AdaptadorDatosProfesores.Fill(DatosProfesores, "Profesores")

        ' Devolver el DataSet lleno
        Return DatosProfesores

    End Function

    ''' <summary>
    ''' Lee los datos de un profesor específico en base a su ID y devuelve un objeto Profesor.
    ''' </summary>
    ''' <param name="Profesor">El objeto Profesor con el ID del profesor a buscar.</param>
    ''' <returns>Un objeto Profesor con los datos del profesor buscado.</returns>
    Public Function LeerDatosProfesorBuscado(Profesor As Profesor) As Profesor

        ' Consulta SQL para seleccionar los campos de la tabla de Profesores donde el ID coincide con el proporcionado
        Dim Query As String = "select Id, Nombre, Apellidos, Departamento from Profesores where Id = @Id"

        ' Crear un nuevo comando SQLite con la consulta y la conexión existente
        Dim Comando = New SQLiteCommand(Query, Conexion)

        ' Agregar el parámetro de ID al comando
        Comando.Parameters.AddWithValue("@Id", Profesor.Id)

        ' Ejecutar la consulta y obtener un lector de datos
        Dim Lector As SQLiteDataReader = Comando.ExecuteReader()

        ' Crear un nuevo objeto Profesor para almacenar los datos buscados
        Dim ProfesorBuscado As New Profesor

        ' Comprobar si se encontraron datos y, si es así, leerlos y almacenarlos en el objeto ProfesorBuscado
        If Lector.Read() Then

            ProfesorBuscado.Id = Lector.GetInt32(0)
            ProfesorBuscado.Nombre = Lector.GetString(1)
            ProfesorBuscado.Apellidos = Lector.GetString(2)
            ProfesorBuscado.Departamento = Lector.GetString(3)

        End If

        ' Cerrar el lector de datos
        Lector.Close()

        ' Devolver el objeto ProfesorBuscado con los datos obtenidos
        Return ProfesorBuscado

    End Function

    ''' <summary>
    ''' Agrega un nuevo profesor a la base de datos.
    ''' </summary>
    ''' <param name="Profesor">El objeto Profesor que contiene los datos del nuevo profesor a agregar.</param>
    Public Sub AgregarProfesor(Profesor As Profesor)

        ' Consulta SQL para insertar un nuevo registro en la tabla de Profesores con los datos del nuevo profesor
        Dim Insert As String = "Insert into Profesores (Nombre, Apellidos, Departamento) values (@Nombre, @Apellidos, @Departamento)"

        ' Crear un nuevo comando SQLite con la consulta y la conexión existente
        Dim Comando = New SQLiteCommand(Insert, Conexion)

        AdaptadorDatosProfesores.InsertCommand = Comando

        ' Agregar los parámetros necesarios al comando
        Comando.Parameters.AddWithValue("@Nombre", Profesor.Nombre)
        Comando.Parameters.AddWithValue("@Apellidos", Profesor.Apellidos)
        Comando.Parameters.AddWithValue("@Departamento", Profesor.Departamento)

        ' Ejecutar el comando para insertar el nuevo profesor en la base de datos
        Comando.ExecuteNonQuery()

    End Sub

    ''' <summary>
    ''' Modifica los datos de un profesor existente en la base de datos.
    ''' </summary>
    ''' <param name="Profesor">El objeto Profesor con los datos actualizados del profesor.</param>
    Public Sub ModificarProfesor(Profesor As Profesor)

        ' Consulta SQL para actualizar los datos del profesor en la tabla de Profesores
        Dim Update As String = "update Profesores set Nombre = @Nombre, Apellidos = @Apellidos, Departamento = @Departamento where Id = @Id"

        ' Crear un nuevo comando SQLite con la consulta y la conexión existente
        Dim Comando = New SQLiteCommand(Update, Conexion)

        AdaptadorDatosProfesores.UpdateCommand = Comando

        ' Agregar los parámetros necesarios al comando
        Comando.Parameters.AddWithValue("@Nombre", Profesor.Nombre)
        Comando.Parameters.AddWithValue("@Apellidos", Profesor.Apellidos)
        Comando.Parameters.AddWithValue("@Departamento", Profesor.Departamento)
        Comando.Parameters.AddWithValue("@Id", Profesor.Id)

        ' Ejecutar el comando para actualizar los datos del profesor en la base de datos
        Comando.ExecuteNonQuery()

    End Sub

    ''' <summary>
    ''' Elimina un profesor existente de la base de datos.
    ''' </summary>
    ''' <param name="Profesor">El objeto Profesor que representa al profesor a eliminar.</param>
    Public Sub EliminarProfesor(Profesor As Profesor)

        ' Consulta SQL para eliminar al profesor de la tabla de Profesores
        Dim Delete As String = "delete from Profesores where Id = @Id"

        ' Crear un nuevo comando SQLite con la consulta y la conexión existente
        Dim Comando = New SQLiteCommand(Delete, Conexion)

        AdaptadorDatosProfesores.DeleteCommand = Comando

        ' Agregar el parámetro de ID al comando
        Comando.Parameters.AddWithValue("@Id", Profesor.Id)

        ' Ejecutar el comando para eliminar al profesor de la base de datos
        Comando.ExecuteNonQuery()

    End Sub

    '                                       '
    '   GESTION DE LA TABLA DE NOTAS        '
    '                                       '

    ''' <summary>
    ''' Lee todos los datos de la tabla de Notas y los devuelve en un DataSet.
    ''' </summary>
    ''' <returns>Un DataSet que contiene todos los datos de la tabla de Notas.</returns>
    Public Function LeerDatosNotas() As DataSet

        ' Consulta SQL para seleccionar todos los campos de la tabla de Notas
        Dim Query As String = "select Alumno, Asignatura, Nota1, Nota2, Nota3, NotaFinal from Cursa"

        ' Crear un nuevo adaptador de datos SQLite con la consulta y la conexión existente
        Dim AdaptadorDatosNotas As New SQLiteDataAdapter(Query, Conexion)

        ' Limpiar cualquier dato existente en el DataSet
        DatosNotas.Clear()

        ' Llenar el DataSet con los datos obtenidos del adaptador
        AdaptadorDatosNotas.Fill(DatosNotas, "Cursa")

        ' Devolver el DataSet lleno
        Return DatosNotas

    End Function

    ''' <summary>
    ''' Lee los datos de una nota específica en base al ID del alumno y la asignatura y devuelve un objeto Notas.
    ''' </summary>
    ''' <param name="Nota">El objeto Notas con el ID del alumno y la asignatura de la nota a buscar.</param>
    ''' <returns>Un objeto Notas con los datos de la nota buscada.</returns>
    Public Function LeerDatosNotaBuscada(Nota As Nota) As Nota

        ' Consulta SQL para seleccionar los campos de la tabla de Notas donde el ID del alumno y la asignatura coinciden con los proporcionados
        Dim Query As String = "select Alumno, Asignatura, Nota1, Nota2, Nota3, NotaFinal from Cursa where Alumno = @Alumno and Asignatura = @Asignatura"

        ' Crear un nuevo comando SQLite con la consulta y la conexión existente
        Dim Comando As New SQLiteCommand(Query, Conexion)

        ' Agregar los parámetros de ID del alumno y asignatura al comando
        Comando.Parameters.AddWithValue("@Alumno", Nota.Alumno)
        Comando.Parameters.AddWithValue("@Asignatura", Nota.Asignatura)

        ' Ejecutar la consulta y obtener un lector de datos
        Dim Lector As SQLiteDataReader = Comando.ExecuteReader()

        ' Crear un nuevo objeto Notas para almacenar los datos buscados
        Dim NotaBuscada As New Nota

        ' Comprobar si se encontraron datos y, si es así, leerlos y almacenarlos en el objeto NotaBuscada
        If Lector.Read() Then

            NotaBuscada.Alumno = Lector.GetInt32(0)
            NotaBuscada.Asignatura = Lector.GetInt32(1)
            NotaBuscada.Nota1 = Lector.GetFloat(2)
            NotaBuscada.Nota2 = Lector.GetFloat(3)
            NotaBuscada.Nota3 = Lector.GetFloat(4)
            NotaBuscada.NotaFinal = Lector.GetFloat(5)

        End If

        ' Cerrar el lector de datos
        Lector.Close()

        ' Devolver el objeto NotaBuscada con los datos obtenidos
        Return NotaBuscada

    End Function

    ''' <summary>
    ''' Lee todos los datos de las notas asociadas a un alumno específico y los devuelve en un DataSet.
    ''' </summary>
    ''' <param name="IdAlumno">El ID del alumno cuyas notas se desean recuperar.</param>
    ''' <returns>Un DataSet que contiene todos los datos de las notas asociadas al alumno especificado.</returns>
    Public Function LeerDatosNotasAlumno(IdAlumno As Integer) As DataSet

        ' Consulta SQL para seleccionar todos los campos de la tabla de Notas donde el ID del alumno coincide con el proporcionado
        Dim Query As String = "select Alumno, Asignatura, Nota1, Nota2, Nota3, NotaFinal from Cursa where Alumno = @IdAlumno"

        ' Crear un nuevo comando SQLite con la consulta y la conexión existente
        Dim Comando = New SQLiteCommand(Query, Conexion)

        ' Agregar el parámetro de ID del alumno al comando
        Comando.Parameters.AddWithValue("@IdAlumno", IdAlumno)

        ' Crear un nuevo adaptador de datos SQLite con el comando
        Dim Adaptador = New SQLiteDataAdapter(Comando)

        ' Crear un nuevo DataSet para almacenar los datos de las notas del alumno
        Dim DatosNotasAlumno As New DataSet()

        ' Limpiar cualquier dato existente en el DataSet
        DatosNotasAlumno.Clear()

        ' Llenar el DataSet con los datos obtenidos del adaptador
        Adaptador.Fill(DatosNotasAlumno, "NotasAlumno")

        ' Devolver el DataSet lleno
        Return DatosNotasAlumno

    End Function

    ''' <summary>
    ''' Lee todos los datos de las notas asociadas a una asignatura específica y los devuelve en un DataSet.
    ''' </summary>
    ''' <param name="IdAsignatura">El ID de la asignatura cuyas notas se desean recuperar.</param>
    ''' <returns>Un DataSet que contiene todos los datos de las notas asociadas a la asignatura especificada.</returns>
    Public Function LeerDatosNotasAsignatura(IdAsignatura As Integer) As DataSet

        ' Consulta SQL para seleccionar todos los campos de la tabla de Notas donde el ID de la asignatura coincide con el proporcionado
        Dim Query As String = "select Alumno, Asignatura, Nota1, Nota2, Nota3, NotaFinal from Cursa where Asignatura = @IdAsignatura"

        ' Crear un nuevo comando SQLite con la consulta y la conexión existente
        Dim Comando = New SQLiteCommand(Query, Conexion)

        ' Agregar el parámetro de ID de la asignatura al comando
        Comando.Parameters.AddWithValue("@IdAsignatura", IdAsignatura)

        ' Crear un nuevo adaptador de datos SQLite con el comando
        Dim Adaptador = New SQLiteDataAdapter(Comando)

        ' Crear un nuevo DataSet para almacenar los datos de las notas de la asignatura
        Dim DatosNotasAsignatura As New DataSet()

        ' Limpiar cualquier dato existente en el DataSet
        DatosNotasAsignatura.Clear()

        ' Llenar el DataSet con los datos obtenidos del adaptador
        Adaptador.Fill(DatosNotasAsignatura, "NotasAsignatura")

        ' Devolver el DataSet lleno
        Return DatosNotasAsignatura

    End Function


    ''' <summary>
    ''' Agrega una nueva nota a la base de datos.
    ''' </summary>
    ''' <param name="Nota">El objeto Notas que contiene los datos de la nueva nota a agregar.</param>
    Public Sub AgregarNota(Nota As Nota)

        ' Consulta SQL para insertar un nuevo registro en la tabla de Notas con los datos de la nueva nota
        Dim Insert As String = "Insert into Cursa (Alumno, Asignatura, Nota1, Nota2, Nota3, NotaFinal) values (@Alumno, @Asignatura, @Nota1, @Nota2, @Nota3, @NotaFinal)"

        ' Crear un nuevo comando SQLite con la consulta y la conexión existente
        Dim Comando = New SQLiteCommand(Insert, Conexion)

        ' Agregar los parámetros necesarios al comando
        Comando.Parameters.AddWithValue("@Alumno", Nota.Alumno)
        Comando.Parameters.AddWithValue("@Asignatura", Nota.Asignatura)
        Comando.Parameters.AddWithValue("@Nota1", Nota.Nota1)
        Comando.Parameters.AddWithValue("@Nota2", Nota.Nota2)
        Comando.Parameters.AddWithValue("@Nota3", Nota.Nota3)
        Comando.Parameters.AddWithValue("@NotaFinal", Nota.NotaFinal)

        ' Ejecutar el comando para insertar la nueva nota en la base de datos
        Comando.ExecuteNonQuery()

    End Sub

    ''' <summary>
    ''' Modifica los datos de una nota existente en la base de datos.
    ''' </summary>
    ''' <param name="Nota">El objeto Notas con los datos actualizados de la nota.</param>
    Public Sub ModificarNota(Nota As Nota)

        ' Consulta SQL para actualizar los datos de la nota en la tabla de Notas
        Dim Update As String = "update Cursa set Nota1 = @Nota1, Nota2 = @Nota2, Nota3 = @Nota3, NotaFinal = @NotaFinal where Alumno = @Alumno and Asignatura = @Asignatura"

        ' Crear un nuevo comando SQLite con la consulta y la conexión existente
        Dim Comando = New SQLiteCommand(Update, Conexion)

        ' Agregar los parámetros necesarios al comando
        Comando.Parameters.AddWithValue("@Nota1", Nota.Nota1)
        Comando.Parameters.AddWithValue("@Nota2", Nota.Nota2)
        Comando.Parameters.AddWithValue("@Nota3", Nota.Nota3)
        Comando.Parameters.AddWithValue("@NotaFinal", Nota.NotaFinal)
        Comando.Parameters.AddWithValue("@Alumno", Nota.Alumno)
        Comando.Parameters.AddWithValue("@Asignatura", Nota.Asignatura)

        ' Ejecutar el comando para actualizar los datos de la nota en la base de datos
        Comando.ExecuteNonQuery()

    End Sub

    ''' <summary>
    ''' Elimina una nota existente de la base de datos.
    ''' </summary>
    ''' <param name="Nota">El objeto Notas que representa la nota a eliminar.</param>
    Public Sub EliminarNota(Nota As Nota)

        ' Consulta SQL para eliminar la nota de la tabla de Notas
        Dim Delete As String = "delete from Cursa where Alumno = @Alumno and Asignatura = @Asignatura"

        ' Crear un nuevo comando SQLite con la consulta y la conexión existente
        Dim Comando = New SQLiteCommand(Delete, Conexion)

        ' Agregar los parámetros necesarios al comando
        Comando.Parameters.AddWithValue("@Alumno", Nota.Alumno)
        Comando.Parameters.AddWithValue("@Asignatura", Nota.Asignatura)

        ' Ejecutar el comando para eliminar la nota de la base de datos
        Comando.ExecuteNonQuery()

    End Sub

End Module