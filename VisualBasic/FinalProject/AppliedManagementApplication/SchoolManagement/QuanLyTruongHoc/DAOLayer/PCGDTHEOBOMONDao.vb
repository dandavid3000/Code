Imports System.Data.OleDb
Imports DTO

Public Module PCGDTHEOBOMONDao
    Public Function XLBangGiaoVien() As DataTable
        Dim dt As New DataTable()
        Dim cn As New OleDbConnection
        cn = MDatabase.ConnectionData()
        Dim strSQL As String
        strSQL = "Select * From GiaoVien"
        Dim da As New OleDbDataAdapter(strSQL, cn)
        da.Fill(dt)
        cn.Close()
        Return dt
    End Function

    Public Function LayBangGiaoVien() As DataTable
        Dim dt As New DataTable()
        dt = XLBangGiaoVien()
        Dim dt1 As New DataTable()
        dt1.Columns.Add("STT")
        dt1.Columns.Add("Mã Giáo Viên")
        dt1.Columns.Add("Họ Tên Giáo Viên")
        dt1.Columns.Add("Tên Tắt")
        dt1.Columns.Add("Địa Chỉ")
        dt1.Columns.Add("Điện Thoại")
        Dim i As Integer = 0
        While (i < dt.Rows.Count)
            Dim row As DataRow = dt1.NewRow
            row(0) = i + 1
            row(1) = dt.Rows(i)("MaGiaoVien")
            row(2) = dt.Rows(i)("HoTenGiaoVien")
            row(3) = dt.Rows(i)("TenTat")
            row(4) = dt.Rows(i)("DiaChi")
            row(5) = dt.Rows(i)("DienThoai")
            dt1.Rows.Add(row)
            i = i + 1
        End While
        Return dt1
    End Function
    
    Public Function XLPhanCong(ByVal malophoc As String) As DataTable
        Dim dt As New DataTable()
        Dim cn As New OleDbConnection
        cn = MDatabase.ConnectionData()
        Dim strSQL As String
        strSQL = "Select distinct lh.TenLopHoc, mh.TenMonHoc, pc.SoTietHocTuan, gv.HoTenGiaoVien, pc.SoTietHocLienTiepToiThieu, pc.SoTietHocLienTiepToiDa,pc.SoBuoiHocToiThieu, pc.SoBuoiHocToiDa"
        strSQL = strSQL + " From LopHoc lh, PhanCong pc, GiaoVien gv, MonHoc mh"
        strSQL = strSQL + " Where pc.MaGiaoVien = gv.MaGiaoVien and lh.MaLopHoc = pc.MaLopHoc and pc.MaMonHoc = mh.MaMonHoc and lh.MaLopHoc = '" + malophoc + "'"
        Dim da As New OleDbDataAdapter(strSQL, cn)
        da.Fill(dt)
        Return dt
    End Function

    Public Function LayBangPhanCong(ByVal malophoc As String) As DataTable
        Dim dt As New DataTable()
        dt = XLPhanCong(malophoc)
        Dim dt1 As New DataTable()
        dt1.Columns.Add("STT")
        dt1.Columns.Add("Tên Lớp Học")
        dt1.Columns.Add("Môn Học")
        dt1.Columns.Add("Tổng Số Tiết/Tuần")
        dt1.Columns.Add("Giáo Viên")
        dt1.Columns.Add("STHLTTT")
        dt1.Columns.Add("STHLTTD")
        dt1.Columns.Add("SBHTT")
        dt1.Columns.Add("SBHTD")
        Dim i As Integer = 0
        While (i < dt.Rows.Count)
            Dim row As DataRow = dt1.NewRow
            row(0) = i + 1
            row(1) = dt.Rows(i)("TenLopHoc")
            row(2) = dt.Rows(i)("TenMonHoc")
            row(3) = dt.Rows(i)("SoTietHocTuan")
            row(4) = dt.Rows(i)("HoTenGiaoVien")
            row(5) = dt.Rows(i)("SoTietHocLienTiepToiThieu")
            row(6) = dt.Rows(i)("SoTietHocLienTiepToiDa")
            row(7) = dt.Rows(i)("SoBuoiHocToiThieu")
            row(8) = dt.Rows(i)("SoBuoiHocToiDa")
            dt1.Rows.Add(row)
            i = i + 1
        End While
        Return dt1
    End Function

    'Phan cong theo giao vien
    Public Function XLPhanCongTheoGV(ByVal maGV As String) As DataTable
        Dim dt As New DataTable()
        Dim cn As New OleDbConnection
        cn = MDatabase.ConnectionData()
        Dim strSQL As String
        strSQL = "Select distinct lh.TenLopHoc, mh.TenMonHoc, pc.SoTietHocTuan, gv.HoTenGiaoVien, pc.SoTietHocLienTiepToiThieu, pc.SoTietHocLienTiepToiDa,pc.SoBuoiHocToiThieu, pc.SoBuoiHocToiDa"
        strSQL = strSQL + " From LopHoc lh, PhanCong pc, GiaoVien gv, MonHoc mh"
        strSQL = strSQL + " Where lh.MaLopHoc = pc.MaLopHoc and pc.MaMonHoc = mh.MaMonHoc and gv.MaGiaoVien= '" + maGV + "'"
        Dim da As New OleDbDataAdapter(strSQL, cn)
        da.Fill(dt)
        Return dt
    End Function

    Public Function LayBangPhanCongTheoGV(ByVal maGV As String) As DataTable
        Dim dt As New DataTable()
        dt = XLPhanCongTheoGV(maGV)
        Dim dt1 As New DataTable()
        dt1.Columns.Add("STT")
        dt1.Columns.Add("Tên Lớp Học")
        dt1.Columns.Add("Môn Học")
        dt1.Columns.Add("Tổng Số Tiết/Tuần")
        dt1.Columns.Add("Giáo Viên")
        dt1.Columns.Add("STHLTTT")
        dt1.Columns.Add("STHLTTD")
        dt1.Columns.Add("SBHTT")
        dt1.Columns.Add("SBHTD")
        Dim i As Integer = 0
        While (i < dt.Rows.Count)
            Dim row As DataRow = dt1.NewRow
            row(0) = i + 1
            row(1) = dt.Rows(i)("TenLopHoc")
            row(2) = dt.Rows(i)("TenMonHoc")
            row(3) = dt.Rows(i)("SoTietHocTuan")
            row(4) = dt.Rows(i)("HoTenGiaoVien")
            row(5) = dt.Rows(i)("SoTietHocLienTiepToiThieu")
            row(6) = dt.Rows(i)("SoTietHocLienTiepToiDa")
            row(7) = dt.Rows(i)("SoBuoiHocToiThieu")
            row(8) = dt.Rows(i)("SoBuoiHocToiDa")
            dt1.Rows.Add(row)
            i = i + 1
        End While
        Return dt1
    End Function

    Public Function LayDSLH() As DataTable
        Dim dt As New DataTable()
        Dim cn As OleDbConnection
        cn = MDatabase.ConnectionData()
        Dim strSQL As String
        strSQL = "Select * From LopHoc"
        Dim da As New OleDbDataAdapter(strSQL, cn)
        da.Fill(dt)
        Return dt
    End Function

    Public Function LayMaLH(ByVal tenlophoc As String) As String
        Dim maLH As String = ""
        Dim dt As New DataTable()
        dt = LayDSLH()
        Dim i As Integer = 0
        While (i < dt.Rows.Count)
            If (tenlophoc = dt.Rows(i)("TenLopHoc")) Then
                maLH = dt(i)("MaLopHoc")
            End If
            i += 1
        End While
        Return maLH
    End Function

    Public Function KTMH(ByVal tenMH As String, ByVal dt As DataTable) As Boolean
        Dim flag As Boolean = False
        Dim i As Integer = 0
        While (i < dt.Rows.Count)
            If (tenMH = dt.Rows(i)("Môn Học")) Then
                flag = True
            End If
            i += 1
        End While
        Return flag
    End Function

    Public Function TachChuoi(ByVal Chuoi As String, ByVal KyTuTachChuoi As String) As String()
        Dim temp() As String
        temp = Split(Chuoi, KyTuTachChuoi)
        Return temp
    End Function
End Module
