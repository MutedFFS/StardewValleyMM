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
        Me.ModList = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ModListd = New System.Windows.Forms.ListBox()
        Me.dModList = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LabelSD = New System.Windows.Forms.Label()
        Me.LabelSmapi = New System.Windows.Forms.Label()
        Me.ASM = New System.Windows.Forms.Button()
        Me.LStorm = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.addm.Size = New System.Drawing.Size(130, 40)
        Me.addm.TabIndex = 3
        Me.addm.Text = "Add  SMAPI/XNB Mod"
        Me.addm.UseVisualStyleBackColor = True
        '
        'LSMAPI
        '
        Me.LSMAPI.Location = New System.Drawing.Point(459, 151)
        Me.LSMAPI.Name = "LSMAPI"
        Me.LSMAPI.Size = New System.Drawing.Size(130, 40)
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
        'ModList
        '
        Me.ModList.FormattingEnabled = True
        Me.ModList.Location = New System.Drawing.Point(10, 177)
        Me.ModList.Name = "ModList"
        Me.ModList.Size = New System.Drawing.Size(210, 225)
        Me.ModList.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(160, 143)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 16)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Installed Mods"
        '
        'ModListd
        '
        Me.ModListd.FormattingEnabled = True
        Me.ModListd.Location = New System.Drawing.Point(226, 177)
        Me.ModListd.Name = "ModListd"
        Me.ModListd.Size = New System.Drawing.Size(210, 225)
        Me.ModListd.TabIndex = 10
        '
        'dModList
        '
        Me.dModList.AutoSize = True
        Me.dModList.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dModList.Location = New System.Drawing.Point(223, 159)
        Me.dModList.Name = "dModList"
        Me.dModList.Size = New System.Drawing.Size(108, 15)
        Me.dModList.TabIndex = 11
        Me.dModList.Text = "Deactivated Mods"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 159)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 15)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Activated Mods"
        '
        'LabelSD
        '
        Me.LabelSD.AutoSize = True
        Me.LabelSD.Location = New System.Drawing.Point(12, 411)
        Me.LabelSD.Name = "LabelSD"
        Me.LabelSD.Size = New System.Drawing.Size(106, 13)
        Me.LabelSD.TabIndex = 15
        Me.LabelSD.Text = "SDVMM Version Info"
        '
        'LabelSmapi
        '
        Me.LabelSmapi.AutoSize = True
        Me.LabelSmapi.Location = New System.Drawing.Point(232, 411)
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
        Me.Button1.Location = New System.Drawing.Point(652, 406)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 22)
        Me.Button1.TabIndex = 19
        Me.Button1.Text = "Settings"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AccessibleName = "FoundMods"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(739, 429)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.LStorm)
        Me.Controls.Add(Me.ASM)
        Me.Controls.Add(Me.LabelSmapi)
        Me.Controls.Add(Me.LabelSD)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dModList)
        Me.Controls.Add(Me.ModListd)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ModList)
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
        Me.Text = "SDVMM V1.4e"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents addm As System.Windows.Forms.Button
    Friend WithEvents LSMAPI As System.Windows.Forms.Button
    Friend WithEvents LSDV As System.Windows.Forms.Button
    Friend WithEvents dlm As System.Windows.Forms.Button
    Friend WithEvents delm As System.Windows.Forms.Button
    Friend WithEvents ModList As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ModListd As System.Windows.Forms.ListBox
    Friend WithEvents dModList As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LabelSD As System.Windows.Forms.Label
    Friend WithEvents LabelSmapi As System.Windows.Forms.Label
    Friend WithEvents ASM As System.Windows.Forms.Button
    Friend WithEvents LStorm As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
