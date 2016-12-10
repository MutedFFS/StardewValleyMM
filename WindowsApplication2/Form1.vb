Imports System.IO
Imports System.Net
Imports System.Threading

Public Class Form1
    Public Shared appPath As String = Application.StartupPath()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (Interaction.Command = "") Then
            Dim startInfo As New ProcessStartInfo With {
            .FileName = (Form1.appPath & "\SDVMM.exe"),
            .UseShellExecute = True,
            .WindowStyle = ProcessWindowStyle.Normal
        }
            Process.Start(startInfo)
            Application.Exit()
        End If
        Thread.Sleep(&H1388)
        Dim address As String = Interaction.Command
        Me.Launch.Enabled = False
        If File.Exists("SDVMM.exe") Then
            File.Delete("SDVMM.exe")
        End If
        Dim fileName As String = (Form1.appPath & "\SDVMM.exe")
        Try
            Dim client1 As New WebClient
            client1.Headers.Item("User-Agent") = "Mozilla/4.0"
            client1.DownloadFile(address, fileName)
        Catch exception1 As Exception
        End Try
        Thread.Sleep(&H1388)
        Me.Launch.Enabled = True
        Interaction.MsgBox("Update Succsesfull, please Press Launch", MsgBoxStyle.ApplicationModal, Nothing)
    End Sub

    Private Sub Launch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Launch.Click
        Dim startInfo As New ProcessStartInfo With {
        .FileName = (Form1.appPath & "\SDVMM.exe"),
        .UseShellExecute = True,
        .WindowStyle = ProcessWindowStyle.Normal
    }
        Process.Start(startInfo)
        Application.Exit()
    End Sub

    Private Sub cancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cancel.Click
        Application.Exit()
    End Sub

End Class
