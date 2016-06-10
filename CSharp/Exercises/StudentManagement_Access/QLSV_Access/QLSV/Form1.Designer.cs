namespace QLSV
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGiupDo = new System.Windows.Forms.Button();
            this.btnHienThi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.crvDanhSach = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnGiupDo);
            this.panel1.Controls.Add(this.btnHienThi);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboLop);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(702, 51);
            this.panel1.TabIndex = 0;
            // 
            // btnGiupDo
            // 
            this.helpProvider1.SetHelpKeyword(this.btnGiupDo, "QuanLyLop.mht");
            this.helpProvider1.SetHelpNavigator(this.btnGiupDo, System.Windows.Forms.HelpNavigator.TableOfContents);
            this.btnGiupDo.Location = new System.Drawing.Point(547, 13);
            this.btnGiupDo.Name = "btnGiupDo";
            this.helpProvider1.SetShowHelp(this.btnGiupDo, true);
            this.btnGiupDo.Size = new System.Drawing.Size(75, 23);
            this.btnGiupDo.TabIndex = 3;
            this.btnGiupDo.Text = "Giúp đỡ";
            this.btnGiupDo.UseVisualStyleBackColor = true;
            this.btnGiupDo.Click += new System.EventHandler(this.btnGiupDo_Click);
            // 
            // btnHienThi
            // 
            this.helpProvider1.SetHelpString(this.btnHienThi, "Bam vao day de hien thi");
            this.btnHienThi.Location = new System.Drawing.Point(453, 12);
            this.btnHienThi.Name = "btnHienThi";
            this.helpProvider1.SetShowHelp(this.btnHienThi, true);
            this.btnHienThi.Size = new System.Drawing.Size(75, 23);
            this.btnHienThi.TabIndex = 2;
            this.btnHienThi.Text = "Hiển Thị";
            this.btnHienThi.UseVisualStyleBackColor = true;
            this.btnHienThi.Click += new System.EventHandler(this.btnHienThi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lớp";
            // 
            // cboLop
            // 
            this.cboLop.FormattingEnabled = true;
            this.cboLop.Location = new System.Drawing.Point(59, 13);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(388, 21);
            this.cboLop.TabIndex = 0;
            // 
            // crvDanhSach
            // 
            this.crvDanhSach.ActiveViewIndex = -1;
            this.crvDanhSach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvDanhSach.Location = new System.Drawing.Point(0, 51);
            this.crvDanhSach.Name = "crvDanhSach";
            this.crvDanhSach.SelectionFormula = "";
            this.crvDanhSach.Size = new System.Drawing.Size(702, 378);
            this.crvDanhSach.TabIndex = 1;
            this.crvDanhSach.ViewTimeSelectionFormula = "";
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "D:\\Hcmus\\NMCNPM\\QLSV\\QLSV\\bin\\Debug\\GiupDo\\GiupDo.chm";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 429);
            this.Controls.Add(this.crvDanhSach);
            this.Controls.Add(this.panel1);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnHienThi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboLop;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvDanhSach;
        private System.Windows.Forms.Button btnGiupDo;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}

