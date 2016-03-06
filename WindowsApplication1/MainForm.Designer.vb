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
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(10, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(720, 150)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'addm
        '
        Me.addm.Location = New System.Drawing.Point(459, 292)
        Me.addm.Name = "addm"
        Me.addm.Size = New System.Drawing.Size(271, 40)
        Me.addm.TabIndex = 3
        Me.addm.Text = "Add Mod"
        Me.addm.UseVisualStyleBackColor = True
        '
        'LSMAPI
        '
        Me.LSMAPI.Location = New System.Drawing.Point(459, 186)
        Me.LSMAPI.Name = "LSMAPI"
        Me.LSMAPI.Size = New System.Drawing.Size(269, 40)
        Me.LSMAPI.TabIndex = 4
        Me.LSMAPI.Text = "Launch SMAPI"
        Me.LSMAPI.UseVisualStyleBackColor = True
        '
        'LSDV
        '
        Me.LSDV.Location = New System.Drawing.Point(459, 237)
        Me.LSDV.Name = "LSDV"
        Me.LSDV.Size = New System.Drawing.Size(269, 40)
        Me.LSDV.TabIndex = 5
        Me.LSDV.Text = "Launch StardewValley"
        Me.LSDV.UseVisualStyleBackColor = True
        '
        'dlm
        '
        Me.dlm.Location = New System.Drawing.Point(459, 345)
        Me.dlm.Name = "dlm"
        Me.dlm.Size = New System.Drawing.Size(271, 40)
        Me.dlm.TabIndex = 6
        Me.dlm.Text = "Download Mods"
        Me.dlm.UseVisualStyleBackColor = True
        '
        'delm
        '
        Me.delm.Location = New System.Drawing.Point(459, 397)
        Me.delm.Name = "delm"
        Me.delm.Size = New System.Drawing.Size(269, 40)
        Me.delm.TabIndex = 7
        Me.delm.Text = "Delete Mods"
        Me.delm.UseVisualStyleBackColor = True
        '
        'ModList
        '
        Me.ModList.FormattingEnabled = True
        Me.ModList.Location = New System.Drawing.Point(10, 212)
        Me.ModList.Name = "ModList"
        Me.ModList.Size = New System.Drawing.Size(423, 225)
        Me.ModList.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 186)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 16)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Installed Mods"
        '
        'MainForm
        '
        Me.AccessibleName = "FoundMods"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(740, 466)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ModList)
        Me.Controls.Add(Me.delm)
        Me.Controls.Add(Me.dlm)
        Me.Controls.Add(Me.LSDV)
        Me.Controls.Add(Me.LSMAPI)
        Me.Controls.Add(Me.addm)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(500, 400)
        Me.Name = "MainForm"
        Me.Text = "SDVMM V1.1b"
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

End Class
