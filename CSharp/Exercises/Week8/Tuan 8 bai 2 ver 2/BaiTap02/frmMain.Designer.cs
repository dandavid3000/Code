namespace BaiTap02
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.myToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnPlay = new System.Windows.Forms.ToolStripButton();
            this.btnHuongDan = new System.Windows.Forms.ToolStripLabel();
            this.btnThoat = new System.Windows.Forms.ToolStripLabel();
            this.myTimer = new System.Windows.Forms.Timer(this.components);
            this.myToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // myToolStrip
            // 
            this.myToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.myToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPlay,
            this.btnHuongDan,
            this.btnThoat});
            this.myToolStrip.Location = new System.Drawing.Point(0, 0);
            this.myToolStrip.Name = "myToolStrip";
            this.myToolStrip.Size = new System.Drawing.Size(284, 25);
            this.myToolStrip.TabIndex = 0;
            this.myToolStrip.Text = "myToolStrip";
            // 
            // btnPlay
            // 
            this.btnPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPlay.Image = ((System.Drawing.Image)(resources.GetObject("btnPlay.Image")));
            this.btnPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(51, 22);
            this.btnPlay.Text = "Bắt đầu";
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnHuongDan
            // 
            this.btnHuongDan.Name = "btnHuongDan";
            this.btnHuongDan.Size = new System.Drawing.Size(67, 22);
            this.btnHuongDan.Text = "Hướng dẫn";
            this.btnHuongDan.Click += new System.EventHandler(this.btnHuongDan_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(38, 22);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(284, 245);
            this.Controls.Add(this.myToolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Trò chơi Ping-Pong đơn giản";
            this.myToolStrip.ResumeLayout(false);
            this.myToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip myToolStrip;
        private System.Windows.Forms.ToolStripButton btnPlay;
        private System.Windows.Forms.Timer myTimer;
        private System.Windows.Forms.ToolStripLabel btnHuongDan;
        private System.Windows.Forms.ToolStripLabel btnThoat;
    }
}

