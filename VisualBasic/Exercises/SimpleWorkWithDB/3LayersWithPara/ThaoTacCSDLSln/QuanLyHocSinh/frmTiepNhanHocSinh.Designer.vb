<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTiepNhanHocSinh
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtMa = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtTen = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtpNgaySinh = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtDiaChi = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmbLopHoc = New System.Windows.Forms.ComboBox
        Me.btnGhi = New System.Windows.Forms.Button
        Me.btnThoat = New System.Windows.Forms.Button
        Me.txtDTB = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.nudToan = New System.Windows.Forms.NumericUpDown
        Me.nudLy = New System.Windows.Forms.NumericUpDown
        Me.nudHoa = New System.Windows.Forms.NumericUpDown
        CType(Me.nudToan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudLy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudHoa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(0, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(22, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ma"
        '
        'txtMa
        '
        Me.txtMa.Location = New System.Drawing.Point(58, 2)
        Me.txtMa.Name = "txtMa"
        Me.txtMa.ReadOnly = True
        Me.txtMa.Size = New System.Drawing.Size(200, 20)
        Me.txtMa.TabIndex = 1
        Me.txtMa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(0, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Ten"
        '
        'txtTen
        '
        Me.txtTen.Location = New System.Drawing.Point(58, 29)
        Me.txtTen.Name = "txtTen"
        Me.txtTen.Size = New System.Drawing.Size(200, 20)
        Me.txtTen.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(0, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Ngay sinh"
        '
        'dtpNgaySinh
        '
        Me.dtpNgaySinh.CustomFormat = "dd/MM/yyyy"
        Me.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpNgaySinh.Location = New System.Drawing.Point(58, 59)
        Me.dtpNgaySinh.Name = "dtpNgaySinh"
        Me.dtpNgaySinh.Size = New System.Drawing.Size(200, 20)
        Me.dtpNgaySinh.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(0, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Dia chi"
        '
        'txtDiaChi
        '
        Me.txtDiaChi.Location = New System.Drawing.Point(58, 85)
        Me.txtDiaChi.Name = "txtDiaChi"
        Me.txtDiaChi.Size = New System.Drawing.Size(200, 20)
        Me.txtDiaChi.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(1, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Toan"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(1, 146)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(18, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Ly"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(1, 175)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(27, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Hoa"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(1, 235)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Ten lop"
        '
        'cmbLopHoc
        '
        Me.cmbLopHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLopHoc.FormattingEnabled = True
        Me.cmbLopHoc.Location = New System.Drawing.Point(58, 227)
        Me.cmbLopHoc.Name = "cmbLopHoc"
        Me.cmbLopHoc.Size = New System.Drawing.Size(200, 21)
        Me.cmbLopHoc.TabIndex = 17
        '
        'btnGhi
        '
        Me.btnGhi.Location = New System.Drawing.Point(4, 275)
        Me.btnGhi.Name = "btnGhi"
        Me.btnGhi.Size = New System.Drawing.Size(75, 23)
        Me.btnGhi.TabIndex = 18
        Me.btnGhi.Text = "&Ghi"
        Me.btnGhi.UseVisualStyleBackColor = True
        '
        'btnThoat
        '
        Me.btnThoat.Location = New System.Drawing.Point(85, 275)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(75, 23)
        Me.btnThoat.TabIndex = 19
        Me.btnThoat.Text = "&Thoat"
        Me.btnThoat.UseVisualStyleBackColor = True
        '
        'txtDTB
        '
        Me.txtDTB.Location = New System.Drawing.Point(58, 201)
        Me.txtDTB.Name = "txtDTB"
        Me.txtDTB.ReadOnly = True
        Me.txtDTB.Size = New System.Drawing.Size(200, 20)
        Me.txtDTB.TabIndex = 15
        Me.txtDTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(1, 208)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "DTB"
        '
        'nudToan
        '
        Me.nudToan.DecimalPlaces = 2
        Me.nudToan.Location = New System.Drawing.Point(58, 114)
        Me.nudToan.Name = "nudToan"
        Me.nudToan.Size = New System.Drawing.Size(200, 20)
        Me.nudToan.TabIndex = 20
        '
        'nudLy
        '
        Me.nudLy.DecimalPlaces = 2
        Me.nudLy.Location = New System.Drawing.Point(58, 144)
        Me.nudLy.Name = "nudLy"
        Me.nudLy.Size = New System.Drawing.Size(200, 20)
        Me.nudLy.TabIndex = 21
        '
        'nudHoa
        '
        Me.nudHoa.DecimalPlaces = 2
        Me.nudHoa.Location = New System.Drawing.Point(58, 173)
        Me.nudHoa.Name = "nudHoa"
        Me.nudHoa.Size = New System.Drawing.Size(200, 20)
        Me.nudHoa.TabIndex = 22
        '
        'frmTiepNhanHocSinh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 310)
        Me.Controls.Add(Me.nudHoa)
        Me.Controls.Add(Me.nudLy)
        Me.Controls.Add(Me.nudToan)
        Me.Controls.Add(Me.btnThoat)
        Me.Controls.Add(Me.btnGhi)
        Me.Controls.Add(Me.cmbLopHoc)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtDTB)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtDiaChi)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtpNgaySinh)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtTen)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtMa)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmTiepNhanHocSinh"
        Me.Text = "Tiep Nhan Hoc Sinh"
        CType(Me.nudToan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudLy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudHoa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMa As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTen As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpNgaySinh As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDiaChi As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbLopHoc As System.Windows.Forms.ComboBox
    Friend WithEvents btnGhi As System.Windows.Forms.Button
    Friend WithEvents btnThoat As System.Windows.Forms.Button
    Friend WithEvents txtDTB As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents nudToan As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudLy As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudHoa As System.Windows.Forms.NumericUpDown

End Class
