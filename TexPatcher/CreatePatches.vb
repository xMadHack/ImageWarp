Public Class CreatePatches

    Private Function CheckFileAvailable(s As String) As Boolean
        If String.IsNullOrWhiteSpace(s) Then
            Return False
        End If
        Return IO.File.Exists(s)
    End Function

    Private Sub bCreatePatches_Click(sender As Object, e As EventArgs) Handles bCreatePatches.Click
        If Not CheckFileAvailable(imfSource.ImageFile) Then
            MessageBox.Show("Please select a source image")
            Return
        End If
        If Not CheckFileAvailable(imfMask.ImageFile) Then
            MessageBox.Show("Please select a mask image")
            Return
        End If
        If String.IsNullOrWhiteSpace(imfPatch.ImageFile) Then
            MessageBox.Show("Please enter an output filename")
            Return
        End If

        Me.UseWaitCursor = True

        Try
            WarpLib.PatchTex.CreatePatch(imfSource.ImageFile, imfMask.ImageFile, imfPatch.ImageFile)
            imfPatch.RefreshPreview()
        Finally
            Me.UseWaitCursor = False
            MessageBox.Show("Finished")
        End Try
    End Sub
End Class
