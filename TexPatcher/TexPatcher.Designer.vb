<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TexPatcher
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
        Me.imfPatched = New TexPatcherTool.ImageFileControl()
        Me.imfPatch = New TexPatcherTool.ImageFileControl()
        Me.imfSource = New TexPatcherTool.ImageFileControl()
        Me.bApplyPatches = New System.Windows.Forms.Button()
        Me.chkCompressDds = New System.Windows.Forms.CheckBox()
        Me.cbPatches = New System.Windows.Forms.ComboBox()
        Me.chkCloseWhenFinished = New System.Windows.Forms.CheckBox()
        Me.MenuBar = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenCreatePatchToolToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutImagePatcherToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutXMadHackToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SupportUsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContributeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PatreonToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PaypalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'imfPatched
        '
        Me.imfPatched.FileFilter = "DDS and PNG Files|*.dds;*.png"
        Me.imfPatched.ImageFile = "patched.png"
        Me.imfPatched.ImageFileLabel = "Patched"
        Me.imfPatched.IsOutput = True
        Me.imfPatched.Location = New System.Drawing.Point(407, 32)
        Me.imfPatched.Name = "imfPatched"
        Me.imfPatched.Size = New System.Drawing.Size(195, 175)
        Me.imfPatched.TabIndex = 4
        '
        'imfPatch
        '
        Me.imfPatch.FileFilter = "PNG Files|*.png"
        Me.imfPatch.ImageFile = ""
        Me.imfPatch.ImageFileLabel = "Patch"
        Me.imfPatch.IsOutput = False
        Me.imfPatch.Location = New System.Drawing.Point(206, 32)
        Me.imfPatch.Name = "imfPatch"
        Me.imfPatch.Size = New System.Drawing.Size(195, 146)
        Me.imfPatch.TabIndex = 2
        '
        'imfSource
        '
        Me.imfSource.FileFilter = "DDS and PNG Files|*.dds;*.png"
        Me.imfSource.ImageFile = ""
        Me.imfSource.ImageFileLabel = "Source"
        Me.imfSource.IsOutput = False
        Me.imfSource.Location = New System.Drawing.Point(5, 32)
        Me.imfSource.Name = "imfSource"
        Me.imfSource.Size = New System.Drawing.Size(195, 175)
        Me.imfSource.TabIndex = 1
        '
        'bApplyPatches
        '
        Me.bApplyPatches.Location = New System.Drawing.Point(618, 139)
        Me.bApplyPatches.Name = "bApplyPatches"
        Me.bApplyPatches.Size = New System.Drawing.Size(229, 39)
        Me.bApplyPatches.TabIndex = 7
        Me.bApplyPatches.Text = "Apply Patch"
        Me.bApplyPatches.UseVisualStyleBackColor = True
        '
        'chkCompressDds
        '
        Me.chkCompressDds.AutoSize = True
        Me.chkCompressDds.Checked = True
        Me.chkCompressDds.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCompressDds.Location = New System.Drawing.Point(618, 73)
        Me.chkCompressDds.Name = "chkCompressDds"
        Me.chkCompressDds.Size = New System.Drawing.Size(240, 19)
        Me.chkCompressDds.TabIndex = 5
        Me.chkCompressDds.Text = "Compress as BC7 (Only for .dds outputs)"
        Me.chkCompressDds.UseVisualStyleBackColor = True
        '
        'cbPatches
        '
        Me.cbPatches.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPatches.FormattingEnabled = True
        Me.cbPatches.Location = New System.Drawing.Point(206, 184)
        Me.cbPatches.Name = "cbPatches"
        Me.cbPatches.Size = New System.Drawing.Size(195, 23)
        Me.cbPatches.TabIndex = 3
        '
        'chkCloseWhenFinished
        '
        Me.chkCloseWhenFinished.AutoSize = True
        Me.chkCloseWhenFinished.Checked = True
        Me.chkCloseWhenFinished.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCloseWhenFinished.Location = New System.Drawing.Point(618, 98)
        Me.chkCloseWhenFinished.Name = "chkCloseWhenFinished"
        Me.chkCloseWhenFinished.Size = New System.Drawing.Size(136, 19)
        Me.chkCloseWhenFinished.TabIndex = 6
        Me.chkCloseWhenFinished.Text = "Close When Finished"
        Me.chkCloseWhenFinished.UseVisualStyleBackColor = True
        '
        'MenuBar
        '
        Me.MenuBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.HelpToolStripMenuItem, Me.SupportUsToolStripMenuItem})
        Me.MenuBar.Location = New System.Drawing.Point(0, 0)
        Me.MenuBar.Name = "MenuBar"
        Me.MenuBar.Size = New System.Drawing.Size(867, 24)
        Me.MenuBar.TabIndex = 15
        Me.MenuBar.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(93, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenCreatePatchToolToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.ToolsToolStripMenuItem.Text = "Tools"
        '
        'OpenCreatePatchToolToolStripMenuItem
        '
        Me.OpenCreatePatchToolToolStripMenuItem.Name = "OpenCreatePatchToolToolStripMenuItem"
        Me.OpenCreatePatchToolToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.OpenCreatePatchToolToolStripMenuItem.Text = "Open CreatePatch Tool"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutImagePatcherToolStripMenuItem, Me.AboutXMadHackToolsToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutImagePatcherToolStripMenuItem
        '
        Me.AboutImagePatcherToolStripMenuItem.Name = "AboutImagePatcherToolStripMenuItem"
        Me.AboutImagePatcherToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.AboutImagePatcherToolStripMenuItem.Text = "About ImagePatcher"
        '
        'AboutXMadHackToolsToolStripMenuItem
        '
        Me.AboutXMadHackToolsToolStripMenuItem.Name = "AboutXMadHackToolsToolStripMenuItem"
        Me.AboutXMadHackToolsToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.AboutXMadHackToolsToolStripMenuItem.Text = "About xMadHackTools"
        '
        'SupportUsToolStripMenuItem
        '
        Me.SupportUsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContributeToolStripMenuItem, Me.PatreonToolStripMenuItem, Me.PaypalToolStripMenuItem})
        Me.SupportUsToolStripMenuItem.Name = "SupportUsToolStripMenuItem"
        Me.SupportUsToolStripMenuItem.Size = New System.Drawing.Size(76, 20)
        Me.SupportUsToolStripMenuItem.Text = "Contribute"
        '
        'ContributeToolStripMenuItem
        '
        Me.ContributeToolStripMenuItem.Name = "ContributeToolStripMenuItem"
        Me.ContributeToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.ContributeToolStripMenuItem.Text = "To xMadHack Github"
        '
        'PatreonToolStripMenuItem
        '
        Me.PatreonToolStripMenuItem.Name = "PatreonToolStripMenuItem"
        Me.PatreonToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.PatreonToolStripMenuItem.Text = "As a Patreon"
        '
        'PaypalToolStripMenuItem
        '
        Me.PaypalToolStripMenuItem.Name = "PaypalToolStripMenuItem"
        Me.PaypalToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.PaypalToolStripMenuItem.Text = "Donate with Paypal"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(618, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 15)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Output Options"
        '
        'TexPatcher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(867, 225)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkCloseWhenFinished)
        Me.Controls.Add(Me.cbPatches)
        Me.Controls.Add(Me.chkCompressDds)
        Me.Controls.Add(Me.imfPatched)
        Me.Controls.Add(Me.imfPatch)
        Me.Controls.Add(Me.imfSource)
        Me.Controls.Add(Me.bApplyPatches)
        Me.Controls.Add(Me.MenuBar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuBar
        Me.MaximizeBox = False
        Me.Name = "TexPatcher"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ImagePatcher"
        Me.MenuBar.ResumeLayout(False)
        Me.MenuBar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents imfPatched As ImageFileControl
    Friend WithEvents imfPatch As ImageFileControl
    Friend WithEvents imfSource As ImageFileControl
    Friend WithEvents bApplyPatches As Button
    Friend WithEvents chkCompressDds As CheckBox
    Friend WithEvents cbPatches As ComboBox
    Friend WithEvents chkCloseWhenFinished As CheckBox
    Friend WithEvents MenuBar As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutXMadHackToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SupportUsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenCreatePatchToolToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutImagePatcherToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PatreonToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PaypalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContributeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label1 As Label
End Class
