namespace Do_An_Cong_Ty
{
    partial class frmXoaThongTinHocSinh
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
            this.btnSua = new System.Windows.Forms.Button();
            this.txtHoTenHocSinh = new System.Windows.Forms.TextBox();
            this.lblTenHocSinh = new System.Windows.Forms.Label();
            this.maskMaHocSinh = new System.Windows.Forms.MaskedTextBox();
            this.lblMaHocSinh = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnThoat
            // 
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Location = new System.Drawing.Point(194, 80);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 10;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(27, 79);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 9;
            this.btnSua.Text = "Xóa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // txtHoTenHocSinh
            // 
            this.txtHoTenHocSinh.Enabled = false;
            this.txtHoTenHocSinh.Location = new System.Drawing.Point(119, 41);
            this.txtHoTenHocSinh.Name = "txtHoTenHocSinh";
            this.txtHoTenHocSinh.Size = new System.Drawing.Size(150, 20);
            this.txtHoTenHocSinh.TabIndex = 8;
            // 
            // lblTenHocSinh
            // 
            this.lblTenHocSinh.AutoSize = true;
            this.lblTenHocSinh.Location = new System.Drawing.Point(24, 44);
            this.lblTenHocSinh.Name = "lblTenHocSinh";
            this.lblTenHocSinh.Size = new System.Drawing.Size(82, 13);
            this.lblTenHocSinh.TabIndex = 5;
            this.lblTenHocSinh.Text = "Họ tên học sinh";
            // 
            // maskMaHocSinh
            // 
            this.maskMaHocSinh.Location = new System.Drawing.Point(119, 13);
            this.maskMaHocSinh.Name = "maskMaHocSinh";
            this.maskMaHocSinh.Size = new System.Drawing.Size(150, 20);
            this.maskMaHocSinh.TabIndex = 7;
            this.maskMaHocSinh.TextChanged += new System.EventHandler(this.maskMaHocSinh_TextChanged);
            // 
            // lblMaHocSinh
            // 
            this.lblMaHocSinh.AutoSize = true;
            this.lblMaHocSinh.Location = new System.Drawing.Point(24, 16);
            this.lblMaHocSinh.Name = "lblMaHocSinh";
            this.lblMaHocSinh.Size = new System.Drawing.Size(65, 13);
            this.lblMaHocSinh.TabIndex = 6;
            this.lblMaHocSinh.Text = "Mã học sinh";
            // 
            // frmXoaThongTinHocSinh
            // 
            this.AcceptButton = this.btnSua;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.CancelButton = this.btnThoat;
            this.ClientSize = new System.Drawing.Size(292, 116);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.txtHoTenHocSinh);
            this.Controls.Add(this.lblTenHocSinh);
            this.Controls.Add(this.maskMaHocSinh);
            this.Controls.Add(this.lblMaHocSinh);
            this.MaximumSize = new System.Drawing.Size(300, 150);
            this.MinimumSize = new System.Drawing.Size(300, 150);
            this.Name = "frmXoaThongTinHocSinh";
            this.Text = "Xoa Thong Tin Hoc Sinh";
            this.Load += new System.EventHandler(this.frmXoaThongTinHocSinh_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.TextBox txtHoTenHocSinh;
        private System.Windows.Forms.Label lblTenHocSinh;
        private System.Windows.Forms.MaskedTextBox maskMaHocSinh;
        private System.Windows.Forms.Label lblMaHocSinh;
    }
}