Imports System.ComponentModel
Imports Clase.BaseDeDatos

''' <summary>
''' Clase que representa el formulario de gestión de profesores.
''' </summary>
Public Class Profesores

    ''' <summary>
    ''' Índice actualmente seleccionado en el ListView.
    ''' </summary>
    Dim indiceListView As Integer = 0

    ''' <summary>
    ''' Opción actual seleccionada (Agregar, Eliminar, Modificar o Visualizar).
    ''' </summary>
    Dim opcion As String

    ''' <summary>
    ''' Maneja el evento Load del formulario. Configura la interfaz inicial y carga los datos de profesores.
    ''' </summary>
    Private Sub Profesores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Configuración inicial del formulario
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MinimizeBox = False
        Me.MaximizeBox = False

        ' Realiza un clic en el menú Visualizar
        VisualizarToolStripMenuItem.PerformClick()

        ' Configura el ListView
        ConfigurarListView()

        ' Carga los datos de profesores en el ListView
        CargarListView(BaseDeDatos.LeerDatosProfesores())

        ' Configura los colores de los controles
        ConfigurarColores()

    End Sub

    ''' <summary>
    ''' Maneja el evento SelectedIndexChanged del ListView. Muestra los detalles del profesor seleccionado.
    ''' </summary>
    Private Sub ListView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView.SelectedIndexChanged

        If ListView.SelectedItems.Count > 0 Then

            ' Obtiene el índice y el elemento seleccionado en el ListView
            Dim indiceSeleccionado As Integer = ListView.SelectedIndices(0)
            indiceListView = indiceSeleccionado
            Dim itemSeleccionado = ListView.Items.Item(indiceSeleccionado)

            ' Muestra los detalles del profesor seleccionado en los TextBox correspondientes
            TextBoxId.Text = itemSeleccionado.SubItems(1).Text
            TextBoxNombre.Text = itemSeleccionado.SubItems(2).Text
            TextBoxApellidos.Text = itemSeleccionado.SubItems(3).Text
            TextBoxDepartamento.Text = itemSeleccionado.SubItems(4).Text

        End If

    End Sub

    ''' <summary>
    ''' Maneja el evento Click del botón Siguiente. Selecciona el siguiente elemento en el ListView.
    ''' </summary>
    Private Sub ButtonSiguiente_Click(sender As Object, e As EventArgs) Handles ButtonSiguiente.Click

        If indiceListView < ListView.Items.Count - 1 Then

            ' Selecciona el siguiente elemento en el ListView
            ListView.Items(indiceListView).Selected = False

            indiceListView += 1

            ListView.Items(indiceListView).Selected = True

        End If

    End Sub

    ''' <summary>
    ''' Maneja el evento Click del botón Anterior. Selecciona el elemento anterior en el ListView.
    ''' </summary>
    Private Sub ButtonAnterior_Click(sender As Object, e As EventArgs) Handles ButtonAnterior.Click

        If indiceListView > 0 Then

            ' Selecciona el elemento anterior en el ListView
            ListView.Items(indiceListView).Selected = False

            indiceListView -= 1

            ListView.Items(indiceListView).Selected = True

        End If

    End Sub

    ''' <summary>
    ''' Maneja el evento Click del botón Primero. Selecciona el primer elemento en el ListView.
    ''' </summary>
    Private Sub ButtonPrimero_Click(sender As Object, e As EventArgs) Handles ButtonPrimero.Click

        ' Selecciona el primer elemento en el ListView
        ListView.Items(indiceListView).Selected = False

        indiceListView = 0

        ListView.Items(indiceListView).Selected = True

    End Sub

    ''' <summary>
    ''' Maneja el evento Click del botón Último. Selecciona el último elemento en el ListView.
    ''' </summary>
    Private Sub ButtonUltimo_Click(sender As Object, e As EventArgs) Handles ButtonUltimo.Click

        ' Selecciona el último elemento en el ListView
        ListView.Items(indiceListView).Selected = False

        indiceListView = ListView.Items.Count - 1

        ListView.Items(indiceListView).Selected = True

    End Sub

    ''' <summary>
    ''' Maneja el evento Click del botón Buscar. Busca un profesor por ID y muestra sus detalles.
    ''' </summary>
    Private Sub ButtonBuscar_Click(sender As Object, e As EventArgs) Handles ButtonBuscar.Click

        Dim IdProfesor As Integer

        If TextBoxBuscar.Text.Equals("") Then

            ' Muestra un mensaje si el campo de búsqueda está vacío
            MsgBox("Introduce un ID para poder buscar al profesor")


            ' Verifica si el ID del profesor es un número válido
        ElseIf Not Integer.TryParse(TextBoxBuscar.Text, IdProfesor) Then

            MessageBox.Show("Por favor, introduce una ID de profesor válida.")

        Else

            ' Busca al profesor por ID en la base de datos y muestra sus detalles si se encuentra
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

    ''' <summary>
    ''' Maneja el evento Click del botón Aceptar. Realiza la acción correspondiente (Agregar, Eliminar, Modificar o Visualizar) según la opción seleccionada.
    ''' </summary>
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

        ' Limpia los datos de los controles y recarga el ListView
        vaciarGroupBoxDatos()

        CargarListView(BaseDeDatos.LeerDatosProfesores)

    End Sub

    ''' <summary>
    ''' Maneja el evento Click del botón Cancelar. Limpia los datos de los controles.
    ''' </summary>
    Private Sub ButtonCancelar_Click(sender As Object, e As EventArgs) Handles ButtonCancelar.Click

        vaciarGroupBoxDatos()

    End Sub

    ''' <summary>
    ''' Maneja el evento Click del elemento de menú Agregar. Selecciona la opción Agregar y muestra los controles correspondientes.
    ''' </summary>
    Private Sub AgregarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarToolStripMenuItem.Click

        ' Configura la opción y muestra los controles necesarios para agregar un profesor
        AgregarToolStripMenuItem.BackColor = PaletaColores.GrisNeutro
        EliminarToolStripMenuItem.BackColor = PaletaColores.Blanco
        ModificarToolStripMenuItem.BackColor = PaletaColores.Blanco
        VisualizarToolStripMenuItem.BackColor = PaletaColores.Blanco

        opcion = "Agregar"

        ButtonAceptar.Show()

        ButtonCancelar.Show()

        PictureBox.Show()

        LabelId.Hide()

        TextBoxId.Hide()

        GroupBoxBuscar.Hide()

    End Sub

    ''' <summary>
    ''' Maneja el evento Click del elemento de menú Eliminar. Selecciona la opción Eliminar y muestra los controles correspondientes.
    ''' </summary>
    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click

        ' Configura la opción y muestra los controles necesarios para eliminar un profesor
        EliminarToolStripMenuItem.BackColor = PaletaColores.GrisNeutro
        AgregarToolStripMenuItem.BackColor = PaletaColores.Blanco
        ModificarToolStripMenuItem.BackColor = PaletaColores.Blanco
        VisualizarToolStripMenuItem.BackColor = PaletaColores.Blanco

        opcion = "Eliminar"

        ButtonAceptar.Show()

        ButtonCancelar.Show()

        PictureBox.Hide()

        GroupBoxBuscar.Show()

        LabelId.Show()

        TextBoxId.Show()

    End Sub

    ''' <summary>
    ''' Maneja el evento Click del elemento de menú Modificar. Selecciona la opción Modificar y muestra los controles correspondientes.
    ''' </summary>
    Private Sub ModificarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarToolStripMenuItem.Click

        ' Configura la opción y muestra los controles necesarios para modificar un profesor
        ModificarToolStripMenuItem.BackColor = PaletaColores.GrisNeutro
        AgregarToolStripMenuItem.BackColor = PaletaColores.Blanco
        EliminarToolStripMenuItem.BackColor = PaletaColores.Blanco
        VisualizarToolStripMenuItem.BackColor = PaletaColores.Blanco

        opcion = "Modificar"

        ButtonAceptar.Show()

        ButtonCancelar.Show()

        LabelId.Hide()

        TextBoxId.Hide()

        PictureBox.Hide()

        GroupBoxBuscar.Show()

    End Sub

    ''' <summary>
    ''' Maneja el evento Click del elemento de menú Visualizar. Selecciona la opción Visualizar y muestra los controles correspondientes.
    ''' </summary>
    Private Sub VisualizarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisualizarToolStripMenuItem.Click

        ' Configura la opción y muestra los controles necesarios para visualizar los profesores
        VisualizarToolStripMenuItem.BackColor = PaletaColores.GrisNeutro
        AgregarToolStripMenuItem.BackColor = PaletaColores.Blanco
        EliminarToolStripMenuItem.BackColor = PaletaColores.Blanco
        ModificarToolStripMenuItem.BackColor = PaletaColores.Blanco

        opcion = "Visualizar"

        ButtonAceptar.Hide()

        ButtonCancelar.Hide()

        PictureBox.Hide()

        GroupBoxBuscar.Show()

        LabelId.Show()

        TextBoxId.Show()

    End Sub

    ''' <summary>
    ''' Maneja el evento Click del elemento de menú Volver. Oculta el formulario actual y muestra el formulario de inicio.
    ''' </summary>
    Private Sub VolverToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VolverToolStripMenuItem.Click

        Me.Hide()

        Inicio.Show()

    End Sub

    ''' <summary>
    ''' Maneja el evento Closing del formulario. Cierra el formulario de inicio al cerrar este formulario.
    ''' </summary>
    Private Sub Profesores_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing

        Inicio.Close()

    End Sub

    ''' <summary>
    ''' Configura el ListView para mostrar los datos de los profesores.
    ''' </summary>
    Private Sub ConfigurarListView()

        ListView.Columns.Add("", 0, HorizontalAlignment.Center)
        ListView.Columns.Add("Id", 30, HorizontalAlignment.Center)
        ListView.Columns.Add("Nombre", 145, HorizontalAlignment.Center)
        ListView.Columns.Add("Apellidos", 175, HorizontalAlignment.Center)
        ListView.Columns.Add("Departamento", 145, HorizontalAlignment.Center)

    End Sub

    ''' <summary>
    ''' Carga los datos de los profesores en el ListView.
    ''' </summary>
    ''' <param name="DatosProfesores">DataSet que contiene los datos de los profesores.</param>
    Private Sub CargarListView(DatosProfesores As DataSet)

        Dim ElementoList As ListViewItem

        ListView.Items.Clear()

        ListView.View = View.Details

        ' Itera sobre los datos de los profesores y los agrega al ListView
        For pos As Integer = 0 To DatosProfesores.Tables(0).Rows.Count - 1

            ElementoList = ListView.Items.Add(DatosProfesores.Tables(0).Rows(pos).Item(0))

            ElementoList.SubItems.Add(DatosProfesores.Tables(0).Rows(pos).Item(0))
            ElementoList.SubItems.Add(DatosProfesores.Tables(0).Rows(pos).Item(1))
            ElementoList.SubItems.Add(DatosProfesores.Tables(0).Rows(pos).Item(2))
            ElementoList.SubItems.Add(DatosProfesores.Tables(0).Rows(pos).Item(3))

        Next

    End Sub

    ''' <summary>
    ''' Configura los colores de los controles en el formulario.
    ''' </summary>
    Private Sub ConfigurarColores()

        MenuStrip.BackColor = PaletaColores.Blanco

        ' Configura los colores de los TextBox en los GroupBox
        For Each control As Control In GroupBoxRellenarDatos.Controls

            If TypeOf control Is System.Windows.Forms.TextBox Then

                DirectCast(control, System.Windows.Forms.TextBox).BackColor = PaletaColores.BeigeClaro
                DirectCast(control, System.Windows.Forms.TextBox).BorderStyle = BorderStyle.FixedSingle

            End If

        Next

        ' Configura los colores de los botones y TextBox en el GroupBoxBuscar
        For Each control As Control In GroupBoxBuscar.Controls

            If TypeOf control Is System.Windows.Forms.Button Then

                DirectCast(control, System.Windows.Forms.Button).BackColor = PaletaColores.MarronClaro
                DirectCast(control, System.Windows.Forms.Button).FlatStyle = FlatStyle.Flat

            ElseIf TypeOf control Is System.Windows.Forms.TextBox Then

                DirectCast(control, System.Windows.Forms.TextBox).BackColor = PaletaColores.BeigeClaro
                DirectCast(control, System.Windows.Forms.TextBox).BorderStyle = BorderStyle.FixedSingle

            End If

        Next

        ' Configura los colores de los botones en el formulario
        For Each control As Control In Me.Controls

            If TypeOf control Is System.Windows.Forms.Button Then

                DirectCast(control, System.Windows.Forms.Button).BackColor = PaletaColores.MarronClaro
                DirectCast(control, System.Windows.Forms.Button).FlatStyle = FlatStyle.Flat

            End If

        Next

    End Sub

    ''' <summary>
    ''' Limpia los datos de los TextBox en el GroupBoxRellenarDatos.
    ''' </summary>
    Private Sub vaciarGroupBoxDatos()

        For Each control As Control In GroupBoxRellenarDatos.Controls

            If TypeOf control Is System.Windows.Forms.TextBox Then

                DirectCast(control, System.Windows.Forms.TextBox).Clear()

            End If

        Next

    End Sub

    ''' <summary>
    ''' Agrega un nuevo profesor a la base de datos.
    ''' </summary>
    Private Sub AgregarProfesor()

        Dim Profesor As Profesor = New Profesor With {
            .Nombre = TextBoxNombre.Text,
            .Apellidos = TextBoxApellidos.Text,
            .Departamento = TextBoxDepartamento.Text}

        BaseDeDatos.AgregarProfesor(Profesor)

    End Sub

    ''' <summary>
    ''' Elimina un profesor de la base de datos.
    ''' </summary>
    Private Sub EliminarProfesor()

        Dim result As DialogResult = MessageBox.Show("¿Estás seguro de que quieres eliminar este profesor?", "Confirmación", MessageBoxButtons.YesNo)

        If result = DialogResult.Yes Then

            Dim Profesor As Profesor = New Profesor With {
            .Id = TextBoxId.Text}

            BaseDeDatos.EliminarProfesor(Profesor)

        End If

    End Sub

    ''' <summary>
    ''' Modifica los datos de un profesor en la base de datos.
    ''' </summary>
    Private Sub ModificarProfesor()

        Dim Profesor As Profesor = New Profesor With {
            .Id = TextBoxId.Text,
            .Nombre = TextBoxNombre.Text,
            .Apellidos = TextBoxApellidos.Text,
            .Departamento = TextBoxDepartamento.Text}

        BaseDeDatos.ModificarProfesor(Profesor)

    End Sub

End Class