namespace Do_An_Cong_Ty
{
    partial class frmBaoCaoTongKet
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
            this.tbcBaoCao = new System.Windows.Forms.TabControl();
            this.tabPageMon = new System.Windows.Forms.TabPage();
            this.btnHuybo = new System.Windows.Forms.Button();
            this.btnThucThi = new System.Windows.Forms.Button();
            this.groupBoxMon = new System.Windows.Forms.GroupBox();
            this.dtgvBaoCaoMon = new System.Windows.Forms.DataGridView();
            this.cbxHocKy = new System.Windows.Forms.ComboBox();
            this.lblHocKy = new System.Windows.Forms.Label();
            this.cbxMonHoc = new System.Windows.Forms.ComboBox();
            this.lblMon = new System.Windows.Forms.Label();
            this.tabPageHocKy = new System.Windows.Forms.TabPage();
            this.btnThoatHK = new System.Windows.Forms.Button();
            this.btnThucThiHK = new System.Windows.Forms.Button();
            this.groupBoxDanhSach = new System.Windows.Forms.GroupBox();
            this.dtgvHocKy = new System.Windows.Forms.DataGridView();
            this.cbxHK = new System.Windows.Forms.ComboBox();
            this.lblHocKy2 = new System.Windows.Forms.Label();
            this.tbcBaoCao.SuspendLayout();
            this.tabPageMon.SuspendLayout();
            this.groupBoxMon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBaoCaoMon)).BeginInit();
            this.tabPageHocKy.SuspendLayout();
            this.groupBoxDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvHocKy)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcBaoCao
            // 
            this.tbcBaoCao.Controls.Add(this.tabPageMon);
            this.tbcBaoCao.Controls.Add(this.tabPageHocKy);
            this.tbcBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcBaoCao.Location = new System.Drawing.Point(0, 0);
            this.tbcBaoCao.Name = "tbcBaoCao";
            this.tbcBaoCao.RightToLeftLayout = true;
            this.tbcBaoCao.SelectedIndex = 0;
            this.tbcBaoCao.Size = new System.Drawing.Size(545, 489);
            this.tbcBaoCao.TabIndex = 0;
            // 
            // tabPageMon
            // 
            this.tabPageMon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tabPageMon.Controls.Add(this.btnHuybo);
            this.tabPageMon.Controls.Add(this.btnThucThi);
            this.tabPageMon.Controls.Add(this.groupBoxMon);
            this.tabPageMon.Controls.Add(this.cbxHocKy);
            this.tabPageMon.Controls.Add(this.lblHocKy);
            this.tabPageMon.Controls.Add(this.cbxMonHoc);
            this.tabPageMon.Controls.Add(this.lblMon);
            this.tabPageMon.Location = new System.Drawing.Point(4, 22);
            this.tabPageMon.Name = "tabPageMon";
            this.tabPageMon.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMon.Size = new System.Drawing.Size(537, 463);
            this.tabPageMon.TabIndex = 0;
            this.tabPageMon.Text = " Môn";
            // 
            // btnHuybo
            // 
            this.btnHuybo.Location = new System.Drawing.Point(440, 44);
            this.btnHuybo.Name = "btnHuybo";
            this.btnHuybo.Size = new System.Drawing.Size(75, 23);
            this.btnHuybo.TabIndex = 6;
            this.btnHuybo.Text = "Hủy Bỏ";
            this.btnHuybo.UseVisualStyleBackColor = true;
            this.btnHuybo.Click += new System.EventHandler(this.btnHuybo_Click);
            // 
            // btnThucThi
            // 
            this.btnThucThi.Location = new System.Drawing.Point(440, 15);
            this.btnThucThi.Name = "btnThucThi";
            this.btnThucThi.Size = new System.Drawing.Size(75, 23);
            this.btnThucThi.TabIndex = 5;
            this.btnThucThi.Text = "Thực Thi";
            this.btnThucThi.UseVisualStyleBackColor = true;
            this.btnThucThi.Click += new System.EventHandler(this.btnThucThi_Click);
            // 
            // groupBoxMon
            // 
            this.groupBoxMon.Controls.Add(this.dtgvBaoCaoMon);
            this.groupBoxMon.ForeColor = System.Drawing.Color.Black;
            this.groupBoxMon.Location = new System.Drawing.Point(22, 73);
            this.groupBoxMon.Name = "groupBoxMon";
            this.groupBoxMon.Size = new System.Drawing.Size(493, 359);
            this.groupBoxMon.TabIndex = 4;
            this.groupBoxMon.TabStop = false;
            this.groupBoxMon.Text = "Danh Sách";
            // 
            // dtgvBaoCaoMon
            // 
            this.dtgvBaoCaoMon.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dtgvBaoCaoMon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvBaoCaoMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvBaoCaoMon.Location = new System.Drawing.Point(3, 16);
            this.dtgvBaoCaoMon.Name = "dtgvBaoCaoMon";
            this.dtgvBaoCaoMon.Size = new System.Drawing.Size(487, 340);
            this.dtgvBaoCaoMon.TabIndex = 0;
            // 
            // cbxHocKy
            // 
            this.cbxHocKy.FormattingEnabled = true;
            this.cbxHocKy.Location = new System.Drawing.Point(275, 31);
            this.cbxHocKy.Name = "cbxHocKy";
            this.cbxHocKy.Size = new System.Drawing.Size(129, 21);
            this.cbxHocKy.TabIndex = 3;
            // 
            // lblHocKy
            // 
            this.lblHocKy.AutoSize = true;
            this.lblHocKy.Location = new System.Drawing.Point(205, 34);
            this.lblHocKy.Name = "lblHocKy";
            this.lblHocKy.Size = new System.Drawing.Size(42, 13);
            this.lblHocKy.TabIndex = 2;
            this.lblHocKy.Text = "Học Kỳ";
            // 
            // cbxMonHoc
            // 
            this.cbxMonHoc.FormattingEnabled = true;
            this.cbxMonHoc.Location = new System.Drawing.Point(56, 31);
            this.cbxMonHoc.Name = "cbxMonHoc";
            this.cbxMonHoc.Size = new System.Drawing.Size(129, 21);
            this.cbxMonHoc.TabIndex = 1;
            // 
            // lblMon
            // 
            this.lblMon.AutoSize = true;
            this.lblMon.Location = new System.Drawing.Point(22, 34);
            this.lblMon.Name = "lblMon";
            this.lblMon.Size = new System.Drawing.Size(28, 13);
            this.lblMon.TabIndex = 0;
            this.lblMon.Text = "Môn";
            // 
            // tabPageHocKy
            // 
            this.tabPageHocKy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tabPageHocKy.Controls.Add(this.btnThoatHK);
            this.tabPageHocKy.Controls.Add(this.btnThucThiHK);
            this.tabPageHocKy.Controls.Add(this.groupBoxDanhSach);
            this.tabPageHocKy.Controls.Add(this.cbxHK);
            this.tabPageHocKy.Controls.Add(this.lblHocKy2);
            this.tabPageHocKy.ForeColor = System.Drawing.Color.Blue;
            this.tabPageHocKy.Location = new System.Drawing.Point(4, 22);
            this.tabPageHocKy.Name = "tabPageHocKy";
            this.tabPageHocKy.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHocKy.Size = new System.Drawing.Size(537, 463);
            this.tabPageHocKy.TabIndex = 1;
            this.tabPageHocKy.Text = "HọcKỳ";
            // 
            // btnThoatHK
            // 
            this.btnThoatHK.ForeColor = System.Drawing.Color.Black;
            this.btnThoatHK.Location = new System.Drawing.Point(422, 47);
            this.btnThoatHK.Name = "btnThoatHK";
            this.btnThoatHK.Size = new System.Drawing.Size(75, 23);
            this.btnThoatHK.TabIndex = 9;
            this.btnThoatHK.Text = "Thoát";
            this.btnThoatHK.UseVisualStyleBackColor = true;
            this.btnThoatHK.Click += new System.EventHandler(this.btnThoatHK_Click);
            // 
            // btnThucThiHK
            // 
            this.btnThucThiHK.ForeColor = System.Drawing.Color.Black;
            this.btnThucThiHK.Location = new System.Drawing.Point(422, 18);
            this.btnThucThiHK.Name = "btnThucThiHK";
            this.btnThucThiHK.Size = new System.Drawing.Size(75, 23);
            this.btnThucThiHK.TabIndex = 8;
            this.btnThucThiHK.Text = "Thực Thi";
            this.btnThucThiHK.UseVisualStyleBackColor = true;
            this.btnThucThiHK.Click += new System.EventHandler(this.btnThucThiHK_Click);
            // 
            // groupBoxDanhSach
            // 
            this.groupBoxDanhSach.Controls.Add(this.dtgvHocKy);
            this.groupBoxDanhSach.ForeColor = System.Drawing.Color.Black;
            this.groupBoxDanhSach.Location = new System.Drawing.Point(22, 73);
            this.groupBoxDanhSach.Name = "groupBoxDanhSach";
            this.groupBoxDanhSach.Size = new System.Drawing.Size(493, 359);
            this.groupBoxDanhSach.TabIndex = 7;
            this.groupBoxDanhSach.TabStop = false;
            this.groupBoxDanhSach.Text = "Danh Sách";
            // 
            // dtgvHocKy
            // 
            this.dtgvHocKy.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dtgvHocKy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvHocKy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvHocKy.Location = new System.Drawing.Point(3, 16);
            this.dtgvHocKy.Name = "dtgvHocKy";
            this.dtgvHocKy.Size = new System.Drawing.Size(487, 340);
            this.dtgvHocKy.TabIndex = 0;
            // 
            // cbxHK
            // 
            this.cbxHK.FormattingEnabled = true;
            this.cbxHK.Location = new System.Drawing.Point(214, 34);
            this.cbxHK.Name = "cbxHK";
            this.cbxHK.Size = new System.Drawing.Size(129, 21);
            this.cbxHK.TabIndex = 6;
            // 
            // lblHocKy2
            // 
            this.lblHocKy2.AutoSize = true;
            this.lblHocKy2.ForeColor = System.Drawing.Color.Black;
            this.lblHocKy2.Location = new System.Drawing.Point(157, 37);
            this.lblHocKy2.Name = "lblHocKy2";
            this.lblHocKy2.Size = new System.Drawing.Size(42, 13);
            this.lblHocKy2.TabIndex = 5;
            this.lblHocKy2.Text = "Học Kỳ";
            // 
            // frmBaoCaoTongKet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 489);
            this.Controls.Add(this.tbcBaoCao);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBaoCaoTongKet";
            this.Text = "Bao Cao Tong Ket";
            this.Load += new System.EventHandler(this.frmBaoCaoTongKet_Load);
            this.tbcBaoCao.ResumeLayout(false);
            this.tabPageMon.ResumeLayout(false);
            this.tabPageMon.PerformLayout();
            this.groupBoxMon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBaoCaoMon)).EndInit();
            this.tabPageHocKy.ResumeLayout(false);
            this.tabPageHocKy.PerformLayout();
            this.groupBoxDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvHocKy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcBaoCao;
        private System.Windows.Forms.TabPage tabPageMon;
        private System.Windows.Forms.TabPage tabPageHocKy;
        private System.Windows.Forms.GroupBox groupBoxMon;
        private System.Windows.Forms.DataGridView dtgvBaoCaoMon;
        private System.Windows.Forms.ComboBox cbxHocKy;
        private System.Windows.Forms.Label lblHocKy;
        private System.Windows.Forms.ComboBox cbxMonHoc;
        private System.Windows.Forms.Label lblMon;
        private System.Windows.Forms.GroupBox groupBoxDanhSach;
        private System.Windows.Forms.DataGridView dtgvHocKy;
        private System.Windows.Forms.ComboBox cbxHK;
        private System.Windows.Forms.Label lblHocKy2;
        private System.Windows.Forms.Button btnHuybo;
        private System.Windows.Forms.Button btnThucThi;
        private System.Windows.Forms.Button btnThoatHK;
        private System.Windows.Forms.Button btnThucThiHK;
    }
}