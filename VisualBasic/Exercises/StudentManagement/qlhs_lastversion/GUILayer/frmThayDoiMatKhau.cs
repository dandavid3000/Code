using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QuanLyHocSinhPTNK.Services;
using QuanLyHocSinhPTNK.Entities;
using BUSLayer;

namespace Do_An_Cong_Ty
{
    public partial class frmThayDoiMatKhau : Form
    {
        private string _taiKhoan;
        private bool _hSDangNhapThanhCong;
        private bool _qLDangNhapThanhCong;

        public bool QLDangNhapThanhCong
        {
            get { return _qLDangNhapThanhCong; }
            set { _qLDangNhapThanhCong = value; }
        }

        public bool HSDangNhapThanhCong
        {
            get { return _hSDangNhapThanhCong; }
            set { _hSDangNhapThanhCong = value; }
        }

        public string TaiKhoan
        {
            get { return _taiKhoan; }
            set { _taiKhoan = value; }
        }

        public frmThayDoiMatKhau()
        {
            InitializeComponent();            
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            for (int j = txtPasswordCu.Text.Length; j < 10; j++)
                txtPasswordCu.Text += " ";
            for (int i = txtNhapLai.Text.Length; i < 10; i++)
                txtNhapLai.Text += " ";
            for (int k = txtPasswordMoi.Text.Length; k < 10; k++)
                txtPasswordMoi.Text += " ";
            if (_hSDangNhapThanhCong)
            {
                HocSinh hs = new HocSinh();
                HocSinhBUS hsBUS = new HocSinhBUS();
                hs = hsBUS.LayHocSinh(_taiKhoan);
                if (hs.Password == txtPasswordCu.Text)
                {
                    if (txtPasswordMoi.Text == txtNhapLai.Text)
                    {
                        hs.Password = txtNhapLai.Text;                        
                        hsBUS.CapNhat(hs);
                        MessageBox.Show("Thay đổi mật khẩu thành công");
                        this.Close();
                    }
                    else
                        MessageBox.Show("Nhập lại sai");
                }
                else
                    MessageBox.Show("Password không hợp lệ");
            }
            else if (_qLDangNhapThanhCong)
            {
                QuanLy ql = new QuanLy();
                QuanLyBUS qlBUS = new QuanLyBUS();
                ql = qlBUS.LayQuanLy(_taiKhoan);
                if (ql.Password == txtPasswordCu.Text)
                {
                    if (txtPasswordMoi.Text == txtNhapLai.Text)
                    {
                        ql.Password = txtNhapLai.Text;                        
                        qlBUS.CapNhat(ql);
                        MessageBox.Show("Thay đổi mật khẩu thành công");
                        this.Close();
                    }
                    else
                        MessageBox.Show("Nhập lại sai");
                }
                else
                    MessageBox.Show("Password không hợp lệ");
            }
        }       
    }
}