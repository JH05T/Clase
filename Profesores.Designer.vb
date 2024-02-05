<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Profesores
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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Profesores))
        AgregarToolStripMenuItem = New ToolStripMenuItem()
        EliminarToolStripMenuItem = New ToolStripMenuItem()
        ModificarToolStripMenuItem = New ToolStripMenuItem()
        VisualizarToolStripMenuItem = New ToolStripMenuItem()
        VolverToolStripMenuItem = New ToolStripMenuItem()
        MenuStrip = New MenuStrip()
        TextBoxId = New TextBox()
        TextBoxNombre = New TextBox()
        TextBoxApellidos = New TextBox()
        LabelApellidos = New Label()
        LabelNombre = New Label()
        LabelId = New Label()
        GroupBoxRellenarDatos = New GroupBox()
        LabelDepartamento = New Label()
        TextBoxDepartamento = New TextBox()
        ButtonCancelar = New Button()
        ButtonAceptar = New Button()
        ListView = New ListView()
        ButtonPrimero = New Button()
        ButtonAnterior = New Button()
        ButtonSiguiente = New Button()
        ButtonUltimo = New Button()
        ButtonBuscar = New Button()
        TextBoxBuscar = New TextBox()
        LabelBuscar = New Label()
        GroupBoxBuscar = New GroupBox()
        MenuStrip.SuspendLayout()
        GroupBoxRellenarDatos.SuspendLayout()
        GroupBoxBuscar.SuspendLayout()
        SuspendLayout()
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
        ' MenuStrip
        ' 
        MenuStrip.BackColor = Color.White
        MenuStrip.Items.AddRange(New ToolStripItem() {AgregarToolStripMenuItem, EliminarToolStripMenuItem, ModificarToolStripMenuItem, VisualizarToolStripMenuItem, VolverToolStripMenuItem})
        MenuStrip.Location = New Point(0, 0)
        MenuStrip.Name = "MenuStrip"
        MenuStrip.Size = New Size(1234, 24)
        MenuStrip.TabIndex = 7
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
        ' TextBoxNombre
        ' 
        TextBoxNombre.Font = New Font("Segoe Print", 9F, FontStyle.Regular, GraphicsUnit.Point)
        TextBoxNombre.Location = New Point(239, 150)
        TextBoxNombre.Name = "TextBoxNombre"
        TextBoxNombre.Size = New Size(150, 29)
        TextBoxNombre.TabIndex = 1
        ' 
        ' TextBoxApellidos
        ' 
        TextBoxApellidos.Font = New Font("Segoe Print", 9F, FontStyle.Regular, GraphicsUnit.Point)
        TextBoxApellidos.Location = New Point(239, 250)
        TextBoxApellidos.Name = "TextBoxApellidos"
        TextBoxApellidos.Size = New Size(150, 29)
        TextBoxApellidos.TabIndex = 2
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
        GroupBoxRellenarDatos.Location = New Point(120, 60)
        GroupBoxRellenarDatos.Name = "GroupBoxRellenarDatos"
        GroupBoxRellenarDatos.Size = New Size(501, 450)
        GroupBoxRellenarDatos.TabIndex = 5
        GroupBoxRellenarDatos.TabStop = False
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
        ' ButtonCancelar
        ' 
        ButtonCancelar.Font = New Font("MV Boli", 8.25F, FontStyle.Bold, GraphicsUnit.Point)
        ButtonCancelar.Location = New Point(233, 630)
        ButtonCancelar.Name = "ButtonCancelar"
        ButtonCancelar.Size = New Size(75, 35)
        ButtonCancelar.TabIndex = 9
        ButtonCancelar.Text = "Cancelar"
        ButtonCancelar.UseVisualStyleBackColor = True
        ' 
        ' ButtonAceptar
        ' 
        ButtonAceptar.Font = New Font("MV Boli", 8.25F, FontStyle.Bold, GraphicsUnit.Point)
        ButtonAceptar.Location = New Point(431, 630)
        ButtonAceptar.Name = "ButtonAceptar"
        ButtonAceptar.Size = New Size(75, 35)
        ButtonAceptar.TabIndex = 10
        ButtonAceptar.Text = "Aceptar"
        ButtonAceptar.UseVisualStyleBackColor = True
        ' 
        ' ListView
        ' 
        ListView.Font = New Font("Segoe Print", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
        ListView.FullRowSelect = True
        ListView.GridLines = True
        ListView.Location = New Point(627, 60)
        ListView.Name = "ListView"
        ListView.Size = New Size(500, 605)
        ListView.TabIndex = 8
        ListView.UseCompatibleStateImageBehavior = False
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
        ' TextBoxBuscar
        ' 
        TextBoxBuscar.Font = New Font("Segoe Print", 9F, FontStyle.Regular, GraphicsUnit.Point)
        TextBoxBuscar.Location = New Point(310, 53)
        TextBoxBuscar.Name = "TextBoxBuscar"
        TextBoxBuscar.Size = New Size(150, 29)
        TextBoxBuscar.TabIndex = 2
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
        GroupBoxBuscar.Location = New Point(120, 520)
        GroupBoxBuscar.Name = "GroupBoxBuscar"
        GroupBoxBuscar.Size = New Size(500, 85)
        GroupBoxBuscar.TabIndex = 6
        GroupBoxBuscar.TabStop = False
        ' 
        ' Profesores
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1234, 711)
        Controls.Add(GroupBoxBuscar)
        Controls.Add(ListView)
        Controls.Add(ButtonAceptar)
        Controls.Add(ButtonCancelar)
        Controls.Add(GroupBoxRellenarDatos)
        Controls.Add(MenuStrip)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Profesores"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Profesores"
        MenuStrip.ResumeLayout(False)
        MenuStrip.PerformLayout()
        GroupBoxRellenarDatos.ResumeLayout(False)
        GroupBoxRellenarDatos.PerformLayout()
        GroupBoxBuscar.ResumeLayout(False)
        GroupBoxBuscar.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents AgregarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ModificarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VisualizarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VolverToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MenuStrip As MenuStrip
    Friend WithEvents LabelNacionalidad As Label
    Friend WithEvents TextBoxId As TextBox
    Friend WithEvents LabelFechaNacimiento As Label
    Friend WithEvents TextBoxNombre As TextBox
    Friend WithEvents LabelEmail As Label
    Friend WithEvents TextBoxApellidos As TextBox
    Friend WithEvents LabelMovil As Label
    Friend WithEvents LabelLocalidad As Label
    Friend WithEvents TextBoxLocalidad As TextBox
    Friend WithEvents TextBoxMovil As TextBox
    Friend WithEvents LabelApellidos As Label
    Friend WithEvents TextBoxEmail As TextBox
    Friend WithEvents LabelNombre As Label
    Friend WithEvents TextBoxFechaNacimiento As TextBox
    Friend WithEvents LabelId As Label
    Friend WithEvents TextBoxNacionalidad As TextBox
    Friend WithEvents LabelDia As Label
    Friend WithEvents LabelMes As Label
    Friend WithEvents LabelYear As Label
    Friend WithEvents TextBoxMesFechaNacimiento As TextBox
    Friend WithEvents TextBoxDiaFechaNacimiento As TextBox
    Friend WithEvents GroupBoxRellenarDatos As GroupBox
    Friend WithEvents ButtonCancelar As Button
    Friend WithEvents ButtonAceptar As Button
    Friend WithEvents ListView As ListView
    Friend WithEvents ButtonPrimero As Button
    Friend WithEvents ButtonAnterior As Button
    Friend WithEvents ButtonSiguiente As Button
    Friend WithEvents ButtonUltimo As Button
    Friend WithEvents ButtonBuscar As Button
    Friend WithEvents TextBoxBuscar As TextBox
    Friend WithEvents LabelBuscar As Label
    Friend WithEvents GroupBoxBuscar As GroupBox
    Friend WithEvents LabelDepartamento As Label
    Friend WithEvents TextBoxDepartamento As TextBox
End Class
