Imports System.ComponentModel

Public Class Inicio

    Private Sub Inicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        BaseDeDatos.Conectar()

        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MinimizeBox = False
        Me.MaximizeBox = False

        ConfigurarColores()

    End Sub

    Private Sub ButtonAlumnos_Click(sender As Object, e As EventArgs) Handles ButtonAlumnos.Click

        Alumnos.Show()

        Me.Hide()

    End Sub

    Private Sub ButtonAsignaturas_Click(sender As Object, e As EventArgs) Handles ButtonAsignaturas.Click

        Asignaturas.Show()

        Me.Hide()

    End Sub

    Private Sub ButtonNotas_Click(sender As Object, e As EventArgs) Handles ButtonNotas.Click

        Notas.Show()

        Me.Hide()

    End Sub

    Private Sub ButtonProfesores_Click(sender As Object, e As EventArgs) Handles ButtonProfesores.Click

        Profesores.Show()

        Me.Hide()

    End Sub

    Private Sub Inicio_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing

        BaseDeDatos.Desconectar()

        Application.Exit()

    End Sub

    Private Sub ConfigurarColores()

        For Each control As Control In Me.Controls

            If TypeOf control Is System.Windows.Forms.Button Then

                DirectCast(control, System.Windows.Forms.Button).BackColor = PaletaColores.AzulLila
                DirectCast(control, System.Windows.Forms.Button).FlatStyle = FlatStyle.Flat

            End If

        Next

    End Sub

End Class