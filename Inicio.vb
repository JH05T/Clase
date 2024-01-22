Imports System.ComponentModel

Public Class Inicio

    Private Sub Inicio_Load(sender As Object, e As EventArgs) Handles Me.Load

        BaseDeDatos.Conectar()

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

    Private Sub Inicio_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        Conexion.Close()

        MsgBox("D")

    End Sub

End Class