Imports System.Data.OleDb
Imports DTO

Public Module GIAOVIENDao
    Public Function XLBangGiaoVien() As DataTable
        Dim dt As New DataTable()
        Dim cn As New OleDbConnection
        cn = MDatabase.ConnectionData()
        Dim strSQL As String
        strSQL = " Select * From GiaoVien"
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

    Public Function DSMHCua1GiaoVien(ByVal magiaovien As String) As DataTable
        Dim dt As New DataTable()
        Dim cn As New OleDbConnection
        cn = MDatabase.ConnectionData()
        Dim strSQL As String
        strSQL = "Select mh.TenMonHoc From MonHoc mh, PhanCong pc"
        strSQL = strSQL + " Where mh.MaMonHoc = pc.MaMonHoc and pc.MaGiaoVien = '" + magiaovien + "'"
        Dim da As New OleDbDataAdapter(strSQL, cn)
        da.Fill(dt)
        cn.Close()
        Return dt
    End Function

    Public Function LayMH(ByVal tenmonhoc As String, ByVal magiaovien As String) As Boolean
        Dim flag As Boolean = False
        Dim dt As New DataTable()
        dt = DSMHCua1GiaoVien(magiaovien)
        Dim i As Integer = 0
        While (i < dt.Rows.Count)
            If (tenmonhoc = dt.Rows(i)(0)) Then
                flag = True
            End If
            i = i + 1
        End While
        Return flag
    End Function

    Public Function XLBangLichRanh(ByVal gv As GiaoVien) As DataTable

        Dim dt As New DataTable
        Dim cn As OleDbConnection = MDatabase.ConnectionData()
        Dim str As String = "Select thu,tiethoc,trangthai From RangBuocGiaoVien where MaGiaoVien = '" + gv.magiaovien + "'"

        'Dim cmd As New OleDbCommand(str, cn)
        'cmd.Parameters.Add("@magiaovien", OleDbType.WChar)
        'cmd.Parameters("@magiaovien").Value = gv.magiaovien
        Dim da As New OleDbDataAdapter(str, cn)
        da.Fill(dt)
        cn.Close()
        Return dt
    End Function

    Public Function LayBangLichRanh(ByVal gv As GiaoVien) As DataTable
        Dim dt As DataTable
        dt = XLBangLichRanh(gv)
        Dim dtb As New DataTable()
        dtb.Columns.Add("Tiết")
        dtb.Columns.Add("Thứ 2")
        dtb.Columns.Add("Thứ 3")
        dtb.Columns.Add("Thứ 4")
        dtb.Columns.Add("Thứ 5")
        dtb.Columns.Add("Thứ 6")
        dtb.Columns.Add("Thứ 7")
        dtb.Columns.Add("Chủ Nhật")
        Dim i As Integer = 0
        While (i < 10)
            Dim row As DataRow = dtb.NewRow()
            row(0) = i + 1
            Dim j As Integer = 0
            While (j < dt.Rows.Count)
                If (dt.Rows(j)(1) = i + 1) Then
                    If (dt.Rows(j)(2) = 1) Then
                        row(dt.Rows(j)(0) - 1) = "Bận"
                    ElseIf (dt.Rows(j)(2) = 2) Then
                        row(dt.Rows(j)(0) - 1) = "Bắt buộc xếp"
                    Else
                        row(dt.Rows(j)(0) - 1) = "Rãnh"
                    End If
                End If
                j += 1
            End While
            dtb.Rows.Add(row)
            i += 1
        End While
        Return dtb
    End Function

    Public Function XLLichBan() As DataTable
        Dim dtb As New DataTable()
        dtb.Columns.Add("Tiết")
        dtb.Columns.Add("Thứ 2")
        dtb.Columns.Add("Thứ 3")
        dtb.Columns.Add("Thứ 4")
        dtb.Columns.Add("Thứ 5")
        dtb.Columns.Add("Thứ 6")
        dtb.Columns.Add("Thứ 7")
        dtb.Columns.Add("Chủ Nhật")
        Dim i As Integer = 0
        While (i < 10)
            Dim row As DataRow = dtb.NewRow()
            row(0) = i + 1
            Dim j As Integer = 1
            While (j < 8)
                row(j) = "Bận"
                j += 1
            End While
            dtb.Rows.Add(row)
            i += 1
        End While
        Return dtb
    End Function
    
    Public Function Tao1GiaoVien(ByVal tengiaovien As String, ByVal tentat As String) As GiaoVien
        Dim gv As New GiaoVien
        Dim strSQL As String = "Select MaGiaoVien From GiaoVien Where MaGiaoVien >= all (Select MaGiaoVien From GiaoVien)"
        gv.hotengiaovien = tengiaovien
        gv.tentat = tentat

        Dim cn As OleDbConnection
        cn = MDatabase.ConnectionData()
        Dim cmd As New OleDbCommand(strSQL, cn)
        Dim maGV As String = cmd.ExecuteScalar()
        Dim maGiaoVien As Integer
        maGiaoVien = CInt(GIAOVIENDao.TachChuoi(maGV, "GV")(0) + GIAOVIENDao.TachChuoi(maGV, "GV")(1)) + 1
        If maGiaoVien < 10 Then
            gv.magiaovien = "GV00" & maGiaoVien.ToString()
        ElseIf (maGiaoVien < 100) Then
            gv.magiaovien = "GV0" & maGiaoVien.ToString()
        Else
            gv.magiaovien = "GV" & maGiaoVien.ToString()
        End If
        Return gv
    End Function

    Public Sub TaoGiaoVienMoi(ByVal gv As GiaoVien)
        Dim cn As OleDbConnection
        cn = MDatabase.ConnectionData()
        Dim strSQL As String
        strSQL = "Insert into GiaoVien(MaGiaoVien, HoTenGiaoVien,TenTat, DiaChi, DienThoai) values (?, ?, ?,?,?)"
        Dim cmd As New OleDbCommand(strSQL, cn)

        cmd.Parameters.Add("@MaGiaoVien", OleDbType.WChar)
        cmd.Parameters.Add("@HoTenGiaoVien", OleDbType.WChar)
        cmd.Parameters.Add("@TenTat", OleDbType.WChar)
        cmd.Parameters.Add("@DiaChi", OleDbType.WChar)
        cmd.Parameters.Add("@DienThoai", OleDbType.WChar)

        cmd.Parameters("@MaGiaoVien").Value = gv.magiaovien
        cmd.Parameters("@HoTenGiaoVien").Value = gv.hotengiaovien
        cmd.Parameters("@TenTat").Value = gv.tentat
        cmd.Parameters("@DiaChi").Value = gv.diachi
        cmd.Parameters("@DienThoai").Value = gv.dienthoai

        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub

    Public Function TachChuoi(ByVal Chuoi As String, ByVal KyTuTachChuoi As String) As String()
        Dim temp() As String
        temp = Split(Chuoi, KyTuTachChuoi)
        Return temp
    End Function

    Public Sub Xoa1GiaoVien(ByVal magiaovien As String)
        Dim cn As OleDbConnection
        cn = MDatabase.ConnectionData()
        Dim strSQL As String
        strSQL = "Delete From GiaoVien where MaGiaoVien = '" + magiaovien + "'"
        Dim cmd As New OleDbCommand(strSQL, cn)
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub

    Public Sub CapNhatLai(ByVal dt As DataTable)
        Dim dtb As DataTable = XLBangGiaoVien()
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
                    Xoa1GiaoVien(dtb.Rows(j)(0))
                End If
                j -= 1
            End While
        End If
    End Sub
End Module
