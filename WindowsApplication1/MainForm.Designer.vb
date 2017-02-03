<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.addm = New System.Windows.Forms.Button()
        Me.LSMAPI = New System.Windows.Forms.Button()
        Me.LSDV = New System.Windows.Forms.Button()
        Me.dlm = New System.Windows.Forms.Button()
        Me.delm = New System.Windows.Forms.Button()
        Me.LabelSD = New System.Windows.Forms.Label()
        Me.LabelSmapi = New System.Windows.Forms.Label()
        Me.ASM = New System.Windows.Forms.Button()
        Me.LStorm = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.XNBlist = New System.Windows.Forms.ListBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.openDFolder = New System.Windows.Forms.Button()
        Me.openModFolder = New System.Windows.Forms.Button()
        Me.refreshb = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dModList = New System.Windows.Forms.Label()
        Me.ModListd = New System.Windows.Forms.ListBox()
        Me.ModList = New System.Windows.Forms.ListBox()
        Me.Tab = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.up = New System.Windows.Forms.Button()
        Me.Loadorder = New System.Windows.Forms.ListBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.Tab.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(10, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(720, 120)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'addm
        '
        Me.addm.Location = New System.Drawing.Point(459, 257)
        Me.addm.Name = "addm"
        Me.addm.Size = New System.Drawing.Size(271, 40)
        Me.addm.TabIndex = 3
        Me.addm.Text = "Add  SMAPI/XNB Mod"
        Me.addm.UseVisualStyleBackColor = True
        '
        'LSMAPI
        '
        Me.LSMAPI.Location = New System.Drawing.Point(459, 151)
        Me.LSMAPI.Name = "LSMAPI"
        Me.LSMAPI.Size = New System.Drawing.Size(271, 40)
        Me.LSMAPI.TabIndex = 4
        Me.LSMAPI.Text = "Launch SMAPI"
        Me.LSMAPI.UseVisualStyleBackColor = True
        '
        'LSDV
        '
        Me.LSDV.Location = New System.Drawing.Point(459, 205)
        Me.LSDV.Name = "LSDV"
        Me.LSDV.Size = New System.Drawing.Size(271, 40)
        Me.LSDV.TabIndex = 5
        Me.LSDV.Text = "Launch Stardew Valley"
        Me.LSDV.UseVisualStyleBackColor = True
        '
        'dlm
        '
        Me.dlm.Location = New System.Drawing.Point(459, 310)
        Me.dlm.Name = "dlm"
        Me.dlm.Size = New System.Drawing.Size(271, 40)
        Me.dlm.TabIndex = 6
        Me.dlm.Text = "Download Mods"
        Me.dlm.UseVisualStyleBackColor = True
        '
        'delm
        '
        Me.delm.Location = New System.Drawing.Point(459, 362)
        Me.delm.Name = "delm"
        Me.delm.Size = New System.Drawing.Size(271, 40)
        Me.delm.TabIndex = 7
        Me.delm.Text = "Delete Mods"
        Me.delm.UseVisualStyleBackColor = True
        '
        'LabelSD
        '
        Me.LabelSD.AutoSize = True
        Me.LabelSD.Location = New System.Drawing.Point(12, 428)
        Me.LabelSD.Name = "LabelSD"
        Me.LabelSD.Size = New System.Drawing.Size(106, 13)
        Me.LabelSD.TabIndex = 15
        Me.LabelSD.Text = "SDVMM Version Info"
        '
        'LabelSmapi
        '
        Me.LabelSmapi.AutoSize = True
        Me.LabelSmapi.Location = New System.Drawing.Point(232, 428)
        Me.LabelSmapi.Name = "LabelSmapi"
        Me.LabelSmapi.Size = New System.Drawing.Size(99, 13)
        Me.LabelSmapi.TabIndex = 16
        Me.LabelSmapi.Text = "SMAPI Version Info"
        '
        'ASM
        '
        Me.ASM.Location = New System.Drawing.Point(600, 257)
        Me.ASM.Name = "ASM"
        Me.ASM.Size = New System.Drawing.Size(130, 40)
        Me.ASM.TabIndex = 17
        Me.ASM.Text = "Add Storm Mod"
        Me.ASM.UseVisualStyleBackColor = True
        '
        'LStorm
        '
        Me.LStorm.Location = New System.Drawing.Point(600, 151)
        Me.LStorm.Name = "LStorm"
        Me.LStorm.Size = New System.Drawing.Size(130, 40)
        Me.LStorm.TabIndex = 18
        Me.LStorm.Text = "Launch Storm"
        Me.LStorm.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(459, 423)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 22)
        Me.Button1.TabIndex = 19
        Me.Button1.Text = "Settings"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(655, 423)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 22)
        Me.Button2.TabIndex = 20
        Me.Button2.Text = "Exit"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(548, 422)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(88, 23)
        Me.Button3.TabIndex = 21
        Me.Button3.Text = "Donate"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(471, 110)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(259, 23)
        Me.ProgressBar1.TabIndex = 22
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.XNBlist)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(435, 265)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "XNB"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'XNBlist
        '
        Me.XNBlist.FormattingEnabled = True
        Me.XNBlist.Location = New System.Drawing.Point(112, 22)
        Me.XNBlist.Name = "XNBlist"
        Me.XNBlist.Size = New System.Drawing.Size(210, 225)
        Me.XNBlist.TabIndex = 14
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.openDFolder)
        Me.TabPage2.Controls.Add(Me.openModFolder)
        Me.TabPage2.Controls.Add(Me.refreshb)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.dModList)
        Me.TabPage2.Controls.Add(Me.ModListd)
        Me.TabPage2.Controls.Add(Me.ModList)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(435, 265)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "SMAPI Mods"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'openDFolder
        '
        Me.openDFolder.Location = New System.Drawing.Point(354, 236)
        Me.openDFolder.Name = "openDFolder"
        Me.openDFolder.Size = New System.Drawing.Size(75, 23)
        Me.openDFolder.TabIndex = 19
        Me.openDFolder.Text = "Open Folder"
        Me.openDFolder.UseVisualStyleBackColor = True
        '
        'openModFolder
        '
        Me.openModFolder.Location = New System.Drawing.Point(6, 236)
        Me.openModFolder.Name = "openModFolder"
        Me.openModFolder.Size = New System.Drawing.Size(75, 23)
        Me.openModFolder.TabIndex = 18
        Me.openModFolder.Text = "Open Folder"
        Me.openModFolder.UseVisualStyleBackColor = True
        '
        'refreshb
        '
        Me.refreshb.Location = New System.Drawing.Point(164, 236)
        Me.refreshb.Name = "refreshb"
        Me.refreshb.Size = New System.Drawing.Size(113, 23)
        Me.refreshb.TabIndex = 17
        Me.refreshb.Text = "Refresh"
        Me.refreshb.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 15)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Activated Mods"
        '
        'dModList
        '
        Me.dModList.AutoSize = True
        Me.dModList.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dModList.Location = New System.Drawing.Point(219, 13)
        Me.dModList.Name = "dModList"
        Me.dModList.Size = New System.Drawing.Size(108, 15)
        Me.dModList.TabIndex = 15
        Me.dModList.Text = "Deactivated Mods"
        '
        'ModListd
        '
        Me.ModListd.FormattingEnabled = True
        Me.ModListd.Location = New System.Drawing.Point(222, 31)
        Me.ModListd.Name = "ModListd"
        Me.ModListd.Size = New System.Drawing.Size(210, 199)
        Me.ModListd.TabIndex = 14
        '
        'ModList
        '
        Me.ModList.FormattingEnabled = True
        Me.ModList.Location = New System.Drawing.Point(6, 31)
        Me.ModList.Name = "ModList"
        Me.ModList.Size = New System.Drawing.Size(210, 199)
        Me.ModList.TabIndex = 13
        '
        'Tab
        '
        Me.Tab.AccessibleName = ""
        Me.Tab.Controls.Add(Me.TabPage2)
        Me.Tab.Controls.Add(Me.TabPage1)
        Me.Tab.Controls.Add(Me.TabPage3)
        Me.Tab.Location = New System.Drawing.Point(10, 135)
        Me.Tab.Name = "Tab"
        Me.Tab.SelectedIndex = 0
        Me.Tab.Size = New System.Drawing.Size(443, 291)
        Me.Tab.TabIndex = 23
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Button4)
        Me.TabPage3.Controls.Add(Me.up)
        Me.TabPage3.Controls.Add(Me.Loadorder)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(435, 265)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Load-Order"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(251, 220)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(90, 30)
        Me.Button4.TabIndex = 16
        Me.Button4.Text = "▼"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'up
        '
        Me.up.Location = New System.Drawing.Point(251, 25)
        Me.up.Name = "up"
        Me.up.Size = New System.Drawing.Size(90, 30)
        Me.up.TabIndex = 15
        Me.up.Text = "▲"
        Me.up.UseVisualStyleBackColor = True
        '
        'Loadorder
        '
        Me.Loadorder.FormattingEnabled = True
        Me.Loadorder.Location = New System.Drawing.Point(17, 25)
        Me.Loadorder.Name = "Loadorder"
        Me.Loadorder.Size = New System.Drawing.Size(210, 225)
        Me.Loadorder.TabIndex = 14
        '
        'MainForm
        '
        Me.AccessibleName = "FoundMods"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(734, 446)
        Me.Controls.Add(Me.Tab)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.LStorm)
        Me.Controls.Add(Me.ASM)
        Me.Controls.Add(Me.LabelSmapi)
        Me.Controls.Add(Me.LabelSD)
        Me.Controls.Add(Me.delm)
        Me.Controls.Add(Me.dlm)
        Me.Controls.Add(Me.LSDV)
        Me.Controls.Add(Me.LSMAPI)
        Me.Controls.Add(Me.addm)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(500, 400)
        Me.Name = "MainForm"
        Me.Text = "SDVMM V2.1a      Smapi V0"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.Tab.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents addm As System.Windows.Forms.Button
    Friend WithEvents LSMAPI As System.Windows.Forms.Button
    Friend WithEvents LSDV As System.Windows.Forms.Button
    Friend WithEvents dlm As System.Windows.Forms.Button
    Friend WithEvents delm As System.Windows.Forms.Button
    Friend WithEvents LabelSD As System.Windows.Forms.Label
    Friend WithEvents LabelSmapi As System.Windows.Forms.Label
    Friend WithEvents ASM As System.Windows.Forms.Button
    Friend WithEvents LStorm As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents XNBlist As ListBox
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents openDFolder As Button
    Friend WithEvents openModFolder As Button
    Friend WithEvents refreshb As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents dModList As Label
    Friend WithEvents ModListd As ListBox
    Friend WithEvents ModList As ListBox
    Friend WithEvents Tab As TabControl
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Button4 As Button
    Friend WithEvents up As Button
    Friend WithEvents Loadorder As ListBox
End Class
