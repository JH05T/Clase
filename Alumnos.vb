Imports System.ComponentModel
Imports Clase.BaseDeDatos

''' <summary>
''' Clase que representa el formulario de gestión de Alumnos.
''' </summary>
Public Class Alumnos

    ''' <summary>
    ''' Índice actualmente seleccionado en el ListView.
    ''' </summary>
    Dim indiceListView As Integer = 0

    ''' <summary>
    ''' Opción seleccionada en el menú de acciones.
    ''' </summary>
    Dim opcion As String

    ''' <summary>
    ''' Método que se ejecuta cuando el formulario de Alumnos se carga inicialmente.
    ''' </summary>
    Private Sub Alumnos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Configura el formulario
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MinimizeBox = False
        Me.MaximizeBox = False

        ' Simula el clic en la opción Visualizar en el menú contextual
        VisualizarToolStripMenuItem.PerformClick()

        ' Configura el ListView
        ConfigurarListView()

        ' Carga los datos de los alumnos en el ListView
        CargarListView(BaseDeDatos.LeerDatosAlumnos())

        ' Configura los colores de los controles en el formulario
        ConfigurarColores()

    End Sub

    ''' <summary>
    ''' Evento que se dispara cuando cambia la selección en el ListView.
    ''' </summary>
    Private Sub ListView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView.SelectedIndexChanged

        ' Variables locales
        Dim FechaNacimiento As DateOnly

        ' Verifica si hay elementos seleccionados en el ListView
        If ListView.SelectedItems.Count > 0 Then

            ' Obtiene el índice seleccionado y el elemento seleccionado
            Dim indiceSeleccionado As Integer = ListView.SelectedIndices(0)

            indiceListView = indiceSeleccionado

            Dim itemSeleccionado = ListView.Items.Item(indiceSeleccionado)

            ' Actualiza los TextBox con la información del alumno seleccionado
            TextBoxId.Text = itemSeleccionado.SubItems(1).Text
            TextBoxNombre.Text = itemSeleccionado.SubItems(2).Text
            TextBoxApellidos.Text = itemSeleccionado.SubItems(3).Text
            TextBoxDireccion.Text = itemSeleccionado.SubItems(4).Text
            TextBoxLocalidad.Text = itemSeleccionado.SubItems(5).Text
            TextBoxMovil.Text = itemSeleccionado.SubItems(6).Text
            TextBoxEmail.Text = itemSeleccionado.SubItems(7).Text

            ' Intenta convertir la fecha de nacimiento y actualiza los TextBox correspondientes
            If DateOnly.TryParse(itemSeleccionado.SubItems(8).Text, FechaNacimiento) Then

                TextBoxDiaFechaNacimiento.Text = FechaNacimiento.Day.ToString
                TextBoxMesFechaNacimiento.Text = FechaNacimiento.Month.ToString
                TextBoxFechaNacimiento.Text = FechaNacimiento.Year.ToString

            End If

            ' Actualiza el TextBox de Nacionalidad
            TextBoxNacionalidad.Text = itemSeleccionado.SubItems(9).Text

        End If

    End Sub

    ''' <summary>
    ''' Evento que se dispara cuando se hace clic en el botón Siguiente.
    ''' </summary>
    Private Sub ButtonSiguiente_Click(sender As Object, e As EventArgs) Handles ButtonSiguiente.Click

        ' Verifica si hay más elementos en el ListView
        If indiceListView < ListView.Items.Count - 1 Then

            ' Deselecciona el elemento actual
            ListView.Items(indiceListView).Selected = False

            ' Incrementa el índice y selecciona el siguiente elemento
            indiceListView += 1

            ListView.Items(indiceListView).Selected = True

        End If

    End Sub

    ''' <summary>
    ''' Evento que se dispara cuando se hace clic en el botón Anterior.
    ''' </summary>
    Private Sub ButtonAnterior_Click(sender As Object, e As EventArgs) Handles ButtonAnterior.Click

        ' Verifica si hay elementos anteriores en el ListView
        If indiceListView > 0 Then

            ' Deselecciona el elemento actual
            ListView.Items(indiceListView).Selected = False

            ' Decrementa el índice y selecciona el elemento anterior
            indiceListView -= 1

            ListView.Items(indiceListView).Selected = True

        End If

    End Sub

    ''' <summary>
    ''' Evento que se dispara cuando se hace clic en el botón Primero.
    ''' </summary>
    Private Sub ButtonPrimero_Click(sender As Object, e As EventArgs) Handles ButtonPrimero.Click

        ' Deselecciona el elemento actual y selecciona el primero
        ListView.Items(indiceListView).Selected = False

        indiceListView = 0

        ListView.Items(indiceListView).Selected = True

    End Sub

    ''' <summary>
    ''' Evento que se dispara cuando se hace clic en el botón Último.
    ''' </summary>
    Private Sub ButtonUltimo_Click(sender As Object, e As EventArgs) Handles ButtonUltimo.Click

        ' Deselecciona el elemento actual y selecciona el último
        ListView.Items(indiceListView).Selected = False

        indiceListView = ListView.Items.Count - 1

        ListView.Items(indiceListView).Selected = True

    End Sub

    ''' <summary>
    ''' Evento que se dispara cuando se hace clic en el botón Buscar.
    ''' </summary>
    Private Sub ButtonBuscar_Click(sender As Object, e As EventArgs) Handles ButtonBuscar.Click

        Dim IdAlumno As Integer

        If TextBoxBuscar.Text.Equals("") Then

            ' Muestra un mensaje si el campo de búsqueda está vacío
            MsgBox("Introduce un ID para poder buscar al alumno")


            ' Verifica si el ID del alumno es un número válido
        ElseIf Not Integer.TryParse(TextBoxBuscar.Text, IdAlumno) Then

            MessageBox.Show("Por favor, introduce una ID de alumno válida.")

        Else

            ' Busca al alumno con el ID proporcionado
            Dim Alumno = BaseDeDatos.LeerDatosAlumnoBuscado(New Alumno With {.Id = TextBoxBuscar.Text})

            If Alumno.Id.Equals(0) Then

                ' Vacía los campos si no se encontró ningún alumno
                vaciarGroupBoxDatos()

            Else

                ' Rellena los campos con los datos del alumno encontrado
                TextBoxId.Text = Alumno.Id
                TextBoxNombre.Text = Alumno.Nombre
                TextBoxApellidos.Text = Alumno.Apellidos
                TextBoxDireccion.Text = Alumno.Direccion
                TextBoxLocalidad.Text = Alumno.Localidad
                TextBoxMovil.Text = Alumno.Movil
                TextBoxEmail.Text = Alumno.Email
                TextBoxDiaFechaNacimiento.Text = Alumno.FechaNacimiento.Day.ToString
                TextBoxMesFechaNacimiento.Text = Alumno.FechaNacimiento.Month.ToString
                TextBoxFechaNacimiento.Text = Alumno.FechaNacimiento.Year.ToString
                TextBoxNacionalidad.Text = Alumno.Nacionalidad

            End If

        End If

    End Sub

    ''' <summary>
    ''' Evento que se dispara cuando se hace clic en el botón Aceptar.
    ''' </summary>
    Private Sub ButtonAceptar_Click(sender As Object, e As EventArgs) Handles ButtonAceptar.Click

        ' Realiza una acción dependiendo de la opción seleccionada
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

        ' Vacía los campos después de la acción
        vaciarGroupBoxDatos()

        ' Recarga la lista de alumnos
        CargarListView(BaseDeDatos.LeerDatosAlumnos)

    End Sub

    ''' <summary>
    ''' Evento que se dispara cuando se hace clic en el botón Cancelar.
    ''' </summary>
    Private Sub ButtonCancelar_Click(sender As Object, e As EventArgs) Handles ButtonCancelar.Click

        ' Vacía los campos del grupo de datos
        vaciarGroupBoxDatos()

    End Sub

    ''' <summary>
    ''' Evento que se dispara al hacer clic en el elemento del menú Agregar.
    ''' </summary>
    Private Sub AgregarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarToolStripMenuItem.Click

        ' Cambia el color del elemento del menú y establece la opción como "Agregar"
        AgregarToolStripMenuItem.BackColor = PaletaColores.GrisNeutro
        EliminarToolStripMenuItem.BackColor = PaletaColores.Blanco
        ModificarToolStripMenuItem.BackColor = PaletaColores.Blanco
        VisualizarToolStripMenuItem.BackColor = PaletaColores.Blanco

        opcion = "Agregar"

        ' Muestra los botones Aceptar y Cancelar
        ButtonAceptar.Show()

        ButtonCancelar.Show()

        LabelId.Hide()

        TextBoxId.Hide()

    End Sub

    ''' <summary>
    ''' Evento que se dispara al hacer clic en el elemento del menú Eliminar.
    ''' </summary>
    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click

        ' Cambia el color del elemento del menú y establece la opción como "Eliminar"
        EliminarToolStripMenuItem.BackColor = PaletaColores.GrisNeutro
        AgregarToolStripMenuItem.BackColor = PaletaColores.Blanco
        ModificarToolStripMenuItem.BackColor = PaletaColores.Blanco
        VisualizarToolStripMenuItem.BackColor = PaletaColores.Blanco

        opcion = "Eliminar"

        ' Muestra los botones Aceptar y Cancelar

        ButtonAceptar.Show()

        ButtonCancelar.Show()

        LabelId.Show()

        TextBoxId.Show()

    End Sub

    ''' <summary>
    ''' Evento que se dispara al hacer clic en el elemento del menú Modificar.
    ''' </summary>
    Private Sub ModificarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarToolStripMenuItem.Click

        ' Cambia el color del elemento del menú y establece la opción como "Modificar"
        ModificarToolStripMenuItem.BackColor = PaletaColores.GrisNeutro
        AgregarToolStripMenuItem.BackColor = PaletaColores.Blanco
        EliminarToolStripMenuItem.BackColor = PaletaColores.Blanco
        VisualizarToolStripMenuItem.BackColor = PaletaColores.Blanco

        opcion = "Modificar"

        ' Muestra los botones Aceptar y Cancelar
        ButtonAceptar.Show()

        ButtonCancelar.Show()

        LabelId.Hide()

        TextBoxId.Hide()

    End Sub

    ''' <summary>
    ''' Evento que se dispara al hacer clic en el elemento del menú Visualizar.
    ''' </summary>
    Private Sub VisualizarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisualizarToolStripMenuItem.Click

        ' Cambia el color del elemento del menú y establece la opción como "Visualizar"
        VisualizarToolStripMenuItem.BackColor = PaletaColores.GrisNeutro
        AgregarToolStripMenuItem.BackColor = PaletaColores.Blanco
        EliminarToolStripMenuItem.BackColor = PaletaColores.Blanco
        ModificarToolStripMenuItem.BackColor = PaletaColores.Blanco

        opcion = "Visualizar"

        ' Oculta los botones Aceptar y Cancelar
        ButtonAceptar.Hide()

        ButtonCancelar.Hide()

        LabelId.Show()

        TextBoxId.Show()

    End Sub

    ''' <summary>
    ''' Evento que se dispara al hacer clic en el elemento del menú Volver.
    ''' </summary>
    Private Sub VolverToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VolverToolStripMenuItem.Click

        ' Oculta el formulario actual y muestra el formulario de Inicio
        Me.Hide()

        Inicio.Show()

    End Sub

    ''' <summary>
    ''' Evento que se dispara al intentar cerrar el formulario de Alumnos.
    ''' </summary>
    Private Sub Alumnos_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing

        ' Cierra el formulario de Inicio cuando se cierra el formulario de Alumnos
        Inicio.Close()

    End Sub

    ''' <summary>
    ''' Configura las columnas del ListView.
    ''' </summary>
    Private Sub ConfigurarListView()

        ' Agrega las columnas al ListView con sus respectivos tamaños y alineaciones
        ListView.Columns.Add("", 0, HorizontalAlignment.Center)
        ListView.Columns.Add("Id", 30, HorizontalAlignment.Center)
        ListView.Columns.Add("Nombre", 100, HorizontalAlignment.Center)
        ListView.Columns.Add("Apellidos", 150, HorizontalAlignment.Center)
        ListView.Columns.Add("Dirección", 150, HorizontalAlignment.Center)
        ListView.Columns.Add("Localidad", 100, HorizontalAlignment.Center)
        ListView.Columns.Add("Móvil", 100, HorizontalAlignment.Center)
        ListView.Columns.Add("Email", 145, HorizontalAlignment.Center)
        ListView.Columns.Add("F. Nacimiento", 100, HorizontalAlignment.Center)
        ListView.Columns.Add("Nacionalidad", 100, HorizontalAlignment.Center)

    End Sub

    ''' <summary>
    ''' Carga los datos de los alumnos en el ListView.
    ''' </summary>
    ''' <param name="DatosAlumnos">Los datos de los alumnos en forma de DataSet.</param>
    Private Sub CargarListView(DatosAlumnos As DataSet)

        ' Limpia los elementos existentes en el ListView
        ListView.Items.Clear()

        ListView.View = View.Details

        ' Itera sobre los datos de los alumnos y los agrega al ListView
        For pos As Integer = 0 To DatosAlumnos.Tables(0).Rows.Count - 1

            Dim ElementoList As ListViewItem = ListView.Items.Add(DatosAlumnos.Tables(0).Rows(pos).Item(0))

            For i As Integer = 0 To DatosAlumnos.Tables(0).Columns.Count - 1

                ElementoList.SubItems.Add(DatosAlumnos.Tables(0).Rows(pos).Item(i).ToString())

            Next

        Next

    End Sub

    ''' <summary>
    ''' Configura los colores de los elementos visuales en el formulario.
    ''' </summary>
    Private Sub ConfigurarColores()

        ' Configura los colores de los elementos visuales en el formulario
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

    ''' <summary>
    ''' Limpia los campos de entrada en el GroupBox de rellenar datos.
    ''' </summary>
    Private Sub vaciarGroupBoxDatos()

        ' Limpia los campos de texto en el GroupBox de rellenar datos
        For Each control As Control In GroupBoxRellenarDatos.Controls

            If TypeOf control Is System.Windows.Forms.TextBox Then

                DirectCast(control, System.Windows.Forms.TextBox).Clear()

            End If

        Next

    End Sub

    ''' <summary>
    ''' Agrega un nuevo alumno a la base de datos.
    ''' </summary>
    Private Sub AgregarAlumno()

        ' Valida los datos de entrada para asegurar que son números válidos y tienen el formato correcto
        Dim Dia, Mes, Year As Integer
        Dim Movil As Long

        If Not Integer.TryParse(TextBoxDiaFechaNacimiento.Text, Dia) Then

            MessageBox.Show("Por favor, introduce un número válido en el campo Día.")

        ElseIf Not Integer.TryParse(TextBoxMesFechaNacimiento.Text, Mes) Then

            MessageBox.Show("Por favor, introduce un número válido en el campo Mes.")

        ElseIf Not Integer.TryParse(TextBoxFechaNacimiento.Text, Year) Then

            MessageBox.Show("Por favor, introduce un número válido en el campo Año.")

        ElseIf Not Long.TryParse(TextBoxMovil.Text, Movil) OrElse TextBoxMovil.Text.Length <> 9 Then

            MessageBox.Show("Por favor, introduce un número de teléfono móvil válido de 9 dígitos.")

        Else

            ' Crea un nuevo objeto Alumno con los datos ingresados por el usuario
            Dim Alumno As Alumno = New Alumno With {
            .Nombre = TextBoxNombre.Text,
            .Apellidos = TextBoxApellidos.Text,
            .Direccion = TextBoxDireccion.Text,
            .Localidad = TextBoxLocalidad.Text,
            .Movil = TextBoxMovil.Text,
            .Email = TextBoxEmail.Text,
            .FechaNacimiento = New DateOnly(Year, Mes, Dia),
            .Nacionalidad = TextBoxNacionalidad.Text}

            ' Agrega el nuevo alumno a la base de datos
            BaseDeDatos.AgregarAlumno(Alumno)

        End If

    End Sub

    ''' <summary>
    ''' Elimina un alumno de la base de datos.
    ''' </summary>
    Private Sub EliminarAlumno()

        ' Muestra un mensaje de confirmación antes de eliminar al alumno seleccionado
        Dim result As DialogResult = MessageBox.Show("¿Estás seguro de que quieres eliminar este alumno?", "Confirmación", MessageBoxButtons.YesNo)

        If result = DialogResult.Yes Then

            ' Crea un objeto Alumno con el ID del alumno a eliminar y llama a la función correspondiente en la base de datos
            Dim Alumno As Alumno = New Alumno With {
                .Id = TextBoxId.Text}

            BaseDeDatos.EliminarAlumno(Alumno)

        End If

    End Sub

    ''' <summary>
    ''' Modifica los datos de un alumno en la base de datos.
    ''' </summary>
    Private Sub ModificarAlumno()

        ' Valida los datos de entrada para asegurar que son números válidos y tienen el formato correcto
        Dim Dia, Mes, Year As Integer
        Dim Movil As Long

        If Not Integer.TryParse(TextBoxDiaFechaNacimiento.Text, Dia) Then

            MessageBox.Show("Por favor, introduce un número válido en el campo Día.")

        ElseIf Not Integer.TryParse(TextBoxMesFechaNacimiento.Text, Mes) Then

            MessageBox.Show("Por favor, introduce un número válido en el campo Mes.")

        ElseIf Not Integer.TryParse(TextBoxFechaNacimiento.Text, Year) Then

            MessageBox.Show("Por favor, introduce un número válido en el campo Año.")

        ElseIf Not Long.TryParse(TextBoxMovil.Text, Movil) OrElse TextBoxMovil.Text.Length <> 9 Then

            MessageBox.Show("Por favor, introduce un número de teléfono móvil válido de 9 dígitos.")

        Else

            ' Crea un objeto Alumno con los datos ingresados por el usuario, incluyendo el ID del alumno a modificar
            Dim Alumno As Alumno = New Alumno With {
            .Id = TextBoxId.Text,
            .Nombre = TextBoxNombre.Text,
            .Apellidos = TextBoxApellidos.Text,
            .Direccion = TextBoxDireccion.Text,
            .Localidad = TextBoxLocalidad.Text,
            .Movil = TextBoxMovil.Text,
            .Email = TextBoxEmail.Text,
            .FechaNacimiento = New DateOnly(Year, Mes, Dia),
            .Nacionalidad = TextBoxNacionalidad.Text}

            ' Llama a la función correspondiente en la base de datos para modificar los datos del alumno
            BaseDeDatos.ModificarAlumno(Alumno)

        End If

    End Sub

End Class