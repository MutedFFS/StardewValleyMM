Imports System.ComponentModel
Imports System.Net

Public Class Webrowser
    Private Sub Load() Handles Me.Shown
        WebBrowser1.Navigate("http://www.nexusmods.com/stardewvalley/mods/searchresults/?src_cat=1")
    End Sub

    Private Sub webBrowser1_Navigating(sender As Object, e As WebBrowserNavigatingEventArgs)
        If e.Url.Segments(e.Url.Segments.Length - 1).EndsWith(".zip" Or ".7z") Then
            e.Cancel = True
            Dim filepath As String = "C:\\"
            Dim client As New WebClient()
            client.DownloadFileAsync(e.Url, filepath)
        End If
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted

    End Sub
End Class