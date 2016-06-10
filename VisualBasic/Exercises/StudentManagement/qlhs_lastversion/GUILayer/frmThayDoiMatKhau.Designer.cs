namespace Do_An_Cong_Ty
{
    partial class frmThayDoiMatKhau
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
            this.btnHuyBo = new System.Windows.Forms.Button();
            this.txtPasswordMoi = new System.Windows.Forms.TextBox();
            this.txtPasswordCu = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblTaiKhoan = new System.Windows.Forms.Label();
            this.btnDongY = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtNhapLai = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnHuyBo
            // 
            this.btnHuyBo.Location = new System.Drawing.Point(242, 8);
            this.btnHuyBo.Margin = new System.Windows.Forms.Padding(4);
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(100, 28);
            this.btnHuyBo.TabIndex = 1;
            this.btnHuyBo.Text = "Hủy Bỏ";
            this.btnHuyBo.UseVisualStyleBackColor = true;
            this.btnHuyBo.Click += new System.EventHandler(this.btnHuyBo_Click);
            // 
            // txtPasswordMoi
            // 
            this.txtPasswordMoi.Location = new System.Drawing.Point(164, 54);
            this.txtPasswordMoi.Name = "txtPasswordMoi";
            this.txtPasswordMoi.PasswordChar = '*';
            this.txtPasswordMoi.Size = new System.Drawing.Size(156, 20);
            this.txtPasswordMoi.TabIndex = 2;
            // 
            // txtPasswordCu
            // 
            this.txtPasswordCu.Location = new System.Drawing.Point(164, 17);
            this.txtPasswordCu.Name = "txtPasswordCu";
            this.txtPasswordCu.PasswordChar = '*';
            this.txtPasswordCu.Size = new System.Drawing.Size(156, 20);
            this.txtPasswordCu.TabIndex = 1;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(74, 57);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(72, 13);
            this.lblPassword.TabIndex = 0;
            this.lblPassword.Text = "Password mới";
            // 
            // lblTaiKhoan
            // 
            this.lblTaiKhoan.AutoSize = true;
            this.lblTaiKhoan.Location = new System.Drawing.Point(73, 20);
            this.lblTaiKhoan.Name = "lblTaiKhoan";
            this.lblTaiKhoan.Size = new System.Drawing.Size(68, 13);
            this.lblTaiKhoan.TabIndex = 0;
            this.lblTaiKhoan.Text = "Password cũ";
            // 
            // btnDongY
            // 
            this.btnDongY.Location = new System.Drawing.Point(50, 8);
            this.btnDongY.Margin = new System.Windows.Forms.Padding(4);
            this.btnDongY.Name = "btnDongY";
            this.btnDongY.Size = new System.Drawing.Size(100, 28);
            this.btnDongY.TabIndex = 0;
            this.btnDongY.Text = "Đồng Ý";
            this.btnDongY.UseVisualStyleBackColor = true;
            this.btnDongY.Click += new System.EventHandler(this.btnDongY_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDongY);
            this.panel2.Controls.Add(this.btnHuyBo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 117);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(392, 45);
            this.panel2.TabIndex = 4;
            // 
            // txtNhapLai
            // 
            this.txtNhapLai.Location = new System.Drawing.Point(164, 90);
            this.txtNhapLai.Name = "txtNhapLai";
            this.txtNhapLai.PasswordChar = '*';
            this.txtNhapLai.Size = new System.Drawing.Size(156, 20);
            this.txtNhapLai.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(73, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Nhập lại";
            // 
            // frmThayDoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(392, 162);
            this.Controls.Add(this.txtNhapLai);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPasswordMoi);
            this.Controls.Add(this.txtPasswordCu);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblTaiKhoan);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.Name = "frmThayDoiMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thay Doi Mat Khau";
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHuyBo;
        private System.Windows.Forms.TextBox txtPasswordMoi;
        private System.Windows.Forms.TextBox txtPasswordCu;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblTaiKhoan;
        private System.Windows.Forms.Button btnDongY;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtNhapLai;
        private System.Windows.Forms.Label label5;


    }
}