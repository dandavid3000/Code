Public Class ThemBenhNhan

    Private Sub ButtonItem17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub ThemBenhNhan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonItem17_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem17.Click
        KetNoiUser.ShowDialog()

        DSBacSi.ShowDialog()
        DSPhongKham.ShowDialog()
        LapHoaDon.ShowDialog()
        LapPhieuKham.ShowDialog()
        LapPhieuXetNghiem.ShowDialog()
        QuanLyKhoa.ShowDialog()
        QuanLyNhanVien.ShowDialog()
        QuanLyPhongKham.ShowDialog()
        QuanLyThuoc.ShowDialog()
        TimKiemBenhNhan.ShowDialog()


    End Sub

    Private Sub ExpandablePanel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpandablePanel1.Click

    End Sub

    Private Sub RibbonControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonControl1.Click

    End Sub
End Class
