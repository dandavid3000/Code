Imports DTO
Imports DAOLayer

Public Module PCGDTHEOBOMONBus
    Public Function LayBangGiaoVien() As DataTable
        Dim dt As New DataTable()
        dt = PCGDTHEOBOMONDao.LayBangGiaoVien()
        Return dt
    End Function

    Public Function LayBangPhanCong(ByVal malophoc As String) As DataTable
        Dim dt As New DataTable()
        dt = PCGDTHEOBOMONDao.LayBangPhanCong(malophoc)
        Return dt
    End Function

    Public Function LayBangPhanCongTheoGV(ByVal maGV As String) As DataTable
        Dim dt As New DataTable()
        dt = PCGDTHEOBOMONDao.LayBangPhanCongTheoGV(maGV)
        Return dt
    End Function

    Public Function LayMaLH(ByVal tenlophoc As String) As String
        Dim maMH As String
        maMH = PCGDTHEOBOMONDao.LayMaLH(tenlophoc)
        Return maMH
    End Function

    Public Function KTMH(ByVal tenMH As String, ByVal dt As DataTable) As Boolean
        Dim flag As Boolean = False
        flag = PCGDTHEOBOMONDao.KTMH(tenMH, dt)
        Return flag
    End Function
End Module
