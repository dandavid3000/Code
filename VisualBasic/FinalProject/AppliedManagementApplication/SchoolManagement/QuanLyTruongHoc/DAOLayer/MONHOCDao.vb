Imports System.Data.OleDb
Imports DTO

Public Module MONHOCDao
    Public Function LayDanhSachMonHoc() As DataTable
        Dim dt As New DataTable()
        Dim cn As New OleDbConnection
        cn = MDatabase.ConnectionData()
        Dim strSQL As String
        strSQL = "Select * From MonHoc"
        Dim da As New OleDbDataAdapter(strSQL, cn)
        da.Fill(dt)
        cn.Close()
        Return dt
    End Function

    Public Function XLDSMonHoc() As DataTable
        Dim dt As New DataTable()
        dt = LayDanhSachMonHoc()
        Dim dt1 As New DataTable()
        dt1.Columns.Add("STT")
        dt1.Columns.Add("MaMonHoc")
        dt1.Columns.Add("TenMonHoc")
        dt1.Columns.Add("QDSTHLTTT")
        dt1.Columns.Add("QDSTHLTTD")
        Dim i As Integer = 0
        While (i < dt.Rows.Count)
            Dim row As DataRow = dt1.NewRow
            row(0) = i + 1
            row(1) = dt.Rows(i)("MaMonHoc")
            row(2) = dt.Rows(i)("TenMonHoc")
            row(3) = dt.Rows(i)("QuiDinhSoTietHocLienTiepToiThieu")
            row(4) = dt.Rows(i)("QuiDinhSoTietHocLienTiepToiDa")
            dt1.Rows.Add(row)
            i = i + 1
        End While
        Return dt1
    End Function

    Public Function LayDanhSachGiaoVienPhuTrach(ByVal mamonhoc As String) As DataTable
        Dim lh As New LopHoc
        Dim pt As New PhuTrach
        Dim gv As New GiaoVien
        Dim pc As New PhanCong

        Dim dt As New DataTable()
        Dim cn As New OleDbConnection
        cn = MDatabase.ConnectionData()
        Dim strSQL As String

        strSQL = " Select distinct gv.HoTenGiaoVien, gv.TenTat, lh.TenLopHoc From GiaoVien gv, PhuTrach pt, PhanCong pc, LopHoc lh"
        strSQL = strSQL + " where gv.MaGiaoVien = pt.MaGiaovien and gv.MaGiaoVien = pc.MaGiaoVien and pc.MaLopHoc = lh.MaLopHoc and pt.MaMonHoc = '" + mamonhoc + "'"
        Dim da As New OleDbDataAdapter(strSQL, cn)
        da.Fill(dt)
        cn.Close()
        Return dt
    End Function

    Public Function XLDSGVPhuTrach(ByVal mamonhoc As String) As DataTable

        Dim dt As New DataTable()
        dt = LayDanhSachGiaoVienPhuTrach(mamonhoc)
        Dim dt1 As New DataTable()
        dt1.Columns.Add("STT")
        dt1.Columns.Add("Họ Tên Giáo Viên")
        dt1.Columns.Add("Tên Tắt")
        dt1.Columns.Add("Tên Lớp Học Phụ Trách")
        Dim i As Integer = 0
        While (i < dt.Rows.Count)
            Dim row As DataRow = dt1.NewRow
            row(0) = i + 1
            row(1) = dt.Rows(i)("HoTenGiaoVien")
            row(2) = dt.Rows(i)("TenTat")
            row(3) = dt.Rows(i)("TenLopHoc")
            dt1.Rows.Add(row)
            i = i + 1
        End While
        Return dt1
    End Function

    Public Function TaoMonHocMoi(ByVal tenmonhoc As String) As MonHoc
        Dim mh As New MonHoc
        Dim strSQL As String = "Select MaMonHoc From MonHoc Where MaMonHoc >= all (Select MaMonHoc From MonHoc)"
        mh.tenmonhoc = tenmonhoc

        Dim cn As OleDbConnection
        cn = MDatabase.ConnectionData()
        Dim cmd As New OleDbCommand(strSQL, cn)
        Dim ma As String = cmd.ExecuteScalar()
        Dim mamh As Integer = CInt(TachChuoi(ma, "MH")(0) + TachChuoi(ma, "MH")(1)) + 1
        If mamh < 10 Then
            mh.mamonhoc = "MH0" & mamh.ToString()
        Else
            mh.mamonhoc = "MH" & mamh.ToString()
        End If
        Return mh
    End Function

    Public Sub TaoMonHocMoi(ByVal mh As MonHoc)
        Dim cn As OleDbConnection
        cn = MDatabase.ConnectionData()
        Dim strSQL As String
        strSQL = "Insert into MonHoc(MaMonhoc, TenMonhoc, QuiDinhSoTietHocLienTiepToiThieu, QuiDinhSoTietHocLienTiepToiDa) values (?, ?, ?, ?)"
        Dim cmd As New OleDbCommand(strSQL, cn)

        cmd.Parameters.Add("@mamonhoc", OleDbType.WChar)
        cmd.Parameters.Add("@tenmonhoc", OleDbType.WChar)
        cmd.Parameters.Add("@quydinhsotiethoclientieptoithieu", OleDbType.BigInt)
        cmd.Parameters.Add("@quydinhsotiethoclientieptoida", OleDbType.BigInt)

        cmd.Parameters("@mamonhoc").Value = mh.mamonhoc
        cmd.Parameters("@tenmonhoc").Value = mh.tenmonhoc
        cmd.Parameters("@quydinhsotiethoclientieptoithieu").Value = mh.quydinhsotiethoclientieptoithieu
        cmd.Parameters("@quydinhsotiethoclientieptoida").Value = mh.quydinhsotiethoclientieptoida
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub

    Public Function TachChuoi(ByVal Chuoi As String, ByVal KyTuTachChuoi As String) As String()
        Dim temp() As String
        temp = Split(Chuoi, KyTuTachChuoi)
        Return temp
    End Function

    Public Sub XoaMonHoc(ByVal maMH As String)
        Dim cn As OleDbConnection
        cn = MDatabase.ConnectionData()
        Dim strSQL As String
        strSQL = "Delete From MonHoc where MaMonHoc = '" + maMH + "'"
        Dim cmd As New OleDbCommand(strSQL, cn)
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub

    Public Sub CapNhatLaiMH(ByVal dt As DataTable)
        Dim dtb As DataTable = LayDanhSachMonHoc()
        If (dtb.Rows.Count <> dt.Rows.Count) Then
            Dim j As Integer = dtb.Rows.Count - 1
            While (j >= 0)
                Dim i As Integer = 0
                Dim dem As Integer = 0
                While (i < dt.Rows.Count)
                    If (dtb.Rows(j)(0) <> dt.Rows(i)(1)) Then
                        dem += 1
                    End If
                    i += 1
                End While
                If (dem = dt.Rows.Count) Then
                    XoaMonHoc(dtb.Rows(j)(0))
                End If
                j -= 1
            End While
        End If
    End Sub
End Module
