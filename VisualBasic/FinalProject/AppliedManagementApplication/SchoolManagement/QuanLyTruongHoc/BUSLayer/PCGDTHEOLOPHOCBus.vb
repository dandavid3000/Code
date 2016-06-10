Imports DTO
Imports DAOLayer

Public Module PCGDTHEOLOPHOCBus
    Public Function LayBangGiaoVien() As DataTable
        Dim dt As New DataTable()
        dt = PCGDTHEOLOPHOCDao.LayBangGiaoVien()
        Return dt
    End Function

    Public Function LayBangGiaoVien(ByVal makhoi As String) As DataTable
        Dim dt As New DataTable()
        dt = PCGDTHEOLOPHOCDao.LayBangGiaoVien(makhoi)
        Return dt
    End Function

    Public Function LayBangPhanCongLopHoc(ByVal malophoc As String) As DataTable
        Dim dt As New DataTable()
        dt = PCGDTHEOLOPHOCDao.LayBangPhanCongLopHoc(malophoc)
        Return dt
    End Function

    Public Function LayBangPhanCongTheoMaGV(ByVal maGV As String) As DataTable
        Dim dt As New DataTable()
        dt = PCGDTHEOLOPHOCDao.LayBangPhanCongTheoMaGV(maGV)
        Return dt
    End Function

    Public Function KTMonHoc(ByVal monhoc As String, ByVal malophoc As String) As Boolean
        Dim flag As Boolean
        flag = PCGDTHEOLOPHOCDao.KTMonHoc(monhoc, malophoc)
        Return flag
    End Function

    Public Function LayMaLHTruoc(ByVal malophoc As String) As String
        Dim ma As String
        ma = PCGDTHEOLOPHOCDao.LayMaLHTruoc(malophoc)
        Return ma
    End Function

    Public Function LayMaLHTiepTheo(ByVal malophoc As String) As String
        Dim ma As String
        ma = PCGDTHEOLOPHOCDao.LayMaLHTiepTheo(malophoc)
        Return ma
    End Function
End Module
