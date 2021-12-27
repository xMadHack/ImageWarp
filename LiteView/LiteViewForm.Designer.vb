<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LiteViewForm
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
        Me.ImgView1 = New LiteView.ImgView()
        Me.SuspendLayout()
        '
        'ImgView1
        '
        Me.ImgView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImgView1.Location = New System.Drawing.Point(0, 28)
        Me.ImgView1.Name = "ImgView1"
        Me.ImgView1.Size = New System.Drawing.Size(1700, 1182)
        Me.ImgView1.TabIndex = 2
        '
        'LiteViewForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 30.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1700, 1249)
        Me.Controls.Add(Me.ImgView1)
        Me.DoubleBuffered = True
        Me.Name = "LiteViewForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LiteView"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImgView1 As ImgView
End Class
