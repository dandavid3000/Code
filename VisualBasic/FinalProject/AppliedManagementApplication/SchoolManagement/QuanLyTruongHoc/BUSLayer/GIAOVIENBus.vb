Imports DTO
Imports DAOLayer

Public Module GIAOVIENBus
    Public Function LayBangGiaoVien() As DataTable
        Dim dt As New DataTable()
        dt = GIAOVIENDao.LayBangGiaoVien()
        Return dt
    End Function

    Public Function LayMH(ByVal tenmonhoc As String, ByVal magiaovien As String) As Boolean
        Dim flag As Boolean = GIAOVIENDao.LayMH(tenmonhoc, magiaovien)
        Return flag
    End Function

    Public Function LayBangLichRanh(ByVal gv As GiaoVien) As DataTable
        Dim dt As New DataTable()
        dt = GIAOVIENDao.LayBangLichRanh(gv)
        Return dt
    End Function

    Public Function Tao1GiaoVien(ByVal tengiaovien As String, ByVal magv As String) As GiaoVien
        Dim gv As New GiaoVien
        gv = GIAOVIENDao.Tao1GiaoVien(tengiaovien, magv)
        Return gv
    End Function

    Public Sub TaoGiaoVienMoi(ByVal gv As GiaoVien)
        GIAOVIENDao.TaoGiaoVienMoi(gv)
    End Sub

    Public Sub CapNhatLai(ByVal dt As DataTable)
        GIAOVIENDao.CapNhatLai(dt)
    End Sub

    Public Function XLLichBan() As DataTable
        Dim dt As New DataTable()
        dt = GIAOVIENDao.XLLichBan()
        Return dt
    End Function
End Module
