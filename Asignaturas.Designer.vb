﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        MenuStripAsignaturas = New MenuStrip()
        AgregarToolStripMenuItem = New ToolStripMenuItem()
        EliminarToolStripMenuItem = New ToolStripMenuItem()
        ModificarToolStripMenuItem = New ToolStripMenuItem()
        VisualizarToolStripMenuItem = New ToolStripMenuItem()
        ToolStripMenuItem1 = New ToolStripMenuItem()
        MenuStripAsignaturas.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStripAsignaturas
        ' 
        MenuStripAsignaturas.Items.AddRange(New ToolStripItem() {ToolStripMenuItem1, AgregarToolStripMenuItem, EliminarToolStripMenuItem, ModificarToolStripMenuItem, VisualizarToolStripMenuItem})
        MenuStripAsignaturas.Location = New Point(0, 0)
        MenuStripAsignaturas.Name = "MenuStripAsignaturas"
        MenuStripAsignaturas.Size = New Size(800, 24)
        MenuStripAsignaturas.TabIndex = 2
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
        ' ToolStripMenuItem1
        ' 
        ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        ToolStripMenuItem1.Size = New Size(12, 20)
        ' 
        ' Asignaturas
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(MenuStripAsignaturas)
        Name = "Asignaturas"
        Text = "Asignaturas"
        MenuStripAsignaturas.ResumeLayout(False)
        MenuStripAsignaturas.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents MenuStripAsignaturas As MenuStrip
    Friend WithEvents AgregarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ModificarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VisualizarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
End Class
