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
    public partial class frmTimKiemHocSinh : Form
    {
        public frmTimKiemHocSinh()
        {
            InitializeComponent();           
        }        
        
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            string maHS = " 1=1 ";
            string tenHS = " 1=1 ";
            string ngaysinh = " 1=1 ";
            string diachi = " 1=1 ";
            string toan = " 1=1 ";
            string ly = " 1=1 ";
            string hoa = " 1=1 ";
            string sinh = " 1=1 ";
            string su = " 1=1 ";
            string dia = " 1=1 ";
            string van = " 1=1 ";
            string daoduc = " 1=1 ";
            string theduc = " 1=1 ";
            string DTB = " 1=1 ";
            string lop = " 1=1 ";            
           
            if (maskMaHS.Text != "")
            {
                maHS = "hs.MaHocSinh = " + "'" + maskMaHS.Text + "'" + " ";
            }

            if (txtTenHocSinh.Text != "")
            {
                tenHS = " hs.HoTenHocSinh like " + "'" + txtTenHocSinh.Text + "'" ;
            }

            if (chkNgaySinh.Checked == true)
            {
                ngaysinh = " hs.NgaySinh between " + "'" + dtpNgaySinhTu.Value.ToString() + "'" + " and " + "'" + dtpNgaySinhDen.Value.ToString() + "'" ;
            }

            if (chkDiaChi.Checked == true)
            {
                diachi = " hs.DiaChi like " + "'" + txtDiaChi.Text + "'";
            }

            if (chkDiemToan.Checked == true)
            {
                toan = " d.MaMon = 'MH001' and " + "d.DTB between " + "'" + nudDiemToanTu.Value.ToString() + "'" + " and " + "'" + nudDiemToanDen.Value.ToString() + "'"; 
            }

            if (chkDiemLy.Checked == true)
            {
                ly = " d.MaMon = 'MH002' and " + "d.DTB between " + "'" + nudDiemLyTu.Value.ToString() + "'" + " and " + "'" + nudDiemLyDen.Value.ToString() + "'"; 
            }

            if (chkDiemHoa.Checked == true)
            {
                hoa = " d.MaMon = 'MH003' and " + "d.DTB between " + "'" + nudDiemHoaTu.Value.ToString() + "'" + " and " + "'" + nudDiemHoaDen.Value.ToString() + "'";
            }

            if (chkDiemSinh.Checked == true)
            {
                sinh = " d.MaMon = 'MH004' and " + "d.DTB between " + "'" + nudDiemSinhTu.Value.ToString() + "'" + " and " + "'" + nudDiemSinhDen.Value.ToString() + "'";
            }
            if (chkDiemSu.Checked == true)
            {
                su = " d.MaMon = 'MH005' and " + "d.DTB between " + "'" + nudDiemSuTu.Value.ToString() + "'" + " and " + "'" + nudDiemSuDen.Value.ToString() + "'";
            }

            if (chkDiemDia.Checked == true)
            {
                dia = " d.MaMon = 'MH006' and " + "d.DTB between " + "'" + nudDiemDiaTu.Value.ToString() + "'" + " and " + "'" + nudDiemDiaDen.Value.ToString() + "'";
            }

            if (chkDiemVan.Checked == true)
            {
                van = " d.MaMon = 'MH007' and " + "d.DTB between " + "'" + nudDiemVanTu.Value.ToString() + "'" + " and " + "'" + nudDiemVanDen.Value.ToString() + "'";
            }

            if (chkDaoDuc.Checked == true)
            {
                daoduc = " d.MaMon = 'MH008' and " + "d.DTB between " + "'" + nudDaoDucTu.Value.ToString() + "'" + " and " + "'" + nudDaoDucDen.Value.ToString() + "'";
            }

            if (chkTheDuc.Checked == true)
            {
                theduc = " d.MaMon = 'MH009' and " + "d.DTB between " + "'" + nudTheDucTu.Value.ToString() + "'" + " and " + "'" + nudTheDucDen.Value.ToString() + "'";
            }

            if (chkDTB.Checked == true)
            {
                DTB = " bd.DTB between " + "'" + nudDTBTu.Value.ToString() + "'" + " and " + "'" + nudDTBDen.Value.ToString() +"'";
            }

            if (chkLopHoc.Checked == true)
            {
                lop = " lh.MaLop = " + "'" + cmbLopHoc.SelectedValue.ToString() + "'";
            }          

            DataTable dt = new DataTable();
            HocSinhBUS hsBUS = new HocSinhBUS();
            dt = hsBUS.LayThongTinHocSinh(maHS, tenHS, ngaysinh, diachi, toan, ly, hoa, sinh, su, dia, van, daoduc, theduc, DTB, lop);
            dtgHocSinh.DataSource = dt;
        }

        private void FrmTimKiemHocSinh_Load(object sender, EventArgs e)
        {
            maskMaHS.Mask = "00L0000";

            TList<LopHoc> dslh = new TList<LopHoc>();
            LopHocBUS lhBUS = new LopHocBUS();
            dslh = lhBUS.LayBang();
            cmbLopHoc.DataSource = dslh;
            cmbLopHoc.DisplayMember = "TenLop";
            cmbLopHoc.ValueMember = "MaLop";
        }

        private void chkNgaySinh_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNgaySinh.Checked == true)
            {
                dtpNgaySinhTu.Enabled = true;
                dtpNgaySinhDen.Enabled = true;
            }
            else
            {
                dtpNgaySinhTu.Enabled = false;
                dtpNgaySinhDen.Enabled = false;
            }
        }

        private void chkDiaChi_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDiaChi.Checked == true)
            {
                txtDiaChi.Enabled = true;
            }
            else
            {
                txtDiaChi.Enabled = false;
            }
        }

        private void chkDiemToan_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDiemToan.Checked == true)
            {
                nudDiemToanTu.Enabled = true;
                nudDiemToanDen.Enabled = true;
            }
            else
            {
                nudDiemToanTu.Enabled = false;
                nudDiemToanDen.Enabled = false;
            }
        }

        private void chkDiemLy_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDiemLy.Checked == true)
            {
                nudDiemLyTu.Enabled = true;
                nudDiemLyDen.Enabled = true;
            }
            else
            {
                nudDiemLyTu.Enabled = false;
                nudDiemLyDen.Enabled = false;
            }
        }

        private void chkDiemHoa_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDiemHoa.Checked == true)
            {
                nudDiemHoaTu.Enabled = true;
                nudDiemHoaDen.Enabled = true;
            }
            else
            {
                nudDiemHoaTu.Enabled = false;
                nudDiemHoaDen.Enabled = false;
            }
        }

        private void chkDiemSinh_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDiemSinh.Checked == true)
            {
                nudDiemSinhTu.Enabled = true;
                nudDiemSinhDen.Enabled = true;
            }
            else
            {
                nudDiemSinhTu.Enabled = false;
                nudDiemSinhDen.Enabled = false;
            }
        }

        private void chkDiemSu_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDiemSu.Checked == true)
            {
                nudDiemSuTu.Enabled = true;
                nudDiemSuDen.Enabled = true;
            }
            else
            {
                nudDiemSuTu.Enabled = false;
                nudDiemSuDen.Enabled = false;
            }
        }

        private void chkDiemDia_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDiemDia.Checked == true)
            {
                nudDiemDiaTu.Enabled = true;
                nudDiemDiaDen.Enabled = true;
            }
            else
            {
                nudDiemDiaTu.Enabled = false;
                nudDiemDiaDen.Enabled = false;
            }
        }

        private void chkDiemVan_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDiemVan.Checked == true)
            {
                nudDiemVanTu.Enabled = true;
                nudDiemVanDen.Enabled = true;
            }
            else
            {
                nudDiemVanTu.Enabled = false;
                nudDiemVanDen.Enabled = false;
            }
        }

        private void chkDaoDuc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDaoDuc.Checked == true)
            {
                nudDaoDucTu.Enabled = true;
                nudDaoDucDen.Enabled = true;
            }
            else
            {
                nudDaoDucTu.Enabled = false;
                nudDaoDucDen.Enabled = false;
            }
        }

        private void chkTheDuc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTheDuc.Checked == true)
            {
                nudTheDucTu.Enabled = true;
                nudTheDucDen.Enabled = true;
            }
            else
            {
                nudTheDucTu.Enabled = false;
                nudTheDucDen.Enabled = false;
            }
        }

        private void chkDTB_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDTB.Checked == true)
            {
                nudDTBTu.Enabled = true;
                nudDTBDen.Enabled = true;
            }
            else
            {
                nudDTBTu.Enabled = false;
                nudDTBDen.Enabled = false;
            }
        }

        private void chkLopHoc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLopHoc.Checked == true)
            {
                cmbLopHoc.Enabled = true;
            }
            else
            {
                cmbLopHoc.Enabled = false;
            }
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }       
    }
}
