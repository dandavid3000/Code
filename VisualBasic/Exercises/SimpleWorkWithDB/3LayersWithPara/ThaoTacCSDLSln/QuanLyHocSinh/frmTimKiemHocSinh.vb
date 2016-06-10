Imports BUSLayer
Imports DTO

Public Class frmTimKiemHocSinh
    Private hsCrt As HocSinhCrt

#Region "Load Data"
    Private Sub LoadLopHoc()
        Dim lhBus As New LopHocBus()
        Dim ds As IList
        ds = lhBus.LayDanhSach()
        cmbLopHoc.DataSource = ds
        cmbLopHoc.ValueMember = "Ma"    'Chuoi ten property Ma cua doi tuong LopHocDto
        cmbLopHoc.DisplayMember = "Ten" 'Chuoi ten property Ten cua doi tuong LopHocDto
    End Sub
    Private Sub CapNhatTieuChuanTraCuu(ByVal bUpdated As Boolean)
        If (bUpdated) Then
            If (txtMaHocSinh.Text <> "") Then
                hsCrt.Ma = Integer.Parse(txtMaHocSinh.Text)
            Else
                hsCrt.Ma = 0
            End If
            hsCrt.Ten = txtTenHocSinh.Text
            hsCrt.NgaySinhTu = dtpNgaySinhTu.Value.Date
            hsCrt.NgaySinhDen = dtpNgaySinhDen.Value.Date
            hsCrt.DiaChi = txtDiaChi.Text
            hsCrt.ToanTu = nudDiemToanTu.Value
            hsCrt.ToanDen = nudDiemToanDen.Value
            hsCrt.LyTu = nudDiemLyTu.Value
            hsCrt.LyDen = nudDiemLyDen.Value
            hsCrt.HoaTu = nudDiemHoaTu.Value
            hsCrt.HoaDen = nudDiemHoaDen.Value
            hsCrt.DTBTu = nudDTBTu.Value
            hsCrt.DTBDen = nudDTBDen.Value
            hsCrt.CheckNgaySinh = chkNgaySinh.Checked
            hsCrt.CheckDiaChi = chkDiaChi.Checked
            hsCrt.CheckToan = chkDiemToan.Checked
            hsCrt.CheckLy = chkDiemLy.Checked
            hsCrt.CheckHoa = chkDiemHoa.Checked
            hsCrt.CheckDTB = chkDTB.Checked
            hsCrt.CheckLopHoc = chkLopHoc.Checked
        Else
            If (hsCrt.Ma <> 0) Then
                txtMaHocSinh.Text = hsCrt.Ma.ToString()
            End If
            txtTenHocSinh.Text = hsCrt.Ten
            dtpNgaySinhTu.Value = hsCrt.NgaySinhTu.Date
            dtpNgaySinhDen.Value = hsCrt.NgaySinhDen.Date
            txtDiaChi.Text = hsCrt.DiaChi
            nudDiemToanTu.Value = hsCrt.ToanTu
            nudDiemToanDen.Value = hsCrt.ToanDen
            nudDiemLyTu.Value = hsCrt.LyTu
            nudDiemLyDen.Value = hsCrt.LyDen
            nudDiemHoaTu.Value = hsCrt.HoaTu
            nudDiemHoaDen.Value = hsCrt.HoaDen
            nudDTBTu.Value = hsCrt.DTBTu
            nudDTBDen.Value = hsCrt.DTBDen
            chkNgaySinh.Checked = hsCrt.CheckNgaySinh
            chkDiaChi.Checked = hsCrt.CheckDiaChi
            chkDiemToan.Checked = hsCrt.CheckToan
            chkDiemLy.Checked = hsCrt.CheckLy
            chkDiemHoa.Checked = hsCrt.CheckHoa
            chkDTB.Checked = hsCrt.CheckDTB
            chkLopHoc.Checked = hsCrt.CheckLopHoc
        End If
    End Sub
    Private Sub frmTimKiemHocSinh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            LoadLopHoc()
            hsCrt = New HocSinhCrt()
            CapNhatTieuChuanTraCuu(False)
            Dim dtHS As New DataTable()
            dtgHocSinh.DataSource = dtHS
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region

#Region "Check Criteria"

    Private Sub chkNgaySinh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles chkNgaySinh.CheckedChanged
        If (chkNgaySinh.Checked) Then
            dtpNgaySinhTu.Enabled = True
            dtpNgaySinhDen.Enabled = True
        Else
            dtpNgaySinhTu.Enabled = False
            dtpNgaySinhDen.Enabled = False
        End If
    End Sub

    Private Sub chkDiaChi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles chkDiaChi.CheckedChanged
        If (chkDiaChi.Checked) Then
            txtDiaChi.Enabled = True
        Else
            txtDiaChi.Enabled = False
        End If
    End Sub

    Private Sub chkDiemToan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles chkDiemToan.CheckedChanged
        If (chkDiemToan.Checked) Then
            nudDiemToanTu.Enabled = True
            nudDiemToanDen.Enabled = True
        Else
            nudDiemToanTu.Enabled = False
            nudDiemToanDen.Enabled = False
        End If
    End Sub

    Private Sub chkDiemLy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles chkDiemLy.CheckedChanged
        If (chkDiemLy.Checked) Then
            nudDiemLyTu.Enabled = True
            nudDiemLyDen.Enabled = True
        Else
            nudDiemLyTu.Enabled = False
            nudDiemLyDen.Enabled = False
        End If
    End Sub

    Private Sub chkDiemHoa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles chkDiemHoa.CheckedChanged
        If (chkDiemHoa.Checked) Then
            nudDiemHoaTu.Enabled = True
            nudDiemHoaDen.Enabled = True
        Else
            nudDiemHoaTu.Enabled = False
            nudDiemHoaDen.Enabled = False
        End If
    End Sub

    Private Sub chkDTB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles chkDTB.CheckedChanged
        If (chkDTB.Checked) Then
            nudDTBTu.Enabled = True
            nudDTBDen.Enabled = True
        Else
            nudDTBTu.Enabled = False
            nudDTBDen.Enabled = False
        End If
    End Sub

    Private Sub chkLopHoc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles chkLopHoc.CheckedChanged
        If (chkLopHoc.Checked) Then
            cmbLopHoc.Enabled = True
        Else
            cmbLopHoc.Enabled = False
        End If
    End Sub

#End Region

#Region "Xu ly su kien"
    Private Sub btnTraCuu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTraCuu.Click
        Try
            CapNhatTieuChuanTraCuu(True)
            Dim hsBus As New HocSinhBus()
            Dim dtHS As DataTable
            dtHS = hsBus.TimKiem(hsCrt)
            dtgHocSinh.DataSource = dtHS
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.Close()
    End Sub
#End Region
    
End Class