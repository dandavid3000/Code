using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _6k3021
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void tạoĐềThiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTaoDeThi TaoDeThi = new frmTaoDeThi();
            TaoDeThi.ShowDialog();
        }

        private void thiTrắcNghiệmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThiTracNghiem ThiTracNghiem = new frmThiTracNghiem();
            ThiTracNghiem.ShowDialog();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}