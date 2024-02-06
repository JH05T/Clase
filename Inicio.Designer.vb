<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inicio
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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Inicio))
        ButtonAlumnos = New Button()
        ButtonAsignaturas = New Button()
        ButtonNotas = New Button()
        ButtonProfesores = New Button()
        PictureBox1 = New PictureBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' ButtonAlumnos
        ' 
        ButtonAlumnos.FlatStyle = FlatStyle.System
        ButtonAlumnos.Font = New Font("Gabriola", 21.75F, FontStyle.Regular, GraphicsUnit.Point)
        ButtonAlumnos.Location = New Point(40, 80)
        ButtonAlumnos.Name = "ButtonAlumnos"
        ButtonAlumnos.Size = New Size(150, 75)
        ButtonAlumnos.TabIndex = 0
        ButtonAlumnos.Text = "Alumnos"
        ButtonAlumnos.UseVisualStyleBackColor = True
        ' 
        ' ButtonAsignaturas
        ' 
        ButtonAsignaturas.Font = New Font("Gabriola", 21.75F, FontStyle.Regular, GraphicsUnit.Point)
        ButtonAsignaturas.Location = New Point(40, 240)
        ButtonAsignaturas.Name = "ButtonAsignaturas"
        ButtonAsignaturas.Size = New Size(150, 75)
        ButtonAsignaturas.TabIndex = 1
        ButtonAsignaturas.Text = "Asignaturas"
        ButtonAsignaturas.UseVisualStyleBackColor = True
        ' 
        ' ButtonNotas
        ' 
        ButtonNotas.Font = New Font("Gabriola", 21.75F, FontStyle.Regular, GraphicsUnit.Point)
        ButtonNotas.Location = New Point(40, 560)
        ButtonNotas.Name = "ButtonNotas"
        ButtonNotas.Size = New Size(150, 75)
        ButtonNotas.TabIndex = 2
        ButtonNotas.Text = "Notas"
        ButtonNotas.UseVisualStyleBackColor = True
        ' 
        ' ButtonProfesores
        ' 
        ButtonProfesores.Font = New Font("Gabriola", 21.75F, FontStyle.Regular, GraphicsUnit.Point)
        ButtonProfesores.Location = New Point(40, 400)
        ButtonProfesores.Name = "ButtonProfesores"
        ButtonProfesores.Size = New Size(150, 75)
        ButtonProfesores.TabIndex = 3
        ButtonProfesores.Text = "Profesores"
        ButtonProfesores.UseVisualStyleBackColor = True
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), Image)
        PictureBox1.ErrorImage = Nothing
        PictureBox1.Location = New Point(230, 0)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(1000, 707)
        PictureBox1.TabIndex = 4
        PictureBox1.TabStop = False
        ' 
        ' Inicio
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(1234, 711)
        Controls.Add(PictureBox1)
        Controls.Add(ButtonProfesores)
        Controls.Add(ButtonNotas)
        Controls.Add(ButtonAsignaturas)
        Controls.Add(ButtonAlumnos)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Inicio"
        StartPosition = FormStartPosition.CenterScreen
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents ButtonAlumnos As Button
    Friend WithEvents ButtonAsignaturas As Button
    Friend WithEvents ButtonNotas As Button
    Friend WithEvents ButtonProfesores As Button
    Friend WithEvents PictureBox1 As PictureBox
End Class
