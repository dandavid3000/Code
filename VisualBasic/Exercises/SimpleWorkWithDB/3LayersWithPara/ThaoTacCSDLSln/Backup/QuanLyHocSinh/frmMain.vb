Public Class frmMain

    Private Sub mnuHeThongThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHeThongThoat.Click
        Me.Close()
    End Sub

    Private Sub TiepNhanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TiepNhanToolStripMenuItem.Click
        Dim frm As New frmTiepNhanHocSinh()
        frm.ShowDialog()
        'Sinh vien tu so sanh phuong thuc frm.Show voi frm.ShowDialog()
    End Sub

    Private Sub TimKiemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimKiemToolStripMenuItem.Click
        Dim frm As New frmTimKiemHocSinh()
        frm.ShowDialog()
    End Sub
End Class