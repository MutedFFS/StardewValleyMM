<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DeleteForm
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
        Me.Delete = New System.Windows.Forms.Button()
        Me.DelList = New System.Windows.Forms.CheckedListBox()
        Me.SuspendLayout()
        '
        'Delete
        '
        Me.Delete.Location = New System.Drawing.Point(229, 335)
        Me.Delete.Name = "Delete"
        Me.Delete.Size = New System.Drawing.Size(253, 43)
        Me.Delete.TabIndex = 1
        Me.Delete.Text = "Delete"
        Me.Delete.UseVisualStyleBackColor = True
        '
        'DelList
        '
        Me.DelList.FormattingEnabled = True
        Me.DelList.Location = New System.Drawing.Point(12, 12)
        Me.DelList.Name = "DelList"
        Me.DelList.Size = New System.Drawing.Size(692, 319)
        Me.DelList.TabIndex = 2
        Me.DelList.UseTabStops = False
        '
        'DeleteForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(729, 390)
        Me.Controls.Add(Me.DelList)
        Me.Controls.Add(Me.Delete)
        Me.Name = "DeleteForm"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Delete As System.Windows.Forms.Button
    Friend WithEvents DelList As System.Windows.Forms.CheckedListBox
End Class
