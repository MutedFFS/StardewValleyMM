Imports System.IO

Module Main
    Public Sub Main()
        Dim x = 2
        If x = 1 Then 'bugged as of now
            If (Not System.IO.Directory.Exists("C:\Program Files (x86)\Steam\steamapps\common\Stardew Valley\StardewModdingAPI.exe")) Then
                If (Not System.IO.Directory.Exists("D:\\Program Files (x86)\Steam\steamapps\common\Stardew Valley\StardewModdingAPI.exe")) Then
                    If (Not System.IO.Directory.Exists("E:\\Program Files (x86)\Steam\steamapps\common\Stardew Valley\StardewModdingAPI.exe")) Then
                        Dim Result As Integer = MsgBox("Couldnt Find SMAPI, please install it yourself or Place the unpacked Files in an Folder called mods and Press yes in the Folowing Dialog", MsgBoxStyle.YesNo)
                        If Result = DialogResult.Yes Then
                            System.IO.File.Move(Application.UserAppDataPath & "Mods\*.*", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\StardewValley\")
                        End If
                    End If
                End If
            End If
        End If

        If (Not System.IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\StardewValley\Mods")) Then
            System.IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\StardewValley\Mods")
        End If

        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New MainForm)

    End Sub

End Module
