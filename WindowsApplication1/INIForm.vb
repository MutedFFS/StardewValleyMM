Imports System.IO

Public Class INIForm
    Dim folder = INI_ReadValueFromFile("General", "GameFolder", "C:\", Application.UserAppDataPath & "\SDVMM.ini")
    Dim Sfolder = INI_ReadValueFromFile("General", "SteamFolder", "C:\", Application.UserAppDataPath & "\SDVMM.ini")
    Dim gog = INI_ReadValueFromFile("General", "Good Old Game Version", 0, Application.UserAppDataPath & "\SDVMM.ini")
    Dim Modfolder = INI_ReadValueFromFile("General", "ModFolder", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\StardewValley\Mods\", Application.UserAppDataPath & "\SDVMM.ini")
    Dim rchannel = INI_ReadValueFromFile("General", "Release Channel", "Stable", Application.UserAppDataPath & "\SDVMM.ini")

    Private Declare Ansi Function GetPrivateProfileString Lib "kernel32.dll" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Int32, ByVal lpFileName As String) As Int32

    Private Declare Ansi Function WritePrivateProfileString Lib "kernel32.dll" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Int32
    '
    '       Functions
    '
    Private Function INI_ReadValueFromFile(ByVal strSection As String, ByVal strKey As String, ByVal strDefault As String, ByVal strFile As String) As String
        'Reading Function 
        'strSection = Section of the INI-File
        'strKey = Name of the Key
        'strDefault = Standardvalue if ini cant be foung
        'strFile = full path to ini
        Dim strTemp As String = Space(1024), lLength As Integer
        lLength = GetPrivateProfileString(strSection, strKey, strDefault, strTemp, strTemp.Length, strFile)
        Return (strTemp.Substring(0, lLength))
    End Function

    Public Function INI_WriteValueToFile(ByVal strSection As String, ByVal strKey As String, ByVal strValue As String, ByVal strFile As String) As Boolean
        'Write function
        'strSection = Section of the INI-File
        'strKey = Name of Key
        'strValue = output Value
        'strFile = full path to INI
        Return (Not (WritePrivateProfileString(strSection, strKey, strValue, strFile) = 0))
    End Function

    Sub IniForm() Handles Me.Load
        If gog = 0 Then
            GogLabel.Text = False
            TextSFolder.Enabled = True
            cSfolder.Enabled = True
        Else
            GogLabel.Text = True
            TextSFolder.Enabled = False
            cSfolder.Enabled = False
        End If
        TextGfolder.Text = folder
        TextSFolder.Text = Sfolder
        channel.Text = rchannel
        If Modfolder = folder & "\Mods" Then
            mflabel.Text = "Stardew Valley Folder"
        Else
            mflabel.Text = "AppData"
        End If
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Close()
    End Sub


    Private Sub GogLabel_Click(sender As Object, e As EventArgs) Handles GogLabel.Click
        If gog = 1 Then
            GogLabel.Text = False
            gog = 0
            TextSFolder.Enabled = True
            cSfolder.Enabled = True
        Else
            GogLabel.Text = True
            gog = 1
            TextSFolder.Enabled = False
            cSfolder.Enabled = False
        End If
    End Sub

    Private Sub TextGfolder_TextChanged(sender As Object, e As EventArgs) Handles TextGfolder.TextChanged
        folder = TextGfolder.Text
    End Sub

    Private Sub TextSFolder_TextChanged(sender As Object, e As EventArgs) Handles TextSFolder.TextChanged
        Sfolder = TextSFolder.Text
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Save.Click
        INI_WriteValueToFile("General", "GameFolder", folder, Application.UserAppDataPath & "\SDVMM.ini")
        INI_WriteValueToFile("General", "SteamFolder", Sfolder, Application.UserAppDataPath & "\SDVMM.ini")
        INI_WriteValueToFile("General", "Good Old Game Version", gog, Application.UserAppDataPath & "\SDVMM.ini")
        INI_WriteValueToFile("General", "ModFolder", Modfolder, Application.UserAppDataPath & "\SDVMM.ini")
        INI_WriteValueToFile("General", "Release Channel", rchannel, Application.UserAppDataPath & "\SDVMM.ini")
        Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles cSfolder.Click
        Dim myStream As Stream = Nothing
        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.InitialDirectory = "c:\"
        openFileDialog1.Filter = "Steam.exe|Steam.exe"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.Title = "Select Steam Exe"
        openFileDialog1.RestoreDirectory = True
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                myStream = openFileDialog1.OpenFile()
                If myStream IsNot Nothing Then
                    Sfolder = Path.GetDirectoryName(openFileDialog1.FileName)
                    TextSFolder.Text = Sfolder
                End If
            Catch Ex As Exception
                MessageBox.Show("Cannot read file from disk! Please restart SDVMM and try again.")
            Finally
                ' Check this again, since we need to make sure we didn't throw an exception on open.
                If (myStream IsNot Nothing) Then
                    myStream.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles cGfolder.Click
        Dim myStream As Stream = Nothing
        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.InitialDirectory = "c:\"
        openFileDialog1.Filter = "Stardew Valley.exe|Stardew Valley.exe"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.Title = "Select Stardew Valley Exe"
        openFileDialog1.RestoreDirectory = True
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                myStream = openFileDialog1.OpenFile()
                If myStream IsNot Nothing Then
                    folder = Path.GetDirectoryName(openFileDialog1.FileName)
                    TextGfolder.Text = folder
                End If
            Catch Ex As Exception
                MessageBox.Show("Cannot read file from disk! Please restart SDVMM and try again.")
            Finally
                ' Check this again, since we need to make sure we didn't throw an exception on open.
                If (myStream IsNot Nothing) Then
                    myStream.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles cgog.Click
        If gog = 1 Then
            GogLabel.Text = False
            gog = 0
            TextSFolder.Enabled = True
            cSfolder.Enabled = True
        Else
            GogLabel.Text = True
            gog = 1
            TextSFolder.Enabled = False
            cSfolder.Enabled = False
        End If
    End Sub

    Private Sub oif_Click(sender As Object, e As EventArgs) Handles oif.Click
        Process.Start(Application.UserAppDataPath)
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles mflabel.Click
        If mflabel.Text = "AppData" Then
            mflabel.Text = "Stardew Valled Folder"
            Modfolder = folder & "\Mods"
        Else
            mflabel.Text = "AppData"
            Modfolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\StardewValley\Mods"
        End If
    End Sub

    Private Sub mfolder_Click(sender As Object, e As EventArgs) Handles mfolder.Click
        If mflabel.Text = "AppData" Then
            mflabel.Text = "Stardew Valley Folder"
            Modfolder = folder & "\Mods"
        Else
            mflabel.Text = "AppData"
            Modfolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\StardewValley\Mods"
        End If
    End Sub

    Private Sub channel_Click(sender As Object, e As EventArgs) Handles channel.Click
        If channel.Text = "Stable" Then
            channel.Text = "Unstable"
            rchannel = "Unstable"
        Else
            channel.Text = "Stable"
            rchannel = "Stable"
        End If
    End Sub

    Private Sub channelc_Click(sender As Object, e As EventArgs) Handles channelc.Click
        If channel.Text = "Stable" Then
            channel.Text = "Unstable"
            rchannel = "Unstable"
        Else
            channel.Text = "Stable"
            rchannel = "Stable"
        End If
    End Sub
End Class