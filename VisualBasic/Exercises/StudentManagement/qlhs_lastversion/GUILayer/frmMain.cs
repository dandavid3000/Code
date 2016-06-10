using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QuanLyHocSinhPTNK.Services;
using QuanLyHocSinhPTNK.Entities;

namespace Do_An_Cong_Ty
{
    public partial class frmMain : Form
    {
        private int _chon = 0;
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

        public frmMain()
        {
            InitializeComponent();
        }


        private void radThongTinHocSinh_CheckedChanged(object sender, EventArgs e)
        {
            if (radTiepNhanHocSinh.Checked)
            {
                _chon = 1;
                radTiepNhanHocSinh.Checked = true;
                radDanhSachLop.Checked = false;
                radThayDoiMatKhau.Checked = false;
                radBaoCaoTongKet.Checked = false;
                radNhapDiem.Checked = false;
                radThayĐoiQuyDinh.Checked = false;               
                radTimKiemHocSinh.Checked = false;
            }
        }

        private void radThongTinVeDiem_CheckedChanged(object sender, EventArgs e)
        {
            if (radDanhSachLop.Checked)
            {
                _chon = 2;
                radDanhSachLop.Checked = true;
                radThayDoiMatKhau.Checked = false;
                radTiepNhanHocSinh.Checked = false;
                radBaoCaoTongKet.Checked = false;
                radNhapDiem.Checked = false;
                radThayĐoiQuyDinh.Checked = false;                     
            }
        }

        private void radNhapDiem_CheckedChanged(object sender, EventArgs e)
        {
            if (radNhapDiem.Checked)
            {
                _chon = 3;
                radNhapDiem.Checked = true;
                radDanhSachLop.Checked = false;
                radThayDoiMatKhau.Checked = false;
                radBaoCaoTongKet.Checked = false;
                radTiepNhanHocSinh.Checked = false;
                radThayĐoiQuyDinh.Checked = false;                
                radTimKiemHocSinh.Checked = false;
            }
        }

        private void radTimKiemHocSinh_CheckedChanged(object sender, EventArgs e)
        {
            if (radTimKiemHocSinh.Checked)
            {
                _chon = 4;
                radTimKiemHocSinh.Checked = true;
                radDanhSachLop.Checked = false;
                radThayDoiMatKhau.Checked = false;
                radBaoCaoTongKet.Checked = false;
                radTiepNhanHocSinh.Checked = false;
                radThayĐoiQuyDinh.Checked = false;                
                radNhapDiem.Checked = false;
            }
        }


        private void radThayDoiMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (radThayDoiMatKhau.Checked)
            {
                _chon = 5;
                radThayDoiMatKhau.Checked = true;
                radTiepNhanHocSinh.Checked = false;
                radDanhSachLop.Checked = false;
                radBaoCaoTongKet.Checked = false;
                radNhapDiem.Checked = false;
                radThayĐoiQuyDinh.Checked = false;                
                radTimKiemHocSinh.Checked = false;
            }
        }       

        private void radBaoCaoTongKet_CheckedChanged(object sender, EventArgs e)
        {
            if (radBaoCaoTongKet.Checked)
            {
                _chon = 6;
                radBaoCaoTongKet.Checked = true;
                radDanhSachLop.Checked = false;
                radThayDoiMatKhau.Checked = false;
                radTimKiemHocSinh.Checked = false;
                radTiepNhanHocSinh.Checked = false;
                radThayĐoiQuyDinh.Checked = false;              
                radNhapDiem.Checked = false;
            }
        }        

        private void radThayĐoiQuyDinh_CheckedChanged(object sender, EventArgs e)
        {
            if (radThayĐoiQuyDinh.Checked)
            {
                _chon = 7;
                radThayĐoiQuyDinh.Checked = true;
                radDanhSachLop.Checked = false;
                radThayDoiMatKhau.Checked = false;
                radTimKiemHocSinh.Checked = false;
                radTiepNhanHocSinh.Checked = false;                
                radBaoCaoTongKet.Checked = false;
                radNhapDiem.Checked = false;
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            radThayDoiMatKhau.Checked = true;
            radDanhSachLop.Checked = false;
            radTiepNhanHocSinh.Checked = false;
            radBaoCaoTongKet.Checked = false;

            frmDangNhap frm = new frmDangNhap();
            frm.ShowDialog();
            _hSDangNhapThanhCong = frm.HSDangNhapThanhCong;
            _qLDangNhapThanhCong = frm.QLDangNhapThanhCong;
            if ((_hSDangNhapThanhCong) || (_qLDangNhapThanhCong))
            {
                ///////////////////////
                _taiKhoan = frm.TaiKhoan;
                QuanLy ql = new QuanLy();
                QuanLyService qlService = new QuanLyService();
                ql = qlService.GetByMaQuanLy(_taiKhoan);
                if (ql != null)
                {
                    ChucDanh cd = new ChucDanh();
                    ChucDanhService cdService = new ChucDanhService();
                    cd = cdService.GetByMaChucDanh(ql.MaChucDanh);
                    if (cd.TenChucDanh == "Giam Thi")
                    {
                        radThayĐoiQuyDinh.Visible = false;
                        xóaLớpToolStripMenuItem.Visible = false;
                        thêmLớpToolStripMenuItem.Visible = false;
                        quảnLýToolStripMenuItem.Visible = false;
                        thayĐổiQuyĐịnhToolStripMenuItem.Visible = false;
                    }
                }

                HocSinh hs = new HocSinh();
                HocSinhService hsService = new HocSinhService();
                hs = hsService.GetByMaHocSinh(_taiKhoan);
                if (hs != null)
                {
                    radBaoCaoTongKet.Visible = false;
                    radTiepNhanHocSinh.Visible = false;
                    radThayĐoiQuyDinh.Visible = false;                   
                    radNhapDiem.Visible = false;
                    nhậpĐiểmToolStripMenuItem.Visible = false;
                    tiếpNhậnHọcSinhToolStripMenuItem.Visible = false;
                    nhậpĐiểmToolStripMenuItem.Visible = false;
                    xóaLớpToolStripMenuItem.Visible = false;
                    thêmLớpToolStripMenuItem.Visible = false;
                    báoCáoToolStripMenuItem.Visible = false;
                    quảnLýToolStripMenuItem.Visible = false;
                    thayĐổiQuyĐịnhToolStripMenuItem.Visible = false;
                    xóaThôngTinHọcSinhToolStripMenuItem.Visible = false;
                    sửaThôngTinHọcSinhToolStripMenuItem.Visible = false;
                }
            }
            else
                this.Close();
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            switch (_chon)
            {                
                case 1:
                    frmTiepNhanHocSinh frm1 = new frmTiepNhanHocSinh();
                    frm1.ShowDialog();
                    break;
                case 2:
                    frmDanhSachLop frm2 = new frmDanhSachLop();
                    frm2.ShowDialog();
                    break;
                case 3:
                    frmNhapDiem frm3 = new frmNhapDiem();
                    frm3.ShowDialog();
                    break;
                case 4:
                    frmTimKiemHocSinh frm4 = new frmTimKiemHocSinh();
                    frm4.ShowDialog();
                    break;
                case 5:
                    frmThayDoiMatKhau frm5 = new frmThayDoiMatKhau();                    
                    frm5.TaiKhoan = _taiKhoan;
                    frm5.HSDangNhapThanhCong = _hSDangNhapThanhCong;
                    frm5.QLDangNhapThanhCong = _qLDangNhapThanhCong;
                    frm5.ShowDialog();
                    break;
                case 6:
                    frmBaoCaoTongKet frm6 = new frmBaoCaoTongKet();
                    frm6.BaoCaoHocKy = false;
                    frm6.BaoCaoMon = false;
                    frm6.ShowDialog();
                    break;                
                case 7:
                    frmThayDoiQuyDinh frm7 = new frmThayDoiQuyDinh();
                    frm7.ShowDialog();
                    break;                
                                   
                default:
                    break;
            }
        }      

        private void tiếpNhậnHọcSinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTiepNhanHocSinh frm1 = new frmTiepNhanHocSinh();
            frm1.ShowDialog();
        }

        private void nhậpĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhapDiem frm3 = new frmNhapDiem();
            frm3.ShowDialog();
        }

        private void timToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimKiemHocSinh frm4 = new frmTimKiemHocSinh();
            frm4.ShowDialog();
        }

        private void danhSáchLớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDanhSachLop frm2 = new frmDanhSachLop();
            frm2.ShowDialog();
        }

        private void báoCáoTheoMônToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBaoCaoTongKet frm = new frmBaoCaoTongKet();
            frm.BaoCaoMon = true;
            frm.ShowDialog();
        }

        private void báoCáoTheoHọcKỳToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBaoCaoTongKet frm = new frmBaoCaoTongKet();
            frm.BaoCaoHocKy = true;
            frm.ShowDialog();
        }

        private void thayĐổiQuyĐịnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThayDoiQuyDinh frm = new frmThayDoiQuyDinh();
            frm.ShowDialog();
        }

        private void đổiPassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThayDoiMatKhau frm = new frmThayDoiMatKhau();
            frm.ShowDialog();
        }

        private void thêmLớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThemLop frm = new frmThemLop();
            frm.ShowDialog();
        }

        private void xóaLớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXoaLop frm = new frmXoaLop();
            frm.ShowDialog();
        }

        private void thêmNhânViênQuảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThemQuanLy frm = new frmThemQuanLy();
            frm.ShowDialog();
        }

        private void xóaNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXoaQuanLy frm = new frmXoaQuanLy();
            frm.ShowDialog();
        }

        private void sửaThôngTinHọcSinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSuaThongTinHocSinh frm = new frmSuaThongTinHocSinh();
            frm.ShowDialog();
        }

        private void xóaThôngTinHọcSinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXoaThongTinHocSinh frm = new frmXoaThongTinHocSinh();
            frm.ShowDialog();
        }                        
    }
}