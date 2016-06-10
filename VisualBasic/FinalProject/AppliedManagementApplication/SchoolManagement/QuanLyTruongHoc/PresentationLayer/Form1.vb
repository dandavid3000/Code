Imports System.Data.OleDb
Imports DTO
Imports BUSLayer

Public Class Form1

    'LOP HOC
    Private Sub rdKhoi10_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdKhoi10.CheckedChanged
        If (rdKhoi10.Checked = True) Then
            rdKhoi11.Checked = False
            rdKhoi12.Checked = False
            rdKhoiTatCa.Checked = False
            Dim lh As New LopHoc
            lh.makhoi = "k10"
            Dim dt As New DataTable()
            dt = LOPHOCBus.LayBangLopHoc(lh)
            dtgvDSLopHoc.DataSource = dt
        End If
    End Sub

    Private Sub rdKhoi11_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdKhoi11.CheckedChanged
        If (rdKhoi11.Checked = True) Then
            rdKhoi10.Checked = False
            rdKhoi12.Checked = False
            rdKhoiTatCa.Checked = False
            Dim lh As New LopHoc
            lh.makhoi = "k11"
            Dim dt As New DataTable()
            dt = LOPHOCBus.LayBangLopHoc(lh)
            dtgvDSLopHoc.DataSource = dt

            Dim dt1 As New DataTable()
            lh.malophoc = txtMaLopHoc.Text
            dt1 = LOPHOCBus.LayBangLichRanh(lh)
            dtgvLichRanh.DataSource = dt1

        End If
    End Sub

    Private Sub rdKhoi12_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdKhoi12.CheckedChanged
        If (rdKhoi12.Checked = True) Then
            rdKhoi11.Checked = False
            rdKhoi10.Checked = False
            rdKhoiTatCa.Checked = False
            Dim lh As New LopHoc
            lh.makhoi = "k12"
            Dim dt As New DataTable()
            dt = LOPHOCBus.LayBangLopHoc(lh)
            dtgvDSLopHoc.DataSource = dt
            Dim dt1 As New DataTable()
            lh.malophoc = txtMaLopHoc.Text
            dt1 = LOPHOCBus.LayBangLichRanh(lh)
            dtgvLichRanh.DataSource = dt1
        End If
    End Sub

    Private Sub rdKhoiTatCa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdKhoiTatCa.CheckedChanged
        If (rdKhoiTatCa.Checked = True) Then
            rdKhoi11.Checked = False
            rdKhoi12.Checked = False
            rdKhoi10.Checked = False
            Dim dt As New DataTable()
            dt = LOPHOCBus.LayBangLopHoc()
            dtgvDSLopHoc.DataSource = dt
            Dim lh As New LopHoc
            Dim dt1 As New DataTable()
            lh.malophoc = txtMaLopHoc.Text
            dt1 = LOPHOCBus.LayBangLichRanh(lh)
            dtgvLichRanh.DataSource = dt1
        End If
    End Sub

    Private Sub dtgvLichRanh_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgvLichRanh.CellContentClick
        Dim rowIndex As String = dtgvLichRanh.CurrentCell.Value.ToString()
        Dim dt1 As New DataTable()
        If (rowIndex = "Bận") Then
            rowIndex = "Buộc Sắp Xếp"
        ElseIf (rowIndex = "Rãnh") Then
            rowIndex = "Bận"
        Else
            rowIndex = "Rãnh"
        End If
        dtgvLichRanh.CurrentCell.Value = rowIndex
    End Sub


    Private Sub btnTrangThai_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrangThai.Click
        Dim dt As New DataTable()
        dt = LOPHOCBus.XLLichBan()
        dtgvLichRanh.DataSource = dt
    End Sub

    Private Sub btnTaoLopHocMoi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTaoLopHocMoi.Click
        Dim lh As New LopHoc
        Dim makhoi As String
        If (rdKhoi10.Checked = True) Then
            makhoi = "K10"
        ElseIf (rdKhoi11.Checked = True) Then
            makhoi = "K11"
        Else
            makhoi = "K12"
        End If
        lh = LOPHOCBus.TaoLopHoc(txtTenLopHoc.Text, makhoi)
        txtMaLopHoc.Text = lh.malophoc
        LOPHOCBus.TaoLopHocMoi(lh)
    End Sub

    Private Sub dtgvDSLopHoc_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgvDSLopHoc.SelectionChanged
        Dim rowIndex As Integer = dtgvDSLopHoc.CurrentRow.Index
        Dim maLH As String = dtgvDSLopHoc("MaLopHoc", rowIndex).Value
        Dim tenLopHoc As String = dtgvDSLopHoc("TenLopHoc", rowIndex).Value
        txtMaLopHoc.Text = maLH
        txtTenLopHoc.Text = tenLopHoc

        Dim dt1 As New DataTable()
        Dim lh As New LopHoc
        lh.malophoc = maLH
        dt1 = LOPHOCBus.LayBangLichRanh(lh)
        dtgvLichRanh.DataSource = dt1
    End Sub

    Private Sub btnXoaLopHoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoaLopHoc.Click
        Dim dt As New DataTable()
        dt = dtgvDSLopHoc.DataSource
        If (dtgvDSLopHoc.CurrentRow IsNot Nothing) Then
            Dim RowIndex As Integer
            RowIndex = dtgvDSLopHoc.CurrentRow.Index
            Dim malophoc As String = dtgvDSLopHoc("MaLopHoc", RowIndex).Value
            Dim row As DataRow
            row = dt.Select("MaLopHoc = " + malophoc.ToString())(0)
            row.Delete()
        End If
    End Sub

    Private Sub btnCapNhatDuLieu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhatDuLieu.Click
        Dim dt As New DataTable()
        Dim lh As New LopHoc
        If (rdKhoi10.Checked = True) Then
            lh.makhoi = "K10"
            dt = LOPHOCBus.LayBangLopHoc(lh)
            dtgvDSLopHoc.DataSource = dt
        ElseIf (rdKhoi11.Checked = True) Then
            lh.makhoi = "K11"
            dt = LOPHOCBus.LayBangLopHoc(lh)
            dtgvDSLopHoc.DataSource = dt
        ElseIf (rdKhoi12.Checked = True) Then
            lh.makhoi = "K12"
            dt = LOPHOCBus.LayBangLopHoc(lh)
            dtgvDSLopHoc.DataSource = dt
        Else
            dt = LOPHOCBus.LayBangLopHoc()
            dtgvDSLopHoc.DataSource = dt
        End If
    End Sub

    'MON HOC
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable()
        dt = MONHOCBus.XLDSMonHoc()
        dtgvDSMonHoc.DataSource = dt

        Dim dt1 As New DataTable()
        dt1 = GIAOVIENBus.LayBangGiaoVien()
        dtgvDSGiaoVien.DataSource = dt1
    End Sub


    Private Sub dtgvDSMonHoc_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgvDSMonHoc.SelectionChanged
        Dim rowIndex As Integer = dtgvDSMonHoc.CurrentRow.Index
        Dim maMH As String = dtgvDSMonHoc("MaMonHoc", rowIndex).Value
        Dim tenMonHoc As String = dtgvDSMonHoc("TenMonHoc", rowIndex).Value
        Dim STMin As Integer = dtgvDSMonHoc("QDSTHLTTT", rowIndex).Value
        Dim STMax As Integer = dtgvDSMonHoc("QDSTHLTTD", rowIndex).Value
        txtMaMonHoc.Text = maMH
        txtTenMonHoc.Text = tenMonHoc
        txtQuyDinhSoTietHocLienTiepToiThieu.Text = STMin
        txtQuyDinhSoTietHocLienTiepToiDa.Text = STMax

        Dim mh As New MonHoc
        mh.mamonhoc = txtMaMonHoc.Text
        Dim dt1 As New DataTable()
        dt1 = MONHOCBus.XLDSGVPhuTrach(mh.mamonhoc)
        dtgvDSGiaoVienPhuTrach.DataSource = dt1
    End Sub


    Private Sub btnTaoMonHocMoi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTaoMonHocMoi.Click
        Dim mh As New MonHoc
        mh.mamonhoc = txtMaMonHoc.Text
        mh.tenmonhoc = txtTenMonHoc.Text
        mh.quydinhsotiethoclientieptoithieu = txtQuyDinhSoTietHocLienTiepToiThieu.Text
        mh.quydinhsotiethoclientieptoida = txtQuyDinhSoTietHocLienTiepToiDa.Text
        MONHOCBus.TaoMonHocMoi(mh)

        mh = MONHOCBus.TaoMonHocMoi(txtMaMonHoc.Text, txtTenMonHoc.Text)
        txtMaMonHoc.Text = mh.mamonhoc
        txtTenMonHoc.Text = mh.mamonhoc
        MONHOCBus.TaoMonHocMoi(mh)
    End Sub

    'GIAO VIEN
    Private Sub dtgvDSGiaoVien_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgvDSGiaoVien.SelectionChanged
        Dim rowIndex As Integer = dtgvDSGiaoVien.CurrentRow.Index
        Dim maGV As String = dtgvDSGiaoVien("Mã Giáo Viên", rowIndex).Value
        Dim hotenGV As String = dtgvDSGiaoVien("Họ Tên Giáo Viên", rowIndex).Value
        Dim tentat As String = dtgvDSGiaoVien("Tên Tắt", rowIndex).Value
        Dim diachi As String = dtgvDSGiaoVien("Địa Chỉ", rowIndex).Value
        Dim dienthoai As String = dtgvDSGiaoVien("Điện Thoại", rowIndex).Value
        txtMaGiaoVien.Text = maGV
        txtTenGiaoVien.Text = hotenGV
        txtTenTat.Text = tentat
        txtDiaChi.Text = diachi
        txtDienThoai.Text = dienthoai

        Dim gv As New GiaoVien
        gv.magiaovien = txtMaGiaoVien.Text
        Dim dt As New DataTable()
        dt = GIAOVIENBus.LayBangLichRanh(gv)
        dtgvLichRanhGiaoVien.DataSource = dt
    End Sub

    Private Sub txtMaGiaoVien_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMaGiaoVien.TextChanged
        Dim flag As Boolean = False
        Dim flag1 As Boolean = False
        Dim flag2 As Boolean = False
        Dim flag3 As Boolean = False
        Dim flag4 As Boolean = False
        Dim flag5 As Boolean = False
        Dim flag6 As Boolean = False
        Dim flag7 As Boolean = False
        'Dim flag8 As Boolean
        Dim flag9 As Boolean
        Dim flag10 As Boolean
        Dim flag11 As Boolean
        Dim flag12 As Boolean = False
        Dim flag13 As Boolean = False
        Dim flag14 As Boolean = False
        Dim flag15 As Boolean = False
        Dim flag16 As Boolean = False
        Dim flag17 As Boolean = False
        Dim flag18 As Boolean = False
        'Dim flag19 As Boolean

        chkbxGDCD.Checked = False
        chkbxDaiLuong.Checked = False
        chkbxDaiSo.Checked = False
        chkbxAnh.Checked = False
        chkbxDia.Checked = False
        chkbxGiaiTich.Checked = False
        chkbxHinhHoc.Checked = False
        chkbxHoa.Checked = False
        chkbxKTCN.Checked = False
        chkbxKTNN.Checked = False
        chkbxSHCN.Checked = False
        chkbxLy.Checked = False
        chkbxSHDC.Checked = False
        chkbxSu.Checked = False
        chkbxSinh.Checked = False
        chkbxTin.Checked = False
        chkbxTheDuc.Checked = False
        chkbxVan.Checked = False

        flag = GIAOVIENBus.LayMH("GDCD", txtMaGiaoVien.Text)
        flag1 = GIAOVIENBus.LayMH("Đại Số", txtMaGiaoVien.Text)
        flag2 = GIAOVIENBus.LayMH("Hình Học", txtMaGiaoVien.Text)
        flag3 = GIAOVIENBus.LayMH("Giải Tích", txtMaGiaoVien.Text)
        flag4 = GIAOVIENBus.LayMH("Đại Lượng", txtMaGiaoVien.Text)
        flag5 = GIAOVIENBus.LayMH("Tin", txtMaGiaoVien.Text)
        flag6 = GIAOVIENBus.LayMH("Lý", txtMaGiaoVien.Text)
        flag7 = GIAOVIENBus.LayMH("Hóa", txtMaGiaoVien.Text)
        'flag8 = GIAOVIENBus.LayMH("Hóa VC", txtMaGiaoVien.Text)
        flag9 = GIAOVIENBus.LayMH("Sinh", txtMaGiaoVien.Text)
        flag10 = GIAOVIENBus.LayMH("Anh", txtMaGiaoVien.Text)
        flag11 = GIAOVIENBus.LayMH("Văn", txtMaGiaoVien.Text)
        flag12 = GIAOVIENBus.LayMH("Sử", txtMaGiaoVien.Text)
        flag13 = GIAOVIENBus.LayMH("Địa", txtMaGiaoVien.Text)
        flag14 = GIAOVIENBus.LayMH("KTNN", txtMaGiaoVien.Text)
        flag15 = GIAOVIENBus.LayMH("KTCN", txtMaGiaoVien.Text)
        flag16 = GIAOVIENBus.LayMH("Thể Dục", txtMaGiaoVien.Text)
        flag17 = GIAOVIENBus.LayMH("SHCN", txtMaGiaoVien.Text)
        flag18 = GIAOVIENBus.LayMH("SHDC", txtMaGiaoVien.Text)
        'flag19 = GIAOVIENBus.LayMH("", txtMaGiaoVien.Text)

        If (flag = True) Then
            chkbxGDCD.Checked = True
        End If
        If (flag1 = True) Then
            chkbxDaiSo.Checked = True
        End If
        If (flag2 = True) Then
            chkbxHinhHoc.Checked = True
        End If
        If (flag3 = True) Then
            chkbxGiaiTich.Checked = True
        End If
        If (flag4 = True) Then
            chkbxDaiLuong.Checked = True
        End If
        If (flag5 = True) Then
            chkbxTin.Checked = True
        End If
        If (flag6 = True) Then
            chkbxLy.Checked = True
        End If
        If (flag7 = True) Then
            chkbxHoa.Checked = True
        End If
        If (flag9 = True) Then
            chkbxSinh.Checked = True
        End If
        If (flag10 = True) Then
            chkbxAnh.Checked = True
        End If
        If (flag11 = True) Then
            chkbxVan.Checked = True
        End If
        If (flag12 = True) Then
            chkbxSu.Checked = True
        End If
        If (flag13 = True) Then
            chkbxDia.Checked = True
        End If
        If (flag14 = True) Then
            chkbxKTCN.Checked = True
        End If
        If (flag15 = True) Then
            chkbxKTNN.Checked = True
        End If
        If (flag16 = True) Then
            chkbxTheDuc.Checked = True
        End If
        If (flag17 = True) Then
            chkbxSHCN.Checked = True
        End If
        If (flag18 = True) Then
            chkbxSHDC.Checked = True
        End If
    End Sub

    'PHAN CONG GIANG DAY THEO LOP HOC
    Private Sub rdK10_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdK10.CheckedChanged
        If (rdK10.Checked = True) Then
            rdK11.Checked = False
            rdK12.Checked = False
            rdTatCa.Checked = False
            Dim lh As New LopHoc
            lh.makhoi = "k10"
            Dim dt As New DataTable()
            dt = PCGDTHEOLOPHOCBus.LayBangGiaoVien(lh.makhoi)
            dtgvDSGVPhanCong.DataSource = dt

            Dim dtlophoc As New DataTable()
            dtlophoc = LOPHOCBus.LayBangLopHoc(lh)
            cmbTenLopHoc.DataSource = dtlophoc
        End If
    End Sub

    Private Sub rdK11_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdK11.CheckedChanged
        If (rdK11.Checked = True) Then
            rdK10.Checked = False
            rdK12.Checked = False
            rdTatCa.Checked = False
            Dim lh As New LopHoc
            lh.makhoi = "k11"
            Dim dt As New DataTable()
            dt = PCGDTHEOLOPHOCBus.LayBangGiaoVien(lh.makhoi)
            dtgvDSGVPhanCong.DataSource = dt
        End If
    End Sub

    Private Sub rdK12_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdK12.CheckedChanged
        If (rdK12.Checked = True) Then
            rdK10.Checked = False
            rdK11.Checked = False
            rdTatCa.Checked = False
            Dim lh As New LopHoc
            lh.makhoi = "k12"
            Dim dt As New DataTable()
            dt = PCGDTHEOLOPHOCBus.LayBangGiaoVien(lh.makhoi)
            dtgvDSGVPhanCong.DataSource = dt
        End If
    End Sub

    Private Sub rdTatCa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdTatCa.CheckedChanged
        If (rdTatCa.Checked = True) Then
            rdK10.Checked = False
            rdK11.Checked = False
            rdK12.Checked = False
            Dim dt2 As New DataTable()
            Dim gv As New GiaoVien
            gv.magiaovien = txtMaGiaoVien.Text
            dt2 = GIAOVIENBus.LayBangGiaoVien()
            dtgvDSGVPhanCong.DataSource = dt2
        End If
    End Sub

    
End Class
