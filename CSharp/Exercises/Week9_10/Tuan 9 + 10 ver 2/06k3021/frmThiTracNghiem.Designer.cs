namespace _6k3021
{
    partial class frmThiTracNghiem
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDuongDan = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnBatDauThi = new System.Windows.Forms.Button();
            this.btnKetThuc = new System.Windows.Forms.Button();
            this.btnXemKetQua = new System.Windows.Forms.Button();
            this.lblPhut = new System.Windows.Forms.Label();
            this.lblGiay = new System.Windows.Forms.Label();
            this.lblHaiCham = new System.Windows.Forms.Label();
            this.btnCauTiepTheo = new System.Windows.Forms.Button();
            this.btnCauTruocDo = new System.Windows.Forms.Button();
            this.DongHo = new System.Windows.Forms.Timer(this.components);
            this.ucCauHoiTracNghiem1 = new _6k3021.ucCauHoiTracNghiem();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đường dẫn : ";
            // 
            // txtDuongDan
            // 
            this.txtDuongDan.Location = new System.Drawing.Point(102, 16);
            this.txtDuongDan.Name = "txtDuongDan";
            this.txtDuongDan.Size = new System.Drawing.Size(498, 20);
            this.txtDuongDan.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(615, 14);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse..";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnBatDauThi
            // 
            this.btnBatDauThi.Location = new System.Drawing.Point(40, 57);
            this.btnBatDauThi.Name = "btnBatDauThi";
            this.btnBatDauThi.Size = new System.Drawing.Size(121, 23);
            this.btnBatDauThi.TabIndex = 2;
            this.btnBatDauThi.Text = "Bắt đầu thi";
            this.btnBatDauThi.UseVisualStyleBackColor = true;
            this.btnBatDauThi.Click += new System.EventHandler(this.btnBatDauThi_Click);
            // 
            // btnKetThuc
            // 
            this.btnKetThuc.Location = new System.Drawing.Point(178, 57);
            this.btnKetThuc.Name = "btnKetThuc";
            this.btnKetThuc.Size = new System.Drawing.Size(121, 23);
            this.btnKetThuc.TabIndex = 2;
            this.btnKetThuc.Text = "Kết thúc";
            this.btnKetThuc.UseVisualStyleBackColor = true;
            this.btnKetThuc.Click += new System.EventHandler(this.btnKetThuc_Click);
            // 
            // btnXemKetQua
            // 
            this.btnXemKetQua.Location = new System.Drawing.Point(318, 57);
            this.btnXemKetQua.Name = "btnXemKetQua";
            this.btnXemKetQua.Size = new System.Drawing.Size(121, 23);
            this.btnXemKetQua.TabIndex = 2;
            this.btnXemKetQua.Text = "Xem kết quả";
            this.btnXemKetQua.UseVisualStyleBackColor = true;
            this.btnXemKetQua.Click += new System.EventHandler(this.btnXemKetQua_Click);
            // 
            // lblPhut
            // 
            this.lblPhut.AutoSize = true;
            this.lblPhut.BackColor = System.Drawing.SystemColors.MenuBar;
            this.lblPhut.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblPhut.Location = new System.Drawing.Point(621, 67);
            this.lblPhut.MaximumSize = new System.Drawing.Size(52, 47);
            this.lblPhut.Name = "lblPhut";
            this.lblPhut.Size = new System.Drawing.Size(19, 13);
            this.lblPhut.TabIndex = 0;
            this.lblPhut.Text = "00";
            // 
            // lblGiay
            // 
            this.lblGiay.AutoSize = true;
            this.lblGiay.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblGiay.Location = new System.Drawing.Point(662, 67);
            this.lblGiay.Name = "lblGiay";
            this.lblGiay.Size = new System.Drawing.Size(19, 13);
            this.lblGiay.TabIndex = 0;
            this.lblGiay.Text = "00";
            // 
            // lblHaiCham
            // 
            this.lblHaiCham.AutoSize = true;
            this.lblHaiCham.Location = new System.Drawing.Point(646, 67);
            this.lblHaiCham.Name = "lblHaiCham";
            this.lblHaiCham.Size = new System.Drawing.Size(10, 13);
            this.lblHaiCham.TabIndex = 0;
            this.lblHaiCham.Text = ":";
            // 
            // btnCauTiepTheo
            // 
            this.btnCauTiepTheo.Location = new System.Drawing.Point(189, 463);
            this.btnCauTiepTheo.Name = "btnCauTiepTheo";
            this.btnCauTiepTheo.Size = new System.Drawing.Size(121, 23);
            this.btnCauTiepTheo.TabIndex = 2;
            this.btnCauTiepTheo.Text = "Câu tiếp theo";
            this.btnCauTiepTheo.UseVisualStyleBackColor = true;
            this.btnCauTiepTheo.Click += new System.EventHandler(this.btnCauTiepTheo_Click);
            // 
            // btnCauTruocDo
            // 
            this.btnCauTruocDo.Location = new System.Drawing.Point(351, 463);
            this.btnCauTruocDo.Name = "btnCauTruocDo";
            this.btnCauTruocDo.Size = new System.Drawing.Size(121, 23);
            this.btnCauTruocDo.TabIndex = 2;
            this.btnCauTruocDo.Text = "Câu trước đó";
            this.btnCauTruocDo.UseVisualStyleBackColor = true;
            this.btnCauTruocDo.Click += new System.EventHandler(this.btnCauTruocDo_Click);
            // 
            // DongHo
            // 
            this.DongHo.Tick += new System.EventHandler(this.DongHo_Tick);
            // 
            // ucCauHoiTracNghiem1
            // 
            this.ucCauHoiTracNghiem1.CauHoi = "";
            this.ucCauHoiTracNghiem1.DapAnA = "";
            this.ucCauHoiTracNghiem1.DapAnB = "";
            this.ucCauHoiTracNghiem1.DapAnC = "";
            this.ucCauHoiTracNghiem1.DapAnD = "";
            this.ucCauHoiTracNghiem1.DapAnDuocChon = "";
            this.ucCauHoiTracNghiem1.Location = new System.Drawing.Point(0, 95);
            this.ucCauHoiTracNghiem1.Name = "ucCauHoiTracNghiem1";
            this.ucCauHoiTracNghiem1.Size = new System.Drawing.Size(710, 340);
            this.ucCauHoiTracNghiem1.TabIndex = 3;
            // 
            // frmThiTracNghiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 511);
            this.Controls.Add(this.ucCauHoiTracNghiem1);
            this.Controls.Add(this.btnXemKetQua);
            this.Controls.Add(this.btnKetThuc);
            this.Controls.Add(this.btnCauTruocDo);
            this.Controls.Add(this.btnCauTiepTheo);
            this.Controls.Add(this.btnBatDauThi);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtDuongDan);
            this.Controls.Add(this.lblGiay);
            this.Controls.Add(this.lblPhut);
            this.Controls.Add(this.lblHaiCham);
            this.Controls.Add(this.label1);
            this.Name = "frmThiTracNghiem";
            this.Text = "Thi trắc nghiệm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDuongDan;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnBatDauThi;
        private System.Windows.Forms.Button btnKetThuc;
        private System.Windows.Forms.Button btnXemKetQua;
        private System.Windows.Forms.Label lblPhut;
        private System.Windows.Forms.Label lblGiay;
        private System.Windows.Forms.Label lblHaiCham;
        private ucCauHoiTracNghiem ucCauHoiTracNghiem1;
        private System.Windows.Forms.Button btnCauTiepTheo;
        private System.Windows.Forms.Button btnCauTruocDo;
        private System.Windows.Forms.Timer DongHo;
    }
}