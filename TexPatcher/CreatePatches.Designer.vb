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
        Me.bCreatePatches.Location = New System.Drawing.Point(615, 96)
        Me.bCreatePatches.Name = "bCreatePatches"
        Me.bCreatePatches.Size = New System.Drawing.Size(73, 62)
        Me.bCreatePatches.TabIndex = 0
        Me.bCreatePatches.Text = "Create Patch"
        Me.bCreatePatches.UseVisualStyleBackColor = True
        '
        'imfPatch
        '
        Me.imfPatch.FileFilter = "PNG Files|*.png"
        Me.imfPatch.ImageFile = "patched.png"
        Me.imfPatch.ImageFileLabel = "Patch"
        Me.imfPatch.IsOutput = True
        Me.imfPatch.Location = New System.Drawing.Point(414, 12)
        Me.imfPatch.Name = "imfPatch"
        Me.imfPatch.Size = New System.Drawing.Size(195, 146)
        Me.imfPatch.TabIndex = 12
        '
        'imfMask
        '
        Me.imfMask.FileFilter = "PNG Files|*.png"
        Me.imfMask.ImageFile = ""
        Me.imfMask.ImageFileLabel = "Mask"
        Me.imfMask.IsOutput = False
        Me.imfMask.Location = New System.Drawing.Point(213, 12)
        Me.imfMask.Name = "imfMask"
        Me.imfMask.Size = New System.Drawing.Size(195, 146)
        Me.imfMask.TabIndex = 11
        '
        'imfSource
        '
        Me.imfSource.FileFilter = "DDS and PNG Files|*.dds;*.png"
        Me.imfSource.ImageFile = ""
        Me.imfSource.ImageFileLabel = "Texture"
        Me.imfSource.IsOutput = False
        Me.imfSource.Location = New System.Drawing.Point(12, 12)
        Me.imfSource.Name = "imfSource"
        Me.imfSource.Size = New System.Drawing.Size(195, 146)
        Me.imfSource.TabIndex = 13
        '
        'CreatePatches
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(699, 170)
        Me.Controls.Add(Me.imfSource)
        Me.Controls.Add(Me.imfPatch)
        Me.Controls.Add(Me.imfMask)
        Me.Controls.Add(Me.bCreatePatches)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
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
