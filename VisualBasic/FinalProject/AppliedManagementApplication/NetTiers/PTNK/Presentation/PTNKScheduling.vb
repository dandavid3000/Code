Imports System
Imports System.Data
Imports System.Configuration
Imports Microsoft
Imports PTNK.Entities
Imports PTNK.Services


Public Class PTNKScheduling
    Public co As Boolean = False
    Public co1 As Boolean = False
    Public co2 As Boolean = False

    Public ma As String

    Private Sub PTNKScheduling_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'LOPHOC
        rdKhoi10.Checked = True
        Dim lh As New LopHoc
        Dim lhs As New LopHocService

        lh.MaKhoi = "k10"

        Dim dtDS As New TList(Of LopHoc)
        dtDS = lhs.GetByMaKhoi(lh.MaKhoi)
        dtgvDSLopHoc.DataSource = dtDS

        ''With dtgvDSLopHoc
        ''    .Columns("STT").Width = 35
        ''    .Columns("STT").DisplayIndex = 0
        ''    .Columns("STT").ReadOnly = True
        ''    .AlternatingRowsDefaultCellStyle.ForeColor = Color.Red
        ''    .Columns("STT").DefaultCellStyle.BackColor = Color.DeepSkyBlue
        ''End With

        ''With dtgvLichRanh
        ''    .Columns("Tiết").Width = 35
        ''    .Columns("Tiết").DisplayIndex = 0
        ''    .Columns("Tiết").ReadOnly = True
        ''    .Columns("Thứ 2").ReadOnly = True
        ''    .Columns("Thứ 3").ReadOnly = True
        ''    .Columns("Thứ 4").ReadOnly = True
        ''    .Columns("Thứ 5").ReadOnly = True
        ''    .Columns("Thứ 6").ReadOnly = True
        ''    .Columns("Thứ 7").ReadOnly = True
        ''    .Columns("Chủ Nhật").ReadOnly = True
        ''    .AlternatingRowsDefaultCellStyle.ForeColor = Color.Red
        ''    .Columns("Tiết").DefaultCellStyle.BackColor = Color.DeepSkyBlue
        ''End With
    End Sub



    Private Sub rdKhoi10_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdKhoi10.CheckedChanged
        If (rdKhoi10.Checked = True) Then
            rdKhoi11.Checked = False
            rdKhoi12.Checked = False
            rdKhoiTatCa.Checked = False
            Dim lh As New LopHoc
            Dim lhs As New LopHocService
            lh.MaKhoi = "k10"
            Dim dt As New TList(Of LopHoc)
            dt = lhs.GetByMaKhoi(lh.MaKhoi)
            dtgvDSLopHoc.DataSource = dt

            Dim dt1 As New TList(Of LopHoc)
            Dim dt1s As New LopHocService
            lh.MaLopHoc = txtMaLopHoc.Text
            ''dt1 = dt1s.GetByMaLopHoc(lh.MaLopHoc)
            dtgvLichRanh.DataSource = dt1
        End If
    End Sub
End Class
