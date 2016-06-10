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
using System.Collections;

namespace Do_An_Cong_Ty
{
    public partial class frmBaoCaoTongKet : Form
    {
        private bool _baoCaoMon;
        private bool _baoCaoHocKy;

        public bool BaoCaoHocKy
        {
            get { return _baoCaoHocKy; }
            set { _baoCaoHocKy = value; }
        }

        public bool BaoCaoMon
        {
            get { return _baoCaoMon; }
            set { _baoCaoMon = value; }
        }

        public frmBaoCaoTongKet()
        {
            InitializeComponent();
        }

        private void frmBaoCaoTongKet_Load(object sender, EventArgs e)
        {
            if (_baoCaoMon)
                this.tabPageHocKy.Dispose();
            if (_baoCaoHocKy)
                this.tabPageMon.Dispose();

            ///////////////////////////////////////
            HocKyBUS HKBUS = new HocKyBUS();
            cbxHocKy.DataSource = HKBUS.LayBang();
            cbxHocKy.DisplayMember = "TenHocKy";
            cbxHocKy.ValueMember = "MaHocKy";

            MonBUS MBUS = new MonBUS();
            cbxMonHoc.DataSource = MBUS.LayBang();
            cbxMonHoc.DisplayMember = "TenMon";
            cbxMonHoc.ValueMember = "MaMon";

            cbxHK.DataSource = HKBUS.LayBang();
            cbxHK.DisplayMember = "TenHocKy";
            cbxHK.ValueMember = "MaHocKy";

            LopHocBUS lhBUS = new LopHocBUS();           
            DataTable dt = new DataTable();
            dt.Columns.Add("STT");
            dt.Columns.Add("Ten Lop");
            dt.Columns.Add("Si So");
            dt.Columns.Add("So Luong Dat");
            dt.Columns.Add("Ti Le Dat");
            ArrayList dsTenLop = new ArrayList();            
            HocSinhBUS hsBUS = new HocSinhBUS();
            dsTenLop = lhBUS.LayDSLopHoc((string)cbxMonHoc.SelectedValue,(string)cbxHocKy.SelectedValue);

            for (int i = 0; i < dsTenLop.Count; i++)
            {
                ArrayList arr = new ArrayList();
                DataRow row = dt.NewRow();
                row[0] = i + 1;
                row[1] = (string)dsTenLop[i];
                int siso = lhBUS.DSSoLuongHS((string)dsTenLop[i]);
                row[2] = siso;
                arr = hsBUS.LayDSTenHS((string)cbxMonHoc.SelectedValue,(string)cbxHocKy.SelectedValue, (string)dsTenLop[i]);
                row[3] = arr.Count;
                double tile = Math.Round((((double)arr.Count) / ((double)siso)) * 100, 2);
                row[4] = (tile + " %");
                dt.Rows.Add(row);
            }
            dtgvBaoCaoMon.DataSource = dt;       
  
            /////////////////////////////

            DataTable dt1 = new DataTable();
            dt1.Columns.Add("STT");
            dt1.Columns.Add("Ten Lop");
            dt1.Columns.Add("Si So");
            dt1.Columns.Add("So Luong Dat");
            dt1.Columns.Add("Ti Le Dat");

            ArrayList dsLopHoc = new ArrayList();           
            dsLopHoc = lhBUS.LayDSLopHoc((string)cbxHK.SelectedValue);

            for (int i = 0; i < dsLopHoc.Count; i++)
            {
                DataRow row = dt1.NewRow();
                row[0] = i + 1;
                row[1] = (string)dsLopHoc[i];
                int siso = lhBUS.DSSoLuongHS((string)dsLopHoc[i]);
                row[2] = siso;
                ArrayList arr = new ArrayList();
                arr = hsBUS.LayDSTenHS((string)cbxHK.SelectedValue, (string)dsLopHoc[i]);
                row[3] = arr.Count;
                double tile = Math.Round((((double)arr.Count) / ((double)siso)) * 100, 2);
                row[4] = (tile + " %");
                dt1.Rows.Add(row);
            }
            dtgvHocKy.DataSource = dt1;
           
        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThucThi_Click(object sender, EventArgs e)
        {
            LopHocBUS lhBUS = new LopHocBUS();
            DataTable dt = new DataTable();
            dt.Columns.Add("STT");
            dt.Columns.Add("Ten Lop");
            dt.Columns.Add("Si So");
            dt.Columns.Add("So Luong Dat");
            dt.Columns.Add("Ti Le Dat");
            ArrayList dsTenLop = new ArrayList();
            HocSinhBUS hsBUS = new HocSinhBUS();
            dsTenLop = lhBUS.LayDSLopHoc((string)cbxMonHoc.SelectedValue, (string)cbxHocKy.SelectedValue);

            for (int i = 0; i < dsTenLop.Count; i++)
            {
                ArrayList arr = new ArrayList();
                DataRow row = dt.NewRow();
                row[0] = i + 1;
                row[1] = (string)dsTenLop[i];
                int siso = lhBUS.DSSoLuongHS((string)dsTenLop[i]);
                row[2] = siso;
                arr = hsBUS.LayDSTenHS((string)cbxMonHoc.SelectedValue, (string)cbxHocKy.SelectedValue, (string)dsTenLop[i]);
                row[3] = arr.Count;
                double tile = Math.Round((((double)arr.Count) / ((double)siso)) * 100, 2);
                row[4] = (tile + " %");
                dt.Rows.Add(row);
            }
            dtgvBaoCaoMon.DataSource = dt;        
        }

        private void btnThoatHK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThucThiHK_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("STT");
            dt1.Columns.Add("Ten Lop");
            dt1.Columns.Add("Si So");
            dt1.Columns.Add("So Luong Dat");
            dt1.Columns.Add("Ti Le Dat");

            ArrayList dsLopHoc = new ArrayList();
            LopHocBUS lhBUS = new LopHocBUS();
            HocSinhBUS hsBUS = new HocSinhBUS();
            dsLopHoc = lhBUS.LayDSLopHoc((string)cbxHK.SelectedValue);

            for (int i = 0; i < dsLopHoc.Count; i++)
            {
                DataRow row = dt1.NewRow();
                row[0] = i + 1;
                row[1] = (string)dsLopHoc[i];
                int siso = lhBUS.DSSoLuongHS((string)dsLopHoc[i]);
                row[2] = siso;
                ArrayList arr = new ArrayList();
                arr = hsBUS.LayDSTenHS((string)cbxHK.SelectedValue, (string)dsLopHoc[i]);
                row[3] = arr.Count;
                double tile = Math.Round((((double)arr.Count) / ((double)siso)) * 100, 2);
                row[4] = (tile + " %");
                dt1.Rows.Add(row);
            }
            dtgvHocKy.DataSource = dt1;
        }

    }
}