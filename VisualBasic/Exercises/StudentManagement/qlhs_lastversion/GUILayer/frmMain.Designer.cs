namespace Do_An_Cong_Ty
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radTiepNhanHocSinh = new System.Windows.Forms.RadioButton();
            this.radDanhSachLop = new System.Windows.Forms.RadioButton();
            this.radThayDoiMatKhau = new System.Windows.Forms.RadioButton();
            this.btnDongY = new System.Windows.Forms.Button();
            this.btnHuyBo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radTimKiemHocSinh = new System.Windows.Forms.RadioButton();
            this.radBaoCaoTongKet = new System.Windows.Forms.RadioButton();
            this.radThayĐoiQuyDinh = new System.Windows.Forms.RadioButton();
            this.radNhapDiem = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.họcSinhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiếpNhậnHọcSinhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhậpĐiểmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lớpHọcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaLớpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmLớpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.danhSáchLớpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoTheoMônToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoTheoHọcKỳToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmNhânViênQuảnLýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaNhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thayĐổiQuyĐịnhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đổiPassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.howToUseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutUsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sửaThôngTinHọcSinhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaThôngTinHọcSinhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radTiepNhanHocSinh
            // 
            this.radTiepNhanHocSinh.AutoSize = true;
            this.radTiepNhanHocSinh.Location = new System.Drawing.Point(29, 135);
            this.radTiepNhanHocSinh.Name = "radTiepNhanHocSinh";
            this.radTiepNhanHocSinh.Size = new System.Drawing.Size(116, 17);
            this.radTiepNhanHocSinh.TabIndex = 4;
            this.radTiepNhanHocSinh.TabStop = true;
            this.radTiepNhanHocSinh.Text = "Tiếp nhận học sinh";
            this.radTiepNhanHocSinh.UseVisualStyleBackColor = true;
            this.radTiepNhanHocSinh.CheckedChanged += new System.EventHandler(this.radThongTinHocSinh_CheckedChanged);
            // 
            // radDanhSachLop
            // 
            this.radDanhSachLop.AutoSize = true;
            this.radDanhSachLop.Location = new System.Drawing.Point(29, 72);
            this.radDanhSachLop.Name = "radDanhSachLop";
            this.radDanhSachLop.Size = new System.Drawing.Size(94, 17);
            this.radDanhSachLop.TabIndex = 2;
            this.radDanhSachLop.TabStop = true;
            this.radDanhSachLop.Text = "Danh sách lớp";
            this.radDanhSachLop.UseVisualStyleBackColor = true;
            this.radDanhSachLop.CheckedChanged += new System.EventHandler(this.radThongTinVeDiem_CheckedChanged);
            // 
            // radThayDoiMatKhau
            // 
            this.radThayDoiMatKhau.AutoSize = true;
            this.radThayDoiMatKhau.Location = new System.Drawing.Point(29, 41);
            this.radThayDoiMatKhau.Name = "radThayDoiMatKhau";
            this.radThayDoiMatKhau.Size = new System.Drawing.Size(114, 17);
            this.radThayDoiMatKhau.TabIndex = 1;
            this.radThayDoiMatKhau.TabStop = true;
            this.radThayDoiMatKhau.Text = "Thay đổi mật khẩu";
            this.radThayDoiMatKhau.UseVisualStyleBackColor = true;
            this.radThayDoiMatKhau.CheckedChanged += new System.EventHandler(this.radThayDoiMatKhau_CheckedChanged);
            // 
            // btnDongY
            // 
            this.btnDongY.Location = new System.Drawing.Point(178, 16);
            this.btnDongY.Name = "btnDongY";
            this.btnDongY.Size = new System.Drawing.Size(75, 23);
            this.btnDongY.TabIndex = 0;
            this.btnDongY.Text = "Đồng Ý";
            this.btnDongY.UseVisualStyleBackColor = true;
            this.btnDongY.Click += new System.EventHandler(this.btnDongY_Click);
            // 
            // btnHuyBo
            // 
            this.btnHuyBo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuyBo.Location = new System.Drawing.Point(289, 16);
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(75, 23);
            this.btnHuyBo.TabIndex = 1;
            this.btnHuyBo.Text = "Hủy Bỏ";
            this.btnHuyBo.UseVisualStyleBackColor = true;
            this.btnHuyBo.Click += new System.EventHandler(this.btnHuyBo_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnHuyBo);
            this.panel1.Controls.Add(this.btnDongY);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 291);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(542, 55);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::Do_An_Cong_Ty.Properties.Resources.truong;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(162, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(380, 267);
            this.panel2.TabIndex = 0;
            // 
            // radTimKiemHocSinh
            // 
            this.radTimKiemHocSinh.AutoSize = true;
            this.radTimKiemHocSinh.Location = new System.Drawing.Point(29, 103);
            this.radTimKiemHocSinh.Name = "radTimKiemHocSinh";
            this.radTimKiemHocSinh.Size = new System.Drawing.Size(110, 17);
            this.radTimKiemHocSinh.TabIndex = 3;
            this.radTimKiemHocSinh.TabStop = true;
            this.radTimKiemHocSinh.Text = "Tìm kiếm học sinh";
            this.radTimKiemHocSinh.UseVisualStyleBackColor = true;
            this.radTimKiemHocSinh.CheckedChanged += new System.EventHandler(this.radTimKiemHocSinh_CheckedChanged);
            // 
            // radBaoCaoTongKet
            // 
            this.radBaoCaoTongKet.AutoSize = true;
            this.radBaoCaoTongKet.Location = new System.Drawing.Point(29, 200);
            this.radBaoCaoTongKet.Name = "radBaoCaoTongKet";
            this.radBaoCaoTongKet.Size = new System.Drawing.Size(107, 17);
            this.radBaoCaoTongKet.TabIndex = 6;
            this.radBaoCaoTongKet.TabStop = true;
            this.radBaoCaoTongKet.Text = "Báo cáo tổng kết";
            this.radBaoCaoTongKet.UseVisualStyleBackColor = true;
            this.radBaoCaoTongKet.CheckedChanged += new System.EventHandler(this.radBaoCaoTongKet_CheckedChanged);
            // 
            // radThayĐoiQuyDinh
            // 
            this.radThayĐoiQuyDinh.AutoSize = true;
            this.radThayĐoiQuyDinh.Location = new System.Drawing.Point(29, 232);
            this.radThayĐoiQuyDinh.Name = "radThayĐoiQuyDinh";
            this.radThayĐoiQuyDinh.Size = new System.Drawing.Size(111, 17);
            this.radThayĐoiQuyDinh.TabIndex = 8;
            this.radThayĐoiQuyDinh.TabStop = true;
            this.radThayĐoiQuyDinh.Text = "Thay đổi quy định";
            this.radThayĐoiQuyDinh.UseVisualStyleBackColor = true;
            this.radThayĐoiQuyDinh.CheckedChanged += new System.EventHandler(this.radThayĐoiQuyDinh_CheckedChanged);
            // 
            // radNhapDiem
            // 
            this.radNhapDiem.AutoSize = true;
            this.radNhapDiem.Location = new System.Drawing.Point(29, 168);
            this.radNhapDiem.Name = "radNhapDiem";
            this.radNhapDiem.Size = new System.Drawing.Size(77, 17);
            this.radNhapDiem.TabIndex = 5;
            this.radNhapDiem.TabStop = true;
            this.radNhapDiem.Text = "Nhập điểm";
            this.radNhapDiem.UseVisualStyleBackColor = true;
            this.radNhapDiem.CheckedChanged += new System.EventHandler(this.radNhapDiem_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.họcSinhToolStripMenuItem,
            this.lớpHọcToolStripMenuItem,
            this.báoCáoToolStripMenuItem,
            this.quảnLýToolStripMenuItem,
            this.optionToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(542, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // họcSinhToolStripMenuItem
            // 
            this.họcSinhToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tiếpNhậnHọcSinhToolStripMenuItem,
            this.nhậpĐiểmToolStripMenuItem,
            this.timToolStripMenuItem,
            this.sửaThôngTinHọcSinhToolStripMenuItem,
            this.xóaThôngTinHọcSinhToolStripMenuItem});
            this.họcSinhToolStripMenuItem.Name = "họcSinhToolStripMenuItem";
            this.họcSinhToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.họcSinhToolStripMenuItem.Text = "Học sinh";
            // 
            // tiếpNhậnHọcSinhToolStripMenuItem
            // 
            this.tiếpNhậnHọcSinhToolStripMenuItem.Name = "tiếpNhậnHọcSinhToolStripMenuItem";
            this.tiếpNhậnHọcSinhToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.tiếpNhậnHọcSinhToolStripMenuItem.Text = "Tiếp nhận học sinh";
            this.tiếpNhậnHọcSinhToolStripMenuItem.Click += new System.EventHandler(this.tiếpNhậnHọcSinhToolStripMenuItem_Click);
            // 
            // nhậpĐiểmToolStripMenuItem
            // 
            this.nhậpĐiểmToolStripMenuItem.Name = "nhậpĐiểmToolStripMenuItem";
            this.nhậpĐiểmToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.nhậpĐiểmToolStripMenuItem.Text = "Nhập điểm";
            this.nhậpĐiểmToolStripMenuItem.Click += new System.EventHandler(this.nhậpĐiểmToolStripMenuItem_Click);
            // 
            // timToolStripMenuItem
            // 
            this.timToolStripMenuItem.Name = "timToolStripMenuItem";
            this.timToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.timToolStripMenuItem.Text = "Tìm kiếm học sinh";
            this.timToolStripMenuItem.Click += new System.EventHandler(this.timToolStripMenuItem_Click);
            // 
            // lớpHọcToolStripMenuItem
            // 
            this.lớpHọcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xóaLớpToolStripMenuItem,
            this.thêmLớpToolStripMenuItem,
            this.toolStripSeparator2,
            this.danhSáchLớpToolStripMenuItem});
            this.lớpHọcToolStripMenuItem.Name = "lớpHọcToolStripMenuItem";
            this.lớpHọcToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.lớpHọcToolStripMenuItem.Text = "Lớp học";
            // 
            // xóaLớpToolStripMenuItem
            // 
            this.xóaLớpToolStripMenuItem.Name = "xóaLớpToolStripMenuItem";
            this.xóaLớpToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.xóaLớpToolStripMenuItem.Text = "Xóa lớp";
            this.xóaLớpToolStripMenuItem.Click += new System.EventHandler(this.xóaLớpToolStripMenuItem_Click);
            // 
            // thêmLớpToolStripMenuItem
            // 
            this.thêmLớpToolStripMenuItem.Name = "thêmLớpToolStripMenuItem";
            this.thêmLớpToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.thêmLớpToolStripMenuItem.Text = "Thêm lớp";
            this.thêmLớpToolStripMenuItem.Click += new System.EventHandler(this.thêmLớpToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // danhSáchLớpToolStripMenuItem
            // 
            this.danhSáchLớpToolStripMenuItem.Name = "danhSáchLớpToolStripMenuItem";
            this.danhSáchLớpToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.danhSáchLớpToolStripMenuItem.Text = "Danh sách lớp";
            this.danhSáchLớpToolStripMenuItem.Click += new System.EventHandler(this.danhSáchLớpToolStripMenuItem_Click);
            // 
            // báoCáoToolStripMenuItem
            // 
            this.báoCáoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.báoCáoTheoMônToolStripMenuItem,
            this.báoCáoTheoHọcKỳToolStripMenuItem});
            this.báoCáoToolStripMenuItem.Name = "báoCáoToolStripMenuItem";
            this.báoCáoToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.báoCáoToolStripMenuItem.Text = "Báo cáo";
            // 
            // báoCáoTheoMônToolStripMenuItem
            // 
            this.báoCáoTheoMônToolStripMenuItem.Name = "báoCáoTheoMônToolStripMenuItem";
            this.báoCáoTheoMônToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.báoCáoTheoMônToolStripMenuItem.Text = "Báo cáo theo môn";
            this.báoCáoTheoMônToolStripMenuItem.Click += new System.EventHandler(this.báoCáoTheoMônToolStripMenuItem_Click);
            // 
            // báoCáoTheoHọcKỳToolStripMenuItem
            // 
            this.báoCáoTheoHọcKỳToolStripMenuItem.Name = "báoCáoTheoHọcKỳToolStripMenuItem";
            this.báoCáoTheoHọcKỳToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.báoCáoTheoHọcKỳToolStripMenuItem.Text = "Báo cáo theo học kỳ";
            this.báoCáoTheoHọcKỳToolStripMenuItem.Click += new System.EventHandler(this.báoCáoTheoHọcKỳToolStripMenuItem_Click);
            // 
            // quảnLýToolStripMenuItem
            // 
            this.quảnLýToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thêmNhânViênQuảnLýToolStripMenuItem,
            this.xóaNhânViênToolStripMenuItem});
            this.quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            this.quảnLýToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.quảnLýToolStripMenuItem.Text = "Quản lý";
            // 
            // thêmNhânViênQuảnLýToolStripMenuItem
            // 
            this.thêmNhânViênQuảnLýToolStripMenuItem.Name = "thêmNhânViênQuảnLýToolStripMenuItem";
            this.thêmNhânViênQuảnLýToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.thêmNhânViênQuảnLýToolStripMenuItem.Text = "Thêm nhân viên";
            this.thêmNhânViênQuảnLýToolStripMenuItem.Click += new System.EventHandler(this.thêmNhânViênQuảnLýToolStripMenuItem_Click);
            // 
            // xóaNhânViênToolStripMenuItem
            // 
            this.xóaNhânViênToolStripMenuItem.Name = "xóaNhânViênToolStripMenuItem";
            this.xóaNhânViênToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.xóaNhânViênToolStripMenuItem.Text = "Xóa nhân viên";
            this.xóaNhânViênToolStripMenuItem.Click += new System.EventHandler(this.xóaNhânViênToolStripMenuItem_Click);
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thayĐổiQuyĐịnhToolStripMenuItem,
            this.đổiPassToolStripMenuItem});
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.optionToolStripMenuItem.Text = "Option";
            // 
            // thayĐổiQuyĐịnhToolStripMenuItem
            // 
            this.thayĐổiQuyĐịnhToolStripMenuItem.Name = "thayĐổiQuyĐịnhToolStripMenuItem";
            this.thayĐổiQuyĐịnhToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.thayĐổiQuyĐịnhToolStripMenuItem.Text = "Thay đổi quy định";
            this.thayĐổiQuyĐịnhToolStripMenuItem.Click += new System.EventHandler(this.thayĐổiQuyĐịnhToolStripMenuItem_Click);
            // 
            // đổiPassToolStripMenuItem
            // 
            this.đổiPassToolStripMenuItem.Name = "đổiPassToolStripMenuItem";
            this.đổiPassToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.đổiPassToolStripMenuItem.Text = "Đổi password";
            this.đổiPassToolStripMenuItem.Click += new System.EventHandler(this.đổiPassToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howToUseToolStripMenuItem,
            this.aboutUsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // howToUseToolStripMenuItem
            // 
            this.howToUseToolStripMenuItem.Name = "howToUseToolStripMenuItem";
            this.howToUseToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.howToUseToolStripMenuItem.Text = "How to use";
            // 
            // aboutUsToolStripMenuItem
            // 
            this.aboutUsToolStripMenuItem.Name = "aboutUsToolStripMenuItem";
            this.aboutUsToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.aboutUsToolStripMenuItem.Text = "About us";
            // 
            // sửaThôngTinHọcSinhToolStripMenuItem
            // 
            this.sửaThôngTinHọcSinhToolStripMenuItem.Name = "sửaThôngTinHọcSinhToolStripMenuItem";
            this.sửaThôngTinHọcSinhToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.sửaThôngTinHọcSinhToolStripMenuItem.Text = "Sửa thông tin học sinh";
            this.sửaThôngTinHọcSinhToolStripMenuItem.Click += new System.EventHandler(this.sửaThôngTinHọcSinhToolStripMenuItem_Click);
            // 
            // xóaThôngTinHọcSinhToolStripMenuItem
            // 
            this.xóaThôngTinHọcSinhToolStripMenuItem.Name = "xóaThôngTinHọcSinhToolStripMenuItem";
            this.xóaThôngTinHọcSinhToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.xóaThôngTinHọcSinhToolStripMenuItem.Text = "Xóa thông tin học sinh";
            this.xóaThôngTinHọcSinhToolStripMenuItem.Click += new System.EventHandler(this.xóaThôngTinHọcSinhToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnDongY;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CancelButton = this.btnHuyBo;
            this.ClientSize = new System.Drawing.Size(542, 346);
            this.Controls.Add(this.radTiepNhanHocSinh);
            this.Controls.Add(this.radNhapDiem);
            this.Controls.Add(this.radThayĐoiQuyDinh);
            this.Controls.Add(this.radBaoCaoTongKet);
            this.Controls.Add(this.radTimKiemHocSinh);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.radThayDoiMatKhau);
            this.Controls.Add(this.radDanhSachLop);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.Blue;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(550, 380);
            this.MinimumSize = new System.Drawing.Size(550, 380);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Man Hinh Chinh";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radTiepNhanHocSinh;
        private System.Windows.Forms.RadioButton radDanhSachLop;
        private System.Windows.Forms.RadioButton radThayDoiMatKhau;
        private System.Windows.Forms.Button btnDongY;
        private System.Windows.Forms.Button btnHuyBo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radTimKiemHocSinh;
        private System.Windows.Forms.RadioButton radBaoCaoTongKet;
        private System.Windows.Forms.RadioButton radThayĐoiQuyDinh;
        private System.Windows.Forms.RadioButton radNhapDiem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem họcSinhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiếpNhậnHọcSinhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhậpĐiểmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lớpHọcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaLớpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thêmLớpToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem danhSáchLớpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báoCáoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báoCáoTheoMônToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báoCáoTheoHọcKỳToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thayĐổiQuyĐịnhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem howToUseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutUsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thêmNhânViênQuảnLýToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaNhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đổiPassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sửaThôngTinHọcSinhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaThôngTinHọcSinhToolStripMenuItem;
    }
}