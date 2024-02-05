<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Asignaturas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Asignaturas))
        GroupBoxBuscar = New GroupBox()
        LabelBuscar = New Label()
        TextBoxBuscar = New TextBox()
        ButtonBuscar = New Button()
        ButtonUltimo = New Button()
        ButtonSiguiente = New Button()
        ButtonAnterior = New Button()
        ButtonPrimero = New Button()
        ListView = New ListView()
        ButtonAceptar = New Button()
        ButtonCancelar = New Button()
        GroupBoxRellenarDatos = New GroupBox()
        LabelId = New Label()
        LabelNombre = New Label()
        LabelApellidos = New Label()
        LabelDepartamento = New Label()
        TextBoxDepartamento = New TextBox()
        TextBoxApellidos = New TextBox()
        TextBoxNombre = New TextBox()
        TextBoxId = New TextBox()
        MenuStripAlumnos = New MenuStrip()
        AgregarToolStripMenuItem = New ToolStripMenuItem()
        EliminarToolStripMenuItem = New ToolStripMenuItem()
        ModificarToolStripMenuItem = New ToolStripMenuItem()
        VisualizarToolStripMenuItem = New ToolStripMenuItem()
        VolverToolStripMenuItem = New ToolStripMenuItem()
        GroupBoxBuscar.SuspendLayout()
        GroupBoxRellenarDatos.SuspendLayout()
        MenuStripAlumnos.SuspendLayout()
        SuspendLayout()
        ' 
        ' GroupBoxBuscar
        ' 
        GroupBoxBuscar.BackColor = Color.Transparent
        GroupBoxBuscar.Controls.Add(LabelBuscar)
        GroupBoxBuscar.Controls.Add(TextBoxBuscar)
        GroupBoxBuscar.Controls.Add(ButtonBuscar)
        GroupBoxBuscar.Controls.Add(ButtonUltimo)
        GroupBoxBuscar.Controls.Add(ButtonSiguiente)
        GroupBoxBuscar.Controls.Add(ButtonAnterior)
        GroupBoxBuscar.Controls.Add(ButtonPrimero)
        GroupBoxBuscar.ForeColor = Color.Black
        GroupBoxBuscar.Location = New Point(120, 543)
        GroupBoxBuscar.Name = "GroupBoxBuscar"
        GroupBoxBuscar.Size = New Size(500, 85)
        GroupBoxBuscar.TabIndex = 12
        GroupBoxBuscar.TabStop = False
        ' 
        ' LabelBuscar
        ' 
        LabelBuscar.Font = New Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        LabelBuscar.Location = New Point(0, 57)
        LabelBuscar.Name = "LabelBuscar"
        LabelBuscar.Size = New Size(310, 23)
        LabelBuscar.TabIndex = 7
        LabelBuscar.Text = "Introduce la ID del profesor que estás buscando:"
        LabelBuscar.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' TextBoxBuscar
        ' 
        TextBoxBuscar.Font = New Font("Segoe Print", 9F, FontStyle.Regular, GraphicsUnit.Point)
        TextBoxBuscar.Location = New Point(310, 53)
        TextBoxBuscar.Name = "TextBoxBuscar"
        TextBoxBuscar.Size = New Size(150, 29)
        TextBoxBuscar.TabIndex = 2
        ' 
        ' ButtonBuscar
        ' 
        ButtonBuscar.BackgroundImage = CType(resources.GetObject("ButtonBuscar.BackgroundImage"), Image)
        ButtonBuscar.BackgroundImageLayout = ImageLayout.Zoom
        ButtonBuscar.Location = New Point(465, 50)
        ButtonBuscar.Name = "ButtonBuscar"
        ButtonBuscar.Size = New Size(35, 35)
        ButtonBuscar.TabIndex = 3
        ButtonBuscar.UseVisualStyleBackColor = True
        ' 
        ' ButtonUltimo
        ' 
        ButtonUltimo.FlatStyle = FlatStyle.System
        ButtonUltimo.Font = New Font("MV Boli", 8.25F, FontStyle.Bold, GraphicsUnit.Point)
        ButtonUltimo.Location = New Point(425, 8)
        ButtonUltimo.Name = "ButtonUltimo"
        ButtonUltimo.Size = New Size(75, 35)
        ButtonUltimo.TabIndex = 5
        ButtonUltimo.Text = "Último"
        ButtonUltimo.UseVisualStyleBackColor = True
        ' 
        ' ButtonSiguiente
        ' 
        ButtonSiguiente.Font = New Font("MV Boli", 8.25F, FontStyle.Bold, GraphicsUnit.Point)
        ButtonSiguiente.Location = New Point(311, 8)
        ButtonSiguiente.Name = "ButtonSiguiente"
        ButtonSiguiente.Size = New Size(75, 35)
        ButtonSiguiente.TabIndex = 4
        ButtonSiguiente.Text = "Siguiente"
        ButtonSiguiente.UseVisualStyleBackColor = True
        ' 
        ' ButtonAnterior
        ' 
        ButtonAnterior.FlatStyle = FlatStyle.Popup
        ButtonAnterior.Font = New Font("MV Boli", 8.25F, FontStyle.Bold, GraphicsUnit.Point)
        ButtonAnterior.Location = New Point(114, 8)
        ButtonAnterior.Name = "ButtonAnterior"
        ButtonAnterior.Size = New Size(75, 35)
        ButtonAnterior.TabIndex = 1
        ButtonAnterior.Text = "Anterior"
        ButtonAnterior.UseVisualStyleBackColor = True
        ' 
        ' ButtonPrimero
        ' 
        ButtonPrimero.FlatStyle = FlatStyle.Flat
        ButtonPrimero.Font = New Font("MV Boli", 8.25F, FontStyle.Bold, GraphicsUnit.Point)
        ButtonPrimero.Location = New Point(0, 8)
        ButtonPrimero.Name = "ButtonPrimero"
        ButtonPrimero.Size = New Size(75, 35)
        ButtonPrimero.TabIndex = 0
        ButtonPrimero.Text = "Primero"
        ButtonPrimero.UseVisualStyleBackColor = True
        ' 
        ' ListView
        ' 
        ListView.Font = New Font("Segoe Print", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
        ListView.FullRowSelect = True
        ListView.GridLines = True
        ListView.Location = New Point(627, 83)
        ListView.Name = "ListView"
        ListView.Size = New Size(500, 605)
        ListView.TabIndex = 14
        ListView.UseCompatibleStateImageBehavior = False
        ' 
        ' ButtonAceptar
        ' 
        ButtonAceptar.Font = New Font("MV Boli", 8.25F, FontStyle.Bold, GraphicsUnit.Point)
        ButtonAceptar.Location = New Point(431, 653)
        ButtonAceptar.Name = "ButtonAceptar"
        ButtonAceptar.Size = New Size(75, 35)
        ButtonAceptar.TabIndex = 16
        ButtonAceptar.Text = "Aceptar"
        ButtonAceptar.UseVisualStyleBackColor = True
        ' 
        ' ButtonCancelar
        ' 
        ButtonCancelar.Font = New Font("MV Boli", 8.25F, FontStyle.Bold, GraphicsUnit.Point)
        ButtonCancelar.Location = New Point(233, 653)
        ButtonCancelar.Name = "ButtonCancelar"
        ButtonCancelar.Size = New Size(75, 35)
        ButtonCancelar.TabIndex = 15
        ButtonCancelar.Text = "Cancelar"
        ButtonCancelar.UseVisualStyleBackColor = True
        ' 
        ' GroupBoxRellenarDatos
        ' 
        GroupBoxRellenarDatos.BackColor = Color.Transparent
        GroupBoxRellenarDatos.Controls.Add(LabelId)
        GroupBoxRellenarDatos.Controls.Add(LabelNombre)
        GroupBoxRellenarDatos.Controls.Add(LabelApellidos)
        GroupBoxRellenarDatos.Controls.Add(LabelDepartamento)
        GroupBoxRellenarDatos.Controls.Add(TextBoxDepartamento)
        GroupBoxRellenarDatos.Controls.Add(TextBoxApellidos)
        GroupBoxRellenarDatos.Controls.Add(TextBoxNombre)
        GroupBoxRellenarDatos.Controls.Add(TextBoxId)
        GroupBoxRellenarDatos.Location = New Point(120, 83)
        GroupBoxRellenarDatos.Name = "GroupBoxRellenarDatos"
        GroupBoxRellenarDatos.Size = New Size(501, 450)
        GroupBoxRellenarDatos.TabIndex = 11
        GroupBoxRellenarDatos.TabStop = False
        ' 
        ' LabelId
        ' 
        LabelId.Font = New Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        LabelId.Location = New Point(113, 50)
        LabelId.Name = "LabelId"
        LabelId.Size = New Size(120, 23)
        LabelId.TabIndex = 3
        LabelId.Text = "Id"
        LabelId.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabelNombre
        ' 
        LabelNombre.Font = New Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        LabelNombre.Location = New Point(113, 150)
        LabelNombre.Name = "LabelNombre"
        LabelNombre.Size = New Size(120, 23)
        LabelNombre.TabIndex = 4
        LabelNombre.Text = "Nombre"
        LabelNombre.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabelApellidos
        ' 
        LabelApellidos.Font = New Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        LabelApellidos.Location = New Point(113, 250)
        LabelApellidos.Name = "LabelApellidos"
        LabelApellidos.Size = New Size(120, 23)
        LabelApellidos.TabIndex = 5
        LabelApellidos.Text = "Apellidos"
        LabelApellidos.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabelDepartamento
        ' 
        LabelDepartamento.Font = New Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        LabelDepartamento.Location = New Point(113, 350)
        LabelDepartamento.Name = "LabelDepartamento"
        LabelDepartamento.Size = New Size(120, 23)
        LabelDepartamento.TabIndex = 6
        LabelDepartamento.Text = "Departamento"
        LabelDepartamento.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' TextBoxDepartamento
        ' 
        TextBoxDepartamento.Font = New Font("Segoe Print", 9F, FontStyle.Regular, GraphicsUnit.Point)
        TextBoxDepartamento.Location = New Point(239, 350)
        TextBoxDepartamento.Name = "TextBoxDepartamento"
        TextBoxDepartamento.Size = New Size(150, 29)
        TextBoxDepartamento.TabIndex = 3
        ' 
        ' TextBoxApellidos
        ' 
        TextBoxApellidos.Font = New Font("Segoe Print", 9F, FontStyle.Regular, GraphicsUnit.Point)
        TextBoxApellidos.Location = New Point(239, 250)
        TextBoxApellidos.Name = "TextBoxApellidos"
        TextBoxApellidos.Size = New Size(150, 29)
        TextBoxApellidos.TabIndex = 2
        ' 
        ' TextBoxNombre
        ' 
        TextBoxNombre.Font = New Font("Segoe Print", 9F, FontStyle.Regular, GraphicsUnit.Point)
        TextBoxNombre.Location = New Point(239, 150)
        TextBoxNombre.Name = "TextBoxNombre"
        TextBoxNombre.Size = New Size(150, 29)
        TextBoxNombre.TabIndex = 1
        ' 
        ' TextBoxId
        ' 
        TextBoxId.Font = New Font("Segoe Print", 9F, FontStyle.Regular, GraphicsUnit.Point)
        TextBoxId.Location = New Point(239, 50)
        TextBoxId.Name = "TextBoxId"
        TextBoxId.ReadOnly = True
        TextBoxId.Size = New Size(150, 29)
        TextBoxId.TabIndex = 0
        ' 
        ' MenuStripAlumnos
        ' 
        MenuStripAlumnos.BackColor = Color.White
        MenuStripAlumnos.Items.AddRange(New ToolStripItem() {AgregarToolStripMenuItem, EliminarToolStripMenuItem, ModificarToolStripMenuItem, VisualizarToolStripMenuItem, VolverToolStripMenuItem})
        MenuStripAlumnos.Location = New Point(0, 0)
        MenuStripAlumnos.Name = "MenuStripAlumnos"
        MenuStripAlumnos.Size = New Size(1234, 24)
        MenuStripAlumnos.TabIndex = 13
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
        ' VolverToolStripMenuItem
        ' 
        VolverToolStripMenuItem.Name = "VolverToolStripMenuItem"
        VolverToolStripMenuItem.Size = New Size(51, 20)
        VolverToolStripMenuItem.Text = "Volver"
        ' 
        ' Asignaturas
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1234, 711)
        Controls.Add(GroupBoxBuscar)
        Controls.Add(ListView)
        Controls.Add(ButtonAceptar)
        Controls.Add(ButtonCancelar)
        Controls.Add(GroupBoxRellenarDatos)
        Controls.Add(MenuStripAlumnos)
        Name = "Asignaturas"
        Text = "Asignaturas"
        GroupBoxBuscar.ResumeLayout(False)
        GroupBoxBuscar.PerformLayout()
        GroupBoxRellenarDatos.ResumeLayout(False)
        GroupBoxRellenarDatos.PerformLayout()
        MenuStripAlumnos.ResumeLayout(False)
        MenuStripAlumnos.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents GroupBoxBuscar As GroupBox
    Friend WithEvents LabelBuscar As Label
    Friend WithEvents TextBoxBuscar As TextBox
    Friend WithEvents ButtonBuscar As Button
    Friend WithEvents ButtonUltimo As Button
    Friend WithEvents ButtonSiguiente As Button
    Friend WithEvents ButtonAnterior As Button
    Friend WithEvents ButtonPrimero As Button
    Friend WithEvents ListView As ListView
    Friend WithEvents ButtonAceptar As Button
    Friend WithEvents ButtonCancelar As Button
    Friend WithEvents GroupBoxRellenarDatos As GroupBox
    Friend WithEvents LabelId As Label
    Friend WithEvents LabelNombre As Label
    Friend WithEvents LabelApellidos As Label
    Friend WithEvents LabelDepartamento As Label
    Friend WithEvents TextBoxDepartamento As TextBox
    Friend WithEvents TextBoxApellidos As TextBox
    Friend WithEvents TextBoxNombre As TextBox
    Friend WithEvents TextBoxId As TextBox
    Friend WithEvents MenuStripAlumnos As MenuStrip
    Friend WithEvents AgregarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ModificarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VisualizarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VolverToolStripMenuItem As ToolStripMenuItem
End Class
