Option Explicit On
Imports System.ComponentModel
Imports System.Net
Imports System.IO
Imports System.IO.Compression
Imports System.Text
Imports System.Web
Imports WinHttp
Imports Awesomium.Core
Imports Awesomium.Windows.Forms



Public Class Form1

    Dim spath = ""
    Dim xnb As Boolean = False
    Dim dll As Boolean = False
    Dim x = ""
    Dim y = ""


    Private Sub Browser_Startup() Handles Me.Load

        browser.Source = New Uri(My.Settings.Homepage)
        AddHandler Awesomium.Core.WebCore.Download, AddressOf DownloadMethod
    End Sub

    Function browser_clsoe() Handles Me.Closing
        If xnb = True And dll = False Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub DownloadMethod(ByVal sender As Object, ByVal e As Awesomium.Core.DownloadEventArgs)
        e.Handled = True
        Using client = New WebClient()
            If e.Url.ToString.Contains(".zip") Then
                client.DownloadFile(e.Url.ToString, MainForm.appPath & "\Mod.zip")
                spath = MainForm.appPath & "\Mod.zip"
            Else
                client.DownloadFile(e.Url.ToString, MainForm.appPath & "\Mod.rar")
                spath = MainForm.appPath & "\Mod.zip"
            End If
        End Using
        MainForm.zip(spath, MainForm.appPath & "\unpacked\", 1, False)
        For Each s In Directory.GetFiles(MainForm.appPath & "\unpacked\", "*.*", SearchOption.AllDirectories)
            x = Path.GetDirectoryName(s)
            y = MainForm.shPath(x)

            If Path.GetExtension(s) = ".xnb" Then
                xnb = True
            Else
                dll = True
            End If
        Next
        If xnb = True And dll = False Then
            MainForm.xbo = True
            For Each s In Directory.GetFiles(MainForm.appPath & "\unpacked\", "*.xnb", SearchOption.AllDirectories)
                My.Computer.FileSystem.MoveDirectory(x & "\", MainForm.appPath & "\XNB\", True)
            Next
        Else
            MsgBox(MainForm.ddir & y & "\")
            If (Not IO.Directory.Exists(MainForm.Modfolder & "\" & y & "\")) Then
                IO.Directory.CreateDirectory(MainForm.Modfolder & "\" & y & "\")
            End If
            My.Computer.FileSystem.MoveDirectory(x & "\", MainForm.Modfolder & "\" & y & "\", True)
        End If
    End Sub



    Private Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click
        browser.GoBack()
    End Sub

    Private Sub Forward_Click(sender As Object, e As EventArgs) Handles Forward.Click
        browser.GoForward()
    End Sub

    Private Sub Home_Click(sender As Object, e As EventArgs) Handles Home.Click
        browser.Source = New Uri("http://www.nexusmods.com/stardewvalley/?")
    End Sub

    Private Sub Close_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        MainForm.count = 1
        browser.Dispose()
        Close()
    End Sub

    Private Sub dend() Handles Me.Closed
        MainForm.count = 1
    End Sub
End Class