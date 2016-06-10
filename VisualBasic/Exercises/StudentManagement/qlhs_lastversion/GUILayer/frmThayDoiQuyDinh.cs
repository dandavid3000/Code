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
    public partial class frmThayDoiQuyDinh : Form
    {
        public frmThayDoiQuyDinh()
        {
            InitializeComponent();
        } 
        
        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            BangThamSo bts = new BangThamSo();
            bts.MaBangThamSo = "BTS001    ";
            BangThamSoBUS btsBUS = new BangThamSoBUS();
            if (chkSoTuoiToiThieu.Checked)
            {
                bts.SoTuoiToiThieu = Convert.ToInt32(txtSoTuoiToiThieu.Text);
            }
            else
            {
                bts.SoTuoiToiThieu = Convert.ToInt32(txtSoTuoiToiThieu.Value);
            }

            if (chkSoTuoiToiDa.Checked)
            {
                bts.SoTuoiToiDa = Convert.ToInt32(txtSoTuoiToiDa.Text);
            }
            else
            {
                bts.SoTuoiToiDa = Convert.ToInt32(txtSoTuoiToiDa.Value);
            }

            if (chkSoTietHocLienTiep.Checked)
            {
                bts.SoTietHocLienTiep = Convert.ToInt32(txtSoTietHocLienTiep.Text);
            }
            else
            {
                bts.SoTietHocLienTiep = Convert.ToInt32(txtSoTietHocLienTiep.Value);
            }

            if (chkSoQuanLyToiDa.Checked)
            {
                bts.SoQuanLyToiDa = Convert.ToInt32(txtSoQuanLyToiDa.Text);
            }
            else
            {
                bts.SoQuanLyToiDa = Convert.ToInt32(txtSoQuanLyToiDa.Value);
            }

            if (chkSoLuongMonHoc.Checked)
            {
                bts.SoMonHoc = Convert.ToInt32(txtSoLuongMonHoc.Text);
            }
            else
            {
                bts.SoMonHoc = Convert.ToInt32(txtSoLuongMonHoc.Value);
            }

            if (chkSiSoToiDa.Checked)
            {
                bts.SiSoToiDa = Convert.ToInt32(txtSiSoToiDa.Text);
            }
            else
            {
                bts.SiSoToiDa = Convert.ToInt32(txtSiSoToiDa.Value);
            }

            if (chkDiemChuan.Checked)
            {
                bts.DiemChuan = Convert.ToInt32(txtDiemChuan.Text);
            }
            else
            {
                bts.DiemChuan = Convert.ToInt32(txtDiemChuan.Value);
            }

            /////////////////////////////////////
            btsBUS.CapNhat(bts);

            MessageBox.Show("Cập nhật thành công");
            this.Close();   
        }

        private bool KTLaSo(string str)
        {
            foreach (char c in str)
                if (char.IsLetter(c))
                    return false;
            return true;
        }

        private void frmThayDoiQuyDinh_Load(object sender, EventArgs e)
        {
            txtSoTuoiToiThieu.Enabled = false;
            txtSoTuoiToiDa.Enabled = false;
            txtSoTietHocLienTiep.Enabled = false;
            txtSoQuanLyToiDa.Enabled = false;
            txtSoLuongMonHoc.Enabled = false;
            txtSiSoToiDa.Enabled = false;
            txtDiemChuan.Enabled = false;
        }

        private void chkSoTuoiToiThieu_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSoTuoiToiThieu.Checked)
                txtSoTuoiToiThieu.Enabled = true;
            else
                txtSoTuoiToiThieu.Enabled = false;
        }

        private void chkSoTuoiToiDa_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSoTuoiToiDa.Checked)
                txtSoTuoiToiDa.Enabled = true;
            else
                txtSoTuoiToiDa.Enabled = false;
        }

        private void chkSiSoToiDa_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSiSoToiDa.Checked)
                txtSiSoToiDa.Enabled = true;
            else
                txtSiSoToiDa.Enabled = false;
        }

        private void chkSoLuongMonHoc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSoLuongMonHoc.Checked)
                txtSoLuongMonHoc.Enabled = true;
            else
                txtSoLuongMonHoc.Enabled = false;
        }

        private void chkDiemChuan_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDiemChuan.Checked)
                txtDiemChuan.Enabled = true;
            else
                txtDiemChuan.Enabled = false;
        }

        private void chkSoQuanLyToiDa_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSoQuanLyToiDa.Checked)
                txtSoQuanLyToiDa.Enabled = true;
            else
                txtSoQuanLyToiDa.Enabled = false;
        }

        private void chkSoTietHocLienTiep_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSoTietHocLienTiep.Checked)
                txtSoTietHocLienTiep.Enabled = true;
            else
                txtSoTietHocLienTiep.Enabled = false;
        }        
    }
}