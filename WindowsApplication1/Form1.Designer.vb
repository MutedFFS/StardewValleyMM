<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Me.Back = New System.Windows.Forms.Button()
        Me.Forward = New System.Windows.Forms.Button()
        Me.Home = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.browser = New Awesomium.Windows.Forms.WebControl(Me.components)
        Me.SuspendLayout()
        '
        'Back
        '
        Me.Back.Location = New System.Drawing.Point(13, 391)
        Me.Back.Name = "Back"
        Me.Back.Size = New System.Drawing.Size(75, 23)
        Me.Back.TabIndex = 0
        Me.Back.Text = "Back"
        Me.Back.UseVisualStyleBackColor = True
        '
        'Forward
        '
        Me.Forward.Location = New System.Drawing.Point(563, 391)
        Me.Forward.Name = "Forward"
        Me.Forward.Size = New System.Drawing.Size(75, 23)
        Me.Forward.TabIndex = 1
        Me.Forward.Text = "Forward"
        Me.Forward.UseVisualStyleBackColor = True
        '
        'Home
        '
        Me.Home.Location = New System.Drawing.Point(295, 391)
        Me.Home.Name = "Home"
        Me.Home.Size = New System.Drawing.Size(75, 23)
        Me.Home.TabIndex = 2
        Me.Home.Text = "Home"
        Me.Home.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(821, 391)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'browser
        '
        Me.browser.Location = New System.Drawing.Point(13, 12)
        Me.browser.Size = New System.Drawing.Size(868, 363)
        Me.browser.Source = New System.Uri("about:blank", System.UriKind.Absolute)
        Me.browser.TabIndex = 7
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(908, 426)
        Me.Controls.Add(Me.browser)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Home)
        Me.Controls.Add(Me.Forward)
        Me.Controls.Add(Me.Back)
        Me.Name = "Form1"
        Me.Text = "ModDownload"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Back As System.Windows.Forms.Button
    Friend WithEvents Forward As System.Windows.Forms.Button
    Friend WithEvents Home As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Private WithEvents browser As Awesomium.Windows.Forms.WebControl
End Class
