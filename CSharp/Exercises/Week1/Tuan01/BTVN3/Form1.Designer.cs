namespace BTVN3
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
            this.btnTinhTBC = new System.Windows.Forms.Button();
            this.lblDaySo = new System.Windows.Forms.Label();
            this.txtDaySo = new System.Windows.Forms.TextBox();
            this.lblKetQua = new System.Windows.Forms.Label();
            this.txtKetQua = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnTinhTBC
            // 
            this.btnTinhTBC.Location = new System.Drawing.Point(31, 76);
            this.btnTinhTBC.Name = "btnTinhTBC";
            this.btnTinhTBC.Size = new System.Drawing.Size(199, 33);
            this.btnTinhTBC.TabIndex = 0;
            this.btnTinhTBC.Text = "Tinh Trung Binh Cong";
            this.btnTinhTBC.UseVisualStyleBackColor = true;
            this.btnTinhTBC.Click += new System.EventHandler(this.btnTinhTBC_Click);
            // 
            // lblDaySo
            // 
            this.lblDaySo.AutoSize = true;
            this.lblDaySo.Location = new System.Drawing.Point(24, 26);
            this.lblDaySo.Name = "lblDaySo";
            this.lblDaySo.Size = new System.Drawing.Size(42, 13);
            this.lblDaySo.TabIndex = 1;
            this.lblDaySo.Text = "Dãy Số";
            // 
            // txtDaySo
            // 
            this.txtDaySo.Location = new System.Drawing.Point(91, 23);
            this.txtDaySo.Name = "txtDaySo";
            this.txtDaySo.Size = new System.Drawing.Size(139, 20);
            this.txtDaySo.TabIndex = 2;
            // 
            // lblKetQua
            // 
            this.lblKetQua.AutoSize = true;
            this.lblKetQua.Location = new System.Drawing.Point(24, 169);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(46, 13);
            this.lblKetQua.TabIndex = 1;
            this.lblKetQua.Text = "Kết Quả";
            // 
            // txtKetQua
            // 
            this.txtKetQua.Location = new System.Drawing.Point(91, 166);
            this.txtKetQua.Name = "txtKetQua";
            this.txtKetQua.Size = new System.Drawing.Size(139, 20);
            this.txtKetQua.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 225);
            this.Controls.Add(this.txtKetQua);
            this.Controls.Add(this.txtDaySo);
            this.Controls.Add(this.lblKetQua);
            this.Controls.Add(this.lblDaySo);
            this.Controls.Add(this.btnTinhTBC);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTinhTBC;
        private System.Windows.Forms.Label lblDaySo;
        private System.Windows.Forms.TextBox txtDaySo;
        private System.Windows.Forms.Label lblKetQua;
        private System.Windows.Forms.TextBox txtKetQua;
    }
}

