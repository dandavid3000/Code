using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QuanLyHocSinhPTNK.Entities;
using QuanLyHocSinhPTNK.Services;
using BUSLayer;

namespace Do_An_Cong_Ty
{
    public partial class frmThemLop : Form
    {
        public frmThemLop()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThemLop_Load(object sender, EventArgs e)
        {            
            TList<Khoi> ds = new TList<Khoi>();
            KhoiBUS kBUS = new KhoiBUS();
            ds = kBUS.LayBang();
            cbxKhoi.DataSource = ds;
            cbxKhoi.DisplayMember = "TenKhoi";
            cbxKhoi.ValueMember = "MaKhoi";

            LopHocBUS lhBUS = new LopHocBUS();
            txtMaLop.Text = lhBUS.LayMaLopHocLonNhat((string)cbxKhoi.SelectedValue);            
        }

        private void cbxKhoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            LopHocBUS lhBUS = new LopHocBUS();         
            if (cbxKhoi.SelectedValue.GetType().Name == "Khoi")
            {
                Khoi k = (Khoi)cbxKhoi.SelectedValue;
                txtMaLop.Text = lhBUS.LayMaLopHocLonNhat(k.MaKhoi);
            }
            else
            {
                txtMaLop.Text = lhBUS.LayMaLopHocLonNhat((string)cbxKhoi.SelectedValue);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LopHoc lh = new LopHoc();
            lh.MaKhoi = (string)cbxKhoi.SelectedValue;
            lh.TenLop = txtTenLop.Text;
            lh.MaLop = txtMaLop.Text;
            LopHocBUS lhBUS = new LopHocBUS();
            bool kq = lhBUS.ThemLop(lh);
            if (kq)
                MessageBox.Show("Thêm lớp học thành công");
            else
                MessageBox.Show("Thêm lớp học thất bại");
            txtTenLop.Text = "";            
            frmThemLop_Load(sender, e);
        }
    }
}