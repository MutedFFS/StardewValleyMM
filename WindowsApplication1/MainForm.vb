Imports System.IO
Imports System.IO.Compression
Public Class MainForm
    Dim appPath As String = Application.StartupPath()
    Dim smdir As New IO.DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\StardewValley\Mods")
    Dim diar1 As IO.FileInfo() = smdir.GetFiles("*.dll")
    Dim diar2 As IO.FileInfo() = smdir.GetFiles("*.xnb")
    Dim dra As IO.FileInfo
    Dim check1 = 0
    Dim folder = "C:\"
    Dim Sfolder = "C:\"
    Dim gog = 0
    Dim appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)

    Private Declare Ansi Function GetPrivateProfileString Lib "kernel32.dll" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Int32, ByVal lpFileName As String) As Int32

    Private Declare Ansi Function WritePrivateProfileString Lib "kernel32.dll" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Int32


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

    Private Sub SDVMM_Startup() Handles Me.Shown
        If (Not System.IO.File.Exists(Application.UserAppDataPath & "\SDVNN.ini")) Then
            If (Not System.IO.Directory.Exists("C:\Program Files (x86)\Steam\steamapps\common\Stardew Valley")) Then
                If (Not System.IO.Directory.Exists("C:\Program Files (x86)\Steam\steamapps\common\Stardew Valley")) Then
                    If (Not System.IO.Directory.Exists("E:\Program Files (x86)\Steam\steamapps\common\Stardew Valley")) Then
                        If (Not System.IO.Directory.Exists("C:\Games\Stardew Valley")) Then
                            If (Not System.IO.Directory.Exists("D:\Games\Stardew Valley")) Then
                                If (Not System.IO.Directory.Exists("E:\Games\Stardew Valley")) Then
                                    INI()
                                Else
                                    folder = "E:\Games\Stardew Valley"
                                    gog = 1
                                    INI_WriteValueToFile("General", "GameFolder", folder, Application.UserAppDataPath & "\SDVNN.ini")
                                    INI_WriteValueToFile("General", "SteamFolder", Sfolder, Application.UserAppDataPath & "\SDVNN.ini")
                                    INI_WriteValueToFile("General", "Good Old Game Version", gog, Application.UserAppDataPath & "\SDVNN.ini")
                                End If
                            Else
                                folder = "D:\Games\Stardew Valley"
                                gog = 1
                                INI_WriteValueToFile("General", "GameFolder", folder, Application.UserAppDataPath & "\SDVNN.ini")
                                INI_WriteValueToFile("General", "SteamFolder", Sfolder, Application.UserAppDataPath & "\SDVNN.ini")
                                INI_WriteValueToFile("General", "Good Old Game Version", gog, Application.UserAppDataPath & "\SDVNN.ini")
                            End If
                        Else
                            folder = "C:\Games\Stardew Valley"
                            gog = 1
                            INI_WriteValueToFile("General", "GameFolder", folder, Application.UserAppDataPath & "\SDVNN.ini")
                            INI_WriteValueToFile("General", "SteamFolder", Sfolder, Application.UserAppDataPath & "\SDVNN.ini")
                            INI_WriteValueToFile("General", "Good Old Game Version", gog, Application.UserAppDataPath & "\SDVNN.ini")
                        End If
                    Else
                        folder = "E:\Program Files (x86)\Steam\steamapps\common\Stardew Valley"
                        Sfolder = "E:\Program Files (x86)\Steam"
                        INI_WriteValueToFile("General", "GameFolder", folder, Application.UserAppDataPath & "\SDVNN.ini")
                        INI_WriteValueToFile("General", "SteamFolder", Sfolder, Application.UserAppDataPath & "\SDVNN.ini")
                        INI_WriteValueToFile("General", "Good Old Game Version", gog, Application.UserAppDataPath & "\SDVNN.ini")
                    End If
                Else
                    folder = "D:\Program Files (x86)\Steam\steamapps\common\Stardew Valley"
                    Sfolder = "D:\Program Files (x86)\Steam"
                    INI_WriteValueToFile("General", "GameFolder", folder, Application.UserAppDataPath & "\SDVNN.ini")
                    INI_WriteValueToFile("General", "SteamFolder", Sfolder, Application.UserAppDataPath & "\SDVNN.ini")
                    INI_WriteValueToFile("General", "Good Old Game Version", gog, Application.UserAppDataPath & "\SDVNN.ini")
                End If
            Else
                folder = "C:\Program Files (x86)\Steam\steamapps\common\Stardew Valley"
                Sfolder = "C:\Program Files (x86)\Steam"
                INI_WriteValueToFile("General", "GameFolder", folder, Application.UserAppDataPath & "\SDVNN.ini")
                INI_WriteValueToFile("General", "SteamFolder", Sfolder, Application.UserAppDataPath & "\SDVNN.ini")
                INI_WriteValueToFile("General", "Good Old Game Version", gog, Application.UserAppDataPath & "\SDVNN.ini")
            End If
        Else
            folder = INI_ReadValueFromFile("General", "GameFolder", "C:\", Application.UserAppDataPath & "\SDVNN.ini")
            Sfolder = INI_ReadValueFromFile("General", "SteamFolder", "C:\", Application.UserAppDataPath & "\SDVNN.ini")
            gog = INI_ReadValueFromFile("General", "Good Old Game Version", 0, Application.UserAppDataPath & "\SDVNN.ini")
        End If
        If System.IO.File.Exists(appPath & "\Update\StardewModdingAPI.exe") Then
            If MsgBox("Found  Updated Files, do you want to update SMAPI now?", MsgBoxStyle.YesNo) = DialogResult.Yes Then
                Call Update()
            End If
        End If
        Dim Check = Directory.GetFiles(appPath & "\Update\", "*.zip")
        If Check.Length = 1 Then
            If MsgBox("Found  Updated Files, do you want to update SMAPI now?", MsgBoxStyle.YesNo) = DialogResult.Yes Then
                Dim fileEntries As String() = Directory.GetFiles(appPath & "\Update\", "*.zip")
                Dim sOnlyFileName As String
                For Each sFileName In fileEntries
                    sOnlyFileName = System.IO.Path.GetFileName(sFileName)
                Next
                extract(appPath & "\Update\" & sOnlyFileName, appPath & "\Update\")
            End If
        End If
        If (Not System.IO.File.Exists(folder & "\StardewModdingAPI.exe")) Then
            MsgBox("Couldnt Find SMAPI, please install it yourself or Place the unpacked Files in an Folder called Update and Start again", MsgBoxStyle.Critical)
            Application.Exit()
        End If
        ModList.Items.Clear()
        For Each dra In diar1
            If ModList.Items.Contains(dra) = False Then
                ModList.Items.Add(dra)
            End If
        Next
    End Sub

    Private Sub INI()
        MsgBox("Sorry, i couldnt detect you Installations Path. But no worry we can fix this! Just answer the follwoing Prompts.", MsgBoxStyle.OkOnly, "Huston we have an Problem!")
        If MsgBox("Do you own the GoG (God old Games) Version?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            gog = 1
            folder = InputBox("Pease Input the Full Path of you StardewValley installation", "Nearly Done!", "Example: C:\games\StardewValley")
            While (Not System.IO.Directory.Exists(folder))
                folder = InputBox("Couldnt not find th Path, Please Try again", "Nearly Done!", "Example: C:\games\StardewValley")
            End While
        Else
            Sfolder = InputBox("Please Input the  Path to your Steam Folder", "Nearly Done!", "Example: C:\Program Files (x86)\Steam")
            While (Not System.IO.Directory.Exists(Sfolder))
                Sfolder = InputBox("Couldnt find the Path, Please try again", "Nearly Done!", "Example: C:\Program Files (x86)\Steam")
            End While
            If (Not System.IO.Directory.Exists(Sfolder & "steamapps\common\Stardew Valley")) Then
                folder = InputBox("Pease Input the  Path to your Stardew Valley Folder", "Nearly Done!", "Example: C:\Program Files (x86)\Steam\steamapps\common\Stardew Valley")
                While (Not System.IO.Directory.Exists(folder))
                    folder = InputBox("Couldnt not find th Path, Please Try again", "Nearly Done!", "Example: C:\Program Files (x86)\Steam\steamapps\common\Stardew Valley")
                End While
            Else
                folder = Sfolder & "steamapps\common\Stardew Valley"
            End If
            If (Not System.IO.Directory.Exists(Sfolder & "\steamapps\common\Stardew Valley\Stardew Valley.exe")) Then
                folder = InputBox("Pease Input the  Path to your Stardew Valley Folder", "Nearly Done!", "Example: C:\Program Files (x86)\Steam\steamapps\common\Stardew Valley")
                If (Not System.IO.Directory.Exists(folder)) Then
                    folder = InputBox("Couldnt not find th Path, Please Try again", "Nearly Done!", "Example: C:\Program Files (x86)\Steam\steamapps\common\Stardew Valley")
                Else
                End If
            Else
                folder = Sfolder & "steamapps\common\Stardew Valley"
            End If

        End If
        INI_WriteValueToFile("General", "GameFolder", folder, Application.UserAppDataPath & "\SDVNN.ini")
        INI_WriteValueToFile("General", "SteamFolder", Sfolder, Application.UserAppDataPath & "\SDVNN.ini")
        INI_WriteValueToFile("General", "Good Old Game Version", gog, Application.UserAppDataPath & "\SDVNN.ini")
    End Sub

    Sub Update()
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(appPath & "\Update\", Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "*.*")
            Dim foundFileInfo As New System.IO.FileInfo(foundFile)
            Dim ext = Path.GetExtension(foundFile)
            If ext = ".dll" Then
                My.Computer.FileSystem.MoveFile(foundFile, Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\StardewValley\Mods\" & foundFileInfo.Name, True)
            Else
                My.Computer.FileSystem.MoveFile(foundFile, folder & "\" & foundFileInfo.Name, True)
            End If
        Next
        System.IO.Directory.Delete(appPath & "\Update\", True)
        System.IO.Directory.CreateDirectory(appPath & "\Update\")
        While (Not System.IO.Directory.Exists(appPath & "\Update\"))
            System.IO.Directory.CreateDirectory(appPath & "\Update\")
        End While
    End Sub


    Sub extract(ByVal zPath, ByVal ePath)
        ZipFile.ExtractToDirectory(zPath, ePath)
        System.IO.File.Delete(zPath)
        MsgBox("hi")
        Call Update()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim Result As Integer = MsgBox("The SDVMM Forumpost will be opened, are you alright with this?", MsgBoxStyle.YesNo)
        If Result = DialogResult.Yes Then
            System.Diagnostics.Process.Start("http://community.playstarbound.com/threads/fairly-simple-mod-manager-batch-based.107663/")
        End If
    End Sub

    Private Sub LSMAPI_Click(sender As Object, e As EventArgs) Handles LSMAPI.Click
        Shell("cmd.exe /c" + "cd /d " & folder & "& call " + """" & folder & "\StardewModdingAPI.exe" & """")
    End Sub

    Private Sub LSDV_Click(sender As Object, e As EventArgs) Handles LSDV.Click
        If gog = 1 Then
            Process.Start(folder & "\Stardew Valley.exe")
        Else
            Process.Start(Sfolder & "\Steam.exe", "-applaunch 413150")
        End If
    End Sub


    Private Sub AddMod_Click(sender As Object, e As EventArgs) Handles addm.Click
        Dim myStream As Stream = Nothing
        Dim openFileDialog1 As New OpenFileDialog()
        Dim ddir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\StardewValley\Mods\"
        openFileDialog1.InitialDirectory = "c:\"
        openFileDialog1.Filter = "SMAPI Mod files (*.dll)|*.dll"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.Title = "Select SMAPI-Mod"
        openFileDialog1.RestoreDirectory = True
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                myStream = openFileDialog1.OpenFile()
                'MsgBox(openFileDialog1.FileName)
                'MsgBox(Path.GetFileName(openFileDialog1.FileName))
                If myStream IsNot Nothing Then
                    Dim tdir = ddir & Path.GetFileName(openFileDialog1.FileName)
                    IO.File.Copy(openFileDialog1.FileName, tdir)
                    ModList.Items.Add(Path.GetFileName(openFileDialog1.FileName))
                End If

            Catch Ex As Exception
                MessageBox.Show("Cannot read file from disk!")
            Finally
                ' Check this again, since we need to make sure we didn't throw an exception on open.
                If (myStream IsNot Nothing) Then
                    myStream.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub dlm_Click(sender As Object, e As EventArgs) Handles dlm.Click
        Dim Result As Integer = MsgBox("The Mod Subforum will be opened, are you alright with this?", MsgBoxStyle.YesNo)
        If Result = DialogResult.Yes Then
            System.Diagnostics.Process.Start("http://community.playstarbound.com/forums/mods.215/")
        End If
    End Sub

    Sub UpdateSNAPI(url)
        My.Computer.Network.DownloadFile(url, appPath & "\Update\update.zip", "", "", True, 500, True)
        extract(appPath & "\Update\update.zip", appPath & "\Update\")
    End Sub


    Private Sub delm_Click(sender As Object, e As EventArgs) Handles delm.Click
        Dim mIndex As Integer = ModList.SelectedIndex
        ' der Name des Eintrages zu einer brauchbaren Variable bringen 
        Dim mText = ModList.Items.Item(mIndex)
        Dim Result As Integer = MsgBox("are you sure that you want to delete: " & mText.ToString & "?", MsgBoxStyle.YesNo)
        If Result = DialogResult.Yes Then
            Dim deldir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\StardewValley\Mods\"
            System.IO.File.Delete(deldir & mText.ToString)
            ModList.Items.Remove(mText)
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    'Private Sub UpSnapi_Click(sender As Object, e As EventArgs)
    'Dim r As String = InputBox("Please Enter the Download URL of the newest version.", "URL", "https://github.com/ClxS/SMAPI/releases/download/0.36/SMAPI_0.36A.zip")
    '   UpdateSNAPI(r)
    'End Sub



End Class
