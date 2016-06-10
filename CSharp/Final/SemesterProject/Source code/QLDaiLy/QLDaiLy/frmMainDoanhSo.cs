using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace QLDaiLy
{
    public partial class frmMainDoanhSo : DevComponents.DotNetBar.Office2007Form
    {
        public frmMainDoanhSo(DataTable dt, DateTime ngay)
        {
            InitializeComponent();
            _dt = dt;
            _ngay = ngay;
        }

        private DataTable _dt;
        private DateTime _ngay;
        private void frmMainDoanhSo_Load(object sender, EventArgs e)
        {
            rptDoanhSo rpt = new rptDoanhSo();

            rpt.Database.Tables["DoanhSo"].SetDataSource(_dt);

            crystalReportViewer1.ReportSource = rpt;
            //rpt.SetParameterValue("Th", frmChinh.thang);
            rpt.SetParameterValue("Thang",_ngay);
        }
    }
}