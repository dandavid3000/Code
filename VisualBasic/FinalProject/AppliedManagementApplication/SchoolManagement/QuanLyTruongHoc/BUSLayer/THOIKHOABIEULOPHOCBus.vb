Imports System.Data.OleDb
Imports DTO
Imports DAOLayer

Public Module THOIKHOABIEULOPHOCBus
    Public Function LayDSLopHoc(ByVal makhoi As String) As DataTable
        Dim dt As New DataTable()
        dt = THOIKHOABIEULOPHOCDao.LayDSLopHoc(makhoi)
        Return dt
    End Function

    Public Function LayDSLopHoc() As DataTable
        Dim dt As New DataTable()
        dt = THOIKHOABIEULOPHOCDao.LayDSLopHoc()
        Return dt
    End Function

    Public Function LayThoiKhoaBieuLopHoc(ByVal malophoc As String) As DataTable
        Dim dt As New DataTable()
        dt = THOIKHOABIEULOPHOCDao.LayThoiKhoaBieuLopHoc(malophoc)
        Return dt
    End Function

    Public Function XLThoiKhoaBieuLopHoc(ByVal malophoc As String) As DataTable
        Dim dt As New DataTable()
        dt = THOIKHOABIEULOPHOCDao.XLThoiKhoaBieuLopHoc(malophoc)
        Return dt
    End Function
End Module
