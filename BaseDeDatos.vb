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

    Public Sub CargarAlumnos()

        Dim Query As String = "select Id, Nombre, Apellidos, Direccion, Localidad, Movil, Email, FechaNacimiento, Nacionalidad from Alumnos"

        Dim AdaptadorDatosAlumnos As SQLiteDataAdapter = New SQLiteDataAdapter(Query, Conexion)

        Dim DatosAlumnos As DataSet = New DataSet

        AdaptadorDatosAlumnos.Fill(DatosAlumnos, “Alumnos")

        Dim ElementoList As ListViewItem

        Alumnos.ListViewAlumnos.Items.Clear()

        Alumnos.ListViewAlumnos.View = View.Details

        Alumnos.ListViewAlumnos.Columns.Add("Id", 25, HorizontalAlignment.Center)
        Alumnos.ListViewAlumnos.Columns.Add("Nombre", 100, HorizontalAlignment.Center)
        Alumnos.ListViewAlumnos.Columns.Add("Apellidos", 150, HorizontalAlignment.Center)
        Alumnos.ListViewAlumnos.Columns.Add("Dirección", 150, HorizontalAlignment.Center)
        Alumnos.ListViewAlumnos.Columns.Add("Localidad", 100, HorizontalAlignment.Center)
        Alumnos.ListViewAlumnos.Columns.Add("Móvil", 75, HorizontalAlignment.Center)
        Alumnos.ListViewAlumnos.Columns.Add("Email", 150, HorizontalAlignment.Center)
        Alumnos.ListViewAlumnos.Columns.Add("F. Nacimiento", 90, HorizontalAlignment.Center)
        Alumnos.ListViewAlumnos.Columns.Add("Nacionalidad", 100, HorizontalAlignment.Center)

        For pos As Integer = 0 To DatosAlumnos.Tables(0).Rows.Count - 1

            ElementoList = Alumnos.ListViewAlumnos.Items.Add(DatosAlumnos.Tables(0).Rows(pos).Item(0))

            ElementoList.SubItems.Add(DatosAlumnos.Tables(0).Rows(pos).Item(1))
            ElementoList.SubItems.Add(DatosAlumnos.Tables(0).Rows(pos).Item(2))
            ElementoList.SubItems.Add(DatosAlumnos.Tables(0).Rows(pos).Item(3))
            ElementoList.SubItems.Add(DatosAlumnos.Tables(0).Rows(pos).Item(4))
            ElementoList.SubItems.Add(DatosAlumnos.Tables(0).Rows(pos).Item(5))
            ElementoList.SubItems.Add(DatosAlumnos.Tables(0).Rows(pos).Item(6))
            ElementoList.SubItems.Add(DatosAlumnos.Tables(0).Rows(pos).Item(7))
            ElementoList.SubItems.Add(DatosAlumnos.Tables(0).Rows(pos).Item(8))

        Next

    End Sub

End Module
