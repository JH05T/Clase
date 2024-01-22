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
        ButtonAlumnos = New Button()
        ButtonAsignaturas = New Button()
        ButtonNotas = New Button()
        ButtonProfesores = New Button()
        SuspendLayout()
        ' 
        ' ButtonAlumnos
        ' 
        ButtonAlumnos.Location = New Point(303, 61)
        ButtonAlumnos.Name = "ButtonAlumnos"
        ButtonAlumnos.Size = New Size(75, 23)
        ButtonAlumnos.TabIndex = 0
        ButtonAlumnos.Text = "Alumnos"
        ButtonAlumnos.UseVisualStyleBackColor = True
        ' 
        ' ButtonAsignaturas
        ' 
        ButtonAsignaturas.Location = New Point(303, 139)
        ButtonAsignaturas.Name = "ButtonAsignaturas"
        ButtonAsignaturas.Size = New Size(75, 23)
        ButtonAsignaturas.TabIndex = 1
        ButtonAsignaturas.Text = "Asignaturas"
        ButtonAsignaturas.UseVisualStyleBackColor = True
        ' 
        ' ButtonNotas
        ' 
        ButtonNotas.Location = New Point(303, 232)
        ButtonNotas.Name = "ButtonNotas"
        ButtonNotas.Size = New Size(75, 23)
        ButtonNotas.TabIndex = 2
        ButtonNotas.Text = "Notas"
        ButtonNotas.UseVisualStyleBackColor = True
        ' 
        ' ButtonProfesores
        ' 
        ButtonProfesores.Location = New Point(303, 317)
        ButtonProfesores.Name = "ButtonProfesores"
        ButtonProfesores.Size = New Size(75, 23)
        ButtonProfesores.TabIndex = 3
        ButtonProfesores.Text = "Profesores"
        ButtonProfesores.UseVisualStyleBackColor = True
        ' 
        ' Inicio
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(ButtonProfesores)
        Controls.Add(ButtonNotas)
        Controls.Add(ButtonAsignaturas)
        Controls.Add(ButtonAlumnos)
        Name = "Inicio"
        ResumeLayout(False)
    End Sub

    Friend WithEvents ButtonAlumnos As Button
    Friend WithEvents ButtonAsignaturas As Button
    Friend WithEvents ButtonNotas As Button
    Friend WithEvents ButtonProfesores As Button
End Class
