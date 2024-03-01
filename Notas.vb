Imports System.ComponentModel

''' <summary>
''' Clase que representa el formulario de gestión de notas.
''' </summary>
Public Class Notas

    ''' <summary>
    ''' Índice actualmente seleccionado en el ListView.
    ''' </summary>
    Dim indiceListView As Integer = 0

    ''' <summary>
    ''' Opción actual seleccionada (Agregar, Eliminar, Modificar o Visualizar).
    ''' </summary>
    Dim opcion As String

    ''' <summary>
    ''' Maneja el evento Load del formulario. Configura la interfaz inicial y carga los datos de notas.
    ''' </summary>
    Private Sub Notas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Configuración inicial del formulario
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MinimizeBox = False
        Me.MaximizeBox = False
        Me.DoubleBuffered = True

        ' Realiza un clic en el menú Visualizar
        VisualizarToolStripMenuItem.PerformClick()

        ' Configura el ListView
        ConfigurarListView()

        ' Carga los datos de notas en el ListView
        CargarListView(BaseDeDatos.LeerDatosNotas())

        ' Configura los colores de los controles
        ConfigurarColores()

    End Sub

    ''' <summary>
    ''' Maneja el evento SelectedIndexChanged del ListView. Muestra los detalles de la nota seleccionada.
    ''' </summary>
    Private Sub ListView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView.SelectedIndexChanged

        If ListView.SelectedItems.Count > 0 Then

            ' Obtiene el índice y el elemento seleccionado en el ListView
            Dim indiceSeleccionado As Integer = ListView.SelectedIndices(0)
            indiceListView = indiceSeleccionado
            Dim itemSeleccionado = ListView.Items.Item(indiceSeleccionado)

            ' Muestra los detalles de la nota seleccionada en los TextBox correspondientes
            TextBoxAlumno.Text = itemSeleccionado.SubItems(1).Text
            TextBoxAsignatura.Text = itemSeleccionado.SubItems(2).Text
            TextBoxNota1.Text = itemSeleccionado.SubItems(3).Text
            TextBoxNota2.Text = itemSeleccionado.SubItems(4).Text
            TextBoxNota3.Text = itemSeleccionado.SubItems(5).Text
            TextBoxNotaFinal.Text = itemSeleccionado.SubItems(6).Text

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
    ''' Maneja el evento Click del botón Buscar. Busca una nota por ID de alumno y asignatura y muestra sus detalles.
    ''' </summary>
    Private Sub ButtonBuscar_Click(sender As Object, e As EventArgs) Handles ButtonBuscar.Click

        Dim idAlumno As Integer
        Dim idAsignatura As Integer
        Dim idAlumnoValido As Boolean = Integer.TryParse(TextBoxBuscarAlumno.Text, idAlumno)
        Dim idAsignaturaValido As Boolean = Integer.TryParse(TextBoxBuscarAsignatura.Text, idAsignatura)

        If idAlumnoValido And idAsignaturaValido Then

            ' Busca la nota por ID de alumno y asignatura en la base de datos y muestra sus detalles si se encuentra
            Dim Nota = BaseDeDatos.LeerDatosNotaBuscada(New Nota With {.Alumno = idAlumno, .Asignatura = idAsignatura})

            MostrarNota(Nota)

        ElseIf idAlumnoValido Then

            ' Busca las notas por ID de alumno en la base de datos y muestra sus detalles si se encuentran
            Dim Notas = BaseDeDatos.LeerDatosNotasAlumno(idAlumno)

            MostrarNotas(Notas)

        ElseIf idAsignaturaValido Then

            ' Busca las notas por ID de asignatura en la base de datos y muestra sus detalles si se encuentran
            Dim Notas = BaseDeDatos.LeerDatosNotasAsignatura(idAsignatura)

            MostrarNotas(Notas)

        Else

            CargarListView(BaseDeDatos.LeerDatosNotas)

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
    ''' Maneja el evento Click del botón Aceptar. Realiza la acción correspondiente (Agregar, Eliminar, Modificar o Visualizar) según la opción seleccionada.
    ''' </summary>
    Private Sub ButtonAceptar_Click(sender As Object, e As EventArgs) Handles ButtonAceptar.Click

        Select Case opcion

            Case "Agregar"

                AgregarNota()

            Case "Eliminar"

                EliminarNota()

            Case "Modificar"

                ModificarNota()

            Case "Visualizar"

            Case Else

        End Select

        ' Limpia los datos de los controles y recarga el ListView
        vaciarGroupBoxDatos()

        CargarListView(BaseDeDatos.LeerDatosNotas)

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

        ' Configura la opción y muestra los controles necesarios para agregar una nota
        AgregarToolStripMenuItem.BackColor = PaletaColores.GrisNeutro
        EliminarToolStripMenuItem.BackColor = PaletaColores.Blanco
        ModificarToolStripMenuItem.BackColor = PaletaColores.Blanco
        VisualizarToolStripMenuItem.BackColor = PaletaColores.Blanco

        opcion = "Agregar"

        ButtonAceptar.Show()

        ButtonCancelar.Show()

        PictureBox.Show()

        LabelNotaFinal.Hide()

        TextBoxNotaFinal.Hide()

        GroupBoxBuscar.Hide()

    End Sub

    ''' <summary>
    ''' Maneja el evento Click del elemento de menú Eliminar. Selecciona la opción Eliminar y muestra los controles correspondientes.
    ''' </summary>
    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click

        ' Configura la opción y muestra los controles necesarios para eliminar una nota
        EliminarToolStripMenuItem.BackColor = PaletaColores.GrisNeutro
        AgregarToolStripMenuItem.BackColor = PaletaColores.Blanco
        ModificarToolStripMenuItem.BackColor = PaletaColores.Blanco
        VisualizarToolStripMenuItem.BackColor = PaletaColores.Blanco

        opcion = "Eliminar"

        ButtonAceptar.Show()

        ButtonCancelar.Show()

        LabelNotaFinal.Show()

        TextBoxNotaFinal.Show()

        PictureBox.Hide()

        GroupBoxBuscar.Show()

    End Sub

    ''' <summary>
    ''' Maneja el evento Click del elemento de menú Modificar. Selecciona la opción Modificar y muestra los controles correspondientes.
    ''' </summary>
    Private Sub ModificarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarToolStripMenuItem.Click

        ' Configura la opción y muestra los controles necesarios para modificar una nota
        ModificarToolStripMenuItem.BackColor = PaletaColores.GrisNeutro
        AgregarToolStripMenuItem.BackColor = PaletaColores.Blanco
        EliminarToolStripMenuItem.BackColor = PaletaColores.Blanco
        VisualizarToolStripMenuItem.BackColor = PaletaColores.Blanco

        opcion = "Modificar"

        PictureBox.Hide()

        LabelNotaFinal.Hide()

        TextBoxNotaFinal.Hide()

        ButtonAceptar.Show()

        ButtonCancelar.Show()

        GroupBoxBuscar.Show()

    End Sub

    ''' <summary>
    ''' Maneja el evento Click del elemento de menú Visualizar. Selecciona la opción Visualizar y muestra los controles correspondientes.
    ''' </summary>
    Private Sub VisualizarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisualizarToolStripMenuItem.Click

        ' Configura la opción y muestra los controles necesarios para visualizar las notas
        VisualizarToolStripMenuItem.BackColor = PaletaColores.GrisNeutro
        AgregarToolStripMenuItem.BackColor = PaletaColores.Blanco
        EliminarToolStripMenuItem.BackColor = PaletaColores.Blanco
        ModificarToolStripMenuItem.BackColor = PaletaColores.Blanco

        opcion = "Visualizar"

        ButtonAceptar.Hide()

        ButtonCancelar.Hide()

        PictureBox.Hide()

        LabelNotaFinal.Show()

        TextBoxNotaFinal.Show()

        GroupBoxBuscar.Show()

    End Sub

    ''' <summary>
    ''' Maneja el evento Click del elemento de menú Volver. Oculta el formulario actual y muestra el formulario de inicio.
    ''' </summary>
    Private Sub VolverToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VolverToolStripMenuItem.Click

        Me.Hide()

        Inicio.Show()

    End Sub

    ''' <summary>
    ''' Este método se ejecuta cuando se hace clic en el botón ButtonAyuda.
    ''' </summary>
    Private Sub ButtonAyuda_Click(sender As Object, e As EventArgs) Handles ButtonAyuda.Click

        ' Define una variable "ruta" que contiene la ruta del archivo "DocNotas.pdf" en el directorio de inicio de la aplicación.
        Dim ruta As String = Application.StartupPath.Substring(0, Application.StartupPath.Length - 25) + "Doc\DocNotas.pdf"

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
    ''' Maneja el evento Closing del formulario. Cierra el formulario de inicio al cerrar este formulario.
    ''' </summary>
    Private Sub Notas_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing

        Inicio.Close()

    End Sub

    ''' <summary>
    ''' Configura el ListView para mostrar los datos de las notas.
    ''' </summary>
    Private Sub ConfigurarListView()

        ListView.Columns.Add("", 0, HorizontalAlignment.Center)
        ListView.Columns.Add("Alumno", 88, HorizontalAlignment.Center)
        ListView.Columns.Add("Asignatura", 88, HorizontalAlignment.Center)
        ListView.Columns.Add("Nota1", 75, HorizontalAlignment.Center)
        ListView.Columns.Add("Nota2", 75, HorizontalAlignment.Center)
        ListView.Columns.Add("Nota3", 75, HorizontalAlignment.Center)
        ListView.Columns.Add("NotaFinal", 75, HorizontalAlignment.Center)

    End Sub

    ''' <summary>
    ''' Carga los datos de las notas en el ListView.
    ''' </summary>
    ''' <param name="DatosNotas">DataSet que contiene los datos de las notas.</param>
    Private Sub CargarListView(DatosNotas As DataSet)

        Dim ElementoList As ListViewItem

        ListView.Items.Clear()

        ListView.View = View.Details

        ' Itera sobre los datos de las notas y los agrega al ListView
        ' Itera sobre los datos de las notas y los agrega al ListView
        For pos As Integer = 0 To DatosNotas.Tables(0).Rows.Count - 1

            ElementoList = ListView.Items.Add(DatosNotas.Tables(0).Rows(pos).Item(0))

            ElementoList.SubItems.Add(DatosNotas.Tables(0).Rows(pos).Item(0))
            ElementoList.SubItems.Add(DatosNotas.Tables(0).Rows(pos).Item(1))
            ElementoList.SubItems.Add(Math.Round(DatosNotas.Tables(0).Rows(pos).Item(2), 2))
            ElementoList.SubItems.Add(Math.Round(DatosNotas.Tables(0).Rows(pos).Item(3), 2))
            ElementoList.SubItems.Add(Math.Round(DatosNotas.Tables(0).Rows(pos).Item(4), 2))
            ElementoList.SubItems.Add(Math.Round(DatosNotas.Tables(0).Rows(pos).Item(5), 2))

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
    Private Sub MostrarNota(Nota As Nota)

        If Nota.Alumno.Equals(0) Then

            vaciarGroupBoxDatos()

        Else

            TextBoxAlumno.Text = Nota.Alumno
            TextBoxAsignatura.Text = Nota.Asignatura
            TextBoxNota1.Text = Nota.Nota1
            TextBoxNota2.Text = Nota.Nota2
            TextBoxNota3.Text = Nota.Nota3
            TextBoxNotaFinal.Text = Nota.NotaFinal

        End If

    End Sub

    Private Sub MostrarNotas(Notas As DataSet)

        CargarListView(Notas)

    End Sub

    ''' <summary>
    ''' Agrega una nueva nota a la base de datos.
    ''' </summary>
    Private Sub AgregarNota()

        Try

            Dim Nota As Nota = New Nota
            Dim Alumno, Asignatura As Integer
            Dim Nota1, Nota2, Nota3 As Single

            ' Reemplaza las comas por puntos en las cadenas de texto
            Dim Nota1Text As String = TextBoxNota1.Text.Replace(".", ",")
            Dim Nota2Text As String = TextBoxNota2.Text.Replace(".", ",")
            Dim Nota3Text As String = TextBoxNota3.Text.Replace(".", ",")

            ' Convierte los valores de texto a números
            If Integer.TryParse(TextBoxAlumno.Text, Alumno) AndAlso Integer.TryParse(TextBoxAsignatura.Text, Asignatura) AndAlso Single.TryParse(Nota1Text, Nota1) AndAlso Single.TryParse(Nota2Text, Nota2) AndAlso Single.TryParse(Nota3Text, Nota3) Then

                ' Asigna los valores a la estructura Nota
                Nota.Alumno = Alumno
                Nota.Asignatura = Asignatura
                Nota.Nota1 = Nota1
                Nota.Nota2 = Nota2
                Nota.Nota3 = Nota3

                ' Calcula la nota final como el promedio de Nota1, Nota2 y Nota3
                Nota.NotaFinal = (Nota.Nota1 + Nota.Nota2 + Nota.Nota3) / 3

                ' Agrega la nota a la base de datos
                BaseDeDatos.AgregarNota(Nota)

            Else

                MsgBox("Por favor, es necesario introducir una ID válida para el alumno y la asignatura.", , "")

            End If

        Catch ex As Exception

            MessageBox.Show("Ha ocurrido un error al agregar la nota, comprueba que todos los campos hayan sido rellenados correctamente")

        End Try

    End Sub


    ''' <summary>
    ''' Elimina una nota de la base de datos.
    ''' </summary>
    Private Sub EliminarNota()

        Try

            Dim result As DialogResult = MessageBox.Show("¿Estás seguro de que quieres eliminar esta nota?", "Confirmación", MessageBoxButtons.YesNo)

            If result = DialogResult.Yes Then

                Dim Nota As Nota = New Nota With {
                .Alumno = TextBoxAlumno.Text,
                .Asignatura = TextBoxAsignatura.Text}

                BaseDeDatos.EliminarNota(Nota)

            End If

        Catch ex As Exception

            MessageBox.Show("Ha ocurrido un error al eliminar la nota, comprueba que todos los campos hayan sido rellenados correctamente")

        End Try

    End Sub

    ''' <summary>
    ''' Modifica las notas de un alumno en la base de datos.
    ''' </summary>
    Private Sub ModificarNota()

        Try

            Dim Nota As Nota = New Nota
            Dim Alumno, Asignatura As Integer
            Dim Nota1, Nota2, Nota3 As Single

            ' Reemplaza las comas por puntos en las cadenas de texto
            Dim Nota1Text As String = TextBoxNota1.Text.Replace(".", ",")
            Dim Nota2Text As String = TextBoxNota2.Text.Replace(".", ",")
            Dim Nota3Text As String = TextBoxNota3.Text.Replace(".", ",")

            ' Convierte los valores de texto a números
            If Integer.TryParse(TextBoxAlumno.Text, Alumno) AndAlso Integer.TryParse(TextBoxAsignatura.Text, Asignatura) AndAlso Single.TryParse(Nota1Text, Nota1) AndAlso Single.TryParse(Nota2Text, Nota2) AndAlso Single.TryParse(Nota3Text, Nota3) Then

                ' Asigna los valores a la estructura Nota
                Nota.Alumno = Alumno
                Nota.Asignatura = Asignatura
                Nota.Nota1 = Nota1
                Nota.Nota2 = Nota2
                Nota.Nota3 = Nota3

                ' Calcula la nota final como el promedio de Nota1, Nota2 y Nota3
                Nota.NotaFinal = (Nota.Nota1 + Nota.Nota2 + Nota.Nota3) / 3

                ' Agrega la nota a la base de datos
                BaseDeDatos.ModificarNota(Nota)

            Else

                MsgBox("Por favor, es necesario introducir una ID válida para el alumno y la asignatura.", , "")

            End If

        Catch ex As Exception

            MessageBox.Show("Ha ocurrido un error al modificar la nota, comprueba que todos los campos hayan sido rellenados correctamente")

        End Try

    End Sub

End Class