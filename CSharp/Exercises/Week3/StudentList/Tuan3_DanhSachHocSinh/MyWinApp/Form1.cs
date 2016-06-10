using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyLibrary;
using System.IO;


namespace MyWinApp
{
    public partial class frmDanhSachSinhVien : Form
    {
        private CLop lop = new CLop();
        private int siso = 0;
        public frmDanhSachSinhVien()
        {
            InitializeComponent();
        }

        private string KiemTraNhapLieu()
        {
            string thongBao = "";
            if (CSinhVien.KiemTraHoTen(txtHovaTen.Text) == false)
                thongBao += "Họ tên không hợp lệ\n";
            if (CSinhVien.KiemTraMSSV(txtMSSV.Text) == false)
                thongBao += "MSSV không hợp lệ\n";
            if (CSinhVien.KiemTraDienThoai(txtDienThoai.Text) == false)
                thongBao += "Điện Thoại không hợp lệ\n";
            if (CSinhVien.KiemTraEmail(txtEmail.Text) == false)
                thongBao += "Email không hợp lệ\n";
            return thongBao;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string thongBao = KiemTraNhapLieu();
            if (thongBao == "")
            {               
                CSinhVien sinhVien = new CSinhVien();
                sinhVien.MSSV = txtMSSV.Text;
                sinhVien.HoTen = txtHovaTen.Text;
                sinhVien.DiaChi = txtDiaChi.Text;
                sinhVien.DienThoai = txtDienThoai.Text;
                sinhVien.Email = txtEmail.Text;
                
                if (lop.ThemSinhVien(sinhVien))
                {
                    // Them vao list box
                    lbxDanhSach .Items.Add(sinhVien.HoTen);
                    siso += 1;
                    lblsiso.Text = "Số lượng sinh viên : " + siso.ToString();
                    lblKiemTra.Text = "";
                }
                else
                {
                    MessageBox.Show("MSSV da ton tai");
                }
            }
            else
            {
                lblKiemTra.Text = thongBao;
            }
        }      

        private void btnGhiFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Txt file (*.txt)|*.txt";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Ghi danh sach lop
                FileInfo fi = new FileInfo(dialog.FileName);                
                string[] arr = fi.Name.Split('.');
                lop.TenLop = arr[0];
                lop.GhiDanhSachLop(dialog.FileName);                
            }
        }

        private void btnDocFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();          
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Doc danh sach lop  
                lop.DocDanhSachLop(dialog.FileName);
                foreach (CSinhVien sinhVien in lop.DanhSachLop)
                {
                    lbxDanhSach.Items.Add(sinhVien.HoTen);
                }
                siso = lop.DanhSachLop.Count;
                lblsiso.Text = "Số lượng sinh viên : " + siso.ToString();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {        
            if (lbxDanhSach.SelectedIndex >= 0)
            {
                CSinhVien sinhVien = lop.LaySinhVien(lbxDanhSach.SelectedIndex);
                lop.XoaSinhVien(sinhVien);
                lbxDanhSach.Items.Remove(sinhVien.HoTen);
                siso -= 1;
                lblsiso.Text = "Số lượng sinh viên : " + siso.ToString();
            }
            else
            {
              MessageBox.Show("Chua chon sinh vien can xoa");
            }           
        }      

        private void lbxDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxDanhSach.SelectedIndex >= 0)
            {
                CSinhVien SinhVien = new CSinhVien();
                SinhVien = lop.LaySinhVien(lbxDanhSach.SelectedIndex);
                txtMSSV.Text = SinhVien.MSSV;
                txtHovaTen.Text = SinhVien.HoTen;
                txtDiaChi.Text = SinhVien.DiaChi;
                txtDienThoai.Text = SinhVien.DienThoai;
                txtEmail.Text = SinhVien.Email;      
            }                   
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (lbxDanhSach.SelectedIndex >= 0)
            {
                CSinhVien sinhVien = lop.LaySinhVien(lbxDanhSach.SelectedIndex);
                lbxDanhSach.Items.Remove(sinhVien.HoTen);
                sinhVien.MSSV = txtMSSV.Text;
                sinhVien.HoTen = txtHovaTen.Text;
                sinhVien.DiaChi = txtDiaChi.Text;
                sinhVien.DienThoai = txtDienThoai.Text;
                sinhVien.Email = txtEmail.Text;
                lop.CapNhatSinhVien(sinhVien);
                lbxDanhSach.Items.Add(sinhVien.HoTen);
            }
            else
            {
                MessageBox.Show("Chua chon sinh vien can cap nhat");
            }       
        }

        private void frmDanhSachSinhVien_Load(object sender, EventArgs e)
        {
            lblsiso.Text = "Số lượng sinh viên : " + siso.ToString();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            lop.Sort();
            foreach (CSinhVien sv in lop.DanhSachLop)
            {
                lbxDanhSach.Items.Remove(sv.HoTen);
            }
            foreach (CSinhVien sv in lop.DanhSachLop)
            {
                lbxDanhSach.Items.Add(sv.HoTen);
            }
        }             
    }
}