Imports DAOLayer
Imports DTO

Public Class HocSinhBus
    'Them
    Public Sub Them(ByVal hsDto As HocSinhDto)
        'Kiem tra Business Rule
        If (hsDto.Toan > 10) Then
            Throw New Exception("Diem toan khong lon hon 10")
        ElseIf (hsDto.Ly > 10) Then
            Throw New Exception("Diem ly khong lon hon 10")
        ElseIf (hsDto.Hoa > 10) Then
            Throw New Exception("Diem Hoa khong lon hon 10")
        End If

        Dim hsDao As New HocSinhDao()
        hsDao.Them(hsDto)
    End Sub

    'Xoa
    Public Sub Xoa(ByVal maHocSinh As Integer)
        'Kiem tra Business Rule neu co
        Dim hsDao As New HocSinhDao()
        hsDao.Xoa(maHocSinh)
    End Sub

    'Sua
    Public Sub Sua(ByVal hsDto As HocSinhDto)
        'Kiem tra Business Rule neu co
        Dim hsDao As New HocSinhDao()
        hsDao.Sua(hsDto)
    End Sub

    'Tim Kiem
    Public Function TimKiem(ByVal maHS As Integer) As HocSinhDto
        'Kiem tra Business Rule neu co
        Dim hsDto As HocSinhDto
        Dim hsDao As New HocSinhDao()
        hsDto = hsDao.TimKiem(maHS)
        Return hsDto
    End Function

    'Lay Bang
    Public Function LayBang() As DataTable
        'Kiem tra Business Rule neu co
        Dim dt As DataTable
        Dim hsDao As New HocSinhDao()
        dt = hsDao.LayBang()
        Return dt
    End Function

    'Cap Nhat Bang
    Public Sub CapNhatBang(ByVal dt As DataTable)
        'Kiem tra Business Rule neu co
        Dim hsDao As New HocSinhDao()
        hsDao.CapNhatBang(dt)
    End Sub

    'Lay Danh Sach
    Public Function LayDanhSach() As IList
        'Kiem tra Business Rule neu co
        Dim ds As IList
        Dim hsDao As New HocSinhDao()
        ds = hsDao.LayDanhSach()
        Return ds
    End Function

    Public Function TimKiem(ByVal hsCrt As HocSinhCrt) As DataTable
        Dim dt As DataTable
        Dim hsDao As New HocSinhDao()
        dt = hsDao.TimKiem(hsCrt)
        Return dt
    End Function
End Class
