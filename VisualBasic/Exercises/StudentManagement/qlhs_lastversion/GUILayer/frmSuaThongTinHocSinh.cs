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
    public partial class frmSuaThongTinHocSinh : Form
    {
        public frmSuaThongTinHocSinh()
        {
            InitializeComponent();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSuaThongTinHocSinh_Load(object sender, EventArgs e)
        {
            radNam.Checked = true;
            radNu.Checked = false;
            maskMaHocSinh.Mask = "00L0000";

            LopHocBUS lhBUS = new LopHocBUS();
            cbxLop.DataSource = lhBUS.LayBang();
            cbxLop.DisplayMember = "TenLop";
            cbxLop.ValueMember = "MaLop";
                  
            string[] XepLoai = { "Xuat Sac", "Gioi", "Kha", "Trung Binh", "Yeu" };
            cbxXepLoai.DataSource = XepLoai;

            string[] HanhKiem ={ "Tot", "Kha", "Trung Binh", "Yeu" };
            cbxHanhKiem.DataSource = HanhKiem;           
        }

        private void maskMaHocSinh_TextChanged(object sender, EventArgs e)
        {
            if (maskMaHocSinh.MaskCompleted)
            {
                HocSinh hs = new HocSinh();
                HocSinhBUS hsBUS = new HocSinhBUS();
                hs = hsBUS.LayHocSinh(maskMaHocSinh.Text);
                if (hs != null)
                {
                    txtHoTenHocSinh.Text = hs.HoTenHocSinh;
                    if (hs.GioiTinh == "Nam")
                        radNam.Checked = true;
                    else if (hs.GioiTinh == "Nu")
                        radNu.Checked = true;
                    dtpkNgaySinh.Value = hs.NgaySinh;
                   
                    cbxLop.SelectedValue = hs.MaLop;
                    cbxHanhKiem.SelectedItem = hs.HanhKiem;
                    cbxXepLoai.SelectedItem = hs.XepLoai;
                    txtDiaChi.Text = hs.DiaChi;
                    txtEmail.Text = hs.Email;
                }
                else
                {
                    txtHoTenHocSinh.Text = "";
                    txtDiaChi.Text = "";
                    txtEmail.Text = "";
                    radNam.Checked = true;
                }

            }
            else
            {
                txtHoTenHocSinh.Text = "";
                txtDiaChi.Text = "";
                txtEmail.Text = "";
                radNam.Checked = true;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            HocSinh hs = new HocSinh();
            HocSinhBUS hsBUS = new HocSinhBUS();
            hs = hsBUS.LayHocSinh((string)maskMaHocSinh.Text);
            if (hs != null)
            {
                if (HocSinhBUS.KiemTraHoTen(txtHoTenHocSinh.Text))
                {
                    if (HocSinhBUS.KiemTraEmail(txtEmail.Text))
                    {
                        if (hs.MaLop == (string)cbxLop.SelectedValue)
                        {
                            hs.MaHocSinh = maskMaHocSinh.Text;
                            hs.HoTenHocSinh = txtHoTenHocSinh.Text;
                            hs.HanhKiem = (string)cbxHanhKiem.SelectedItem;
                            if (radNam.Checked)
                                hs.GioiTinh = "Nam";
                            else if (radNu.Checked)
                                hs.GioiTinh = "Nu";
                            hs.NgaySinh = dtpkNgaySinh.Value;
                            hs.DiaChi = txtDiaChi.Text;
                            hs.Email = txtEmail.Text;
                            hs.XepLoai = (string)cbxXepLoai.SelectedItem;
                            hs.MaLop = (string)cbxLop.SelectedValue;
                            if (MessageBox.Show("Bạn có chắc chắn muốn sửa thông tin học sinh này không?", "Thông Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                bool kq = hsBUS.CapNhat(hs);
                                if (kq)
                                    MessageBox.Show("Sửa thông tin học sinh thành công");
                                else
                                    MessageBox.Show("Sửa thông tin học sinh thất bại");
                                maskMaHocSinh.Text = "";
                                txtHoTenHocSinh.Text = "";
                                txtDiaChi.Text = "";
                                txtEmail.Text = "";
                                radNam.Checked = true;
                            }
                        }
                        else
                        {
                            if (MessageBox.Show("Bạn có chắc chắn muốn chuyển lớp cho học sinh này không?", "Thông Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
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

                                if (cbxLop.SelectedValue.GetType().Name == "LopHoc")
                                {
                                    LopHoc lh = (LopHoc)cbxLop.SelectedValue;
                                    hs.MaHocSinh = hsBUS.LayMaHSLonNhatTheoLop(lh.MaLop);
                                }
                                else
                                {
                                    hs.MaHocSinh = hsBUS.LayMaHSLonNhatTheoLop((string)cbxLop.SelectedValue);
                                }                                
                                string thongbao = "Mã học sinh vừa thay đổi: " + hs.MaHocSinh;                                
                                MessageBox.Show(thongbao,"Thông Báo");
                                hs.HoTenHocSinh = txtHoTenHocSinh.Text;
                                hs.HanhKiem = (string)cbxHanhKiem.SelectedItem;
                                if (radNam.Checked)
                                    hs.GioiTinh = "Nam";
                                else if (radNu.Checked)
                                    hs.GioiTinh = "Nu";
                                hs.NgaySinh = dtpkNgaySinh.Value;
                                hs.DiaChi = txtDiaChi.Text;
                                hs.Email = txtEmail.Text;
                                hs.XepLoai = (string)cbxXepLoai.SelectedItem;
                                hs.MaLop = (string)cbxLop.SelectedValue;
                               
                                bool kq1 = hsBUS.Them(hs);
                                if (kq1)
                                {
                                    hsBUS.NhapDiemMacDinh(hs);
                                    MessageBox.Show("Sửa thông tin học sinh thành công");
                                    maskMaHocSinh.Text = "";
                                    txtHoTenHocSinh.Text = "";
                                    txtDiaChi.Text = "";
                                    txtEmail.Text = "";
                                    radNam.Checked = true; 
                                }
                                else
                                    MessageBox.Show("Sửa thông tin học sinh thất bại");                                                          
                            }                            
                        }
                        
                    }
                    else
                        MessageBox.Show("Email không hợp lệ");
                }
                else
                    MessageBox.Show("Họ tên không hợp lệ");
                
            }
            else
                MessageBox.Show("Mã học sinh không tồn tại");            
        }        
    }
}