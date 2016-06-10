Imports BUSLayer
Imports DTO

Public Class frmTiepNhanHocSinh
    Private Sub btnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhi.Click
        Try
            Dim hsDto As New HocSinhDto()

            Dim lhDto As LopHocDto
            lhDto = cmbLopHoc.SelectedItem

            hsDto.Ten = txtTen.Text
            hsDto.NgaySinh = dtpNgaySinh.Value
            hsDto.DiaChi = txtDiaChi.Text
            hsDto.Toan = nudToan.Value
            hsDto.Ly = nudLy.Value
            hsDto.Hoa = nudHoa.Value
            hsDto.DTB = Math.Round((hsDto.Toan + hsDto.Ly + hsDto.Hoa) / 3, 2)
            hsDto.MaLop = lhDto.Ma

            Dim hsBus As New HocSinhBus()
            hsBus.Them(hsDto)

            txtMa.Text = hsDto.Ma.ToString()
            txtDTB.Text = hsDto.DTB.ToString()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim lhBus As New LopHocBus()
        Dim ds As IList
        ds = lhBus.LayDanhSach()
        cmbLopHoc.DataSource = ds
        cmbLopHoc.ValueMember = "Ma"    'Chuoi ten property Ma cua doi tuong LopHocDto
        cmbLopHoc.DisplayMember = "Ten" 'Chuoi ten property Ten cua doi tuong LopHocDto
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.Close()
    End Sub

    Private Sub txtTen_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTen.KeyPress
        If (Not Char.IsLetter(e.KeyChar) And Not Char.IsWhiteSpace(e.KeyChar)) Then
            e.Handled = True
        End If
        If (Char.IsControl(e.KeyChar)) Then
            e.Handled = False
        End If
    End Sub
End Class
