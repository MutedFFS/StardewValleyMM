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
    Dim cVersion = "1.4a"
    Dim notFound = 0
    Dim Skip = 0


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
        INI_WriteValueToFile("XNB Backup paths", name, xtpath, Application.UserAppDataPath & "\SDVNN.ini")
        If ModList.Items.Contains(name) = False Then
            ModList.Items.Add(name)
        End If
    End Function

    Function deleteXNB(name As String)
        Dim arr() As String = IO.File.ReadAllLines(Application.UserAppDataPath & "\SDVNN.ini")
        For Each item As String In arr
            If item.Contains("=") Then
                If item.Contains("Content") Then
                    If item.Contains(name) Then
                        Dim param() As String = item.Split("="c)
                        'MsgBox(param(0)) 'output the name
                        My.Computer.FileSystem.MoveFile(appPath & "\Backup\" & param(0), param(1), True)
                        INI_WriteValueToFile("XNB Backup paths", param(0), Nothing, Application.UserAppDataPath & "\SDVNN.ini")
                        ModList.Items.Remove(param(0))
                    End If

                End If
            End If
        Next

    End Function

    Function checkSDVMMUpdate()
        If My.Computer.Network.IsAvailable Then
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
        Else
        End If
    End Function

    Function INI()
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
            INI_WriteValueToFile("SMAPI Details", "Version", "SMAPI_0.37.1A", Application.UserAppDataPath & "\SDVNN.ini")
        Else
            folder = INI_ReadValueFromFile("General", "GameFolder", "C:\", Application.UserAppDataPath & "\SDVNN.ini")
            Sfolder = INI_ReadValueFromFile("General", "SteamFolder", "C:\", Application.UserAppDataPath & "\SDVNN.ini")
            gog = INI_ReadValueFromFile("General", "Good Old Game Version", 0, Application.UserAppDataPath & "\SDVNN.ini")
            cSVersion = INI_ReadValueFromFile("SMAPI Details", "Version", "SMAPI_0.37.1A", Application.UserAppDataPath & "\SDVNN.ini")
        End If
        If (Not System.IO.File.Exists(folder & "\StardewModdingAPI.exe")) Then
            If MsgBox("Couldnt Find SMAPI, should i install it?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                notFound = 1
                checkSmapiUpdate()
            Else
                LSMAPI.Enabled = False
            End If
        End If
        If Skip = 0 Then
            checkSmapiUpdate()
        End If
        If (Not System.IO.File.Exists(folder & "\StormLoader.exe")) Then
            ' If MsgBox("Couldnt Find SMAPI, should i install it?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            'notFound = 1
            'checkSmapiUpdate()
            'Else
            '  LSMAPI.Enabled = False
            'End If
            LStorm.Enabled = False
        End If

        '  checkSDVMMUpdate()
        ModList.Items.Clear()
        For Each dra In diar1
            If ModList.Items.Contains(dra) = False Then
                ModList.Items.Add(dra)
            End If
        Next
        Dim arr2() As String = IO.File.ReadAllLines(Application.UserAppDataPath & "\SDVNN.ini")
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
        Dim arr() As String = IO.File.ReadAllLines(Application.UserAppDataPath & "\SDVNN.ini")
        For Each item As String In arr
            If item.Contains("=") Then
                If item.Contains("Content") Then
                    Dim param() As String = item.Split("="c)
                    ModList.Items.Add(param(0))
                End If
            End If
        Next
        For Each dra In diar2
            If ModListd.Items.Contains(dra) = False Then
                ModListd.Items.Add(dra)
            End If
        Next
        LabelSmapi.Text = "SMAPI Version: " & cSVersion
        LabelSD.Text = "SDVMM Version: " & cVersion
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

    Private Sub LStorm_Click(sender As Object, e As EventArgs) Handles LStorm.Click
        Shell("cmd.exe /c" + "cd /d " & folder & "& call " + """" & folder & "\StormLoader.exe" & """")
        Process.Start(folder & "\StormLoader.exe")
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
                            IO.File.Copy(s, tdir)
                            If ModList.Items.Contains(Path.GetFileName(s)) = False Then
                                ModList.Items.Add(Path.GetFileName(s))
                            End If
                        End If
                    Next
                    Multiok = 0
                    Mulitcount = 0
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
                    INI_WriteValueToFile("Storm", addname, fname, Application.UserAppDataPath & "\SDVNN.ini")
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

    Private Sub delm_Click(sender As Object, e As EventArgs) Handles delm.Click
        Dim mIndex As Integer = ModList.SelectedIndex
        Dim mText = ModList.Items(1)
        Dim check As Integer = 0
        If mIndex < 0 Then
            mIndex = ModListd.SelectedIndex
            If mIndex < 0 Then
                MsgBox("No Mod to delete selected.", MsgBoxStyle.OkOnly, "no mod selected")
                Exit Sub
            End If
            mText = ModListd.Items(mIndex)
            check = 1
        Else
            mText = ModList.Items(mIndex)
        End If
        If mIndex >= 0 Then

            Dim Result As Integer = MsgBox("are you sure that you want to delete: " & mText.ToString & "?", MsgBoxStyle.YesNo)
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
                            INI_WriteValueToFile("Storm", mText, Nothing, Application.UserAppDataPath & "\SDVNN.ini")
                        Else
                            Dim deldir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\StardewValley\deactivatedMods\" & split(0) & "\"
                            System.IO.Directory.Delete(deldir, True)
                            ModListd.Items.Remove(mText)
                            INI_WriteValueToFile("Storm", mText, Nothing, Application.UserAppDataPath & "\SDVNN.ini")
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
                My.Computer.FileSystem.MoveFile(spath, tpath)
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
            If MsgBox("Found  Updated Files, do you want to update SMAPI now?", MsgBoxStyle.YesNo) = DialogResult.Yes Then
                Call Update()
            End If
        End If

        If IO.Directory.Exists(appPath & "\Update\") Then
            Dim Check = Directory.GetFiles(appPath & "\Update\", "*.zip")
            If Check.Length = 1 Then
                If MsgBox("Found  Updated Files, do you want to update SMAPI now?", MsgBoxStyle.YesNo) = DialogResult.Yes Then
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
                If MsgBox("SMAPI Update found, do you want to Install it now?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Or notFound = 1 Then
                    Dim myWebClient As New WebClient()
                    myWebClient.DownloadFile(nurl, fname)
                    IO.File.Move(appPath & "\" & fname, appPath & "\Update\" & fname)
                    INI_WriteValueToFile("SMAPI Details", "Version", fnameoe, Application.UserAppDataPath & "\SDVNN.ini")
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

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
