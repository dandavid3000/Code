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
    public partial class frmTiepNhanHocSinh : Form
    {
        public frmTiepNhanHocSinh()
        {
            InitializeComponent();
            ToolTip tlt = new ToolTip();
            tlt.AutomaticDelay = 50;
            tlt.AutoPopDelay = 500;        
            tlt.ReshowDelay = 500;
            tlt.SetToolTip(this.btnThemLop, "Thêm lớp học mới");
        }      

        private void FrmThongTinHocSinh_Load(object sender, EventArgs e)
        {
            radNam.Checked = true;
            radNu.Checked = false;

            LopHocBUS lhBUS = new LopHocBUS();
            cbxLop.DataSource = lhBUS.LayBang();
            cbxLop.DisplayMember = "TenLop";
            cbxLop.ValueMember = "MaLop";

            HocSinhBUS hsBUS = new HocSinhBUS();
            txtMaHocSinh.Text = hsBUS.LayMaHSLonNhatTheoLop((string)cbxLop.SelectedValue);
            string[] XepLoai = {"Xuat Sac", "Gioi", "Kha", "Trung Binh", "Yeu" };
            cbxXepLoai.DataSource = XepLoai;

            string[] HanhKiem ={ "Tot", "Kha", "Trung Binh", "Yeu" };
            cbxHanhKiem.DataSource = HanhKiem;           
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTiepNhan_Click(object sender, EventArgs e)
        {
            if (HocSinhBUS.KiemTraHoTen(txtHoTen.Text))
            {
                if (HocSinhBUS.KiemTraEmail(txtEmail.Text))
                {
                    if (HocSinhBUS.KiemTraPassworđ(txtPassword.Text))
                    {
                        HocSinhBUS hsBUS = new HocSinhBUS();
                        HocSinh hs = new HocSinh();

                        if (radNam.Checked)
                        {
                            hs.GioiTinh = "Nam";
                        }
                        else if (radNu.Checked)
                        {
                            hs.GioiTinh = "Nu";
                        }
                        
                        hs.MaLop = (string)cbxLop.SelectedValue;
                        hs.HoTenHocSinh = txtHoTen.Text;
                        if (KiemTraNgaySinh(dtpkNgaySinh.Value))
                            hs.NgaySinh = dtpkNgaySinh.Value;
                        else
                        {
                            MessageBox.Show("Ngày sinh không hợp lệ");
                            dtpkNgaySinh.Focus();
                        }
                        hs.DiaChi = txtDiaChi.Text;
                        hs.Email = txtEmail.Text;
                        hs.XepLoai = (string)cbxXepLoai.SelectedValue;
                        hs.HanhKiem = (string)cbxHanhKiem.SelectedValue;
                        hs.Password = txtPassword.Text;
                        hs.MaHocSinh = hsBUS.LayMaHSLonNhatTheoLop((string)cbxLop.SelectedValue);

                        bool kq = hsBUS.Them(hs);
                        if (kq)
                        {
                            hsBUS.NhapDiemMacDinh(hs);
                            MessageBox.Show("Thêm học sinh thành công");
                            this.Close();
                        }
                        else
                            MessageBox.Show("Thêm học sinh thất bại");
                    }
                    else
                        MessageBox.Show("Password không hợp lệ");                    
                }
                else
                    MessageBox.Show("Email không hợp lệ");
            }
            else
                MessageBox.Show("Họ tên không hợp lệ");
        }

        private void radNam_CheckedChanged(object sender, EventArgs e)
        {
            if (radNam.Checked)
                radNu.Checked = false;
        }

        private void radNu_CheckedChanged(object sender, EventArgs e)
        {
            if (radNu.Checked)
                radNam.Checked = false;
        }

        private void btnThemLop_Click(object sender, EventArgs e)
        {
            frmThemLop frm = new frmThemLop();
            frm.ShowDialog();
        }

        public bool KiemTraNgaySinh(DateTime date)
        {
            bool kq = true;
            BangThamSo bts = new BangThamSo();
            BangThamSoBUS btsBUS = new BangThamSoBUS();
            bts = btsBUS.LayBangTheoMa("BTS001");
            if (((DateTime.Now.Year - date.Year) > bts.SoTuoiToiDa) || ((DateTime.Now.Year - date.Year) < bts.SoTuoiToiThieu))
                kq = false;
            return kq;
        }

        private void cbxLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            HocSinhBUS hsBUS = new HocSinhBUS();
            if (cbxLop.SelectedValue.GetType().Name == "LopHoc")
            {
                LopHoc lh = (LopHoc)cbxLop.SelectedValue;
                txtMaHocSinh.Text = hsBUS.LayMaHSLonNhatTheoLop(lh.MaLop);
            }
            else
                txtMaHocSinh.Text = hsBUS.LayMaHSLonNhatTheoLop((string)cbxLop.SelectedValue);
        }
    }
}