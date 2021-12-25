<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainAppForm
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
        Me.components = New System.ComponentModel.Container()
        Me.buttonSourceImage = New System.Windows.Forms.Button()
        Me.tbSourceImageFilename = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pbSourceImage = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pbWarpMap = New System.Windows.Forms.PictureBox()
        Me.buttonWarpMap = New System.Windows.Forms.Button()
        Me.tbWarpMapFilename = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lRightClickForOptions = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pbOutputImage = New System.Windows.Forms.PictureBox()
        Me.cmsOutputImage = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenImageOutputFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.buttonOutput = New System.Windows.Forms.Button()
        Me.tbOutputFilename = New System.Windows.Forms.TextBox()
        Me.buttonDoIt = New System.Windows.Forms.Button()
        Me.chkRepairSeams = New System.Windows.Forms.CheckBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.tbConsole = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.msMainMenu = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UtilitiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerateIdentityWarpMapToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.X512ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.X1024ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.X2048ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.X4096ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.X8912ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BrowseTemporalImagesFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProjectsWebsiteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel2.SuspendLayout()
        CType(Me.pbSourceImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.pbWarpMap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.pbOutputImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsOutputImage.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.msMainMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'buttonSourceImage
        '
        Me.buttonSourceImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonSourceImage.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.buttonSourceImage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.buttonSourceImage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.buttonSourceImage.Location = New System.Drawing.Point(220, 21)
        Me.buttonSourceImage.Name = "buttonSourceImage"
        Me.buttonSourceImage.Size = New System.Drawing.Size(41, 25)
        Me.buttonSourceImage.TabIndex = 0
        Me.buttonSourceImage.Text = "..."
        Me.buttonSourceImage.UseVisualStyleBackColor = True
        '
        'tbSourceImageFilename
        '
        Me.tbSourceImageFilename.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbSourceImageFilename.Location = New System.Drawing.Point(3, 22)
        Me.tbSourceImageFilename.Name = "tbSourceImageFilename"
        Me.tbSourceImageFilename.Size = New System.Drawing.Size(211, 23)
        Me.tbSourceImageFilename.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.pbSourceImage)
        Me.Panel2.Controls.Add(Me.buttonSourceImage)
        Me.Panel2.Controls.Add(Me.tbSourceImageFilename)
        Me.Panel2.Location = New System.Drawing.Point(12, 27)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(264, 150)
        Me.Panel2.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "1. Source Image"
        '
        'pbSourceImage
        '
        Me.pbSourceImage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbSourceImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbSourceImage.Location = New System.Drawing.Point(3, 51)
        Me.pbSourceImage.Name = "pbSourceImage"
        Me.pbSourceImage.Size = New System.Drawing.Size(258, 96)
        Me.pbSourceImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbSourceImage.TabIndex = 3
        Me.pbSourceImage.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.pbWarpMap)
        Me.Panel1.Controls.Add(Me.buttonWarpMap)
        Me.Panel1.Controls.Add(Me.tbWarpMapFilename)
        Me.Panel1.Location = New System.Drawing.Point(282, 27)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(403, 150)
        Me.Panel1.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 15)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "2. WarpMap"
        '
        'pbWarpMap
        '
        Me.pbWarpMap.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbWarpMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbWarpMap.Location = New System.Drawing.Point(3, 51)
        Me.pbWarpMap.Name = "pbWarpMap"
        Me.pbWarpMap.Size = New System.Drawing.Size(397, 96)
        Me.pbWarpMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbWarpMap.TabIndex = 3
        Me.pbWarpMap.TabStop = False
        '
        'buttonWarpMap
        '
        Me.buttonWarpMap.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonWarpMap.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.buttonWarpMap.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.buttonWarpMap.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.buttonWarpMap.Location = New System.Drawing.Point(359, 21)
        Me.buttonWarpMap.Name = "buttonWarpMap"
        Me.buttonWarpMap.Size = New System.Drawing.Size(41, 25)
        Me.buttonWarpMap.TabIndex = 0
        Me.buttonWarpMap.Text = "..."
        Me.buttonWarpMap.UseVisualStyleBackColor = True
        '
        'tbWarpMapFilename
        '
        Me.tbWarpMapFilename.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbWarpMapFilename.Location = New System.Drawing.Point(3, 22)
        Me.tbWarpMapFilename.Name = "tbWarpMapFilename"
        Me.tbWarpMapFilename.Size = New System.Drawing.Size(350, 23)
        Me.tbWarpMapFilename.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel3.Controls.Add(Me.lRightClickForOptions)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.pbOutputImage)
        Me.Panel3.Controls.Add(Me.buttonOutput)
        Me.Panel3.Controls.Add(Me.tbOutputFilename)
        Me.Panel3.Location = New System.Drawing.Point(12, 183)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(264, 217)
        Me.Panel3.TabIndex = 6
        '
        'lRightClickForOptions
        '
        Me.lRightClickForOptions.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lRightClickForOptions.AutoSize = True
        Me.lRightClickForOptions.Location = New System.Drawing.Point(3, 199)
        Me.lRightClickForOptions.Name = "lRightClickForOptions"
        Me.lRightClickForOptions.Size = New System.Drawing.Size(192, 15)
        Me.lRightClickForOptions.TabIndex = 14
        Me.lRightClickForOptions.Text = "Right click in the image for options"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "3. Output"
        '
        'pbOutputImage
        '
        Me.pbOutputImage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbOutputImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbOutputImage.ContextMenuStrip = Me.cmsOutputImage
        Me.pbOutputImage.Location = New System.Drawing.Point(3, 51)
        Me.pbOutputImage.Name = "pbOutputImage"
        Me.pbOutputImage.Size = New System.Drawing.Size(258, 163)
        Me.pbOutputImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbOutputImage.TabIndex = 3
        Me.pbOutputImage.TabStop = False
        '
        'cmsOutputImage
        '
        Me.cmsOutputImage.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveAsToolStripMenuItem, Me.OpenToolStripMenuItem, Me.OpenImageOutputFolderToolStripMenuItem})
        Me.cmsOutputImage.Name = "ContextMenuStrip1"
        Me.cmsOutputImage.Size = New System.Drawing.Size(190, 70)
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.SaveAsToolStripMenuItem.Text = "Save As..."
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'OpenImageOutputFolderToolStripMenuItem
        '
        Me.OpenImageOutputFolderToolStripMenuItem.Name = "OpenImageOutputFolderToolStripMenuItem"
        Me.OpenImageOutputFolderToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.OpenImageOutputFolderToolStripMenuItem.Text = "Browse Output Folder"
        '
        'buttonOutput
        '
        Me.buttonOutput.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonOutput.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.buttonOutput.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.buttonOutput.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.buttonOutput.Location = New System.Drawing.Point(220, 21)
        Me.buttonOutput.Name = "buttonOutput"
        Me.buttonOutput.Size = New System.Drawing.Size(41, 25)
        Me.buttonOutput.TabIndex = 0
        Me.buttonOutput.Text = "..."
        Me.buttonOutput.UseVisualStyleBackColor = True
        '
        'tbOutputFilename
        '
        Me.tbOutputFilename.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbOutputFilename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbOutputFilename.Location = New System.Drawing.Point(3, 22)
        Me.tbOutputFilename.Name = "tbOutputFilename"
        Me.tbOutputFilename.Size = New System.Drawing.Size(211, 23)
        Me.tbOutputFilename.TabIndex = 1
        Me.tbOutputFilename.Text = "output\outputImage.png"
        '
        'buttonDoIt
        '
        Me.buttonDoIt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonDoIt.FlatAppearance.BorderSize = 0
        Me.buttonDoIt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.buttonDoIt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.buttonDoIt.Location = New System.Drawing.Point(3, 51)
        Me.buttonDoIt.Name = "buttonDoIt"
        Me.buttonDoIt.Size = New System.Drawing.Size(397, 25)
        Me.buttonDoIt.TabIndex = 5
        Me.buttonDoIt.Text = "Do it!"
        Me.buttonDoIt.UseVisualStyleBackColor = True
        '
        'chkRepairSeams
        '
        Me.chkRepairSeams.AutoSize = True
        Me.chkRepairSeams.Checked = True
        Me.chkRepairSeams.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRepairSeams.Location = New System.Drawing.Point(5, 26)
        Me.chkRepairSeams.Name = "chkRepairSeams"
        Me.chkRepairSeams.Size = New System.Drawing.Size(95, 19)
        Me.chkRepairSeams.TabIndex = 11
        Me.chkRepairSeams.Text = "Repair seams"
        Me.chkRepairSeams.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.Controls.Add(Me.tbConsole)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.chkRepairSeams)
        Me.Panel4.Controls.Add(Me.buttonDoIt)
        Me.Panel4.Location = New System.Drawing.Point(282, 183)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(403, 217)
        Me.Panel4.TabIndex = 12
        '
        'tbConsole
        '
        Me.tbConsole.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbConsole.Location = New System.Drawing.Point(3, 109)
        Me.tbConsole.Multiline = True
        Me.tbConsole.Name = "tbConsole"
        Me.tbConsole.ReadOnly = True
        Me.tbConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbConsole.Size = New System.Drawing.Size(397, 105)
        Me.tbConsole.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 91)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(27, 15)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Log"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 15)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "4. Parameters"
        '
        'msMainMenu
        '
        Me.msMainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.UtilitiesToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.msMainMenu.Location = New System.Drawing.Point(0, 0)
        Me.msMainMenu.Name = "msMainMenu"
        Me.msMainMenu.Size = New System.Drawing.Size(697, 24)
        Me.msMainMenu.TabIndex = 13
        Me.msMainMenu.Text = "Main Menu"
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
        'UtilitiesToolStripMenuItem
        '
        Me.UtilitiesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GenerateIdentityWarpMapToolStripMenuItem, Me.BrowseTemporalImagesFolderToolStripMenuItem})
        Me.UtilitiesToolStripMenuItem.Name = "UtilitiesToolStripMenuItem"
        Me.UtilitiesToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.UtilitiesToolStripMenuItem.Text = "Utilities"
        '
        'GenerateIdentityWarpMapToolStripMenuItem
        '
        Me.GenerateIdentityWarpMapToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.X512ToolStripMenuItem, Me.X1024ToolStripMenuItem, Me.X2048ToolStripMenuItem, Me.X4096ToolStripMenuItem, Me.X8912ToolStripMenuItem})
        Me.GenerateIdentityWarpMapToolStripMenuItem.Name = "GenerateIdentityWarpMapToolStripMenuItem"
        Me.GenerateIdentityWarpMapToolStripMenuItem.Size = New System.Drawing.Size(241, 22)
        Me.GenerateIdentityWarpMapToolStripMenuItem.Text = "Generate Identity WarpMap"
        '
        'X512ToolStripMenuItem
        '
        Me.X512ToolStripMenuItem.Name = "X512ToolStripMenuItem"
        Me.X512ToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.X512ToolStripMenuItem.Tag = "512"
        Me.X512ToolStripMenuItem.Text = "512 x 512"
        '
        'X1024ToolStripMenuItem
        '
        Me.X1024ToolStripMenuItem.Name = "X1024ToolStripMenuItem"
        Me.X1024ToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.X1024ToolStripMenuItem.Tag = "1024"
        Me.X1024ToolStripMenuItem.Text = "1024 x 1024"
        '
        'X2048ToolStripMenuItem
        '
        Me.X2048ToolStripMenuItem.Name = "X2048ToolStripMenuItem"
        Me.X2048ToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.X2048ToolStripMenuItem.Tag = "2048"
        Me.X2048ToolStripMenuItem.Text = "2048 x 2048"
        '
        'X4096ToolStripMenuItem
        '
        Me.X4096ToolStripMenuItem.Name = "X4096ToolStripMenuItem"
        Me.X4096ToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.X4096ToolStripMenuItem.Tag = "4096"
        Me.X4096ToolStripMenuItem.Text = "4096 x 4096"
        '
        'X8912ToolStripMenuItem
        '
        Me.X8912ToolStripMenuItem.Name = "X8912ToolStripMenuItem"
        Me.X8912ToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.X8912ToolStripMenuItem.Tag = "8912"
        Me.X8912ToolStripMenuItem.Text = "8192 x 8912"
        '
        'BrowseTemporalImagesFolderToolStripMenuItem
        '
        Me.BrowseTemporalImagesFolderToolStripMenuItem.Name = "BrowseTemporalImagesFolderToolStripMenuItem"
        Me.BrowseTemporalImagesFolderToolStripMenuItem.Size = New System.Drawing.Size(241, 22)
        Me.BrowseTemporalImagesFolderToolStripMenuItem.Text = "Browse Temporal Images Folder"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProjectsWebsiteToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'ProjectsWebsiteToolStripMenuItem
        '
        Me.ProjectsWebsiteToolStripMenuItem.Name = "ProjectsWebsiteToolStripMenuItem"
        Me.ProjectsWebsiteToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.ProjectsWebsiteToolStripMenuItem.Text = "Project's website"
        '
        'MainAppForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(697, 412)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.msMainMenu)
        Me.DoubleBuffered = True
        Me.MainMenuStrip = Me.msMainMenu
        Me.Name = "MainAppForm"
        Me.Text = "Image Warp [XMH Tools Suite]"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.pbSourceImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbWarpMap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.pbOutputImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsOutputImage.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.msMainMenu.ResumeLayout(False)
        Me.msMainMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents buttonSourceImage As Button
    Friend WithEvents tbSourceImageFilename As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents pbSourceImage As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents pbWarpMap As PictureBox
    Friend WithEvents buttonWarpMap As Button
    Friend WithEvents tbWarpMapFilename As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents pbOutputImage As PictureBox
    Friend WithEvents buttonOutput As Button
    Friend WithEvents tbOutputFilename As TextBox
    Friend WithEvents buttonDoIt As Button
    Friend WithEvents chkRepairSeams As CheckBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents tbConsole As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents msMainMenu As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UtilitiesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GenerateIdentityWarpMapToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents X1024ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents X512ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents X2048ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents X4096ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents X8912ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProjectsWebsiteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lRightClickForOptions As Label
    Friend WithEvents BrowseTemporalImagesFolderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents cmsOutputImage As ContextMenuStrip
    Friend WithEvents SaveAsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenImageOutputFolderToolStripMenuItem As ToolStripMenuItem
End Class
