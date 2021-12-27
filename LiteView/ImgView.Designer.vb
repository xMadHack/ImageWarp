<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImgView
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.FpsLock = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsDdsUncompressedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsDdsBC7ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToClipboardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FpsLock
        '
        Me.FpsLock.Enabled = True
        Me.FpsLock.Interval = 20
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(28, 28)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveAsToolStripMenuItem, Me.SaveAsDdsUncompressedToolStripMenuItem, Me.SaveAsDdsBC7ToolStripMenuItem, Me.CopyToClipboardToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(395, 184)
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(394, 36)
        Me.SaveAsToolStripMenuItem.Text = "Save As PNG..."
        '
        'SaveAsDdsUncompressedToolStripMenuItem
        '
        Me.SaveAsDdsUncompressedToolStripMenuItem.Name = "SaveAsDdsUncompressedToolStripMenuItem"
        Me.SaveAsDdsUncompressedToolStripMenuItem.Size = New System.Drawing.Size(394, 36)
        Me.SaveAsDdsUncompressedToolStripMenuItem.Text = "Save As DDS (Uncompressed)..."
        '
        'SaveAsDdsBC7ToolStripMenuItem
        '
        Me.SaveAsDdsBC7ToolStripMenuItem.Name = "SaveAsDdsBC7ToolStripMenuItem"
        Me.SaveAsDdsBC7ToolStripMenuItem.Size = New System.Drawing.Size(394, 36)
        Me.SaveAsDdsBC7ToolStripMenuItem.Text = "Save As DDS (Compressed BC7)..."
        '
        'CopyToClipboardToolStripMenuItem
        '
        Me.CopyToClipboardToolStripMenuItem.Name = "CopyToClipboardToolStripMenuItem"
        Me.CopyToClipboardToolStripMenuItem.Size = New System.Drawing.Size(394, 36)
        Me.CopyToClipboardToolStripMenuItem.Text = "Copy to Clipboard"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(394, 36)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ImgView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 30.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DoubleBuffered = True
        Me.Name = "ImgView"
        Me.Size = New System.Drawing.Size(975, 695)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents FpsLock As Timer
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents SaveAsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopyToClipboardToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveAsDdsBC7ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveAsDdsUncompressedToolStripMenuItem As ToolStripMenuItem
End Class
