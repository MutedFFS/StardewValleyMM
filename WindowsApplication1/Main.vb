Imports System.IO

Module Main
    Public Sub Main()
        If (Not System.IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\StardewValley\Mods")) Then
            System.IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\StardewValley\Mods")
        End If
        If (Not System.IO.Directory.Exists(Application.UserAppDataPath & "\Update\")) Then
            System.IO.Directory.CreateDirectory(Application.UserAppDataPath & "\Update\")

        End If

        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New MainForm)

    End Sub

End Module
