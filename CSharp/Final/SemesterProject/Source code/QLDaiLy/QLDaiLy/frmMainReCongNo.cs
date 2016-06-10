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
    public partial class frmMainReCongNo : DevComponents.DotNetBar.Office2007Form
    {
        public frmMainReCongNo(DataTable da, DateTime ngay)
        {
            InitializeComponent();
            _dt = da;
            _ngay = ngay;
        }

        private DataTable _dt;
        private DateTime _ngay;

        private void frmMainReCongNo_Load(object sender, EventArgs e)
        {
            rptCongNo rpt = new rptCongNo();

            rpt.Database.Tables["BaoCaoCongNo"].SetDataSource(_dt);

            crystalReportViewer1.ReportSource = rpt;
            rpt.SetParameterValue("Thang", frmChinh.ngay );

        }
    }
}