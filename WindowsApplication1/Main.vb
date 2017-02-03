Imports System.IO

Module Main

    Public ReadOnly PathSeparator As Char
    Public sep = Path.DirectorySeparatorChar

    Dim appPath As String = Application.StartupPath()
    Dim smdir As New IO.DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & sep & "StardewValley" & sep & "Mods")
    Dim dmdir As New IO.DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & sep & "StardewValley" & sep & "deactivatedMods")
    Dim xmdir As New IO.DirectoryInfo(appPath & sep & "Backup")
    Dim diar1 As IO.FileInfo() = smdir.GetFiles("*.dll")
    Dim diar2 As IO.FileInfo() = dmdir.GetFiles("*.dll")
    Dim diar3 As IO.FileInfo() = xmdir.GetFiles("*.xnb")
    Dim dra As IO.FileInfo

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



    Public Sub Main()
        Dim appPath As String = Application.StartupPath()
        Dim errcode As Integer = 0
        '   Try
        errcode = 1
        If (Not System.IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & sep & "StardewValley" & sep & "Mods")) Then
            System.IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & sep & "StardewValley" & sep & "Mods")
        End If
        errcode = 2
        If (Not System.IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & sep & "StardewValley" & sep & "deactivatedMods")) Then
            System.IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & sep & "StardewValley" & sep & "deactivatedMods")
        End If
        errcode = 3
        If (System.IO.Directory.Exists(appPath & sep & "Update" & sep)) Then
            IO.Directory.Delete(appPath & sep & "Update" & sep, True)
        End If
        If (Not System.IO.Directory.Exists(appPath & sep & "Update" & sep)) Then
            System.IO.Directory.CreateDirectory(appPath & sep & "Update" & sep)
        End If
        errcode = 4
        If (Not System.IO.Directory.Exists(appPath & sep & "Backup" & sep)) Then
            System.IO.Directory.CreateDirectory(appPath & sep & "Backup" & sep)
        End If

        errcode = 5
        While System.IO.File.Exists(Application.UserAppDataPath & sep & "SDVNN.ini")
            My.Computer.FileSystem.MoveFile(Application.UserAppDataPath & sep & "SDVNN.ini", Application.UserAppDataPath & sep & "SDVMM.ini", True)
        End While
        'does the ini file exist?
        errcode = 6
        If (Not System.IO.File.Exists(Application.UserAppDataPath & sep & "XNB.ini") And System.IO.File.Exists(Application.UserAppDataPath & sep & "SDVMM.ini")) Then
            errcode = 7
            INI_WriteValueToFile("XNB Backup Paths", Nothing, Nothing, Application.UserAppDataPath & sep & "XNB.ini")
            INI_WriteValueToFile("Storm", Nothing, Nothing, Application.UserAppDataPath & sep & "Storm.ini")
            errcode = 8
            For Each dra In diar3
                Dim value = ""
                value = INI_ReadValueFromFile("XNB Backup paths", dra.Name, "no", Application.UserAppDataPath & sep & "SDVMM.ini")
                INI_WriteValueToFile("XNB Backup Paths", dra.Name, value, Application.UserAppDataPath & sep & "XNB.ini")
                INI_WriteValueToFile("XNB Backup paths", dra.Name, Nothing, Application.UserAppDataPath & sep & "SDVMM.ini")
            Next
            errcode = 9
            Dim arr3() As String = IO.File.ReadAllLines(Application.UserAppDataPath & sep & "SDVMM.ini") 'reads all storm mods
            For Each item As String In arr3
                If item.Contains("=") Then
                    If item.Contains(".storm") Then
                        Dim param() As String = item.Split("=")
                        Dim file() As String = param(0).Split(".")
                        errcode = 10
                        INI_ReadValueFromFile("Strom", param(0), Nothing, Application.UserAppDataPath & sep & "SDVMM.ini")
                        INI_WriteValueToFile("Storm", param(0), file(0) & "." & file(1), Application.UserAppDataPath & sep & "Storm.ini")
                        INI_WriteValueToFile("XNB Backup paths", dra.Name, Nothing, Application.UserAppDataPath & sep & "SDVMM.ini")
                    End If
                End If
            Next
        End If
        If (Not System.IO.Directory.Exists(appPath & sep & "unpacked" & sep)) Then
            System.IO.Directory.CreateDirectory(appPath & sep & "unpacked" & sep)
        End If
        errcode = 11
        Application.EnableVisualStyles()
        errcode = 12
        Application.SetCompatibleTextRenderingDefault(False)
        errcode = 13
        Application.Run(New MainForm)

        '  Catch ex As Exception
        '     MsgBox("Failed to Launch! Errorcode:" & errcode)
        '  End Try
    End Sub

End Module
