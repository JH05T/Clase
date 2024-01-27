Imports System.ComponentModel
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Alumnos

    Dim indiceListView As Integer = 0
    Dim opcion As String

    Private Sub Alumnos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        VisualizarToolStripMenuItem.PerformClick()

        ConfigurarListView()

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

            ListView.Items(indiceListView).Selected = False

            indiceListView += 1

            ListView.Items(indiceListView).Selected = True

        End If

    End Sub

    Private Sub ButtonAnterior_Click(sender As Object, e As EventArgs) Handles ButtonAnterior.Click

        If indiceListView > 0 Then

            ListView.Items(indiceListView).Selected = False

            indiceListView -= 1

            ListView.Items(indiceListView).Selected = True

        End If

    End Sub

    Private Sub ButtonPrimero_Click(sender As Object, e As EventArgs) Handles ButtonPrimero.Click

        ListView.Items(indiceListView).Selected = False

        indiceListView = 0

        ListView.Items(indiceListView).Selected = True

    End Sub

    Private Sub ButtonUltimo_Click(sender As Object, e As EventArgs) Handles ButtonUltimo.Click

        ListView.Items(indiceListView).Selected = False

        indiceListView = ListView.Items.Count - 1

        ListView.Items(indiceListView).Selected = True

    End Sub

    Private Sub ButtonBuscar_Click(sender As Object, e As EventArgs) Handles ButtonBuscar.Click

        Dim Alumno = BaseDeDatos.LeerDatosAlumnoBuscado(New Alumno With {.Id = TextBoxBuscar.Text})

        If Alumno.Id.Equals(0) Then

            vaciarGroupBoxDatos()

        Else

            TextBoxId.Text = Alumno.Id
            TextBoxNombre.Text = Alumno.Nombre
            TextBoxApellidos.Text = Alumno.Apellidos
            TextBoxDireccion.Text = Alumno.Direccion
            TextBoxLocalidad.Text = Alumno.Localidad
            TextBoxMovil.Text = Alumno.Movil
            TextBoxEmail.Text = Alumno.Email
            ComboBoxDiaFechaNacimiento.Text = Alumno.FechaNacimiento.Day.ToString
            ComboBoxMesFechaNacimiento.Text = Alumno.FechaNacimiento.Month.ToString
            TextBoxFechaNacimiento.Text = Alumno.FechaNacimiento.Year.ToString
            TextBoxNacionalidad.Text = Alumno.Nacionalidad

        End If

    End Sub

    Private Sub ButtonAceptar_Click(sender As Object, e As EventArgs) Handles ButtonAceptar.Click

        Select Case opcion

            Case "Agregar"

                AgregarAlumno()

            Case "Eliminar"

                EliminarAlumno()

            Case "Modificar"

                ModificarAlumno()

            Case "Visualizar"

            Case Else

        End Select

        vaciarGroupBoxDatos()

        CargarListView(BaseDeDatos.LeerDatosAlumnos)

    End Sub

    Private Sub ButtonCancelar_Click(sender As Object, e As EventArgs) Handles ButtonCancelar.Click

        vaciarGroupBoxDatos()

    End Sub

    Private Sub AgregarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarToolStripMenuItem.Click

        AgregarToolStripMenuItem.BackColor = Color.Beige
        EliminarToolStripMenuItem.BackColor = Color.White
        ModificarToolStripMenuItem.BackColor = Color.White
        VisualizarToolStripMenuItem.BackColor = Color.White

        opcion = "Agregar"

        ButtonAceptar.Show()

        ButtonCancelar.Show()

    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click

        EliminarToolStripMenuItem.BackColor = Color.Beige
        AgregarToolStripMenuItem.BackColor = Color.White
        ModificarToolStripMenuItem.BackColor = Color.White
        VisualizarToolStripMenuItem.BackColor = Color.White

        opcion = "Eliminar"

        ButtonAceptar.Show()

        ButtonCancelar.Show()

    End Sub
    Private Sub ModificarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarToolStripMenuItem.Click

        ModificarToolStripMenuItem.BackColor = Color.Beige
        EliminarToolStripMenuItem.BackColor = Color.White
        AgregarToolStripMenuItem.BackColor = Color.White
        VisualizarToolStripMenuItem.BackColor = Color.White

        opcion = "Modificar"

        ButtonAceptar.Show()

        ButtonCancelar.Show()

    End Sub

    Private Sub VisualizarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisualizarToolStripMenuItem.Click

        AgregarToolStripMenuItem.BackColor = Color.White
        EliminarToolStripMenuItem.BackColor = Color.White
        ModificarToolStripMenuItem.BackColor = Color.White
        VisualizarToolStripMenuItem.BackColor = Color.Beige

        opcion = "Visualizar"

        ButtonAceptar.Hide()

        ButtonCancelar.Hide()

    End Sub

    Private Sub Alumnos_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing

        Inicio.Close()

    End Sub

    Private Sub ConfigurarListView()

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

    End Sub

    Private Sub CargarListView(DatosAlumnos As DataSet)

        Dim ElementoList As ListViewItem

        ListView.Items.Clear()

        ListView.View = View.Details

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

    Private Sub vaciarGroupBoxDatos()

        For Each control As Control In GroupBoxRellenarDatos.Controls

            If TypeOf control Is System.Windows.Forms.TextBox Then

                DirectCast(control, System.Windows.Forms.TextBox).Clear()

            ElseIf TypeOf control Is System.Windows.Forms.ComboBox Then

                DirectCast(control, System.Windows.Forms.ComboBox).Text = ""

            End If

        Next

    End Sub

    Private Sub AgregarAlumno()

        Dim Alumno As Alumno = New Alumno With {
            .Nombre = TextBoxNombre.Text,
            .Apellidos = TextBoxApellidos.Text,
            .Direccion = TextBoxDireccion.Text,
            .Localidad = TextBoxLocalidad.Text,
            .Movil = TextBoxMovil.Text,
            .Email = TextBoxEmail.Text,
            .FechaNacimiento = New DateOnly(Integer.Parse(TextBoxFechaNacimiento.Text), Integer.Parse(ComboBoxMesFechaNacimiento.Text), Integer.Parse(ComboBoxDiaFechaNacimiento.Text)),
            .Nacionalidad = TextBoxNacionalidad.Text}

        BaseDeDatos.AgregarAlumno(Alumno)

    End Sub
    Private Sub EliminarAlumno()

        Dim Alumno As Alumno = New Alumno With {
            .Id = TextBoxId.Text}

        BaseDeDatos.EliminarAlumno(Alumno)

    End Sub
    Private Sub ModificarAlumno()

        Dim Alumno As Alumno = New Alumno With {
            .Id = TextBoxId.Text,
            .Nombre = TextBoxNombre.Text,
            .Apellidos = TextBoxApellidos.Text,
            .Direccion = TextBoxDireccion.Text,
            .Localidad = TextBoxLocalidad.Text,
            .Movil = TextBoxMovil.Text,
            .Email = TextBoxEmail.Text,
            .FechaNacimiento = New DateOnly(Integer.Parse(TextBoxFechaNacimiento.Text), Integer.Parse(ComboBoxMesFechaNacimiento.Text), Integer.Parse(ComboBoxDiaFechaNacimiento.Text)),
            .Nacionalidad = TextBoxNacionalidad.Text}

        BaseDeDatos.ModificarAlumno(Alumno)

    End Sub

End Class
