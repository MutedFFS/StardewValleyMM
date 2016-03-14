Imports System.IO
Imports System.IO.Compression
Imports System.Net

Public Class MainForm
    Public Shared xpath As String = ""
    Public Shared Multiok = 0
    Public Shared Mulitcount = 0
    Public Shared Fname As String = ""
    Dim appPath As String = Application.StartupPath()
    Dim smdir As New IO.DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\StardewValley\Mods")
    Dim dmdir As New IO.DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\StardewValley\deactivatedMods")
    Dim diar1 As IO.FileInfo() = smdir.GetFiles("*.dll")
    Dim diar2 As IO.FileInfo() = dmdir.GetFiles("*.dll")
    Dim dra As IO.FileInfo
    Dim check1 = 0
    Public Shared folder = "C:\"
    Dim Sfolder = "C:\"
    Dim gog = 0
    Dim cSVersion = "0"
    Dim cVersion = "1.4e"
    Dim notFound = 0
    Dim Skip = 0
    Dim errorlv = 0


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

    Function shPath(mypath As String)
        Dim myPos As Integer
        Dim myFolder As String

        myPos = InStrRev(mypath, "\", -1, vbTextCompare)

        If myPos > 0 Then
            myFolder = Mid(mypath, myPos + 1)
            Return myFolder
        End If

    End Function


    Function UpdateSNAPI(url)
        My.Computer.Network.DownloadFile(url, appPath & "\Update\update.zip", "", "", True, 500, True)
        zip(appPath & "\Update\update.zip", appPath & "\Update\", 1, True)
    End Function

    Function Update()
        Try
            For Each foundFile As String In My.Computer.FileSystem.GetFiles(appPath & "\Update\", Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "*.*")
                Dim foundFileInfo As New System.IO.FileInfo(foundFile)
                Dim ext = Path.GetExtension(foundFile)
                If ext = ".dll" Then
                    errorlv = 1
                    My.Computer.FileSystem.MoveFile(foundFile, Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\StardewValley\Mods\" & foundFileInfo.Name, True)
                Else
                    errorlv = 2
                    My.Computer.FileSystem.MoveFile(foundFile, folder & "\" & foundFileInfo.Name, True)
                End If
            Next
            errorlv = 3
            System.IO.Directory.Delete(appPath & "\Update\", True)
            errorlv = 4
            System.IO.Directory.CreateDirectory(appPath & "\Update\")
            errorlv = 5
            While (Not System.IO.Directory.Exists(appPath & "\Update\"))
                errorlv = 6
                System.IO.Directory.CreateDirectory(appPath & "\Update\")
            End While
        Catch Ex As Exception
            MessageBox.Show("Cannot read file from disk! Errorlevel: " & errorlv)
        End Try
    End Function

    Function installXNB()
        Dim Form As New XNBForm
        'open XNB Form
        If Multiok = 0 Then
            Form.ShowDialog()
        End If
        'Parse folder from form
        Dim xtpath = XNBForm.XtFolder & "\" & Fname
        Dim name = shPath(XNBForm.XtFolder) & "-" & Fname
        My.Computer.FileSystem.MoveFile(xtpath, appPath & "\Backup\" & name, True)
        IO.File.Copy(xpath, xtpath)
        INI_WriteValueToFile("XNB Backup paths", name, xtpath, Application.UserAppDataPath & "\SDVMM.ini")
        If ModList.Items.Contains(name) = False Then
            ModList.Items.Add(name)
        End If
    End Function

    Function deleteXNB(name As String)
        Dim arr() As String = IO.File.ReadAllLines(Application.UserAppDataPath & "\SDVMM.ini")
        For Each item As String In arr
            If item.Contains("=") Then
                If item.Contains("Content") Then
                    If item.Contains(name) Then
                        Dim param() As String = item.Split("="c)
                        'MsgBox(param(0)) 'output the name
                        My.Computer.FileSystem.MoveFile(appPath & "\Backup\" & param(0), param(1), True)
                        INI_WriteValueToFile("XNB Backup paths", param(0), Nothing, Application.UserAppDataPath & "\SDVMM.ini")
                        ModList.Items.Remove(param(0))
                    End If

                End If
            End If
        Next

    End Function

    Function checkSDVMMUpdate()
        If My.Computer.Network.IsAvailable Then
            Try
                Dim url = "https://github.com/Yuukiw/StardewValleyMM/releases"
                If IO.File.Exists(appPath & "\Update\vcheck.txt") Then
                    IO.File.Delete(appPath & "\Update\vcheck.txt")
                End If
                My.Computer.Network.DownloadFile(url, appPath & "\Update\vcheck.txt")
                Dim file = Nothing
                Dim version = Nothing
                Dim arr() As String = IO.File.ReadAllLines(appPath & "\Update\vcheck.txt")
                For Each item As String In arr
                    If item.Contains("/SDVMM") Then
                        Dim param() As String = item.Split("/")
                        If file = Nothing Then
                            version = param(5)
                        End If
                    End If
                Next
                Dim p() As String = file.Split("e x e")
                MsgBox(p(0) & " " & p(1))
                Dim nurl = "https://github.com/yuukiw/StardewValleyMM/releases/download/" & version & "/SDVMM.exe"
                If (Not String.Compare(version, cVersion)) = 0 Then
                    If MsgBox("SMAPI Update found, do you want to Install it now?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        Dim myWebClient As New WebClient()
                        myWebClient.DownloadFile(nurl, "SDVMM.exe")
                    End If
                End If
            Catch ex As Exception
                MsgBox("Not able to connect to the Internet.")
            End Try

        Else
        End If
    End Function

    Function INI()
        MsgBox("Sorry, I could not detect your Stardew Valley installation path. But no worries we can fix this! Just answer the following prompts.", MsgBoxStyle.OkOnly, "Huston we have an Problem!")
        Dim IniF As New INIForm
        IniF.ShowDialog()
    End Function

    Function zip(zPath As String, dPath As String, mode As Integer, up As Boolean)
        If mode = 0 Then
            ZipFile.CreateFromDirectory(zPath, dPath)
        Else
            ZipFile.ExtractToDirectory(zPath, dPath)
            System.IO.File.Delete(zPath)
        End If
        If up = True Then
            Call Update()
        End If
    End Function
    '
    '               SUBS
    '

    'Launch Sub
    Private Sub SDVMM_Startup() Handles Me.Shown
        'fixing name error
        While System.IO.File.Exists(Application.UserAppDataPath & "\SDVNN.ini")
            My.Computer.FileSystem.MoveFile(Application.UserAppDataPath & "\SDVNN.ini", Application.UserAppDataPath & "\SDVMM.ini", True)
        End While

        'does the ini file exist?
        If (Not System.IO.File.Exists(Application.UserAppDataPath & "\SDVMM.ini")) Then
            Dim spath As String = "Program Files (x86)\Steam\steamapps\common\Stardew Valley"
            Dim sspath As String = "Program Files (x86)\Steam\"
            Dim gpath As String = "Games\Stardew Valley"
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
                        INI_WriteValueToFile("General", "GameFolder", Folder1, Application.UserAppDataPath & "\SDVMM.ini") 'writing variables to the ini
                        INI_WriteValueToFile("General", "SteamFolder", Drives.Name & sspath, Application.UserAppDataPath & "\SDVMM.ini") '^
                        INI_WriteValueToFile("General", "Good Old Game Version", gog, Application.UserAppDataPath & "\SDVMM.ini") '^
                        succses = True 'tell the if routine that a file i found
                        Exit For 'exit for loop
                    ElseIf System.IO.Directory.Exists(Folder2) Then
                        gog = 1 'same as above just the GoG variant
                        folder = Folder2
                        INI_WriteValueToFile("General", "GameFolder", Folder2, Application.UserAppDataPath & "\SDVMM.ini")
                        INI_WriteValueToFile("General", "Good Old Game Version", gog, Application.UserAppDataPath & "\SDVMM.ini")
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
            folder = INI_ReadValueFromFile("General", "GameFolder", "C:\", Application.UserAppDataPath & "\SDVMM.ini")
            Sfolder = INI_ReadValueFromFile("General", "SteamFolder", "C:\", Application.UserAppDataPath & "\SDVMM.ini")
            gog = INI_ReadValueFromFile("General", "Good Old Game Version", 0, Application.UserAppDataPath & "\SDVMM.ini")
            cSVersion = INI_ReadValueFromFile("SMAPI Details", "Version", "SMAPI_0.37.1A", Application.UserAppDataPath & "\SDVMM.ini")
        End If
        If (Not System.IO.File.Exists(folder & "\StardewModdingAPI.exe")) Then 'does smapi exist? if no:
            If MsgBox("SMAPI does not appear to be installed, should i install it?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then 'ask the user if he would like to install it.If yes:
                notFound = 1 'change variable to tell the subroutine that it can just install the update even if the a version number exist
                checkSmapiUpdate() 'call sub routine
            Else 'if no
                LSMAPI.Enabled = False 'deactivate the button
            End If
        End If
        If Skip = 0 Then 'this is only 1 if the subroutine was run with the parameter not found = 1, this is to tell the programm that it doenst need to check twice
            checkSmapiUpdate()
        End If
        If (Not System.IO.File.Exists(folder & "\StormLoader.exe")) Then 'same as with smapi. not implemented since it isnt Storm isnt really useable for the normal user imo. But it will detect it
            ' If MsgBox("Couldnt Find SMAPI, should i install it?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            'notFound = 1
            'checkSmapiUpdate()
            'Else
            '  LSMAPI.Enabled = False
            'End If
            LStorm.Enabled = False 'if not  disable the button
        End If
        '  checkSDVMMUpdate() ' here he should check for an update of the mod manager but not yet implemented
        ModList.Items.Clear() ' clea the modlists. While they should be empty anyways i still want to be sure
        ModListd.Items.Clear()
        For Each dra In diar1 ' reads all smapi dlls.
            If ModList.Items.Contains(dra) = False Then 'check to defend against double entries
                ModList.Items.Add(dra)
            End If
        Next
        Dim arr2() As String = IO.File.ReadAllLines(Application.UserAppDataPath & "\SDVMM.ini") 'reads all storm mods
        For Each item As String In arr2
            If item.Contains("=") Then
                If item.Contains(".storm") Then
                    Dim param() As String = item.Split("=")
                    Dim file() = param(0).Split(".")
                    If IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\StardewValley\Mods\" & file(0) & "\") Then
                        ModList.Items.Add(param(0))
                    Else
                        ModListd.Items.Add(param(0))
                    End If
                End If
            End If
        Next
        Dim arr() As String = IO.File.ReadAllLines(Application.UserAppDataPath & "\SDVMM.ini") 'reads all XNB Mods
        For Each item As String In arr
            If item.Contains("=") Then
                If item.Contains("Content") Then
                    Dim param() As String = item.Split("="c)
                    If IO.File.Exists(appPath & "\Backup\" & param(0)) Then
                        ModList.Items.Add(param(0))
                    Else
                        INI_WriteValueToFile("XNB Backup paths", param(0), Nothing, Application.UserAppDataPath & "\SDVMM.ini")
                    End If

                End If
            End If
        Next
        For Each dra In diar2 ' reads all deactivated mods
            If ModListd.Items.Contains(dra) = False Then
                ModListd.Items.Add(dra)
            End If
        Next
        LabelSmapi.Text = "SMAPI Version: " & cSVersion
        LabelSD.Text = "SDVMM Version: " & cVersion
    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim Result As Integer = MsgBox("The SDVMM forum topic will be opened in your web browser, do you wish to proceed?", MsgBoxStyle.YesNo)
        If Result = DialogResult.Yes Then
            System.Diagnostics.Process.Start("http://community.playstarbound.com/threads/fairly-simple-mod-manager-batch-based.107663/")
        End If
    End Sub

    Private Sub LSMAPI_Click(sender As Object, e As EventArgs) Handles LSMAPI.Click
        Try
            Shell("cmd.exe /c" + "cd /d " & folder & "& call " + """" & folder & "\StardewModdingAPI.exe" & """")
        Catch ex As Exception
            MsgBox("Could not Launch Smapi! Please check if the path is correct? Path: " & folder)
        End Try
    End Sub

    Private Sub LStorm_Click(sender As Object, e As EventArgs) Handles LStorm.Click
        Try

            Shell("cmd.exe /c" + "cd /d " & folder & "& call " + """" & folder & "\StormLoader.exe" & """")
            Process.Start(folder & "\StormLoader.exe")
        Catch ex As Exception
            MsgBox("Could not Launch Storm API! Please check if the path is corect? Path: " & folder)
        End Try
    End Sub

    Private Sub LSDV_Click(sender As Object, e As EventArgs) Handles LSDV.Click
        Try
            If gog = 1 Then
                Process.Start(folder & "\Stardew Valley.exe")
            Else
                Process.Start(Sfolder & "\Steam.exe", "-applaunch 413150")
            End If
        Catch ex As Exception
            If gog = 1 Then
                MsgBox("Could not Launch Smapi! Please check if the path is correct? Path: " & folder)
            Else
                MsgBox("Could not Launch Smapi! Please check if the path is correct? Path: " & Sfolder)
            End If
        End Try

    End Sub


    Private Sub AddMod_Click(sender As Object, e As EventArgs) Handles addm.Click
        Dim myStream As Stream = Nothing
        Dim openFileDialog1 As New OpenFileDialog()
        Dim ddir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\StardewValley\Mods\"
        openFileDialog1.InitialDirectory = "c:\"
        openFileDialog1.Filter = "SMAPI Mod files (*.dll)|*.dll|XNB Mods (*.XNB)|*.xnb|SMAPI MOD Ini(*.ini)|*.ini|All|*.*"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.Title = "Select SMAPI-Mod"
        openFileDialog1.RestoreDirectory = True
        openFileDialog1.Multiselect = True
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                myStream = openFileDialog1.OpenFile()
                If myStream IsNot Nothing Then
                    For Each s As String In openFileDialog1.FileNames
                        Mulitcount += 1
                    Next
                    For Each s As String In openFileDialog1.FileNames
                        Fname = Path.GetFileName(s)
                        Dim tdir = ddir & Path.GetFileName(s)
                        Dim ext = Path.GetExtension(s)
                        If ext = ".xnb" Then
                            xpath = s
                            installXNB()
                        Else
                            IO.File.Copy(s, tdir, True)
                            If ModList.Items.Contains(Path.GetFileName(s)) = False Then
                                If Path.GetExtension(Path.GetExtension(s)) = ".ini" Then
                                Else
                                    ModList.Items.Add(Path.GetFileName(s))
                                End If
                            End If
                        End If
                    Next
                    Multiok = 0
                    Mulitcount = 0
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

    Private Sub ASM_Click(sender As Object, e As EventArgs) Handles ASM.Click
        Dim myStream As Stream = Nothing
        Dim openFileDialog1 As New OpenFileDialog()
        Dim ddir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\StardewValley\Mods\"
        openFileDialog1.InitialDirectory = "c:\"
        openFileDialog1.Filter = "Storm Mod files (*.dll)|*.dll"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.Title = "Select Storm-Mod"
        openFileDialog1.RestoreDirectory = True
        openFileDialog1.Multiselect = False
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                myStream = openFileDialog1.OpenFile()
                If myStream IsNot Nothing Then
                    Dim Folder = Path.GetDirectoryName(openFileDialog1.FileName) & "\"
                    ddir = ddir & Path.GetFileNameWithoutExtension(openFileDialog1.FileName) & "\"
                    Dim fname = Path.GetFileName(openFileDialog1.FileName)
                    If (Not IO.Directory.Exists(ddir)) Then
                        IO.Directory.CreateDirectory(ddir)
                    End If
                    For Each s In Directory.GetFiles(Folder, "*.*", SearchOption.TopDirectoryOnly)
                        Dim sname = Path.GetFileName(s)
                        My.Computer.FileSystem.CopyFile(s, ddir & sname, True)
                    Next
                    My.Computer.FileSystem.CopyDirectory(Folder, ddir, True)
                    'My.Computer.FileSystem.DeleteDirectory(Folder, FileIO.DeleteDirectoryOption.DeleteAllContents)
                    Dim addname = fname & ".storm"
                    ' MsgBox(Path.GetExtension(addname))
                    ' MsgBox(addname)
                    If ModList.Items.Contains(Path.GetFileName(addname)) = False Then
                        ModList.Items.Add(Path.GetFileName(addname))
                    End If
                    INI_WriteValueToFile("Storm", addname, fname, Application.UserAppDataPath & "\SDVMM.ini")
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

    Private Sub dlm_Click(sender As Object, e As EventArgs) Handles dlm.Click
        Dim Result As Integer = MsgBox("The Stardew Valley Mod forum will be opened in your web browser, do you wish to proceed?", MsgBoxStyle.YesNo)
        If Result = DialogResult.Yes Then
            System.Diagnostics.Process.Start("http://community.playstarbound.com/forums/mods.215/")
        End If
    End Sub

    Private Sub delm_Click(sender As Object, e As EventArgs) Handles delm.Click
        Dim mIndex As Integer = ModList.SelectedIndex
        Dim mText = ModList.Items(1)
        Dim check As Integer = 0
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
                        Dim deldir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\StardewValley\Mods\"
                        System.IO.File.Delete(deldir & mText.ToString)
                        ModList.Items.Remove(mText)
                    Else
                        Dim deldir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\StardewValley\deactivatedMods\"
                        System.IO.File.Delete(deldir & mText.ToString)
                        ModListd.Items.Remove(mText)
                    End If

                Else
                    If Path.GetExtension(mText.ToString) = ".storm" Then
                        Dim mnew = Path.GetFileNameWithoutExtension(mText.ToString)
                        Dim split() = mnew.Split(".")
                        ' MsgBox(split(0) & "." & split(1))
                        If check = 0 Then
                            Dim deldir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\StardewValley\Mods\" & split(0) & "\"
                            System.IO.Directory.Delete(deldir, True)
                            ModList.Items.Remove(mText)
                            INI_WriteValueToFile("Storm", mText, Nothing, Application.UserAppDataPath & "\SDVMM.ini")
                        Else
                            Dim deldir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\StardewValley\deactivatedMods\" & split(0) & "\"
                            System.IO.Directory.Delete(deldir, True)
                            ModListd.Items.Remove(mText)
                            INI_WriteValueToFile("Storm", mText, Nothing, Application.UserAppDataPath & "\SDVMM.ini")
                        End If
                    Else
                        deleteXNB(mText)
                    End If

                End If
            Else
                Exit Sub
            End If
        End If

    End Sub

    Private Sub ModListd_dc(sender As Object, e As EventArgs) Handles ModListd.DoubleClick
        Dim mIndex As Integer = ModListd.SelectedIndex
        Dim mText = ModListd.Items.Item(mIndex)
        If mIndex >= 0 Then
            If Path.GetExtension(mText.ToString) = ".storm" Then
                Dim mnew = Path.GetFileNameWithoutExtension(mText.ToString)
                Dim split() = mnew.Split(".")
                Dim name = split(0) & "." & split(1)
                Dim spath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\StardewValley\deactivatedMods\" & split(0) & "\"
                Dim tpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\StardewValley\Mods\" & split(0) & "\"
                My.Computer.FileSystem.MoveDirectory(spath, tpath)
                ModListd.Items.Remove(mText)
                ModList.Items.Add(mText)
            Else
                Dim spath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\StardewValley\deactivatedMods\" & mText.ToString
                Dim tpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\StardewValley\Mods\" & mText.ToString
                My.Computer.FileSystem.MoveFile(spath, tpath, True)
                ModListd.Items.Remove(mText)
                ModList.Items.Add(mText)
            End If
        End If
    End Sub

    Private Sub ModList_dc(sender As Object, e As EventArgs) Handles ModList.DoubleClick
        Dim mIndex As Integer = ModList.SelectedIndex
        Dim mText = ModList.Items.Item(mIndex)
        If mIndex >= 0 Then
            If Path.GetExtension(mText.ToString) = ".dll" Then
                Dim spath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\StardewValley\Mods\" & mText.ToString
                Dim tpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\StardewValley\deactivatedMods\" & mText.ToString
                My.Computer.FileSystem.MoveFile(spath, tpath)
                ModList.Items.Remove(mText)
                ModListd.Items.Add(mText)
            Else
                If Path.GetExtension(mText.ToString) = ".storm" Then
                    Dim mnew = Path.GetFileNameWithoutExtension(mText.ToString)
                    Dim split() = mnew.Split(".")
                    Dim name = split(0) & "." & split(1)
                    Dim spath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\StardewValley\Mods\" & split(0) & "\"
                    Dim tpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\StardewValley\deactivatedMods\" & split(0) & "\"
                    My.Computer.FileSystem.MoveDirectory(spath, tpath)
                    ModList.Items.Remove(mText)
                    ModListd.Items.Add(mText)
                Else
                    MsgBox("Not yet possible, sorry!", MsgBoxStyle.Information)
                End If

            End If
        End If
    End Sub

    Private Sub checkSmapiUpdate()
        If System.IO.File.Exists(appPath & "\Update\StardewModdingAPI.exe") Then
            If MsgBox("SMAPI Update Available! Do you want to download the update SMAPI now?", MsgBoxStyle.YesNo) = DialogResult.Yes Then
                Call Update()
            End If
        End If

        If IO.Directory.Exists(appPath & "\Update\") Then
            Dim Check = Directory.GetFiles(appPath & "\Update\", "*.zip")
            If Check.Length = 1 Then
                If MsgBox("SMAPI Update Available! Do you want to download the update SMAPI now?", MsgBoxStyle.YesNo) = DialogResult.Yes Then
                    Dim fileEntries As String() = Directory.GetFiles(appPath & "\Update\", "*.zip")
                    Dim sOnlyFileName As String
                    For Each sFileName In fileEntries
                        sOnlyFileName = System.IO.Path.GetFileName(sFileName)
                    Next
                    zip(appPath & "\Update\" & sOnlyFileName, appPath & "\Update\", 1, True)
                End If
            End If
        End If

        If My.Computer.Network.IsAvailable Then
            Dim url = "https://github.com/ClxS/SMAPI/releases"
            If IO.File.Exists(appPath & "\Update\vcheck.txt") Then
                IO.File.Delete(appPath & "\Update\vcheck.txt")
            End If
            My.Computer.Network.DownloadFile(url, appPath & "\Update\vcheck.txt")
            Dim file = Nothing
            Dim version = Nothing
            Dim arr() As String = IO.File.ReadAllLines(appPath & "\Update\vcheck.txt")
            For Each item As String In arr
                If item.Contains("/SMAPI_") Then
                    Dim param() As String = item.Split("/")
                    If file = Nothing Then
                        file = param(1) & "/" & param(2) & "/" & param(3) & "/" & param(4) & "/" & param(5) & "/" & param(6)
                        version = param(5)
                    End If
                End If
            Next
            Dim p() As String = file.Split("zip")
            Dim nurl = "https://github.com/" & p(0) & "zip"
            Dim fname = Path.GetFileName(nurl)
            Dim fnameoe As String = Path.GetFileNameWithoutExtension(nurl)
            ' If (Not String.Compare(fnameoe, cSVersion)) = 0 Or notFound = 1 Then
            If Not (fnameoe = cSVersion) Or notFound = 1 Then
                If MsgBox("SMAPI Update Available! Do you want to install the update SMAPI now?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Or notFound = 1 Then
                    Dim myWebClient As New WebClient()
                    myWebClient.DownloadFile(nurl, fname)
                    IO.File.Move(appPath & "\" & fname, appPath & "\Update\" & fname)
                    INI_WriteValueToFile("SMAPI Details", "Version", fnameoe, Application.UserAppDataPath & "\SDVMM.ini")
                    zip(appPath & "\Update\" & fname, appPath & "\Update\", 1, True)
                    If notFound = 1 Then
                        Skip = 1
                        notFound = 0
                    End If
                End If
            End If
        Else
        End If
    End Sub

 

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Form2 As New INIForm
        Form2.ShowDialog()
    End Sub

    Private Sub LabelSD_Click(sender As Object, e As EventArgs) Handles LabelSD.Click

    End Sub
End Class
