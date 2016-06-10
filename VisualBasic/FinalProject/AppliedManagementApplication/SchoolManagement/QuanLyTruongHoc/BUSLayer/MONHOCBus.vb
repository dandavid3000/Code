Imports DTO
Imports DAOLayer

Public Module MONHOCBus
    Public Function XLDSMonHoc() As DataTable
        Dim dt As New DataTable()
        dt = MONHOCDao.XLDSMonHoc()
        Return dt
    End Function

    Public Function XLDSGVPhuTrach(ByVal mamonhoc As String) As DataTable
        Dim dt As New DataTable()
        dt = MONHOCDao.XLDSGVPhuTrach(mamonhoc)
        Return dt
    End Function

    Public Function TaoMonHocMoi(ByVal tenmonhoc As String) As MonHoc
        Dim mh As New MonHoc
        mh = MONHOCDao.TaoMonHocMoi(tenmonhoc)
        Return (mh)
    End Function

    Public Sub TaoMonHocMoi(ByVal mh As MonHoc)
        MONHOCDao.TaoMonHocMoi(mh)
    End Sub

    Public Function TachChuoi(ByVal Chuoi As String, ByVal KyTuTachChuoi As String) As String()
        Dim str() As String
        str = MONHOCDao.TachChuoi(Chuoi, KyTuTachChuoi)
        Return str
    End Function

    Public Sub CapNhatLaiMH(ByVal dt As DataTable)
        MONHOCDao.CapNhatLaiMH(dt)
    End Sub
End Module
