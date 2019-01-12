Public Class Main
    Dim PicID As Integer = 0
    Public Function GetWidthHeight() As Size
        Dim Pic As Image = Image.FromFile(Application.StartupPath + "\crazy.gif")
        GetWidthHeight.Width = Pic.Width
        GetWidthHeight.Height = Pic.Height
        Return GetWidthHeight
    End Function
    Sub AddPic(ByVal x As Integer, ByVal y As Integer)
        Dim NewPic As New PictureBox
        PicID += 1
        With NewPic
            .Location = New Point(x, y)
            .Size = GetWidthHeight()
            .Name = "Pic" + CStr(PicID)
            .Image = Image.FromFile(Application.StartupPath + "\crazy.gif")
        End With
        Me.Controls.Add(NewPic)
    End Sub
    Sub DelAllPic()
        While PicID > 0
            Me.Controls.RemoveByKey("Pic" + CStr(PicID))
            PicID -= 1
        End While
    End Sub
    Sub RefreshFormPic()
        DelAllPic()
        For x = 0 To Me.Width Step GetWidthHeight().Width
            For y = 0 To Me.Height Step GetWidthHeight.Height
                AddPic(x, y)
            Next
        Next
    End Sub
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshFormPic()
    End Sub

    Private Sub Main_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        RefreshFormPic()
    End Sub
End Class
