namespace _6k3021
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.giớiThiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTacGia = new System.Windows.Forms.TextBox();
            this.txtTenSach = new System.Windows.Forms.TextBox();
            this.txtMaSach = new System.Windows.Forms.TextBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.rdbNgoaiNuoc = new System.Windows.Forms.RadioButton();
            this.rdbTrongNuoc = new System.Windows.Forms.RadioButton();
            this.lblNguon = new System.Windows.Forms.Label();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.lblTacGia = new System.Windows.Forms.Label();
            this.lblTenSach = new System.Windows.Forms.Label();
            this.lblMaSach = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lvwDanhSach = new System.Windows.Forms.ListView();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.giớiThiệuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(697, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // giớiThiệuToolStripMenuItem
            // 
            this.giớiThiệuToolStripMenuItem.Name = "giớiThiệuToolStripMenuItem";
            this.giớiThiệuToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.giớiThiệuToolStripMenuItem.Text = "Giới thiệu";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtTacGia);
            this.panel1.Controls.Add(this.txtTenSach);
            this.panel1.Controls.Add(this.txtMaSach);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Controls.Add(this.rdbNgoaiNuoc);
            this.panel1.Controls.Add(this.rdbTrongNuoc);
            this.panel1.Controls.Add(this.lblNguon);
            this.panel1.Controls.Add(this.lblThongBao);
            this.panel1.Controls.Add(this.lblTacGia);
            this.panel1.Controls.Add(this.lblTenSach);
            this.panel1.Controls.Add(this.lblMaSach);
            this.panel1.Location = new System.Drawing.Point(10, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(282, 238);
            this.panel1.TabIndex = 1;
            // 
            // txtTacGia
            // 
            this.txtTacGia.Location = new System.Drawing.Point(81, 117);
            this.txtTacGia.Name = "txtTacGia";
            this.txtTacGia.Size = new System.Drawing.Size(164, 20);
            this.txtTacGia.TabIndex = 3;
            // 
            // txtTenSach
            // 
            this.txtTenSach.Location = new System.Drawing.Point(81, 38);
            this.txtTenSach.Name = "txtTenSach";
            this.txtTenSach.Size = new System.Drawing.Size(164, 20);
            this.txtTenSach.TabIndex = 3;
            // 
            // txtMaSach
            // 
            this.txtMaSach.Location = new System.Drawing.Point(81, 12);
            this.txtMaSach.Name = "txtMaSach";
            this.txtMaSach.Size = new System.Drawing.Size(164, 20);
            this.txtMaSach.TabIndex = 3;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(168, 191);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(81, 22);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(72, 191);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(81, 22);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // rdbNgoaiNuoc
            // 
            this.rdbNgoaiNuoc.AutoSize = true;
            this.rdbNgoaiNuoc.Location = new System.Drawing.Point(168, 78);
            this.rdbNgoaiNuoc.Name = "rdbNgoaiNuoc";
            this.rdbNgoaiNuoc.Size = new System.Drawing.Size(80, 17);
            this.rdbNgoaiNuoc.TabIndex = 1;
            this.rdbNgoaiNuoc.TabStop = true;
            this.rdbNgoaiNuoc.Text = "Ngoài nước";
            this.rdbNgoaiNuoc.UseVisualStyleBackColor = true;
            // 
            // rdbTrongNuoc
            // 
            this.rdbTrongNuoc.AutoSize = true;
            this.rdbTrongNuoc.Location = new System.Drawing.Point(82, 78);
            this.rdbTrongNuoc.Name = "rdbTrongNuoc";
            this.rdbTrongNuoc.Size = new System.Drawing.Size(80, 17);
            this.rdbTrongNuoc.TabIndex = 1;
            this.rdbTrongNuoc.TabStop = true;
            this.rdbTrongNuoc.Text = "Trong nước";
            this.rdbTrongNuoc.UseVisualStyleBackColor = true;
            // 
            // lblNguon
            // 
            this.lblNguon.AutoSize = true;
            this.lblNguon.Location = new System.Drawing.Point(12, 82);
            this.lblNguon.Name = "lblNguon";
            this.lblNguon.Size = new System.Drawing.Size(39, 13);
            this.lblNguon.TabIndex = 0;
            this.lblNguon.Text = "Nguồn";
            // 
            // lblThongBao
            // 
            this.lblThongBao.AutoSize = true;
            this.lblThongBao.ForeColor = System.Drawing.Color.Crimson;
            this.lblThongBao.Location = new System.Drawing.Point(38, 163);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(43, 13);
            this.lblThongBao.TabIndex = 0;
            this.lblThongBao.Text = "Tác giả";
            // 
            // lblTacGia
            // 
            this.lblTacGia.AutoSize = true;
            this.lblTacGia.Location = new System.Drawing.Point(12, 120);
            this.lblTacGia.Name = "lblTacGia";
            this.lblTacGia.Size = new System.Drawing.Size(43, 13);
            this.lblTacGia.TabIndex = 0;
            this.lblTacGia.Text = "Tác giả";
            // 
            // lblTenSach
            // 
            this.lblTenSach.AutoSize = true;
            this.lblTenSach.Location = new System.Drawing.Point(12, 41);
            this.lblTenSach.Name = "lblTenSach";
            this.lblTenSach.Size = new System.Drawing.Size(52, 13);
            this.lblTenSach.TabIndex = 0;
            this.lblTenSach.Text = "Tên sách";
            // 
            // lblMaSach
            // 
            this.lblMaSach.AutoSize = true;
            this.lblMaSach.Location = new System.Drawing.Point(12, 15);
            this.lblMaSach.Name = "lblMaSach";
            this.lblMaSach.Size = new System.Drawing.Size(48, 13);
            this.lblMaSach.TabIndex = 0;
            this.lblMaSach.Text = "Mã sách";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lvwDanhSach);
            this.panel2.Location = new System.Drawing.Point(320, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(365, 238);
            this.panel2.TabIndex = 2;
            // 
            // lvwDanhSach
            // 
            this.lvwDanhSach.Location = new System.Drawing.Point(3, 3);
            this.lvwDanhSach.Name = "lvwDanhSach";
            this.lvwDanhSach.Size = new System.Drawing.Size(359, 232);
            this.lvwDanhSach.TabIndex = 0;
            this.lvwDanhSach.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 293);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem giớiThiệuToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdbNgoaiNuoc;
        private System.Windows.Forms.RadioButton rdbTrongNuoc;
        private System.Windows.Forms.Label lblTacGia;
        private System.Windows.Forms.Label lblTenSach;
        private System.Windows.Forms.Label lblMaSach;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblNguon;
        private System.Windows.Forms.TextBox txtTacGia;
        private System.Windows.Forms.TextBox txtTenSach;
        private System.Windows.Forms.TextBox txtMaSach;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label lblThongBao;
        private System.Windows.Forms.ListView lvwDanhSach;
    }
}

