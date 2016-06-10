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
    public partial class frmNhapDiem : Form
    {
        public frmNhapDiem()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmNhapDiem_Load(object sender, EventArgs e)
        {
            maskMaHocSinh.Mask = "00L0000";
            TList<HocKy> ds = new TList<HocKy>();
            HocKyBUS hkBUS = new HocKyBUS();
            cbxHocKy.DataSource = hkBUS.LayBang();
            cbxHocKy.DisplayMember = "TenHocKy";
            cbxHocKy.ValueMember = "MaHocKy";
        }       

        private void btnThucThi_Click(object sender, EventArgs e)
        {
            HocSinhBUS hsBus = new HocSinhBUS();
            bool flag = hsBus.KTTonTai(maskMaHocSinh.Text);
            if (flag == false)
            {
                MessageBox.Show("Mã học sinh không tồn tại");
            }
            else
            {                
                BangDiem bd = new BangDiem();
                BangDiemBUS bdBUS = new BangDiemBUS();
                bd.MaBangDiem = bdBUS.LayMaLonNhat();
                bd.MaHocSinh = maskMaHocSinh.Text;
                bdBUS.Them(bd);

                DiemBUS dBUS = new DiemBUS();
                Diem d = new Diem();
                d.MaBangDiem = bd.MaBangDiem;
                d.MaDiem = dBUS.LayMaDiemLonNhat();
                d.Diem15Phut = Convert.ToDouble(XuLyRong(txtToan15.Text));
                d.Diem1Tiet = Convert.ToDouble(XuLyRong(txtToan1Tiet.Text));
                d.DiemCuoiKy = Convert.ToDouble(XuLyRong(txtToanCuoiKy.Text));
                d.Dtb = dBUS.TinhDTB(d.Diem15Phut, d.Diem1Tiet, d.DiemCuoiKy);
                d.MaMon = "MH001";
                d.MaHocKy = (string)cbxHocKy.SelectedValue;
                dBUS.Them(d);

                Diem d1 = new Diem();
                d1.MaBangDiem = bd.MaBangDiem;
                d1.MaDiem = dBUS.LayMaDiemLonNhat();
                d1.Diem15Phut = Convert.ToDouble(XuLyRong(txtLy15.Text));
                d1.Diem1Tiet = Convert.ToDouble(XuLyRong(txtLy1Tiet.Text));
                d1.DiemCuoiKy = Convert.ToDouble(XuLyRong(txtLyCuoiKy.Text));
                d1.Dtb = dBUS.TinhDTB(d1.Diem15Phut, d1.Diem1Tiet, d1.DiemCuoiKy);
                d1.MaMon = "MH002";
                d1.MaHocKy = (string)cbxHocKy.SelectedValue;
                dBUS.Them(d1);

                Diem d2 = new Diem();
                d2.MaBangDiem = bd.MaBangDiem;
                d2.MaDiem = dBUS.LayMaDiemLonNhat();
                d2.Diem15Phut = Convert.ToDouble(XuLyRong(txtHoa15.Text));
                d2.Diem1Tiet = Convert.ToDouble(XuLyRong(txtHoa1Tiet.Text));
                d2.DiemCuoiKy = Convert.ToDouble(XuLyRong(txtHoaCuoiKy.Text));
                d2.Dtb = dBUS.TinhDTB(d2.Diem15Phut, d2.Diem1Tiet, d2.DiemCuoiKy);
                d2.MaMon = "MH003";
                d2.MaHocKy = (string)cbxHocKy.SelectedValue;
                dBUS.Them(d2);

                Diem d3 = new Diem();
                d3.MaBangDiem = bd.MaBangDiem;
                d3.MaDiem = dBUS.LayMaDiemLonNhat();
                d3.Diem15Phut = Convert.ToDouble(XuLyRong(txtSinh15.Text));
                d3.Diem1Tiet = Convert.ToDouble(XuLyRong(txtSinh1Tiet.Text));
                d3.DiemCuoiKy = Convert.ToDouble(XuLyRong(txtSinhCuoiKy.Text));
                d3.Dtb = dBUS.TinhDTB(d3.Diem15Phut, d3.Diem1Tiet, d3.DiemCuoiKy);
                d3.MaMon = "MH004";
                d3.MaHocKy = (string)cbxHocKy.SelectedValue;
                dBUS.Them(d3);

                Diem d4 = new Diem();
                d4.MaBangDiem = bd.MaBangDiem;
                d4.MaDiem = dBUS.LayMaDiemLonNhat();
                d4.Diem15Phut = Convert.ToDouble(XuLyRong(txtSu15.Text));
                d4.Diem1Tiet = Convert.ToDouble(XuLyRong(txtSu1Tiet.Text));
                d4.DiemCuoiKy = Convert.ToDouble(XuLyRong(txtSuCuoiKy.Text));
                d4.Dtb = dBUS.TinhDTB(d4.Diem15Phut, d4.Diem1Tiet, d4.DiemCuoiKy);
                d4.MaMon = "MH005";
                d4.MaHocKy = (string)cbxHocKy.SelectedValue;
                dBUS.Them(d4);

                Diem d5 = new Diem();
                d5.MaBangDiem = bd.MaBangDiem;
                d5.MaDiem = dBUS.LayMaDiemLonNhat();
                d5.Diem15Phut = Convert.ToDouble(XuLyRong(txtDia15.Text));
                d5.Diem1Tiet = Convert.ToDouble(XuLyRong(txtDia1Tiet.Text));
                d5.DiemCuoiKy = Convert.ToDouble(XuLyRong(txtDiaCuoiKy.Text));
                d5.Dtb = dBUS.TinhDTB(d5.Diem15Phut, d5.Diem1Tiet, d5.DiemCuoiKy);
                d5.MaMon = "MH006";
                d5.MaHocKy = (string)cbxHocKy.SelectedValue;
                dBUS.Them(d5);

                Diem d6 = new Diem();
                d6.MaBangDiem = bd.MaBangDiem;
                d6.MaDiem = dBUS.LayMaDiemLonNhat();
                d6.Diem15Phut = Convert.ToDouble(XuLyRong(txtVan15.Text));
                d6.Diem1Tiet = Convert.ToDouble(XuLyRong(txtVan1Tiet.Text));
                d6.DiemCuoiKy = Convert.ToDouble(XuLyRong(txtVanCuoiKy.Text));
                d6.Dtb = dBUS.TinhDTB(d6.Diem15Phut, d6.Diem1Tiet, d6.DiemCuoiKy);
                d6.MaMon = "MH007";
                d6.MaHocKy = (string)cbxHocKy.SelectedValue;
                dBUS.Them(d6);

                Diem d7 = new Diem();
                d7.MaBangDiem = bd.MaBangDiem;
                d7.MaDiem = dBUS.LayMaDiemLonNhat();
                d7.Diem15Phut = Convert.ToDouble(XuLyRong(txtDaoDuc15.Text));
                d7.Diem1Tiet = Convert.ToDouble(XuLyRong(txtDaoDuc1Tiet.Text));
                d7.DiemCuoiKy = Convert.ToDouble(XuLyRong(txtDaoDucCuoiKy.Text));
                d7.Dtb = dBUS.TinhDTB(d7.Diem15Phut, d7.Diem1Tiet, d7.DiemCuoiKy);
                d7.MaMon = "MH008";
                d7.MaHocKy = (string)cbxHocKy.SelectedValue;
                dBUS.Them(d7);

                Diem d8 = new Diem();
                d8.MaBangDiem = bd.MaBangDiem;
                d8.MaDiem = dBUS.LayMaDiemLonNhat();
                d8.Diem15Phut = Convert.ToDouble(XuLyRong(txtTheDuc15.Text));
                d8.Diem1Tiet = Convert.ToDouble(XuLyRong(txtTheDuc1Tiet.Text));
                d8.DiemCuoiKy = Convert.ToDouble(XuLyRong(txtTheDucCuoiKy.Text));
                d8.Dtb = dBUS.TinhDTB(d8.Diem15Phut, d8.Diem1Tiet, d8.DiemCuoiKy);
                d8.MaMon = "MH009";
                d8.MaHocKy = (string)cbxHocKy.SelectedValue;
                dBUS.Them(d8);

                bd.Dtb = bdBUS.TinhDTB(d.Dtb, d1.Dtb, d2.Dtb, d3.Dtb, d4.Dtb, d5.Dtb, d6.Dtb, d7.Dtb, d8.Dtb);
                bdBUS.CapNhat(bd);

                MessageBox.Show("Nhập điểm thành công");
                this.Close();        
            }            
        }

        public string XuLyRong(string str)
        {
            if (str == "")
                str = "0";
            return str;
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            txtDaoDuc15.Text = "0";
            txtDaoDuc1Tiet.Text = "0";
            txtDaoDucCuoiKy.Text = "0";
            txtDia15.Text = "0";
            txtDia1Tiet.Text = "0";
            txtDiaCuoiKy.Text = "0";
            txtHoa15.Text = "0";
            txtHoa1Tiet.Text = "0";
            txtHoaCuoiKy.Text = "0";
            txtLy15.Text = "0";
            txtLy1Tiet.Text = "0";
            txtLyCuoiKy.Text = "0";
            txtSinh15.Text = "0";
            txtSinh1Tiet.Text = "0";
            txtSinhCuoiKy.Text = "0";
            txtSu15.Text = "0";
            txtSu1Tiet.Text = "0";
            txtSuCuoiKy.Text = "0";
            txtTheDuc15.Text = "0";
            txtTheDuc1Tiet.Text = "0";
            txtTheDucCuoiKy.Text = "0";
            txtToan15.Text = "0";
            txtToan1Tiet.Text = "0";
            txtToanCuoiKy.Text = "0";
            txtVan15.Text = "0";
            txtVan1Tiet.Text = "0";
            txtVanCuoiKy.Text = "0";
        }

        private void maskMaHocSinh_TextChanged(object sender, EventArgs e)
        {
            if (maskMaHocSinh.MaskCompleted)
            {
                HocSinh hs = new HocSinh();
                HocSinhBUS hsBUS = new HocSinhBUS();
                hs = hsBUS.LayHocSinh(maskMaHocSinh.Text);
                if (hs != null)
                    txtHoTen.Text = hs.HoTenHocSinh;
                else
                    txtHoTen.Text = "";
            }
            else
                txtHoTen.Text = "";
        }           
    }
}