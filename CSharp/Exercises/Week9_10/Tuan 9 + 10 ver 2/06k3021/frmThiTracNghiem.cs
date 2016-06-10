using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Collections;
using _6k3021;

namespace _6k3021
{   
    public partial class frmThiTracNghiem : Form
    {

        public frmThiTracNghiem()
        {
            InitializeComponent();
        }
        int index = 0;
        private bool Thi = false;
        List<string> _baiThi = new List<string>();
        ArrayList _danhSachCauTraLoi = new ArrayList();


        CDeThi deThi = new CDeThi();
        private int _phut;

        public int Phut
        {
            get { return _phut; }
            set { _phut = value; }
        }
        private int _giay;

        public int Giay
        {
            get { return _giay; }
            set { _giay = value; }
        }
        private string _duongDan;

        public string DuongDan
        {
            get { return _duongDan; }
            set { _duongDan = value; }
        }

        private void LoadCauHoi(CCauTracNghiem cauTracNghiem)
        {
            ucCauHoiTracNghiem1.CauHoi = cauTracNghiem.NoiDungCauHoi;
            ucCauHoiTracNghiem1.DapAnA = cauTracNghiem.DapAnA;
            ucCauHoiTracNghiem1.DapAnB = cauTracNghiem.DapAnB;
            ucCauHoiTracNghiem1.DapAnC = cauTracNghiem.DapAnC;
            ucCauHoiTracNghiem1.DapAnD = cauTracNghiem.DapAnD;
        }

       
        private void btnBrowse_Click(object sender, EventArgs e)
        {
           OpenFileDialog duongDan = new OpenFileDialog();
           duongDan.Filter = "Excel File (*.xml)| *.xml";
           duongDan.RestoreDirectory = true;

            if (duongDan.ShowDialog() == DialogResult.OK)
            {
                txtDuongDan.Text = duongDan.FileName;
            }

            deThi.DocFileXML(duongDan.FileName);
        }

        private void btnBatDauThi_Click(object sender, EventArgs e)
        {
            Thi = true;
            if (txtDuongDan.Text != string.Empty)
            {
                string Answer = ucCauHoiTracNghiem1.DapAnDuocChon;
                _baiThi.Add(Answer);
                deThi.Equals(txtDuongDan.Text);

                CCauTracNghiem cauTracNghiem = (CCauTracNghiem)deThi.DanhSachCauHoi[index];
                LoadCauHoi(cauTracNghiem);

                btnCauTruocDo.Enabled = false;
                btnXemKetQua.Enabled = false;

                this.DongHo.Start();
               
            }
        }

        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            //Tao 2 bien so cau tra loi dung sai
            int Dung = 0;
            int Sai = 0;

            Thi=false;
            this.DongHo.Stop();

            for (int i = 0; i < deThi.DanhSachCauHoi.Count; i++)
            {
                CCauTracNghiem TraLoi = (CCauTracNghiem)deThi.DanhSachCauHoi[i];

                foreach (string str in _baiThi)
                {
                    if (TraLoi.KiemTraDapAn(str))
                    {
                        //Neu tra loi dung thi tang dung len 1 va tuong tu khi sai
                        Dung++;
                        break;
                    }
                    else
                    {
                        Sai++;
                        break;
                    }
                }
            }

        }

        private void btnXemKetQua_Click(object sender, EventArgs e)
        {
            btnCauTiepTheo.Enabled = true;
            btnCauTruocDo.Enabled = false;

            //Xoa cau hoi trac nghiem
            ucCauHoiTracNghiem1.DapAnDuocChon = string.Empty;
            ucCauHoiTracNghiem1.DapAnA = string.Empty;
            ucCauHoiTracNghiem1.DapAnB = string.Empty;
            ucCauHoiTracNghiem1.DapAnC = string.Empty;
            ucCauHoiTracNghiem1.DapAnD = string.Empty;
            index = 0;

            CCauTracNghiem cauTracNghiem = new CCauTracNghiem();
            cauTracNghiem = deThi.DanhSachCauHoi[index];
            LoadCauHoi(cauTracNghiem);
            ucCauHoiTracNghiem1.KiemTra(cauTracNghiem.DapAnDung, _baiThi[index]);
            ucCauHoiTracNghiem1.XemDA(_baiThi[index]);
            
        }

        private void btnCauTiepTheo_Click(object sender, EventArgs e)
        {
            index++;
            if (index <= _danhSachCauTraLoi.Count -1 )
            {

                CCauTracNghiem cauTracNghiem = (CCauTracNghiem)deThi.DanhSachCauHoi[index];
                LoadCauHoi(cauTracNghiem);
                btnCauTruocDo.Enabled = true;
                if (Thi==true)
                {

                    string Answer = ucCauHoiTracNghiem1.DapAnDuocChon;
                    _baiThi.Add(Answer);
                }
            }
            else
            {
                this.DongHo.Stop();
                MessageBox.Show("Ket thuc bai thi roi !");
            }
        }

        private void btnCauTruocDo_Click(object sender, EventArgs e)
        {
            index--;
            CCauTracNghiem cauTracNghiem = (CCauTracNghiem)deThi.DanhSachCauHoi[index];
            LoadCauHoi(cauTracNghiem);
            if (Thi==true)
            {
                string Answer = ucCauHoiTracNghiem1.DapAnDuocChon;
                _baiThi.Add(Answer);
            }
        }

        private void DongHo_Tick(object sender, EventArgs e)
        {
            _giay++;
            lblGiay.Text = _giay.ToString();
            if (_giay == 59)
            {

                _giay = 0;
                _phut++;
            }
        }
    }
}