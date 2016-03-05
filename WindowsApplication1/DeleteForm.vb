Public Class DeleteForm
    Dim amdir As New IO.DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\StardewValley\Mods")
    Dim dmdir As New IO.DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\StardewValley\deactivatedMods")
    Dim diar1 As IO.FileInfo() = amdir.GetFiles("*.dll")
    Dim diar2 As IO.FileInfo() = dmdir.GetFiles("*.dll")
    Dim dra As IO.FileInfo



    Private Sub DeleteForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each dra In diar1
            If DelList.Items.Contains(dra) = False Then
                DelList.Items.Add(dra)
            End If
        Next
        For i As Integer = 0 To DelList.Items.Count - 1
            DelList.SetItemChecked(i, True)
        Next
        For Each dra In diar2
            If DelList.Items.Contains(dra) = False Then
                DelList.Items.Add(dra)
            End If
        Next
    End Sub

    Private Sub DelList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DelList.SelectedIndexChanged
        For Each dra In diar1
            If DelList.Items.Contains(dra) = False Then
                DelList.Items.Add(dra)
            End If
        Next
        For i As Integer = 0 To DelList.Items.Count - 1
            DelList.SetItemChecked(i, True)
        Next
        For Each dra In diar2
            If DelList.Items.Contains(dra) = False Then
                DelList.Items.Add(dra)
            End If
        Next
    End Sub

    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click

        MsgBox("Are you sure you want to delete those Mods?", MsgBoxStyle.YesNo)
        If MsgBoxResult.Yes = True Then   ' User chose Yes.
            ' Perform some action.
        Else
            ' Perform some other action.
        End If

    End Sub
End Class