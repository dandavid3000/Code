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
    public partial class frmXoaThongTinHocSinh : Form
    {
        public frmXoaThongTinHocSinh()
        {
            InitializeComponent();
        }

        private void frmXoaThongTinHocSinh_Load(object sender, EventArgs e)
        {
            maskMaHocSinh.Mask = "00L0000";
        }

        private void maskMaHocSinh_TextChanged(object sender, EventArgs e)
        {
            if (maskMaHocSinh.MaskCompleted)
            {
                HocSinh hs = new HocSinh();
                HocSinhBUS hsBUS = new HocSinhBUS();
                hs = hsBUS.LayHocSinh(maskMaHocSinh.Text);
                if (hs != null)
                    txtHoTenHocSinh.Text = hs.HoTenHocSinh;
                else
                    txtHoTenHocSinh.Text = "";
            }
            else
                txtHoTenHocSinh.Text = "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            HocSinh hs = new HocSinh();
            HocSinhBUS hsBUS = new HocSinhBUS();
            hs = hsBUS.LayHocSinh((string)maskMaHocSinh.Text);
            if (hs != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa học sinh này không?", "Thông Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    BangDiemBUS bdBUS = new BangDiemBUS();
                    TList<BangDiem> dsbd = bdBUS.LayBangDiemTheoMaHocSinh(hs.MaHocSinh);
                    foreach (BangDiem bd in dsbd)
                    {
                        DiemBUS dBUS = new DiemBUS();
                        TList<Diem> dsd = dBUS.LayDiemTheoMaBangDiem(bd.MaBangDiem);
                        foreach (Diem d in dsd)
                            dBUS.Xoa(d);
                        bdBUS.Xoa(bd);
                    }
                    
                    bool kq = hsBUS.Xoa(hs);
                    if (kq)
                        MessageBox.Show("Xóa học sinh thành công");
                    else
                        MessageBox.Show("Xóa học sinh thất bại");
                    maskMaHocSinh.Text = "";
                    txtHoTenHocSinh.Text = "";
                }
            }
            else
                MessageBox.Show("Mã học sinh không tồn tại");            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}