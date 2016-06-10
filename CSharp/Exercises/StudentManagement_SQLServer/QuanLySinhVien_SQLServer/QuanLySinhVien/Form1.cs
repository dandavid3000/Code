using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace QuanLySinhVien
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Dao dao = new Dao();
            DataTable dt = dao.LayDanhSachLop();
            cboLop.DataSource = dt;
            cboLop.ValueMember = "MaLop";
            cboLop.DisplayMember = "TenLop";
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            Dao dao = new Dao();
            int MaLop = int.Parse(cboLop.SelectedValue.ToString());

            DataTable dt = dao.LayDanhSachSinhVienTheoLop(MaLop);

            #region Load report tĩnh
            //Cách 1 : Load report tĩnh
            //rptSinhVien rpt = new rptSinhVien();
            #endregion

            #region Load Report động
            //Cách 2 : Load report động từ một thư mục chỉ định
            string path = Application.StartupPath + "\\Reports\\rptSinhVien.rpt";
            ReportDocument rpt = new ReportDocument();
            #endregion

            //Load report
            rpt.Load(path);
            rpt.SetDataSource(dt);
            //Hiển thị trên report lọc sinh viên theo lớp nào
            rpt.SetParameterValue("prTenLop", cboLop.Text);

           

            crvDanhSach.ReportSource = rpt;
        }

        private void btnGiupDo_Click(object sender, EventArgs e)
        {
            //Mo file giúp đỡ
            //Help.ShowHelp(this, "GiupDo\\GiupDo.chm");

            //Giúp đỡ theo topic
            Help.ShowHelp(this, "GiupDo\\GiupDo.chm", "QuanLyLop.mht");
        }
    }
}