Public Class ImgView
    Dim IsMouseDown As Boolean = False
    Dim ImageCenter As New PointF(0F, 0F)
    Dim ZoomFactor As Double = 1.0

    Dim MipMap As Bitmap = Nothing
    Dim MipMap2 As Bitmap = Nothing

    Dim Filename As String = ""

    Private ReadOnly Property ImageOrigin As PointF
        Get
            If ViewedImage IsNot Nothing Then

                Dim ic = ImageCenter
                Dim s = ImageZoomedSize
                Return New PointF(ic.X - s.Width / 2.0, ic.Y - s.Height / 2.0)
            Else
                Return ImageCenter
            End If
        End Get
    End Property

    Private ReadOnly Property ImageZoomedSize As SizeF
        Get
            If ViewedImage IsNot Nothing Then
                Return New SizeF(ViewedImage.Width * ZoomFactor, ViewedImage.Height * ZoomFactor)
            Else
                Return New SizeF(1, 1)
            End If
        End Get
    End Property

    Private ReadOnly Property CenterOfView As PointF
        Get
            Dim cs = Me.ClientSize
            Return New PointF(cs.Width / 2.0, cs.Height / 2.0)
        End Get
    End Property
    Private Sub pView_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If e.Button <> MouseButtons.Left Then Return
        IsMouseDown = True
        MouseOldPos = e.Location
    End Sub

    Private Sub pView_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        If e.Button <> MouseButtons.Left Then Return
        IsMouseDown = False
    End Sub
    Private MouseOldPos As New Point()
    Private Sub pView_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        Dim newX = e.Location.X
        Dim newy = e.Location.Y
        Dim dx = newX - MouseOldPos.X
        Dim dy = newy - MouseOldPos.Y
        If IsMouseDown Then
            ImageCenter = New PointF(ImageCenter.X + dx, ImageCenter.Y + dy)
            TryInvalidate()
        End If
        MouseOldPos = e.Location
    End Sub

    Private ViewedImage As Bitmap = Nothing

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub LoadImage(file As String)
        LoadImage(New Bitmap(file), file)
    End Sub

    Public Sub LoadImage(bmp As Bitmap, displayedFilename As String)
        Filename = displayedFilename
        ViewedImage = bmp
        MipMap = New Bitmap(ViewedImage, New Size(ViewedImage.Width / 2, ViewedImage.Height / 2))
        MipMap2 = New Bitmap(ViewedImage, New Size(ViewedImage.Width / 4, ViewedImage.Height / 4))

        ResetImage()
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim g As Graphics = e.Graphics
        g.Clear(Me.BackColor)
            If ViewedImage Is Nothing Then Return

        'g.InterpolationMode = Drawing2D.InterpolationMode.Bilinear
        Dim o = ImageOrigin
        Dim s = ImageZoomedSize
        If ZoomFactor < 0.25 Then
            g.DrawImage(MipMap2, o.X, o.Y, s.Width, s.Height)
        ElseIf ZoomFactor < 0.5 Then
            g.DrawImage(MipMap, o.X, o.Y, s.Width, s.Height)
        Else
            g.DrawImage(ViewedImage, o.X, o.Y, s.Width, s.Height)
        End If
    End Sub
    Private Function GetFitZoomFactor() As Double
        If ViewedImage Is Nothing Then Return 1.0
        Dim viewAspect = CDbl(Me.ClientSize.Height) / CDbl(Me.ClientSize.Width)
        Dim imageAspect = CDbl(ViewedImage.Height) / CDbl(ViewedImage.Width)
        If viewAspect > imageAspect Then
            'fit by image width
            Return CDbl(Me.ClientSize.Width) / CDbl(ViewedImage.Width)
        Else
            'fit by image height
            Return CDbl(Me.ClientSize.Height) / CDbl(ViewedImage.Height)
        End If
    End Function
    Private Sub ResetImage()
        ZoomFactor = GetFitZoomFactor()
        ImageCenter = CenterOfView
        TryInvalidate()
    End Sub
    Private Sub ImgView_DoubleClick(sender As Object, e As EventArgs) Handles Me.DoubleClick
        If ZoomFactor > 0.99 AndAlso ZoomFactor < 1.01 Then
            ResetImage()
        Else
            ZoomFactor = 1.0
            ImageCenter = CenterOfView
            TryInvalidate()
        End If
    End Sub

    Public ReadOnly Property DisplayedImage As Image
        Get
            Return ViewedImage
        End Get
    End Property

    Private Sub ImgView_MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
        If e.Delta <> 0 Then

            Dim DX = e.Location.X - ImageCenter.X
            Dim DY = e.Location.Y - ImageCenter.Y
            Dim presize = ImageZoomedSize

            If e.Delta > 0 Then
                ZoomFactor *= (1.0 + (e.Delta * 0.001))
            Else
                ZoomFactor /= (1.0 + (-e.Delta * 0.001))
            End If
            ZoomFactor = Math.Min(20.0, Math.Max(0.1, ZoomFactor))

            Dim displacementRatio = (ImageZoomedSize.Width - presize.Width) / presize.Width
            ImageCenter = New PointF(ImageCenter.X - (DX * displacementRatio), ImageCenter.Y - (DY * displacementRatio))

            TryInvalidate()
        End If
    End Sub

    Private Sub TryInvalidate()
        QueueDraw = True
    End Sub

    Private AlreadyDrawn As Boolean = False
    Private QueueDraw As Boolean = True
    Private Sub FpsLock_Tick(sender As Object, e As EventArgs) Handles FpsLock.Tick
        AlreadyDrawn = False
        If QueueDraw Then Me.Invalidate()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        ParentForm.Close()
    End Sub

    Private Sub CopyToClipboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToClipboardToolStripMenuItem.Click
        Clipboard.SetImage(ViewedImage)
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        Dim sfd As New SaveFileDialog()
        sfd.Title = "Saving As PNG"
        sfd.Filter = "PNG Images| *.png"
        sfd.FileName = System.IO.Path.GetFileNameWithoutExtension(Filename) + ".png"
        If sfd.ShowDialog() = DialogResult.OK Then
            WarpLib.DdsTools.ConvertToPng(Filename, sfd.FileName)
        End If
    End Sub

    Private Sub SaveAsDdsUncompressedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsDdsUncompressedToolStripMenuItem.Click
        Dim sfd As New SaveFileDialog()
        sfd.Title = "Saving As Uncompressed DDS"
        sfd.Filter = "DDS Images| *.dds"
        sfd.FileName = System.IO.Path.GetFileNameWithoutExtension(Filename) + ".dds"
        If sfd.ShowDialog() = DialogResult.OK Then
            WarpLib.DdsTools.ConvertToDds(Filename, sfd.FileName, True, False)
        End If
    End Sub

    Private Sub SaveAsDdsBC7ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsDdsBC7ToolStripMenuItem.Click
        Dim sfd As New SaveFileDialog()
        sfd.Title = "Saving As Compressed (BC7) DDS"
        sfd.Filter = "DDS Images| *.dds"
        sfd.FileName = System.IO.Path.GetFileNameWithoutExtension(Filename) + ".dds"
        If sfd.ShowDialog() = DialogResult.OK Then
            WarpLib.DdsTools.ConvertToDds(Filename, sfd.FileName, True, True)
        End If
    End Sub
End Class
