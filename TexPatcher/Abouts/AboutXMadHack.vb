Public Class AboutXMadHack
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub llGithub_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llGithub.LinkClicked
        Process.Start("explorer", "https://github.com/xMadHack")
    End Sub

    Private Sub llPatreon_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llPatreon.LinkClicked
        Process.Start("explorer", "https://www.patreon.com/xMadHack")
    End Sub

    Private Sub llPaypal_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llPaypal.LinkClicked
        Process.Start("explorer", "https://paypal.me/xMadHack")
    End Sub
End Class