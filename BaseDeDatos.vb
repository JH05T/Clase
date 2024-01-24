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

    Public Function LeerDatosAlumnos() As DataSet

        Dim Query As String = "select Id, Nombre, Apellidos, Direccion, Localidad, Movil, Email, FechaNacimiento, Nacionalidad from Alumnos"

        Dim AdaptadorDatosAlumnos As SQLiteDataAdapter = New SQLiteDataAdapter(Query, Conexion)

        Dim DatosAlumnos As DataSet = New DataSet

        AdaptadorDatosAlumnos.Fill(DatosAlumnos, “Alumnos")

        Return DatosAlumnos

    End Function

End Module
