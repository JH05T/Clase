Imports System.ComponentModel

''' <summary>
''' Clase principal para la gestión de asignaturas.
''' </summary>
Public Class Asignaturas

    ''' <summary>
    ''' Índice actualmente seleccionado en el ListView.
    ''' </summary>
    Dim indiceListView As Integer = 0

    ''' <summary>
    ''' Opción actual seleccionada (Agregar, Eliminar, Modificar o Visualizar).
    ''' </summary>
    Dim opcion As String

    ''' <summary>
    ''' Evento Load del formulario.
    ''' </summary>
    Private Sub Asignaturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Configuración inicial del formulario
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MinimizeBox = False
        Me.MaximizeBox = False
        Me.DoubleBuffered = True

        ' Ejecuta automáticamente la opción Visualizar
        VisualizarToolStripMenuItem.PerformClick()

        ' Configura el ListView
        ConfigurarListView()

        ' Carga los datos de las asignaturas en el ListView
        CargarListView(BaseDeDatos.LeerDatosAsignaturas())

        ' Configura los colores
        ConfigurarColores()

    End Sub

    ''' <summary>
    ''' Maneja el evento SelectedIndexChanged del ListView.
    ''' </summary>
    Private Sub ListView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView.SelectedIndexChanged

        ' Verifica si se ha seleccionado algún ítem en el ListView
        If ListView.SelectedItems.Count > 0 Then

            ' Obtiene el índice seleccionado y muestra los detalles en los TextBox correspondientes
            Dim indiceSeleccionado As Integer = ListView.SelectedIndices(0)
            indiceListView = indiceSeleccionado
            Dim itemSeleccionado = ListView.Items.Item(indiceSeleccionado)

            TextBoxId.Text = itemSeleccionado.SubItems(1).Text
            TextBoxNombre.Text = itemSeleccionado.SubItems(2).Text
            TextBoxAula.Text = itemSeleccionado.SubItems(3).Text
            TextBoxProfesor.Text = itemSeleccionado.SubItems(4).Text

        End If

    End Sub

    ''' <summary>
    ''' Evento que se dispara cuando se hace clic en el botón Siguiente.
    ''' </summary>
    Private Sub ButtonSiguiente_Click(sender As Object, e As EventArgs) Handles ButtonSiguiente.Click

        ' Verifica si hay más elementos en el ListView
        If indiceListView < ListView.Items.Count - 1 Then

            ' Deselecciona el elemento actual si existe
            If ListView.Items(indiceListView) IsNot Nothing Then

                ListView.Items(indiceListView).Selected = False

            End If

            ' Incrementa el índice y selecciona el siguiente elemento
            indiceListView += 1

            ' Comprueba si el índice es válido antes de seleccionar el elemento
            If indiceListView < ListView.Items.Count AndAlso ListView.Items(indiceListView) IsNot Nothing Then

                ListView.Items(indiceListView).Selected = True

            End If

        End If

    End Sub

    ''' <summary>
    ''' Evento que se dispara cuando se hace clic en el botón Anterior.
    ''' </summary>
    Private Sub ButtonAnterior_Click(sender As Object, e As EventArgs) Handles ButtonAnterior.Click

        ' Verifica si hay elementos anteriores en el ListView
        If indiceListView > 0 Then

            ' Deselecciona el elemento actual si existe
            If ListView.Items(indiceListView) IsNot Nothing Then

                ListView.Items(indiceListView).Selected = False

            End If

            ' Decrementa el índice y selecciona el elemento anterior
            indiceListView -= 1

            ' Comprueba si el índice es válido antes de seleccionar el elemento
            If indiceListView >= 0 AndAlso ListView.Items(indiceListView) IsNot Nothing Then

                ListView.Items(indiceListView).Selected = True

            End If

        End If

    End Sub

    ''' <summary>
    ''' Evento que se dispara cuando se hace clic en el botón Primero.
    ''' </summary>
    Private Sub ButtonPrimero_Click(sender As Object, e As EventArgs) Handles ButtonPrimero.Click

        ' Deselecciona el elemento actual si existe y selecciona el primero
        If ListView.Items.Count > 0 AndAlso ListView.Items(indiceListView) IsNot Nothing Then

            ListView.Items(indiceListView).Selected = False

        End If

        indiceListView = 0

        ' Comprueba si el índice es válido antes de seleccionar el elemento
        If ListView.Items.Count > 0 AndAlso ListView.Items(indiceListView) IsNot Nothing Then

            ListView.Items(indiceListView).Selected = True

        End If

    End Sub

    ''' <summary>
    ''' Evento que se dispara cuando se hace clic en el botón Último.
    ''' </summary>
    Private Sub ButtonUltimo_Click(sender As Object, e As EventArgs) Handles ButtonUltimo.Click

        ' Deselecciona el elemento actual si existe y selecciona el último
        If ListView.Items.Count > 0 AndAlso ListView.Items(indiceListView) IsNot Nothing Then

            ListView.Items(indiceListView).Selected = False

        End If

        indiceListView = ListView.Items.Count - 1

        ' Comprueba si el índice es válido antes de seleccionar el elemento
        If ListView.Items.Count > 0 AndAlso ListView.Items(indiceListView) IsNot Nothing Then

            ListView.Items(indiceListView).Selected = True

        End If

    End Sub

    ''' <summary>
    ''' Maneja el evento Click del botón Buscar.
    ''' </summary>
    Private Sub ButtonBuscar_Click(sender As Object, e As EventArgs) Handles ButtonBuscar.Click

        Dim IdAsignatura As Integer

        ' Verifica si se ha ingresado un ID para buscar la asignatura
        If TextBoxBuscar.Text.Equals("") Then

            MsgBox("Introduce un ID para poder buscar la asignatura")

            ' Verifica si el ID de la asignatura es un número válido
        ElseIf Not Integer.TryParse(TextBoxBuscar.Text, IdAsignatura) Then

            MessageBox.Show("Por favor, introduce una ID de asignatura válida.")

        Else

            ' Busca la asignatura por ID en la base de datos y muestra los detalles si se encuentra
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

    ''' <summary>
    ''' Muestra un texto cuando el ratón se coloca sobre el botón de buscar.
    ''' </summary>
    Private Sub ButtonBuscar_MouseHover(sender As Object, e As EventArgs) Handles ButtonBuscar.MouseHover

        ' Establece el texto "buscar" que se mostrará cuando el ratón se coloca sobre el botón de buscar
        ToolTipBuscar.SetToolTip(ButtonBuscar, "Buscar")

    End Sub

    ''' <summary>
    ''' Maneja el evento Click del botón Aceptar.
    ''' </summary>
    Private Sub ButtonAceptar_Click(sender As Object, e As EventArgs) Handles ButtonAceptar.Click

        ' Realiza la acción correspondiente según la opción seleccionada
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

        ' Limpia los campos y actualiza la lista de asignaturas
        vaciarGroupBoxDatos()

        CargarListView(BaseDeDatos.LeerDatosAsignaturas)

    End Sub

    ''' <summary>
    ''' Maneja el evento Click del botón Cancelar.
    ''' </summary>
    Private Sub ButtonCancelar_Click(sender As Object, e As EventArgs) Handles ButtonCancelar.Click

        ' Limpia los campos
        vaciarGroupBoxDatos()

    End Sub

    ''' <summary>
    ''' Maneja el evento Click del menú Agregar.
    ''' </summary>
    Private Sub AgregarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarToolStripMenuItem.Click

        ' Configura la opción como Agregar y muestra los controles correspondientes
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
    ''' Maneja el evento Click del menú Eliminar.
    ''' </summary>
    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click

        ' Configura la opción como Eliminar y muestra los controles correspondientes
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
    ''' Maneja el evento Click del menú Modificar.
    ''' </summary>
    Private Sub ModificarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarToolStripMenuItem.Click

        ' Configura la opción como Modificar y muestra los controles correspondientes
        ModificarToolStripMenuItem.BackColor = PaletaColores.GrisNeutro
        AgregarToolStripMenuItem.BackColor = PaletaColores.Blanco
        EliminarToolStripMenuItem.BackColor = PaletaColores.Blanco
        VisualizarToolStripMenuItem.BackColor = PaletaColores.Blanco

        opcion = "Modificar"

        ButtonAceptar.Show()

        ButtonCancelar.Show()

        PictureBox.Hide()

        LabelId.Hide()

        TextBoxId.Hide()

        GroupBoxBuscar.Show()

    End Sub

    ''' <summary>
    ''' Maneja el evento Click del menú Visualizar.
    ''' </summary>
    Private Sub VisualizarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisualizarToolStripMenuItem.Click

        ' Configura la opción como Visualizar y muestra los controles correspondientes
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
    ''' Maneja el evento Click del menú Volver.
    ''' </summary>
    Private Sub VolverToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VolverToolStripMenuItem.Click

        ' Oculta el formulario actual y muestra el formulario de Inicio
        Me.Hide()
        Inicio.Show()

    End Sub

    ''' <summary>
    ''' Este método se ejecuta cuando se hace clic en el botón ButtonAyuda.
    ''' </summary>
    Private Sub ButtonAyuda_Click(sender As Object, e As EventArgs) Handles ButtonAyuda.Click

        ' Define una variable "ruta" que contiene la ruta del archivo "DocAsignaturas.pdf" en el directorio de inicio de la aplicación.
        Dim ruta As String = Application.StartupPath.Substring(0, Application.StartupPath.Length - 25) + "Doc\DocAsignaturas.pdf"

        ' Abre una ventana de línea de comandos y ejecuta el comando "start" para abrir el archivo especificado en la ruta.
        Process.Start("cmd", "/C start file:///" & ruta)

    End Sub

    ''' <summary>
    ''' Muestra un texto cuando el ratón se coloca sobre el botón de ayuda.
    ''' </summary>
    Private Sub ButtonAyuda_MouseHover(sender As Object, e As EventArgs) Handles ButtonAyuda.MouseHover

        ' Establece el texto "ayuda" que se mostrará cuando el ratón se coloca sobre el botón de ayuda
        ToolTipBuscar.SetToolTip(ButtonAyuda, "Ayuda")

    End Sub

    ''' <summary>
    ''' Maneja el evento Closing del formulario.
    ''' </summary>
    Private Sub Asignaturas_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing

        ' Cierra el formulario de Inicio al cerrar este formulario
        Inicio.Close()

    End Sub

    ''' <summary>
    ''' Configura el ListView.
    ''' </summary>
    Private Sub ConfigurarListView()

        ' Agrega las columnas al ListView con sus respectivos tamaños y alineaciones
        ListView.Columns.Add("", 0, HorizontalAlignment.Center)
        ListView.Columns.Add("Id", 30, HorizontalAlignment.Center)
        ListView.Columns.Add("Nombre", 145, HorizontalAlignment.Center)
        ListView.Columns.Add("Aula", 175, HorizontalAlignment.Center)
        ListView.Columns.Add("Profesor", 145, HorizontalAlignment.Center)

    End Sub

    ''' <summary>
    ''' Carga los datos de asignaturas en el ListView.
    ''' </summary>
    ''' <param name="DatosAsignaturas">DataSet que contiene los datos de las asignaturas.</param>
    Private Sub CargarListView(DatosAsignaturas As DataSet)

        Dim ElementoList As ListViewItem

        ' Borra todos los elementos existentes en el ListView
        ListView.Items.Clear()

        ListView.View = View.Details

        ' Agrega cada asignatura como un elemento en el ListView
        For pos As Integer = 0 To DatosAsignaturas.Tables(0).Rows.Count - 1

            ElementoList = ListView.Items.Add(DatosAsignaturas.Tables(0).Rows(pos).Item(0))

            ElementoList.SubItems.Add(DatosAsignaturas.Tables(0).Rows(pos).Item(0))
            ElementoList.SubItems.Add(DatosAsignaturas.Tables(0).Rows(pos).Item(1))
            ElementoList.SubItems.Add(DatosAsignaturas.Tables(0).Rows(pos).Item(2))
            ElementoList.SubItems.Add(DatosAsignaturas.Tables(0).Rows(pos).Item(3))

        Next

    End Sub

    ''' <summary>
    ''' Configura los colores de los controles en el formulario.
    ''' </summary>
    Private Sub ConfigurarColores()

        ' Configura los colores del menú
        MenuStrip.BackColor = PaletaColores.Blanco

        ' Configura los colores de los TextBox en el GroupBoxRellenarDatos
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
    ''' Limpia los campos de entrada en el GroupBoxRellenarDatos.
    ''' </summary>
    Private Sub vaciarGroupBoxDatos()

        ' Limpia los TextBox en el GroupBoxRellenarDatos
        For Each control As Control In GroupBoxRellenarDatos.Controls

            If TypeOf control Is System.Windows.Forms.TextBox Then

                DirectCast(control, System.Windows.Forms.TextBox).Clear()

            End If

        Next

    End Sub

    ''' <summary>
    ''' Agrega una nueva asignatura.
    ''' </summary>
    Private Sub AgregarAsignatura()

        Try

            Dim Profesor As Integer

            ' Verifica si el ID del profesor es un número válido
            If Not Integer.TryParse(TextBoxProfesor.Text, Profesor) Then

                MessageBox.Show("Por favor, introduce una ID de profesor válida en el campo Profesor.")

                Return

            End If

            ' Crea un objeto de asignatura y lo agrega a la base de datos
            Dim Asignatura As Asignatura = New Asignatura With {
            .Nombre = TextBoxNombre.Text,
            .Aula = TextBoxAula.Text,
            .Profesor = TextBoxProfesor.Text}

            BaseDeDatos.AgregarAsignatura(Asignatura)

        Catch ex As Exception

            MessageBox.Show("Ha ocurrido un error al agregar la asignatura, comprueba que todos los campos hayan sido rellenados correctamente")

        End Try

    End Sub

    ''' <summary>
    ''' Elimina una asignatura seleccionada.
    ''' </summary>
    Private Sub EliminarAsignatura()

        Try

            ' Pregunta al usuario si está seguro de eliminar la asignatura
            Dim result As DialogResult = MessageBox.Show("¿Estás seguro de que quieres eliminar esta asignatura?", "Confirmación", MessageBoxButtons.YesNo)

            ' Si el usuario confirma, elimina la asignatura de la base de datos
            If result = DialogResult.Yes Then

                Dim Asignatura As Asignatura = New Asignatura With {
                    .Id = TextBoxId.Text}

                BaseDeDatos.EliminarAsignatura(Asignatura)

            End If

        Catch ex As Exception

            MessageBox.Show("Ha ocurrido un error al eliminar la asignatura, comprueba que todos los campos hayan sido rellenados correctamente")

        End Try

    End Sub

    ''' <summary>
    ''' Modifica los detalles de una asignatura.
    ''' </summary>
    Private Sub ModificarAsignatura()

        Try

            Dim Profesor As Integer

            ' Verifica si el ID del profesor es un número válido
            If Not Integer.TryParse(TextBoxProfesor.Text, Profesor) Then

                MessageBox.Show("Por favor, introduce un número válido en el campo Profesor.")

                Return

            End If

            ' Crea un objeto de asignatura con los detalles modificados y actualiza la base de datos
            Dim Asignatura As Asignatura = New Asignatura With {
            .Id = TextBoxId.Text,
            .Nombre = TextBoxNombre.Text,
            .Aula = TextBoxAula.Text,
            .Profesor = TextBoxProfesor.Text}

            BaseDeDatos.ModificarAsignatura(Asignatura)

        Catch ex As Exception

            MessageBox.Show("Ha ocurrido un error al modificar la asignatura, comprueba que todos los campos hayan sido rellenados correctamente")

        End Try

    End Sub

End Class