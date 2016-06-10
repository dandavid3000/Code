Imports System
Imports System.Data
Imports System.Configuration
Imports Microsoft
Imports System.Data.OleDb
Imports DTO
Imports BUSLayer

Public Class PTNKScheduling
    Public co As Boolean = False
    Public co1 As Boolean = False
    Public co2 As Boolean = False

    Public ma As String

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'LOPHOC
        rdKhoi10.Checked = True
        Dim lh As New LopHoc
        lh.makhoi = "k10"
        Dim dtDS As New DataTable()
        dtDS = LOPHOCBus.LayBangLopHoc(lh)
        dtgvDSLopHoc.DataSource = dtDS
        With dtgvDSLopHoc
            .Columns("STT").Width = 35
            .Columns("STT").DisplayIndex = 0
            .Columns("STT").ReadOnly = True
            .AlternatingRowsDefaultCellStyle.ForeColor = Color.Red
            .Columns("STT").DefaultCellStyle.BackColor = Color.DeepSkyBlue
        End With

        With dtgvLichRanh
            .Columns("Tiết").Width = 35
            .Columns("Tiết").DisplayIndex = 0
            .Columns("Tiết").ReadOnly = True
            .Columns("Thứ 2").ReadOnly = True
            .Columns("Thứ 3").ReadOnly = True
            .Columns("Thứ 4").ReadOnly = True
            .Columns("Thứ 5").ReadOnly = True
            .Columns("Thứ 6").ReadOnly = True
            .Columns("Thứ 7").ReadOnly = True
            .Columns("Chủ Nhật").ReadOnly = True
            .AlternatingRowsDefaultCellStyle.ForeColor = Color.Red
            .Columns("Tiết").DefaultCellStyle.BackColor = Color.DeepSkyBlue
        End With

        'MONHOC
        Dim dt As New DataTable()
        dt = MONHOCBus.XLDSMonHoc()
        dtgvDSMonHoc.DataSource = dt
        With dtgvDSMonHoc
            .Columns("STT").Width = 35
            .Columns("STT").DisplayIndex = 0
            .Columns("STT").ReadOnly = True
            .AlternatingRowsDefaultCellStyle.ForeColor = Color.Red
            .Columns("STT").DefaultCellStyle.BackColor = Color.DeepSkyBlue
        End With

        Dim dt3 As New DataTable()
        dt3 = MONHOCBus.XLDSGVPhuTrach(txtMaMonHoc.Text)
        dtgvDSGiaoVienPhuTrach.DataSource = dt3
        With dtgvDSGiaoVienPhuTrach
            .Columns("STT").Width = 35
            .Columns("STT").DisplayIndex = 0
            .Columns("STT").ReadOnly = True
            .AlternatingRowsDefaultCellStyle.ForeColor = Color.Red
            .Columns("STT").DefaultCellStyle.BackColor = Color.DeepSkyBlue
        End With
        'GIAOVIEN
        Dim dt1 As New DataTable()
        dt1 = GIAOVIENBus.LayBangGiaoVien()
        dtgvDSGiaoVien.DataSource = dt1
        With dtgvDSGiaoVien
            .Columns("STT").Width = 35
            .Columns("STT").DisplayIndex = 0
            .Columns("STT").ReadOnly = True
            .AlternatingRowsDefaultCellStyle.ForeColor = Color.Red
            .Columns("STT").DefaultCellStyle.BackColor = Color.DeepSkyBlue
        End With

        Dim gv As New GiaoVien
        gv.magiaovien = txtMaGiaoVien.Text
        Dim dt4 As New DataTable()
        dt4 = GIAOVIENBus.LayBangLichRanh(gv)
        dtgvLichRanhGiaoVien.DataSource = dt4
        With dtgvLichRanhGiaoVien
            .Columns("Tiết").Width = 35
            .Columns("Tiết").DisplayIndex = 0
            .Columns("Tiết").ReadOnly = True
            .AlternatingRowsDefaultCellStyle.ForeColor = Color.Red
            .Columns("Tiết").DefaultCellStyle.BackColor = Color.DeepSkyBlue
        End With
        'PHANCONGGIANGDAYTHEOGIAOVIEN
        rdPhanCongTheoLopHoc.Checked = True
        pnlPCGD.Controls.Add(New ucPCGDTheoLopHoc())

        'LICHDAYGIAOVIEN
        Dim dtDSGV As New DataTable()
        dtDSGV = LICHDAYGIAOVIENBus.LayBangGiaoVien()
        dtgvDSGVien.DataSource = dtDSGV
        Dim dtXLGV As New DataTable()
        dtXLGV = LICHDAYGIAOVIENBus.XLBangGiaoVien()
        cmbTenGV.DataSource = dtXLGV
        cmbTenGV.DisplayMember = "TenGiaoVien"
        cmbTenGV.ValueMember = "MaGiaoVien"

        'THOIKHOABIEULOPHOC
        rdoKhoi10.Checked = True
        Dim dt2 As New DataTable()
        dt2 = THOIKHOABIEULOPHOCBus.LayThoiKhoaBieuLopHoc(txtMaLH.Text)
        DtGridThoiKhoaBieuLopHoc.DataSource = dt2

        'QUYDINHTOANTRUONG
        txtSoTietToiDaTrongNgay.Text = QUYDINHTOANTRUONGBus.LaySTTDTrongNgay()
        txtTietGay.Text = QUYDINHTOANTRUONGBus.LayTietGay()
        txtSoTietToiDaDuocHocTrongNgay.Text = QUYDINHTOANTRUONGBus.LaySTTDTDHrongNgay()

    End Sub

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

            Dim dt1 As New DataTable()
            lh.malophoc = txtMaLopHoc.Text
            dt1 = LOPHOCBus.LayBangLichRanh(lh)
            dtgvLichRanh.DataSource = dt1
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
        Dim makhoi As String = ""
        If (rdKhoi10.Checked = True) Then
            makhoi = "K10"
        ElseIf (rdKhoi11.Checked = True) Then
            makhoi = "K11"
        ElseIf (rdKhoi12.Checked = True) Then
            makhoi = "K12"
        Else
            MessageBox.Show("Không thể tạo lớp học không có mã khối")
            Return
        End If
        lh = LOPHOCBus.TaoLopHoc(txtTenLopHoc.Text, makhoi)
        txtMaLopHoc.Text = lh.malophoc
        txtTenLopHoc.Text = ""

        Dim dt As New DataTable()
        dt = LOPHOCBus.LichRanh()
        dtgvLichRanh.DataSource = dt

        ma = txtMaLopHoc.Text
        co = True
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


        If (maLH = ma) Then
            Dim dt As New DataTable()
            dt = LOPHOCBus.LichRanh()
            dtgvLichRanh.DataSource = dt
        End If
    End Sub

    Private Sub btnXoaLopHoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoaLopHoc.Click
        Dim dt As New DataTable()
        dt = dtgvDSLopHoc.DataSource
        If (dtgvDSLopHoc.CurrentRow IsNot Nothing) Then
            Dim RowIndex As Integer
            RowIndex = dtgvDSLopHoc.CurrentRow.Index
            Dim malophoc As String = dtgvDSLopHoc("MaLopHoc", RowIndex).Value
            dtgvDSLopHoc.Rows.RemoveAt(RowIndex)
        End If
    End Sub

    Private Sub btnCapNhatDuLieu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhatDuLieu.Click
        Dim lh As New LopHoc
        Dim makhoi As String
        If (rdKhoi10.Checked = True) Then
            makhoi = "K10"
        ElseIf (rdKhoi11.Checked = True) Then
            makhoi = "K11"
        Else
            makhoi = "K12"
        End If
        If (co = True) Then
            lh = LOPHOCBus.TaoLopHoc(txtTenLopHoc.Text, makhoi)
            txtMaLopHoc.Text = lh.malophoc
            LOPHOCBus.TaoLopHocMoi(lh)
            Dim dt As New DataTable()
            dt = LayBangLopHoc(lh)
            dtgvDSLopHoc.DataSource = dt
            co = False
        Else
            lh.makhoi = makhoi
            If (rdKhoiTatCa.Checked = True) Then
                MessageBox.Show("Không cập nhật được")
            End If
            LOPHOCBus.CapNhatLai(dtgvDSLopHoc.DataSource, lh)
        End If
    End Sub

    'MON HOC 
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
        mh = MONHOCBus.TaoMonHocMoi(txtTenMonHoc.Text)
        txtMaMonHoc.Text = mh.mamonhoc
        txtTenMonHoc.Text = ""
        txtQuyDinhSoTietHocLienTiepToiThieu.Text = 0
        txtQuyDinhSoTietHocLienTiepToiDa.Text = 0
        co1 = True
    End Sub

    Private Sub btnXoaMonHoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoaMonHoc.Click
        Dim dt As New DataTable()
        dt = dtgvDSMonHoc.DataSource
        If (dtgvDSMonHoc.CurrentRow IsNot Nothing) Then
            Dim RowIndex As Integer
            RowIndex = dtgvDSMonHoc.CurrentRow.Index
            dtgvDSMonHoc.Rows.RemoveAt(RowIndex)
        End If
    End Sub

    Private Sub btnCapNhatDuLieu2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhatDuLieu2.Click
        Dim mh As New MonHoc
        mh.mamonhoc = txtMaMonHoc.Text
        If (co1 = True) Then
            mh = MONHOCBus.TaoMonHocMoi(txtTenMonHoc.Text)
            mh.tenmonhoc = txtTenMonHoc.Text
            mh.quydinhsotiethoclientieptoithieu = txtQuyDinhSoTietHocLienTiepToiThieu.Text
            mh.quydinhsotiethoclientieptoida = txtQuyDinhSoTietHocLienTiepToiDa.Text
            MONHOCBus.TaoMonHocMoi(mh)
            Dim dt As New DataTable()
            dt = MONHOCBus.XLDSMonHoc()
            dtgvDSMonHoc.DataSource = dt
        Else
            MONHOCBus.CapNhatLaiMH(dtgvDSMonHoc.DataSource)
        End If
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
        Dim flag9 As Boolean = False
        Dim flag10 As Boolean = False
        Dim flag11 As Boolean = False
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

    Private Sub btnTaoGiaoVienMoi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTaoGiaoVienMoi.Click
        Dim gv As New GiaoVien
        gv = GIAOVIENBus.Tao1GiaoVien(txtTenGiaoVien.Text, txtTenTat.Text)
        txtMaGiaoVien.Text = gv.magiaovien
        txtTenGiaoVien.Text = ""
        txtTenTat.Text = ""
        txtDiaChi.Text = ""
        txtDienThoai.Text = ""
        co2 = True
    End Sub

    Private Sub btnCapNhatDuLieu3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhatDuLieu3.Click
        Dim gv As New GiaoVien
        If (co2 = True) Then
            gv = GIAOVIENBus.Tao1GiaoVien(txtTenGiaoVien.Text, txtMaGiaoVien.Text)
            gv.magiaovien = txtMaGiaoVien.Text
            gv.hotengiaovien = txtTenGiaoVien.Text
            gv.tentat = txtTenTat.Text
            gv.diachi = txtDiaChi.Text
            gv.dienthoai = txtDienThoai.Text
            GIAOVIENBus.TaoGiaoVienMoi(gv)
            Dim dt As New DataTable()
            dt = GIAOVIENBus.LayBangGiaoVien()
            dtgvDSGiaoVien.DataSource = dt
        Else
            GIAOVIENBus.CapNhatLai(dtgvDSGiaoVien.DataSource)
        End If
    End Sub

    Private Sub btnXoaGiaoVien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoaGiaoVien.Click
        Dim dt As New DataTable()
        dt = dtgvDSGiaoVien.DataSource
        If (dtgvDSGiaoVien.CurrentRow IsNot Nothing) Then
            Dim RowIndex As Integer
            RowIndex = dtgvDSGiaoVien.CurrentRow.Index
            Dim magiaovien As String = dtgvDSGiaoVien("Mã Giáo Viên", RowIndex).Value
            dtgvDSGiaoVien.Rows.RemoveAt(RowIndex)
        End If
    End Sub

    'PHAN CONG GIANG DAY THEO LOP HOC  
    Private Sub dtgvDSGVien_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgvDSGVien.SelectionChanged
        Dim rowInDex As Integer = dtgvDSGVien.CurrentRow.Index
        Dim maGV As String = dtgvDSGVien("Mã Giáo Viên", rowInDex).Value
        txtMGVien.Text = maGV
        Dim TenTat As String = dtgvDSGVien("Tên Tắt", rowInDex).Value
        txtTTat.Text = TenTat

    End Sub

    Private Sub rdPhanCongTheoBoMon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdPhanCongTheoBoMon.CheckedChanged
        If (rdPhanCongTheoBoMon.Checked) Then
            rdPhanCongTheoLopHoc.Checked = False
            pnlPCGD.Controls.Clear()
            pnlPCGD.Controls.Add(New ucPCGDTheoBoMon())
        End If
    End Sub

    Private Sub rdPhanCongTheoLopHoc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdPhanCongTheoLopHoc.CheckedChanged
        If (rdPhanCongTheoLopHoc.Checked) Then
            rdPhanCongTheoBoMon.Checked = False
            pnlPCGD.Controls.Clear()
            pnlPCGD.Controls.Add(New ucPCGDTheoLopHoc())
        End If
    End Sub

    Private Sub rdoKhoi10_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoKhoi10.CheckedChanged
        Dim makhoi As String
        If (rdoKhoi10.Checked = True) Then
            rdoKhoi10.Checked = True
            rdoKhoi11.Checked = False
            rdoKhoi12.Checked = False
            rdoTatCa.Checked = False
            makhoi = "k10"
            Dim dt As New DataTable()
            dt = THOIKHOABIEULOPHOCBus.LayDSLopHoc(makhoi)
            cmbTLHoc.DataSource = dt
            cmbTLHoc.DisplayMember = "TenLopHoc"
            cmbTLHoc.ValueMember = "MaLopHoc"
            Dim ma As String = cmbTLHoc.SelectedValue
            txtMaLH.Text = ma
        End If
    End Sub

    Private Sub rdoKhoi11_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoKhoi11.CheckedChanged
        Dim makhoi As String
        If (rdoKhoi11.Checked = True) Then
            rdoKhoi11.Checked = True
            rdoKhoi10.Checked = False
            rdoKhoi12.Checked = False
            rdoTatCa.Checked = False
            makhoi = "k11"
            Dim dt As New DataTable()
            dt = THOIKHOABIEULOPHOCBus.LayDSLopHoc(makhoi)
            cmbTLHoc.DataSource = dt
            cmbTLHoc.DisplayMember = "TenLopHoc"
            cmbTLHoc.ValueMember = "MaLopHoc"
        End If
    End Sub

    Private Sub rdoKhoi12_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoKhoi12.CheckedChanged
        Dim makhoi As String
        If (rdoKhoi12.Checked = True) Then
            rdoKhoi12.Checked = True
            rdoKhoi11.Checked = False
            rdoKhoi10.Checked = False
            rdoTatCa.Checked = False
            makhoi = "k12"
            Dim dt As New DataTable()
            dt = THOIKHOABIEULOPHOCBus.LayDSLopHoc(makhoi)
            cmbTLHoc.DataSource = dt
            cmbTLHoc.DisplayMember = "TenLopHoc"
            cmbTLHoc.ValueMember = "MaLopHoc"
        End If
    End Sub

    Private Sub rdoTatCa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoTatCa.CheckedChanged
        If (rdoTatCa.Checked = True) Then
            rdoTatCa.Checked = True
            rdoKhoi10.Checked = False
            rdoKhoi12.Checked = False
            rdoKhoi11.Checked = False
            Dim dt As New DataTable()
            dt = THOIKHOABIEULOPHOCBus.LayDSLopHoc()
            cmbTLHoc.DataSource = dt
            cmbTLHoc.DisplayMember = "TenLopHoc"
            cmbTLHoc.ValueMember = "MaLopHoc"
        End If
    End Sub

    Private Sub cmbTLHoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTLHoc.SelectedIndexChanged
        Dim ma As String = cmbTLHoc.SelectedValue.ToString()
        txtMaLH.Text = ma
        Dim dt As New DataTable()
        dt = THOIKHOABIEULOPHOCBus.LayThoiKhoaBieuLopHoc(ma)
        DtGridThoiKhoaBieuLopHoc.DataSource = dt
    End Sub

    Private Sub btnDongY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDongY.Click
        QUYDINHTOANTRUONGBus.CapNhat(txtSoTietToiDaTrongNgay.Text, txtTietGay.Text, txtSoTietToiDaDuocHocTrongNgay.Text)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        tbcManHinhChinh.SelectTab(0)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        tbcManHinhChinh.SelectTab(1)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        tbcManHinhChinh.SelectTab(2)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        tbcManHinhChinh.SelectTab(3)
    End Sub

    Private Sub btnXuatRaTapTin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXuatRaTapTin.Click
        Dim app As New Microsoft.Office.Interop.Excel.Application()
        app.Visible = False
        Dim workbooks As Microsoft.Office.Interop.Excel.Workbooks
        workbooks = app.Workbooks
        Dim book As Microsoft.Office.Interop.Excel._Workbook
        book = workbooks.Add(Type.Missing)
        Dim sheet As Microsoft.Office.Interop.Excel._Worksheet
        sheet = book.ActiveSheet

        Dim dt As DataTable
        dt = Me.dtgvDSLopHoc.DataSource
        sheet.Range("A1", Type.Missing).Value2 = "STT"
        sheet.Range("B1", Type.Missing).Value2 = "MaLopHoc"
        sheet.Range("C1", Type.Missing).Value2 = "TenLopHoc"

        Dim colIndex = 1
        Dim j As Integer = 2

        For i As Integer = 0 To dt.Rows.Count - 1
            Dim dr As DataRow
            dr = dt.Rows(i)
            sheet.Range("A" + j.ToString(), Type.Missing).Value2 = dr(0).ToString()
            sheet.Range("B" + j.ToString(), Type.Missing).Value2 = dr(1).ToString()
            sheet.Range("C" + j.ToString(), Type.Missing).Value2 = dr(2).ToString()
            j = j + 1
        Next
        Me.SaveFileDialog1.ShowDialog()
        Dim name = Me.SaveFileDialog1.FileName
        book.SaveAs(name, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing)
    End Sub

    Private Sub btnXoaTapTin2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoaTapTin2.Click
        Dim app As New Microsoft.Office.Interop.Excel.Application()
        app.Visible = False
        Dim workbooks As Microsoft.Office.Interop.Excel.Workbooks
        workbooks = app.Workbooks
        Dim book As Microsoft.Office.Interop.Excel._Workbook
        book = workbooks.Add(Type.Missing)
        Dim sheet As Microsoft.Office.Interop.Excel._Worksheet
        sheet = book.ActiveSheet

        Dim dt As DataTable
        dt = Me.dtgvDSMonHoc.DataSource
        sheet.Range("A1", Type.Missing).Value2 = "STT"
        sheet.Range("B1", Type.Missing).Value2 = "MaMonHoc"
        sheet.Range("C1", Type.Missing).Value2 = "TenMonHoc"
        sheet.Range("D1", Type.Missing).Value2 = "QDSTHLTTT"
        sheet.Range("E1", Type.Missing).Value2 = "QDSTHLTTD"

        Dim colIndex = 1
        Dim j As Integer = 2

        For i As Integer = 0 To dt.Rows.Count - 1
            Dim dr As DataRow
            dr = dt.Rows(i)
            sheet.Range("A" + j.ToString(), Type.Missing).Value2 = dr(0).ToString()
            sheet.Range("B" + j.ToString(), Type.Missing).Value2 = dr(1).ToString()
            sheet.Range("C" + j.ToString(), Type.Missing).Value2 = dr(2).ToString()
            sheet.Range("D" + j.ToString(), Type.Missing).Value2 = dr(3).ToString()
            sheet.Range("E" + j.ToString(), Type.Missing).Value2 = dr(4).ToString()
            j = j + 1
        Next
        Me.SaveFileDialog1.ShowDialog()
        Dim name = Me.SaveFileDialog1.FileName
        book.SaveAs(name, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing)
    End Sub

    Private Sub btnXuatRaTapTin3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXuatRaTapTin3.Click
        Dim app As New Microsoft.Office.Interop.Excel.Application()
        app.Visible = False
        Dim workbooks As Microsoft.Office.Interop.Excel.Workbooks
        workbooks = app.Workbooks
        Dim book As Microsoft.Office.Interop.Excel._Workbook
        book = workbooks.Add(Type.Missing)
        Dim sheet As Microsoft.Office.Interop.Excel._Worksheet
        sheet = book.ActiveSheet

        Dim dt As DataTable
        dt = Me.dtgvDSGiaoVien.DataSource
        sheet.Range("A1", Type.Missing).Value2 = "STT"
        sheet.Range("B1", Type.Missing).Value2 = "Mã Giáo Viên"
        sheet.Range("C1", Type.Missing).Value2 = "Họ Tên Giáo Viên"
        sheet.Range("D1", Type.Missing).Value2 = "Tên Tắt"
        sheet.Range("E1", Type.Missing).Value2 = "Địa Chỉ"
        sheet.Range("F1", Type.Missing).Value2 = "Điên Thoại"
        Dim colIndex = 1
        Dim j As Integer = 2

        For i As Integer = 0 To dt.Rows.Count - 1
            Dim dr As DataRow
            dr = dt.Rows(i)
            sheet.Range("A" + j.ToString(), Type.Missing).Value2 = dr(0).ToString()
            sheet.Range("B" + j.ToString(), Type.Missing).Value2 = dr(1).ToString()
            sheet.Range("C" + j.ToString(), Type.Missing).Value2 = dr(2).ToString()
            sheet.Range("D" + j.ToString(), Type.Missing).Value2 = dr(3).ToString()
            sheet.Range("E" + j.ToString(), Type.Missing).Value2 = dr(4).ToString()
            sheet.Range("F" + j.ToString(), Type.Missing).Value2 = dr(5).ToString()
            j = j + 1
        Next
        Me.SaveFileDialog1.ShowDialog()
        Dim name = Me.SaveFileDialog1.FileName
        book.SaveAs(name, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing)
    End Sub

    Private Sub btnBanHet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBanHet.Click
        Dim dt As New DataTable()
        dt = GIAOVIENBus.XLLichBan()
        dtgvLichRanhGiaoVien.DataSource = dt
    End Sub

    Private Sub dtgvLichRanhGiaoVien_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgvLichRanhGiaoVien.CellContentClick
        Dim rowIndex As String = dtgvLichRanhGiaoVien.CurrentCell.Value.ToString()
        Dim dt1 As New DataTable()
        If (rowIndex = "Bận") Then
            rowIndex = "Buộc Sắp Xếp"
        ElseIf (rowIndex = "Rãnh") Then
            rowIndex = "Bận"
        Else
            rowIndex = "Rãnh"
        End If
        dtgvLichRanhGiaoVien.CurrentCell.Value = rowIndex
    End Sub

    Private Sub TrợGiúpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrợGiúpToolStripMenuItem.Click
        System.Diagnostics.Process.Start("help.chm")
    End Sub

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub
End Class