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

            ' Actualiza la base de datos con los cambios en el DataSet
            ActualizarDB(DatosAsignaturas, AdaptadorDatosAsignaturas, "Asignaturas")
            ActualizarDB(DatosProfesores, AdaptadorDatosProfesores, "Profesores")

            Conexion.Close()

        Else

            ' Muestra un mensaje si la conexión no está abierta
            MsgBox("No se puede cerrar")

        End If

    End Sub

    Public Sub ActualizarDB(Datos As DataSet, Adaptador As SQLiteDataAdapter, Tabla As String)

        Try

            If Datos.HasChanges() Then

                Dim NuevosDatos = Datos.GetChanges()

                If Datos.HasErrors() Then

                    Datos.RejectChanges()

                Else

                    Adaptador.Update(NuevosDatos, Tabla)

                    Datos.AcceptChanges()

                End If

            End If

        Catch ex As Exception

        End Try

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

        ' Establece la clave primaria del DataTable
        DatosAlumnos.Tables("Alumnos").PrimaryKey = New DataColumn() {DatosAlumnos.Tables("Alumnos").Columns("Id")}

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
    ' Crea un id temporal para los nuevos alumnos
    Public Function AgregarAlumno(Alumno As Alumno) As DataSet

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

        ' Agrega el nuevo alumno al DataSet
        Dim fila = DatosAlumnos.Tables("Alumnos").NewRow()
        fila("id") = 0
        fila("Nombre") = Alumno.Nombre
        fila("Apellidos") = Alumno.Apellidos
        fila("Direccion") = Alumno.Direccion
        fila("Localidad") = Alumno.Localidad
        fila("Movil") = Alumno.Movil
        fila("Email") = Alumno.Email
        fila("FechaNacimiento") = Alumno.FechaNacimiento.ToString("yyyy-MM-dd")
        fila("Nacionalidad") = Alumno.Nacionalidad
        DatosAlumnos.Tables("Alumnos").Rows.Add(fila)

        ' Actualiza la base de datos con los cambios en el DataSet
        ActualizarDB(DatosAlumnos, AdaptadorDatosAlumnos, "Alumnos")

        DatosAlumnos.Clear()

        AdaptadorDatosAlumnos.Fill(DatosAlumnos, "Alumnos")

        Return DatosAlumnos

    End Function

    ''' <summary>
    ''' Modifica los datos de un alumno en el DataSet.
    ''' </summary>
    ''' <param name="Alumno">El objeto Alumno con los datos modificados.</param>
    Public Function ModificarAlumno(Alumno As Alumno) As DataSet

        ' Consulta SQL para actualizar un registro existente en la tabla Alumnos
        Dim Update As String = "Update Alumnos set Nombre = @Nombre, Apellidos = @Apellidos, Direccion = @Direccion, Localidad = @Localidad, Movil = @Movil, Email = @Email, FechaNacimiento = @FechaNacimiento, Nacionalidad = @Nacionalidad where Id = @Id"

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

        ' Busca la fila del alumno en el DataSet
        Dim fila = DatosAlumnos.Tables("Alumnos").Rows.Find(Alumno.Id)

        ' Si la fila existe, modifica los datos del alumno
        If fila IsNot Nothing Then

            fila("Nombre") = Alumno.Nombre
            fila("Apellidos") = Alumno.Apellidos
            fila("Direccion") = Alumno.Direccion
            fila("Localidad") = Alumno.Localidad
            fila("Movil") = Alumno.Movil
            fila("Email") = Alumno.Email
            fila("FechaNacimiento") = Alumno.FechaNacimiento.ToString("yyyy-MM-dd")
            fila("Nacionalidad") = Alumno.Nacionalidad

        End If

        ' Actualiza la base de datos con los cambios en el DataSet
        ActualizarDB(DatosAlumnos, AdaptadorDatosAlumnos, "Alumnos")

        DatosAlumnos.Clear()

        AdaptadorDatosAlumnos.Fill(DatosAlumnos, "Alumnos")

        Return DatosAlumnos

    End Function

    ''' <summary>
    ''' Elimina un alumno del DataSet.
    ''' </summary>
    ''' <param name="Alumno">El objeto Alumno que se va a eliminar.</param>
    Public Function EliminarAlumno(Alumno As Alumno) As DataSet

        ' Consulta SQL para eliminar un registro de la tabla Alumnos
        Dim Delete As String = "delete from Alumnos where Id = @Id"

        ' Crea un comando SQLite con la consulta y los parámetros necesarios
        Dim Comando = New SQLiteCommand(Delete, Conexion)

        AdaptadorDatosAlumnos.DeleteCommand = Comando

        Comando.Parameters.AddWithValue("@Id", Alumno.Id)

        ' Busca la fila del alumno en el DataSet
        Dim fila = DatosAlumnos.Tables("Alumnos").Rows.Find(Alumno.Id)

        ' Si la fila existe, elimina al alumno del DataSet
        If fila IsNot Nothing Then

            fila.Delete()

        End If

        ' Actualiza la base de datos con los cambios en el DataSet
        ActualizarDB(DatosAlumnos, AdaptadorDatosAlumnos, "Alumnos")

        DatosAlumnos.Clear()

        AdaptadorDatosAlumnos.Fill(DatosAlumnos, "Alumnos")

        Return DatosAlumnos

    End Function

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

        ' Establece la clave primaria del DataTable
        DatosAsignaturas.Tables("Asignaturas").PrimaryKey = New DataColumn() {DatosAsignaturas.Tables("Asignaturas").Columns("Id")}

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
    Public Function AgregarAsignatura(Asignatura As Asignatura) As DataSet

        ' Consulta SQL para insertar un nuevo registro en la tabla Asignaturas
        Dim Insert As String = "Insert into Asignaturas (Nombre, Aula, Profesor) values (@Nombre, @Aula, @Profesor)"

        ' Crea un comando SQLite con la consulta y los parámetros necesarios
        Dim Comando = New SQLiteCommand(Insert, Conexion)

        AdaptadorDatosAsignaturas.InsertCommand = Comando

        ' Agregar los parámetros necesarios al comando
        Comando.Parameters.AddWithValue("@Nombre", Asignatura.Nombre)
        Comando.Parameters.AddWithValue("@Aula", Asignatura.Aula)
        Comando.Parameters.AddWithValue("@Profesor", Asignatura.Profesor)

        ' Agrega la nueva asignatura al DataSet
        Dim fila = DatosAsignaturas.Tables("Asignaturas").NewRow()
        fila("id") = 0
        fila("Nombre") = Asignatura.Nombre
        fila("Aula") = Asignatura.Aula
        fila("Profesor") = Asignatura.Profesor
        DatosAsignaturas.Tables("Asignaturas").Rows.Add(fila)

        ' Actualiza la base de datos con los cambios en el DataSet
        ActualizarDB(DatosAsignaturas, AdaptadorDatosAsignaturas, "Asignaturas")

        DatosAsignaturas.Clear()

        AdaptadorDatosAlumnos.Fill(DatosAsignaturas, "Asignaturas")

        Return DatosAsignaturas

    End Function

    ''' <summary>
    ''' Modifica los datos de una asignatura en el DataSet.
    ''' </summary>
    ''' <param name="Asignatura">El objeto Asignatura con los datos modificados.</param>
    Public Function ModificarAsignatura(Asignatura As Asignatura) As DataSet

        ' Consulta SQL para actualizar un registro existente en la tabla Asignaturas
        Dim Update As String = "Update Asignaturas set Nombre = @Nombre, Aula = @Aula, Profesor = @Profesor where Id = @Id"

        ' Crea un comando SQLite con la consulta y los parámetros necesarios
        Dim Comando = New SQLiteCommand(Update, Conexion)

        AdaptadorDatosAsignaturas.UpdateCommand = Comando

        ' Agregar los parámetros necesarios al comando
        Comando.Parameters.AddWithValue("@Nombre", Asignatura.Nombre)
        Comando.Parameters.AddWithValue("@Aula", Asignatura.Aula)
        Comando.Parameters.AddWithValue("@Profesor", Asignatura.Profesor)
        Comando.Parameters.AddWithValue("@Id", Asignatura.Id)

        ' Busca la fila de la asignatura en el DataSet
        Dim fila = DatosAsignaturas.Tables("Asignaturas").Rows.Find(Asignatura.Id)

        ' Si la fila existe, modifica los datos de la asignatura
        If fila IsNot Nothing Then

            fila("Nombre") = Asignatura.Nombre
            fila("Aula") = Asignatura.Aula
            fila("Profesor") = Asignatura.Profesor

        End If

        ' Actualiza la base de datos con los cambios en el DataSet
        ActualizarDB(DatosAsignaturas, AdaptadorDatosAsignaturas, "Asignaturas")

        DatosAsignaturas.Clear()

        AdaptadorDatosAsignaturas.Fill(DatosAsignaturas, "Asignaturas")

        Return DatosAsignaturas

    End Function

    ''' <summary>
    ''' Elimina una asignatura del DataSet.
    ''' </summary>
    ''' <param name="Asignatura">El objeto Asignatura que se va a eliminar.</param>
    Public Function EliminarAsignatura(Asignatura As Asignatura) As DataSet

        ' Consulta SQL para eliminar un registro de la tabla Asignaturas
        Dim Delete As String = "delete from Asignaturas where Id = @Id"

        ' Crea un comando SQLite con la consulta y los parámetros necesarios
        Dim Comando = New SQLiteCommand(Delete, Conexion)

        AdaptadorDatosAsignaturas.DeleteCommand = Comando

        ' Agregar el parámetro de ID al comando
        Comando.Parameters.AddWithValue("@Id", Asignatura.Id)

        ' Busca la fila de la asignatura en el DataSet
        Dim fila = DatosAsignaturas.Tables("Asignaturas").Rows.Find(Asignatura.Id)

        ' Si la fila existe, elimina la asignatura del DataSet
        If fila IsNot Nothing Then

            fila.Delete()

        End If

        ' Actualiza la base de datos con los cambios en el DataSet
        ActualizarDB(DatosAsignaturas, AdaptadorDatosAsignaturas, "Asignaturas")

        DatosAsignaturas.Clear()

        AdaptadorDatosAsignaturas.Fill(DatosAsignaturas, "Asignaturas")

        Return DatosAsignaturas

    End Function


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

        ' Establece la clave primaria del DataTable
        DatosProfesores.Tables("Profesores").PrimaryKey = New DataColumn() {DatosProfesores.Tables("Profesores").Columns("Id")}

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
    Public Function AgregarProfesor(Profesor As Profesor) As DataSet

        ' Consulta SQL para insertar un nuevo registro en la tabla Profesores
        Dim Insert As String = "Insert into Profesores (Nombre, Apellidos, Departamento) values (@Nombre, @Apellidos, @Departamento)"

        ' Crea un comando SQLite con la consulta y los parámetros necesarios
        Dim Comando = New SQLiteCommand(Insert, Conexion)

        AdaptadorDatosProfesores.InsertCommand = Comando

        ' Agregar los parámetros necesarios al comando
        Comando.Parameters.AddWithValue("@Nombre", Profesor.Nombre)
        Comando.Parameters.AddWithValue("@Apellidos", Profesor.Apellidos)
        Comando.Parameters.AddWithValue("@Departamento", Profesor.Departamento)

        ' Agrega el nuevo profesor al DataSet
        Dim fila = DatosProfesores.Tables("Profesores").NewRow()
        fila("id") = 0
        fila("Nombre") = Profesor.Nombre
        fila("Apellidos") = Profesor.Apellidos
        fila("Departamento") = Profesor.Departamento
        DatosProfesores.Tables("Profesores").Rows.Add(fila)

        ' Actualiza la base de datos con los cambios en el DataSet
        ActualizarDB(DatosProfesores, AdaptadorDatosProfesores, "Profesores")

        DatosProfesores.Clear()

        AdaptadorDatosAlumnos.Fill(DatosProfesores, "Profesores")

        Return DatosProfesores

    End Function

    ''' <summary>
    ''' Modifica los datos de un profesor en el DataSet.
    ''' </summary>
    ''' <param name="Profesor">El objeto Profesor con los datos modificados.</param>
    Public Function ModificarProfesor(Profesor As Profesor) As DataSet

        ' Consulta SQL para actualizar un registro existente en la tabla Profesores
        Dim Update As String = "Update Profesores set Nombre = @Nombre, Apellidos = @Apellidos, Departamento = @Departamento where Id = @Id"

        ' Crea un comando SQLite con la consulta y los parámetros necesarios
        Dim Comando = New SQLiteCommand(Update, Conexion)

        AdaptadorDatosProfesores.UpdateCommand = Comando

        ' Agregar los parámetros necesarios al comando
        Comando.Parameters.AddWithValue("@Nombre", Profesor.Nombre)
        Comando.Parameters.AddWithValue("@Apellidos", Profesor.Apellidos)
        Comando.Parameters.AddWithValue("@Departamento", Profesor.Departamento)
        Comando.Parameters.AddWithValue("@Id", Profesor.Id)

        ' Busca la fila del profesor en el DataSet
        Dim fila = DatosProfesores.Tables("Profesores").Rows.Find(Profesor.Id)

        ' Si la fila existe, modifica los datos del profesor
        If fila IsNot Nothing Then

            fila("Nombre") = Profesor.Nombre
            fila("Apellidos") = Profesor.Apellidos
            fila("Departamento") = Profesor.Departamento

        End If

        ' Actualiza la base de datos con los cambios en el DataSet
        ActualizarDB(DatosProfesores, AdaptadorDatosProfesores, "Profesores")

        DatosProfesores.Clear()

        AdaptadorDatosProfesores.Fill(DatosProfesores, "Profesores")

        Return DatosProfesores

    End Function

    ''' <summary>
    ''' Elimina un profesor del DataSet.
    ''' </summary>
    ''' <param name="Profesor">El objeto Profesor que se va a eliminar.</param>
    Public Function EliminarProfesor(Profesor As Profesor) As DataSet

        ' Consulta SQL para eliminar un registro de la tabla Profesores
        Dim Delete As String = "delete from Profesores where Id = @Id"

        ' Crea un comando SQLite con la consulta y los parámetros necesarios
        Dim Comando = New SQLiteCommand(Delete, Conexion)

        AdaptadorDatosProfesores.DeleteCommand = Comando

        ' Agregar el parámetro de ID al comando
        Comando.Parameters.AddWithValue("@Id", Profesor.Id)

        ' Busca la fila del profesor en el DataSet
        Dim fila = DatosProfesores.Tables("Profesores").Rows.Find(Profesor.Id)

        ' Si la fila existe, elimina al profesor del DataSet
        If fila IsNot Nothing Then

            fila.Delete()

        End If

        ' Actualiza la base de datos con los cambios en el DataSet
        ActualizarDB(DatosProfesores, AdaptadorDatosProfesores, "Profesores")

        DatosProfesores.Clear()

        AdaptadorDatosProfesores.Fill(DatosProfesores, "Profesores")

        Return DatosProfesores

    End Function

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

        ' Establece la clave primaria del DataTable
        DatosNotas.Tables("Cursa").PrimaryKey = New DataColumn() {DatosNotas.Tables("Cursa").Columns("Asignatura"), DatosNotas.Tables("Cursa").Columns("Alumno")}

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
            NotaBuscada.Nota1 = Math.Round(Lector.GetFloat(2), 2)
            NotaBuscada.Nota2 = Math.Round(Lector.GetFloat(3), 2)
            NotaBuscada.Nota3 = Math.Round(Lector.GetFloat(4), 2)
            NotaBuscada.NotaFinal = Math.Round(Lector.GetFloat(5), 2)

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

        ' Establece la clave primaria del DataTable
        DatosNotas.Tables("Cursa").PrimaryKey = New DataColumn() {DatosNotas.Tables("Cursa").Columns("Asignatura"), DatosNotas.Tables("Cursa").Columns("Alumno")}

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

        ' Establece la clave primaria del DataTable
        DatosNotas.Tables("Cursa").PrimaryKey = New DataColumn() {DatosNotas.Tables("Cursa").Columns("Asignatura"), DatosNotas.Tables("Cursa").Columns("Alumno")}

        ' Devolver el DataSet lleno
        Return DatosNotasAsignatura

    End Function


    ''' <summary>
    ''' Agrega una nueva nota a la base de datos.
    ''' </summary>
    ''' <param name="Nota">El objeto Notas que contiene los datos de la nueva nota a agregar.</param>
    Public Function AgregarNota(Nota As Nota) As DataSet

        ' Consulta SQL para insertar un nuevo registro en la tabla Notas
        Dim Insert As String = "Insert into Cursa (Alumno, Asignatura, Nota1, Nota2, Nota3, NotaFinal) values (@Alumno, @Asignatura, @Nota1, @Nota2, @Nota3, @NotaFinal)"

        ' Crea un comando SQLite con la consulta y los parámetros necesarios
        Dim Comando = New SQLiteCommand(Insert, Conexion)
        AdaptadorDatosNotas.InsertCommand = Comando

        ' Agregar los parámetros necesarios al comando
        Comando.Parameters.AddWithValue("@Alumno", Nota.Alumno)
        Comando.Parameters.AddWithValue("@Asignatura", Nota.Asignatura)
        Comando.Parameters.AddWithValue("@Nota1", Nota.Nota1)
        Comando.Parameters.AddWithValue("@Nota2", Nota.Nota2)
        Comando.Parameters.AddWithValue("@Nota3", Nota.Nota3)
        Comando.Parameters.AddWithValue("@NotaFinal", Nota.NotaFinal)

        ' Agrega la nueva nota al DataSet
        Dim fila = DatosNotas.Tables("Cursa").NewRow()
        fila("Alumno") = Nota.Alumno
        fila("Asignatura") = Nota.Asignatura
        fila("Nota1") = Nota.Nota1
        fila("Nota2") = Nota.Nota2
        fila("Nota3") = Nota.Nota3
        fila("NotaFinal") = Nota.NotaFinal
        DatosNotas.Tables("Cursa").Rows.Add(fila)

        ' Actualiza la base de datos con los cambios en el DataSet
        ActualizarDB(DatosNotas, AdaptadorDatosNotas, "Cursa")

        DatosNotas.Clear()

        AdaptadorDatosNotas.Fill(DatosNotas, "Cursa")

        Return DatosNotas

    End Function

    ''' <summary>
    ''' Modifica los datos de una nota en el DataSet.
    ''' </summary>
    ''' <param name="Nota">El objeto Nota con los datos modificados.</param>
    Public Function ModificarNota(Nota As Nota) As DataSet

        ' Consulta SQL para actualizar un registro existente en la tabla Cursa
        Dim Update As String = "Update Cursa set Nota1 = @Nota1, Nota2 = @Nota2, Nota3 = @Nota3, NotaFinal = @NotaFinal where Alumno = @Alumno and Asignatura = @Asignatura"

        ' Crea un comando SQLite con la consulta y los parámetros necesarios
        Dim Comando = New SQLiteCommand(Update, Conexion)
        AdaptadorDatosNotas.UpdateCommand = Comando

        ' Agregar los parámetros necesarios al comando
        Comando.Parameters.AddWithValue("@Nota1", Nota.Nota1)
        Comando.Parameters.AddWithValue("@Nota2", Nota.Nota2)
        Comando.Parameters.AddWithValue("@Nota3", Nota.Nota3)
        Comando.Parameters.AddWithValue("@NotaFinal", Nota.NotaFinal)
        Comando.Parameters.AddWithValue("@Alumno", Nota.Alumno)
        Comando.Parameters.AddWithValue("@Asignatura", Nota.Asignatura)

        ' Busca la fila de la nota en el DataSet
        Dim fila = DatosNotas.Tables("Cursa").Rows.Find(New Object() {Nota.Alumno, Nota.Asignatura})

        ' Si la fila existe, modifica los datos de la nota
        If fila IsNot Nothing Then

            fila("Nota1") = Nota.Nota1
            fila("Nota2") = Nota.Nota2
            fila("Nota3") = Nota.Nota3
            fila("NotaFinal") = Nota.NotaFinal

        End If

        ' Actualiza la base de datos con los cambios en el DataSet
        ActualizarDB(DatosNotas, AdaptadorDatosNotas, "Cursa")

        DatosNotas.Clear()

        AdaptadorDatosNotas.Fill(DatosNotas, "Cursa")

        Return DatosNotas

    End Function

    ''' <summary>
    ''' Elimina una nota del DataSet.
    ''' </summary>
    ''' <param name="Nota">El objeto Nota que se va a eliminar.</param>
    Public Function EliminarNota(Nota As Nota) As DataSet

        ' Consulta SQL para eliminar un registro de la tabla Cursa
        Dim Delete As String = "delete from Cursa where Alumno = @Alumno and Asignatura = @Asignatura"

        ' Crea un comando SQLite con la consulta y los parámetros necesarios
        Dim Comando = New SQLiteCommand(Delete, Conexion)

        AdaptadorDatosNotas.DeleteCommand = Comando

        Comando.Parameters.AddWithValue("@Alumno", Nota.Alumno)
        Comando.Parameters.AddWithValue("@Asignatura", Nota.Asignatura)

        ' Busca la fila de la nota en el DataSet
        Dim fila = DatosNotas.Tables("Cursa").Rows.Find(New Object() {Nota.Alumno, Nota.Asignatura})

        ' Si la fila existe, elimina la nota del DataSet
        If fila IsNot Nothing Then

            fila.Delete()

        End If

        ' Actualiza la base de datos con los cambios en el DataSet
        ActualizarDB(DatosNotas, AdaptadorDatosNotas, "Cursa")

        DatosNotas.Clear()

        AdaptadorDatosNotas.Fill(DatosNotas, "Cursa")

        Return DatosNotas

    End Function

End Module