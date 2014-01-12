Public Class Form1
    Dim times As Integer = 5
    Dim imageNum As Integer
    Dim ButtonPressed As Boolean
    Dim Images As Dictionary(Of Integer, Bitmap) = New Dictionary(Of Integer, Bitmap)
    Public Function GetRandomNum(fromNum As Integer, toNum As Integer)
        Dim myRandom As New Random
        Dim RandomNumber As Integer = myRandom.Next(fromNum, toNum)
        Return RandomNumber
    End Function
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Images.Add(1, My.Resources.circle_1)
        Images.Add(2, My.Resources.Circle_2)
        Images.Add(3, My.Resources.Circle_3)
    End Sub
    Private Sub Iterate()
        Threading.Thread.Sleep(GetRandomNum(500, 2000))
        PictureBox1.Image = Images(GetRandomNum(1, 4))
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Iterate()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form2.Show()
        Me.Close()
    End Sub
End Class
