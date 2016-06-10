namespace Do_An_Cong_Ty
{
    partial class frmXoaQuanLy
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
            this.cbxChucDanh = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.cbxPhongBan = new System.Windows.Forms.ComboBox();
            this.txtTenQuanLy = new System.Windows.Forms.TextBox();
            this.lblKhoi = new System.Windows.Forms.Label();
            this.lblTenLop = new System.Windows.Forms.Label();
            this.lblMaLop = new System.Windows.Forms.Label();
            this.cbxMaQuanLy = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbxChucDanh
            // 
            this.cbxChucDanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxChucDanh.FormattingEnabled = true;
            this.cbxChucDanh.Location = new System.Drawing.Point(121, 66);
            this.cbxChucDanh.Name = "cbxChucDanh";
            this.cbxChucDanh.Size = new System.Drawing.Size(137, 21);
            this.cbxChucDanh.TabIndex = 3;
            this.cbxChucDanh.SelectedIndexChanged += new System.EventHandler(this.cbxChucDanh_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chức Danh";
            // 
            // btnThoat
            // 
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Location = new System.Drawing.Point(183, 130);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(37, 130);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // cbxPhongBan
            // 
            this.cbxPhongBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPhongBan.FormattingEnabled = true;
            this.cbxPhongBan.Location = new System.Drawing.Point(121, 93);
            this.cbxPhongBan.Name = "cbxPhongBan";
            this.cbxPhongBan.Size = new System.Drawing.Size(137, 21);
            this.cbxPhongBan.TabIndex = 4;
            this.cbxPhongBan.SelectedIndexChanged += new System.EventHandler(this.cbxPhongBan_SelectedIndexChanged);
            // 
            // txtTenQuanLy
            // 
            this.txtTenQuanLy.Enabled = false;
            this.txtTenQuanLy.Location = new System.Drawing.Point(121, 40);
            this.txtTenQuanLy.Name = "txtTenQuanLy";
            this.txtTenQuanLy.Size = new System.Drawing.Size(137, 20);
            this.txtTenQuanLy.TabIndex = 2;
            // 
            // lblKhoi
            // 
            this.lblKhoi.AutoSize = true;
            this.lblKhoi.Location = new System.Drawing.Point(35, 96);
            this.lblKhoi.Name = "lblKhoi";
            this.lblKhoi.Size = new System.Drawing.Size(60, 13);
            this.lblKhoi.TabIndex = 0;
            this.lblKhoi.Text = "Phòng Ban";
            // 
            // lblTenLop
            // 
            this.lblTenLop.AutoSize = true;
            this.lblTenLop.Location = new System.Drawing.Point(34, 43);
            this.lblTenLop.Name = "lblTenLop";
            this.lblTenLop.Size = new System.Drawing.Size(69, 13);
            this.lblTenLop.TabIndex = 0;
            this.lblTenLop.Text = "Tên Quản Lý";
            // 
            // lblMaLop
            // 
            this.lblMaLop.AutoSize = true;
            this.lblMaLop.Location = new System.Drawing.Point(34, 17);
            this.lblMaLop.Name = "lblMaLop";
            this.lblMaLop.Size = new System.Drawing.Size(65, 13);
            this.lblMaLop.TabIndex = 0;
            this.lblMaLop.Text = "Mã Quản Lý";
            // 
            // cbxMaQuanLy
            // 
            this.cbxMaQuanLy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMaQuanLy.FormattingEnabled = true;
            this.cbxMaQuanLy.Location = new System.Drawing.Point(121, 14);
            this.cbxMaQuanLy.Name = "cbxMaQuanLy";
            this.cbxMaQuanLy.Size = new System.Drawing.Size(137, 21);
            this.cbxMaQuanLy.TabIndex = 1;
            this.cbxMaQuanLy.SelectedIndexChanged += new System.EventHandler(this.cbxMaQuanLy_SelectedIndexChanged);
            // 
            // frmXoaQuanLy
            // 
            this.AcceptButton = this.btnXoa;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.CancelButton = this.btnThoat;
            this.ClientSize = new System.Drawing.Size(292, 166);
            this.Controls.Add(this.cbxMaQuanLy);
            this.Controls.Add(this.cbxChucDanh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.cbxPhongBan);
            this.Controls.Add(this.txtTenQuanLy);
            this.Controls.Add(this.lblKhoi);
            this.Controls.Add(this.lblTenLop);
            this.Controls.Add(this.lblMaLop);
            this.Name = "frmXoaQuanLy";
            this.Text = "Xoa Quan Ly";
            this.Load += new System.EventHandler(this.frmXoaQuanLy_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxChucDanh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.ComboBox cbxPhongBan;
        private System.Windows.Forms.TextBox txtTenQuanLy;
        private System.Windows.Forms.Label lblKhoi;
        private System.Windows.Forms.Label lblTenLop;
        private System.Windows.Forms.Label lblMaLop;
        private System.Windows.Forms.ComboBox cbxMaQuanLy;
    }
}