<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class INIForm
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GogLabel = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextGfolder = New System.Windows.Forms.TextBox()
        Me.TextSFolder = New System.Windows.Forms.TextBox()
        Me.Save = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.cGfolder = New System.Windows.Forms.Button()
        Me.cSfolder = New System.Windows.Forms.Button()
        Me.cgog = New System.Windows.Forms.Button()
        Me.oif = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Is GoG Version: "
        '
        'GogLabel
        '
        Me.GogLabel.AutoSize = True
        Me.GogLabel.Location = New System.Drawing.Point(105, 13)
        Me.GogLabel.Name = "GogLabel"
        Me.GogLabel.Size = New System.Drawing.Size(60, 13)
        Me.GogLabel.TabIndex = 1
        Me.GogLabel.Text = "GoGCheck"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Gamefolder:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Steamfolder"
        '
        'TextGfolder
        '
        Me.TextGfolder.Location = New System.Drawing.Point(108, 46)
        Me.TextGfolder.Name = "TextGfolder"
        Me.TextGfolder.Size = New System.Drawing.Size(224, 20)
        Me.TextGfolder.TabIndex = 4
        '
        'TextSFolder
        '
        Me.TextSFolder.Location = New System.Drawing.Point(108, 77)
        Me.TextSFolder.Name = "TextSFolder"
        Me.TextSFolder.Size = New System.Drawing.Size(224, 20)
        Me.TextSFolder.TabIndex = 5
        '
        'Save
        '
        Me.Save.Location = New System.Drawing.Point(16, 107)
        Me.Save.Name = "Save"
        Me.Save.Size = New System.Drawing.Size(75, 23)
        Me.Save.TabIndex = 6
        Me.Save.Text = "Save"
        Me.Save.UseVisualStyleBackColor = True
        '
        'Cancel
        '
        Me.Cancel.Location = New System.Drawing.Point(348, 107)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(75, 23)
        Me.Cancel.TabIndex = 7
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = True
        '
        'cGfolder
        '
        Me.cGfolder.Location = New System.Drawing.Point(348, 44)
        Me.cGfolder.Name = "cGfolder"
        Me.cGfolder.Size = New System.Drawing.Size(75, 23)
        Me.cGfolder.TabIndex = 8
        Me.cGfolder.Text = "Change"
        Me.cGfolder.UseVisualStyleBackColor = True
        '
        'cSfolder
        '
        Me.cSfolder.Location = New System.Drawing.Point(348, 75)
        Me.cSfolder.Name = "cSfolder"
        Me.cSfolder.Size = New System.Drawing.Size(75, 23)
        Me.cSfolder.TabIndex = 9
        Me.cSfolder.Text = "Change"
        Me.cSfolder.UseVisualStyleBackColor = True
        '
        'cgog
        '
        Me.cgog.Location = New System.Drawing.Point(348, 8)
        Me.cgog.Name = "cgog"
        Me.cgog.Size = New System.Drawing.Size(75, 23)
        Me.cgog.TabIndex = 10
        Me.cgog.Text = "Change"
        Me.cgog.UseVisualStyleBackColor = True
        '
        'oif
        '
        Me.oif.Location = New System.Drawing.Point(173, 107)
        Me.oif.Name = "oif"
        Me.oif.Size = New System.Drawing.Size(102, 23)
        Me.oif.TabIndex = 11
        Me.oif.Text = "Open  INI-Folder"
        Me.oif.UseVisualStyleBackColor = True
        '
        'INIForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(430, 139)
        Me.Controls.Add(Me.oif)
        Me.Controls.Add(Me.cgog)
        Me.Controls.Add(Me.cSfolder)
        Me.Controls.Add(Me.cGfolder)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.Save)
        Me.Controls.Add(Me.TextSFolder)
        Me.Controls.Add(Me.TextGfolder)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GogLabel)
        Me.Controls.Add(Me.Label1)
        Me.Name = "INIForm"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GogLabel As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextGfolder As System.Windows.Forms.TextBox
    Friend WithEvents TextSFolder As System.Windows.Forms.TextBox
    Friend WithEvents Save As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents cGfolder As System.Windows.Forms.Button
    Friend WithEvents cSfolder As System.Windows.Forms.Button
    Friend WithEvents cgog As System.Windows.Forms.Button
    Friend WithEvents oif As System.Windows.Forms.Button
End Class
