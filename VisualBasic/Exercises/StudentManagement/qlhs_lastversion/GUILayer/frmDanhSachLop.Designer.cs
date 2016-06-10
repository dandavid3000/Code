namespace Do_An_Cong_Ty
{
    partial class frmDanhSachLop
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
            this.lblNhapMa = new System.Windows.Forms.Label();
            this.dtgvDanhSach = new System.Windows.Forms.DataGridView();
            this.gbxBangDiem = new System.Windows.Forms.GroupBox();
            this.btnXemDanhSach = new System.Windows.Forms.Button();
            this.cbxLopHoc = new System.Windows.Forms.ComboBox();
            this.radKhoi10 = new System.Windows.Forms.RadioButton();
            this.radKhoi11 = new System.Windows.Forms.RadioButton();
            this.radKhoi12 = new System.Windows.Forms.RadioButton();
            this.lblSiSo = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDanhSach)).BeginInit();
            this.gbxBangDiem.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNhapMa
            // 
            this.lblNhapMa.AutoSize = true;
            this.lblNhapMa.Location = new System.Drawing.Point(262, 30);
            this.lblNhapMa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNhapMa.Name = "lblNhapMa";
            this.lblNhapMa.Size = new System.Drawing.Size(31, 16);
            this.lblNhapMa.TabIndex = 0;
            this.lblNhapMa.Text = "Lớp";
            // 
            // dtgvDanhSach
            // 
            this.dtgvDanhSach.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dtgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvDanhSach.Location = new System.Drawing.Point(4, 19);
            this.dtgvDanhSach.Margin = new System.Windows.Forms.Padding(4);
            this.dtgvDanhSach.Name = "dtgvDanhSach";
            this.dtgvDanhSach.Size = new System.Drawing.Size(614, 381);
            this.dtgvDanhSach.TabIndex = 0;
            this.dtgvDanhSach.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvDanhSach_CellContentClick);
            // 
            // gbxBangDiem
            // 
            this.gbxBangDiem.Controls.Add(this.dtgvDanhSach);
            this.gbxBangDiem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbxBangDiem.ForeColor = System.Drawing.Color.Black;
            this.gbxBangDiem.Location = new System.Drawing.Point(0, 72);
            this.gbxBangDiem.Margin = new System.Windows.Forms.Padding(4);
            this.gbxBangDiem.Name = "gbxBangDiem";
            this.gbxBangDiem.Padding = new System.Windows.Forms.Padding(4);
            this.gbxBangDiem.Size = new System.Drawing.Size(622, 404);
            this.gbxBangDiem.TabIndex = 2;
            this.gbxBangDiem.TabStop = false;
            this.gbxBangDiem.Text = "Danh Sách Học Sinh";
            // 
            // btnXemDanhSach
            // 
            this.btnXemDanhSach.AutoSize = true;
            this.btnXemDanhSach.Location = new System.Drawing.Point(504, 9);
            this.btnXemDanhSach.Margin = new System.Windows.Forms.Padding(4);
            this.btnXemDanhSach.Name = "btnXemDanhSach";
            this.btnXemDanhSach.Size = new System.Drawing.Size(114, 28);
            this.btnXemDanhSach.TabIndex = 3;
            this.btnXemDanhSach.Text = "Xem Danh Sách";
            this.btnXemDanhSach.UseVisualStyleBackColor = true;
            this.btnXemDanhSach.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // cbxLopHoc
            // 
            this.cbxLopHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLopHoc.FormattingEnabled = true;
            this.cbxLopHoc.Location = new System.Drawing.Point(300, 24);
            this.cbxLopHoc.Name = "cbxLopHoc";
            this.cbxLopHoc.Size = new System.Drawing.Size(121, 24);
            this.cbxLopHoc.TabIndex = 4;
            // 
            // radKhoi10
            // 
            this.radKhoi10.AutoSize = true;
            this.radKhoi10.Location = new System.Drawing.Point(19, 28);
            this.radKhoi10.Name = "radKhoi10";
            this.radKhoi10.Size = new System.Drawing.Size(69, 20);
            this.radKhoi10.TabIndex = 5;
            this.radKhoi10.TabStop = true;
            this.radKhoi10.Text = "Khối 10";
            this.radKhoi10.UseVisualStyleBackColor = true;
            this.radKhoi10.CheckedChanged += new System.EventHandler(this.radKhoi10_CheckedChanged);
            // 
            // radKhoi11
            // 
            this.radKhoi11.AutoSize = true;
            this.radKhoi11.Location = new System.Drawing.Point(94, 28);
            this.radKhoi11.Name = "radKhoi11";
            this.radKhoi11.Size = new System.Drawing.Size(69, 20);
            this.radKhoi11.TabIndex = 6;
            this.radKhoi11.TabStop = true;
            this.radKhoi11.Text = "Khối 11";
            this.radKhoi11.UseVisualStyleBackColor = true;
            this.radKhoi11.CheckedChanged += new System.EventHandler(this.radKhoi11_CheckedChanged);
            // 
            // radKhoi12
            // 
            this.radKhoi12.AutoSize = true;
            this.radKhoi12.Location = new System.Drawing.Point(169, 28);
            this.radKhoi12.Name = "radKhoi12";
            this.radKhoi12.Size = new System.Drawing.Size(69, 20);
            this.radKhoi12.TabIndex = 7;
            this.radKhoi12.TabStop = true;
            this.radKhoi12.Text = "Khối 12";
            this.radKhoi12.UseVisualStyleBackColor = true;
            this.radKhoi12.CheckedChanged += new System.EventHandler(this.radKhoi12_CheckedChanged);
            // 
            // lblSiSo
            // 
            this.lblSiSo.AutoSize = true;
            this.lblSiSo.Location = new System.Drawing.Point(428, 30);
            this.lblSiSo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSiSo.Name = "lblSiSo";
            this.lblSiSo.Size = new System.Drawing.Size(47, 16);
            this.lblSiSo.TabIndex = 8;
            this.lblSiSo.Text = "Sỉ số : ";
            // 
            // btnThoat
            // 
            this.btnThoat.AutoSize = true;
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Location = new System.Drawing.Point(504, 45);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(114, 28);
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmDanhSachLop
            // 
            this.AcceptButton = this.btnXemDanhSach;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.CancelButton = this.btnThoat;
            this.ClientSize = new System.Drawing.Size(622, 476);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.lblSiSo);
            this.Controls.Add(this.radKhoi12);
            this.Controls.Add(this.radKhoi11);
            this.Controls.Add(this.radKhoi10);
            this.Controls.Add(this.cbxLopHoc);
            this.Controls.Add(this.btnXemDanhSach);
            this.Controls.Add(this.gbxBangDiem);
            this.Controls.Add(this.lblNhapMa);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDanhSachLop";
            this.Text = "Danh Sach Lop";
            this.Load += new System.EventHandler(this.FrmThongTinVeDiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDanhSach)).EndInit();
            this.gbxBangDiem.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNhapMa;
        private System.Windows.Forms.DataGridView dtgvDanhSach;
        private System.Windows.Forms.GroupBox gbxBangDiem;
        private System.Windows.Forms.Button btnXemDanhSach;
        private System.Windows.Forms.ComboBox cbxLopHoc;
        private System.Windows.Forms.RadioButton radKhoi10;
        private System.Windows.Forms.RadioButton radKhoi11;
        private System.Windows.Forms.RadioButton radKhoi12;
        private System.Windows.Forms.Label lblSiSo;
        private System.Windows.Forms.Button btnThoat;
    }
}