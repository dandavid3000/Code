namespace Do_An_Cong_Ty
{
    partial class frmThemQuanLy
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
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.cbxPhongBan = new System.Windows.Forms.ComboBox();
            this.txtTenQuanLy = new System.Windows.Forms.TextBox();
            this.lblKhoi = new System.Windows.Forms.Label();
            this.lblTenLop = new System.Windows.Forms.Label();
            this.txtMaQuanLy = new System.Windows.Forms.TextBox();
            this.lblMaLop = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxChucDanh = new System.Windows.Forms.ComboBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnThoat
            // 
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Location = new System.Drawing.Point(183, 171);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(37, 171);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // cbxPhongBan
            // 
            this.cbxPhongBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPhongBan.FormattingEnabled = true;
            this.cbxPhongBan.Location = new System.Drawing.Point(121, 128);
            this.cbxPhongBan.Name = "cbxPhongBan";
            this.cbxPhongBan.Size = new System.Drawing.Size(137, 21);
            this.cbxPhongBan.TabIndex = 5;
            this.cbxPhongBan.SelectedIndexChanged += new System.EventHandler(this.cbxPhongBan_SelectedIndexChanged);
            // 
            // txtTenQuanLy
            // 
            this.txtTenQuanLy.Location = new System.Drawing.Point(121, 49);
            this.txtTenQuanLy.Name = "txtTenQuanLy";
            this.txtTenQuanLy.Size = new System.Drawing.Size(137, 20);
            this.txtTenQuanLy.TabIndex = 2;
            // 
            // lblKhoi
            // 
            this.lblKhoi.AutoSize = true;
            this.lblKhoi.Location = new System.Drawing.Point(35, 131);
            this.lblKhoi.Name = "lblKhoi";
            this.lblKhoi.Size = new System.Drawing.Size(60, 13);
            this.lblKhoi.TabIndex = 0;
            this.lblKhoi.Text = "Phòng Ban";
            // 
            // lblTenLop
            // 
            this.lblTenLop.AutoSize = true;
            this.lblTenLop.Location = new System.Drawing.Point(34, 52);
            this.lblTenLop.Name = "lblTenLop";
            this.lblTenLop.Size = new System.Drawing.Size(69, 13);
            this.lblTenLop.TabIndex = 0;
            this.lblTenLop.Text = "Tên Quản Lý";
            // 
            // txtMaQuanLy
            // 
            this.txtMaQuanLy.Enabled = false;
            this.txtMaQuanLy.ForeColor = System.Drawing.Color.Red;
            this.txtMaQuanLy.Location = new System.Drawing.Point(121, 23);
            this.txtMaQuanLy.Name = "txtMaQuanLy";
            this.txtMaQuanLy.Size = new System.Drawing.Size(137, 20);
            this.txtMaQuanLy.TabIndex = 1;
            // 
            // lblMaLop
            // 
            this.lblMaLop.AutoSize = true;
            this.lblMaLop.Location = new System.Drawing.Point(34, 26);
            this.lblMaLop.Name = "lblMaLop";
            this.lblMaLop.Size = new System.Drawing.Size(65, 13);
            this.lblMaLop.TabIndex = 0;
            this.lblMaLop.Text = "Mã Quản Lý";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chức Danh";
            // 
            // cbxChucDanh
            // 
            this.cbxChucDanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxChucDanh.FormattingEnabled = true;
            this.cbxChucDanh.Location = new System.Drawing.Point(121, 101);
            this.cbxChucDanh.Name = "cbxChucDanh";
            this.cbxChucDanh.Size = new System.Drawing.Size(137, 21);
            this.cbxChucDanh.TabIndex = 4;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(121, 75);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(137, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Password";
            // 
            // frmThemQuanLy
            // 
            this.AcceptButton = this.btnThem;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.CancelButton = this.btnThoat;
            this.ClientSize = new System.Drawing.Size(292, 216);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxChucDanh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.cbxPhongBan);
            this.Controls.Add(this.txtTenQuanLy);
            this.Controls.Add(this.lblKhoi);
            this.Controls.Add(this.lblTenLop);
            this.Controls.Add(this.txtMaQuanLy);
            this.Controls.Add(this.lblMaLop);
            this.Name = "frmThemQuanLy";
            this.Text = "Them Quan Ly";
            this.Load += new System.EventHandler(this.frmThemQuanLy_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.ComboBox cbxPhongBan;
        private System.Windows.Forms.TextBox txtTenQuanLy;
        private System.Windows.Forms.Label lblKhoi;
        private System.Windows.Forms.Label lblTenLop;
        private System.Windows.Forms.TextBox txtMaQuanLy;
        private System.Windows.Forms.Label lblMaLop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxChucDanh;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
    }
}