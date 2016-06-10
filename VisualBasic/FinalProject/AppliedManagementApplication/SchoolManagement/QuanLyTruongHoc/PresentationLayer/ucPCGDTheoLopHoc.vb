Imports BUSLayer
Imports DTO
Imports PresentationLayer

Public Class ucPCGDTheoLopHoc

    Private Sub ucPCGDTheoLopHoc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt1 As New DataTable()
        dt1 = GIAOVIENBus.LayBangGiaoVien()
        dtgvDSGVien.DataSource = dt1
        rdPhanCongTheoLopHoc.Checked = True
        rdK10.Checked = True
        With dtgvDSGVien
            .Columns("STT").Width = 35
            .Columns("STT").DisplayIndex = 0
            .Columns("STT").ReadOnly = True
            .AlternatingRowsDefaultCellStyle.ForeColor = Color.Red
            .Columns("STT").DefaultCellStyle.BackColor = Color.DeepSkyBlue
            .Columns("Mã Giáo Viên").Visible = False
        End With

        Dim dt As New DataTable()
        dt = PCGDTHEOLOPHOCBus.LayBangPhanCongLopHoc(txtMLHoc.Text)
        dtgvBangPhanCong.DataSource = dt
        With dtgvBangPhanCong
            .Columns("STT").Width = 35
            .Columns("STT").DisplayIndex = 0
            .Columns("STT").ReadOnly = True
            .AlternatingRowsDefaultCellStyle.ForeColor = Color.Red
            .Columns("STT").DefaultCellStyle.BackColor = Color.DeepSkyBlue
        End With
    End Sub

    Private Sub rdK10_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdK10.CheckedChanged
        If (rdK10.Checked = True) Then
            rdK11.Checked = False
            rdK12.Checked = False
            rdTatCa.Checked = False
            Dim lh As New LopHoc
            lh.makhoi = "k10"
            Dim dt As New DataTable()
            dt = PCGDTHEOLOPHOCBus.LayBangGiaoVien(lh.makhoi)
            dtgvDSGVPhanCong.DataSource = dt

            Dim dtLopHoc As New DataTable()
            dtLopHoc = LOPHOCBus.LayBangLopHoc(lh)
            cmbTenLopHoc.DataSource = dtLopHoc
            cmbTenLopHoc.DisplayMember = "TenLopHoc"
            cmbTenLopHoc.ValueMember = "MaLopHoc"
            Dim ma As String
            ma = cmbTenLopHoc.SelectedValue.ToString()
            txtMLHoc.Text = ma
        End If
    End Sub

    Private Sub rdK11_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdK11.CheckedChanged
        If (rdK11.Checked = True) Then
            rdK10.Checked = False
            rdK12.Checked = False
            rdTatCa.Checked = False
            Dim lh As New LopHoc
            lh.makhoi = "k11"
            Dim dt As New DataTable()
            dt = PCGDTHEOLOPHOCBus.LayBangGiaoVien(lh.makhoi)
            dtgvDSGVPhanCong.DataSource = dt

            Dim dtLopHoc As New DataTable()
            dtLopHoc = LOPHOCBus.LayBangLopHoc(lh)
            cmbTenLopHoc.DataSource = dtLopHoc
            cmbTenLopHoc.DisplayMember = "TenLopHoc"
            cmbTenLopHoc.ValueMember = "MaLopHoc"
        End If
    End Sub

    Private Sub rdK12_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdK12.CheckedChanged
        If (rdK12.Checked = True) Then
            rdK10.Checked = False
            rdK11.Checked = False
            rdTatCa.Checked = False
            Dim lh As New LopHoc
            lh.makhoi = "k12"
            Dim dt As New DataTable()
            dt = PCGDTHEOLOPHOCBus.LayBangGiaoVien(lh.makhoi)
            dtgvDSGVPhanCong.DataSource = dt

            Dim dtLopHoc As New DataTable()
            dtLopHoc = LOPHOCBus.LayBangLopHoc(lh)
            cmbTenLopHoc.DataSource = dtLopHoc
            cmbTenLopHoc.DisplayMember = "TenLopHoc"
            cmbTenLopHoc.ValueMember = "MaLopHoc"
        End If
    End Sub

    Private Sub rdTatCa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdTatCa.CheckedChanged
        If (rdTatCa.Checked = True) Then
            rdK10.Checked = False
            rdK11.Checked = False
            rdK12.Checked = False
            Dim dt2 As New DataTable()
            Dim gv As New GiaoVien
            'gv.magiaovien = txtMaGiaoVien.Text
            dt2 = GIAOVIENBus.LayBangGiaoVien()
            dtgvDSGVPhanCong.DataSource = dt2

            Dim dtLopHoc As New DataTable()
            dtLopHoc = LOPHOCBus.LayBangLopHoc()
            cmbTenLopHoc.DataSource = dtLopHoc
            cmbTenLopHoc.DisplayMember = "TenLopHoc"
            cmbTenLopHoc.ValueMember = "MaLopHoc"
        End If
    End Sub

    Private Sub cmbTenLopHoc_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTenLopHoc.SelectedIndexChanged
        Dim ma As String
        ma = cmbTenLopHoc.SelectedValue.ToString()
        txtMLHoc.Text = ma
    End Sub

    Private Sub txtMLHoc_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMLHoc.TextChanged
        Dim ma As String
        ma = txtMLHoc.Text
        If (rdK10.Checked = True) Then
            Dim lh As New LopHoc
            lh.makhoi = "k10"
            Dim dt2 As New DataTable()
            dt2 = PCGDTHEOLOPHOCBus.LayBangPhanCongLopHoc(ma)
            dtgvBangPhanCong.DataSource = dt2
        End If

        If (rdK11.Checked = True) Then
            Dim lh As New LopHoc
            lh.makhoi = "k11"
            Dim dt2 As New DataTable()
            dt2 = PCGDTHEOLOPHOCBus.LayBangPhanCongLopHoc(ma)
            dtgvBangPhanCong.DataSource = dt2
        End If

        If (rdK12.Checked = True) Then
            Dim lh As New LopHoc
            lh.makhoi = "k12"
            Dim dt2 As New DataTable()
            dt2 = PCGDTHEOLOPHOCBus.LayBangPhanCongLopHoc(ma)
            dtgvBangPhanCong.DataSource = dt2
        End If

        If (rdTatCa.Checked = True) Then
            Dim lh As New LopHoc
            Dim dt2 As New DataTable()
            dt2 = PCGDTHEOLOPHOCBus.LayBangPhanCongLopHoc(ma)
            dtgvBangPhanCong.DataSource = dt2
        End If

        Dim flag As Boolean = False
        Dim flag1 As Boolean = False
        Dim flag2 As Boolean = False
        Dim flag3 As Boolean = False
        Dim flag4 As Boolean = False
        Dim flag5 As Boolean = False
        Dim flag6 As Boolean = False
        Dim flag7 As Boolean = False
        Dim flag8 As Boolean = False
        Dim flag9 As Boolean = False
        Dim flag10 As Boolean = False
        Dim flag11 As Boolean = False
        Dim flag12 As Boolean = False
        Dim flag13 As Boolean = False
        Dim flag14 As Boolean = False
        Dim flag15 As Boolean = False
        Dim flag16 As Boolean = False
        Dim flag17 As Boolean = False
        Dim flag18 As Boolean = False
        Dim flag19 As Boolean = False

        cbAnh.Checked = False
        cbAnhNC1.Checked = False
        cbAnhNC2.Checked = False
        cbDaiLuong.Checked = False
        cbDia.Checked = False
        cbDiaC.Checked = False
        cbGDCD.Checked = False
        cbGiaiTich.Checked = False
        cbKTCN.Checked = False
        cbKTNN.Checked = False
        cbSHCN.Checked = False
        cbSHDC.Checked = False
        cbSinhNC1.Checked = False
        cbSinhNC2.Checked = False
        cbSu.Checked = False
        cbSuC.Checked = False
        cbTheDuc.Checked = False
        cbVan.Checked = False
        cbVanNC1.Checked = False
        cbVanNC2.Checked = False

        flag = PCGDTHEOLOPHOCBus.KTMonHoc("Anh", txtMLHoc.Text)
        flag1 = PCGDTHEOLOPHOCBus.KTMonHoc("Anh NC1", txtMLHoc.Text)
        flag2 = PCGDTHEOLOPHOCBus.KTMonHoc("Anh NC2", txtMLHoc.Text)
        flag3 = PCGDTHEOLOPHOCBus.KTMonHoc("Đại Lượng", txtMLHoc.Text)
        flag4 = PCGDTHEOLOPHOCBus.KTMonHoc("Địa", txtMLHoc.Text)
        flag5 = PCGDTHEOLOPHOCBus.KTMonHoc("Địa C", txtMLHoc.Text)
        flag6 = PCGDTHEOLOPHOCBus.KTMonHoc("GDCD", txtMLHoc.Text)
        flag7 = PCGDTHEOLOPHOCBus.KTMonHoc("Giải Tích", txtMLHoc.Text)
        flag8 = PCGDTHEOLOPHOCBus.KTMonHoc("KTCN", txtMLHoc.Text)
        flag9 = PCGDTHEOLOPHOCBus.KTMonHoc("KTNN", txtMLHoc.Text)
        flag10 = PCGDTHEOLOPHOCBus.KTMonHoc("SHCN ", txtMLHoc.Text)
        flag11 = PCGDTHEOLOPHOCBus.KTMonHoc("SHDC", txtMLHoc.Text)
        flag12 = PCGDTHEOLOPHOCBus.KTMonHoc("Sinh NC1", txtMLHoc.Text)
        flag13 = PCGDTHEOLOPHOCBus.KTMonHoc("Sinh NC2", txtMLHoc.Text)
        flag14 = PCGDTHEOLOPHOCBus.KTMonHoc("Sử", txtMLHoc.Text)
        flag15 = PCGDTHEOLOPHOCBus.KTMonHoc("Sử C", txtMLHoc.Text)
        flag16 = PCGDTHEOLOPHOCBus.KTMonHoc("Thể Dục", txtMLHoc.Text)
        flag17 = PCGDTHEOLOPHOCBus.KTMonHoc("Văn", txtMLHoc.Text)
        flag18 = PCGDTHEOLOPHOCBus.KTMonHoc("Văn NC1", txtMLHoc.Text)
        flag19 = PCGDTHEOLOPHOCBus.KTMonHoc("Văn NC2", txtMLHoc.Text)

        If (flag = True) Then
            cbAnh.Checked = True
        End If
        If (flag1 = True) Then
            cbAnhNC1.Checked = True
        End If
        If (flag2 = True) Then
            cbAnhNC2.Checked = True
        End If
        If (flag3 = True) Then
            cbDaiLuong.Checked = True
        End If
        If (flag4 = True) Then
            cbDia.Checked = True
        End If
        If (flag5 = True) Then
            cbDiaC.Checked = True
        End If
        If (flag6 = True) Then
            cbGDCD.Checked = True
        End If
        If (flag7 = True) Then
            cbGiaiTich.Checked = True
        End If
        If (flag8 = True) Then
            cbKTCN.Checked = True
        End If
        If (flag9 = True) Then
            cbKTNN.Checked = True
        End If
        If (flag10 = True) Then
            cbSHCN.Checked = True
        End If
        If (flag11 = True) Then
            cbSHDC.Checked = True
        End If
        If (flag12 = True) Then
            cbSinhNC1.Checked = True
        End If
        If (flag13 = True) Then
            cbSinhNC2.Checked = True
        End If
        If (flag14 = True) Then
            cbSu.Checked = True
        End If
        If (flag15 = True) Then
            cbSuC.Checked = True
        End If
        If (flag16 = True) Then
            cbTheDuc.Checked = True
        End If
        If (flag17 = True) Then
            cbVan.Checked = True
        End If
        If (flag18 = True) Then
            cbVanNC1.Checked = True
        End If
        If (flag19 = True) Then
            cbVanNC2.Checked = True
        End If

    End Sub

    Private Sub dtgvDSGVien_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgvDSGVien.SelectionChanged
        Dim rowInDex As Integer = dtgvDSGVien.CurrentRow.Index
        Dim maGV As String = dtgvDSGVien("Mã Giáo Viên", rowInDex).Value
        dtgvBangPhanCong.DataSource = PCGDTHEOLOPHOCBus.LayBangPhanCongTheoMaGV(maGV)
        ' Dim tengiaovien As String = dtgvDSGVien("Họ Tên Giáo Viên", rowInDex).Value
    End Sub

    Private Sub btnLopKeTruoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLopKeTruoc.Click
        Dim matruoc As String
        matruoc = PCGDTHEOLOPHOCBus.LayMaLHTruoc(cmbTenLopHoc.SelectedValue.ToString())
        txtMLHoc.Text = matruoc
        cmbTenLopHoc.SelectedValue = matruoc
       End Sub

    Private Sub btnLopTieptheo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLopTieptheo.Click
        Dim matieptheo As String
        matieptheo = PCGDTHEOLOPHOCBus.LayMaLHTiepTheo(cmbTenLopHoc.SelectedValue.ToString())
        txtMLHoc.Text = matieptheo
        cmbTenLopHoc.SelectedValue = matieptheo
    End Sub

    Private Sub btnXuatRaTapTin4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXuatRaTapTin4.Click
        Dim app As New Microsoft.Office.Interop.Excel.Application()
        app.Visible = False
        Dim workbooks As Microsoft.Office.Interop.Excel.Workbooks
        workbooks = app.Workbooks
        Dim book As Microsoft.Office.Interop.Excel._Workbook
        book = workbooks.Add(Type.Missing)
        Dim sheet As Microsoft.Office.Interop.Excel._Worksheet
        sheet = book.ActiveSheet

        Dim dt As DataTable
        dt = Me.dtgvBangPhanCong.DataSource
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
