<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Notas
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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Notas))
        PictureBox = New PictureBox()
        GroupBoxBuscar = New GroupBox()
        Label1 = New Label()
        TextBoxBuscarAsignatura = New TextBox()
        LabelBuscar = New Label()
        TextBoxBuscarAlumno = New TextBox()
        ButtonBuscar = New Button()
        ButtonUltimo = New Button()
        ButtonSiguiente = New Button()
        ButtonAnterior = New Button()
        ButtonPrimero = New Button()
        ListView = New ListView()
        ButtonAceptar = New Button()
        ButtonCancelar = New Button()
        GroupBoxRellenarDatos = New GroupBox()
        LabelNota2 = New Label()
        LabelNotaFinal = New Label()
        TextBoxNotaFinal = New TextBox()
        TextBoxNota2 = New TextBox()
        LabelAlumno = New Label()
        LabelNota1 = New Label()
        LabelNota3 = New Label()
        LabelAsignatura = New Label()
        TextBoxAsignatura = New TextBox()
        TextBoxNota3 = New TextBox()
        TextBoxNota1 = New TextBox()
        TextBoxAlumno = New TextBox()
        MenuStrip = New MenuStrip()
        AgregarToolStripMenuItem = New ToolStripMenuItem()
        EliminarToolStripMenuItem = New ToolStripMenuItem()
        ModificarToolStripMenuItem = New ToolStripMenuItem()
        VisualizarToolStripMenuItem = New ToolStripMenuItem()
        VolverToolStripMenuItem = New ToolStripMenuItem()
        CType(PictureBox, ComponentModel.ISupportInitialize).BeginInit()
        GroupBoxBuscar.SuspendLayout()
        GroupBoxRellenarDatos.SuspendLayout()
        MenuStrip.SuspendLayout()
        SuspendLayout()
        ' 
        ' PictureBox
        ' 
        PictureBox.BackgroundImage = CType(resources.GetObject("PictureBox.BackgroundImage"), Image)
        PictureBox.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox.Location = New Point(627, 83)
        PictureBox.Name = "PictureBox"
        PictureBox.Size = New Size(500, 605)
        PictureBox.TabIndex = 25
        PictureBox.TabStop = False
        ' 
        ' GroupBoxBuscar
        ' 
        GroupBoxBuscar.BackColor = Color.Transparent
        GroupBoxBuscar.Controls.Add(Label1)
        GroupBoxBuscar.Controls.Add(TextBoxBuscarAsignatura)
        GroupBoxBuscar.Controls.Add(LabelBuscar)
        GroupBoxBuscar.Controls.Add(TextBoxBuscarAlumno)
        GroupBoxBuscar.Controls.Add(ButtonBuscar)
        GroupBoxBuscar.Controls.Add(ButtonUltimo)
        GroupBoxBuscar.Controls.Add(ButtonSiguiente)
        GroupBoxBuscar.Controls.Add(ButtonAnterior)
        GroupBoxBuscar.Controls.Add(ButtonPrimero)
        GroupBoxBuscar.ForeColor = Color.Black
        GroupBoxBuscar.Location = New Point(120, 510)
        GroupBoxBuscar.Name = "GroupBoxBuscar"
        GroupBoxBuscar.Size = New Size(500, 125)
        GroupBoxBuscar.TabIndex = 20
        GroupBoxBuscar.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Location = New Point(0, 92)
        Label1.Name = "Label1"
        Label1.Size = New Size(310, 23)
        Label1.TabIndex = 10
        Label1.Text = "Introduce la ID de la asignatura para ver sus notas:"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' TextBoxBuscarAsignatura
        ' 
        TextBoxBuscarAsignatura.Font = New Font("Segoe Print", 9F, FontStyle.Regular, GraphicsUnit.Point)
        TextBoxBuscarAsignatura.Location = New Point(310, 88)
        TextBoxBuscarAsignatura.Name = "TextBoxBuscarAsignatura"
        TextBoxBuscarAsignatura.Size = New Size(150, 29)
        TextBoxBuscarAsignatura.TabIndex = 5
        ' 
        ' LabelBuscar
        ' 
        LabelBuscar.Font = New Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        LabelBuscar.Location = New Point(0, 57)
        LabelBuscar.Name = "LabelBuscar"
        LabelBuscar.RightToLeft = RightToLeft.Yes
        LabelBuscar.Size = New Size(310, 23)
        LabelBuscar.TabIndex = 7
        LabelBuscar.Text = "Introduce la ID del alumno para ver sus notas:"
        LabelBuscar.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' TextBoxBuscarAlumno
        ' 
        TextBoxBuscarAlumno.Font = New Font("Segoe Print", 9F, FontStyle.Regular, GraphicsUnit.Point)
        TextBoxBuscarAlumno.Location = New Point(310, 53)
        TextBoxBuscarAlumno.Name = "TextBoxBuscarAlumno"
        TextBoxBuscarAlumno.Size = New Size(150, 29)
        TextBoxBuscarAlumno.TabIndex = 4
        ' 
        ' ButtonBuscar
        ' 
        ButtonBuscar.BackgroundImage = CType(resources.GetObject("ButtonBuscar.BackgroundImage"), Image)
        ButtonBuscar.BackgroundImageLayout = ImageLayout.Zoom
        ButtonBuscar.Location = New Point(465, 68)
        ButtonBuscar.Name = "ButtonBuscar"
        ButtonBuscar.Size = New Size(35, 35)
        ButtonBuscar.TabIndex = 6
        ButtonBuscar.UseVisualStyleBackColor = True
        ' 
        ' ButtonUltimo
        ' 
        ButtonUltimo.FlatStyle = FlatStyle.System
        ButtonUltimo.Font = New Font("MV Boli", 8.25F, FontStyle.Bold, GraphicsUnit.Point)
        ButtonUltimo.Location = New Point(425, 8)
        ButtonUltimo.Name = "ButtonUltimo"
        ButtonUltimo.Size = New Size(75, 35)
        ButtonUltimo.TabIndex = 3
        ButtonUltimo.Text = "Último"
        ButtonUltimo.UseVisualStyleBackColor = True
        ' 
        ' ButtonSiguiente
        ' 
        ButtonSiguiente.Font = New Font("MV Boli", 8.25F, FontStyle.Bold, GraphicsUnit.Point)
        ButtonSiguiente.Location = New Point(311, 8)
        ButtonSiguiente.Name = "ButtonSiguiente"
        ButtonSiguiente.Size = New Size(75, 35)
        ButtonSiguiente.TabIndex = 2
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
        ListView.TabIndex = 22
        ListView.UseCompatibleStateImageBehavior = False
        ' 
        ' ButtonAceptar
        ' 
        ButtonAceptar.Font = New Font("MV Boli", 8.25F, FontStyle.Bold, GraphicsUnit.Point)
        ButtonAceptar.Location = New Point(431, 653)
        ButtonAceptar.Name = "ButtonAceptar"
        ButtonAceptar.Size = New Size(75, 35)
        ButtonAceptar.TabIndex = 24
        ButtonAceptar.Text = "Aceptar"
        ButtonAceptar.UseVisualStyleBackColor = True
        ' 
        ' ButtonCancelar
        ' 
        ButtonCancelar.Font = New Font("MV Boli", 8.25F, FontStyle.Bold, GraphicsUnit.Point)
        ButtonCancelar.Location = New Point(233, 653)
        ButtonCancelar.Name = "ButtonCancelar"
        ButtonCancelar.Size = New Size(75, 35)
        ButtonCancelar.TabIndex = 23
        ButtonCancelar.Text = "Cancelar"
        ButtonCancelar.UseVisualStyleBackColor = True
        ' 
        ' GroupBoxRellenarDatos
        ' 
        GroupBoxRellenarDatos.BackColor = Color.Transparent
        GroupBoxRellenarDatos.Controls.Add(LabelNota2)
        GroupBoxRellenarDatos.Controls.Add(LabelNotaFinal)
        GroupBoxRellenarDatos.Controls.Add(TextBoxNotaFinal)
        GroupBoxRellenarDatos.Controls.Add(TextBoxNota2)
        GroupBoxRellenarDatos.Controls.Add(LabelAlumno)
        GroupBoxRellenarDatos.Controls.Add(LabelNota1)
        GroupBoxRellenarDatos.Controls.Add(LabelNota3)
        GroupBoxRellenarDatos.Controls.Add(LabelAsignatura)
        GroupBoxRellenarDatos.Controls.Add(TextBoxAsignatura)
        GroupBoxRellenarDatos.Controls.Add(TextBoxNota3)
        GroupBoxRellenarDatos.Controls.Add(TextBoxNota1)
        GroupBoxRellenarDatos.Controls.Add(TextBoxAlumno)
        GroupBoxRellenarDatos.Location = New Point(120, 81)
        GroupBoxRellenarDatos.Name = "GroupBoxRellenarDatos"
        GroupBoxRellenarDatos.Size = New Size(500, 430)
        GroupBoxRellenarDatos.TabIndex = 19
        GroupBoxRellenarDatos.TabStop = False
        ' 
        ' LabelNota2
        ' 
        LabelNota2.Font = New Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        LabelNota2.Location = New Point(245, 200)
        LabelNota2.Name = "LabelNota2"
        LabelNota2.Size = New Size(100, 29)
        LabelNota2.TabIndex = 9
        LabelNota2.Text = "Nota 2"
        LabelNota2.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabelNotaFinal
        ' 
        LabelNotaFinal.Font = New Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        LabelNotaFinal.Location = New Point(245, 300)
        LabelNotaFinal.Name = "LabelNotaFinal"
        LabelNotaFinal.Size = New Size(100, 29)
        LabelNotaFinal.TabIndex = 10
        LabelNotaFinal.Text = "Nota Final"
        LabelNotaFinal.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' TextBoxNotaFinal
        ' 
        TextBoxNotaFinal.Font = New Font("Segoe Print", 9F, FontStyle.Regular, GraphicsUnit.Point)
        TextBoxNotaFinal.Location = New Point(350, 300)
        TextBoxNotaFinal.Name = "TextBoxNotaFinal"
        TextBoxNotaFinal.ReadOnly = True
        TextBoxNotaFinal.Size = New Size(125, 29)
        TextBoxNotaFinal.TabIndex = 5
        ' 
        ' TextBoxNota2
        ' 
        TextBoxNota2.Font = New Font("Segoe Print", 9F, FontStyle.Regular, GraphicsUnit.Point)
        TextBoxNota2.Location = New Point(350, 200)
        TextBoxNota2.Name = "TextBoxNota2"
        TextBoxNota2.Size = New Size(125, 29)
        TextBoxNota2.TabIndex = 3
        ' 
        ' LabelAlumno
        ' 
        LabelAlumno.Font = New Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        LabelAlumno.Location = New Point(5, 100)
        LabelAlumno.Name = "LabelAlumno"
        LabelAlumno.Size = New Size(100, 29)
        LabelAlumno.TabIndex = 3
        LabelAlumno.Text = "Alumno"
        LabelAlumno.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabelNota1
        ' 
        LabelNota1.Font = New Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        LabelNota1.Location = New Point(5, 200)
        LabelNota1.Name = "LabelNota1"
        LabelNota1.Size = New Size(100, 29)
        LabelNota1.TabIndex = 4
        LabelNota1.Text = "Nota 1"
        LabelNota1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabelNota3
        ' 
        LabelNota3.Font = New Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        LabelNota3.Location = New Point(5, 300)
        LabelNota3.Name = "LabelNota3"
        LabelNota3.Size = New Size(100, 29)
        LabelNota3.TabIndex = 5
        LabelNota3.Text = "Nota 3"
        LabelNota3.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabelAsignatura
        ' 
        LabelAsignatura.Font = New Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        LabelAsignatura.Location = New Point(245, 100)
        LabelAsignatura.Name = "LabelAsignatura"
        LabelAsignatura.Size = New Size(100, 29)
        LabelAsignatura.TabIndex = 1
        LabelAsignatura.Text = "Asignatura"
        LabelAsignatura.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' TextBoxAsignatura
        ' 
        TextBoxAsignatura.Font = New Font("Segoe Print", 9F, FontStyle.Regular, GraphicsUnit.Point)
        TextBoxAsignatura.Location = New Point(350, 100)
        TextBoxAsignatura.Name = "TextBoxAsignatura"
        TextBoxAsignatura.Size = New Size(125, 29)
        TextBoxAsignatura.TabIndex = 1
        ' 
        ' TextBoxNota3
        ' 
        TextBoxNota3.Font = New Font("Segoe Print", 9F, FontStyle.Regular, GraphicsUnit.Point)
        TextBoxNota3.Location = New Point(110, 300)
        TextBoxNota3.Name = "TextBoxNota3"
        TextBoxNota3.Size = New Size(125, 29)
        TextBoxNota3.TabIndex = 4
        ' 
        ' TextBoxNota1
        ' 
        TextBoxNota1.Font = New Font("Segoe Print", 9F, FontStyle.Regular, GraphicsUnit.Point)
        TextBoxNota1.Location = New Point(110, 200)
        TextBoxNota1.Name = "TextBoxNota1"
        TextBoxNota1.Size = New Size(125, 29)
        TextBoxNota1.TabIndex = 2
        ' 
        ' TextBoxAlumno
        ' 
        TextBoxAlumno.Font = New Font("Segoe Print", 9F, FontStyle.Regular, GraphicsUnit.Point)
        TextBoxAlumno.Location = New Point(110, 100)
        TextBoxAlumno.Name = "TextBoxAlumno"
        TextBoxAlumno.Size = New Size(125, 29)
        TextBoxAlumno.TabIndex = 0
        ' 
        ' MenuStrip
        ' 
        MenuStrip.BackColor = Color.White
        MenuStrip.Items.AddRange(New ToolStripItem() {AgregarToolStripMenuItem, EliminarToolStripMenuItem, ModificarToolStripMenuItem, VisualizarToolStripMenuItem, VolverToolStripMenuItem})
        MenuStrip.Location = New Point(0, 0)
        MenuStrip.Name = "MenuStrip"
        MenuStrip.Size = New Size(1234, 24)
        MenuStrip.TabIndex = 21
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
        ' Notas
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(1234, 711)
        Controls.Add(PictureBox)
        Controls.Add(GroupBoxBuscar)
        Controls.Add(ListView)
        Controls.Add(ButtonAceptar)
        Controls.Add(ButtonCancelar)
        Controls.Add(GroupBoxRellenarDatos)
        Controls.Add(MenuStrip)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Notas"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Notas"
        CType(PictureBox, ComponentModel.ISupportInitialize).EndInit()
        GroupBoxBuscar.ResumeLayout(False)
        GroupBoxBuscar.PerformLayout()
        GroupBoxRellenarDatos.ResumeLayout(False)
        GroupBoxRellenarDatos.PerformLayout()
        MenuStrip.ResumeLayout(False)
        MenuStrip.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox As PictureBox
    Friend WithEvents GroupBoxBuscar As GroupBox
    Friend WithEvents LabelBuscar As Label
    Friend WithEvents TextBoxBuscarAlumno As TextBox
    Friend WithEvents ButtonBuscar As Button
    Friend WithEvents ButtonUltimo As Button
    Friend WithEvents ButtonSiguiente As Button
    Friend WithEvents ButtonAnterior As Button
    Friend WithEvents ButtonPrimero As Button
    Friend WithEvents ListView As ListView
    Friend WithEvents ButtonAceptar As Button
    Friend WithEvents ButtonCancelar As Button
    Friend WithEvents GroupBoxRellenarDatos As GroupBox
    Friend WithEvents LabelAlumno As Label
    Friend WithEvents LabelNota1 As Label
    Friend WithEvents LabelNota3 As Label
    Friend WithEvents LabelAsignatura As Label
    Friend WithEvents TextBoxAsignatura As TextBox
    Friend WithEvents TextBoxNota3 As TextBox
    Friend WithEvents TextBoxNota1 As TextBox
    Friend WithEvents TextBoxAlumno As TextBox
    Friend WithEvents MenuStrip As MenuStrip
    Friend WithEvents AgregarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ModificarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VisualizarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VolverToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxBuscarAsignatura As TextBox
    Friend WithEvents LabelNota2 As Label
    Friend WithEvents LabelNotaFinal As Label
    Friend WithEvents TextBoxNotaFinal As TextBox
    Friend WithEvents TextBoxNota2 As TextBox
End Class
