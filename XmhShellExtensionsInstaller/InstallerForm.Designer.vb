<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InstallerForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InstallerForm))
        Me.bInstall = New System.Windows.Forms.Button()
        Me.bUninstall = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbInstallAll = New System.Windows.Forms.RadioButton()
        Me.rbInstallThumbnails = New System.Windows.Forms.RadioButton()
        Me.rbInstallContextMenu = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'bInstall
        '
        Me.bInstall.Location = New System.Drawing.Point(370, 45)
        Me.bInstall.Name = "bInstall"
        Me.bInstall.Size = New System.Drawing.Size(75, 23)
        Me.bInstall.TabIndex = 0
        Me.bInstall.Text = "Install"
        Me.bInstall.UseVisualStyleBackColor = True
        '
        'bUninstall
        '
        Me.bUninstall.Location = New System.Drawing.Point(6, 33)
        Me.bUninstall.Name = "bUninstall"
        Me.bUninstall.Size = New System.Drawing.Size(172, 23)
        Me.bUninstall.TabIndex = 1
        Me.bUninstall.Text = "Uninstall Everything"
        Me.bUninstall.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbInstallAll)
        Me.GroupBox1.Controls.Add(Me.rbInstallThumbnails)
        Me.GroupBox1.Controls.Add(Me.rbInstallContextMenu)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.bInstall)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(461, 187)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Installation options"
        '
        'rbInstallAll
        '
        Me.rbInstallAll.AutoSize = True
        Me.rbInstallAll.Checked = True
        Me.rbInstallAll.Location = New System.Drawing.Point(6, 22)
        Me.rbInstallAll.Name = "rbInstallAll"
        Me.rbInstallAll.Size = New System.Drawing.Size(118, 19)
        Me.rbInstallAll.TabIndex = 4
        Me.rbInstallAll.TabStop = True
        Me.rbInstallAll.Text = "Install everything."
        Me.rbInstallAll.UseVisualStyleBackColor = True
        '
        'rbInstallThumbnails
        '
        Me.rbInstallThumbnails.AutoSize = True
        Me.rbInstallThumbnails.Location = New System.Drawing.Point(6, 72)
        Me.rbInstallThumbnails.Name = "rbInstallThumbnails"
        Me.rbInstallThumbnails.Size = New System.Drawing.Size(175, 19)
        Me.rbInstallThumbnails.TabIndex = 3
        Me.rbInstallThumbnails.Text = "Install only DDS Thumbnails."
        Me.rbInstallThumbnails.UseVisualStyleBackColor = True
        '
        'rbInstallContextMenu
        '
        Me.rbInstallContextMenu.AutoSize = True
        Me.rbInstallContextMenu.Location = New System.Drawing.Point(6, 47)
        Me.rbInstallContextMenu.Name = "rbInstallContextMenu"
        Me.rbInstallContextMenu.Size = New System.Drawing.Size(280, 19)
        Me.rbInstallContextMenu.TabIndex = 2
        Me.rbInstallContextMenu.Text = "Install only Context Menu for DDS and Png Files."
        Me.rbInstallContextMenu.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(449, 84)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "The installation process will ask for Administrator privileges." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This will happen" &
    ":" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Copy dlls to xMadHack folder in Program Files." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Register the dlls." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Add" &
    " entries to the Windows Registry."
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.bUninstall)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 252)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(461, 164)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Uninstallation"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(6, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(449, 84)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = resources.GetString("Label2.Text")
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label3.ForeColor = System.Drawing.Color.Crimson
        Me.Label3.Location = New System.Drawing.Point(12, 202)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(449, 34)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "IMPORTANT: To remove the shell extensions, run this installer and click the Unins" &
    "tall Everything button."
        '
        'InstallerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(485, 429)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "InstallerForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Xmh Shell Extensions Installer"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents bInstall As Button
    Friend WithEvents bUninstall As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbInstallAll As RadioButton
    Friend WithEvents rbInstallThumbnails As RadioButton
    Friend WithEvents rbInstallContextMenu As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
