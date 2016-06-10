Imports DAOLayer

Public Class LopHocBus
    'Them
    'Xoa
    'Sua
    'Tim Kiem
    'Lay Bang
    'Cap Nhat Bang
    'Lay Danh Sach
    Public Function LayDanhSach() As IList
        Dim lhDao As New LopHocDao()
        Dim ds As IList
        ds = lhDao.LayDanhSach()
        Return ds
    End Function
End Class
