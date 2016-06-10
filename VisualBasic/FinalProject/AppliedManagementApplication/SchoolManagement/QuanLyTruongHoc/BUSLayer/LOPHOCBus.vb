Imports DTO
Imports DAOLayer

Public Module LOPHOCBus
    Public Function LayBangLopHoc(ByVal lh As LopHoc) As DataTable
        Dim dt As New DataTable()
        dt = LOPHOCDao.XLLopHoc(lh)
        Return dt
    End Function

    Public Function LayBangLopHoc() As DataTable
        Dim dt As New DataTable()
        dt = LOPHOCDao.XLLopHoc()
        Return dt
    End Function

    Public Function LayBangLichRanh(ByVal lh As LopHoc) As DataTable
        Dim dt As New DataTable()
        dt = LOPHOCDao.LayBangLichRanh(lh)
        Return dt
    End Function

    Public Function XLLichBan() As DataTable
        Dim dt As New DataTable()
        dt = LOPHOCDao.XLLichBan()
        Return dt
    End Function

    Public Function LichRanh() As DataTable
        Dim dt As New DataTable()
        dt = LOPHOCDao.LichRanh()
        Return dt
    End Function

    Public Function TaoLopHoc(ByVal tenlophoc As String, ByVal makhoi As String) As LopHoc
        Dim lh As New LopHoc
        lh = LOPHOCDao.TaoLopHoc(tenlophoc, makhoi)
        Return lh
    End Function

    Public Function TachChuoi(ByVal Chuoi As String, ByVal KyTuTachChuoi As String) As String()
        Dim str() As String
        str = LOPHOCDao.TachChuoi(Chuoi, KyTuTachChuoi)
        Return str
    End Function

    Public Sub TaoLopHocMoi(ByVal lh As LopHoc)
        LOPHOCDao.TaoLopHocMoi(lh)
    End Sub

    Public Sub XoaLopHoc(ByVal malop As String)
        LOPHOCDao.XoaLopHoc(malop)
    End Sub

    Public Sub CapNhatLai(ByVal dt As DataTable, ByVal lh As LopHoc)
        LOPHOCDao.CapNhatLai(dt, lh)
    End Sub
End Module
