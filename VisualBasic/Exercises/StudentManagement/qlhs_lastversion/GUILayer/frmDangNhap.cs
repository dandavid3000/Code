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
    public partial class frmDangNhap : Form
    {
        private bool _hSDangNhapThanhCong;
        private bool _qLDangNhapThanhCong;
        private string _taiKhoan;

        public string TaiKhoan
        {
            get { return _taiKhoan; }
            set { _taiKhoan = value; }
        }

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

        public frmDangNhap()
        {
            InitializeComponent();            
        }
        
        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            HocSinhBUS hsBUS = new HocSinhBUS();
            QuanLyBUS qlBUS = new QuanLyBUS();
            string taikhoan = txtTaiKhoan.Text;
            string password = txtPassword.Text;
            for (int i = taikhoan.Length; i < 10; i++)
                taikhoan += " ";
            for (int j = password.Length; j < 10; j++)
                password += " ";
            _hSDangNhapThanhCong = hsBUS.KTTaiKhoan(taikhoan, password);
            _qLDangNhapThanhCong = qlBUS.KTTaiKhoan(taikhoan, password);
            if ((_hSDangNhapThanhCong) || (_qLDangNhapThanhCong))
            {
                _taiKhoan = taikhoan;
                QuanLy ql = new QuanLy();
                QuanLyService qlService = new QuanLyService();
                ql = qlService.GetByMaQuanLy(_taiKhoan);
                if (ql != null)
                {
                    ChucDanh cd = new ChucDanh();
                    ChucDanhService cdService = new ChucDanhService();
                    cd = cdService.GetByMaChucDanh(ql.MaChucDanh);
                    string str = "Xin chào: " + cd.TenChucDanh + " " + ql.HoTenQuanLy;
                    MessageBox.Show(str);
                }

                HocSinh hs = new HocSinh();
                HocSinhService hsService = new HocSinhService();
                hs = hsService.GetByMaHocSinh(_taiKhoan);
                if (hs != null)
                {
                    string str = "Xin chào: " + hs.HoTenHocSinh;
                    MessageBox.Show(str);
                }
                this.Close();
            }
            else
                MessageBox.Show("Tài khoản hoặc password không hợp lệ");
        }        
    }
}