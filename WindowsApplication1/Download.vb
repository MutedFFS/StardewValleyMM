Public Class Download
    Dim appPath As String = Application.StartupPath()
    Dim mdir As New IO.DirectoryInfo(appPath & "\ModDB")
    Dim diar As IO.FileInfo() = mdir.GetFiles("*.ini")
    Dim dra As IO.FileInfo
    Dim Name = ""
    Dim Author = ""
    Dim Version = ""
    Dim Description = ""
    Dim url = ""
    Dim homepage = ""



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

    Sub download_startup() Handles Me.Load
        Button1.Enabled = False
        Button3.Enabled = False
        ModInfo.ReadOnly = True
        For Each dra In diar
            Mods.Items.Add(dra.Name)
        Next
    End Sub


    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Mods.SelectedIndexChanged
        ModInfo.Clear()
        Dim mindex = Mods.SelectedIndex
        Dim mtext = ""
        mtext = Mods.Items(mindex)
        Name = INI_ReadValueFromFile("Data", "Name", "", appPath & "\ModDB\" & mtext)
        Author = INI_ReadValueFromFile("Data", "Author", "", appPath & "\ModDB\" & mtext)
        Version = INI_ReadValueFromFile("Data", "Version", "", appPath & "\ModDB\" & mtext)
        Description = INI_ReadValueFromFile("Data", "Description", "", appPath & "\ModDB\" & mtext)
        url = INI_ReadValueFromFile("Data", "url", "", appPath & "\ModDB\" & mtext)
        homepage = INI_ReadValueFromFile("Data", "Homepage", "", appPath & "\ModDB\" & mtext)
        ModInfo.AppendText("Name: " & Name & Environment.NewLine)
        ModInfo.AppendText("Author: " & Author & Environment.NewLine)
        ModInfo.AppendText("Version: " & Version & Environment.NewLine)
        ModInfo.AppendText("Description: " & Description & Environment.NewLine)
        Button1.Enabled = True
        If homepage IsNot Nothing Then
            Button3.Enabled = True
        End If
    End Sub
End Class