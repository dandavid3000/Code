Imports DTO
Imports System.Data.OleDb

Public Module QUYDINHTOANTRUONGDao
    Public Function LayBangThamSo() As DataTable
        Dim dt As New DataTable()
        Dim cn As OleDbConnection
        cn = MDatabase.ConnectionData()
        Dim strSQL As String
        strSQL = " Select * from ThamSo"
        Dim da As New OleDbDataAdapter(strSQL, cn)
        da.Fill(dt)
        Return dt
    End Function

    Public Function LaySTTDTrongNgay() As Integer
        Dim STTDa As Integer
        Dim dt As New DataTable
        dt = LayBangThamSo()
        STTDa = dt.Rows(0)("SoTietToiDaTrongNgay")
        Return STTDa
    End Function

    Public Function LayTietGay() As Integer
        Dim STTDa As Integer
        Dim dt As New DataTable
        dt = LayBangThamSo()
        STTDa = dt.Rows(0)("TietGay")
        Return STTDa
    End Function

    Public Function LaySTTDTDHrongNgay() As Integer
        Dim STTDa As Integer
        Dim dt As New DataTable
        dt = LayBangThamSo()
        STTDa = dt.Rows(0)("SoTietToiDaDuocHocTrongNgay")
        Return STTDa
    End Function

    Public Sub CapNhat(ByVal STTDTrongNgay As Integer, ByVal SoTietGay As Integer, ByVal STTDDHTrongNgay As Integer)
        Dim cn As OleDbConnection
        cn = MDatabase.ConnectionData()
        Dim strSQL As String
        strSQL = "Update ThamSo set SoTietToiDaTrongNgay = '" + STTDTrongNgay.ToString() + "', TietGay = '" + SoTietGay.ToString() + "', SoTietToiDaDuocHocTrongNgay = '" + STTDDHTrongNgay.ToString() + "'"
        Dim cmd As New OleDbCommand(strSQL, cn)
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub
End Module
