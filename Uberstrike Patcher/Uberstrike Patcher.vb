Public Class Form1
    Private IsFormBeingDragged As Boolean = False
    Private MouseDownX As Integer
    Private MouseDownY As Integer
    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseDown

        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = True
            MouseDownX = e.X
            MouseDownY = e.Y
        End If
    End Sub

    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseUp

        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = False
        End If
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseMove

        If IsFormBeingDragged Then
            Dim temp As Point = New Point()

            temp.X = Me.Location.X + (e.X - MouseDownX)
            temp.Y = Me.Location.Y + (e.Y - MouseDownY)
            Me.Location = temp
            temp = Nothing
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If My.Computer.FileSystem.FileExists("C:\Program Files (x86)\Steam\steamapps\common\UberStrike\UberStrike_Data\Managed\Assembly-CSharp.dll") AndAlso
           My.Computer.FileSystem.FileExists("C:\Program Files (x86)\Steam\steamapps\common\UberStrike\UberStrike_Data\Managed\UnityEngine.dll") AndAlso
           My.Computer.FileSystem.FileExists("C:\Program Files (x86)\Steam\steamapps\common\UberStrike\UberStrike_Data\Managed\Assembly-CSharp-firstpass.dll") Then
            IO.File.Delete("C:\Program Files (x86)\Steam\steamapps\common\UberStrike\UberStrike_Data\Managed\Assembly-CSharp.dll")
            IO.File.Delete("C:\Program Files (x86)\Steam\steamapps\common\UberStrike\UberStrike_Data\Managed\UnityEngine.dll")
            IO.File.Delete("C:\Program Files (x86)\Steam\steamapps\common\UberStrike\UberStrike_Data\Managed\Assembly-CSharp-firstpass.dll")
            IO.File.WriteAllBytes("C:\Program Files (x86)\Steam\steamapps\common\UberStrike\UberStrike_Data\Managed\UnityEngine.dll", My.Resources.UnityEngine)
            IO.File.WriteAllBytes("C:\Program Files (x86)\Steam\steamapps\common\UberStrike\UberStrike_Data\Managed\Assembly-CSharp.dll", My.Resources.Assembly_CSharp)
            IO.File.WriteAllBytes("C:\Program Files (x86)\Steam\steamapps\common\UberStrike\UberStrike_Data\Managed\Assembly-CSharp-firstpass.dll", My.Resources.Assembly_CSharp_firstpass)
            MsgBox("All files have been patched successfully!", MsgBoxStyle.Information, "Patcher")
        Else
            MsgBox("DLLs not found. Make sure your Uberstrike is in the default location (C:\Program Files (x86)\Steam\steamapps\common\UberStrike\)", MsgBoxStyle.Critical, "Patcher")
        End If

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        IO.File.WriteAllBytes("C:\Program Files (x86)\Steam\steamapps\common\UberStrike\UberStrike_Data\.uberstrok", My.Resources.Anjum)
        MsgBox("Server has been set to 10032 Uberstrike!", MsgBoxStyle.Information, "Success")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        IO.File.WriteAllBytes("C:\Program Files (x86)\Steam\steamapps\common\UberStrike\UberStrike_Data\.uberstrok", My.Resources.Patrik)
        MsgBox("Server has been set to UberKill!", MsgBoxStyle.Information, "Success")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim FILE_NAME As String = "C:\Program Files (x86)\Steam\steamapps\common\UberStrike\UberStrike_Data\.uberstrok"

        If System.IO.File.Exists(FILE_NAME) = True Then

            Dim objWriter As New System.IO.StreamWriter(FILE_NAME)

            objWriter.Write(TextBox1.Text)
            objWriter.Close()
            MsgBox("Custom hostname has been set.", MsgBoxStyle.Information, "Success")

        Else

            MessageBox.Show("Hostname file does not exist! Patch with one of the servers first.")

        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("http://www.facebook.com/10032gaming/")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Application.Exit()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.Audio.Play(My.Resources.Ricardo, AudioPlayMode.BackgroundLoop)
        Dim ping As New System.Net.NetworkInformation.Ping
        Dim ms1 = ping.Send("10032ubz.servehttp.com").RoundtripTime()

        Label6.Text = (ms1)


        Dim ping2 As New System.Net.NetworkInformation.Ping
        Dim ms2 = ping.Send("andr1.clashofmagic.net").RoundtripTime()

        Label9.Text = (ms2)
    End Sub
End Class
