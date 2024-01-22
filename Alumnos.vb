Imports System.ComponentModel

Public Class Alumnos

    Private Sub Alumnos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        BaseDeDatos.CargarAlumnos()

    End Sub

    Private Sub Alumnos_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing

        Application.Exit()

    End Sub

End Class
