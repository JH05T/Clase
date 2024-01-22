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
        ToolStripMenuItem1 = New ToolStripMenuItem()
        AgregarToolStripMenuItem = New ToolStripMenuItem()
        EliminarToolStripMenuItem = New ToolStripMenuItem()
        ModificarToolStripMenuItem = New ToolStripMenuItem()
        VisualizarToolStripMenuItem = New ToolStripMenuItem()
        ListViewAlumnos = New ListView()
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
        GroupBoxAlumnos = New GroupBox()
        MenuStripAlumnos.SuspendLayout()
        GroupBoxAlumnos.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStripAlumnos
        ' 
        MenuStripAlumnos.Items.AddRange(New ToolStripItem() {ToolStripMenuItem1, AgregarToolStripMenuItem, EliminarToolStripMenuItem, ModificarToolStripMenuItem, VisualizarToolStripMenuItem})
        MenuStripAlumnos.Location = New Point(0, 0)
        MenuStripAlumnos.Name = "MenuStripAlumnos"
        MenuStripAlumnos.Size = New Size(1234, 24)
        MenuStripAlumnos.TabIndex = 1
        ' 
        ' ToolStripMenuItem1
        ' 
        ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        ToolStripMenuItem1.Size = New Size(12, 20)
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
        ' ListViewAlumnos
        ' 
        ListViewAlumnos.Location = New Point(117, 400)
        ListViewAlumnos.Name = "ListViewAlumnos"
        ListViewAlumnos.Size = New Size(1000, 256)
        ListViewAlumnos.TabIndex = 2
        ListViewAlumnos.UseCompatibleStateImageBehavior = False
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
        TextBoxId.Size = New Size(150, 23)
        TextBoxId.TabIndex = 12
        ' 
        ' TextBoxNombre
        ' 
        TextBoxNombre.Location = New Point(485, 50)
        TextBoxNombre.Name = "TextBoxNombre"
        TextBoxNombre.Size = New Size(150, 23)
        TextBoxNombre.TabIndex = 13
        ' 
        ' TextBoxApellidos
        ' 
        TextBoxApellidos.Location = New Point(847, 50)
        TextBoxApellidos.Name = "TextBoxApellidos"
        TextBoxApellidos.Size = New Size(150, 23)
        TextBoxApellidos.TabIndex = 14
        ' 
        ' TextBoxDireccion
        ' 
        TextBoxDireccion.Location = New Point(127, 150)
        TextBoxDireccion.Name = "TextBoxDireccion"
        TextBoxDireccion.Size = New Size(150, 23)
        TextBoxDireccion.TabIndex = 15
        ' 
        ' TextBoxLocalidad
        ' 
        TextBoxLocalidad.Location = New Point(485, 150)
        TextBoxLocalidad.Name = "TextBoxLocalidad"
        TextBoxLocalidad.Size = New Size(150, 23)
        TextBoxLocalidad.TabIndex = 16
        ' 
        ' TextBoxMovil
        ' 
        TextBoxMovil.Location = New Point(847, 150)
        TextBoxMovil.Name = "TextBoxMovil"
        TextBoxMovil.Size = New Size(150, 23)
        TextBoxMovil.TabIndex = 17
        ' 
        ' TextBoxEmail
        ' 
        TextBoxEmail.Location = New Point(127, 250)
        TextBoxEmail.Name = "TextBoxEmail"
        TextBoxEmail.Size = New Size(150, 23)
        TextBoxEmail.TabIndex = 18
        ' 
        ' TextBoxFechaNacimiento
        ' 
        TextBoxFechaNacimiento.Location = New Point(485, 250)
        TextBoxFechaNacimiento.Name = "TextBoxFechaNacimiento"
        TextBoxFechaNacimiento.Size = New Size(150, 23)
        TextBoxFechaNacimiento.TabIndex = 19
        ' 
        ' TextBoxNacionalidad
        ' 
        TextBoxNacionalidad.Location = New Point(845, 250)
        TextBoxNacionalidad.Name = "TextBoxNacionalidad"
        TextBoxNacionalidad.Size = New Size(150, 23)
        TextBoxNacionalidad.TabIndex = 20
        ' 
        ' GroupBoxAlumnos
        ' 
        GroupBoxAlumnos.Controls.Add(TextBoxNacionalidad)
        GroupBoxAlumnos.Controls.Add(LabelId)
        GroupBoxAlumnos.Controls.Add(TextBoxFechaNacimiento)
        GroupBoxAlumnos.Controls.Add(LabelNombre)
        GroupBoxAlumnos.Controls.Add(TextBoxEmail)
        GroupBoxAlumnos.Controls.Add(LabelApellidos)
        GroupBoxAlumnos.Controls.Add(TextBoxMovil)
        GroupBoxAlumnos.Controls.Add(LabelDireccion)
        GroupBoxAlumnos.Controls.Add(TextBoxLocalidad)
        GroupBoxAlumnos.Controls.Add(LabelLocalidad)
        GroupBoxAlumnos.Controls.Add(TextBoxDireccion)
        GroupBoxAlumnos.Controls.Add(LabelMovil)
        GroupBoxAlumnos.Controls.Add(TextBoxApellidos)
        GroupBoxAlumnos.Controls.Add(LabelEmail)
        GroupBoxAlumnos.Controls.Add(TextBoxNombre)
        GroupBoxAlumnos.Controls.Add(LabelFechaNacimiento)
        GroupBoxAlumnos.Controls.Add(TextBoxId)
        GroupBoxAlumnos.Controls.Add(LabelNacionalidad)
        GroupBoxAlumnos.Location = New Point(117, 50)
        GroupBoxAlumnos.Name = "GroupBoxAlumnos"
        GroupBoxAlumnos.Size = New Size(1000, 300)
        GroupBoxAlumnos.TabIndex = 21
        GroupBoxAlumnos.TabStop = False
        ' 
        ' Alumnos
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1234, 711)
        Controls.Add(ListViewAlumnos)
        Controls.Add(MenuStripAlumnos)
        Controls.Add(GroupBoxAlumnos)
        MainMenuStrip = MenuStripAlumnos
        Name = "Alumnos"
        Text = "Alumnos"
        MenuStripAlumnos.ResumeLayout(False)
        MenuStripAlumnos.PerformLayout()
        GroupBoxAlumnos.ResumeLayout(False)
        GroupBoxAlumnos.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents MenuStripAlumnos As MenuStrip
    Friend WithEvents AgregarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ModificarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VisualizarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ListViewAlumnos As ListView
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
    Friend WithEvents GroupBoxAlumnos As GroupBox
End Class
