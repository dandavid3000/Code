using System;
using System.Windows.Forms;

namespace BaiTap02
{
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
        }
        public string NguoiChoi01
        {
            get { return txtNguoiChoi01.Text; }
        }
        public string NguoiChoi02
        {
            get { return txtNguoiChoi02.Text; }
        }
        private void txtNguoiChoi_TextChanged(object sender, EventArgs e)
        {
            if (txtNguoiChoi01.Text.Trim() == string.Empty
                || txtNguoiChoi02.Text.Trim() == string.Empty
                || txtNguoiChoi01.Text.Trim() == txtNguoiChoi02.Text.Trim())
                btnBD.Enabled = false;
            else
                btnBD.Enabled = true;
        }

        private void btnT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}