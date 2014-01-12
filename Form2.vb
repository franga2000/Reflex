Imports System.IO
Public Class Form2
    Dim Report As ArrayList = New ArrayList
    Dim ButtonPressed As Boolean
    Dim Time As Integer = 0
    Dim Times As Integer = 0
    Dim Light As Boolean = False
    Dim Round As Integer
    Dim Running As Boolean

    Public Function GetRandomNum(fromNum As Integer, toNum As Integer)
        Dim myRandom As New Random
        Dim RandomNumber As Integer = myRandom.Next(fromNum, toNum)
        Return RandomNumber
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Time = Time + 1
        Label1.Text = Time
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Running = True
        PictureBox1.Image = My.Resources.circle_1
        Light = True
        Timer1.Start()
        Do Until ButtonPressed
            Application.DoEvents()
        Loop
        Timer1.Stop()
        Light = False
        Report.Add(Time)
        Time = 0
        Label1.Text() = Time
        PictureBox1.Image = My.Resources.circle_grey
        ButtonPressed = False
        Timer2.Interval = GetRandomNum(500, 2000)
        Timer2.Start()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Running Then
            If Light Then
                ButtonPressed = True
            End If
        Else
            Button1.PerformClick()
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Timer2.Stop()
        If Times < 5 Then
            Times = Times + 1
            Button1.PerformClick()
        Else
            Round = Round + 1
            My.Computer.FileSystem.WriteAllText("./Data/Round.txt", Round, False)
            Dim theWriter As New StreamWriter("./Data/" & Round & ".txt")
            For Each currentElement As String In Report
                theWriter.WriteLine(currentElement) 
            Next
            theWriter.Close()
            Times = 0
            Report.Clear()
            MsgBox("Finished!", , "Reflex")
        End If

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If File.Exists("./Data/Round.txt") Then
            If Not (My.Computer.FileSystem.ReadAllText("./Data/Round.txt") = "") Then
                Round = My.Computer.FileSystem.ReadAllText("./Data/Round.txt")
            Else
                Round = 1
                My.Computer.FileSystem.WriteAllText("./Data/Round.txt", Round, False)
            End If
        Else
            If My.Computer.FileSystem.DirectoryExists("./Data") Then
                My.Computer.FileSystem.WriteAllText("./Data/Round.txt", Round, False)
            Else
                My.Computer.FileSystem.CreateDirectory("./Data")
                My.Computer.FileSystem.WriteAllText("./Data/Round.txt", Round, False)


            End If
        End If
    End Sub
End Class