Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Public Class MainAppForm

    Private WarpMap As Bitmap
    Private SourceImage As Bitmap
    Private OutputImage As Bitmap

    Private Sub buttonOutput_Click(sender As Object, e As EventArgs) Handles buttonOutput.Click
        Dim sfd = New SaveFileDialog
        sfd.Filter = "PNG Image Files | *.png"
        sfd.OverwritePrompt = False
        sfd.FileName = tbOutputFilename.Text
        If sfd.ShowDialog() = DialogResult.OK Then
            tbOutputFilename.Text = sfd.FileName
            If IO.File.Exists(tbOutputFilename.Text) Then
                Try
                    OutputImage = WarpLib.WarpBitmap.LoadBitmap(sfd.FileName)
                    pbOutputImage.Image = OutputImage
                Catch ex As Exception

                End Try
            End If
        End If
    End Sub

    Private Sub buttonWarpMap_Click(sender As Object, e As EventArgs) Handles buttonWarpMap.Click
        Dim ofd = New OpenFileDialog
        ofd.FileName = tbWarpMapFilename.Text
        ofd.Filter = "PNG Image Files | *.png"
        If ofd.ShowDialog() = DialogResult.OK Then
            WarpMap = WarpLib.WarpBitmap.LoadBitmap(ofd.FileName)
            pbWarpMap.Image = WarpMap
            tbWarpMapFilename.Text = ofd.FileName
        End If
    End Sub

    Private Sub buttonSourceImage_Click(sender As Object, e As EventArgs) Handles buttonSourceImage.Click
        Dim ofd = New OpenFileDialog
        If ofd.ShowDialog() = DialogResult.OK Then

            SourceImage = WarpLib.WarpBitmap.LoadBitmap(ofd.FileName)  'New Bitmap(ofd.FileName)
            pbSourceImage.Image = SourceImage
            tbSourceImageFilename.Text = ofd.FileName
        End If
    End Sub

    Private Sub buttonDoIt_Click(sender As Object, e As EventArgs) Handles buttonDoIt.Click
        DoWarpping()
    End Sub

    Private ReadOnly Property OutputFileName As String
        Get
            Return tbOutputFilename.Text
        End Get
    End Property

    Private ReadOnly Property SourceImageFilename As String
        Get
            Return tbSourceImageFilename.Text
        End Get
    End Property

    Private ReadOnly Property WarpMapFilename As String
        Get
            Return tbWarpMapFilename.Text
        End Get
    End Property

    Private Sub SetUIEnabled(ByVal enabled As Boolean)
        Panel1.Enabled = enabled
        Panel2.Enabled = enabled
        Panel3.Enabled = enabled
        Panel4.Enabled = enabled
    End Sub

    Private Sub LogInConsole(text As String)
        SafelyDo(Sub()
                     tbConsole.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} {text + System.Environment.NewLine}")
                     tbConsole.ScrollToCaret()
                 End Sub)
    End Sub
    Private Sub DoInParallel(action As Action, finalAction As Action)
        Dim thread As New Threading.Thread(
            Sub()
                Try
                    action()
                Finally
                    SafelyDo(finalAction)
                End Try
            End Sub)
        thread.Start()
    End Sub

    Private Sub SafelyDo(action As Action)
        If Me.InvokeRequired Then
            Me.Invoke(action)
        Else
            action()
        End If
    End Sub

    Private Sub DoWarpping()
        If Not FilenameIsOK(SourceImageFilename) Then Throw New Exception("Please set a valid Source Image filename")
        If Not FilenameIsOK(WarpMapFilename) Then Throw New Exception("Please set a valid WarpMap filename")
        If Not FilenameIsOK(OutputFileName) Then Throw New Exception("Please set a valid Output filename")
        SetUIEnabled(False)
        Me.UseWaitCursor = True
        Dim startingTime = DateTime.Now
        DoInParallel(
            Sub()
                Dim previewBitmap = WarpLib.WarpBitmap.GetWarppedBitmap(SourceImageFilename, WarpMapFilename, OutputFileName, RepairSeams)
                SafelyDo(
                    Sub()
                        OutputImage = previewBitmap
                        pbOutputImage.Image = previewBitmap
                    End Sub)
            End Sub,
            Sub()
                SetUIEnabled(True)
                Me.UseWaitCursor = False
                LogInConsole($"Process finished in: {(DateTime.Now - startingTime).TotalSeconds.ToString("F2")}")
            End Sub)
    End Sub

    Public Shared Function FilenameIsOK(ByVal fileName As String) As Boolean
        If String.IsNullOrWhiteSpace(fileName) Then Return False
        Dim file As String = IO.Path.GetFileName(fileName)
        Dim directory As String = IO.Path.GetDirectoryName(fileName)

        Return Not (file.Intersect(IO.Path.GetInvalidFileNameChars()).Any() _
                OrElse
                directory.Intersect(IO.Path.GetInvalidPathChars()).Any())
    End Function

    Private Sub ShowSaveAsDialogForIdentityWarpMapGeneration(size As Integer)
        Dim sfd = New SaveFileDialog()
        sfd.FileName = $"IdentityWarpMap{size}x{size}.png"
        sfd.Filter = "PNG Image Format|*.png"
        If sfd.ShowDialog() <> DialogResult.OK Then Return
        WarpLib.WarpBitmap.GenerateIdentityGradient(size, sfd.FileName)
        LogInConsole($"IdentiyMap saved to: {sfd.FileName}")
    End Sub
    Private SaveOutputAsFilename As String = "Output.png"

    Private ReadOnly Property RepairSeams As Boolean
        Get
            Return chkRepairSeams.Checked
        End Get
    End Property

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        If OutputImage Is Nothing Then Return
        Dim sfd = New SaveFileDialog()
        sfd.FileName = SaveOutputAsFilename
        sfd.Filter = "PNG Image Format|*.png"
        If sfd.ShowDialog() <> DialogResult.OK Then Return
        SaveOutputAsFilename = sfd.FileName
    End Sub

    Private Sub WarpImageGenerationToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles X512ToolStripMenuItem.Click, X1024ToolStripMenuItem.Click, X2048ToolStripMenuItem.Click,
                X4096ToolStripMenuItem.Click, X8912ToolStripMenuItem.Click
        ShowSaveAsDialogForIdentityWarpMapGeneration(Integer.Parse(sender.tag))
    End Sub

    Private Sub BrowseTemporalImagesFolderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BrowseTemporalImagesFolderToolStripMenuItem.Click
        Dim folder = IO.Path.GetFullPath(WarpLib.WarpBitmap.ProcessingPipelineDebugFolder)
        If Not IO.Directory.Exists(folder) Then
            MessageBox.Show("The directory does not exists. Please, process an image and try again.")
            Return
        End If
        Process.Start("explorer", folder)
    End Sub

    Private Sub ProjectsWebsiteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProjectsWebsiteToolStripMenuItem.Click
        Process.Start("explorer", "http://google.com")
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        If OutputImage IsNot Nothing Then
            If IO.File.Exists(OutputFileName) Then
                Process.Start("explorer", IO.Path.GetFullPath(OutputFileName))
            End If
        End If

    End Sub

    Private Sub OpenImageDebugFolderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenImageOutputFolderToolStripMenuItem.Click
        Dim outfile = OutputFileName
        If String.IsNullOrWhiteSpace(outfile) Then outfile = "."
        Dim folder = IO.Path.GetDirectoryName(IO.Path.GetFullPath(outfile))
        If Not IO.Directory.Exists(folder) Then
            MessageBox.Show("The directory does not exists. Please, process an image and try again.")
            Return
        End If
        Process.Start("explorer", folder)
    End Sub

    Private Sub MainAppForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        WarpLib.WarpBitmap.WriteToLogHandler = Sub(s As String) Me.LogInConsole(s)
    End Sub
End Class
