Public Class ImageFileControl

    Public Property ImageFile As String
        Get
            Return TextBox1.Text
        End Get
        Set(value As String)
            TextBox1.Text = value
            CaretToEnd()
            RefreshPreview()
        End Set
    End Property

    Public Property ImageFileLabel As String
        Get
            Return Label1.Text
        End Get
        Set(value As String)
            Label1.Text = value
        End Set
    End Property

    Private IsOutputImage As Boolean = False

    Public Property IsOutput As Boolean
        Get
            Return IsOutputImage
        End Get
        Set(value As Boolean)
            IsOutputImage = value
        End Set
    End Property

    Public Sub RefreshPreview()
        Dim file = ImageFile
        PictureBox1.Image = Nothing
        Try
            If String.IsNullOrWhiteSpace(file) Then Return
            If Not IO.File.Exists(file) Then Return
            If file.EndsWith(".dds", StringComparison.CurrentCultureIgnoreCase) Then
                PictureBox1.Image = WarpLib.DdsTools.LoadDdsAsBitmap(file)
            Else
                PictureBox1.Image = WarpLib.WarpBitmap.LoadBitmap(file)

            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Property FileFilter As String = "PNG Files|*.png"

    Public Sub CaretToEnd()
        If String.IsNullOrEmpty(TextBox1.Text) Then Return
        TextBox1.SelectionStart = TextBox1.Text.Length - 1
        TextBox1.ScrollToCaret()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If IsOutputImage Then
            Dim sfd = New SaveFileDialog()
            sfd.Filter = FileFilter
            sfd.FileName = ImageFile
            sfd.OverwritePrompt = False
            If sfd.ShowDialog() = DialogResult.OK Then
                ImageFile = sfd.FileName
            End If
        Else
            Dim ofd = New OpenFileDialog()
            ofd.Filter = FileFilter
            ofd.FileName = ImageFile
            If ofd.ShowDialog() = DialogResult.OK Then
                ImageFile = ofd.FileName
                CaretToEnd()
            End If
        End If

    End Sub

    Private Sub OpenImageFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenImageFileToolStripMenuItem.Click
        Dim file = ImageFile
        Try
            If String.IsNullOrWhiteSpace(file) Then Return
            If Not IO.File.Exists(file) Then Return
            Process.Start("explorer", file)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BrowseImageFolderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BrowseImageFolderToolStripMenuItem.Click
        Dim file = ImageFile
        Try
            If String.IsNullOrWhiteSpace(file) Then Return
            Dim folder = IO.Path.GetDirectoryName(file)
            If Not IO.Directory.Exists(folder) Then Return
            Process.Start("explorer", folder)
        Catch ex As Exception

        End Try
    End Sub
End Class
