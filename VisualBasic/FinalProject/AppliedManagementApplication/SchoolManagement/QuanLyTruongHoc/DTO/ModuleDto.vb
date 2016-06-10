Imports System.Data.OleDb

Public Module ModuleDto
    Public Structure LopHoc
        Dim malophoc As String
        Dim tenlophoc As String
        Dim makhoi As String
        Public Sub Initialize()
            malophoc = ""
            tenlophoc = ""
            makhoi = ""
        End Sub

    End Structure

    Public Structure GiaoVien
        Dim magiaovien As String
        Dim hotengiaovien As String
        Dim tentat As String
        Dim diachi As String
        Dim dienthoai As String
        Public Sub Initialize()
            magiaovien = ""
            hotengiaovien = ""
            tentat = ""
            diachi = ""
            dienthoai = ""
        End Sub
    End Structure

    Public Structure Khoi
        Dim makhoi As String
        Dim tenkhoi As String
        Public Sub Initialize()
            makhoi = ""
            tenkhoi = ""
        End Sub
    End Structure

    Public Structure LichLopHoc
        Dim malichlophoc As String
        Dim maphancong As String
        Dim thu As Integer
        Dim tiethocbatdau As Integer
        Dim sotiethoc As Integer
        Public Sub Initialize()
            malichlophoc = ""
            maphancong = ""
            thu = 0
            tiethocbatdau = 0
            sotiethoc = 0
        End Sub
    End Structure

    Public Structure MonHoc
        Dim mamonhoc As String
        Dim tenmonhoc As String
        Dim quydinhsotiethoclientieptoithieu As Integer
        Dim quydinhsotiethoclientieptoida As Integer
        Public Sub Initialize()
            mamonhoc = ""
            tenmonhoc = ""
            quydinhsotiethoclientieptoida = 0
            quydinhsotiethoclientieptoithieu = 0
        End Sub
    End Structure

    Public Structure PhanCong
        Dim maphancong As String
        Dim malophoc As String
        Dim mamonhoc As String
        Dim magiaovien As String
        Dim sotiethoctuan As Integer
        Dim sotiethoclientieptoithieu As Integer
        Dim sotiethoclientieptoida As Integer
        Dim sobuoihoctoithieu As Integer
        Dim sobuoihoctoida As Integer
        Public Sub Initialize()
            maphancong = ""
            malophoc = ""
            mamonhoc = ""
            magiaovien = ""
            sotiethoctuan = 0
            sotiethoclientieptoida = 0
            sobuoihoctoithieu = 0
            sotiethoclientieptoithieu = 0
            sobuoihoctoida = 0
        End Sub
    End Structure

    Public Structure PhuTrach
        Dim maphutrach As String
        Dim magiaovien As String
        Dim mamonhoc As String
        Public Sub initialize()
            maphutrach = ""
            magiaovien = ""
            mamonhoc = ""
        End Sub
    End Structure

    Public Structure RangBuocGiaovien
        Dim marangbuocgiaovien As String
        Dim magiaovien As String
        Dim thu As Integer
        Dim tiethoc As Integer
        Dim trangthai As Integer
        Public Sub Initialize()
            marangbuocgiaovien = ""
            magiaovien = ""
            thu = 0
            tiethoc = 0
            trangthai = 0
        End Sub
    End Structure

    Public Structure RangBuocLopHoc
        Dim marangbuoclophoc As String
        Dim malophoc As String
        Dim thu As Integer
        Dim tiethoc As Integer
        Dim trangthai As Integer
        Public Sub Initialize()
            marangbuoclophoc = ""
            malophoc = ""
            thu = 0
            tiethoc = 0
            trangthai = 0
        End Sub
    End Structure

    Public Structure ThamSo
        Dim SoTietToiDaTrongNgay As Integer
        Dim SoTietToiDaDuocHocTrongNgay As Integer
        Dim TietGay As Integer
        Public Sub Initialize()
            SoTietToiDaDuocHocTrongNgay = 0
            SoTietToiDaTrongNgay = 0
            TietGay = 0
        End Sub
    End Structure
End Module
