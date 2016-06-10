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
    public partial class frmDanhSachLop : Form
    {
        public frmDanhSachLop()
        {
            InitializeComponent();
        }

        private void FrmThongTinVeDiem_Load(object sender, EventArgs e)
        {
            radKhoi10.Checked = true;
            radKhoi11.Checked = false;
            radKhoi12.Checked = false;

            LopHocBUS lhBUS = new LopHocBUS();
            TList<LopHoc> ds = new TList<LopHoc>();
            ds = lhBUS.LayBangTheoMaKhoi("K10");
            cbxLopHoc.DataSource = ds;
            cbxLopHoc.DisplayMember = "TenLop";
            cbxLopHoc.ValueMember = "MaLop";            

            HocSinhBUS hsBUS = new HocSinhBUS();
            lblSiSo.Text = "Sỉ số : " + hsBUS.LayBangTheoMaLop((string)cbxLopHoc.SelectedValue).Count.ToString();
            dtgvDanhSach.DataSource = hsBUS.LayBangTheoMaLop((string)cbxLopHoc.SelectedValue);
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            HocSinhBUS hsBUS = new HocSinhBUS();
            lblSiSo.Text = "Sỉ số : " + hsBUS.LayBangTheoMaLop((string)cbxLopHoc.SelectedValue).Count.ToString();
            dtgvDanhSach.DataSource = hsBUS.LayBangTheoMaLop((string)cbxLopHoc.SelectedValue);
        }

        private void radKhoi10_CheckedChanged(object sender, EventArgs e)
        {            
            if (radKhoi10.Checked)
            {               
                radKhoi11.Checked = false;
                radKhoi12.Checked = false;

                LopHocBUS lhBUS = new LopHocBUS();
                TList<LopHoc> ds = new TList<LopHoc>();
                ds = lhBUS.LayBangTheoMaKhoi("K10");
                cbxLopHoc.DataSource = ds;
                cbxLopHoc.DisplayMember = "TenLop";
                cbxLopHoc.ValueMember = "MaLop";
            }
        }

        private void radKhoi11_CheckedChanged(object sender, EventArgs e)
        {            
            if (radKhoi11.Checked)
            {
                radKhoi10.Checked = false;              
                radKhoi12.Checked = false;

                LopHocBUS lhBUS = new LopHocBUS();
                TList<LopHoc> ds = new TList<LopHoc>();
                ds = lhBUS.LayBangTheoMaKhoi("K11");
                cbxLopHoc.DataSource = ds;
                cbxLopHoc.DisplayMember = "TenLop";
                cbxLopHoc.ValueMember = "MaLop";
            }
        }

        private void radKhoi12_CheckedChanged(object sender, EventArgs e)
        {
            if (radKhoi12.Checked)
            {
                radKhoi10.Checked = false;
                radKhoi11.Checked = false;                

                LopHocBUS lhBUS = new LopHocBUS();
                TList<LopHoc> ds = new TList<LopHoc>();
                ds = lhBUS.LayBangTheoMaKhoi("K12");
                cbxLopHoc.DataSource = ds;
                cbxLopHoc.DisplayMember = "TenLop";
                cbxLopHoc.ValueMember = "MaLop";
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }          
    }
}