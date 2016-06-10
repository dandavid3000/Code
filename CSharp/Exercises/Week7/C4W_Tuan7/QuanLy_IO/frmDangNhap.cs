using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLy_IO
{
    public partial class frmDangNhap : Form
    {
        //Ability & Property
        private bool _dangNhapThanhCong = false;

        public bool DangNhapThanhCong
        {
            get { return _dangNhapThanhCong; }
            set { _dangNhapThanhCong = value; }
        }

        private Users _user;

        public Users User
        {
            get { return _user; }
            set { _user = value; }
        }

        //Phương Thức
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (Users.Authentication(txtTaiKhoan.Text, txtMatKhau.Text))
            {
                this.DangNhapThanhCong = true;
                this.User = new Users(txtTaiKhoan.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Tai khoan hoac mat khau khong hop le");
            }
        }
    }
}