using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace QLDaiLy
{
    public partial class frmPhieuXuatHang : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public frmPhieuXuatHang()
        {
            InitializeComponent();
        }

        private void frmPhieuXuatHang_Load(object sender, EventArgs e)
        {
            load_lvwPhieuXuatHang();
        }

        private void load_lvwPhieuXuatHang()
        {
       
            lvwPhieuXuatHang.Items.Clear();
            lvwPhieuXuatHang.Columns.Clear();
            lvwPhieuXuatHang.Columns.Add("STT", 40, HorizontalAlignment.Left);
            lvwPhieuXuatHang.Columns.Add("Mặt hàng", 120, HorizontalAlignment.Left);
            lvwPhieuXuatHang.Columns.Add("ĐVT", 50, HorizontalAlignment.Left);
            lvwPhieuXuatHang.Columns.Add("Số lượng", 70, HorizontalAlignment.Center);
            lvwPhieuXuatHang.Columns.Add("Đơn giá", 70, HorizontalAlignment.Center);
            lvwPhieuXuatHang.Columns.Add("Thành tiền", 120, HorizontalAlignment.Center);
            lvwPhieuXuatHang.FullRowSelect = true;
            lvwPhieuXuatHang.View = View.Details;
            lvwPhieuXuatHang.GridLines = true;

            
        }
    }
}
