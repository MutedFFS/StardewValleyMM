Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports System.Security.Cryptography
Imports Microsoft.VisualBasic.ApplicationServices
Imports Newtonsoft.Json




Public Class MainForm

    Public Shared ReadOnly PathSeparator As Char
    Public Shared sep = Path.DirectorySeparatorChar

    Public Shared loadorderc As String = 0
    Public Shared xbo As Boolean = False
    Public Shared xpath As String = ""
    Public Shared Multiok = 0
    Public Shared Mulitcount = 0
    Public Shared Fname As String = ""
    Public Shared appPath As String = Application.StartupPath()
    Public Shared ddir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & sep & "StardewValley" & sep & "Mods" & sep
    Public Shared xa() As String = {}
    Public Shared count As Integer = 0
    Dim dmdir As New IO.DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & sep & "StardewValley" & sep & "deactivatedMods")
    Dim xmdir As New IO.DirectoryInfo(appPath & sep & "Backup")
    Dim diar2 As IO.FileInfo() = dmdir.GetFiles("*.dll") 'Scans for all existing mods
    Dim diar3 As IO.FileInfo() = xmdir.GetFiles("*.xnb") 'Scams for all existing xnb files
    Dim dra As IO.FileInfo
    Dim check1 = 0
    Public Shared folder = "C:" & sep
    Public Shared Sfolder = "C:" & sep
    Public Shared gog = 0
    Public Shared cSVersion = "0"
    Public Shared cVersion = "3.1b"
    Dim notFound = 0
    Dim Skip = 0
    Shared errorlv = 0
    Public Shared prel = False
    Public Shared release_channel
    Public Shared done As Boolean = False
    Dim lastdir = INI_ReadValueFromFile("General", "LastDir", "C:" & sep, Application.UserAppDataPath & sep & "SDVMM.ini")
    Dim foundXNB As String = Nothing



    Private Declare Ansi Function GetPrivateProfileString Lib "kernel32.dll" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Int32, ByVal lpFileName As String) As Int32

    Private Declare Ansi Function WritePrivateProfileString Lib "kernel32.dll" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Int32
    '
    '       Functions
    '



    Public Shared Function INI_ReadValueFromFile(ByVal strSection As String, ByVal strKey As String, ByVal strDefault As String, ByVal strFile As String) As String
        'Reading Function 
        'strSection = Section of the INI-File
        'strKey = Name of the Key
        'strDefault = Standardvalue if ini cant be foung
        'strFile = full path to ini
        Dim strTemp As String = Space(1024), lLength As Integer
        lLength = GetPrivateProfileString(strSection, strKey, strDefault, strTemp, strTemp.Length, strFile)
        Return (strTemp.Substring(0, lLength))
    End Function

    Public Shared Function INI_WriteValueToFile(ByVal strSection As String, ByVal strKey As String, ByVal strValue As String, ByVal strFile As String) As Boolean
        'Write function
        'strSection = Section of the INI-File
        'strKey = Name of Key
        'strValue = output Value
        'strFile = full path to INI
        Return (Not (WritePrivateProfileString(strSection, strKey, strValue, strFile) = 0))
    End Function

    Shared Function shPath(mypath As String)
        Dim myPos As Integer
        Dim myFolder As String

        myPos = InStrRev(mypath, sep, -1, vbTextCompare)

        If myPos > 0 Then
            myFolder = Mid(mypath, myPos + 1)
            Return myFolder
        End If
        Return 0
    End Function


    Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
        My.Computer.FileSystem.WriteAllText(appPath + "Crashlog.txt", Err.Description, True)
        My.Computer.FileSystem.WriteAllText(appPath + "Crashlog.txt", "Gamepath =  " + folder.ToString, True)
        My.Computer.FileSystem.WriteAllText(appPath + "Crashlog.txt", "Steampath =  " + Sfolder.ToString, True)
        My.Computer.FileSystem.WriteAllText(appPath + "Crashlog.txt", "GOG =  " + gog.ToString, True)

    End Sub

    Function UpdateSNAPI(url)
        My.Computer.Network.DownloadFile(url, appPath & sep & "Update" & sep & "update.zip", "", "", True, 500, True)
        zip(appPath & sep & "Update" & sep & "update.zip", appPath & sep & "Update" & sep, 1, True)
    End Function

    Overloads Shared Function Update()
        Dim cfolder = ""
        Dim from = ""
        Dim MoveTo = ""
        Try
            For Each Dir As String In Directory.GetDirectories(appPath & sep & "Update" & sep)
                cfolder = shPath(Dir)
            Next
            from = appPath & sep & "Update" & sep & "cfolder" & sep & "cfolder" & sep & "Windows" & sep
            MoveTo = folder '&  sep & "Mods" & sep 
            If Not File.Exists(MoveTo & sep & "Stardew Valley.exe") Then
                MsgBox("The Gamepath doesnt seem to be correct, please check the settings.", MsgBoxStyle.OkOnly)
                Dim IniF As New INIForm
                IniF.ShowDialog()
            End If
            My.Computer.FileSystem.MoveDirectory(from, MoveTo, True)
            errorlv = 3
            System.IO.Directory.Delete(appPath & sep & "Update" & sep, True)
            errorlv = 4
            System.IO.Directory.CreateDirectory(appPath & sep & "Update" & sep)
            errorlv = 5
            While (Not System.IO.Directory.Exists(appPath & sep & "Update" & sep))
                errorlv = 6
                System.IO.Directory.CreateDirectory(appPath & sep & "Update" & sep)
            End While
        Catch Ex As Exception
            MessageBox.Show(Ex.ToString)
        End Try

    End Function



    Public Shared SHAcheck As String
    Public Event UnhandledException(sender As Object, e As UnhandledExceptionEventArgs)

    Public Class GitRelease
        Public Property tag_name As String
        Public Property name As String
        Public Property body As String
        Public Property assets As GitAsset()
    End Class

    Public Class GitAsset
        Public Property name As String
        Public Property content_type As String
        Public Property browser_download_url As String
    End Class

    Shared Durl = ""

    Public Shared Function CheckVersion(Version As String) As Boolean
        If My.Computer.Network.IsAvailable Then
            Try
                'Delete old Updater.exe
                If File.Exists("Updater.exe") Then
                    File.Delete("Updater.exe")
                End If
                If File.Exists("Update.bat") Then
                    File.Delete("Update.bat")
                End If
                If File.Exists((MainForm.appPath & sep & "latest.json")) Then
                    File.Delete((MainForm.appPath & sep & "latest.json"))
                End If
                Dim jsonpath As String = (MainForm.appPath & sep & "latest.json")
                Dim client As New WebClient
                client.Headers.Item("User-Agent") = "Mozilla/4.0"
                client.DownloadFile("https://api.github.com/repos/yuukiw/StardewValleyMM/releases/latest", jsonpath)
                Dim stream As Stream = client.OpenRead(jsonpath)
                Dim reader As New StreamReader(stream)
                Dim jsonData As String = reader.ReadToEnd
                reader.Close()

                Dim release As GitRelease = JsonConvert.DeserializeObject(Of GitRelease)(jsonData)
                Dim Update_Version = release.tag_name
                Durl = release.assets(0).browser_download_url
                If Update_Version > Version Then
                    Return True
                Else
                    Return False
                End If
            Catch
                Return False
            End Try
        End If
    End Function

    Public Shared Function checkSHA(Path As String) As Boolean
        Dim FileDownloadSHA As String
        Using stream As FileStream = File.OpenRead(Path)
            Dim sha As New SHA256Managed()
            Dim hash As Byte() = sha.ComputeHash(stream)
            FileDownloadSHA = BitConverter.ToString(hash).Replace("-", String.Empty)
        End Using
        If FileDownloadSHA = SHAcheck Then
            Return True
        Else
            Return False
        End If
    End Function


    Public Shared Sub DownloadUpdate()
        Dim startInfo As New ProcessStartInfo With {
            .FileName = (MainForm.appPath & sep & "SDVMM Updater.exe"),
            .Arguments = MainForm.Durl,
            .UseShellExecute = True,
            .WindowStyle = ProcessWindowStyle.Normal
        }
        Process.Start(startInfo)
        Application.Exit()
    End Sub




    Function checkSDVMMUpdate()
        If My.Computer.Network.IsAvailable Then
            Try
                Dim url = "https://github.com/Yuukiw/StardewValleyMM/releases"
                If IO.File.Exists(appPath & sep & "Update" & sep & "vcheck.txt") Then
                    IO.File.Delete(appPath & sep & "Update" & sep & "vcheck.txt")
                End If
                My.Computer.Network.DownloadFile(url, appPath & sep & "Update" & sep & "vcheck.txt")
                Dim file = Nothing
                Dim version = Nothing
                Dim arr() As String = IO.File.ReadAllLines(appPath & sep & "Update" & sep & "vcheck.txt")
                For Each item As String In arr
                    If item.Contains("/SDVMM") Then
                        Dim param() As String = item.Split("/")
                        If file = Nothing Then
                            version = param(5)
                        End If
                    End If
                Next
                Dim nurl = "https://github.com/yuukiw/StardewValleyMM/releases/download/" & version & "/SDVMM.exe"
                If (Not String.Compare(version, cVersion)) = 0 Then
                    If MsgBox("SMAPI Update found, do you want to Install it now?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        Dim myWebClient As New WebClient()
                        myWebClient.DownloadFile(nurl, "SDVMM.exe")
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        Else
        End If
    End Function

    Function INI()
        MsgBox("Sorry, I could not detect your Stardew Valley installation path. But no worries we can fix this! Just answer the following prompts.", MsgBoxStyle.OkOnly, "Huston we have an Problem!")
        Dim IniF As New INIForm
        IniF.ShowDialog()
    End Function

    Shared Function zip(zPath As String, dPath As String, mode As Integer, up As Boolean)
        If mode = 0 Then
            ZipFile.CreateFromDirectory(zPath, dPath)

        Else
            ZipFile.ExtractToDirectory(zPath, dPath)
            done = True
            If mode = 1 Then
                System.IO.File.Delete(zPath)
            End If
        End If
        If up = True Then
            Call Update()
        End If
    End Function

    Private Function GetFileVersionInfo(ByVal filename As String) As Version
        Return Version.Parse(FileVersionInfo.GetVersionInfo(filename).FileVersion)
    End Function

    Public foundfile As Boolean = False
    Public Function rec(ByVal SourcePath As String, searched As String)

        Dim SourceDir As DirectoryInfo = New DirectoryInfo(SourcePath)
        Dim pathIndex As Integer
        pathIndex = SourcePath.LastIndexOf("\")
        ' the source directory must exist, otherwise throw an exception

        If SourceDir.Exists Then
            Dim SubDir As DirectoryInfo
            For Each SubDir In SourceDir.GetDirectories()
                rec(SourcePath & SubDir.Name & sep, searched)
            Next


            For Each childFile As FileInfo In SourceDir.GetFiles(searched, SearchOption.AllDirectories)
                If foundfile = False Then
                    foundXNB = childFile.FullName
                    foundfile = True
                Else
                    foundXNB = Nothing
                    Return False
                End If
            Next
        Else
            Throw New DirectoryNotFoundException("Source directory does not exist: " + SourceDir.FullName)
        End If
    End Function

    '
    '               SUBS
    '

    'Launch Sub
    Private Sub SDVMM_Startup() Handles Me.Load
        '  Button3.Hide()
        INI_WriteValueToFile("General", "Modfolder", Nothing, Application.UserAppDataPath & sep & "SDVMM.ini")

        ProgressBar1.Enabled = False
        ProgressBar1.Hide()
        prel = INI_ReadValueFromFile("General", "Pre-Release", False, Application.UserAppDataPath & sep & "SDVMM.ini")
        ASM.Enabled = False
        ASM.Hide()
        LStorm.Enabled = False
        LStorm.Hide()

        If (Not System.IO.File.Exists(appPath & sep & "SDVMM Updater.exe")) Then
            Dim client As New WebClient
            client.Headers.Item("User-Agent") = "Mozilla/4.0"
            client.DownloadFile("https://drive.google.com/uc?export=download&id=0B94u0_R6vixWUy12RVpJN1NkWlU", appPath & sep & "SDVMM Updater.exe")
        End If

        If (Not System.IO.File.Exists(appPath & sep & "Newtonsoft.Json.dll")) Then
            Dim client As New WebClient
            client.Headers.Item("User-Agent") = "Mozilla/4.0"
            client.DownloadFile("https://drive.google.com/uc?export=download&id=0B94u0_R6vixWNmUxLVpLQksyRUU", appPath & sep & "Newtonsoft.Json.dll")
        End If

        If CheckVersion(cVersion) = True Then
            If MsgBox("SDVMM Update found. Install now?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                DownloadUpdate()
            End If
        End If

        'fixing name Error
        If (Not System.IO.File.Exists(Application.UserAppDataPath & sep & "SDVMM.ini")) Then
            Dim spath As String = "Program Files (x86)" & sep & "Steam" & sep & "steamapps" & sep & "common" & sep & "Stardew Valley"
            Dim sspath As String = "Program Files (x86)" & sep & "Steam" & sep
            Dim gpath As String = "Games" & sep & "StardewValley"
            Dim allDrives() As DriveInfo = DriveInfo.GetDrives()
            Dim Folder1 As String = ""
            Dim Folder2 As String = ""
            Dim Drives As DriveInfo
            Dim succses As Boolean = False
            'get all driveletter
            For Each Drives In allDrives
                'if drive = HDD
                If Drives.DriveType = 3 Then
                    Folder1 = Drives.Name & spath
                    Folder2 = Drives.Name & gpath
                    'does a the steam version of Stardew Valley exist on the drive
                    If System.IO.Directory.Exists(Folder1) Then
                        'if yes then:
                        gog = 0 'its not the gog version
                        Sfolder = sspath 'changing the variables to not have to read them out again
                        folder = Folder1 '^
                        INI_WriteValueToFile("General", "GameFolder", Folder1, Application.UserAppDataPath & sep & "SDVMM.ini") 'writing variables to the ini
                        INI_WriteValueToFile("General", "SteamFolder", Drives.Name & sspath, Application.UserAppDataPath & sep & "SDVMM.ini") '^
                        INI_WriteValueToFile("General", "Good Old Game Version", gog, Application.UserAppDataPath & sep & "SDVMM.ini") '^
                        succses = True 'tell the if routine that a file i found
                        Exit For 'exit for loop
                    ElseIf System.IO.Directory.Exists(Folder2) Then
                        gog = 1 'same as above just the GoG variant
                        folder = Folder2
                        INI_WriteValueToFile("General", "GameFolder", Folder2, Application.UserAppDataPath & sep & "SDVMM.ini")
                        INI_WriteValueToFile("General", "Good Old Game Version", gog, Application.UserAppDataPath & sep & "SDVMM.ini")
                        succses = True   'tell the if routine that a file i found
                        Exit For 'exit for loop
                    End If
                End If
            Next
            'if the algorithmn couldnt find the file then call the ini
            If succses = False Then
                INI()
            End If
        Else 'if the ini exist then just read out all need variables
            folder = INI_ReadValueFromFile("General", "GameFolder", "C:" & sep, Application.UserAppDataPath & sep & "SDVMM.ini")
            Sfolder = INI_ReadValueFromFile("General", "SteamFolder", "C:" & sep, Application.UserAppDataPath & sep & "SDVMM.ini")
            gog = INI_ReadValueFromFile("General", "Good Old Game Version", 0, Application.UserAppDataPath & sep & "SDVMM.ini")
            release_channel = INI_ReadValueFromFile("General", "Release Channel", "Stable", Application.UserAppDataPath & sep & "SDVMM.ini")
            cSVersion = INI_ReadValueFromFile("SMAPI Details", "Version", "SMAPI-0.37.1A", Application.UserAppDataPath & sep & "SDVMM.ini")
        End If
        If (Not System.IO.File.Exists(folder & sep & "StardewModdingAPI.exe")) Then 'does smapi exist? if no:
            If MsgBox("SMAPI does not appear to be installed, should i install it?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then 'ask the user if he would like to install it.If yes:
                notFound = 1 'change variable to tell the subroutine that it can just install the update even if the a version number exist
                checkSmapiUpdate() 'call sub routine
            Else 'if no
                LSMAPI.Enabled = False 'deactivate the button
            End If
        End If
        If (Not System.IO.Directory.Exists(folder & sep & "Mods" & sep)) Then
            System.IO.Directory.CreateDirectory(folder & sep & "Mods" & sep)
        End If
        If Skip = 0 Then 'this is only 1 if the subroutine was run with the parameter not found = 1, this is to tell the programm that it doenst need to check twice
            checkSmapiUpdate()
        End If
        ' If (Not System.IO.File.Exists(folder &  sep & "StormLoader.exe")) Then 'same as with smapi. not implemented since it isnt Storm isnt really useable for the normal user imo. But it will detect it
        ' If MsgBox("Couldnt Find SMAPI, should i install it?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        'notFound = 1
        'checkSmapiUpdate()
        'Else
        '  LSMAPI.Enabled = False
        'End If
        'LStorm.Enabled = False 'if not  disable the button
        '  End If
        '  checkSDVMMUpdate() ' here he should check for an update of the mod manager but not yet implemented
        refreshb.PerformClick()
        LabelSmapi.Text = "SMAPI Version: " & cSVersion.ToString
        LabelSD.Text = "SDVMM Version: " & cVersion
        ModList.Sorted = True : ModListd.Sorted = True : XNBlist.Sorted = True : Loadorder.Sorted = True
        'SetWindowText(hwnd, "SDVMM Version: " & cVersion & "    Relase-Channel: " & release_channel)
        Me.Text = "SDVMM V" & MainForm.cVersion & "   Smapi: " & MainForm.cSVersion

    End Sub



    Private Sub Refresh_list() Handles refreshb.Click
        ModList.Items.Clear() ' clea the modlists. While they should be empty anyways i still want to be sure
        ModListd.Items.Clear()
        Loadorder.Items.Clear()
        Dim result = 0
        Dim number As Integer = 1
        For Each Dir As String In Directory.GetDirectories(folder & sep & "mods" & sep)
            Dim file = shPath(Dir)
            result = String.Compare(file, "Content")
            If result > 0 Or result < 0 Then
                If ModList.Items.Contains(file & ".dll") = False Then 'check to defend against double entries
                    ModList.Items.Add(file & ".dll")
                    Loadorder.Items.Add(file & ".dll")
                End If
            End If
        Next
        For Each Dir As String In Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & sep & "StardewValley" & sep & "Mods" & sep)
            Dim file = shPath(Dir)
            result = String.Compare(file, "Content")
            If result > 0 Or result < 0 Then
                If ModList.Items.Contains(file & ".dll") = False Then 'check to defend against double entries
                    MsgBox(folder & sep & "Mod" & sep & file, MsgBoxStyle.OkOnly)
                    My.Computer.FileSystem.MoveDirectory(Dir, folder & sep & "Mods" & sep & file & sep, True)
                End If
            End If
        Next
        For Each Dir As String In Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & sep & "StardewValley" & sep & "deactivatedMods" & sep)
            Dim file = shPath(Dir)
            result = String.Compare(file, "Content")
            If result > 0 Or result < 0 Then
                If ModListd.Items.Contains(file & ".dll") = False Then 'check to defend against double entries
                    ModListd.Items.Add(file & ".dll")
                End If
            End If
        Next
        'Dim arr2() As String = IO.File.ReadAllLines(Application.UserAppDataPath &  sep & "Storm.ini") 'reads all storm mods
        'For Each item As String In arr2
        'If item.Contains("=") Then
        'If item.Contains(".storm") Then
        'Dim param() As String = item.Split("=")
        '  Dim file() = param(0).Split(".")
        '  If IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) &  sep & "StardewValley" & sep & "Mods" & sep & file(0) & sep) Then
        ' #ModList.Items.Add(param(0))
        '  Else
        '  ModListd.Items.Add(param(0))
        '  End If
        '  End If
        'End If
        '   Next
        ' For Each dra In diar3
        'If IO.File.Exists(appPath &  sep & "Backup" & sep &dra.Name) Then
        'ModList.Items.Add(dra.Name)
        ' Else
        ' INI_WriteValueToFile("XNB Backup paths", dra.Name, Nothing, Application.UserAppDataPath &  sep & "XNB.ini")
        'End If
        ' Next
        Dim arr() As String = IO.File.ReadAllLines(Application.UserAppDataPath & sep & "XNB.ini")
        For Each item As String In arr
            If item.Contains(".xnb") Then
                Dim param() As String = item.Split("="c)
                Dim help = INI_ReadValueFromFile("XNB Backup paths", param(0), "", Application.UserAppDataPath & sep & "XNB.ini")
                Dim name = param(0)
                If IO.File.Exists(appPath & sep & "Backup" & sep & name) Then
                    XNBlist.Items.Add(name)
                Else
                    INI_WriteValueToFile("XNB Backup paths", param(0), Nothing, Application.UserAppDataPath & sep & "XNB.ini")
                End If
            End If
        Next
        For Each dra In diar2 ' reads all deactivated mods
            If ModListd.Items.Contains(dra) = False Then
                ModListd.Items.Add(dra)
            End If
        Next
    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim Result As Integer = MsgBox("The SDVMM forum topic will be opened in your web browser, do you wish to proceed?", MsgBoxStyle.YesNo)
        If Result = DialogResult.Yes Then
            System.Diagnostics.Process.Start("http://community.playstarbound.com/threads/fairly-simple-mod-manager-batch-based.107663/")
        End If
    End Sub

    Private Sub LSMAPI_Click(sender As Object, e As EventArgs) Handles LSMAPI.Click
        Try
            Shell("cmd.exe /c" + "cd /d " & folder & "& call " + """" & folder & sep & "StardewModdingAPI.exe" & """")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    ' Private Sub LStorm_Click(sender As Object, e As EventArgs) Handles LStorm.Click
    ' Try

    '    Shell("cmd.exe /c" + "cd /d " & folder & "& call " + """" & folder &  sep & "StormLoader.exe" & """")
    ' '      Process.Start(folder &  sep & "StormLoader.exe")
    '  Catch ex As Exception
    '       MsgBox("Could not Launch Storm API! Please check if the path is corect? Path: " & folder)
    '   End Try
    ' End Sub

    Private Sub LSDV_Click(sender As Object, e As EventArgs) Handles LSDV.Click
        Try
            If gog = 1 Then
                Process.Start(folder & sep & "Stardew Valley.exe")
            Else
                Process.Start(Sfolder & sep & "Steam.exe", "-applaunch 413150")
            End If
        Catch ex As Exception
            If gog = 1 Then
                MsgBox("Could not Launch Smapi! Please check if the path is correct? Path: " & folder)
            Else
                MsgBox("Could not Launch Smapi! Please check if the path is correct? Path: " & Sfolder)
            End If
        End Try

    End Sub



    Private Function installXNB(xspath As String)
        Dim xtpath As String = Nothing
        Dim name As String = Nothing
        If (foundXNB Is Nothing) Then
            Dim Form As New XNBForm
            'open XNB Form
            If Multiok = 0 Then
                Form.ShowDialog()
            End If
            xtpath = XNBForm.XtFolder & sep & Fname
            name = shPath(XNBForm.XtFolder) & "-" & Fname
            If (Not IO.File.Exists(appPath & sep & "Backup" & sep & name)) Then
            End If
            My.Computer.FileSystem.MoveFile(xtpath, appPath & sep & "Backup" & sep & name, True)
        Else
            xtpath = foundXNB
            name = shPath(foundXNB) & "-" & Fname
        End If

        IO.File.Copy(xspath, xtpath, True)
        INI_WriteValueToFile("XNB Backup paths", name, xtpath, Application.UserAppDataPath & sep & "XNB.ini")
        If XNBlist.Items.Contains(name) = False Then
            XNBlist.Items.Add(name)
        End If
    End Function

    Function deleteXNB(name As String)
        Dim arr() As String = IO.File.ReadAllLines(Application.UserAppDataPath & sep & "XNB.ini")
        For Each item As String In arr
            If item.Contains("=") Then
                If item.Contains("Content") Then
                    If item.Contains(name) Then
                        Dim param() As String = item.Split("="c)
                        'MsgBox(param(0)) 'output the name
                        My.Computer.FileSystem.MoveFile(appPath & sep & "Backup" & sep & param(0), param(1), True)
                        INI_WriteValueToFile("XNB Backup paths", param(0), Nothing, Application.UserAppDataPath & sep & "XNB.ini")
                        XNBlist.Items.Remove(param(0))
                    End If

                End If
            End If
        Next

    End Function


    Public found As Boolean = False

    Private Sub AddMod_Click(sender As Object, e As EventArgs) Handles addm.Click
        Dim isZip As Boolean = False
        Dim myStream As Stream = Nothing
        Dim openFileDialog1 As New OpenFileDialog()
        Dim ddir = folder & sep
        Dim number = Loadorder.Items.Count + 1
        openFileDialog1.InitialDirectory = lastdir
        openFileDialog1.Filter = "SMAPI Mod files (*.dll)|*.dll|XNB Mods (*.XNB)|*.xnb|SMAPI Mod Ini(*.ini)|*.ini|Zip Files|*.zip|All|*.*"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.Title = "Select SMAPI-Mod"
        openFileDialog1.Multiselect = True
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                myStream = openFileDialog1.OpenFile()
                If myStream IsNot Nothing Then
                    For Each s As String In openFileDialog1.FileNames
                        Mulitcount += 1
                    Next
                    For Each s As String In openFileDialog1.FileNames
                        Dim dir = Path.GetDirectoryName(s) & sep
                        INI_WriteValueToFile("General", "lastDir", gog, Application.UserAppDataPath & sep & "SDVMM.ini")
                        lastdir = dir
                        Fname = Path.GetFileName(s)
                        Dim tdir = ddir & Path.GetFileName(s)
                        Dim ext = Path.GetExtension(s)
                        Dim help As String = ""
                        Dim test As String = ""
                        If ext = ".xnb" Then

                            If (Fname.Contains("winter_") Or Fname.Contains("srping_") Or Fname.Contains("summer_") Or Fname.Contains("fall_") = False) Then
                                found = rec(folder & sep & "content" & sep, Fname)
                            End If
                            xpath = s
                            installXNB(xpath)
                        Else
                            If ext = ".zip" Then
                                isZip = True
                                number = Loadorder.Items.Count + 1
                                tdir = Path.GetDirectoryName(s) & sep & Path.GetFileNameWithoutExtension(s) & sep
                                zip(s.ToString, tdir, 2, False)
                                '  Threading.Thread.CurrentThread.Sleep(10000)
                                Dim List = My.Computer.FileSystem.GetFiles(tdir, FileIO.SearchOption.SearchAllSubDirectories, "*.*")
                                For Each foundFile In List
                                    If Path.GetExtension(foundFile) = ".dll" Then
                                        tdir = Path.GetDirectoryName(foundFile) & sep
                                        help = Path.GetDirectoryName(foundFile) & ".exe"
                                        Exit For
                                    End If
                                    If Path.GetExtension(foundFile) = ".xnb" Then
                                        Dim openFileDialog2 As New OpenFileDialog()
                                        MsgBox("Zip contains XNB Files, please Select the Files(s) you want To install")
                                        openFileDialog2.InitialDirectory = tdir
                                        openFileDialog2.Filter = "XNB Mods (*.XNB)|*.xnb"
                                        openFileDialog2.FilterIndex = 1
                                        openFileDialog2.Title = "Select XNB-Mod"
                                        openFileDialog2.Multiselect = True
                                        If openFileDialog2.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                                            Mulitcount = 0
                                            For Each ss As String In openFileDialog2.FileNames
                                                Mulitcount += 1
                                            Next
                                            For Each ss As String In openFileDialog2.FileNames
                                                xpath = ss
                                                Fname = Path.GetFileName(ss)
                                                installXNB(ss)
                                            Next
                                        End If
                                        Exit Sub
                                    End If
                                Next
                                My.Computer.FileSystem.MoveDirectory(tdir, folder & sep & "Mods" & sep & number & "-" & Path.GetFileNameWithoutExtension(help) & sep, True)
                                If ModList.Items.Contains(Path.GetFileName(s)) = False Then
                                    If Path.GetExtension(Path.GetExtension(s)) = ".ini" Then
                                    Else
                                        ModList.Items.Add(number & "-" & help)
                                        Loadorder.Items.Add(number & "-" & help)
                                    End If
                                End If
                            Else
                                If ext = ".dll" Then
                                    tdir = ddir & sep & "Mods" & sep & number & "-" & Path.GetFileNameWithoutExtension(s) & sep ' & Path.GetFileName(s)
                                    Dim paths = Path.GetDirectoryName(s)
                                    number = Loadorder.Items.Count + 1
                                    '        MsgBox(number)
                                    If (Not IO.Directory.Exists(ddir & number & "-" & Path.GetFileNameWithoutExtension(s) & sep)) Then
                                        '    IO.Directory.CreateDirectory(ddir & number & "-" & Path.GetFileNameWithoutExtension(s) & sep)
                                    End If
                                    Dim tpath = Path.GetDirectoryName(s) & sep
                                    My.Computer.FileSystem.CopyDirectory(tpath, tdir, True)
                                    'If IO.File.Exists(paths &  sep & "manifest.json") Then
                                    'IO.File.Copy(s, ddir & Path.GetFileNameWithoutExtension(s) & sep &  sep & "manifest.json", True)
                                    ' Else
                                    '   MsgBox("Couldn't find " & Path.GetFileNameWithoutExtension(s) & ".json . The mod may not Work.")
                                    ' End If
                                    If ModList.Items.Contains(Path.GetFileName(s)) = False Then
                                        If Path.GetExtension(Path.GetExtension(s)) = ".ini" Then
                                        Else
                                            ModList.Items.Add(number & "-" & Path.GetFileName(s))
                                            Loadorder.Items.Add(number & "-" & Path.GetFileName(s))
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Next
                    Multiok = 0
                    Mulitcount = 0
                End If

            Catch Ex As Exception
                MessageBox.Show(Ex.ToString)
            Finally
                ' Check this again, since we need to make sure we didn't throw an exception on open.
                If (myStream IsNot Nothing) Then
                    myStream.Close()
                End If
            End Try
        End If
        refreshb.PerformClick()
    End Sub


    Private Sub client_ProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
        Dim bytesIn As Double = Double.Parse(e.BytesReceived.ToString())
        Dim totalBytes As Double = Double.Parse(e.TotalBytesToReceive.ToString())
        Dim percentage As Double = bytesIn / totalBytes * 100
        ProgressBar1.Enabled = True
        ProgressBar1.Show()
        ProgressBar1.Value = Int32.Parse(Math.Truncate(percentage).ToString())
    End Sub

    Private Sub client_DownloadCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        MessageBox.Show("Download Complete")
        ProgressBar1.Value = 0
        ProgressBar1.Enabled = False
        ProgressBar1.Hide()
        Call zip(appPath & sep & "awe.zip", appPath & sep, 1, False)
        While IO.File.Exists(appPath & sep & "awe.zip")
        End While
        dlm.Enabled = True
        dlm.PerformClick()
    End Sub

    Private Sub dlm_Click(sender As Object, e As EventArgs) Handles dlm.Click
        MsgBox("Feature is being reworked!", MsgBoxStyle.OkOnly)
        '  Dim Form2 As New Webrowser
        '  Form2.ShowDialog()
        'If System.IO.Directory.Exists(appPath &  sep & "unpacked" & sep ,) Then
        '    My.Computer.FileSystem.DeleteDirectory(appPath &  sep & "unpacked" & sep , FileIO.DeleteDirectoryOption.DeleteAllContents)
        '    My.Computer.FileSystem.CreateDirectory(appPath &  sep & "unpacked" & sep )
        'End If
        'If (Not System.IO.Directory.Exists(appPath &  sep & "Update" & sep )) Then
        '    My.Computer.FileSystem.CreateDirectory(appPath &  sep & "unpacked" & sep )
        'End If
        'If (Not System.IO.File.Exists(appPath &  sep & "awesomium.dll")) Then
        '    If MsgBox("To use this Feature you will need some additional Files (aprox. Size: 18 MB, Aprox downloadtime: 1-2 Minutes), download it now?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '        Using client As New WebClient()
        '            AddHandler client.DownloadProgressChanged, AddressOf client_ProgressChanged
        '            AddHandler client.DownloadFileCompleted, AddressOf client_DownloadCompleted
        '            ProgressBar1.Enabled = True
        '            ProgressBar1.Show()
        '            client.DownloadFileAsync(New Uri("http://sdvmm.mirror-realms.com/awe.zip"), appPath &  sep & "awe.zip")
        '            dlm.Enabled = False
        '            Exit Sub
        '        End Using
        '    Else
        '        Exit Sub
        '    End If
        'End If
        'Dim Form3 As New Form1
        'Dim x = WebCore.IsInitialized
        'If Not WebCore.IsInitialized Then
        '    WebCore.Initialize(New WebConfig() With {
        '            .HomeURL = New Uri(My.Settings.Homepage),
        '            .RemoteDebuggingPort = 2229,
        '            .LogLevel = LogLevel.Verbose
        '        })
        'End If
        'count = 0
        'While count = 0
        '    loadorderc = Loadorder.Items.Count
        '    Form3.ShowDialog()
        'End While
        'Dim y = WebCore.IsInitialized
        'For Each Dir As String In Directory.GetDirectories(folder &  sep & "mods" & sep )
        '    Dim file = shPath(Dir)
        '    Dim result = String.Compare(file, "Content")
        '    If result > 0 Or result < 0 Then
        '        If ModList.Items.Contains(file & ".dll") = False Then 'check to defend against double entries
        '            ModList.Items.Add(file & ".dll")
        '        End If
        '    End If
        'Next
        'ModList.Sorted = True
        'My.Computer.FileSystem.DeleteDirectory(appPath &  sep & "unpacked" & sep , FileIO.DeleteDirectoryOption.DeleteAllContents)
        'My.Computer.FileSystem.CreateDirectory(appPath &  sep & "unpacked" & sep )
    End Sub

    Private Sub delm_Click(sender As Object, e As EventArgs) Handles delm.Click
        Dim mIndex As Integer = ModList.SelectedIndex
        Dim mText = ""
        Dim deldir = ""
        Dim check As Integer = 0
        Dim tabi = Tab.SelectedIndex
        If tabi = 0 Then
            If mIndex < 0 Then
                mIndex = ModListd.SelectedIndex
                If mIndex < 0 Then
                    MsgBox("No Mod selected to delete.", MsgBoxStyle.OkOnly, "no mod selected")
                    Exit Sub
                End If
                mText = ModListd.Items(mIndex)
                check = 1
            Else
                mText = ModList.Items(mIndex)
            End If
            If mIndex >= 0 Then
                Dim Result As Integer = MsgBox("Are you sure that you want to delete the following mod: " & mText.ToString & "?", MsgBoxStyle.YesNo)
                If Result = DialogResult.Yes Then
                    If Path.GetExtension(mText.ToString) = ".dll" Then
                        If check = 0 Then

                            If IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & sep & "StardewValley" & sep & "Mods" & sep & Path.GetFileNameWithoutExtension(mText.ToString) & sep) Then
                                deldir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & sep & "StardewValley" & sep & "Mods" & sep & Path.GetFileNameWithoutExtension(mText.ToString)
                            Else
                                If IO.Directory.Exists(folder & sep & Path.GetFileNameWithoutExtension(mText.ToString) & sep & mText.ToString & sep) Then
                                    deldir = folder & sep & Path.GetFileNameWithoutExtension(mText.ToString)
                                    System.IO.File.Delete(deldir & mText.ToString)
                                    System.IO.Directory.Delete(deldir, True)
                                    ModList.Items.Remove(mText)
                                    Exit Sub
                                Else
                                    deldir = folder & sep & "Mods" & sep
                                End If
                            End If
                            System.IO.Directory.Delete(deldir & Path.GetFileNameWithoutExtension(mText.ToString) & sep, True)
                            Dim oldNumber = Loadorder.Items.Count
                            ModList.Items.Remove(mText)
                            Loadorder.Items.Remove(mText)
                            ModList.Refresh()
                            Loadorder.Refresh()
                            Dim newnumber = Loadorder.Items.Count
                            Dim help As Integer = mIndex
                            Do While (help < newnumber)
                                mText = Loadorder.Items(help)
                                ModList.Items.Remove(mText)
                                Loadorder.Items.Remove(mText)
                                Dim value As String = help + 2
                                Dim param() As String = mText.Split(value)
                                Dim mmir As String = ""
                                mmir = folder & sep & "Mods" & sep & Path.GetFileNameWithoutExtension(mText.ToString) & sep
                                Dim ndir As String = deldir & help + 1 & Path.GetFileNameWithoutExtension(param(1)) & sep
                                My.Computer.FileSystem.MoveDirectory(mmir, ndir, True)
                                ModList.Items.Add(help + 1 & param(1))
                                Loadorder.Items.Add(help + 1 & param(1))
                                help += 1
                            Loop
                        Else
                            mText = ModListd.Items(mIndex)
                            deldir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & sep & "StardewValley" & sep & "deactivatedMods" & sep & Path.GetFileNameWithoutExtension(mText.ToString) & sep
                            System.IO.Directory.Delete(deldir, True)
                            ModListd.Items.Remove(mText)
                        End If
                    Else
                        If Path.GetExtension(mText.ToString) = ".storm" Then
                            Dim mnew = Path.GetFileNameWithoutExtension(mText.ToString)
                            Dim split() = mnew.Split(".")
                            ' MsgBox(split(0) & "." & split(1))
                            If check = 0 Then
                                deldir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & sep & "StardewValley" & sep & "Mods" & sep & split(0)
                                System.IO.Directory.Delete(deldir, True)
                                ModList.Items.Remove(mText)
                                INI_WriteValueToFile("Storm", mText, Nothing, Application.UserAppDataPath & sep & "Storm.ini")
                            Else
                                deldir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & sep & "StardewValley" & sep & "deactivatedMods" & sep & split(0) & sep
                                System.IO.Directory.Delete(deldir, True)
                                ModListd.Items.Remove(mText)
                                INI_WriteValueToFile("Storm", mText, Nothing, Application.UserAppDataPath & sep & "Storm.ini")
                            End If
                        Else
                            '  deleteXNB(mText)
                        End If

                    End If
                Else
                    Exit Sub
                End If
                ModList.Sorted = True : ModListd.Sorted = True
            End If
        Else
            mIndex = XNBlist.SelectedIndex
            If mIndex < 0 Then
                MsgBox("No Mod selected to delete.", MsgBoxStyle.OkOnly, "no mod selected")
                Exit Sub
            End If
            mText = XNBlist.Items(mIndex)
            If MsgBox("Are you sure that  you want to delete: " & mText & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                deleteXNB(mText)
            End If
        End If
    End Sub

    Private Sub ModListd_dc(sender As Object, e As EventArgs) Handles ModListd.MouseDoubleClick
        Dim mIndex As Integer = ModListd.SelectedIndex
        Dim mText = ModListd.Items.Item(mIndex)
        If mIndex >= 0 Then
            Dim spath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & sep & "StardewValley" & sep & "deactivatedMods" & sep & Path.GetFileNameWithoutExtension(mText) & sep
            Dim tpath = folder & sep & "Mods" & sep & sep & Path.GetFileNameWithoutExtension(mText) & sep
            My.Computer.FileSystem.MoveDirectory(spath, tpath, True)
            ModListd.Items.Remove(mText)
            ModList.Items.Add(mText)
        End If
        ModList.Sorted = True : ModListd.Sorted = True
    End Sub

    Private Sub ModList_dc(sender As Object, e As EventArgs) Handles ModList.MouseDoubleClick
        Dim mIndex As Integer = ModList.SelectedIndex
        Dim mText = ModList.Items.Item(mIndex)
        Dim spath = ""
        Dim tpath = ""
        If mIndex >= 0 Then
            If Path.GetExtension(mText.ToString) = ".dll" Then

                spath = folder & sep & "Mods" & sep & Path.GetFileNameWithoutExtension(mText) & sep
                tpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & sep & "StardewValley" & sep & "deactivatedMods" & sep & Path.GetFileNameWithoutExtension(mText) & sep
                If (Not Directory.Exists(tpath)) Then
                    Directory.CreateDirectory(tpath)
                End If
                My.Computer.FileSystem.MoveDirectory(spath, tpath, True)
                ModList.Items.Remove(mText)
                ModListd.Items.Add(mText)
                ModList.Sorted = True : ModListd.Sorted = True
            Else
                MsgBox("Not yet possible, sorry!", MsgBoxStyle.Information)
            End If
        End If
    End Sub

    Private Sub XNBList_md(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles XNBlist.MouseDoubleClick
        '  MsgBox("hi")
        Dim mIndex As Integer = XNBlist.SelectedIndex
        Dim mText = XNBlist.Items.Item(mIndex)
        '   MsgBox(mText)
        If Path.GetExtension(mText.ToString) = ".xnb" Then
            'MsgBox("Right Button Clicked: " & mText.ToString)
            Dim arr() As String = IO.File.ReadAllLines(Application.UserAppDataPath & sep & "XNB.ini")
            For Each item As String In arr
                If item.Contains(mText.ToString) Then
                    Dim param() As String = item.Split("="c)
                    Dim defn = Path.GetFileNameWithoutExtension(param(0))
                    Dim xname = InputBox("Rename " & param(0) & " to: ", "Rename " & param(0), defn)
                    If xname IsNot "" Then
                        Dim help = INI_ReadValueFromFile("XNB Backup paths", param(0), "", Application.UserAppDataPath & sep & "XNB.ini")
                        My.Computer.FileSystem.MoveFile(appPath & sep & "Backup" & sep & param(0), appPath & sep & "Backup" & sep & xname & ".xnb", True)
                        INI_WriteValueToFile("XNB Backup paths", param(0), Nothing, Application.UserAppDataPath & sep & "XNB.ini")
                        INI_WriteValueToFile("XNB Backup paths", xname & ".xnb", help, Application.UserAppDataPath & sep & "XNB.ini")
                        XNBlist.Items.Add(xname & ".xnb")
                        XNBlist.Items.Remove(param(0))
                        ModList.Sorted = True : ModListd.Sorted = True : XNBlist.Sorted = True
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub checkSmapiUpdate()
        Dim c = 1
        Dim x As String = ""
        Try
            If My.Computer.Network.IsAvailable Then
                If File.Exists((MainForm.appPath & sep & "latest.json")) Then
                    File.Delete((MainForm.appPath & sep & "latest.json"))
                End If
                Dim jsonpath As String = (MainForm.appPath & sep & "latest.json")
                Dim client1 As New WebClient
                client1.Headers.Item("User-Agent") = "Mozilla/4.0"
                client1.DownloadFile("https://api.github.com/repos/Pathoschild/SMAPI/releases/latest", jsonpath)
                Dim client As New WebClient()
                Dim stream As Stream = client.OpenRead(jsonpath)
                Dim reader As New StreamReader(stream)
                Dim jsonData As String = reader.ReadToEnd
                reader.Close()

                Dim release As GitRelease = JsonConvert.DeserializeObject(Of GitRelease)(jsonData)
                Dim version = release.tag_name
                Dim nurl = release.assets(1).browser_download_url
                Dim fname = Path.GetFileName(nurl)
                c = 10
                Dim fnameoe As String = Path.GetFileNameWithoutExtension(fname)
                ' If (Not String.Compare(fnameoe, cSVersion)) = 0 Or notFound = 1 Then
                Dim result As Boolean = version = cSVersion
                If (result = False) Or notFound = 1 Then
                    If MsgBox("SMAPI Update Available! Do you want to install the update SMAPI now?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Or notFound = 1 Then
                        Dim myWebClient As New WebClient()
                        myWebClient.DownloadFile(nurl, fname)
                        c = 11
                        IO.File.Move(appPath & sep & fname, appPath & sep & "Update" & sep & fname)
                        INI_WriteValueToFile("SMAPI Details", "Version", fnameoe, Application.UserAppDataPath & sep & "SDVMM.ini")
                        Dim from As String = appPath & sep & "Update" & sep & fname
                        Dim fto As String = appPath & sep & "Update" & sep & fnameoe & sep
                        zip(from, fto, 1, False)
                        Dim moveto As String = ""
                        For Each Dir As String In Directory.GetDirectories(fto)
                            moveto = Dir + sep & "Windows" & sep
                        Next
                        My.Computer.FileSystem.MoveDirectory(moveto, folder, True)
                        cSVersion = INI_ReadValueFromFile("SMAPI Details", "Version", "SMAPI-0.37.1A", Application.UserAppDataPath & sep & "SDVMM.ini")
                        cSVersion = version
                        INI_WriteValueToFile("SMAPI Details", "Version", version, Application.UserAppDataPath & sep & "SDVMM.ini")
                        LabelSmapi.Text = version
                        If notFound = 1 Then
                            Skip = 1
                            notFound = 0
                        End If
                    End If
                End If
            Else
            End If
        Catch ex As Exception
            If MsgBox(ex.ToString, MsgBoxStyle.RetryCancel) = MsgBoxResult.Retry Then
                checkSDVMMUpdate()
            Else
                Skip = 1
            End If
        End Try
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Form2 As New INIForm
        Form2.ShowDialog()
    End Sub



    Private Sub ModList_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        If MsgBox("Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Close()
        Else
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Dim url = "https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=QCHX7GHVLJPJW"
        Process.Start(url)
        MsgBox("if the opening of the Browser fails just use this URL: " & url)


    End Sub



    Private Sub Loadorder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Loadorder.SelectedIndexChanged
        Dim tabi = Tab.SelectedIndex
        If tabi = 2 Then
            delm.Enabled = False
        Else
            delm.Enabled = True
        End If
    End Sub

    Private Sub up_Click(sender As Object, e As EventArgs) Handles up.Click

        Dim mIndex As Integer = Loadorder.SelectedIndex
        If mIndex > 0 Then
            Dim mText As String = Loadorder.Items(mIndex)
            ModList.Items.Remove(mText)
            Loadorder.Items.Remove(mText)
            ModList.Refresh()
            Loadorder.Refresh()
            Dim number = Loadorder.Items.Count
            Dim limit As String = mIndex
            Dim help
            help = Loadorder.Items(limit - 1)
            Loadorder.Items.Remove(mText)
            ModList.Items.Remove(mText)
            Loadorder.Items.Remove(help)
            ModList.Items.Remove(help)
            ModList.Refresh()
            Loadorder.Refresh()
            Dim spliter1 As String = limit + 1
            Dim param() As String = mText.Split(spliter1)
            Dim file1 = Path.GetFileNameWithoutExtension(limit & param(1))
            Loadorder.Items.Add(limit & param(1))
            ModList.Items.Add(limit & param(1))
            ModList.Refresh()
            Loadorder.Refresh()
            Dim param2() As String = help.Split(limit)
            Dim file2 = Path.GetFileNameWithoutExtension(spliter1 & param2(1))
            Loadorder.Items.Add(spliter1 & param2(1))
            ModList.Items.Add(spliter1 & param2(1))
            ModList.Refresh()
            Loadorder.Refresh()
            Dim olddir1 = ""
            Dim olddir2 = ""
            Dim newdir1 = folder & sep & "Mods" & sep & file1 & sep
            Dim newdir2 = folder & sep & "Mods" & sep & file2 & sep

            If IO.Directory.Exists(folder & sep & "Mods" & sep & Path.GetFileNameWithoutExtension(mText) & sep) Then

                olddir1 = folder & sep & "Mods" & sep & Path.GetFileNameWithoutExtension(mText) & sep
            Else
                olddir1 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & sep & "StardewValley" & sep & "Mods" & sep & Path.GetFileNameWithoutExtension(mText) & sep
            End If
            If IO.Directory.Exists(folder & sep & "Mods" & sep & Path.GetFileNameWithoutExtension(help) & sep) Then
                olddir2 = folder & sep & "Mods" & sep & Path.GetFileNameWithoutExtension(help) & sep
            Else
                olddir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & sep & "StardewValley" & sep & "Mods" & sep & Path.GetFileNameWithoutExtension(help) & sep
            End If
            My.Computer.FileSystem.MoveDirectory(olddir1, newdir1, True)
            My.Computer.FileSystem.MoveDirectory(olddir2, newdir2, True)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim mIndex As Integer = Loadorder.SelectedIndex
        Dim max = Loadorder.Items.Count - 1
        If mIndex < max Then
            Dim mText As String = Loadorder.Items(mIndex)
            ModList.Items.Remove(mText)
            Loadorder.Items.Remove(mText)
            ModList.Refresh()
            Loadorder.Refresh()
            Dim number = Loadorder.Items.Count
            Dim limit As String = mIndex
            Dim help
            help = Loadorder.Items(limit)
            Loadorder.Items.Remove(mText)
            ModList.Items.Remove(mText)
            Loadorder.Items.Remove(help)
            ModList.Items.Remove(help)
            ModList.Refresh()
            Loadorder.Refresh()
            Dim spliter1 As String = limit + 1
            Dim help3 As String = spliter1 + 1
            Dim param() As String = mText.Split(spliter1)
            Dim file1 = Path.GetFileNameWithoutExtension(help3 & param(1))
            Loadorder.Items.Add(help3 & param(1))
            ModList.Items.Add(help3 & param(1))
            ModList.Refresh()
            Loadorder.Refresh()
            Dim help2 As String = spliter1 + 1
            Dim param2() As String = help.Split(help2)
            Dim file2 = Path.GetFileNameWithoutExtension(help2 - 1 & param2(1))
            Loadorder.Items.Add(spliter1 & param2(1))
            ModList.Items.Add(spliter1 & param2(1))
            ModList.Refresh()
            Loadorder.Refresh()
            Dim olddir1 = ""
            Dim olddir2 = ""
            Dim newdir1 = folder & sep & "Mods" & sep & file1 & sep
            Dim newdir2 = folder & sep & "Mods" & sep & file2 & sep

            If IO.Directory.Exists(folder & sep & "Mods" & sep & Path.GetFileNameWithoutExtension(mText) & sep) Then

                olddir1 = folder & sep & "Mods" & sep & Path.GetFileNameWithoutExtension(mText) & sep
            Else
                olddir1 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & sep & "StardewValley" & sep & "Mods" & sep & Path.GetFileNameWithoutExtension(mText) & sep
            End If
            If IO.Directory.Exists(folder & sep & "Mods" & sep & Path.GetFileNameWithoutExtension(help) & sep) Then
                olddir2 = folder & sep & "Mods" & sep & Path.GetFileNameWithoutExtension(help) & sep
            Else
                olddir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & sep & "StardewValley" & sep & "Mods" & sep & Path.GetFileNameWithoutExtension(help) & sep
            End If
            My.Computer.FileSystem.MoveDirectory(olddir1, newdir1, True)
            My.Computer.FileSystem.MoveDirectory(olddir2, newdir2, True)
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles openModFolder.Click
        Process.Start(folder + "/Mods/")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles openDFolder.Click
        Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & sep & "StardewValley" & sep & "deactivatedMods" & sep)
    End Sub

    Private Sub ModList_dc(sender As Object, e As MouseEventArgs) Handles ModList.MouseDoubleClick

    End Sub

    Private Sub ModListd_dc(sender As Object, e As MouseEventArgs) Handles ModListd.MouseDoubleClick

    End Sub

    Private Sub Refresh_list(sender As Object, e As EventArgs) Handles refreshb.Click

    End Sub
End Class


