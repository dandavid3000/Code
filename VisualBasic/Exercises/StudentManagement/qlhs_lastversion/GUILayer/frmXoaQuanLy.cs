using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BUSLayer;
using QuanLyHocSinhPTNK.Entities;

namespace Do_An_Cong_Ty
{
    public partial class frmXoaQuanLy : Form
    {
        public frmXoaQuanLy()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmXoaQuanLy_Load(object sender, EventArgs e)
        {
            PhongBanBUS pbBUS = new PhongBanBUS();
            cbxPhongBan.DataSource = pbBUS.LayBang();
            cbxPhongBan.DisplayMember = "TenPhongBan";
            cbxPhongBan.ValueMember = "MaPhongBan";

            ChucDanhBUS cdBUS = new ChucDanhBUS();
            cbxChucDanh.DataSource = cdBUS.LayDanhSachChucDanh((string)cbxPhongBan.SelectedValue);
            cbxChucDanh.DisplayMember = "TenChucDanh";
            cbxChucDanh.ValueMember = "MaChucDanh";

            QuanLyBUS qlBUS = new QuanLyBUS();
            DataTable dt = qlBUS.LayQuanLyXoa((string)cbxChucDanh.SelectedValue, (string)cbxPhongBan.SelectedValue);
            cbxMaQuanLy.DataSource = dt;
            cbxMaQuanLy.DisplayMember = "MaQuanLy";
            cbxMaQuanLy.ValueMember = "MaQuanLy";

            txtTenQuanLy.Text = qlBUS.LayQuanLy((string)cbxMaQuanLy.SelectedValue).HoTenQuanLy;
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

                QuanLyBUS qlBUS = new QuanLyBUS();
                DataTable dt = qlBUS.LayQuanLyXoa((string)cbxChucDanh.SelectedValue, pb.MaPhongBan);
                cbxMaQuanLy.DataSource = dt;                
            }
            else
            {
                cbxChucDanh.DataSource = cdBUS.LayDanhSachChucDanh((string)cbxPhongBan.SelectedValue);
                cbxChucDanh.DisplayMember = "TenChucDanh";
                cbxChucDanh.ValueMember = "MaChucDanh";

                QuanLyBUS qlBUS = new QuanLyBUS();
                DataTable dt = qlBUS.LayQuanLyXoa((string)cbxChucDanh.SelectedValue, (string)cbxPhongBan.SelectedValue);
                cbxMaQuanLy.DataSource = dt;              
            }
            cbxMaQuanLy.DisplayMember = "MaQuanLy";
            cbxMaQuanLy.ValueMember = "MaQuanLy";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            QuanLy ql = new QuanLy();
            QuanLyBUS qlBUS = new QuanLyBUS();
            ql = qlBUS.LayQuanLy((string)cbxMaQuanLy.SelectedValue);

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa quản lý này không?", "Thông Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool kq = qlBUS.Xoa(ql);
                if (kq)
                    MessageBox.Show("Xóa quản lý thành công");
                else
                    MessageBox.Show("Xóa quản lý thất bại");
                frmXoaQuanLy_Load(sender, e);
            }
        }

        private void cbxChucDanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            QuanLyBUS qlBUS = new QuanLyBUS();
            if (cbxChucDanh.SelectedValue.GetType().Name == "ChucDanh")
            {
                ChucDanh cd = (ChucDanh)cbxChucDanh.SelectedValue;
                if (cbxPhongBan.SelectedValue.GetType().Name == "PhongBan")
                {
                    PhongBan pb = (PhongBan)cbxPhongBan.SelectedValue;
                    DataTable dt = qlBUS.LayQuanLyXoa(cd.MaChucDanh, pb.MaPhongBan);
                    cbxMaQuanLy.DataSource = dt;                    
                }
                else
                {
                    DataTable dt = qlBUS.LayQuanLyXoa(cd.MaChucDanh, (string)cbxPhongBan.SelectedValue);
                    cbxMaQuanLy.DataSource = dt;                    
                }
            }
            else
            {
                if (cbxPhongBan.SelectedValue.GetType().Name == "PhongBan")
                {
                    PhongBan pb = (PhongBan)cbxPhongBan.SelectedValue;
                    DataTable dt = qlBUS.LayQuanLyXoa((string)cbxChucDanh.SelectedValue, pb.MaPhongBan);
                    cbxMaQuanLy.DataSource = dt;                    
                }
                else
                {
                    DataTable dt = qlBUS.LayQuanLyXoa((string)cbxChucDanh.SelectedValue, (string)cbxPhongBan.SelectedValue);
                    cbxMaQuanLy.DataSource = dt;                  
                }                
            }
            cbxMaQuanLy.DisplayMember = "MaQuanLy";
            cbxMaQuanLy.ValueMember = "MaQuanLy";
        }

        private void cbxMaQuanLy_SelectedIndexChanged(object sender, EventArgs e)
        {
            QuanLyBUS qlBUS = new QuanLyBUS();
            if (cbxMaQuanLy.SelectedValue.GetType().Name == "DataRowView")
            {
                DataRowView row = (DataRowView)cbxMaQuanLy.SelectedValue;
                txtTenQuanLy.Text = qlBUS.LayQuanLy((string)row[0]).HoTenQuanLy;
            }
            else
            {                
                txtTenQuanLy.Text = qlBUS.LayQuanLy((string)cbxMaQuanLy.SelectedValue).HoTenQuanLy;
            }
        }
    }
}