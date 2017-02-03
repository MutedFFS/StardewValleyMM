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
        CoBo.Items.Add(New MyListItem("general content", gfolder & sep & "Content"))
        CoBo.Items.Add(New MyListItem("Animal", gfolder & sep & "Content" & sep & "Animals"))
        CoBo.Items.Add(New MyListItem("Buildings", gfolder & sep & "Content" & sep & "uildings"))
        CoBo.Items.Add(New MyListItem("character - General (no Portraits)", gfolder & sep & "Content" & sep & "Characters"))
        CoBo.Items.Add(New MyListItem("character - Dialogue - general", gfolder & sep & "Content" & sep & "Characters" & sep & "Dialogue"))
        CoBo.Items.Add(New MyListItem("character - Dialogue - fall", gfolder & sep & "Content" & sep & "Characters" & sep & "Dialogue" & sep & "fall"))
        CoBo.Items.Add(New MyListItem("character - Dialogue - spring", gfolder & sep & "Content" & sep & "Characters" & sep & "Dialogue" & sep & "spring"))
        CoBo.Items.Add(New MyListItem("character - Dialogue - summer", gfolder & sep & "Content" & sep & "Characters" & sep & "Dialogue" & sep & "summer"))
        CoBo.Items.Add(New MyListItem("character - Dialogue - winter", gfolder & sep & "Content" & sep & "Characters" & sep & "Dialogue" & sep & "winter"))
        CoBo.Items.Add(New MyListItem("character - Farmer (clothes, accsessoires,hats, etc)", gfolder & sep & "Content" & sep & "Characters" & sep & "Farmer"))
        CoBo.Items.Add(New MyListItem("character - Monster", gfolder & sep & "Content" & sep & "Characters" & sep & "Monsters"))
        CoBo.Items.Add(New MyListItem("character - shedules - general", gfolder & sep & "Content" & sep & "Characters" & sep & "schedules"))
        CoBo.Items.Add(New MyListItem("character - shedules - spring", gfolder & sep & "Content" & sep & "Characters" & sep & "schedules" & sep & "spring"))
        CoBo.Items.Add(New MyListItem("Data - general", gfolder & sep & "Content" & sep & "Data"))
        CoBo.Items.Add(New MyListItem("Data - Events", gfolder & sep & "Content" & sep & "Data" & sep & "Events"))
        CoBo.Items.Add(New MyListItem("Data - Festivals", gfolder & sep & "Content" & sep & "Data" & sep & "Festivals"))
        CoBo.Items.Add(New MyListItem("Data - TV", gfolder & sep & "Content" & sep & "Data" & sep & "TV"))
        CoBo.Items.Add(New MyListItem("Fonts", gfolder & sep & "Content" & sep & "Fonts"))
        CoBo.Items.Add(New MyListItem("Loose Sprites", gfolder & sep & "Content" & sep & "LooseSprites"))
        CoBo.Items.Add(New MyListItem("Loose Sprites - Lighting", gfolder & sep & "Content" & sep & "LooseSprites" & sep & "Lighting"))
        CoBo.Items.Add(New MyListItem("Maps - general", gfolder & sep & "Content" & sep & "Maps"))
        CoBo.Items.Add(New MyListItem("Maps - Mines", gfolder & sep & "Content" & sep & "Maps" & sep & "Mines"))
        CoBo.Items.Add(New MyListItem("Mines (different Folder)", gfolder & sep & "Content" & sep & "Mines"))
        CoBo.Items.Add(New MyListItem("Minigames", gfolder & sep & "Content" & sep & "Minigames"))
        CoBo.Items.Add(New MyListItem("Portraits", gfolder & sep & "Content" & sep & "Portraits"))
        CoBo.Items.Add(New MyListItem("Terrain Features", gfolder & sep & "Content" & sep & "TerrainFeatures"))
        CoBo.Items.Add(New MyListItem("Tile Sheets", gfolder & sep & "Content" & sep & "TileSheets"))
        CoBo.Items.Add(New MyListItem("XACT", gfolder & sep & "Content" & sep & "XACT"))
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
