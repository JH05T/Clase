Imports System.ComponentModel

Public Class Asignaturas

    Dim indiceListView As Integer = 0
    Dim opcion As String

    Private Sub Asignaturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MinimizeBox = False
        Me.MaximizeBox = False

        VisualizarToolStripMenuItem.PerformClick()

        ConfigurarListView()

        CargarListView(BaseDeDatos.LeerDatosAsignaturas())

        ConfigurarColores()

    End Sub

    Private Sub ListView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView.SelectedIndexChanged

        If ListView.SelectedItems.Count > 0 Then

            Dim indiceSeleccionado As Integer = ListView.SelectedIndices(0)
            indiceListView = indiceSeleccionado
            Dim itemSeleccionado = ListView.Items.Item(indiceSeleccionado)

            TextBoxId.Text = itemSeleccionado.SubItems(1).Text
            TextBoxNombre.Text = itemSeleccionado.SubItems(2).Text
            TextBoxAula.Text = itemSeleccionado.SubItems(3).Text
            TextBoxProfesor.Text = itemSeleccionado.SubItems(4).Text

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

            MsgBox("Introduce un ID para poder buscar la asignatura")

        Else

            Dim Asignatura = BaseDeDatos.LeerDatosAsignaturaBuscada(New Asignatura With {.Id = TextBoxBuscar.Text})

            If Asignatura.Id.Equals(0) Then

                vaciarGroupBoxDatos()

            Else

                TextBoxId.Text = Asignatura.Id
                TextBoxNombre.Text = Asignatura.Nombre
                TextBoxAula.Text = Asignatura.Aula
                TextBoxProfesor.Text = Asignatura.Profesor

            End If

        End If

    End Sub

    Private Sub ButtonAceptar_Click(sender As Object, e As EventArgs) Handles ButtonAceptar.Click

        Select Case opcion

            Case "Agregar"

                AgregarAsignatura()

            Case "Eliminar"

                EliminarAsignatura()

            Case "Modificar"

                ModificarAsignatura()

            Case "Visualizar"

            Case Else

        End Select

        vaciarGroupBoxDatos()

        CargarListView(BaseDeDatos.LeerDatosAsignaturas)

    End Sub

    Private Sub ButtonCancelar_Click(sender As Object, e As EventArgs) Handles ButtonCancelar.Click

        vaciarGroupBoxDatos()

    End Sub

    Private Sub AgregarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarToolStripMenuItem.Click

        AgregarToolStripMenuItem.BackColor = PaletaColores.GrisNeutro
        EliminarToolStripMenuItem.BackColor = PaletaColores.Blanco
        ModificarToolStripMenuItem.BackColor = PaletaColores.Blanco
        VisualizarToolStripMenuItem.BackColor = PaletaColores.Blanco

        opcion = "Agregar"

        ButtonAceptar.Show()

        ButtonCancelar.Show()

        PictureBox.Show()

        GroupBoxBuscar.Hide()

    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click

        EliminarToolStripMenuItem.BackColor = PaletaColores.GrisNeutro
        AgregarToolStripMenuItem.BackColor = PaletaColores.Blanco
        ModificarToolStripMenuItem.BackColor = PaletaColores.Blanco
        VisualizarToolStripMenuItem.BackColor = PaletaColores.Blanco

        opcion = "Eliminar"

        ButtonAceptar.Show()

        ButtonCancelar.Show()

        PictureBox.Hide()

        GroupBoxBuscar.Show()

    End Sub

    Private Sub ModificarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarToolStripMenuItem.Click

        ModificarToolStripMenuItem.BackColor = PaletaColores.GrisNeutro
        AgregarToolStripMenuItem.BackColor = PaletaColores.Blanco
        EliminarToolStripMenuItem.BackColor = PaletaColores.Blanco
        VisualizarToolStripMenuItem.BackColor = PaletaColores.Blanco

        opcion = "Modificar"

        ButtonAceptar.Show()

        ButtonCancelar.Show()

        PictureBox.Hide()

        GroupBoxBuscar.Show()

    End Sub

    Private Sub VisualizarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisualizarToolStripMenuItem.Click

        VisualizarToolStripMenuItem.BackColor = PaletaColores.GrisNeutro
        AgregarToolStripMenuItem.BackColor = PaletaColores.Blanco
        EliminarToolStripMenuItem.BackColor = PaletaColores.Blanco
        ModificarToolStripMenuItem.BackColor = PaletaColores.Blanco

        opcion = "Visualizar"

        ButtonAceptar.Hide()

        ButtonCancelar.Hide()

        PictureBox.Hide()

        GroupBoxBuscar.Show()

    End Sub

    Private Sub VolverToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VolverToolStripMenuItem.Click

        Me.Hide()
        Inicio.Show()

    End Sub

    Private Sub Asignaturas_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing

        Inicio.Close()

    End Sub

    Private Sub ConfigurarListView()

        ListView.Columns.Add("", 0, HorizontalAlignment.Center)
        ListView.Columns.Add("Id", 30, HorizontalAlignment.Center)
        ListView.Columns.Add("Nombre", 145, HorizontalAlignment.Center)
        ListView.Columns.Add("Aula", 175, HorizontalAlignment.Center)
        ListView.Columns.Add("Profesor", 145, HorizontalAlignment.Center)

    End Sub

    Private Sub CargarListView(DatosAsignaturas As DataSet)

        Dim ElementoList As ListViewItem

        ListView.Items.Clear()

        ListView.View = View.Details

        For pos As Integer = 0 To DatosAsignaturas.Tables(0).Rows.Count - 1

            ElementoList = ListView.Items.Add(DatosAsignaturas.Tables(0).Rows(pos).Item(0))

            ElementoList.SubItems.Add(DatosAsignaturas.Tables(0).Rows(pos).Item(0))
            ElementoList.SubItems.Add(DatosAsignaturas.Tables(0).Rows(pos).Item(1))
            ElementoList.SubItems.Add(DatosAsignaturas.Tables(0).Rows(pos).Item(2))
            ElementoList.SubItems.Add(DatosAsignaturas.Tables(0).Rows(pos).Item(3))

        Next

    End Sub

    Private Sub ConfigurarColores()

        MenuStrip.BackColor = PaletaColores.Blanco

        For Each control As Control In GroupBoxRellenarDatos.Controls

            If TypeOf control Is System.Windows.Forms.TextBox Then

                DirectCast(control, System.Windows.Forms.TextBox).BackColor = PaletaColores.BeigeClaro
                DirectCast(control, System.Windows.Forms.TextBox).BorderStyle = BorderStyle.FixedSingle

            End If

        Next

        For Each control As Control In GroupBoxBuscar.Controls

            If TypeOf control Is System.Windows.Forms.Button Then

                DirectCast(control, System.Windows.Forms.Button).BackColor = PaletaColores.MarronClaro
                DirectCast(control, System.Windows.Forms.Button).FlatStyle = FlatStyle.Flat

            ElseIf TypeOf control Is System.Windows.Forms.TextBox Then

                DirectCast(control, System.Windows.Forms.TextBox).BackColor = PaletaColores.BeigeClaro
                DirectCast(control, System.Windows.Forms.TextBox).BorderStyle = BorderStyle.FixedSingle

            End If

        Next

        For Each control As Control In Me.Controls

            If TypeOf control Is System.Windows.Forms.Button Then

                DirectCast(control, System.Windows.Forms.Button).BackColor = PaletaColores.MarronClaro
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

    Private Sub AgregarAsignatura()

        Dim Profesor As Integer

        If Not Integer.TryParse(TextBoxProfesor.Text, Profesor) Then

            MessageBox.Show("Por favor, introduce una ID de profesor válida en el campo Profesor.")

            Return

        End If

        Dim Asignatura As Asignatura = New Asignatura With {
        .Nombre = TextBoxNombre.Text,
        .Aula = TextBoxAula.Text,
        .Profesor = TextBoxProfesor.Text}

        BaseDeDatos.AgregarAsignatura(Asignatura)

    End Sub

    Private Sub EliminarAsignatura()

        Dim result As DialogResult = MessageBox.Show("¿Estás seguro de que quieres eliminar esta asignatura?", "Confirmación", MessageBoxButtons.YesNo)

        If result = DialogResult.Yes Then

            Dim Asignatura As Asignatura = New Asignatura With {
        .Id = TextBoxId.Text}

            BaseDeDatos.EliminarAsignatura(Asignatura)

        End If

    End Sub

    Private Sub ModificarAsignatura()

        Dim Profesor As Integer

        If Not Integer.TryParse(TextBoxProfesor.Text, Profesor) Then

            MessageBox.Show("Por favor, introduce un número válido en el campo Profesor.")

            Return

        End If

        Dim Asignatura As Asignatura = New Asignatura With {
        .Id = TextBoxId.Text,
        .Nombre = TextBoxNombre.Text,
        .Aula = TextBoxAula.Text,
        .Profesor = TextBoxProfesor.Text}

        BaseDeDatos.ModificarAsignatura(Asignatura)

    End Sub

End Class