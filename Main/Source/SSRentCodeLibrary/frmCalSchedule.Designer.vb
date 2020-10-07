<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCalSchedule
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.SsCalendar1 = New SSRentCodeLibrary.SSCalendar
        Me.SuspendLayout()
        '
        'SsCalendar1
        '
        Me.SsCalendar1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SsCalendar1.BackColor = System.Drawing.SystemColors.Control
        Me.SsCalendar1.Cursor = System.Windows.Forms.Cursors.Default
        Me.SsCalendar1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SsCalendar1.Location = New System.Drawing.Point(0, 0)
        Me.SsCalendar1.Name = "SsCalendar1"
        Me.SsCalendar1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SsCalendar1.SelectedDate = New Date(2008, 1, 15, 16, 42, 51, 813)
        Me.SsCalendar1.Size = New System.Drawing.Size(849, 732)
        Me.SsCalendar1.TabIndex = 0
        '
        'frmCalSchedule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(844, 739)
        Me.Controls.Add(Me.SsCalendar1)
        Me.MinimizeBox = False
        Me.Name = "frmCalSchedule"
        Me.Text = "Supreme Services Calendar View"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SsCalendar1 As SSRentCodeLibrary.SSCalendar
End Class
