namespace Do_An_Cong_Ty
{
    partial class frmXoaLop
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
            this.btnXoa = new System.Windows.Forms.Button();
            this.cbxKhoi = new System.Windows.Forms.ComboBox();
            this.txtTenLop = new System.Windows.Forms.TextBox();
            this.lblKhoi = new System.Windows.Forms.Label();
            this.lblTenLop = new System.Windows.Forms.Label();
            this.lblMaLop = new System.Windows.Forms.Label();
            this.cbxMaLop = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnThoat
            // 
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Location = new System.Drawing.Point(151, 119);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(29, 119);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // cbxKhoi
            // 
            this.cbxKhoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxKhoi.FormattingEnabled = true;
            this.cbxKhoi.Location = new System.Drawing.Point(89, 81);
            this.cbxKhoi.Name = "cbxKhoi";
            this.cbxKhoi.Size = new System.Drawing.Size(137, 21);
            this.cbxKhoi.TabIndex = 3;
            this.cbxKhoi.SelectedIndexChanged += new System.EventHandler(this.cbxKhoi_SelectedIndexChanged);
            // 
            // txtTenLop
            // 
            this.txtTenLop.Enabled = false;
            this.txtTenLop.Location = new System.Drawing.Point(89, 53);
            this.txtTenLop.Name = "txtTenLop";
            this.txtTenLop.Size = new System.Drawing.Size(137, 20);
            this.txtTenLop.TabIndex = 2;
            // 
            // lblKhoi
            // 
            this.lblKhoi.AutoSize = true;
            this.lblKhoi.Location = new System.Drawing.Point(26, 84);
            this.lblKhoi.Name = "lblKhoi";
            this.lblKhoi.Size = new System.Drawing.Size(28, 13);
            this.lblKhoi.TabIndex = 0;
            this.lblKhoi.Text = "Khối";
            // 
            // lblTenLop
            // 
            this.lblTenLop.AutoSize = true;
            this.lblTenLop.Location = new System.Drawing.Point(26, 56);
            this.lblTenLop.Name = "lblTenLop";
            this.lblTenLop.Size = new System.Drawing.Size(47, 13);
            this.lblTenLop.TabIndex = 0;
            this.lblTenLop.Text = "Tên Lớp";
            // 
            // lblMaLop
            // 
            this.lblMaLop.AutoSize = true;
            this.lblMaLop.Location = new System.Drawing.Point(26, 28);
            this.lblMaLop.Name = "lblMaLop";
            this.lblMaLop.Size = new System.Drawing.Size(43, 13);
            this.lblMaLop.TabIndex = 0;
            this.lblMaLop.Text = "Mã Lớp";
            // 
            // cbxMaLop
            // 
            this.cbxMaLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMaLop.FormattingEnabled = true;
            this.cbxMaLop.Location = new System.Drawing.Point(89, 25);
            this.cbxMaLop.Name = "cbxMaLop";
            this.cbxMaLop.Size = new System.Drawing.Size(137, 21);
            this.cbxMaLop.TabIndex = 1;
            this.cbxMaLop.SelectedIndexChanged += new System.EventHandler(this.cbxMaLop_SelectedIndexChanged);
            // 
            // frmXoaLop
            // 
            this.AcceptButton = this.btnXoa;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.CancelButton = this.btnThoat;
            this.ClientSize = new System.Drawing.Size(252, 166);
            this.Controls.Add(this.cbxMaLop);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.cbxKhoi);
            this.Controls.Add(this.txtTenLop);
            this.Controls.Add(this.lblKhoi);
            this.Controls.Add(this.lblTenLop);
            this.Controls.Add(this.lblMaLop);
            this.Name = "frmXoaLop";
            this.Text = "Xoa Lop";
            this.Load += new System.EventHandler(this.frmXoaLop_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.ComboBox cbxKhoi;
        private System.Windows.Forms.TextBox txtTenLop;
        private System.Windows.Forms.Label lblKhoi;
        private System.Windows.Forms.Label lblTenLop;
        private System.Windows.Forms.Label lblMaLop;
        private System.Windows.Forms.ComboBox cbxMaLop;
    }
}