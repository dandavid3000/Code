using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyLiberary;
using System.IO;

namespace WindowsApplication1
{

    public partial class Form1 : Form
    {
        private CLop lop = new CLop();            
                
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string KiemTraNhapLieu()
        {
            string thongBao = "";
            if (CSinhVien.KiemTraHoTen(txtHoTen.Text) == false)
                thongBao += "Ho ten khong hop le\n";
            if (CSinhVien.KiemTraMSSV(txtMSSV.Text) == false)
                thongBao += "MSSV khong hop le\n";
            // ... kiem tra cac thuoc tinh khac
            return thongBao;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string thongBao = KiemTraNhapLieu();
            if (thongBao == "")
            {
                CSinhVien sinhVien = new CSinhVien();
                sinhVien.MSSV = txtMSSV.Text;
                sinhVien.HoTen = txtHoTen.Text;
                sinhVien.DiaChi = txtDiaChi.Text;
                sinhVien.Email = txtEmail.Text;
                sinhVien.SoDienThoai = txtDiaChi.Text;
                lblSLSV.Text = lop.DanhSachLop.Count.ToString();
                
                // ... thuoc tinh khac
                if (lop.ThemSinhVien(sinhVien))
                {
                    // Them vao list box
                    lbxDanhSach.Items.Add(sinhVien.HoTen);
                }
                else
                {
                    MessageBox.Show("MSSV da ton tai");
                }
            }
            else
            {
                lblThongBaoLoi.Text = thongBao;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lbxDanhSach.SelectedIndex >= 0)
            {
                CSinhVien sinhVien = lop.LaySinhVien(lbxDanhSach.SelectedIndex);
                lop.XoaSinhVien(sinhVien);
                // Them vao list box
            

                lbxDanhSach.Items.RemoveAt(lbxDanhSach.SelectedIndex);
                lblSLSV.Text = lop.DanhSachLop.Count.ToString();
             }
            else
            {
                MessageBox.Show("Chua chon sinh vien can xoa");
            }
        }

        private void btnGhiFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Txt file (*.txt)|*.txt";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Ghi danh sach lop
                lop.GhiDanhSachLop(dialog.FileName);
            }
        }

        private void btnDocFile_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Txt file (*.txt)| *.txt";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                lop.DocDanhSachLop(dialog.FileName);
            }

            lbxDanhSach.Items.Clear();
            ArrayList danhsach = new ArrayList();

            danhsach = lop.DanhSachLop;
            foreach (CSinhVien sinhvien in danhsach)
            {
                lbxDanhSach.Items.Add(sinhvien.HoTen);

            }
            
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (lbxDanhSach.SelectedIndex >= 0)
            {             
               // string thongBao = KiemTraNhapLieu();
               CSinhVien sinhVien = new CSinhVien();
                sinhVien=lop.LaySinhVien(lbxDanhSach.SelectedIndex);                                 
                
                txtMSSV.Text = sinhVien.MSSV;
                txtHoTen.Text = sinhVien.HoTen;
                txtDiaChi.Text = sinhVien.DiaChi;
                txtEmail.Text = sinhVien.Email;
                txtDienThoai.Text = sinhVien.SoDienThoai;

                lblSLSV.Text = lop.DanhSachLop.Count.ToString();
                              
            }
            else
            {
                MessageBox.Show("Ko co sinh vien");
            }
        }

       
    }
}