namespace _6k3021
{
    partial class frmMain
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
            this.tạoĐềThiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thiTrắcNghiệmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tạoĐềThiToolStripMenuItem,
            this.thiTrắcNghiệmToolStripMenuItem,
            this.thoátToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(280, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tạoĐềThiToolStripMenuItem
            // 
            this.tạoĐềThiToolStripMenuItem.Name = "tạoĐềThiToolStripMenuItem";
            this.tạoĐềThiToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.tạoĐềThiToolStripMenuItem.Text = "Tạo đề thi";
            this.tạoĐềThiToolStripMenuItem.Click += new System.EventHandler(this.tạoĐềThiToolStripMenuItem_Click);
            // 
            // thiTrắcNghiệmToolStripMenuItem
            // 
            this.thiTrắcNghiệmToolStripMenuItem.Name = "thiTrắcNghiệmToolStripMenuItem";
            this.thiTrắcNghiệmToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.thiTrắcNghiệmToolStripMenuItem.Text = "Thi trắc nghiệm";
            this.thiTrắcNghiệmToolStripMenuItem.Click += new System.EventHandler(this.thiTrắcNghiệmToolStripMenuItem_Click);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.thoátToolStripMenuItem.Text = "Thoát";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 88);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Thi trắc nghiệm toán học";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tạoĐềThiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thiTrắcNghiệmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
    }
}

