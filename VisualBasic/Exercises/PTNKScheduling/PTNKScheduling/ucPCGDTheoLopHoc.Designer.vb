<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucPCGDTheoLopHoc
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.dtgvDSGVien = New System.Windows.Forms.DataGridView
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.cmbTenLopHoc = New System.Windows.Forms.ComboBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.rdTatCa = New System.Windows.Forms.RadioButton
        Me.rdK12 = New System.Windows.Forms.RadioButton
        Me.rdK11 = New System.Windows.Forms.RadioButton
        Me.rdK10 = New System.Windows.Forms.RadioButton
        Me.txtMLHoc = New System.Windows.Forms.TextBox
        Me.lblMaLopHoc4 = New System.Windows.Forms.Label
        Me.lblTenLopHoc4 = New System.Windows.Forms.Label
        Me.lblKhoi = New System.Windows.Forms.Label
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.cbGiaiTich = New System.Windows.Forms.CheckBox
        Me.cbDaiLuong = New System.Windows.Forms.CheckBox
        Me.cbSHDC = New System.Windows.Forms.CheckBox
        Me.cbSHCN = New System.Windows.Forms.CheckBox
        Me.cbTheDuc = New System.Windows.Forms.CheckBox
        Me.cbKTCN = New System.Windows.Forms.CheckBox
        Me.cbKTNN = New System.Windows.Forms.CheckBox
        Me.cbGDCD = New System.Windows.Forms.CheckBox
        Me.cbDiaC = New System.Windows.Forms.CheckBox
        Me.cbDia = New System.Windows.Forms.CheckBox
        Me.cbSuC = New System.Windows.Forms.CheckBox
        Me.cbSu = New System.Windows.Forms.CheckBox
        Me.cbVanNC2 = New System.Windows.Forms.CheckBox
        Me.cbVanNC1 = New System.Windows.Forms.CheckBox
        Me.cbVan = New System.Windows.Forms.CheckBox
        Me.cbAnhNC2 = New System.Windows.Forms.CheckBox
        Me.cbAnhNC1 = New System.Windows.Forms.CheckBox
        Me.cbAnh = New System.Windows.Forms.CheckBox
        Me.cbSinhNC2 = New System.Windows.Forms.CheckBox
        Me.cbSinhNC1 = New System.Windows.Forms.CheckBox
        Me.btnCapNhatDuLieu4 = New System.Windows.Forms.Button
        Me.btnXuatRaTapTin4 = New System.Windows.Forms.Button
        Me.btnLopKeTruoc = New System.Windows.Forms.Button
        Me.btnLopTieptheo = New System.Windows.Forms.Button
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.dtgvBangPhanCong = New System.Windows.Forms.DataGridView
        Me.GroupBox4.SuspendLayout()
        CType(Me.dtgvDSGVien, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.dtgvBangPhanCong, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.dtgvDSGVien)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox4.Location = New System.Drawing.Point(467, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(320, 468)
        Me.GroupBox4.TabIndex = 71
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Danh Sách Giáo Viên"
        Me.GroupBox4.UseWaitCursor = True
        '
        'dtgvDSGVien
        '
        Me.dtgvDSGVien.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtgvDSGVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgvDSGVien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgvDSGVien.Location = New System.Drawing.Point(3, 16)
        Me.dtgvDSGVien.Name = "dtgvDSGVien"
        Me.dtgvDSGVien.Size = New System.Drawing.Size(314, 449)
        Me.dtgvDSGVien.TabIndex = 1
        Me.dtgvDSGVien.UseWaitCursor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.cmbTenLopHoc)
        Me.GroupBox7.Controls.Add(Me.Panel2)
        Me.GroupBox7.Controls.Add(Me.txtMLHoc)
        Me.GroupBox7.Controls.Add(Me.lblMaLopHoc4)
        Me.GroupBox7.Controls.Add(Me.lblTenLopHoc4)
        Me.GroupBox7.Controls.Add(Me.lblKhoi)
        Me.GroupBox7.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox7.Location = New System.Drawing.Point(20, 12)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(441, 99)
        Me.GroupBox7.TabIndex = 64
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Thông Tin Lớp Học"
        Me.GroupBox7.UseWaitCursor = True
        '
        'cmbTenLopHoc
        '
        Me.cmbTenLopHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTenLopHoc.FormattingEnabled = True
        Me.cmbTenLopHoc.Location = New System.Drawing.Point(109, 47)
        Me.cmbTenLopHoc.Name = "cmbTenLopHoc"
        Me.cmbTenLopHoc.Size = New System.Drawing.Size(236, 21)
        Me.cmbTenLopHoc.TabIndex = 8
        Me.cmbTenLopHoc.UseWaitCursor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rdTatCa)
        Me.Panel2.Controls.Add(Me.rdK12)
        Me.Panel2.Controls.Add(Me.rdK11)
        Me.Panel2.Controls.Add(Me.rdK10)
        Me.Panel2.Location = New System.Drawing.Point(109, 19)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(236, 26)
        Me.Panel2.TabIndex = 7
        Me.Panel2.UseWaitCursor = True
        '
        'rdTatCa
        '
        Me.rdTatCa.AutoSize = True
        Me.rdTatCa.Location = New System.Drawing.Point(135, 3)
        Me.rdTatCa.Name = "rdTatCa"
        Me.rdTatCa.Size = New System.Drawing.Size(56, 17)
        Me.rdTatCa.TabIndex = 2
        Me.rdTatCa.Text = "Tất cả"
        Me.rdTatCa.UseVisualStyleBackColor = True
        Me.rdTatCa.UseWaitCursor = True
        '
        'rdK12
        '
        Me.rdK12.AutoSize = True
        Me.rdK12.Location = New System.Drawing.Point(92, 4)
        Me.rdK12.Name = "rdK12"
        Me.rdK12.Size = New System.Drawing.Size(37, 17)
        Me.rdK12.TabIndex = 1
        Me.rdK12.Text = "12"
        Me.rdK12.UseVisualStyleBackColor = True
        Me.rdK12.UseWaitCursor = True
        '
        'rdK11
        '
        Me.rdK11.AutoSize = True
        Me.rdK11.Location = New System.Drawing.Point(47, 3)
        Me.rdK11.Name = "rdK11"
        Me.rdK11.Size = New System.Drawing.Size(37, 17)
        Me.rdK11.TabIndex = 0
        Me.rdK11.Text = "11"
        Me.rdK11.UseVisualStyleBackColor = True
        Me.rdK11.UseWaitCursor = True
        '
        'rdK10
        '
        Me.rdK10.AutoSize = True
        Me.rdK10.Location = New System.Drawing.Point(4, 4)
        Me.rdK10.Name = "rdK10"
        Me.rdK10.Size = New System.Drawing.Size(37, 17)
        Me.rdK10.TabIndex = 0
        Me.rdK10.Text = "10"
        Me.rdK10.UseVisualStyleBackColor = True
        Me.rdK10.UseWaitCursor = True
        '
        'txtMLHoc
        '
        Me.txtMLHoc.Location = New System.Drawing.Point(109, 74)
        Me.txtMLHoc.Name = "txtMLHoc"
        Me.txtMLHoc.Size = New System.Drawing.Size(236, 20)
        Me.txtMLHoc.TabIndex = 5
        Me.txtMLHoc.UseWaitCursor = True
        '
        'lblMaLopHoc4
        '
        Me.lblMaLopHoc4.AutoSize = True
        Me.lblMaLopHoc4.Location = New System.Drawing.Point(10, 77)
        Me.lblMaLopHoc4.Name = "lblMaLopHoc4"
        Me.lblMaLopHoc4.Size = New System.Drawing.Size(66, 13)
        Me.lblMaLopHoc4.TabIndex = 4
        Me.lblMaLopHoc4.Text = "Mã Lớp Học"
        Me.lblMaLopHoc4.UseWaitCursor = True
        '
        'lblTenLopHoc4
        '
        Me.lblTenLopHoc4.AutoSize = True
        Me.lblTenLopHoc4.Location = New System.Drawing.Point(6, 50)
        Me.lblTenLopHoc4.Name = "lblTenLopHoc4"
        Me.lblTenLopHoc4.Size = New System.Drawing.Size(70, 13)
        Me.lblTenLopHoc4.TabIndex = 2
        Me.lblTenLopHoc4.Text = "Tên Lớp Học"
        Me.lblTenLopHoc4.UseWaitCursor = True
        '
        'lblKhoi
        '
        Me.lblKhoi.AutoSize = True
        Me.lblKhoi.Location = New System.Drawing.Point(9, 27)
        Me.lblKhoi.Name = "lblKhoi"
        Me.lblKhoi.Size = New System.Drawing.Size(28, 13)
        Me.lblKhoi.TabIndex = 1
        Me.lblKhoi.Text = "Khối"
        Me.lblKhoi.UseWaitCursor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.cbGiaiTich)
        Me.GroupBox8.Controls.Add(Me.cbDaiLuong)
        Me.GroupBox8.Controls.Add(Me.cbSHDC)
        Me.GroupBox8.Controls.Add(Me.cbSHCN)
        Me.GroupBox8.Controls.Add(Me.cbTheDuc)
        Me.GroupBox8.Controls.Add(Me.cbKTCN)
        Me.GroupBox8.Controls.Add(Me.cbKTNN)
        Me.GroupBox8.Controls.Add(Me.cbGDCD)
        Me.GroupBox8.Controls.Add(Me.cbDiaC)
        Me.GroupBox8.Controls.Add(Me.cbDia)
        Me.GroupBox8.Controls.Add(Me.cbSuC)
        Me.GroupBox8.Controls.Add(Me.cbSu)
        Me.GroupBox8.Controls.Add(Me.cbVanNC2)
        Me.GroupBox8.Controls.Add(Me.cbVanNC1)
        Me.GroupBox8.Controls.Add(Me.cbVan)
        Me.GroupBox8.Controls.Add(Me.cbAnhNC2)
        Me.GroupBox8.Controls.Add(Me.cbAnhNC1)
        Me.GroupBox8.Controls.Add(Me.cbAnh)
        Me.GroupBox8.Controls.Add(Me.cbSinhNC2)
        Me.GroupBox8.Controls.Add(Me.cbSinhNC1)
        Me.GroupBox8.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox8.Location = New System.Drawing.Point(20, 117)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(441, 116)
        Me.GroupBox8.TabIndex = 70
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Danh Sách Môn Học"
        Me.GroupBox8.UseWaitCursor = True
        '
        'cbGiaiTich
        '
        Me.cbGiaiTich.AutoSize = True
        Me.cbGiaiTich.Location = New System.Drawing.Point(283, 88)
        Me.cbGiaiTich.Name = "cbGiaiTich"
        Me.cbGiaiTich.Size = New System.Drawing.Size(70, 17)
        Me.cbGiaiTich.TabIndex = 19
        Me.cbGiaiTich.Text = "Giải Tích"
        Me.cbGiaiTich.UseVisualStyleBackColor = True
        Me.cbGiaiTich.UseWaitCursor = True
        '
        'cbDaiLuong
        '
        Me.cbDaiLuong.AutoSize = True
        Me.cbDaiLuong.Location = New System.Drawing.Point(283, 65)
        Me.cbDaiLuong.Name = "cbDaiLuong"
        Me.cbDaiLuong.Size = New System.Drawing.Size(75, 17)
        Me.cbDaiLuong.TabIndex = 18
        Me.cbDaiLuong.Text = "Đại Lượng"
        Me.cbDaiLuong.UseVisualStyleBackColor = True
        Me.cbDaiLuong.UseWaitCursor = True
        '
        'cbSHDC
        '
        Me.cbSHDC.AutoSize = True
        Me.cbSHDC.Location = New System.Drawing.Point(283, 42)
        Me.cbSHDC.Name = "cbSHDC"
        Me.cbSHDC.Size = New System.Drawing.Size(56, 17)
        Me.cbSHDC.TabIndex = 17
        Me.cbSHDC.Text = "SHDC"
        Me.cbSHDC.UseVisualStyleBackColor = True
        Me.cbSHDC.UseWaitCursor = True
        '
        'cbSHCN
        '
        Me.cbSHCN.AutoSize = True
        Me.cbSHCN.Location = New System.Drawing.Point(283, 19)
        Me.cbSHCN.Name = "cbSHCN"
        Me.cbSHCN.Size = New System.Drawing.Size(56, 17)
        Me.cbSHCN.TabIndex = 16
        Me.cbSHCN.Text = "SHCN"
        Me.cbSHCN.UseVisualStyleBackColor = True
        Me.cbSHCN.UseWaitCursor = True
        '
        'cbTheDuc
        '
        Me.cbTheDuc.AutoSize = True
        Me.cbTheDuc.Location = New System.Drawing.Point(213, 88)
        Me.cbTheDuc.Name = "cbTheDuc"
        Me.cbTheDuc.Size = New System.Drawing.Size(68, 17)
        Me.cbTheDuc.TabIndex = 15
        Me.cbTheDuc.Text = "Thể Dục"
        Me.cbTheDuc.UseVisualStyleBackColor = True
        Me.cbTheDuc.UseWaitCursor = True
        '
        'cbKTCN
        '
        Me.cbKTCN.AutoSize = True
        Me.cbKTCN.Location = New System.Drawing.Point(213, 65)
        Me.cbKTCN.Name = "cbKTCN"
        Me.cbKTCN.Size = New System.Drawing.Size(55, 17)
        Me.cbKTCN.TabIndex = 14
        Me.cbKTCN.Text = "KTCN"
        Me.cbKTCN.UseVisualStyleBackColor = True
        Me.cbKTCN.UseWaitCursor = True
        '
        'cbKTNN
        '
        Me.cbKTNN.AutoSize = True
        Me.cbKTNN.Location = New System.Drawing.Point(213, 42)
        Me.cbKTNN.Name = "cbKTNN"
        Me.cbKTNN.Size = New System.Drawing.Size(56, 17)
        Me.cbKTNN.TabIndex = 13
        Me.cbKTNN.Text = "KTNN"
        Me.cbKTNN.UseVisualStyleBackColor = True
        Me.cbKTNN.UseWaitCursor = True
        '
        'cbGDCD
        '
        Me.cbGDCD.AutoSize = True
        Me.cbGDCD.Location = New System.Drawing.Point(214, 19)
        Me.cbGDCD.Name = "cbGDCD"
        Me.cbGDCD.Size = New System.Drawing.Size(57, 17)
        Me.cbGDCD.TabIndex = 12
        Me.cbGDCD.Text = "GDCD"
        Me.cbGDCD.UseVisualStyleBackColor = True
        Me.cbGDCD.UseWaitCursor = True
        '
        'cbDiaC
        '
        Me.cbDiaC.AutoSize = True
        Me.cbDiaC.Location = New System.Drawing.Point(158, 88)
        Me.cbDiaC.Name = "cbDiaC"
        Me.cbDiaC.Size = New System.Drawing.Size(52, 17)
        Me.cbDiaC.TabIndex = 11
        Me.cbDiaC.Text = "Địa C"
        Me.cbDiaC.UseVisualStyleBackColor = True
        Me.cbDiaC.UseWaitCursor = True
        '
        'cbDia
        '
        Me.cbDia.AutoSize = True
        Me.cbDia.Location = New System.Drawing.Point(158, 65)
        Me.cbDia.Name = "cbDia"
        Me.cbDia.Size = New System.Drawing.Size(42, 17)
        Me.cbDia.TabIndex = 10
        Me.cbDia.Text = "Địa"
        Me.cbDia.UseVisualStyleBackColor = True
        Me.cbDia.UseWaitCursor = True
        '
        'cbSuC
        '
        Me.cbSuC.AutoSize = True
        Me.cbSuC.Location = New System.Drawing.Point(158, 42)
        Me.cbSuC.Name = "cbSuC"
        Me.cbSuC.Size = New System.Drawing.Size(49, 17)
        Me.cbSuC.TabIndex = 9
        Me.cbSuC.Text = "Sử C"
        Me.cbSuC.UseVisualStyleBackColor = True
        Me.cbSuC.UseWaitCursor = True
        '
        'cbSu
        '
        Me.cbSu.AutoSize = True
        Me.cbSu.Location = New System.Drawing.Point(158, 19)
        Me.cbSu.Name = "cbSu"
        Me.cbSu.Size = New System.Drawing.Size(39, 17)
        Me.cbSu.TabIndex = 8
        Me.cbSu.Text = "Sử"
        Me.cbSu.UseVisualStyleBackColor = True
        Me.cbSu.UseWaitCursor = True
        '
        'cbVanNC2
        '
        Me.cbVanNC2.AutoSize = True
        Me.cbVanNC2.Location = New System.Drawing.Point(83, 88)
        Me.cbVanNC2.Name = "cbVanNC2"
        Me.cbVanNC2.Size = New System.Drawing.Size(69, 17)
        Me.cbVanNC2.TabIndex = 7
        Me.cbVanNC2.Text = "Văn NC2"
        Me.cbVanNC2.UseVisualStyleBackColor = True
        Me.cbVanNC2.UseWaitCursor = True
        '
        'cbVanNC1
        '
        Me.cbVanNC1.AutoSize = True
        Me.cbVanNC1.Location = New System.Drawing.Point(83, 65)
        Me.cbVanNC1.Name = "cbVanNC1"
        Me.cbVanNC1.Size = New System.Drawing.Size(69, 17)
        Me.cbVanNC1.TabIndex = 6
        Me.cbVanNC1.Text = "Văn NC1"
        Me.cbVanNC1.UseVisualStyleBackColor = True
        Me.cbVanNC1.UseWaitCursor = True
        '
        'cbVan
        '
        Me.cbVan.AutoSize = True
        Me.cbVan.Location = New System.Drawing.Point(83, 42)
        Me.cbVan.Name = "cbVan"
        Me.cbVan.Size = New System.Drawing.Size(45, 17)
        Me.cbVan.TabIndex = 5
        Me.cbVan.Text = "Văn"
        Me.cbVan.UseVisualStyleBackColor = True
        Me.cbVan.UseWaitCursor = True
        '
        'cbAnhNC2
        '
        Me.cbAnhNC2.AutoSize = True
        Me.cbAnhNC2.Location = New System.Drawing.Point(83, 19)
        Me.cbAnhNC2.Name = "cbAnhNC2"
        Me.cbAnhNC2.Size = New System.Drawing.Size(69, 17)
        Me.cbAnhNC2.TabIndex = 4
        Me.cbAnhNC2.Text = "Anh NC2"
        Me.cbAnhNC2.UseVisualStyleBackColor = True
        Me.cbAnhNC2.UseWaitCursor = True
        '
        'cbAnhNC1
        '
        Me.cbAnhNC1.AutoSize = True
        Me.cbAnhNC1.Location = New System.Drawing.Point(6, 88)
        Me.cbAnhNC1.Name = "cbAnhNC1"
        Me.cbAnhNC1.Size = New System.Drawing.Size(69, 17)
        Me.cbAnhNC1.TabIndex = 3
        Me.cbAnhNC1.Text = "Anh NC1"
        Me.cbAnhNC1.UseVisualStyleBackColor = True
        Me.cbAnhNC1.UseWaitCursor = True
        '
        'cbAnh
        '
        Me.cbAnh.AutoSize = True
        Me.cbAnh.Location = New System.Drawing.Point(6, 65)
        Me.cbAnh.Name = "cbAnh"
        Me.cbAnh.Size = New System.Drawing.Size(48, 17)
        Me.cbAnh.TabIndex = 2
        Me.cbAnh.Text = "Anh "
        Me.cbAnh.UseVisualStyleBackColor = True
        Me.cbAnh.UseWaitCursor = True
        '
        'cbSinhNC2
        '
        Me.cbSinhNC2.AutoSize = True
        Me.cbSinhNC2.Location = New System.Drawing.Point(6, 42)
        Me.cbSinhNC2.Name = "cbSinhNC2"
        Me.cbSinhNC2.Size = New System.Drawing.Size(71, 17)
        Me.cbSinhNC2.TabIndex = 1
        Me.cbSinhNC2.Text = "Sinh NC2"
        Me.cbSinhNC2.UseVisualStyleBackColor = True
        Me.cbSinhNC2.UseWaitCursor = True
        '
        'cbSinhNC1
        '
        Me.cbSinhNC1.AutoSize = True
        Me.cbSinhNC1.Location = New System.Drawing.Point(6, 19)
        Me.cbSinhNC1.Name = "cbSinhNC1"
        Me.cbSinhNC1.Size = New System.Drawing.Size(71, 17)
        Me.cbSinhNC1.TabIndex = 0
        Me.cbSinhNC1.Text = "Sinh NC1"
        Me.cbSinhNC1.UseVisualStyleBackColor = True
        Me.cbSinhNC1.UseWaitCursor = True
        '
        'btnCapNhatDuLieu4
        '
        Me.btnCapNhatDuLieu4.ForeColor = System.Drawing.Color.Blue
        Me.btnCapNhatDuLieu4.Location = New System.Drawing.Point(470, 498)
        Me.btnCapNhatDuLieu4.Name = "btnCapNhatDuLieu4"
        Me.btnCapNhatDuLieu4.Size = New System.Drawing.Size(113, 23)
        Me.btnCapNhatDuLieu4.TabIndex = 68
        Me.btnCapNhatDuLieu4.Text = "Cập Nhật Dữ Liệu"
        Me.btnCapNhatDuLieu4.UseVisualStyleBackColor = True
        Me.btnCapNhatDuLieu4.UseWaitCursor = True
        '
        'btnXuatRaTapTin4
        '
        Me.btnXuatRaTapTin4.ForeColor = System.Drawing.Color.Blue
        Me.btnXuatRaTapTin4.Location = New System.Drawing.Point(657, 498)
        Me.btnXuatRaTapTin4.Name = "btnXuatRaTapTin4"
        Me.btnXuatRaTapTin4.Size = New System.Drawing.Size(88, 23)
        Me.btnXuatRaTapTin4.TabIndex = 69
        Me.btnXuatRaTapTin4.Text = "Xuất ra tập tin"
        Me.btnXuatRaTapTin4.UseVisualStyleBackColor = True
        Me.btnXuatRaTapTin4.UseWaitCursor = True
        '
        'btnLopKeTruoc
        '
        Me.btnLopKeTruoc.ForeColor = System.Drawing.Color.Blue
        Me.btnLopKeTruoc.Location = New System.Drawing.Point(77, 498)
        Me.btnLopKeTruoc.Name = "btnLopKeTruoc"
        Me.btnLopKeTruoc.Size = New System.Drawing.Size(101, 23)
        Me.btnLopKeTruoc.TabIndex = 66
        Me.btnLopKeTruoc.Text = "Lớp Kế Trước"
        Me.btnLopKeTruoc.UseVisualStyleBackColor = True
        Me.btnLopKeTruoc.UseWaitCursor = True
        '
        'btnLopTieptheo
        '
        Me.btnLopTieptheo.ForeColor = System.Drawing.Color.Blue
        Me.btnLopTieptheo.Location = New System.Drawing.Point(282, 498)
        Me.btnLopTieptheo.Name = "btnLopTieptheo"
        Me.btnLopTieptheo.Size = New System.Drawing.Size(93, 23)
        Me.btnLopTieptheo.TabIndex = 67
        Me.btnLopTieptheo.Text = "Lớp Tiếp Theo"
        Me.btnLopTieptheo.UseVisualStyleBackColor = True
        Me.btnLopTieptheo.UseWaitCursor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.dtgvBangPhanCong)
        Me.GroupBox6.Location = New System.Drawing.Point(20, 239)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(441, 241)
        Me.GroupBox6.TabIndex = 65
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Bảng Phân Công"
        Me.GroupBox6.UseWaitCursor = True
        '
        'dtgvBangPhanCong
        '
        Me.dtgvBangPhanCong.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtgvBangPhanCong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgvBangPhanCong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgvBangPhanCong.Location = New System.Drawing.Point(3, 16)
        Me.dtgvBangPhanCong.Name = "dtgvBangPhanCong"
        Me.dtgvBangPhanCong.Size = New System.Drawing.Size(435, 222)
        Me.dtgvBangPhanCong.TabIndex = 0
        Me.dtgvBangPhanCong.UseWaitCursor = True
        '
        'ucPCGDTheoLopHoc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.btnCapNhatDuLieu4)
        Me.Controls.Add(Me.btnXuatRaTapTin4)
        Me.Controls.Add(Me.btnLopKeTruoc)
        Me.Controls.Add(Me.btnLopTieptheo)
        Me.Controls.Add(Me.GroupBox6)
        Me.Name = "ucPCGDTheoLopHoc"
        Me.Size = New System.Drawing.Size(807, 532)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.dtgvDSGVien, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.dtgvBangPhanCong, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents dtgvDSGVien As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbTenLopHoc As System.Windows.Forms.ComboBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rdTatCa As System.Windows.Forms.RadioButton
    Friend WithEvents rdK12 As System.Windows.Forms.RadioButton
    Friend WithEvents rdK11 As System.Windows.Forms.RadioButton
    Friend WithEvents rdK10 As System.Windows.Forms.RadioButton
    Friend WithEvents txtMLHoc As System.Windows.Forms.TextBox
    Friend WithEvents lblMaLopHoc4 As System.Windows.Forms.Label
    Friend WithEvents lblTenLopHoc4 As System.Windows.Forms.Label
    Friend WithEvents lblKhoi As System.Windows.Forms.Label
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents cbGiaiTich As System.Windows.Forms.CheckBox
    Friend WithEvents cbDaiLuong As System.Windows.Forms.CheckBox
    Friend WithEvents cbSHDC As System.Windows.Forms.CheckBox
    Friend WithEvents cbSHCN As System.Windows.Forms.CheckBox
    Friend WithEvents cbTheDuc As System.Windows.Forms.CheckBox
    Friend WithEvents cbKTCN As System.Windows.Forms.CheckBox
    Friend WithEvents cbKTNN As System.Windows.Forms.CheckBox
    Friend WithEvents cbGDCD As System.Windows.Forms.CheckBox
    Friend WithEvents cbDiaC As System.Windows.Forms.CheckBox
    Friend WithEvents cbDia As System.Windows.Forms.CheckBox
    Friend WithEvents cbSuC As System.Windows.Forms.CheckBox
    Friend WithEvents cbSu As System.Windows.Forms.CheckBox
    Friend WithEvents cbVanNC2 As System.Windows.Forms.CheckBox
    Friend WithEvents cbVanNC1 As System.Windows.Forms.CheckBox
    Friend WithEvents cbVan As System.Windows.Forms.CheckBox
    Friend WithEvents cbAnhNC2 As System.Windows.Forms.CheckBox
    Friend WithEvents cbAnhNC1 As System.Windows.Forms.CheckBox
    Friend WithEvents cbAnh As System.Windows.Forms.CheckBox
    Friend WithEvents cbSinhNC2 As System.Windows.Forms.CheckBox
    Friend WithEvents cbSinhNC1 As System.Windows.Forms.CheckBox
    Friend WithEvents btnCapNhatDuLieu4 As System.Windows.Forms.Button
    Friend WithEvents btnXuatRaTapTin4 As System.Windows.Forms.Button
    Friend WithEvents btnLopKeTruoc As System.Windows.Forms.Button
    Friend WithEvents btnLopTieptheo As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents dtgvBangPhanCong As System.Windows.Forms.DataGridView

End Class
