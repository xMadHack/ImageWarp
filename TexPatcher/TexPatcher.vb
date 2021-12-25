Public Class TexPatcher

    Private Function CheckFileAvailable(s As String) As Boolean
        If String.IsNullOrWhiteSpace(s) Then
            Return False
        End If
        Return IO.File.Exists(s)
    End Function
    Private Sub bApplyPatches_Click(sender As Object, e As EventArgs) Handles bApplyPatches.Click
        If Not CheckFileAvailable(imfSource.ImageFile) Then
            MessageBox.Show("Please select a source image")
            Return
        End If
        If Not CheckFileAvailable(imfPatch.ImageFile) Then
            MessageBox.Show("Please select a patch image")
            Return
        End If
        If String.IsNullOrWhiteSpace(imfPatched.ImageFile) Then
            MessageBox.Show("Please enter an output filename")
            Return
        End If
        Me.UseWaitCursor = True
        Try
            WarpLib.PatchTex.ApplyPatch(imfSource.ImageFile, imfPatch.ImageFile, imfPatched.ImageFile, chkCompressDds.Checked)
            imfPatched.RefreshPreview()
        Finally
            Me.UseWaitCursor = False
        End Try

        If chkCloseWhenFinished.Checked Then
            Me.Close()
        Else
            MessageBox.Show("Finished")
        End If
    End Sub

    Private Function quote(s As String) As String
        Return ControlChars.Quote + s + ControlChars.Quote
    End Function

    Private Sub ImagePatcher_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim args = My.Application.CommandLineArgs
        If args.Count = 1 Then
            Dim inFile = args(0)
            If inFile.EndsWith(".png", StringComparison.CurrentCultureIgnoreCase) Then
                Dim outfile = IO.Path.GetDirectoryName(inFile)
                outfile = IO.Path.Combine(outfile, IO.Path.GetFileNameWithoutExtension(inFile) + ".dds")
                imfPatched.ImageFile = outfile
            Else
                imfPatched.ImageFile = inFile
            End If
            imfSource.ImageFile = inFile
        End If
        Dim patchesDir = IO.Path.GetFullPath("Patches")
        cbPatches.Items.Add("None")
        cbPatches.SelectedItem = "None"
        If IO.Directory.Exists(patchesDir) Then
            Dim patchesFiles = IO.Directory.GetFiles(patchesDir)
            For Each f As String In patchesFiles
                cbPatches.Items.Add(IO.Path.GetFileName(f))
            Next
        End If
    End Sub

    Private Sub cbPatches_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPatches.SelectedIndexChanged
        If cbPatches.SelectedItem <> "None" Then
            imfPatch.ImageFile = IO.Path.Combine(IO.Path.GetFullPath("Patches"), cbPatches.SelectedItem)
        End If
    End Sub

    Private Sub OpenCreatePatchToolToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenCreatePatchToolToolStripMenuItem.Click
        Dim f = New CreatePatches()
        f.Show()
    End Sub

    Private Sub PatreonToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PatreonToolStripMenuItem.Click
        Process.Start("explorer", "https://www.patreon.com/xMadHack")
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub ContributeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContributeToolStripMenuItem.Click
        Process.Start("explorer", "https://github.com/xMadHack")
    End Sub

    Private Sub PaypalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PaypalToolStripMenuItem.Click
        Process.Start("explorer", "https://paypal.me/xMadHack")
    End Sub

    Private Sub AboutXMadHackToolsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutXMadHackToolsToolStripMenuItem.Click
        Dim about = New AboutXMadHack()
        about.ShowDialog(Me)
    End Sub

    Private Sub AboutImagePatcherToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutImagePatcherToolStripMenuItem.Click
        Dim about = New AboutTexPatcher()
        about.ShowDialog(Me)
    End Sub
End Class