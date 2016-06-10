using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace QuanLy_IO
{
    public partial class frmThayDoiMatKhau : Form
    {
        private Users _user;

        public Users User
        {
            get { return _user; }
            set { _user = value; }
        }

        public frmThayDoiMatKhau()
        {
            InitializeComponent();
        }

        private void tbnBoQua_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThayDoi_Click(object sender, EventArgs e)
        {
            //frmQuanLy frm = new frmQuanLy();        
            //Users user = frm.User;
            if (txtMKCu.Text == _user.Password)
            {
                if (txtMKMoi.Text == txtNhapLai.Text)
                {
                    _user.Password = txtMKMoi.Text;
                    FileStream theFile = File.Open("../../users/"+ _user.UserName + ".txt",FileMode.Open,FileAccess.Write);
                    StreamWriter writer = new StreamWriter(theFile);
                    writer.WriteLine(_user.UserName);
                    writer.WriteLine(_user.Password);
                    writer.WriteLine(_user.FullName);
                    writer.WriteLine(_user.Group);

                    MessageBox.Show("Thay đổi mật khẩu thành công");

                    writer.Close();
                    theFile.Close();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nhập Lại không đúng");
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu cũ không hợp lệ");
            }
        }
    }
}