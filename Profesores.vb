Imports System.ComponentModel

Public Class Profesores

    Dim indiceListView As Integer = 0
    Dim opcion As String

    Private Sub Profesores_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MinimizeBox = False
        Me.MaximizeBox = False

        VisualizarToolStripMenuItem.PerformClick()

        ConfigurarListView()

        CargarListView(BaseDeDatos.LeerDatosProfesores())

        ConfigurarColores()

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
            TextBoxDepartamento.Text = itemSeleccionado.SubItems(4).Text

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

        If TextBoxBuscar.Text.Equals("") Then

            MsgBox("Introduce un ID para poder buscar al profesor")

        Else

            Dim Profesor = BaseDeDatos.LeerDatosProfesorBuscado(New Profesor With {.Id = TextBoxBuscar.Text})

            If Profesor.Id.Equals(0) Then

                vaciarGroupBoxDatos()

            Else

                TextBoxId.Text = Profesor.Id
                TextBoxNombre.Text = Profesor.Nombre
                TextBoxApellidos.Text = Profesor.Apellidos
                TextBoxDepartamento.Text = Profesor.Departamento

            End If

        End If

    End Sub

    Private Sub ButtonAceptar_Click(sender As Object, e As EventArgs) Handles ButtonAceptar.Click

        Select Case opcion

            Case "Agregar"

                AgregarProfesor()

            Case "Eliminar"

                EliminarProfesor()

            Case "Modificar"

                ModificarProfesor()

            Case "Visualizar"

            Case Else

        End Select

        vaciarGroupBoxDatos()

        CargarListView(BaseDeDatos.LeerDatosProfesores)

    End Sub

    Private Sub ButtonCancelar_Click(sender As Object, e As EventArgs) Handles ButtonCancelar.Click

        vaciarGroupBoxDatos()

    End Sub

    Private Sub AgregarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarToolStripMenuItem.Click

        AgregarToolStripMenuItem.BackColor = PaletaColores.Rosa
        EliminarToolStripMenuItem.BackColor = PaletaColores.AzulCielo
        ModificarToolStripMenuItem.BackColor = PaletaColores.AzulCielo
        VisualizarToolStripMenuItem.BackColor = PaletaColores.AzulCielo

        opcion = "Agregar"

        ButtonAceptar.Show()

        ButtonCancelar.Show()

    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click

        EliminarToolStripMenuItem.BackColor = PaletaColores.Rosa
        AgregarToolStripMenuItem.BackColor = PaletaColores.AzulCielo
        ModificarToolStripMenuItem.BackColor = PaletaColores.AzulCielo
        VisualizarToolStripMenuItem.BackColor = PaletaColores.AzulCielo

        opcion = "Eliminar"

        ButtonAceptar.Show()

        ButtonCancelar.Show()

    End Sub
    Private Sub ModificarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarToolStripMenuItem.Click

        ModificarToolStripMenuItem.BackColor = PaletaColores.Rosa
        AgregarToolStripMenuItem.BackColor = PaletaColores.AzulCielo
        EliminarToolStripMenuItem.BackColor = PaletaColores.AzulCielo
        VisualizarToolStripMenuItem.BackColor = PaletaColores.AzulCielo

        opcion = "Modificar"

        ButtonAceptar.Show()

        ButtonCancelar.Show()

    End Sub

    Private Sub VisualizarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisualizarToolStripMenuItem.Click

        VisualizarToolStripMenuItem.BackColor = PaletaColores.Rosa
        AgregarToolStripMenuItem.BackColor = PaletaColores.AzulCielo
        EliminarToolStripMenuItem.BackColor = PaletaColores.AzulCielo
        ModificarToolStripMenuItem.BackColor = PaletaColores.AzulCielo

        opcion = "Visualizar"

        ButtonAceptar.Hide()

        ButtonCancelar.Hide()

    End Sub

    Private Sub VolverToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VolverToolStripMenuItem.Click

        Me.Hide()
        Inicio.Show()

    End Sub

    Private Sub Alumnos_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing

        Inicio.Close()

    End Sub

    Private Sub ConfigurarListView()

        ListView.Columns.Add("", 0, HorizontalAlignment.Center)
        ListView.Columns.Add("Id", 30, HorizontalAlignment.Center)
        ListView.Columns.Add("Nombre", 145, HorizontalAlignment.Center)
        ListView.Columns.Add("Apellidos", 175, HorizontalAlignment.Center)
        ListView.Columns.Add("Departamento", 145, HorizontalAlignment.Center)

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

        Next

    End Sub

    Private Sub ConfigurarColores()

        MenuStripAlumnos.BackColor = PaletaColores.AzulCielo

        For Each control As Control In GroupBoxRellenarDatos.Controls

            If TypeOf control Is System.Windows.Forms.TextBox Then

                DirectCast(control, System.Windows.Forms.TextBox).BackColor = PaletaColores.LilaClaro
                DirectCast(control, System.Windows.Forms.TextBox).BorderStyle = BorderStyle.FixedSingle

            End If

        Next

        For Each control As Control In GroupBoxBuscar.Controls

            If TypeOf control Is System.Windows.Forms.Button Then

                DirectCast(control, System.Windows.Forms.Button).BackColor = PaletaColores.AzulLila
                DirectCast(control, System.Windows.Forms.Button).FlatStyle = FlatStyle.Flat

            ElseIf TypeOf control Is System.Windows.Forms.TextBox Then

                DirectCast(control, System.Windows.Forms.TextBox).BackColor = PaletaColores.LilaClaro
                DirectCast(control, System.Windows.Forms.TextBox).BorderStyle = BorderStyle.FixedSingle

            End If

        Next

        For Each control As Control In Me.Controls

            If TypeOf control Is System.Windows.Forms.Button Then

                DirectCast(control, System.Windows.Forms.Button).BackColor = PaletaColores.AzulLila
                DirectCast(control, System.Windows.Forms.Button).FlatStyle = FlatStyle.Flat

            End If

        Next

    End Sub

    Private Sub vaciarGroupBoxDatos()

        For Each control As Control In GroupBoxRellenarDatos.Controls

            If TypeOf control Is System.Windows.Forms.TextBox Then

                DirectCast(control, System.Windows.Forms.TextBox).Clear()

            End If

        Next

    End Sub

    Private Sub AgregarProfesor()

        Dim Profesor As Profesor = New Profesor With {
            .Nombre = TextBoxNombre.Text,
            .Apellidos = TextBoxApellidos.Text,
            .Departamento = TextBoxDepartamento.Text}

        BaseDeDatos.AgregarProfesor(Profesor)

    End Sub

    Private Sub EliminarProfesor()

        Dim result As DialogResult = MessageBox.Show("¿Estás seguro de que quieres eliminar este profesor?", "Confirmación", MessageBoxButtons.YesNo)

        If result = DialogResult.Yes Then

            Dim Profesor As Profesor = New Profesor With {
            .Id = TextBoxId.Text}

            BaseDeDatos.EliminarProfesor(Profesor)

        End If

    End Sub

    Private Sub ModificarProfesor()

        Dim Profesor As Profesor = New Profesor With {
            .Id = TextBoxId.Text,
            .Nombre = TextBoxNombre.Text,
            .Apellidos = TextBoxApellidos.Text,
            .Departamento = TextBoxDepartamento.Text}

        BaseDeDatos.ModificarProfesor(Profesor)

    End Sub


End Class