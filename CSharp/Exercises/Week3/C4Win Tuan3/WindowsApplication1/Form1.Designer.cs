namespace WindowsApplication1
{
    partial class Form1
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
            this.lbldsqlsv = new System.Windows.Forms.Label();
            this.lbxDanhSach = new System.Windows.Forms.ListBox();
            this.txtMSSV = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnDocFile = new System.Windows.Forms.Button();
            this.btnGhiFile = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.lblThongBaoLoi = new System.Windows.Forms.Label();
            this.lblSoLuongSinhvien = new System.Windows.Forms.Label();
            this.lblSLSV = new System.Windows.Forms.Label();
            this.lblMSSV = new System.Windows.Forms.Label();
            this.lblHoVaTen = new System.Windows.Forms.Label();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.lblDienThoai = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblDanhSach = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbldsqlsv
            // 
            this.lbldsqlsv.AutoSize = true;
            this.lbldsqlsv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldsqlsv.Location = new System.Drawing.Point(130, 18);
            this.lbldsqlsv.Name = "lbldsqlsv";
            this.lbldsqlsv.Size = new System.Drawing.Size(232, 20);
            this.lbldsqlsv.TabIndex = 0;
            this.lbldsqlsv.Text = "Danh sách quản lý sinh viên";
            // 
            // lbxDanhSach
            // 
            this.lbxDanhSach.FormattingEnabled = true;
            this.lbxDanhSach.Location = new System.Drawing.Point(12, 66);
            this.lbxDanhSach.Name = "lbxDanhSach";
            this.lbxDanhSach.Size = new System.Drawing.Size(179, 238);
            this.lbxDanhSach.TabIndex = 1;
            // 
            // txtMSSV
            // 
            this.txtMSSV.Location = new System.Drawing.Point(279, 66);
            this.txtMSSV.Name = "txtMSSV";
            this.txtMSSV.Size = new System.Drawing.Size(108, 20);
            this.txtMSSV.TabIndex = 2;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(279, 92);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(169, 20);
            this.txtHoTen.TabIndex = 2;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(279, 118);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(169, 20);
            this.txtDiaChi.TabIndex = 2;
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(279, 144);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(169, 20);
            this.txtDienThoai.TabIndex = 2;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(279, 170);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(169, 20);
            this.txtEmail.TabIndex = 2;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(266, 223);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(45, 23);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(317, 223);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(45, 23);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(368, 223);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(68, 23);
            this.btnCapNhat.TabIndex = 3;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnDocFile
            // 
            this.btnDocFile.Location = new System.Drawing.Point(264, 333);
            this.btnDocFile.Name = "btnDocFile";
            this.btnDocFile.Size = new System.Drawing.Size(55, 23);
            this.btnDocFile.TabIndex = 3;
            this.btnDocFile.Text = "Đọc file";
            this.btnDocFile.UseVisualStyleBackColor = true;
            this.btnDocFile.Click += new System.EventHandler(this.btnDocFile_Click);
            // 
            // btnGhiFile
            // 
            this.btnGhiFile.Location = new System.Drawing.Point(325, 333);
            this.btnGhiFile.Name = "btnGhiFile";
            this.btnGhiFile.Size = new System.Drawing.Size(58, 23);
            this.btnGhiFile.TabIndex = 3;
            this.btnGhiFile.Text = "Ghi File";
            this.btnGhiFile.UseVisualStyleBackColor = true;
            this.btnGhiFile.Click += new System.EventHandler(this.btnGhiFile_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(389, 333);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(59, 23);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // lblThongBaoLoi
            // 
            this.lblThongBaoLoi.AutoSize = true;
            this.lblThongBaoLoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongBaoLoi.ForeColor = System.Drawing.Color.Red;
            this.lblThongBaoLoi.Location = new System.Drawing.Point(220, 261);
            this.lblThongBaoLoi.Name = "lblThongBaoLoi";
            this.lblThongBaoLoi.Size = new System.Drawing.Size(0, 15);
            this.lblThongBaoLoi.TabIndex = 0;
            // 
            // lblSoLuongSinhvien
            // 
            this.lblSoLuongSinhvien.AutoSize = true;
            this.lblSoLuongSinhvien.Location = new System.Drawing.Point(25, 317);
            this.lblSoLuongSinhvien.Name = "lblSoLuongSinhvien";
            this.lblSoLuongSinhvien.Size = new System.Drawing.Size(100, 13);
            this.lblSoLuongSinhvien.TabIndex = 0;
            this.lblSoLuongSinhvien.Text = "Số lượng sinh viên :";
            // 
            // lblSLSV
            // 
            this.lblSLSV.AutoSize = true;
            this.lblSLSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSLSV.Location = new System.Drawing.Point(131, 317);
            this.lblSLSV.Name = "lblSLSV";
            this.lblSLSV.Size = new System.Drawing.Size(0, 15);
            this.lblSLSV.TabIndex = 0;
            // 
            // lblMSSV
            // 
            this.lblMSSV.AutoSize = true;
            this.lblMSSV.Location = new System.Drawing.Point(208, 69);
            this.lblMSSV.Name = "lblMSSV";
            this.lblMSSV.Size = new System.Drawing.Size(40, 13);
            this.lblMSSV.TabIndex = 4;
            this.lblMSSV.Text = "MSSV ";
            // 
            // lblHoVaTen
            // 
            this.lblHoVaTen.AutoSize = true;
            this.lblHoVaTen.Location = new System.Drawing.Point(208, 95);
            this.lblHoVaTen.Name = "lblHoVaTen";
            this.lblHoVaTen.Size = new System.Drawing.Size(54, 13);
            this.lblHoVaTen.TabIndex = 4;
            this.lblHoVaTen.Text = "Họ và tên";
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Location = new System.Drawing.Point(208, 121);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(41, 13);
            this.lblDiaChi.TabIndex = 4;
            this.lblDiaChi.Text = "Địa Chỉ";
            // 
            // lblDienThoai
            // 
            this.lblDienThoai.AutoSize = true;
            this.lblDienThoai.Location = new System.Drawing.Point(208, 147);
            this.lblDienThoai.Name = "lblDienThoai";
            this.lblDienThoai.Size = new System.Drawing.Size(59, 13);
            this.lblDienThoai.TabIndex = 4;
            this.lblDienThoai.Text = "Điện Thoại";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(208, 173);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email";
            // 
            // lblDanhSach
            // 
            this.lblDanhSach.AutoSize = true;
            this.lblDanhSach.Location = new System.Drawing.Point(25, 47);
            this.lblDanhSach.Name = "lblDanhSach";
            this.lblDanhSach.Size = new System.Drawing.Size(61, 13);
            this.lblDanhSach.TabIndex = 4;
            this.lblDanhSach.Text = "Danh Sách";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 389);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblDienThoai);
            this.Controls.Add(this.lblDiaChi);
            this.Controls.Add(this.lblHoVaTen);
            this.Controls.Add(this.lblDanhSach);
            this.Controls.Add(this.lblMSSV);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.btnGhiFile);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnDocFile);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtDienThoai);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.txtMSSV);
            this.Controls.Add(this.lbxDanhSach);
            this.Controls.Add(this.lblThongBaoLoi);
            this.Controls.Add(this.lblSLSV);
            this.Controls.Add(this.lblSoLuongSinhvien);
            this.Controls.Add(this.lbldsqlsv);
            this.Name = "Form1";
            this.Text = "Danh sách sinh viên";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbldsqlsv;
        private System.Windows.Forms.ListBox lbxDanhSach;
        private System.Windows.Forms.TextBox txtMSSV;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnDocFile;
        private System.Windows.Forms.Button btnGhiFile;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label lblThongBaoLoi;
        private System.Windows.Forms.Label lblSoLuongSinhvien;
        private System.Windows.Forms.Label lblSLSV;
        private System.Windows.Forms.Label lblMSSV;
        private System.Windows.Forms.Label lblHoVaTen;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.Label lblDienThoai;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblDanhSach;
    }
}

