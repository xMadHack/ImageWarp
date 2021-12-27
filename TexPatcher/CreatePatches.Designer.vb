<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CreatePatches
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
        Me.bCreatePatches = New System.Windows.Forms.Button()
        Me.imfPatch = New TexPatcherTool.ImageFileControl()
        Me.imfMask = New TexPatcherTool.ImageFileControl()
        Me.imfSource = New TexPatcherTool.ImageFileControl()
        Me.SuspendLayout()
        '
        'bCreatePatches
        '
        Me.bCreatePatches.Location = New System.Drawing.Point(879, 160)
        Me.bCreatePatches.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bCreatePatches.Name = "bCreatePatches"
        Me.bCreatePatches.Size = New System.Drawing.Size(104, 103)
        Me.bCreatePatches.TabIndex = 0
        Me.bCreatePatches.Text = "Create Patch"
        Me.bCreatePatches.UseVisualStyleBackColor = True
        '
        'imfPatch
        '
        Me.imfPatch.FileFilter = "PNG Files|*.png"
        Me.imfPatch.ImageFile = "patch.png"
        Me.imfPatch.ImageFileLabel = "Patch (Png only)"
        Me.imfPatch.IsOutput = True
        Me.imfPatch.Location = New System.Drawing.Point(591, 20)
        Me.imfPatch.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        Me.imfPatch.Name = "imfPatch"
        Me.imfPatch.Size = New System.Drawing.Size(279, 243)
        Me.imfPatch.TabIndex = 12
        '
        'imfMask
        '
        Me.imfMask.FileFilter = "PNG Files|*.png"
        Me.imfMask.ImageFile = ""
        Me.imfMask.ImageFileLabel = "Mask (Png only)"
        Me.imfMask.IsOutput = False
        Me.imfMask.Location = New System.Drawing.Point(304, 20)
        Me.imfMask.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        Me.imfMask.Name = "imfMask"
        Me.imfMask.Size = New System.Drawing.Size(279, 243)
        Me.imfMask.TabIndex = 11
        '
        'imfSource
        '
        Me.imfSource.FileFilter = "DDS and PNG Files|*.dds;*.png"
        Me.imfSource.ImageFile = ""
        Me.imfSource.ImageFileLabel = "Texture"
        Me.imfSource.IsOutput = False
        Me.imfSource.Location = New System.Drawing.Point(17, 20)
        Me.imfSource.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        Me.imfSource.Name = "imfSource"
        Me.imfSource.Size = New System.Drawing.Size(279, 243)
        Me.imfSource.TabIndex = 13
        '
        'CreatePatches
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 30.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(999, 283)
        Me.Controls.Add(Me.imfSource)
        Me.Controls.Add(Me.imfPatch)
        Me.Controls.Add(Me.imfMask)
        Me.Controls.Add(Me.bCreatePatches)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.Name = "CreatePatches"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "CreatePatch Tool"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents bCreatePatches As Button

    Friend WithEvents imfPatch As ImageFileControl
    Friend WithEvents imfMask As ImageFileControl
    Friend WithEvents imfSource As ImageFileControl
End Class
