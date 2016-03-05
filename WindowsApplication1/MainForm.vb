Imports System.IO

Public Class MainForm
    Dim smdir As New IO.DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\StardewValley\Mods")
    Dim diar1 As IO.FileInfo() = smdir.GetFiles("*.dll")
    Dim diar2 As IO.FileInfo() = smdir.GetFiles("*.xnb")
    Dim dra As IO.FileInfo
    Dim check1 = 0
    Dim folder = "C:\"
    Dim Sfolder = "C:\"
    Dim gog = 0


    Private Sub SDVMM_Startup() Handles Me.Activated
        If (Not System.IO.Directory.Exists("C:\Program Files (x86)\Steam\steamapps\common\Stardew Valley")) Then
            If (Not System.IO.Directory.Exists("C:\Program Files (x86)\Steam\steamapps\common\Stardew Valley")) Then
                If (Not System.IO.Directory.Exists("E:\Program Files (x86)\Steam\steamapps\common\Stardew Valley")) Then
                    If (Not System.IO.Directory.Exists("E:\Program Files (x86)\Steam\steamapps\common\Stardew Valley")) Then
                        If (Not System.IO.Directory.Exists("E:\Program Files (x86)\Steam\steamapps\common\Stardew Valley")) Then
                            If (Not System.IO.Directory.Exists("E:\Program Files (x86)\Steam\steamapps\common\Stardew Valley")) Then
                                Dim Result As Integer = MsgBox("Couldnt Find Stardew Valley, are you sure it is installed. If so please write in the official Forunpost. You browser will direclty get you to it if you press Yes.", MsgBoxStyle.YesNo)
                                If Result = DialogResult.Yes Then
                                    System.Diagnostics.Process.Start("http://community.playstarbound.com/threads/fairly-simple-mod-manager-batch-based.107663/")
                                End If
                            Else
                                folder = "E:\Games\Stardew Valley"
                                gog = 1
                            End If
                        Else
                            folder = "D:\Games\Stardew Valley"
                            gog = 1
                        End If
                    Else
                        folder = "C:\Games\Stardew Valley"
                        gog = 1
                    End If
                Else
                    folder = "E:\Program Files (x86)\Steam\steamapps\common\Stardew Valley"
                    Sfolder = "E:\Program Files (x86)\Steam"
                End If
            Else
                folder = "D:\Program Files (x86)\Steam\steamapps\common\Stardew Valley"
                Sfolder = "D:\Program Files (x86)\Steam"
            End If
        Else
            folder = "C:\Program Files (x86)\Steam\steamapps\common\Stardew Valley"
            Sfolder = "C:\Program Files (x86)\Steam"
        End If
        ModList.Items.Clear()
        For Each dra In diar1
            If ModList.Items.Contains(dra) = False Then
                ModList.Items.Add(dra)
            End If
        Next
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
                    System.IO.File.Copy(openFileDialog1.FileName, tdir)
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




    Private Sub delm_Click(sender As Object, e As EventArgs) Handles delm.Click
        Dim mIndex As Integer = ModList.SelectedIndex
        ' der Name des Eintrages zu einer brauchbaren Variable bringen 
        Dim mText = ModList.Items.Item(mIndex)
        Dim Result As Integer = MsgBox("are you sure that you want to delete: " & mText.ToString & "?", MsgBoxStyle.YesNo)
        If Result = DialogResult.Yes Then
            Dim deldir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\StardewValley\Mods\"
            System.IO.File.Delete(deldir & mText.ToString)
            ModList.Items.Remove(mIndex)
        End If
    End Sub

End Class
