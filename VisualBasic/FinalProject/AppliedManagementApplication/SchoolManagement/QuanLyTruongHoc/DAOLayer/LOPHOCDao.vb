Imports System.Data.OleDb
Imports DTO

Public Module LOPHOCDao
    Public Function LayBangLopHoc(ByVal lh As LopHoc) As DataTable
        Dim dt As New DataTable()
        Dim cn As OleDbConnection
        cn = MDatabase.ConnectionData()
        Dim strsql As String
        strsql = " select * from lophoc where makhoi ='" + lh.makhoi + "'"
        Dim da As New OleDbDataAdapter(strsql, cn)
        da.Fill(dt)
        cn.Close()
        Return dt
    End Function

    Public Function LayBangLopHoc() As DataTable
        Dim dt As New DataTable()
        Dim cn As OleDbConnection
        cn = MDatabase.ConnectionData()
        Dim strSQL As String
        strSQL = " Select * From LopHoc "
        Dim da As New OleDbDataAdapter(strSQL, cn)
        da.Fill(dt)
        cn.Close()
        Return dt
    End Function

    Public Function XLLopHoc(ByVal lh As LopHoc) As DataTable
        Dim dt1 As New DataTable()
        dt1 = LayBangLopHoc(lh)
        Dim dt As New DataTable()
        dt.Columns.Add("STT")
        dt.Columns.Add("MaLopHoc")
        dt.Columns.Add("TenLopHoc")
        Dim i As Integer = 0
        While (i < dt1.Rows.Count)
            Dim row As DataRow = dt.NewRow()
            row(0) = i + 1
            row(1) = dt1.Rows(i)("MaLopHoc")
            row(2) = dt1.Rows(i)("TenLopHoc")
            dt.Rows.Add(row)
            i = i + 1
        End While
        Return dt
    End Function

    Public Function XLLopHoc() As DataTable
        Dim dt1 As New DataTable()
        dt1 = LayBangLopHoc()
        Dim dt As New DataTable()
        dt.Columns.Add("STT")
        dt.Columns.Add("MaLopHoc")
        dt.Columns.Add("TenLopHoc")
        Dim i As Integer = 0
        While (i < dt1.Rows.Count)
            Dim row As DataRow = dt.NewRow()
            row(0) = i + 1
            row(1) = dt1.Rows(i)("MaLopHoc")
            row(2) = dt1.Rows(i)("TenLopHoc")
            dt.Rows.Add(row)
            i = i + 1
        End While
        Return dt
    End Function

    Public Function XLBangLichRanh(ByVal lh As LopHoc) As DataTable

        Dim dt As New DataTable
        Dim cn As OleDbConnection = MDatabase.ConnectionData()
        Dim str As String = "Select thu,tiethoc,trangthai From RangBuocLopHoc where MaLopHoc = ?"

        Dim cmd As New OleDbCommand(str, cn)
        cmd.Parameters.Add("@malophoc", OleDbType.WChar)
        cmd.Parameters("@malophoc").Value = lh.malophoc
        Dim da As New OleDbDataAdapter(cmd)
        da.Fill(dt)
        cn.Close()
        Return dt
    End Function

    Public Function LayBangLichRanh(ByVal lh As LopHoc) As DataTable
        Dim dt As DataTable
        dt = XLBangLichRanh(lh)
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

    Public Function LichRanh() As DataTable
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
                row(j) = "Rãnh"
                j += 1
            End While
            dtb.Rows.Add(row)
            i += 1
        End While
        Return dtb
    End Function

    Public Function TaoLopHoc(ByVal tenlophoc As String, ByVal makhoi As String) As LopHoc
        Dim lh As New LopHoc
        Dim strSQL As String = "Select MaLopHoc From LopHoc Where MaLopHoc >= all (Select MaLopHoc From LopHoc)"
        lh.tenlophoc = tenlophoc
        lh.makhoi = makhoi

        Dim cn As OleDbConnection
        cn = MDatabase.ConnectionData()
        Dim cmd As New OleDbCommand(strSQL, cn)
        Dim ma As String = cmd.ExecuteScalar()
        Dim malop As Integer = CInt(TachChuoi(ma, "LH")(0) + TachChuoi(ma, "LH")(1)) + 1
        If malop < 10 Then
            lh.malophoc = "LH0" & malop.ToString()
        Else
            lh.malophoc = "LH" & malop.ToString()
        End If
        Return lh
    End Function

    Public Sub TaoLopHocMoi(ByVal lh As LopHoc)
        Dim cn As OleDbConnection
        cn = MDatabase.ConnectionData()
        Dim strSQL As String
        strSQL = "Insert into LopHoc(malophoc, tenlophoc, makhoi) values (?, ?, ?)"
        Dim cmd As New OleDbCommand(strSQL, cn)

        cmd.Parameters.Add("@malophoc", OleDbType.WChar)
        cmd.Parameters.Add("@tenlophoc", OleDbType.WChar)
        cmd.Parameters.Add("@makhoi", OleDbType.WChar)

        cmd.Parameters("@malophoc").Value = lh.malophoc
        cmd.Parameters("@tenlophoc").Value = lh.tenlophoc
        cmd.Parameters("@makhoi").Value = lh.makhoi

        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub

    Public Function TachChuoi(ByVal Chuoi As String, ByVal KyTuTachChuoi As String) As String()
        Dim temp() As String
        temp = Split(Chuoi, KyTuTachChuoi)
        Return temp
    End Function

    Public Sub XoaLopHoc(ByVal malop As String)
        Dim cn As OleDbConnection
        cn = MDatabase.ConnectionData()
        Dim strSQL As String
        strSQL = "Delete From LopHoc where MaLopHoc = '" + malop + "'"
        Dim cmd As New OleDbCommand(strSQL, cn)
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub

    Public Sub CapNhatLai(ByVal dt As DataTable, ByVal lh As LopHoc)
        Dim dtb As DataTable = LayBangLopHoc(lh)
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
                    XoaLopHoc(dtb.Rows(j)(0))
                End If
                j -= 1
            End While
        End If
    End Sub
    
End Module
