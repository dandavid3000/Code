Imports DAOLayer
Imports DTO
Public Module LICHDAYGIAOVIENBus
    Public Function LayBangGiaoVien() As DataTable
        Dim dt As New DataTable()
        dt = LICHDAYGIAOVIENDao.LayBangGiaoVien()
        Return dt
    End Function

    Public Function XLBangGiaoVien() As DataTable
        Dim dt As New DataTable()
        dt = LICHDAYGIAOVIENDao.XLBangGiaoVien()
        Return dt
    End Function
End Module
