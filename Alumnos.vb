Imports System.ComponentModel
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Alumnos

    Dim indiceListView As Integer = 0

    Private Sub Alumnos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CargarListView(BaseDeDatos.LeerDatosAlumnos())

        For i As Integer = 0 To 31

            ComboBoxDiaFechaNacimiento.Items.Add(i)

        Next

        For i As Integer = 0 To 12

            ComboBoxMesFechaNacimiento.Items.Add(i)

        Next


    End Sub

    Private Sub ListView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView.SelectedIndexChanged

        Dim FechaNacimiento As DateOnly

        If ListView.SelectedItems.Count > 0 Then

            Dim indiceSeleccionado As Integer = ListView.SelectedIndices(0)
            indiceListView = indiceSeleccionado
            Dim itemSeleccionado = ListView.Items.Item(indiceSeleccionado)

            TextBoxId.Text = itemSeleccionado.SubItems(1).Text
            TextBoxNombre.Text = itemSeleccionado.SubItems(2).Text
            TextBoxApellidos.Text = itemSeleccionado.SubItems(3).Text
            TextBoxDireccion.Text = itemSeleccionado.SubItems(4).Text
            TextBoxLocalidad.Text = itemSeleccionado.SubItems(5).Text
            TextBoxMovil.Text = itemSeleccionado.SubItems(6).Text
            TextBoxEmail.Text = itemSeleccionado.SubItems(7).Text

            If DateOnly.TryParse(itemSeleccionado.SubItems(8).Text, FechaNacimiento) Then

                ComboBoxDiaFechaNacimiento.Text = FechaNacimiento.Day.ToString
                ComboBoxMesFechaNacimiento.Text = FechaNacimiento.Month.ToString
                TextBoxFechaNacimiento.Text = FechaNacimiento.Year.ToString

            Else

            End If

            TextBoxNacionalidad.Text = itemSeleccionado.SubItems(9).Text

        End If

    End Sub

    Private Sub ButtonSiguiente_Click(sender As Object, e As EventArgs) Handles ButtonSiguiente.Click

        If indiceListView < ListView.Items.Count - 1 Then

            indiceListView += 1

            MsgBox(indiceListView)

            ListView.Items(indiceListView).Selected = True

        End If

    End Sub

    Private Sub ButtonAnterior_Click(sender As Object, e As EventArgs) Handles ButtonAnterior.Click

        If indiceListView > 0 Then

            indiceListView -= 1

            ListView.Items(indiceListView).Selected = True

        End If

    End Sub

    Private Sub Alumnos_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing

        Inicio.Close()

    End Sub

    Private Sub CargarListView(DatosAlumnos As DataSet)

        Dim ElementoList As ListViewItem

        ListView.Items.Clear()

        ListView.View = View.Details

        ListView.Columns.Add("", 0, HorizontalAlignment.Center)
        ListView.Columns.Add("Id", 25, HorizontalAlignment.Center)
        ListView.Columns.Add("Nombre", 100, HorizontalAlignment.Center)
        ListView.Columns.Add("Apellidos", 150, HorizontalAlignment.Center)
        ListView.Columns.Add("Dirección", 150, HorizontalAlignment.Center)
        ListView.Columns.Add("Localidad", 100, HorizontalAlignment.Center)
        ListView.Columns.Add("Móvil", 75, HorizontalAlignment.Center)
        ListView.Columns.Add("Email", 150, HorizontalAlignment.Center)
        ListView.Columns.Add("F. Nacimiento", 90, HorizontalAlignment.Center)
        ListView.Columns.Add("Nacionalidad", 100, HorizontalAlignment.Center)

        For pos As Integer = 0 To DatosAlumnos.Tables(0).Rows.Count - 1

            ElementoList = ListView.Items.Add(DatosAlumnos.Tables(0).Rows(pos).Item(0))

            ElementoList.SubItems.Add(DatosAlumnos.Tables(0).Rows(pos).Item(0))
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

End Class
