Imports System
Imports System.Data
Imports System.Configuration
Imports Microsoft
Imports System.Data.OleDb
Imports DTO
Imports BUSLayer
Imports PresentationLayer

Public Class ucPCGDTheoBoMon
    Public maGVGD As String
    Dim tang As Integer = 0

    Private Sub ucPCGDTheoBoMon_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable()
        dt = PCGDTHEOBOMONBus.LayBangGiaoVien()
        dtgvDSGVien.DataSource = dt
        chkbx10A.Checked = True
        With dtgvDSGVien
            .Columns("STT").Width = 35
            .Columns("STT").DisplayIndex = 0
            .Columns("STT").ReadOnly = True
            .AlternatingRowsDefaultCellStyle.ForeColor = Color.Red
            .Columns("STT").DefaultCellStyle.BackColor = Color.DeepSkyBlue
            .Columns("Mã Giáo Viên").Visible = False
        End With

        Dim ma As String = dtgvDSGVien("Mã Giáo Viên", dtgvDSGVien.CurrentRow.Index).Value
        Dim dt1 As New DataTable()
        dt1 = PCGDTHEOBOMONBus.LayBangPhanCongTheoGV(ma)
        dtgvBPCong.DataSource = dt1
        With dtgvBPCong
            .Columns("STT").Width = 35
            .Columns("STT").DisplayIndex = 0
            .Columns("STT").ReadOnly = True
            .AlternatingRowsDefaultCellStyle.ForeColor = Color.Red
            .Columns("STT").DefaultCellStyle.BackColor = Color.DeepSkyBlue
        End With
    End Sub

    Private Sub dtgvDSGVien_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgvDSGVien.SelectionChanged
        Dim rowInDex As Integer = dtgvDSGVien.CurrentRow.Index
        Dim tengiaovien As String = dtgvDSGVien("Họ Tên Giáo Viên", rowInDex).Value
        txtHoTenGiaoVien.Text = tengiaovien
        Dim tentat As String = dtgvDSGVien("Tên Tắt", rowInDex).Value
        txtTenTat.Text = tentat
        Dim maGV As String = dtgvDSGVien("Mã Giáo Viên", rowInDex).Value
        Dim dt As New DataTable()
        dt = PCGDTHEOBOMONBus.LayBangPhanCongTheoGV(maGV)
        dtgvBPCong.DataSource = dt
        tang = 0
    End Sub

    Private Sub chkbx10A_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbx10A.CheckedChanged
        If (chkbx10A.Checked = True) Then
            chkbx10A.Checked = True

            chkbx10Anh.Checked = False
            chkbx10D.Checked = False
            chkbx10Hoa.Checked = False
            chkbx10Ly.Checked = False
            chkbx10Sinh.Checked = False
            chkbx10Tin.Checked = False
            chkbx10Toan.Checked = False
            chkbx10Van.Checked = False

            chkbx11A.Checked = False
            chkbx11Anh.Checked = False
            chkbx11D.Checked = False
            chkbx11Hoa.Checked = False
            chkbx11Ly.Checked = False
            chkbx11Sinh.Checked = False
            chkbx11Tin.Checked = False
            chkbx11Toan.Checked = False
            chkbx11Văn.Checked = False

            chkbx12A.Checked = False
            chkbx12Anh.Checked = False
            chkbx12Hoa.Checked = False
            chkbx12Ly.Checked = False
            chkbx12Sinh.Checked = False
            chkbx12Tin.Checked = False
            chkbx12Toan.Checked = False
            chkbx12Van.Checked = False
            Dim maLH As String
            maLH = PCGDTHEOBOMONBus.LayMaLH("10 A")
            Dim dt As New DataTable()
            dt = PCGDTHEOBOMONBus.LayBangPhanCong(maLH)
            dtgvBPCong.DataSource = dt
        End If
    End Sub

    Private Sub chkbx10Anh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbx10Anh.CheckedChanged
        If (chkbx10Anh.Checked = True) Then
            chkbx10Anh.Checked = True

            chkbx10A.Checked = False
            chkbx10D.Checked = False
            chkbx10Hoa.Checked = False
            chkbx10Ly.Checked = False
            chkbx10Sinh.Checked = False
            chkbx10Tin.Checked = False
            chkbx10Toan.Checked = False
            chkbx10Van.Checked = False

            chkbx11A.Checked = False
            chkbx11Anh.Checked = False
            chkbx11D.Checked = False
            chkbx11Hoa.Checked = False
            chkbx11Ly.Checked = False
            chkbx11Sinh.Checked = False
            chkbx11Tin.Checked = False
            chkbx11Toan.Checked = False
            chkbx11Văn.Checked = False

            chkbx12A.Checked = False
            chkbx12Anh.Checked = False
            chkbx12Hoa.Checked = False
            chkbx12Ly.Checked = False
            chkbx12Sinh.Checked = False
            chkbx12Tin.Checked = False
            chkbx12Toan.Checked = False
            chkbx12Van.Checked = False

            Dim maLH As String
            maLH = PCGDTHEOBOMONBus.LayMaLH("10 Anh")
            dtgvBPCong.DataSource = PCGDTHEOBOMONBus.LayBangPhanCong(maLH)

        End If
    End Sub

    Private Sub chkbx10D_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbx10D.CheckedChanged
        If (chkbx10D.Checked = True) Then
            chkbx10D.Checked = True

            chkbx10A.Checked = False
            chkbx10Anh.Checked = False
            chkbx10Hoa.Checked = False
            chkbx10Ly.Checked = False
            chkbx10Sinh.Checked = False
            chkbx10Tin.Checked = False
            chkbx10Toan.Checked = False
            chkbx10Van.Checked = False

            chkbx11A.Checked = False
            chkbx11Anh.Checked = False
            chkbx11D.Checked = False
            chkbx11Hoa.Checked = False
            chkbx11Ly.Checked = False
            chkbx11Sinh.Checked = False
            chkbx11Tin.Checked = False
            chkbx11Toan.Checked = False
            chkbx11Văn.Checked = False

            chkbx12A.Checked = False
            chkbx12Anh.Checked = False
            chkbx12Hoa.Checked = False
            chkbx12Ly.Checked = False
            chkbx12Sinh.Checked = False
            chkbx12Tin.Checked = False
            chkbx12Toan.Checked = False
            chkbx12Van.Checked = False
            Dim maLH As String
            maLH = PCGDTHEOBOMONBus.LayMaLH("10 D")
            dtgvBPCong.DataSource = PCGDTHEOBOMONBus.LayBangPhanCong(maLH)
        End If
    End Sub

    Private Sub chkbx10Hoa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbx10Hoa.CheckedChanged
        If (chkbx10Hoa.Checked = True) Then
            chkbx10Hoa.Checked = True

            chkbx10A.Checked = False
            chkbx10Anh.Checked = False
            chkbx10D.Checked = False
            chkbx10Ly.Checked = False
            chkbx10Sinh.Checked = False
            chkbx10Tin.Checked = False
            chkbx10Toan.Checked = False
            chkbx10Van.Checked = False

            chkbx11A.Checked = False
            chkbx11Anh.Checked = False
            chkbx11D.Checked = False
            chkbx11Hoa.Checked = False
            chkbx11Ly.Checked = False
            chkbx11Sinh.Checked = False
            chkbx11Tin.Checked = False
            chkbx11Toan.Checked = False
            chkbx11Văn.Checked = False

            chkbx12A.Checked = False
            chkbx12Anh.Checked = False
            chkbx12Hoa.Checked = False
            chkbx12Ly.Checked = False
            chkbx12Sinh.Checked = False
            chkbx12Tin.Checked = False
            chkbx12Toan.Checked = False
            chkbx12Van.Checked = False
            Dim maLH As String
            maLH = PCGDTHEOBOMONBus.LayMaLH("10 Hóa")
            dtgvBPCong.DataSource = PCGDTHEOBOMONBus.LayBangPhanCong(maLH)
        End If
    End Sub

    Private Sub chkbx10Ly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbx10Ly.CheckedChanged
        If (chkbx10Ly.Checked = True) Then
            chkbx10Ly.Checked = True

            chkbx10A.Checked = False
            chkbx10Anh.Checked = False
            chkbx10Hoa.Checked = False
            chkbx10D.Checked = False
            chkbx10Sinh.Checked = False
            chkbx10Tin.Checked = False
            chkbx10Toan.Checked = False
            chkbx10Van.Checked = False

            chkbx11A.Checked = False
            chkbx11Anh.Checked = False
            chkbx11D.Checked = False
            chkbx11Hoa.Checked = False
            chkbx11Ly.Checked = False
            chkbx11Sinh.Checked = False
            chkbx11Tin.Checked = False
            chkbx11Toan.Checked = False
            chkbx11Văn.Checked = False

            chkbx12A.Checked = False
            chkbx12Anh.Checked = False
            chkbx12Hoa.Checked = False
            chkbx12Ly.Checked = False
            chkbx12Sinh.Checked = False
            chkbx12Tin.Checked = False
            chkbx12Toan.Checked = False
            chkbx12Van.Checked = False
            Dim maLH As String
            maLH = PCGDTHEOBOMONBus.LayMaLH("10 Lý")
            dtgvBPCong.DataSource = PCGDTHEOBOMONBus.LayBangPhanCong(maLH)
        End If
    End Sub

    Private Sub chkbx10Sinh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbx10Sinh.CheckedChanged
        If (chkbx10Sinh.Checked = True) Then
            chkbx10Sinh.Checked = True

            chkbx10A.Checked = False
            chkbx10Anh.Checked = False
            chkbx10Hoa.Checked = False
            chkbx10Ly.Checked = False
            chkbx10D.Checked = False
            chkbx10Tin.Checked = False
            chkbx10Toan.Checked = False
            chkbx10Van.Checked = False

            chkbx11A.Checked = False
            chkbx11Anh.Checked = False
            chkbx11D.Checked = False
            chkbx11Hoa.Checked = False
            chkbx11Ly.Checked = False
            chkbx11Sinh.Checked = False
            chkbx11Tin.Checked = False
            chkbx11Toan.Checked = False
            chkbx11Văn.Checked = False

            chkbx12A.Checked = False
            chkbx12Anh.Checked = False
            chkbx12Hoa.Checked = False
            chkbx12Ly.Checked = False
            chkbx12Sinh.Checked = False
            chkbx12Tin.Checked = False
            chkbx12Toan.Checked = False
            chkbx12Van.Checked = False
            Dim maLH As String
            maLH = PCGDTHEOBOMONBus.LayMaLH("10 Sinh")
            dtgvBPCong.DataSource = PCGDTHEOBOMONBus.LayBangPhanCong(maLH)
        End If
    End Sub

    Private Sub chkbx10Tin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbx10Tin.CheckedChanged
        If (chkbx10Tin.Checked = True) Then
            chkbx10Tin.Checked = True

            chkbx10A.Checked = False
            chkbx10Anh.Checked = False
            chkbx10Hoa.Checked = False
            chkbx10Ly.Checked = False
            chkbx10Sinh.Checked = False
            chkbx10D.Checked = False
            chkbx10Toan.Checked = False
            chkbx10Van.Checked = False

            chkbx11A.Checked = False
            chkbx11Anh.Checked = False
            chkbx11D.Checked = False
            chkbx11Hoa.Checked = False
            chkbx11Ly.Checked = False
            chkbx11Sinh.Checked = False
            chkbx11Tin.Checked = False
            chkbx11Toan.Checked = False
            chkbx11Văn.Checked = False

            chkbx12A.Checked = False
            chkbx12Anh.Checked = False
            chkbx12Hoa.Checked = False
            chkbx12Ly.Checked = False
            chkbx12Sinh.Checked = False
            chkbx12Tin.Checked = False
            chkbx12Toan.Checked = False
            chkbx12Van.Checked = False
            Dim maLH As String
            maLH = PCGDTHEOBOMONBus.LayMaLH("10 Tin")
            dtgvBPCong.DataSource = PCGDTHEOBOMONBus.LayBangPhanCong(maLH)
        End If
    End Sub

    Private Sub chkbx10Toan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbx10Toan.CheckedChanged
        If (chkbx10Toan.Checked = True) Then
            chkbx10Toan.Checked = True

            chkbx10A.Checked = False
            chkbx10Anh.Checked = False
            chkbx10Hoa.Checked = False
            chkbx10Ly.Checked = False
            chkbx10Sinh.Checked = False
            chkbx10Tin.Checked = False
            chkbx10D.Checked = False
            chkbx10Van.Checked = False

            chkbx11A.Checked = False
            chkbx11Anh.Checked = False
            chkbx11D.Checked = False
            chkbx11Hoa.Checked = False
            chkbx11Ly.Checked = False
            chkbx11Sinh.Checked = False
            chkbx11Tin.Checked = False
            chkbx11Toan.Checked = False
            chkbx11Văn.Checked = False

            chkbx12A.Checked = False
            chkbx12Anh.Checked = False
            chkbx12Hoa.Checked = False
            chkbx12Ly.Checked = False
            chkbx12Sinh.Checked = False
            chkbx12Tin.Checked = False
            chkbx12Toan.Checked = False
            chkbx12Van.Checked = False
            Dim maLH As String
            maLH = PCGDTHEOBOMONBus.LayMaLH("10 Toán")
            dtgvBPCong.DataSource = PCGDTHEOBOMONBus.LayBangPhanCong(maLH)
        End If
    End Sub

    Private Sub chkbx10Van_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbx10Van.CheckedChanged
        If (chkbx10Van.Checked = True) Then
            chkbx10Van.Checked = True

            chkbx10A.Checked = False
            chkbx10Anh.Checked = False
            chkbx10Hoa.Checked = False
            chkbx10Ly.Checked = False
            chkbx10Sinh.Checked = False
            chkbx10Tin.Checked = False
            chkbx10Toan.Checked = False
            chkbx10D.Checked = False

            chkbx11A.Checked = False
            chkbx11Anh.Checked = False
            chkbx11D.Checked = False
            chkbx11Hoa.Checked = False
            chkbx11Ly.Checked = False
            chkbx11Sinh.Checked = False
            chkbx11Tin.Checked = False
            chkbx11Toan.Checked = False
            chkbx11Văn.Checked = False

            chkbx12A.Checked = False
            chkbx12Anh.Checked = False
            chkbx12Hoa.Checked = False
            chkbx12Ly.Checked = False
            chkbx12Sinh.Checked = False
            chkbx12Tin.Checked = False
            chkbx12Toan.Checked = False
            chkbx12Van.Checked = False
            Dim maLH As String
            maLH = PCGDTHEOBOMONBus.LayMaLH("10 Văn")
            dtgvBPCong.DataSource = PCGDTHEOBOMONBus.LayBangPhanCong(maLH)
        End If
    End Sub

    Private Sub chkbx11A_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbx11A.CheckedChanged
        If (chkbx11A.Checked = True) Then
            chkbx11A.Checked = True

            chkbx10A.Checked = False
            chkbx10Anh.Checked = False
            chkbx10Hoa.Checked = False
            chkbx10Ly.Checked = False
            chkbx10Sinh.Checked = False
            chkbx10Tin.Checked = False
            chkbx10Toan.Checked = False
            chkbx10Van.Checked = False
            chkbx10D.Checked = False

            chkbx11Anh.Checked = False
            chkbx11D.Checked = False
            chkbx11Hoa.Checked = False
            chkbx11Ly.Checked = False
            chkbx11Sinh.Checked = False
            chkbx11Tin.Checked = False
            chkbx11Toan.Checked = False
            chkbx11Văn.Checked = False

            chkbx12A.Checked = False
            chkbx12Anh.Checked = False
            chkbx12Hoa.Checked = False
            chkbx12Ly.Checked = False
            chkbx12Sinh.Checked = False
            chkbx12Tin.Checked = False
            chkbx12Toan.Checked = False
            chkbx12Van.Checked = False
            Dim maLH As String
            maLH = PCGDTHEOBOMONBus.LayMaLH("11 A")
            dtgvBPCong.DataSource = PCGDTHEOBOMONBus.LayBangPhanCong(maLH)
        End If
    End Sub

    Private Sub chkbx11Anh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbx11Anh.CheckedChanged
        If (chkbx11Anh.Checked = True) Then
            chkbx11Anh.Checked = True

            chkbx10A.Checked = False
            chkbx10Anh.Checked = False
            chkbx10Hoa.Checked = False
            chkbx10Ly.Checked = False
            chkbx10Sinh.Checked = False
            chkbx10Tin.Checked = False
            chkbx10Toan.Checked = False
            chkbx10Van.Checked = False
            chkbx10D.Checked = False

            chkbx11A.Checked = False
            chkbx11D.Checked = False
            chkbx11Hoa.Checked = False
            chkbx11Ly.Checked = False
            chkbx11Sinh.Checked = False
            chkbx11Tin.Checked = False
            chkbx11Toan.Checked = False
            chkbx11Văn.Checked = False

            chkbx12A.Checked = False
            chkbx12Anh.Checked = False
            chkbx12Hoa.Checked = False
            chkbx12Ly.Checked = False
            chkbx12Sinh.Checked = False
            chkbx12Tin.Checked = False
            chkbx12Toan.Checked = False
            chkbx12Van.Checked = False
            Dim maLH As String
            maLH = PCGDTHEOBOMONBus.LayMaLH("11 Anh")
            dtgvBPCong.DataSource = PCGDTHEOBOMONBus.LayBangPhanCong(maLH)
        End If
    End Sub

    Private Sub chkbx11D_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbx11D.CheckedChanged
        If (chkbx11D.Checked = True) Then
            chkbx11D.Checked = True

            chkbx10A.Checked = False
            chkbx10Anh.Checked = False
            chkbx10Hoa.Checked = False
            chkbx10Ly.Checked = False
            chkbx10Sinh.Checked = False
            chkbx10Tin.Checked = False
            chkbx10Toan.Checked = False
            chkbx10Van.Checked = False
            chkbx10D.Checked = False

            chkbx11Anh.Checked = False
            chkbx11A.Checked = False
            chkbx11Hoa.Checked = False
            chkbx11Ly.Checked = False
            chkbx11Sinh.Checked = False
            chkbx11Tin.Checked = False
            chkbx11Toan.Checked = False
            chkbx11Văn.Checked = False

            chkbx12A.Checked = False
            chkbx12Anh.Checked = False
            chkbx12Hoa.Checked = False
            chkbx12Ly.Checked = False
            chkbx12Sinh.Checked = False
            chkbx12Tin.Checked = False
            chkbx12Toan.Checked = False
            chkbx12Van.Checked = False
            Dim maLH As String
            maLH = PCGDTHEOBOMONBus.LayMaLH("10 D")
            dtgvBPCong.DataSource = PCGDTHEOBOMONBus.LayBangPhanCong(maLH)
        End If
    End Sub

    Private Sub chkbx11Hoa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbx11Hoa.CheckedChanged
        If (chkbx11Hoa.Checked = True) Then
            chkbx11Hoa.Checked = True

            chkbx10A.Checked = False
            chkbx10Anh.Checked = False
            chkbx10Hoa.Checked = False
            chkbx10Ly.Checked = False
            chkbx10Sinh.Checked = False
            chkbx10Tin.Checked = False
            chkbx10Toan.Checked = False
            chkbx10Van.Checked = False
            chkbx10D.Checked = False

            chkbx11Anh.Checked = False
            chkbx11D.Checked = False
            chkbx11A.Checked = False
            chkbx11Ly.Checked = False
            chkbx11Sinh.Checked = False
            chkbx11Tin.Checked = False
            chkbx11Toan.Checked = False
            chkbx11Văn.Checked = False

            chkbx12A.Checked = False
            chkbx12Anh.Checked = False
            chkbx12Hoa.Checked = False
            chkbx12Ly.Checked = False
            chkbx12Sinh.Checked = False
            chkbx12Tin.Checked = False
            chkbx12Toan.Checked = False
            chkbx12Van.Checked = False
            Dim maLH As String
            maLH = PCGDTHEOBOMONBus.LayMaLH("11 Hóa")
            dtgvBPCong.DataSource = PCGDTHEOBOMONBus.LayBangPhanCong(maLH)
        End If
    End Sub

    Private Sub chkbx11Ly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbx11Ly.CheckedChanged
        If (chkbx11Ly.Checked = True) Then
            chkbx11Ly.Checked = True

            chkbx10A.Checked = False
            chkbx10Anh.Checked = False
            chkbx10Hoa.Checked = False
            chkbx10Ly.Checked = False
            chkbx10Sinh.Checked = False
            chkbx10Tin.Checked = False
            chkbx10Toan.Checked = False
            chkbx10Van.Checked = False
            chkbx10D.Checked = False

            chkbx11Anh.Checked = False
            chkbx11D.Checked = False
            chkbx11Hoa.Checked = False
            chkbx11A.Checked = False
            chkbx11Sinh.Checked = False
            chkbx11Tin.Checked = False
            chkbx11Toan.Checked = False
            chkbx11Văn.Checked = False

            chkbx12A.Checked = False
            chkbx12Anh.Checked = False
            chkbx12Hoa.Checked = False
            chkbx12Ly.Checked = False
            chkbx12Sinh.Checked = False
            chkbx12Tin.Checked = False
            chkbx12Toan.Checked = False
            chkbx12Van.Checked = False
            Dim maLH As String
            maLH = PCGDTHEOBOMONBus.LayMaLH("11 Lý")
            dtgvBPCong.DataSource = PCGDTHEOBOMONBus.LayBangPhanCong(maLH)
        End If
    End Sub

    Private Sub chkbx11Sinh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbx11Sinh.CheckedChanged
        If (chkbx11Sinh.Checked = True) Then
            chkbx11Sinh.Checked = True

            chkbx10A.Checked = False
            chkbx10Anh.Checked = False
            chkbx10Hoa.Checked = False
            chkbx10Ly.Checked = False
            chkbx10Sinh.Checked = False
            chkbx10Tin.Checked = False
            chkbx10Toan.Checked = False
            chkbx10Van.Checked = False
            chkbx10D.Checked = False

            chkbx11Anh.Checked = False
            chkbx11D.Checked = False
            chkbx11Hoa.Checked = False
            chkbx11Ly.Checked = False
            chkbx11A.Checked = False
            chkbx11Tin.Checked = False
            chkbx11Toan.Checked = False
            chkbx11Văn.Checked = False

            chkbx12A.Checked = False
            chkbx12Anh.Checked = False
            chkbx12Hoa.Checked = False
            chkbx12Ly.Checked = False
            chkbx12Sinh.Checked = False
            chkbx12Tin.Checked = False
            chkbx12Toan.Checked = False
            chkbx12Van.Checked = False
            Dim maLH As String
            maLH = PCGDTHEOBOMONBus.LayMaLH("11 Sinh")
            dtgvBPCong.DataSource = PCGDTHEOBOMONBus.LayBangPhanCong(maLH)
        End If
    End Sub

    Private Sub chkbx11Tin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbx11Tin.CheckedChanged
        If (chkbx11Tin.Checked = True) Then
            chkbx11Tin.Checked = True

            chkbx10A.Checked = False
            chkbx10Anh.Checked = False
            chkbx10Hoa.Checked = False
            chkbx10Ly.Checked = False
            chkbx10Sinh.Checked = False
            chkbx10Tin.Checked = False
            chkbx10Toan.Checked = False
            chkbx10Van.Checked = False
            chkbx10D.Checked = False

            chkbx11Anh.Checked = False
            chkbx11D.Checked = False
            chkbx11Hoa.Checked = False
            chkbx11Ly.Checked = False
            chkbx11Sinh.Checked = False
            chkbx11A.Checked = False
            chkbx11Toan.Checked = False
            chkbx11Văn.Checked = False

            chkbx12A.Checked = False
            chkbx12Anh.Checked = False
            chkbx12Hoa.Checked = False
            chkbx12Ly.Checked = False
            chkbx12Sinh.Checked = False
            chkbx12Tin.Checked = False
            chkbx12Toan.Checked = False
            chkbx12Van.Checked = False
            Dim maLH As String
            maLH = PCGDTHEOBOMONBus.LayMaLH("11 Tin")
            dtgvBPCong.DataSource = PCGDTHEOBOMONBus.LayBangPhanCong(maLH)
        End If
    End Sub

    Private Sub chkbx11Toan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbx11Toan.CheckedChanged
        If (chkbx11Toan.Checked = True) Then
            chkbx11Toan.Checked = True

            chkbx10A.Checked = False
            chkbx10Anh.Checked = False
            chkbx10Hoa.Checked = False
            chkbx10Ly.Checked = False
            chkbx10Sinh.Checked = False
            chkbx10Tin.Checked = False
            chkbx10Toan.Checked = False
            chkbx10Van.Checked = False
            chkbx10D.Checked = False

            chkbx11Anh.Checked = False
            chkbx11D.Checked = False
            chkbx11Hoa.Checked = False
            chkbx11Ly.Checked = False
            chkbx11Sinh.Checked = False
            chkbx11Tin.Checked = False
            chkbx11A.Checked = False
            chkbx11Văn.Checked = False

            chkbx12A.Checked = False
            chkbx12Anh.Checked = False
            chkbx12Hoa.Checked = False
            chkbx12Ly.Checked = False
            chkbx12Sinh.Checked = False
            chkbx12Tin.Checked = False
            chkbx12Toan.Checked = False
            chkbx12Van.Checked = False
            Dim maLH As String
            maLH = PCGDTHEOBOMONBus.LayMaLH("11 Toán")
            dtgvBPCong.DataSource = PCGDTHEOBOMONBus.LayBangPhanCong(maLH)
        End If
    End Sub

    Private Sub chkbx11Văn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbx11Văn.CheckedChanged
        If (chkbx11Văn.Checked = True) Then
            chkbx11Văn.Checked = True

            chkbx10A.Checked = False
            chkbx10Anh.Checked = False
            chkbx10Hoa.Checked = False
            chkbx10Ly.Checked = False
            chkbx10Sinh.Checked = False
            chkbx10Tin.Checked = False
            chkbx10Toan.Checked = False
            chkbx10Van.Checked = False
            chkbx10D.Checked = False

            chkbx11Anh.Checked = False
            chkbx11D.Checked = False
            chkbx11Hoa.Checked = False
            chkbx11Ly.Checked = False
            chkbx11Sinh.Checked = False
            chkbx11Tin.Checked = False
            chkbx11Toan.Checked = False
            chkbx11A.Checked = False

            chkbx12A.Checked = False
            chkbx12Anh.Checked = False
            chkbx12Hoa.Checked = False
            chkbx12Ly.Checked = False
            chkbx12Sinh.Checked = False
            chkbx12Tin.Checked = False
            chkbx12Toan.Checked = False
            chkbx12Van.Checked = False
            Dim maLH As String
            maLH = PCGDTHEOBOMONBus.LayMaLH("10 Văn")
            dtgvBPCong.DataSource = PCGDTHEOBOMONBus.LayBangPhanCong(maLH)
        End If
    End Sub

    Private Sub chkbx12A_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbx12A.CheckedChanged
        If (chkbx12A.Checked = True) Then
            chkbx12A.Checked = True

            chkbx10A.Checked = False
            chkbx10Anh.Checked = False
            chkbx10Hoa.Checked = False
            chkbx10Ly.Checked = False
            chkbx10Sinh.Checked = False
            chkbx10Tin.Checked = False
            chkbx10Toan.Checked = False
            chkbx10Van.Checked = False
            chkbx10D.Checked = False

            chkbx11A.Checked = False
            chkbx11Anh.Checked = False
            chkbx11D.Checked = False
            chkbx11Hoa.Checked = False
            chkbx11Ly.Checked = False
            chkbx11Sinh.Checked = False
            chkbx11Tin.Checked = False
            chkbx11Toan.Checked = False
            chkbx11Văn.Checked = False

            chkbx12Anh.Checked = False
            chkbx12Hoa.Checked = False
            chkbx12Ly.Checked = False
            chkbx12Sinh.Checked = False
            chkbx12Tin.Checked = False
            chkbx12Toan.Checked = False
            chkbx12Van.Checked = False
            Dim maLH As String
            maLH = PCGDTHEOBOMONBus.LayMaLH("12 A")
            dtgvBPCong.DataSource = PCGDTHEOBOMONBus.LayBangPhanCong(maLH)
        End If
    End Sub

    Private Sub chkbx12Anh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbx12Anh.CheckedChanged
        If (chkbx12Anh.Checked = True) Then
            chkbx12Anh.Checked = True

            chkbx10A.Checked = False
            chkbx10Anh.Checked = False
            chkbx10Hoa.Checked = False
            chkbx10Ly.Checked = False
            chkbx10Sinh.Checked = False
            chkbx10Tin.Checked = False
            chkbx10Toan.Checked = False
            chkbx10Van.Checked = False
            chkbx10D.Checked = False

            chkbx11A.Checked = False
            chkbx11Anh.Checked = False
            chkbx11D.Checked = False
            chkbx11Hoa.Checked = False
            chkbx11Ly.Checked = False
            chkbx11Sinh.Checked = False
            chkbx11Tin.Checked = False
            chkbx11Toan.Checked = False
            chkbx11Văn.Checked = False

            chkbx12A.Checked = False
            chkbx12Hoa.Checked = False
            chkbx12Ly.Checked = False
            chkbx12Sinh.Checked = False
            chkbx12Tin.Checked = False
            chkbx12Toan.Checked = False
            chkbx12Van.Checked = False
            Dim maLH As String
            maLH = PCGDTHEOBOMONBus.LayMaLH("12 Anh")
            dtgvBPCong.DataSource = PCGDTHEOBOMONBus.LayBangPhanCong(maLH)
        End If
    End Sub

    Private Sub chkbx12Hoa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbx12Hoa.CheckedChanged
        If (chkbx12Hoa.Checked = True) Then
            chkbx12Hoa.Checked = True

            chkbx10A.Checked = False
            chkbx10Anh.Checked = False
            chkbx10Hoa.Checked = False
            chkbx10Ly.Checked = False
            chkbx10Sinh.Checked = False
            chkbx10Tin.Checked = False
            chkbx10Toan.Checked = False
            chkbx10Van.Checked = False
            chkbx10D.Checked = False

            chkbx11A.Checked = False
            chkbx11Anh.Checked = False
            chkbx11D.Checked = False
            chkbx11Hoa.Checked = False
            chkbx11Ly.Checked = False
            chkbx11Sinh.Checked = False
            chkbx11Tin.Checked = False
            chkbx11Toan.Checked = False
            chkbx11Văn.Checked = False

            chkbx12Anh.Checked = False
            chkbx12A.Checked = False
            chkbx12Ly.Checked = False
            chkbx12Sinh.Checked = False
            chkbx12Tin.Checked = False
            chkbx12Toan.Checked = False
            chkbx12Van.Checked = False
            Dim maLH As String
            maLH = PCGDTHEOBOMONBus.LayMaLH("10 Hóa")
            dtgvBPCong.DataSource = PCGDTHEOBOMONBus.LayBangPhanCong(maLH)
        End If
    End Sub

    Private Sub chkbx12Ly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbx12Ly.CheckedChanged
        If (chkbx12Ly.Checked = True) Then
            chkbx12Ly.Checked = True

            chkbx10A.Checked = False
            chkbx10Anh.Checked = False
            chkbx10Hoa.Checked = False
            chkbx10Ly.Checked = False
            chkbx10Sinh.Checked = False
            chkbx10Tin.Checked = False
            chkbx10Toan.Checked = False
            chkbx10Van.Checked = False
            chkbx10D.Checked = False

            chkbx11A.Checked = False
            chkbx11Anh.Checked = False
            chkbx11D.Checked = False
            chkbx11Hoa.Checked = False
            chkbx11Ly.Checked = False
            chkbx11Sinh.Checked = False
            chkbx11Tin.Checked = False
            chkbx11Toan.Checked = False
            chkbx11Văn.Checked = False

            chkbx12Anh.Checked = False
            chkbx12Hoa.Checked = False
            chkbx12A.Checked = False
            chkbx12Sinh.Checked = False
            chkbx12Tin.Checked = False
            chkbx12Toan.Checked = False
            chkbx12Van.Checked = False
            Dim maLH As String
            maLH = PCGDTHEOBOMONBus.LayMaLH("12 Lý")
            dtgvBPCong.DataSource = PCGDTHEOBOMONBus.LayBangPhanCong(maLH)
        End If
    End Sub

    Private Sub chkbx12Sinh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbx12Sinh.CheckedChanged
        If (chkbx12Sinh.Checked = True) Then
            chkbx12Sinh.Checked = True

            chkbx10A.Checked = False
            chkbx10Anh.Checked = False
            chkbx10Hoa.Checked = False
            chkbx10Ly.Checked = False
            chkbx10Sinh.Checked = False
            chkbx10Tin.Checked = False
            chkbx10Toan.Checked = False
            chkbx10Van.Checked = False
            chkbx10D.Checked = False

            chkbx11A.Checked = False
            chkbx11Anh.Checked = False
            chkbx11D.Checked = False
            chkbx11Hoa.Checked = False
            chkbx11Ly.Checked = False
            chkbx11Sinh.Checked = False
            chkbx11Tin.Checked = False
            chkbx11Toan.Checked = False
            chkbx11Văn.Checked = False

            chkbx12Anh.Checked = False
            chkbx12Hoa.Checked = False
            chkbx12Ly.Checked = False
            chkbx12A.Checked = False
            chkbx12Tin.Checked = False
            chkbx12Toan.Checked = False
            chkbx12Van.Checked = False
            Dim maLH As String
            maLH = PCGDTHEOBOMONBus.LayMaLH("10 Sinh")
            dtgvBPCong.DataSource = PCGDTHEOBOMONBus.LayBangPhanCong(maLH)
        End If
    End Sub

    Private Sub chkbx12Tin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbx12Tin.CheckedChanged
        If (chkbx12Tin.Checked = True) Then
            chkbx12Tin.Checked = True

            chkbx10A.Checked = False
            chkbx10Anh.Checked = False
            chkbx10Hoa.Checked = False
            chkbx10Ly.Checked = False
            chkbx10Sinh.Checked = False
            chkbx10Tin.Checked = False
            chkbx10Toan.Checked = False
            chkbx10Van.Checked = False
            chkbx10D.Checked = False

            chkbx11A.Checked = False
            chkbx11Anh.Checked = False
            chkbx11D.Checked = False
            chkbx11Hoa.Checked = False
            chkbx11Ly.Checked = False
            chkbx11Sinh.Checked = False
            chkbx11Tin.Checked = False
            chkbx11Toan.Checked = False
            chkbx11Văn.Checked = False

            chkbx12Anh.Checked = False
            chkbx12Hoa.Checked = False
            chkbx12Ly.Checked = False
            chkbx12Sinh.Checked = False
            chkbx12A.Checked = False
            chkbx12Toan.Checked = False
            chkbx12Van.Checked = False
            Dim maLH As String
            maLH = PCGDTHEOBOMONBus.LayMaLH("12 Tin")
            dtgvBPCong.DataSource = PCGDTHEOBOMONBus.LayBangPhanCong(maLH)
        End If
    End Sub

    Private Sub chkbx12Toan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbx12Toan.CheckedChanged
        If (chkbx12Toan.Checked = True) Then
            chkbx12Toan.Checked = True

            chkbx10A.Checked = False
            chkbx10Anh.Checked = False
            chkbx10Hoa.Checked = False
            chkbx10Ly.Checked = False
            chkbx10Sinh.Checked = False
            chkbx10Tin.Checked = False
            chkbx10Toan.Checked = False
            chkbx10Van.Checked = False
            chkbx10D.Checked = False

            chkbx11A.Checked = False
            chkbx11Anh.Checked = False
            chkbx11D.Checked = False
            chkbx11Hoa.Checked = False
            chkbx11Ly.Checked = False
            chkbx11Sinh.Checked = False
            chkbx11Tin.Checked = False
            chkbx11Toan.Checked = False
            chkbx11Văn.Checked = False

            chkbx12Anh.Checked = False
            chkbx12Hoa.Checked = False
            chkbx12Ly.Checked = False
            chkbx12Sinh.Checked = False
            chkbx12Tin.Checked = False
            chkbx12A.Checked = False
            chkbx12Van.Checked = False
            Dim maLH As String
            maLH = PCGDTHEOBOMONBus.LayMaLH("12 Toán")
            dtgvBPCong.DataSource = PCGDTHEOBOMONBus.LayBangPhanCong(maLH)
        End If
    End Sub

    Private Sub chkbx12Van_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbx12Van.CheckedChanged
        If (chkbx12Van.Checked = True) Then
            chkbx12Van.Checked = True

            chkbx10A.Checked = False
            chkbx10Anh.Checked = False
            chkbx10Hoa.Checked = False
            chkbx10Ly.Checked = False
            chkbx10Sinh.Checked = False
            chkbx10Tin.Checked = False
            chkbx10Toan.Checked = False
            chkbx10Van.Checked = False
            chkbx10D.Checked = False

            chkbx11A.Checked = False
            chkbx11Anh.Checked = False
            chkbx11D.Checked = False
            chkbx11Hoa.Checked = False
            chkbx11Ly.Checked = False
            chkbx11Sinh.Checked = False
            chkbx11Tin.Checked = False
            chkbx11Toan.Checked = False
            chkbx11Văn.Checked = False

            chkbx12Anh.Checked = False
            chkbx12Hoa.Checked = False
            chkbx12Ly.Checked = False
            chkbx12Sinh.Checked = False
            chkbx12Tin.Checked = False
            chkbx12Toan.Checked = False
            chkbx12A.Checked = False
            Dim maLH As String
            maLH = PCGDTHEOBOMONBus.LayMaLH("12 Văn")
            dtgvBPCong.DataSource = PCGDTHEOBOMONBus.LayBangPhanCong(maLH)
        End If
    End Sub

    Private Sub dtgvBPCong_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgvBPCong.SelectionChanged
        Dim co1 As Boolean = False
        Dim co2 As Boolean = False
        Dim co3 As Boolean = False
        Dim co4 As Boolean = False
        Dim co5 As Boolean = False
        Dim co6 As Boolean = False
        Dim co7 As Boolean = False
        Dim co8 As Boolean = False
        Dim co9 As Boolean = False
        Dim co10 As Boolean = False
        Dim co11 As Boolean = False
        Dim co12 As Boolean = False
        Dim co13 As Boolean = False
        Dim co14 As Boolean = False
        Dim co15 As Boolean = False
        Dim co16 As Boolean = False
        Dim co17 As Boolean = False
        Dim co18 As Boolean = False
        Dim co19 As Boolean = False
        Dim co20 As Boolean = False

        chkbxAnh.Checked = False
        chkbxAnhNC1.Checked = False
        chkbxAnhNC2.Checked = False
        chkbxDaiLuong.Checked = False
        chkbxGiaiTich.Checked = False
        chkbxDia.Checked = False
        chkbxDiaC.Checked = False
        chkbxSu.Checked = False
        chkbxSuC.Checked = False
        chkbxGDCD.Checked = False
        chkbxSHCN.Checked = False
        chkbxSHDC.Checked = False
        chkbxKTNN.Checked = False
        chkbxKTCN.Checked = False
        chkbxSinhNC1.Checked = False
        chkbxSinhNC2.Checked = False
        chkbxTheDuc.Checked = False
        chkbxVan.Checked = False
        chkbxVanNC1.Checked = False
        chkbxVanNC2.Checked = False

        co1 = PCGDTHEOBOMONBus.KTMH("Sinh NC1", dtgvBPCong.DataSource)
        If (co1 = True) Then
            chkbxSinhNC1.Checked = True
            co1 = False
        End If
        co2 = PCGDTHEOBOMONBus.KTMH("Sinh NC2", dtgvBPCong.DataSource)
        If (co2 = True) Then
            chkbxSinhNC2.Checked = True
            co2 = False
        End If

        co3 = PCGDTHEOBOMONBus.KTMH("Anh", dtgvBPCong.DataSource)
        If (co3 = True) Then
            chkbxAnh.Checked = True
            co3 = False
        End If

        co4 = PCGDTHEOBOMONBus.KTMH("Anh NC1", dtgvBPCong.DataSource)
        If (co4 = True) Then
            chkbxAnhNC1.Checked = True
            co4 = False
        End If

        co5 = PCGDTHEOBOMONBus.KTMH("Anh NC2", dtgvBPCong.DataSource)
        If (co5 = True) Then
            chkbxAnhNC2.Checked = True
            co5 = False
        End If

        co6 = PCGDTHEOBOMONBus.KTMH("Văn", dtgvBPCong.DataSource)
        If (co6 = True) Then
            chkbxVan.Checked = True
            co6 = False
        End If

        co7 = PCGDTHEOBOMONBus.KTMH("Văn NC1", dtgvBPCong.DataSource)
        If (co7 = True) Then
            chkbxVanNC1.Checked = True
            co7 = False
        End If

        co8 = PCGDTHEOBOMONBus.KTMH("Văn NC2", dtgvBPCong.DataSource)
        If (co8 = True) Then
            chkbxVanNC2.Checked = True
            co8 = False
        End If

        co9 = PCGDTHEOBOMONBus.KTMH("Sử", dtgvBPCong.DataSource)
        If (co9 = True) Then
            chkbxSu.Checked = True
            co9 = False
        End If

        co10 = PCGDTHEOBOMONBus.KTMH("Sử C", dtgvBPCong.DataSource)
        If (co10 = True) Then
            chkbxSuC.Checked = True
            co10 = False
        End If

        co11 = PCGDTHEOBOMONBus.KTMH("Địa", dtgvBPCong.DataSource)
        If (co11 = True) Then
            chkbxDia.Checked = True
            co11 = False
        End If

        co12 = PCGDTHEOBOMONBus.KTMH("Địa C", dtgvBPCong.DataSource)
        If (co12 = True) Then
            chkbxDiaC.Checked = True
            co12 = False
        End If

        co13 = PCGDTHEOBOMONBus.KTMH("GDCD", dtgvBPCong.DataSource)
        If (co13 = True) Then
            chkbxGDCD.Checked = True
            co13 = False
        End If

        co14 = PCGDTHEOBOMONBus.KTMH("KTNN", dtgvBPCong.DataSource)
        If (co2 = True) Then
            chkbxKTNN.Checked = True
            co14 = False
        End If

        co15 = PCGDTHEOBOMONBus.KTMH("KTCN", dtgvBPCong.DataSource)
        If (co15 = True) Then
            chkbxKTCN.Checked = True
            co15 = False
        End If

        co16 = PCGDTHEOBOMONBus.KTMH("Thể Dục", dtgvBPCong.DataSource)
        If (co16 = True) Then
            chkbxTheDuc.Checked = True
            co16 = False
        End If

        co17 = PCGDTHEOBOMONBus.KTMH("SHCN", dtgvBPCong.DataSource)
        If (co17 = True) Then
            chkbxSHCN.Checked = True
            co17 = False
        End If

        co18 = PCGDTHEOBOMONBus.KTMH("SHDC", dtgvBPCong.DataSource)
        If (co18 = True) Then
            chkbxSHCN.Checked = True
            co18 = False
        End If

        co19 = PCGDTHEOBOMONBus.KTMH("Đại Lượng", dtgvBPCong.DataSource)
        If (co19 = True) Then
            chkbxDaiLuong.Checked = True
            co19 = False
        End If

        co20 = PCGDTHEOBOMONBus.KTMH("Giải Tích", dtgvBPCong.DataSource)
        If (co20 = True) Then
            chkbxGiaiTich.Checked = True
            co20 = False
        End If
    End Sub

    Private Sub btnGiaoVienKeTruoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGiaoVienKeTruoc.Click
        If (dtgvDSGVien.CurrentRow.Index > 1) Then
            Dim rowInDex As Integer = dtgvDSGVien.CurrentRow.Index + tang - 1
            Dim tengiaovien As String = dtgvDSGVien("Họ Tên Giáo Viên", rowInDex).Value
            txtHoTenGiaoVien.Text = tengiaovien
            Dim tentat As String = dtgvDSGVien("Tên Tắt", rowInDex).Value
            txtTenTat.Text = tentat
            Dim maGV As String = dtgvDSGVien("Mã Giáo Viên", rowInDex).Value
            Dim dt As New DataTable()
            dt = PCGDTHEOBOMONBus.LayBangPhanCongTheoGV(maGV)
            dtgvBPCong.DataSource = dt
            tang -= 1
        End If
    End Sub

    Private Sub btnGiaoVienTieptheo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGiaoVienTieptheo.Click
        Dim rowInDex As Integer = dtgvDSGVien.CurrentRow.Index + tang + 1
        Dim tengiaovien As String = dtgvDSGVien("Họ Tên Giáo Viên", rowInDex).Value
        txtHoTenGiaoVien.Text = tengiaovien
        Dim tentat As String = dtgvDSGVien("Tên Tắt", rowInDex).Value
        txtTenTat.Text = tentat
        Dim maGV As String = dtgvDSGVien("Mã Giáo Viên", rowInDex).Value
        Dim dt As New DataTable()
        dt = PCGDTHEOBOMONBus.LayBangPhanCongTheoGV(maGV)
        dtgvBPCong.DataSource = dt
        tang += 1
    End Sub

    Private Sub btnXuatRaTapTin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXuatRaTapTin.Click
        Dim app As New Microsoft.Office.Interop.Excel.Application()
        app.Visible = False
        Dim workbooks As Microsoft.Office.Interop.Excel.Workbooks
        workbooks = app.Workbooks
        Dim book As Microsoft.Office.Interop.Excel._Workbook
        book = workbooks.Add(Type.Missing)
        Dim sheet As Microsoft.Office.Interop.Excel._Worksheet
        sheet = book.ActiveSheet

        Dim dt As DataTable
        dt = Me.dtgvBPCong.DataSource
        sheet.Range("A1", Type.Missing).Value2 = "STT"
        sheet.Range("B1", Type.Missing).Value2 = "Tên Lớp Học"
        sheet.Range("C1", Type.Missing).Value2 = "Môn Học"
        sheet.Range("D1", Type.Missing).Value2 = "Tổng Số Tiết/Tuần"
        sheet.Range("E1", Type.Missing).Value2 = "Giáo Viên"
        sheet.Range("F1", Type.Missing).Value2 = "STHLTTT"
        sheet.Range("G1", Type.Missing).Value2 = "STHLTTD"
        sheet.Range("H1", Type.Missing).Value2 = "SBHTT"
        sheet.Range("I1", Type.Missing).Value2 = "SBHTD"
        Dim colIndex = 1
        Dim j As Integer = 2

        For i As Integer = 0 To dt.Rows.Count - 1
            Dim dr As DataRow
            dr = dt.Rows(i)
            sheet.Range("A" + j.ToString(), Type.Missing).Value2 = dr(0).ToString()
            sheet.Range("B" + j.ToString(), Type.Missing).Value2 = dr(1).ToString()
            sheet.Range("C" + j.ToString(), Type.Missing).Value2 = dr(2).ToString()
            sheet.Range("D" + j.ToString(), Type.Missing).Value2 = dr(3).ToString()
            sheet.Range("E" + j.ToString(), Type.Missing).Value2 = dr(4).ToString()
            sheet.Range("F" + j.ToString(), Type.Missing).Value2 = dr(5).ToString()
            sheet.Range("G" + j.ToString(), Type.Missing).Value2 = dr(6).ToString()
            sheet.Range("H" + j.ToString(), Type.Missing).Value2 = dr(7).ToString()
            sheet.Range("I" + j.ToString(), Type.Missing).Value2 = dr(8).ToString()
            j = j + 1
        Next
        Me.SaveFileDialog1.ShowDialog()
        Dim name = Me.SaveFileDialog1.FileName
        book.SaveAs(name, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing)
    End Sub
End Class
