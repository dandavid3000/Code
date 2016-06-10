namespace QuanLy_IO
{
    partial class frmQuanLy
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.quanLyNguoiDungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quanLyNghiepVuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ThayDoiMKtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTenNguoiDung = new System.Windows.Forms.Label();
            this.lvwQuanLyNguoiDung = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbxQuyen = new System.Windows.Forms.ComboBox();
            this.lblQuyen = new System.Windows.Forms.Label();
            this.txtHovaTen = new System.Windows.Forms.TextBox();
            this.lblHoVaTen = new System.Windows.Forms.Label();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.lblTaiKhoan = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quanLyNguoiDungToolStripMenuItem,
            this.quanLyNghiepVuToolStripMenuItem,
            this.ThayDoiMKtoolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(592, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // quanLyNguoiDungToolStripMenuItem
            // 
            this.quanLyNguoiDungToolStripMenuItem.Name = "quanLyNguoiDungToolStripMenuItem";
            this.quanLyNguoiDungToolStripMenuItem.Size = new System.Drawing.Size(118, 20);
            this.quanLyNguoiDungToolStripMenuItem.Text = "Quản Lý Người Dùng";
            // 
            // quanLyNghiepVuToolStripMenuItem
            // 
            this.quanLyNghiepVuToolStripMenuItem.Name = "quanLyNghiepVuToolStripMenuItem";
            this.quanLyNghiepVuToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.quanLyNghiepVuToolStripMenuItem.Text = "Quản Lý Nghiệp Vụ";
            // 
            // ThayDoiMKtoolStripMenuItem
            // 
            this.ThayDoiMKtoolStripMenuItem.Name = "ThayDoiMKtoolStripMenuItem";
            this.ThayDoiMKtoolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.ThayDoiMKtoolStripMenuItem.Text = "Thay Đổi Mật Khẩu";
            this.ThayDoiMKtoolStripMenuItem.Click += new System.EventHandler(this.ThayDoiMKtoolStripMenuItem_Click);
            // 
            // lblTenNguoiDung
            // 
            this.lblTenNguoiDung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTenNguoiDung.AutoSize = true;
            this.lblTenNguoiDung.Location = new System.Drawing.Point(251, 10);
            this.lblTenNguoiDung.Name = "lblTenNguoiDung";
            this.lblTenNguoiDung.Size = new System.Drawing.Size(90, 13);
            this.lblTenNguoiDung.TabIndex = 1;
            this.lblTenNguoiDung.Text = "lblTenNguoiDung";
            // 
            // lvwQuanLyNguoiDung
            // 
            this.lvwQuanLyNguoiDung.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvwQuanLyNguoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwQuanLyNguoiDung.FullRowSelect = true;
            this.lvwQuanLyNguoiDung.GridLines = true;
            this.lvwQuanLyNguoiDung.Location = new System.Drawing.Point(0, 57);
            this.lvwQuanLyNguoiDung.MultiSelect = false;
            this.lvwQuanLyNguoiDung.Name = "lvwQuanLyNguoiDung";
            this.lvwQuanLyNguoiDung.Size = new System.Drawing.Size(592, 159);
            this.lvwQuanLyNguoiDung.TabIndex = 2;
            this.lvwQuanLyNguoiDung.UseCompatibleStateImageBehavior = false;
            this.lvwQuanLyNguoiDung.SelectedIndexChanged += new System.EventHandler(this.lvwQuanLyNguoiDung_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTenNguoiDung);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(592, 33);
            this.panel1.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnThoat);
            this.panel3.Controls.Add(this.btnCapNhat);
            this.panel3.Controls.Add(this.btnXoa);
            this.panel3.Controls.Add(this.btnThem);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 306);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(592, 60);
            this.panel3.TabIndex = 5;
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Location = new System.Drawing.Point(466, 19);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCapNhat.Location = new System.Drawing.Point(339, 19);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(75, 23);
            this.btnCapNhat.TabIndex = 6;
            this.btnCapNhat.Text = "Cập Nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXoa.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnXoa.Location = new System.Drawing.Point(201, 19);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnThem.Location = new System.Drawing.Point(51, 19);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cbxQuyen);
            this.panel4.Controls.Add(this.lblQuyen);
            this.panel4.Controls.Add(this.txtHovaTen);
            this.panel4.Controls.Add(this.lblHoVaTen);
            this.panel4.Controls.Add(this.txtTaiKhoan);
            this.panel4.Controls.Add(this.lblTaiKhoan);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 216);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(592, 90);
            this.panel4.TabIndex = 6;
            // 
            // cbxQuyen
            // 
            this.cbxQuyen.FormattingEnabled = true;
            this.cbxQuyen.Location = new System.Drawing.Point(420, 15);
            this.cbxQuyen.Name = "cbxQuyen";
            this.cbxQuyen.Size = new System.Drawing.Size(160, 21);
            this.cbxQuyen.TabIndex = 5;
            this.cbxQuyen.SelectedIndexChanged += new System.EventHandler(this.cbxQuyen_SelectedIndexChanged);
            // 
            // lblQuyen
            // 
            this.lblQuyen.AutoSize = true;
            this.lblQuyen.Location = new System.Drawing.Point(376, 18);
            this.lblQuyen.Name = "lblQuyen";
            this.lblQuyen.Size = new System.Drawing.Size(38, 13);
            this.lblQuyen.TabIndex = 4;
            this.lblQuyen.Text = "Quyền";
            // 
            // txtHovaTen
            // 
            this.txtHovaTen.Location = new System.Drawing.Point(145, 55);
            this.txtHovaTen.Name = "txtHovaTen";
            this.txtHovaTen.Size = new System.Drawing.Size(435, 20);
            this.txtHovaTen.TabIndex = 3;
            // 
            // lblHoVaTen
            // 
            this.lblHoVaTen.AutoSize = true;
            this.lblHoVaTen.Location = new System.Drawing.Point(48, 58);
            this.lblHoVaTen.Name = "lblHoVaTen";
            this.lblHoVaTen.Size = new System.Drawing.Size(58, 13);
            this.lblHoVaTen.TabIndex = 2;
            this.lblHoVaTen.Text = "Họ và Tên";
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Location = new System.Drawing.Point(145, 15);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(170, 20);
            this.txtTaiKhoan.TabIndex = 1;
            // 
            // lblTaiKhoan
            // 
            this.lblTaiKhoan.AutoSize = true;
            this.lblTaiKhoan.Location = new System.Drawing.Point(50, 18);
            this.lblTaiKhoan.Name = "lblTaiKhoan";
            this.lblTaiKhoan.Size = new System.Drawing.Size(56, 13);
            this.lblTaiKhoan.TabIndex = 0;
            this.lblTaiKhoan.Text = "Tài Khoản";
            // 
            // frmQuanLy
            // 
            this.AcceptButton = this.btnThem;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnThoat;
            this.ClientSize = new System.Drawing.Size(592, 366);
            this.Controls.Add(this.lvwQuanLyNguoiDung);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmQuanLy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quan Ly";
            this.Load += new System.EventHandler(this.frmQuanLy_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quanLyNguoiDungToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quanLyNghiepVuToolStripMenuItem;
        private System.Windows.Forms.Label lblTenNguoiDung;
        private System.Windows.Forms.ToolStripMenuItem ThayDoiMKtoolStripMenuItem;
        private System.Windows.Forms.ListView lvwQuanLyNguoiDung;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label lblTaiKhoan;
        private System.Windows.Forms.TextBox txtHovaTen;
        private System.Windows.Forms.Label lblHoVaTen;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.ComboBox cbxQuyen;
        private System.Windows.Forms.Label lblQuyen;
    }
}

