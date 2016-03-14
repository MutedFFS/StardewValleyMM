Imports System.IO

Public Class XNBForm
    Public Shared XtFolder
    Dim cb1 = MainForm.Multiok
    Dim mc = MainForm.Mulitcount
    Dim ffolder = MainForm.xpath
    Dim gfolder = MainForm.folder

    Private Sub XNB_Startup() Handles Me.Shown
        If mc <= 1 Then
            CheckBox1.Enabled = False
        End If
        If cb1 = 1 Then
            Close()
        End If
        CoBo.Items.Add(New MyListItem("Please Select", "noValue"))
        CoBo.Items.Add(New MyListItem("general content", gfolder & "\Content"))
        CoBo.Items.Add(New MyListItem("Animal", gfolder & "\Content\Animals"))
        CoBo.Items.Add(New MyListItem("Buildings", gfolder & "\Content\Buildings"))
        CoBo.Items.Add(New MyListItem("character - General (no Portraits)", gfolder & "\Content\Characters"))
        CoBo.Items.Add(New MyListItem("character - Dialogue - general", gfolder & "\Content\Characters\Dialogue"))
        CoBo.Items.Add(New MyListItem("character - Dialogue - fall", gfolder & "\Content\Characters\Dialogue\fall"))
        CoBo.Items.Add(New MyListItem("character - Dialogue - spring", gfolder & "\Content\Characters\Dialogue\spring"))
        CoBo.Items.Add(New MyListItem("character - Dialogue - summer", gfolder & "\Content\Characters\Dialogue\summer"))
        CoBo.Items.Add(New MyListItem("character - Dialogue - winter", gfolder & "\Content\Characters\Dialogue\winter"))
        CoBo.Items.Add(New MyListItem("character - Farmer (clothes, accsessoires,hats, etc)", gfolder & "\Content\Characters\Farmer"))
        CoBo.Items.Add(New MyListItem("character - Monster", gfolder & "\Content\Characters\Monsters"))
        CoBo.Items.Add(New MyListItem("character - shedules - general", gfolder & "\Content\Characters\schedules"))
        CoBo.Items.Add(New MyListItem("character - shedules - spring", gfolder & "\Content\Characters\schedules\spring"))
        CoBo.Items.Add(New MyListItem("Data - general", gfolder & "\Content\Data"))
        CoBo.Items.Add(New MyListItem("Data - Events", gfolder & "\Content\Data\Events"))
        CoBo.Items.Add(New MyListItem("Data - Festivals", gfolder & "\Content\Data\Festivals"))
        CoBo.Items.Add(New MyListItem("Data - TV", gfolder & "\Content\Data\TV"))
        CoBo.Items.Add(New MyListItem("Fonts", gfolder & "\Content\Fonts"))
        CoBo.Items.Add(New MyListItem("Loose Sprites", gfolder & "\Content\LooseSprites"))
        CoBo.Items.Add(New MyListItem("Loose Sprites - Lighting", gfolder & "\Content\LooseSprites\Lighting"))
        CoBo.Items.Add(New MyListItem("Maps - general", gfolder & "\Content\Maps"))
        CoBo.Items.Add(New MyListItem("Maps - Mines", gfolder & "\Content\Maps\Mines"))
        CoBo.Items.Add(New MyListItem("Mines (different Folder)", gfolder & "\Content\Mines"))
        CoBo.Items.Add(New MyListItem("Minigames", gfolder & "\Content\Minigames"))
        CoBo.Items.Add(New MyListItem("Portraits", gfolder & "\Content\Portraits"))
        CoBo.Items.Add(New MyListItem("Terrain Features", gfolder & "\Content\TerrainFeatures"))
        CoBo.Items.Add(New MyListItem("Tile Sheets", gfolder & "\Content\TileSheets"))
        CoBo.Items.Add(New MyListItem("XACT", gfolder & "\Content\XACT"))
        If CoBo.Items.Count > 0 Then
            CoBo.SelectedIndex = 0    ' The first item has index 0 '
        End If
    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Close()
    End Sub

    Private Sub OK_Click(sender As Object, e As EventArgs) Handles OK.Click
        Dim destF As MyListItem = CType(CoBo.SelectedItem, MyListItem)
        If CoBo.SelectedIndex > 0 Then
            XtFolder = destF.Value
            If CheckBox1.Checked Then
                cb1 = 1
                MainForm.Multiok = 1
            End If
            Close()
        Else
            MsgBox("Invalid Choice, please try again.")
        End If

    End Sub
End Class
