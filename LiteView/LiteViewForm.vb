Public Class LiteViewForm
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private ImgFilename As String = ""
    Private Sub LiteViewForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If My.Application.CommandLineArgs.Count = 0 Then
            Dim ofd = New OpenFileDialog()
            If ofd.ShowDialog() = DialogResult.OK Then
                ImgView1.LoadImage(ofd.FileName)
                ImgFilename = ofd.FileName
            Else
                Close()
            End If
        Else
            Dim filename = My.Application.CommandLineArgs(0)
            ImgFilename = filename
            If filename.ToLower().EndsWith(".dds") Then
                ImgView1.LoadImage(WarpLib.DdsTools.LoadDdsAsBitmap(filename), filename)
            Else
                Try
                    ImgView1.LoadImage(filename)
                Catch ex As Exception
                    MessageBox.Show("Unsupported Image File " + filename)
                    Close()
                End Try
            End If
        End If

        UpdateTitle()
    End Sub

    Private Sub UpdateTitle()
        If String.IsNullOrWhiteSpace(ImgFilename) OrElse ImgView1.DisplayedImage Is Nothing Then
            Return
        End If
        Me.Text = $"[XMH] LiteView >  {ImgFilename} > {ImgView1.DisplayedImage.Width}x{ImgView1.DisplayedImage.Height}"
    End Sub
End Class
