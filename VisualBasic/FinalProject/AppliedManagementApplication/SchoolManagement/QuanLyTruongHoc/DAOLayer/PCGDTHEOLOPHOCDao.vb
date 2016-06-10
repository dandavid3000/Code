Imports System.Data.OleDb
Imports DTO

Public Module PCGDTHEOLOPHOCDao

    Public Function XLBangGiaoVien(ByVal makhoi As String) As DataTable
        Dim dt As New DataTable()
        Dim cn As New OleDbConnection
        cn = MDatabase.ConnectionData()
        Dim strSQL As String
        strSQL = "Select distinct gv.MaGiaoVien, gv.HoTenGiaoVien,gv.TenTat, gv.DiaChi, gv.DienThoai"
        strSQL = strSQL + " From GiaoVien gv, PhanCong pc, LopHoc lh"
        strSQL = strSQL + " Where pc.MaLopHoc = lh.MaLopHoc and pc.MaGiaoVien = gv.MaGiaoVien and lh.MaKhoi = '" + makhoi + "' "
        Dim da As New OleDbDataAdapter(strSQL, cn)
        da.Fill(dt)
        cn.Close()
        Return dt
    End Function

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
        'dt1.Columns.Add("Mã Giáo Viên")
        dt1.Columns.Add("Họ Tên Giáo Viên")
        dt1.Columns.Add("Tên Tắt")
        dt1.Columns.Add("Địa Chỉ")
        dt1.Columns.Add("Điện Thoại")
        Dim i As Integer = 0
        While (i < dt.Rows.Count)
            Dim row As DataRow = dt1.NewRow
            row(0) = i + 1
            'row(1) = dt.Rows(i)("MaGiaoVien")
            row(1) = dt.Rows(i)("HoTenGiaoVien")
            row(2) = dt.Rows(i)("TenTat")
            row(3) = dt.Rows(i)("DiaChi")
            row(4) = dt.Rows(i)("DienThoai")
            dt1.Rows.Add(row)
            i = i + 1
        End While
        Return dt1
    End Function

    Public Function LayBangGiaoVien(ByVal makhoi As String) As DataTable
        Dim dt As New DataTable()
        dt = XLBangGiaoVien(makhoi)
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

    Public Function LayBangPhanCongLopHoc(ByVal malophoc As String) As DataTable
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


    'Phan cong theo ma giao vien 
    Public Function XLPhanCongTheoMaGV(ByVal maGV As String) As DataTable
        Dim dt As New DataTable()
        Dim cn As New OleDbConnection
        cn = MDatabase.ConnectionData()
        Dim strSQL As String
        strSQL = "Select distinct lh.TenLopHoc, mh.TenMonHoc, pc.SoTietHocTuan,gv.MaGiaoVien, gv.HoTenGiaoVien, pc.SoTietHocLienTiepToiThieu, pc.SoTietHocLienTiepToiDa,pc.SoBuoiHocToiThieu, pc.SoBuoiHocToiDa"
        strSQL = strSQL + " From LopHoc lh, PhanCong pc, GiaoVien gv, MonHoc mh"
        strSQL = strSQL + " Where lh.MaLopHoc = pc.MaLopHoc and pc.MaMonHoc = mh.MaMonHoc and pc.MaGiaoVien = gv.MaGiaoVien and gv.MaGiaoVien = '" + maGV + "'"
        Dim da As New OleDbDataAdapter(strSQL, cn)
        da.Fill(dt)
        Return dt
    End Function

    Public Function LayBangPhanCongTheoMaGV(ByVal maGV As String) As DataTable
        Dim dt As New DataTable()
        dt = XLPhanCongTheoMaGV(maGV)
        Dim dt1 As New DataTable()
        dt1.Columns.Add("STT")
        dt1.Columns.Add("Tên Lớp Học")
        dt1.Columns.Add("Môn Học")
        dt1.Columns.Add("Tổng Số Tiết/Tuần")
        dt1.Columns.Add("Mã Giáo Viên")
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
            row(4) = dt.Rows(i)("MaGiaoVien")
            row(5) = dt.Rows(i)("HoTenGiaoVien")
            row(6) = dt.Rows(i)("SoTietHocLienTiepToiThieu")
            row(7) = dt.Rows(i)("SoTietHocLienTiepToiDa")
            row(8) = dt.Rows(i)("SoBuoiHocToiThieu")
            row(9) = dt.Rows(i)("SoBuoiHocToiDa")
            dt1.Rows.Add(row)
            i = i + 1
        End While
        Return dt1
    End Function

    Public Function LayCacMonHocCua1Lop(ByVal malophoc As String) As DataTable
        Dim dt As New DataTable()
        Dim cn As New OleDbConnection
        cn = MDatabase.ConnectionData()
        Dim strSQL As String
        strSQL = " select mh.TenMonHoc From PhanCong pc, MonHoc mh"
        strSQL = strSQL + " Where pc.MaMonHoc = mh.MaMonHoc and pc.MaLopHoc = '" + malophoc + "'"
        Dim da As New OleDbDataAdapter(strSQL, cn)
        da.Fill(dt)
        cn.Close()
        Return dt
    End Function

    Public Function KTMonHoc(ByVal monhoc As String, ByVal malophoc As String) As Boolean
        Dim flag As Boolean = False
        Dim dt As New DataTable()
        dt = LayCacMonHocCua1Lop(malophoc)
        Dim i As Integer = 0
        While (i < dt.Rows.Count)
            If (monhoc = dt.Rows(i)(0)) Then
                flag = True
            End If
            i = i + 1
        End While
        Return flag
    End Function

    Public Function TachChuoi(ByVal Chuoi As String, ByVal KyTuTachChuoi As String) As String()
        Dim temp() As String
        temp = Split(Chuoi, KyTuTachChuoi)
        Return temp
    End Function

    Public Function LayMaLHTruoc(ByVal malophoc As String) As String
        Dim malop As Integer = CInt(TachChuoi(malophoc, "LH")(0) + TachChuoi(malophoc, "LH")(1)) - 1
        If (malop < 10 And malop > 0) Then
            malophoc = "LH0" & malop.ToString()
        ElseIf (malop > 10) Then
            malophoc = "LH" & malop.ToString()
        End If
        Return malophoc
    End Function

    Public Function MaLHMax() As String
        Dim cn As OleDbConnection
        cn = MDatabase.ConnectionData()
        Dim strSQL As String
        strSQL = "select MaLopHoc From LopHoc Where MaLopHoc >= all (select MaLopHoc from LopHoc)"
        Dim cmd As New OleDbCommand(strSQL, cn)
        cmd.ExecuteScalar()
        Return cmd.ExecuteScalar()
    End Function

    Public Function LayMaLHTiepTheo(ByVal malophoc As String) As String
        Dim ma As String = MaLHMax()
        Dim malop As Integer = CInt(TachChuoi(malophoc, "LH")(0) + TachChuoi(malophoc, "LH")(1)) + 1
        If (malop < 10) Then
            malophoc = "LH0" & malop.ToString()
        ElseIf ((malop > 10) And malop <= ma) Then
            malophoc = "LH" & malop.ToString()
        End If
        Return malophoc
    End Function

End Module


