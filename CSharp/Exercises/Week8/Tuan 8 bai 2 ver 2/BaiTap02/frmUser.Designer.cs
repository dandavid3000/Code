namespace BaiTap02
{
    partial class frmUser
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNguoiChoi01 = new System.Windows.Forms.TextBox();
            this.txtNguoiChoi02 = new System.Windows.Forms.TextBox();
            this.btnBD = new System.Windows.Forms.Button();
            this.btnT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Người chơi 01";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Người chơi 02";
            // 
            // txtNguoiChoi01
            // 
            this.txtNguoiChoi01.Location = new System.Drawing.Point(113, 13);
            this.txtNguoiChoi01.Margin = new System.Windows.Forms.Padding(4);
            this.txtNguoiChoi01.MaxLength = 25;
            this.txtNguoiChoi01.Name = "txtNguoiChoi01";
            this.txtNguoiChoi01.Size = new System.Drawing.Size(208, 25);
            this.txtNguoiChoi01.TabIndex = 2;
            this.txtNguoiChoi01.TextChanged += new System.EventHandler(this.txtNguoiChoi_TextChanged);
            // 
            // txtNguoiChoi02
            // 
            this.txtNguoiChoi02.Location = new System.Drawing.Point(113, 54);
            this.txtNguoiChoi02.Margin = new System.Windows.Forms.Padding(4);
            this.txtNguoiChoi02.MaxLength = 25;
            this.txtNguoiChoi02.Name = "txtNguoiChoi02";
            this.txtNguoiChoi02.Size = new System.Drawing.Size(208, 25);
            this.txtNguoiChoi02.TabIndex = 3;
            this.txtNguoiChoi02.TextChanged += new System.EventHandler(this.txtNguoiChoi_TextChanged);
            // 
            // btnBD
            // 
            this.btnBD.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnBD.Enabled = false;
            this.btnBD.Location = new System.Drawing.Point(158, 86);
            this.btnBD.Name = "btnBD";
            this.btnBD.Size = new System.Drawing.Size(75, 23);
            this.btnBD.TabIndex = 4;
            this.btnBD.Text = "Bắt đầu";
            this.btnBD.UseVisualStyleBackColor = true;
            // 
            // btnT
            // 
            this.btnT.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnT.Location = new System.Drawing.Point(246, 86);
            this.btnT.Name = "btnT";
            this.btnT.Size = new System.Drawing.Size(75, 23);
            this.btnT.TabIndex = 5;
            this.btnT.Text = "Thoát";
            this.btnT.UseVisualStyleBackColor = true;
            this.btnT.Click += new System.EventHandler(this.btnT_Click);
            // 
            // frmUser
            // 
            this.AcceptButton = this.btnBD;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CancelButton = this.btnT;
            this.ClientSize = new System.Drawing.Size(333, 115);
            this.Controls.Add(this.btnT);
            this.Controls.Add(this.btnBD);
            this.Controls.Add(this.txtNguoiChoi02);
            this.Controls.Add(this.txtNguoiChoi01);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nhập tên người chơi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNguoiChoi01;
        private System.Windows.Forms.TextBox txtNguoiChoi02;
        private System.Windows.Forms.Button btnBD;
        private System.Windows.Forms.Button btnT;
    }
}