<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AboutXMadHack
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.llPatreon = New System.Windows.Forms.LinkLabel()
        Me.llGithub = New System.Windows.Forms.LinkLabel()
        Me.llPaypal = New System.Windows.Forms.LinkLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 18)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(433, 30)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "xMadHack is creating CG and Modding Tools."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 82)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(413, 30)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Find the latest news and support the effort:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(456, 298)
        Me.Button1.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(129, 46)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "OK"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'llPatreon
        '
        Me.llPatreon.AutoSize = True
        Me.llPatreon.Location = New System.Drawing.Point(21, 182)
        Me.llPatreon.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.llPatreon.Name = "llPatreon"
        Me.llPatreon.Size = New System.Drawing.Size(354, 30)
        Me.llPatreon.TabIndex = 3
        Me.llPatreon.TabStop = True
        Me.llPatreon.Text = "https://www.patreon.com/xMadHack"
        '
        'llGithub
        '
        Me.llGithub.AutoSize = True
        Me.llGithub.Location = New System.Drawing.Point(21, 144)
        Me.llGithub.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.llGithub.Name = "llGithub"
        Me.llGithub.Size = New System.Drawing.Size(407, 30)
        Me.llGithub.TabIndex = 4
        Me.llGithub.TabStop = True
        Me.llGithub.Text = "https://github.com/xMadHack/ImageWarp"
        '
        'llPaypal
        '
        Me.llPaypal.AutoSize = True
        Me.llPaypal.Location = New System.Drawing.Point(21, 220)
        Me.llPaypal.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.llPaypal.Name = "llPaypal"
        Me.llPaypal.Size = New System.Drawing.Size(282, 30)
        Me.llPaypal.TabIndex = 5
        Me.llPaypal.TabStop = True
        Me.llPaypal.Text = "https://paypal.me/xMadHack"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 306)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(310, 30)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Contact: xMadHack@gmail.com"
        '
        'AboutXMadHack
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 30.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(609, 368)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.llPaypal)
        Me.Controls.Add(Me.llGithub)
        Me.Controls.Add(Me.llPatreon)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Name = "AboutXMadHack"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "About xMadHack"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents llPatreon As LinkLabel
    Friend WithEvents llGithub As LinkLabel
    Friend WithEvents llPaypal As LinkLabel
    Friend WithEvents Label3 As Label
End Class
