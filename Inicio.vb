Imports System.ComponentModel

''' <summary>
''' Clase que representa el formulario de inicio de la aplicación.
''' </summary>
Public Class Inicio

    ''' <summary>
    ''' Evento que se desencadena cuando el formulario se carga inicialmente.
    ''' </summary>
    Private Sub Inicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Se establece la conexión con la base de datos al cargar el formulario.
        BaseDeDatos.Conectar()

        ' Se configura el formulario para que tenga un borde fijo y no se pueda minimizar ni maximizar.
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MinimizeBox = False
        Me.MaximizeBox = False

        ' Se llama al método para configurar los colores de los controles en el formulario.
        ConfigurarColores()

    End Sub

    ''' <summary>
    ''' Evento que se desencadena cuando se hace clic en el botón de Alumnos.
    ''' </summary>
    Private Sub ButtonAlumnos_Click(sender As Object, e As EventArgs) Handles ButtonAlumnos.Click

        ' Se muestra el formulario de Alumnos y se oculta el formulario actual.
        Alumnos.Show()

        Me.Hide()

    End Sub

    ''' <summary>
    ''' Evento que se desencadena cuando se hace clic en el botón de Asignaturas.
    ''' </summary>
    Private Sub ButtonAsignaturas_Click(sender As Object, e As EventArgs) Handles ButtonAsignaturas.Click

        ' Se muestra el formulario de Asignaturas y se oculta el formulario actual.
        Asignaturas.Show()

        Me.Hide()

    End Sub

    ''' <summary>
    ''' Evento que se desencadena cuando se hace clic en el botón de Notas.
    ''' </summary>
    Private Sub ButtonNotas_Click(sender As Object, e As EventArgs) Handles ButtonNotas.Click

        ' Se muestra el formulario de Notas y se oculta el formulario actual.
        Notas.Show()

        Me.Hide()

    End Sub

    ''' <summary>
    ''' Evento que se desencadena cuando se hace clic en el botón de Profesores.
    ''' </summary>
    Private Sub ButtonProfesores_Click(sender As Object, e As EventArgs) Handles ButtonProfesores.Click

        ' Se muestra el formulario de Profesores y se oculta el formulario actual.
        Profesores.Show()

        Me.Hide()

    End Sub

    ''' <summary>
    ''' Evento que se desencadena cuando se intenta cerrar el formulario.
    ''' </summary>
    Private Sub Inicio_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing

        ' Se desconecta de la base de datos y se cierra la aplicación.
        BaseDeDatos.Desconectar()

        Application.Exit()

    End Sub

    ''' <summary>
    ''' Método que configura los colores de los botones en el formulario.
    ''' </summary>
    Private Sub ConfigurarColores()

        For Each control As Control In Me.Controls

            If TypeOf control Is System.Windows.Forms.Button Then

                ' Se establece el color de fondo y el estilo de los botones.
                DirectCast(control, System.Windows.Forms.Button).BackColor = PaletaColores.MarronClaro
                DirectCast(control, System.Windows.Forms.Button).FlatStyle = FlatStyle.Flat

            End If

        Next

    End Sub

End Class