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
        MenuStripAlumnos.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStripAlumnos
        ' 
        MenuStripAlumnos.Items.AddRange(New ToolStripItem() {ToolStripMenuItem1, AgregarToolStripMenuItem, EliminarToolStripMenuItem, ModificarToolStripMenuItem, VisualizarToolStripMenuItem})
        MenuStripAlumnos.Location = New Point(0, 0)
        MenuStripAlumnos.Name = "MenuStripAlumnos"
        MenuStripAlumnos.Size = New Size(800, 24)
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
        ListViewAlumnos.Location = New Point(12, 182)
        ListViewAlumnos.Name = "ListViewAlumnos"
        ListViewAlumnos.Size = New Size(776, 256)
        ListViewAlumnos.TabIndex = 2
        ListViewAlumnos.UseCompatibleStateImageBehavior = False
        ' 
        ' Alumnos
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(ListViewAlumnos)
        Controls.Add(MenuStripAlumnos)
        MainMenuStrip = MenuStripAlumnos
        Name = "Alumnos"
        Text = "Alumnos"
        MenuStripAlumnos.ResumeLayout(False)
        MenuStripAlumnos.PerformLayout()
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
End Class
