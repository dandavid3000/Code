namespace _6k3021
{
    partial class frmTaoDeThi
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
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnDoc = new System.Windows.Forms.Button();
            this.btnGhi = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lvwNoiDungCauHoi = new System.Windows.Forms.ListView();
            this.ucCauHoiTracNghiem1 = new _6k3021.ucCauHoiTracNghiem();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(38, 358);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(130, 358);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(224, 358);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(75, 23);
            this.btnCapNhat.TabIndex = 1;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnDoc
            // 
            this.btnDoc.Location = new System.Drawing.Point(527, 358);
            this.btnDoc.Name = "btnDoc";
            this.btnDoc.Size = new System.Drawing.Size(75, 23);
            this.btnDoc.TabIndex = 1;
            this.btnDoc.Text = "Đọc file";
            this.btnDoc.UseVisualStyleBackColor = true;
            this.btnDoc.Click += new System.EventHandler(this.btnDoc_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Location = new System.Drawing.Point(619, 358);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(75, 23);
            this.btnGhi.TabIndex = 1;
            this.btnGhi.Text = "Ghi file";
            this.btnGhi.UseVisualStyleBackColor = true;
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lvwNoiDungCauHoi);
            this.panel1.Location = new System.Drawing.Point(18, 417);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(698, 266);
            this.panel1.TabIndex = 2;
            // 
            // lvwNoiDungCauHoi
            // 
            this.lvwNoiDungCauHoi.Location = new System.Drawing.Point(3, 3);
            this.lvwNoiDungCauHoi.Name = "lvwNoiDungCauHoi";
            this.lvwNoiDungCauHoi.Size = new System.Drawing.Size(692, 260);
            this.lvwNoiDungCauHoi.TabIndex = 3;
            this.lvwNoiDungCauHoi.UseCompatibleStateImageBehavior = false;
            this.lvwNoiDungCauHoi.View = System.Windows.Forms.View.Details;
            // 
            // ucCauHoiTracNghiem1
            // 
            this.ucCauHoiTracNghiem1.CauHoi = "";
            this.ucCauHoiTracNghiem1.DapAnA = "";
            this.ucCauHoiTracNghiem1.DapAnB = "";
            this.ucCauHoiTracNghiem1.DapAnC = "";
            this.ucCauHoiTracNghiem1.DapAnD = "";
            this.ucCauHoiTracNghiem1.DapAnDuocChon = "";
            this.ucCauHoiTracNghiem1.Location = new System.Drawing.Point(12, 12);
            this.ucCauHoiTracNghiem1.Name = "ucCauHoiTracNghiem1";
            this.ucCauHoiTracNghiem1.Size = new System.Drawing.Size(710, 340);
            this.ucCauHoiTracNghiem1.TabIndex = 0;
            // 
            // frmTaoDeThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 696);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnGhi);
            this.Controls.Add(this.btnDoc);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.ucCauHoiTracNghiem1);
            this.Name = "frmTaoDeThi";
            this.Text = "frmTaoDeThi";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ucCauHoiTracNghiem ucCauHoiTracNghiem1;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnDoc;
        private System.Windows.Forms.Button btnGhi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lvwNoiDungCauHoi;
    }
}