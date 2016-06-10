Imports System.Data.OleDb
Imports DTO

Public Module THOIKHOABIEULOPHOCDao

    Public Function LayDSLopHoc(ByVal makhoi As String) As DataTable
        Dim dt As New DataTable()
        Dim cn As OleDbConnection
        cn = MDatabase.ConnectionData()
        Dim strSQL As String
        strSQL = "Select * From LopHoc where MaKhoi = '" + makhoi + "'"
        Dim da As New OleDbDataAdapter(strSQL, cn)
        da.Fill(dt)
        Return dt
    End Function

    Public Function LayDSLopHoc() As DataTable
        Dim dt As New DataTable()
        Dim cn As OleDbConnection
        cn = MDatabase.ConnectionData()
        Dim strSQL As String
        strSQL = "Select * From LopHoc "
        Dim da As New OleDbDataAdapter(strSQL, cn)
        da.Fill(dt)
        Return dt
    End Function

    Public Function XLThoiKhoaBieuLopHoc(ByVal malophoc As String) As DataTable
        Dim dt As New DataTable()
        Dim cn As OleDbConnection
        cn = MDatabase.ConnectionData()
        Dim strSQL As String
        strSQL = " Select TietHoc, Thu, PhuTrach from ThoiKhoaBieu where MaLopHoc = '" + malophoc + "'"
        Dim da As New OleDbDataAdapter(strSQL, cn)
        da.Fill(dt)
        Return dt
    End Function

    Public Function LayThoiKhoaBieuLopHoc(ByVal malophoc As String) As DataTable
        Dim dt As New DataTable()
        dt = XLThoiKhoaBieuLopHoc(malophoc)
        Dim dt1 As New DataTable()
        dt1.Columns.Add("Tiết")
        dt1.Columns.Add("Thứ 2")
        dt1.Columns.Add("Thứ 3")
        dt1.Columns.Add("Thứ 4")
        dt1.Columns.Add("Thứ 5")
        dt1.Columns.Add("Thứ 6")
        dt1.Columns.Add("Thứ 7")
        dt1.Columns.Add("CN")
        Dim j As Integer = 0
        While (j < 10)
            Dim row As DataRow = dt1.NewRow()
            row(0) = j + 1
            j = j + 1
        End While
        Return dt1
    End Function
End Module
