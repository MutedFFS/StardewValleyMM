Imports System.IO

Module Main
    Public Sub Main()
        Dim appPath As String = Application.StartupPath()
        If (Not System.IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\StardewValley\Mods")) Then
            System.IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\StardewValley\Mods")
        End If
        If (Not System.IO.Directory.Exists(appPath & "\Update\")) Then
            System.IO.Directory.CreateDirectory(appPath & "\Update\")
        End If

        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New MainForm)

    End Sub

End Module
