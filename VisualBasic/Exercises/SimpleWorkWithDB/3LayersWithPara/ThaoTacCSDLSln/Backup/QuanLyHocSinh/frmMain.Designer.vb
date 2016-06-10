<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.mnuHeThong = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuHeThongBackup = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuHeThongThoat = New System.Windows.Forms.ToolStripMenuItem
        Me.HocSinhToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TiepNhanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TimKiemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuHeThong, Me.HocSinhToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(292, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuHeThong
        '
        Me.mnuHeThong.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuHeThongBackup, Me.ToolStripSeparator1, Me.mnuHeThongThoat})
        Me.mnuHeThong.Name = "mnuHeThong"
        Me.mnuHeThong.Size = New System.Drawing.Size(75, 20)
        Me.mnuHeThong.Text = "He &Thong"
        '
        'mnuHeThongBackup
        '
        Me.mnuHeThongBackup.Enabled = False
        Me.mnuHeThongBackup.Name = "mnuHeThongBackup"
        Me.mnuHeThongBackup.Size = New System.Drawing.Size(129, 22)
        Me.mnuHeThongBackup.Text = "&Backup"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(126, 6)
        '
        'mnuHeThongThoat
        '
        Me.mnuHeThongThoat.Name = "mnuHeThongThoat"
        Me.mnuHeThongThoat.Size = New System.Drawing.Size(129, 22)
        Me.mnuHeThongThoat.Text = "T&hoat"
        '
        'HocSinhToolStripMenuItem
        '
        Me.HocSinhToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TiepNhanToolStripMenuItem, Me.TimKiemToolStripMenuItem})
        Me.HocSinhToolStripMenuItem.Name = "HocSinhToolStripMenuItem"
        Me.HocSinhToolStripMenuItem.Size = New System.Drawing.Size(70, 20)
        Me.HocSinhToolStripMenuItem.Text = "&Hoc Sinh"
        '
        'TiepNhanToolStripMenuItem
        '
        Me.TiepNhanToolStripMenuItem.Name = "TiepNhanToolStripMenuItem"
        Me.TiepNhanToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.TiepNhanToolStripMenuItem.Text = "&Tiep Nhan"
        '
        'TimKiemToolStripMenuItem
        '
        Me.TimKiemToolStripMenuItem.Name = "TimKiemToolStripMenuItem"
        Me.TimKiemToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.TimKiemToolStripMenuItem.Text = "Tim &Kiem"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 262)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.Text = "frmMain"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuHeThong As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HocSinhToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TiepNhanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHeThongThoat As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHeThongBackup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TimKiemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
