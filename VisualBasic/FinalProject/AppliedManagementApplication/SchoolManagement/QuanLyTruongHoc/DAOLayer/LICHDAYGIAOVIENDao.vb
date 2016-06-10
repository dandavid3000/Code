Imports DTO
Imports System.Data.OleDb

Public Module LICHDAYGIAOVIENDao
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
End Module
