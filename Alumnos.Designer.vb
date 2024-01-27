<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Alumnos
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        MenuStripAlumnos = New MenuStrip()
        AgregarToolStripMenuItem = New ToolStripMenuItem()
        EliminarToolStripMenuItem = New ToolStripMenuItem()
        ModificarToolStripMenuItem = New ToolStripMenuItem()
        VisualizarToolStripMenuItem = New ToolStripMenuItem()
        ListView = New ListView()
        LabelId = New Label()
        LabelNombre = New Label()
        LabelApellidos = New Label()
        LabelDireccion = New Label()
        LabelLocalidad = New Label()
        LabelMovil = New Label()
        LabelEmail = New Label()
        LabelFechaNacimiento = New Label()
        LabelNacionalidad = New Label()
        TextBoxId = New TextBox()
        TextBoxNombre = New TextBox()
        TextBoxApellidos = New TextBox()
        TextBoxDireccion = New TextBox()
        TextBoxLocalidad = New TextBox()
        TextBoxMovil = New TextBox()
        TextBoxEmail = New TextBox()
        TextBoxFechaNacimiento = New TextBox()
        TextBoxNacionalidad = New TextBox()
        GroupBoxRellenarDatos = New GroupBox()
        LabelYear = New Label()
        LabelMes = New Label()
        LabelDia = New Label()
        ComboBoxMesFechaNacimiento = New ComboBox()
        ComboBoxDiaFechaNacimiento = New ComboBox()
        GroupBoxBuscar = New GroupBox()
        LabelBuscar = New Label()
        TextBoxBuscar = New TextBox()
        ButtonBuscar = New Button()
        ButtonUltimo = New Button()
        ButtonSiguiente = New Button()
        ButtonAnterior = New Button()
        ButtonPrimero = New Button()
        ButtonAceptar = New Button()
        ButtonCancelar = New Button()
        MenuStripAlumnos.SuspendLayout()
        GroupBoxRellenarDatos.SuspendLayout()
        GroupBoxBuscar.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStripAlumnos
        ' 
        MenuStripAlumnos.BackColor = Color.White
        MenuStripAlumnos.Items.AddRange(New ToolStripItem() {AgregarToolStripMenuItem, EliminarToolStripMenuItem, ModificarToolStripMenuItem, VisualizarToolStripMenuItem})
        MenuStripAlumnos.Location = New Point(0, 0)
        MenuStripAlumnos.Name = "MenuStripAlumnos"
        MenuStripAlumnos.Size = New Size(1234, 24)
        MenuStripAlumnos.TabIndex = 1
        ' 
        ' AgregarToolStripMenuItem
        ' 
        AgregarToolStripMenuItem.Name = "AgregarToolStripMenuItem"
        AgregarToolStripMenuItem.Size = New Size(61, 20)
        AgregarToolStripMenuItem.Text = "Agregar"
        ' 
        ' EliminarToolStripMenuItem
        ' 
        EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        EliminarToolStripMenuItem.Size = New Size(62, 20)
        EliminarToolStripMenuItem.Text = "Eliminar"
        ' 
        ' ModificarToolStripMenuItem
        ' 
        ModificarToolStripMenuItem.Name = "ModificarToolStripMenuItem"
        ModificarToolStripMenuItem.Size = New Size(70, 20)
        ModificarToolStripMenuItem.Text = "Modificar"
        ' 
        ' VisualizarToolStripMenuItem
        ' 
        VisualizarToolStripMenuItem.Name = "VisualizarToolStripMenuItem"
        VisualizarToolStripMenuItem.Size = New Size(68, 20)
        VisualizarToolStripMenuItem.Text = "Visualizar"
        ' 
        ' ListView
        ' 
        ListView.FullRowSelect = True
        ListView.GridLines = True
        ListView.Location = New Point(117, 400)
        ListView.Name = "ListView"
        ListView.Size = New Size(1000, 256)
        ListView.TabIndex = 2
        ListView.UseCompatibleStateImageBehavior = False
        ' 
        ' LabelId
        ' 
        LabelId.Location = New Point(1, 50)
        LabelId.Name = "LabelId"
        LabelId.Size = New Size(120, 23)
        LabelId.TabIndex = 3
        LabelId.Text = "Id"
        LabelId.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabelNombre
        ' 
        LabelNombre.Location = New Point(359, 50)
        LabelNombre.Name = "LabelNombre"
        LabelNombre.Size = New Size(120, 23)
        LabelNombre.TabIndex = 4
        LabelNombre.Text = "Nombre"
        LabelNombre.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabelApellidos
        ' 
        LabelApellidos.Location = New Point(721, 50)
        LabelApellidos.Name = "LabelApellidos"
        LabelApellidos.Size = New Size(120, 23)
        LabelApellidos.TabIndex = 5
        LabelApellidos.Text = "Apellidos"
        LabelApellidos.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabelDireccion
        ' 
        LabelDireccion.Location = New Point(1, 150)
        LabelDireccion.Name = "LabelDireccion"
        LabelDireccion.Size = New Size(120, 23)
        LabelDireccion.TabIndex = 6
        LabelDireccion.Text = "Dirección"
        LabelDireccion.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabelLocalidad
        ' 
        LabelLocalidad.Location = New Point(359, 150)
        LabelLocalidad.Name = "LabelLocalidad"
        LabelLocalidad.Size = New Size(120, 23)
        LabelLocalidad.TabIndex = 7
        LabelLocalidad.Text = "Localidad"
        LabelLocalidad.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabelMovil
        ' 
        LabelMovil.Location = New Point(721, 150)
        LabelMovil.Name = "LabelMovil"
        LabelMovil.Size = New Size(120, 23)
        LabelMovil.TabIndex = 8
        LabelMovil.Text = "Móvil"
        LabelMovil.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabelEmail
        ' 
        LabelEmail.Location = New Point(1, 250)
        LabelEmail.Name = "LabelEmail"
        LabelEmail.Size = New Size(120, 23)
        LabelEmail.TabIndex = 9
        LabelEmail.Text = "Email"
        LabelEmail.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabelFechaNacimiento
        ' 
        LabelFechaNacimiento.Location = New Point(359, 250)
        LabelFechaNacimiento.Name = "LabelFechaNacimiento"
        LabelFechaNacimiento.Size = New Size(120, 23)
        LabelFechaNacimiento.TabIndex = 10
        LabelFechaNacimiento.Text = "Fecha De Nacimiento"
        LabelFechaNacimiento.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabelNacionalidad
        ' 
        LabelNacionalidad.Location = New Point(719, 250)
        LabelNacionalidad.Name = "LabelNacionalidad"
        LabelNacionalidad.Size = New Size(120, 23)
        LabelNacionalidad.TabIndex = 11
        LabelNacionalidad.Text = "Nacionalidad"
        LabelNacionalidad.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' TextBoxId
        ' 
        TextBoxId.Location = New Point(127, 50)
        TextBoxId.Name = "TextBoxId"
        TextBoxId.ReadOnly = True
        TextBoxId.Size = New Size(150, 23)
        TextBoxId.TabIndex = 0
        ' 
        ' TextBoxNombre
        ' 
        TextBoxNombre.Location = New Point(485, 50)
        TextBoxNombre.Name = "TextBoxNombre"
        TextBoxNombre.Size = New Size(150, 23)
        TextBoxNombre.TabIndex = 1
        ' 
        ' TextBoxApellidos
        ' 
        TextBoxApellidos.Location = New Point(847, 50)
        TextBoxApellidos.Name = "TextBoxApellidos"
        TextBoxApellidos.Size = New Size(150, 23)
        TextBoxApellidos.TabIndex = 2
        ' 
        ' TextBoxDireccion
        ' 
        TextBoxDireccion.Location = New Point(127, 150)
        TextBoxDireccion.Name = "TextBoxDireccion"
        TextBoxDireccion.Size = New Size(150, 23)
        TextBoxDireccion.TabIndex = 3
        ' 
        ' TextBoxLocalidad
        ' 
        TextBoxLocalidad.Location = New Point(485, 150)
        TextBoxLocalidad.Name = "TextBoxLocalidad"
        TextBoxLocalidad.Size = New Size(150, 23)
        TextBoxLocalidad.TabIndex = 4
        ' 
        ' TextBoxMovil
        ' 
        TextBoxMovil.Location = New Point(847, 150)
        TextBoxMovil.Name = "TextBoxMovil"
        TextBoxMovil.Size = New Size(150, 23)
        TextBoxMovil.TabIndex = 5
        ' 
        ' TextBoxEmail
        ' 
        TextBoxEmail.Location = New Point(127, 250)
        TextBoxEmail.Name = "TextBoxEmail"
        TextBoxEmail.Size = New Size(150, 23)
        TextBoxEmail.TabIndex = 6
        ' 
        ' TextBoxFechaNacimiento
        ' 
        TextBoxFechaNacimiento.Location = New Point(585, 250)
        TextBoxFechaNacimiento.Name = "TextBoxFechaNacimiento"
        TextBoxFechaNacimiento.Size = New Size(50, 23)
        TextBoxFechaNacimiento.TabIndex = 9
        ' 
        ' TextBoxNacionalidad
        ' 
        TextBoxNacionalidad.Location = New Point(845, 250)
        TextBoxNacionalidad.Name = "TextBoxNacionalidad"
        TextBoxNacionalidad.Size = New Size(150, 23)
        TextBoxNacionalidad.TabIndex = 10
        ' 
        ' GroupBoxRellenarDatos
        ' 
        GroupBoxRellenarDatos.Controls.Add(LabelYear)
        GroupBoxRellenarDatos.Controls.Add(LabelMes)
        GroupBoxRellenarDatos.Controls.Add(LabelDia)
        GroupBoxRellenarDatos.Controls.Add(ComboBoxMesFechaNacimiento)
        GroupBoxRellenarDatos.Controls.Add(ComboBoxDiaFechaNacimiento)
        GroupBoxRellenarDatos.Controls.Add(TextBoxNacionalidad)
        GroupBoxRellenarDatos.Controls.Add(LabelId)
        GroupBoxRellenarDatos.Controls.Add(TextBoxFechaNacimiento)
        GroupBoxRellenarDatos.Controls.Add(LabelNombre)
        GroupBoxRellenarDatos.Controls.Add(TextBoxEmail)
        GroupBoxRellenarDatos.Controls.Add(LabelApellidos)
        GroupBoxRellenarDatos.Controls.Add(TextBoxMovil)
        GroupBoxRellenarDatos.Controls.Add(LabelDireccion)
        GroupBoxRellenarDatos.Controls.Add(TextBoxLocalidad)
        GroupBoxRellenarDatos.Controls.Add(LabelLocalidad)
        GroupBoxRellenarDatos.Controls.Add(TextBoxDireccion)
        GroupBoxRellenarDatos.Controls.Add(LabelMovil)
        GroupBoxRellenarDatos.Controls.Add(TextBoxApellidos)
        GroupBoxRellenarDatos.Controls.Add(LabelEmail)
        GroupBoxRellenarDatos.Controls.Add(TextBoxNombre)
        GroupBoxRellenarDatos.Controls.Add(LabelFechaNacimiento)
        GroupBoxRellenarDatos.Controls.Add(TextBoxId)
        GroupBoxRellenarDatos.Controls.Add(LabelNacionalidad)
        GroupBoxRellenarDatos.Location = New Point(117, 50)
        GroupBoxRellenarDatos.Name = "GroupBoxRellenarDatos"
        GroupBoxRellenarDatos.Size = New Size(1000, 300)
        GroupBoxRellenarDatos.TabIndex = 0
        GroupBoxRellenarDatos.TabStop = False
        ' 
        ' LabelYear
        ' 
        LabelYear.Location = New Point(585, 224)
        LabelYear.Name = "LabelYear"
        LabelYear.Size = New Size(50, 23)
        LabelYear.TabIndex = 14
        LabelYear.Text = "Año"
        LabelYear.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabelMes
        ' 
        LabelMes.Location = New Point(535, 224)
        LabelMes.Name = "LabelMes"
        LabelMes.Size = New Size(50, 23)
        LabelMes.TabIndex = 13
        LabelMes.Text = "Mes"
        LabelMes.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabelDia
        ' 
        LabelDia.Location = New Point(485, 224)
        LabelDia.Name = "LabelDia"
        LabelDia.Size = New Size(50, 23)
        LabelDia.TabIndex = 12
        LabelDia.Text = "Día"
        LabelDia.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' ComboBoxMesFechaNacimiento
        ' 
        ComboBoxMesFechaNacimiento.FormattingEnabled = True
        ComboBoxMesFechaNacimiento.Location = New Point(535, 250)
        ComboBoxMesFechaNacimiento.Name = "ComboBoxMesFechaNacimiento"
        ComboBoxMesFechaNacimiento.Size = New Size(50, 23)
        ComboBoxMesFechaNacimiento.TabIndex = 8
        ' 
        ' ComboBoxDiaFechaNacimiento
        ' 
        ComboBoxDiaFechaNacimiento.FormattingEnabled = True
        ComboBoxDiaFechaNacimiento.Location = New Point(485, 250)
        ComboBoxDiaFechaNacimiento.Name = "ComboBoxDiaFechaNacimiento"
        ComboBoxDiaFechaNacimiento.Size = New Size(50, 23)
        ComboBoxDiaFechaNacimiento.TabIndex = 7
        ' 
        ' GroupBoxBuscar
        ' 
        GroupBoxBuscar.Controls.Add(LabelBuscar)
        GroupBoxBuscar.Controls.Add(TextBoxBuscar)
        GroupBoxBuscar.Controls.Add(ButtonBuscar)
        GroupBoxBuscar.Controls.Add(ButtonUltimo)
        GroupBoxBuscar.Controls.Add(ButtonSiguiente)
        GroupBoxBuscar.Controls.Add(ButtonAnterior)
        GroupBoxBuscar.Controls.Add(ButtonPrimero)
        GroupBoxBuscar.Location = New Point(117, 349)
        GroupBoxBuscar.Name = "GroupBoxBuscar"
        GroupBoxBuscar.Size = New Size(1000, 44)
        GroupBoxBuscar.TabIndex = 1
        GroupBoxBuscar.TabStop = False
        ' 
        ' LabelBuscar
        ' 
        LabelBuscar.Location = New Point(245, 15)
        LabelBuscar.Name = "LabelBuscar"
        LabelBuscar.Size = New Size(300, 23)
        LabelBuscar.TabIndex = 7
        LabelBuscar.Text = "Introduce la ID del alumno que estás buscando:"
        LabelBuscar.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' TextBoxBuscar
        ' 
        TextBoxBuscar.Location = New Point(550, 15)
        TextBoxBuscar.Name = "TextBoxBuscar"
        TextBoxBuscar.Size = New Size(150, 23)
        TextBoxBuscar.TabIndex = 2
        ' 
        ' ButtonBuscar
        ' 
        ButtonBuscar.Location = New Point(705, 8)
        ButtonBuscar.Name = "ButtonBuscar"
        ButtonBuscar.Size = New Size(35, 35)
        ButtonBuscar.TabIndex = 3
        ButtonBuscar.Text = "ButtonBuscar"
        ButtonBuscar.UseVisualStyleBackColor = True
        ' 
        ' ButtonUltimo
        ' 
        ButtonUltimo.Location = New Point(925, 8)
        ButtonUltimo.Name = "ButtonUltimo"
        ButtonUltimo.Size = New Size(75, 35)
        ButtonUltimo.TabIndex = 5
        ButtonUltimo.Text = "Último"
        ButtonUltimo.UseVisualStyleBackColor = True
        ' 
        ' ButtonSiguiente
        ' 
        ButtonSiguiente.Location = New Point(800, 8)
        ButtonSiguiente.Name = "ButtonSiguiente"
        ButtonSiguiente.Size = New Size(75, 35)
        ButtonSiguiente.TabIndex = 4
        ButtonSiguiente.Text = "Siguiente"
        ButtonSiguiente.UseVisualStyleBackColor = True
        ' 
        ' ButtonAnterior
        ' 
        ButtonAnterior.Location = New Point(125, 8)
        ButtonAnterior.Name = "ButtonAnterior"
        ButtonAnterior.Size = New Size(75, 35)
        ButtonAnterior.TabIndex = 1
        ButtonAnterior.Text = "Anterior"
        ButtonAnterior.UseVisualStyleBackColor = True
        ' 
        ' ButtonPrimero
        ' 
        ButtonPrimero.Location = New Point(0, 8)
        ButtonPrimero.Name = "ButtonPrimero"
        ButtonPrimero.Size = New Size(75, 35)
        ButtonPrimero.TabIndex = 0
        ButtonPrimero.Text = "Primero"
        ButtonPrimero.UseVisualStyleBackColor = True
        ' 
        ' ButtonAceptar
        ' 
        ButtonAceptar.Location = New Point(800, 664)
        ButtonAceptar.Name = "ButtonAceptar"
        ButtonAceptar.Size = New Size(75, 35)
        ButtonAceptar.TabIndex = 3
        ButtonAceptar.Text = "Aceptar"
        ButtonAceptar.UseVisualStyleBackColor = True
        ' 
        ' ButtonCancelar
        ' 
        ButtonCancelar.Location = New Point(450, 664)
        ButtonCancelar.Name = "ButtonCancelar"
        ButtonCancelar.Size = New Size(75, 35)
        ButtonCancelar.TabIndex = 2
        ButtonCancelar.Text = "Cancelar"
        ButtonCancelar.UseVisualStyleBackColor = True
        ' 
        ' Alumnos
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1234, 711)
        Controls.Add(GroupBoxBuscar)
        Controls.Add(ListView)
        Controls.Add(ButtonAceptar)
        Controls.Add(MenuStripAlumnos)
        Controls.Add(ButtonCancelar)
        Controls.Add(GroupBoxRellenarDatos)
        MainMenuStrip = MenuStripAlumnos
        Name = "Alumnos"
        Text = "Alumnos"
        MenuStripAlumnos.ResumeLayout(False)
        MenuStripAlumnos.PerformLayout()
        GroupBoxRellenarDatos.ResumeLayout(False)
        GroupBoxRellenarDatos.PerformLayout()
        GroupBoxBuscar.ResumeLayout(False)
        GroupBoxBuscar.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents MenuStripAlumnos As MenuStrip
    Friend WithEvents AgregarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ModificarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VisualizarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ListView As ListView
    Friend WithEvents LabelId As Label
    Friend WithEvents LabelNombre As Label
    Friend WithEvents LabelApellidos As Label
    Friend WithEvents LabelDireccion As Label
    Friend WithEvents LabelLocalidad As Label
    Friend WithEvents LabelMovil As Label
    Friend WithEvents LabelEmail As Label
    Friend WithEvents LabelFechaNacimiento As Label
    Friend WithEvents LabelNacionalidad As Label
    Friend WithEvents TextBoxId As TextBox
    Friend WithEvents TextBoxNombre As TextBox
    Friend WithEvents TextBoxApellidos As TextBox
    Friend WithEvents TextBoxDireccion As TextBox
    Friend WithEvents TextBoxLocalidad As TextBox
    Friend WithEvents TextBoxMovil As TextBox
    Friend WithEvents TextBoxEmail As TextBox
    Friend WithEvents TextBoxFechaNacimiento As TextBox
    Friend WithEvents TextBoxNacionalidad As TextBox
    Friend WithEvents GroupBoxRellenarDatos As GroupBox
    Friend WithEvents GroupBoxBuscar As GroupBox
    Friend WithEvents ComboBoxMesFechaNacimiento As ComboBox
    Friend WithEvents ComboBoxDiaFechaNacimiento As ComboBox
    Friend WithEvents ButtonUltimo As Button
    Friend WithEvents ButtonSiguiente As Button
    Friend WithEvents ButtonAceptar As Button
    Friend WithEvents ButtonCancelar As Button
    Friend WithEvents ButtonAnterior As Button
    Friend WithEvents ButtonPrimero As Button
    Friend WithEvents LabelYear As Label
    Friend WithEvents LabelMes As Label
    Friend WithEvents LabelDia As Label
    Friend WithEvents LabelBuscar As Label
    Friend WithEvents TextBoxBuscar As TextBox
    Friend WithEvents ButtonBuscar As Button
End Class
