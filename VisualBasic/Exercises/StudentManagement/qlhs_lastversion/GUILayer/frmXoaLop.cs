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
    public partial class frmXoaLop : Form
    {
        public frmXoaLop()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            LopHoc lh = new LopHoc();
            lh.MaKhoi = (string)cbxKhoi.SelectedValue;
            lh.TenLop = txtTenLop.Text;
            lh.MaLop = (string)cbxMaLop.SelectedValue;
            LopHocBUS lhBUS = new LopHocBUS();
           
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa lớp học này không?", "Thông Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool kq = lhBUS.Xoa(lh);
                if (kq)
                    MessageBox.Show("Xóa lớp học thành công");
                else
                    MessageBox.Show("Xóa lớp học thất bại");
                frmXoaLop_Load(sender, e);
            }
        }

        private void cbxKhoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            LopHocBUS lhBUS = new LopHocBUS();
            if (cbxKhoi.SelectedValue.GetType().Name == "Khoi")
            {
                Khoi k = (Khoi)cbxKhoi.SelectedValue;
                cbxMaLop.DataSource = lhBUS.LayBangTheoMaKhoi(k.MaKhoi);
                cbxMaLop.DisplayMember = "MaLop";
                cbxMaLop.ValueMember = "MaLop";
            }
            else
            {
                cbxMaLop.DataSource = lhBUS.LayBangTheoMaKhoi((string)cbxKhoi.SelectedValue);
                cbxMaLop.DisplayMember = "MaLop";
                cbxMaLop.ValueMember = "MaLop";
            }            
        }

        private void cbxMaLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            LopHocBUS lhBUS = new LopHocBUS();
            if (cbxMaLop.SelectedValue.GetType().Name == "LopHoc")
            {
                LopHoc lh = (LopHoc)cbxMaLop.SelectedValue;
                txtTenLop.Text = lh.TenLop;
            }
            else
            {
                LopHoc lophoc = new LopHoc();
                lophoc = lhBUS.LayLopHocTheoMaLop((string)cbxMaLop.SelectedValue);
                if(lophoc != null)
                    txtTenLop.Text = lophoc.TenLop;           
            }
        }

        private void frmXoaLop_Load(object sender, EventArgs e)
        {
            TList<Khoi> ds = new TList<Khoi>();
            KhoiBUS kBUS = new KhoiBUS();
            ds = kBUS.LayBang();
            cbxKhoi.DataSource = ds;
            cbxKhoi.DisplayMember = "TenKhoi";
            cbxKhoi.ValueMember = "MaKhoi";

            TList<LopHoc> dslh = new TList<LopHoc>();
            LopHocBUS lhBUS = new LopHocBUS();
            dslh = lhBUS.LayBangTheoMaKhoi((string)cbxKhoi.SelectedValue);
            cbxMaLop.DataSource = dslh;
            cbxMaLop.DisplayMember = "MaLop";
            cbxMaLop.ValueMember = "MaLop";

            LopHoc lh = new LopHoc();
            lh = lhBUS.LayLopHocTheoMaLop((string)cbxMaLop.SelectedValue);
            txtTenLop.Text = lh.TenLop;
        }
    }
}