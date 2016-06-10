using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QuanLyHocSinhPTNK.Entities;
using BUSLayer;

namespace Do_An_Cong_Ty
{
    public partial class frmThemQuanLy : Form
    {
        public frmThemQuanLy()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            QuanLy ql = new QuanLy();
            ql.MaQuanLy = txtMaQuanLy.Text;
            ql.MaPhongBan = (string)cbxPhongBan.SelectedValue;
            ql.HoTenQuanLy = txtTenQuanLy.Text;
            ql.Password = txtPassword.Text;
            ql.MaChucDanh = (string)cbxChucDanh.SelectedValue;

            QuanLyBUS qlBUS = new QuanLyBUS();
            bool kq = qlBUS.Them(ql);
            if (kq)
                MessageBox.Show("Thêm quản lý thành công");
            else
                MessageBox.Show("Thêm quản lý thất bại");
            txtTenQuanLy.Text = "";
            txtPassword.Text = "";
            frmThemQuanLy_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThemQuanLy_Load(object sender, EventArgs e)
        {            
            PhongBanBUS pbBUS = new PhongBanBUS();
            cbxPhongBan.DataSource = pbBUS.LayBang();
            cbxPhongBan.DisplayMember = "TenPhongBan";
            cbxPhongBan.ValueMember = "MaPhongBan";

            ChucDanhBUS cdBUS = new ChucDanhBUS();
            cbxChucDanh.DataSource = cdBUS.LayDanhSachChucDanh((string)cbxPhongBan.SelectedValue);
            cbxChucDanh.DisplayMember = "TenChucDanh";
            cbxChucDanh.ValueMember = "MaChucDanh";

            QuanLyBUS qlBUs = new QuanLyBUS();
            txtMaQuanLy.Text = qlBUs.LayMaQuanLyLonNhat();
        }

        private void cbxPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChucDanhBUS cdBUS = new ChucDanhBUS();
            if (cbxPhongBan.SelectedValue.GetType().Name == "PhongBan")
            {
                PhongBan pb = (PhongBan)cbxPhongBan.SelectedValue;                
                cbxChucDanh.DataSource = cdBUS.LayDanhSachChucDanh(pb.MaPhongBan);
                cbxChucDanh.DisplayMember = "TenChucDanh";
                cbxChucDanh.ValueMember = "MaChucDanh";
            }
            else
            {
                cbxChucDanh.DataSource = cdBUS.LayDanhSachChucDanh((string)cbxPhongBan.SelectedValue);
                cbxChucDanh.DisplayMember = "TenChucDanh";
                cbxChucDanh.ValueMember = "MaChucDanh";
            }
        }
    }
}