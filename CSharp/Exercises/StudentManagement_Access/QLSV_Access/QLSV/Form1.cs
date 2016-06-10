using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace QLSV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            Dao dao = new Dao();
            int MaLop = int.Parse(cboLop.SelectedValue.ToString());
            DataTable dt = dao.LayDanhSachHocSinhTheoLop(MaLop);

            //Load report tĩnh
            //rptDanhSach rpt = new rptDanhSach();
            
            //rpt.SetDataSource(dt);

            //Load report động
            ReportDocument rpt = new ReportDocument();
            string path = Application.StartupPath + "\\Reports\\rptDanhSach.rpt";
            rpt.Load(path);

            rpt.SetDataSource(dt);
            rpt.SetParameterValue("prTenLop", cboLop.Text);

            crvDanhSach.ReportSource = rpt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Dao dao = new Dao();
            DataTable dt = dao.LayDanhSachLop();
            cboLop.DataSource = dt;
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";
        }

        private void btnGiupDo_Click(object sender, EventArgs e)
        {
            //Load lên trang mặc định
            //Help.ShowHelp(this, "GiupDo\\GiupDo.chm");
            //Load theo ngữ cảnh
            Help.ShowHelp(this, "GiupDo\\GiupDo.chm", "QuanLySinhVien.mht");
        }
    }
}