Imports DAOLayer
Imports DTO

Public Module QUYDINHTOANTRUONGBus
    Public Function LaySTTDTrongNgay() As Integer
        Dim STTTD As Integer
        STTTD = QUYDINHTOANTRUONGDao.LaySTTDTrongNgay()
        Return STTTD
    End Function

    Public Function LayTietGay() As Integer
        Dim STTTD As Integer
        STTTD = QUYDINHTOANTRUONGDao.LayTietGay()
        Return STTTD
    End Function

    Public Function LaySTTDTDHrongNgay() As Integer
        Dim STTTD As Integer
        STTTD = QUYDINHTOANTRUONGDao.LaySTTDTDHrongNgay()
        Return STTTD
    End Function

    Public Sub CapNhat(ByVal STTDTrongNgay As Integer, ByVal SoTietGay As Integer, ByVal STTDDHTrongNgay As Integer)
        QUYDINHTOANTRUONGDao.CapNhat(STTDTrongNgay,SoTietGay, STTDDHTrongNgay)
    End Sub
End Module
