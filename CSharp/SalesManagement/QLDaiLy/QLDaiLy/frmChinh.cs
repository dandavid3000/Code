using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using DevComponents.DotNetBar;
using QLDL.DTO;
using QLDL.BUS;


namespace QLDaiLy
{
    public partial class frmChinh : DevComponents.DotNetBar.Office2007RibbonForm
   
    {
        public frmChinh()
        {
            InitializeComponent();

        }
        Control[] tmpCtrlDaiLy = new Control[9]; //Khai báo 2 phần tử từ 0 đến 1 chứa 2 control bao gồm TextBox ComboBox, ...
        string[] strColumnDaiLy = new string[9];
        private Control[] buttonDaiLy = new Control[7];
       // DataTable dtTBDaiLy = DaiLyBUS.SelectAllDaiLy();
        DataTable dtTBDaiLy;
        bool bAdd = false;
        int tmpOption = 1;
       
        private void frmChinh_Load(object sender, EventArgs e)
        {
            load_lvwPhieuXuatHang();
            load_TabDaiLy();
            
        }
        private void load_lvwPhieuXuatHang()
        {

            lvwPhieuXuatHang.Items.Clear();
            lvwPhieuXuatHang.Columns.Clear();
            lvwPhieuXuatHang.Columns.Add("STT", 40, HorizontalAlignment.Left);
            lvwPhieuXuatHang.Columns.Add("Mặt hàng", 115, HorizontalAlignment.Left);
            lvwPhieuXuatHang.Columns.Add("ĐVT", 50, HorizontalAlignment.Left);
            lvwPhieuXuatHang.Columns.Add("Số lượng", 70, HorizontalAlignment.Center);
            lvwPhieuXuatHang.Columns.Add("Đơn giá", 70, HorizontalAlignment.Center);
            lvwPhieuXuatHang.Columns.Add("Thành tiền",120 ,HorizontalAlignment.Center);
            lvwPhieuXuatHang.FullRowSelect = true;
            lvwPhieuXuatHang.View = View.Details;
            lvwPhieuXuatHang.GridLines = true;
        }
        private void load_TabDaiLy()
        {
            tmpCtrlDaiLy[0] = this.txtMaDL;
            tmpCtrlDaiLy[1] = this.txtTenDL;
            tmpCtrlDaiLy[2] = this.cbxMaLoaiDL;
            tmpCtrlDaiLy[3] = this.txtDienThoai;
            tmpCtrlDaiLy[4] = this.txtDiaChi;
            tmpCtrlDaiLy[5] = this.cbxMaQuan;
            tmpCtrlDaiLy[6] = this.dtpkNgayTiepNhan;
            tmpCtrlDaiLy[7] = this.txtEmail;
            tmpCtrlDaiLy[8] = this.txtNoCuaDaiLy;

            buttonDaiLy[0] = this.btnThemDL;
            buttonDaiLy[1] = this.btnXoaDL;
            buttonDaiLy[2] = this.btnSuaDL;
            buttonDaiLy[3] = this.btnLuuDL;
            buttonDaiLy[4] = this.btnCancelDL;
            buttonDaiLy[5] = this.btnNapLaiDL;
            buttonDaiLy[6] = this.btnThoatDL;

            strColumnDaiLy[0] = "MaDaiLy";
            strColumnDaiLy[1] = "TenDaiLy";
            strColumnDaiLy[2] = "MaLoaiDaiLy";
            strColumnDaiLy[3] = "DienThoai";
            strColumnDaiLy[4] = "DiaChi";
            strColumnDaiLy[5] = "MaQuan";
            strColumnDaiLy[6] = "NgayTiepNhan";
            strColumnDaiLy[7] = "Email";
            strColumnDaiLy[8] = "NoCuaDaiLy";
            Load_DataBinding(dtTBDaiLy, tmpCtrlDaiLy, strColumnDaiLy);
            load_GridDaiLyDaiLy();
            bAdd = false;
            string tab = "DL";
            Reset_Form(buttonDaiLy,bAdd, tab);
            
        }
        private void load_GridDaiLyDaiLy()
        {
            dtTBDaiLy = DaiLyBUS.SelectAllDaiLy();
            GridDaiLy.DataSource = dtTBDaiLy;
            GridDaiLy.Columns[0].Width = 10;
            GridDaiLy.Columns[1].Width = 110;
            GridDaiLy.Columns[2].Width = 80;
            GridDaiLy.Columns[3].Width = 70;
            GridDaiLy.Columns[4].Width = 150;
            GridDaiLy.Columns[5].Width = 80;
            GridDaiLy.Columns[6].Width = 100;
            GridDaiLy.Columns[7].Width = 100;
            GridDaiLy.Columns[8].Width = 120;
            //Đặt tên Columns
            GridDaiLy.Columns[0].Visible = false;
            GridDaiLy.Columns[1].HeaderText = "Tên đại lý";
            GridDaiLy.Columns[2].HeaderText = "Loại đại lý";
            GridDaiLy.Columns[3].HeaderText = "Điện thoại";
            GridDaiLy.Columns[4].HeaderText = "Địa chỉ";
            GridDaiLy.Columns[5].HeaderText = "Quận";
            GridDaiLy.Columns[6].HeaderText = "Ngày tiếp nhận";
            GridDaiLy.Columns[7].HeaderText = "Email";
            GridDaiLy.Columns[8].HeaderText = "Nợ đại lý";


        }


        private string AutoResize()
        {
            throw new NotImplementedException();
        }
        private void ribbonPanel2_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {

        }

        private void panelEx3_Click(object sender, EventArgs e)
        {

        }

        private void btnDKHosting_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTabIndex = 0;
        }

        private void labelX16_Click(object sender, EventArgs e)
        {

        }

        private void buttonX12_Click(object sender, EventArgs e)
        {// them dai ly
            bAdd = true;
            tmpOption = 1;
            GridDaiLy.Enabled = false;
            string tab = "DL";
            Clear_DataBinding(tmpCtrlDaiLy);
            Reset_Form(buttonDaiLy,bAdd,tab);
        }

        private void buttonX9_Click(object sender, EventArgs e)
        {// luu dai ly
            string tab = "DL";
            

            Reset_Button(this,bAdd, tab);
            bool flagadd = false;
           if (tmpOption == 1)
                {
                    string ten = txtTenDL.Text;
                    int maloai = Convert.ToInt16(cbxMaLoaiDL.Text);
                    string dt = txtDienThoai.Text;
                    string dc = txtDiaChi.Text;
                    int qu = Convert.ToInt16(cbxMaQuan.Text);
                    DateTime ngay = dtpkNgayTiepNhan.Value;
                    string em = txtEmail.Text;
                    DaiLyDTO dl = new DaiLyDTO(ten, maloai, dt, dc, qu, ngay, em);
                    DaiLyBUS.InsertDaiLy(dl);
                    load_GridDaiLyDaiLy();
                    GridDaiLy.Enabled = true;
                }
                if (tmpOption == 2)
                {
                    int madaily = Convert.ToInt16(txtMaDL.Text);
                    string ten = txtTenDL.Text;
                    int maloai = Convert.ToInt16(cbxMaLoaiDL.Text);
                    string dt = txtDienThoai.Text;
                    string dc = txtDiaChi.Text;
                    int qu = Convert.ToInt16(cbxMaQuan.Text);
                    DateTime ngay = dtpkNgayTiepNhan.Value;
                   // string ngay = dtpkNgayTiepNhan.Text;
                    string em = txtEmail.Text;
                    //int no = Convert.ToInt16(txtNoToiDa.Text);
                    DaiLyDTO dl = new DaiLyDTO(madaily,ten, maloai, dt, dc, qu, ngay, em);
                    DaiLyBUS.updateDaiLy(dl);
                    load_GridDaiLyDaiLy();
                    GridDaiLy.Enabled = true;
                   
                }
            bAdd = false;
            Reset_Form(buttonDaiLy, bAdd, tab);

            

        }
        public static void Load_DataBinding(DataTable dtTB, Control [] ctr, string [] col)
        {
            dtTB = DaiLyBUS.SelectAllDaiLy();
            for (int i = 0; i < ctr.Count(); i++ )
            {
                ctr[i].Text = dtTB.Rows[0][i].ToString();
            }
        }
        public static void Clear_DataBinding(Control[] ctr)
        {
            for (int i = 0; i < ctr.Count(); i++)
            {
                ctr[i].Text = "";
            }
        }
        public static void Reset_Button(Control ctrl, bool bAdd_Change, string tab)
        {
            if (ctrl is ButtonX)
            {
                if (bAdd_Change == true)
                {
                    ctrl.Enabled = false;
                    if (ctrl.Name == "btnLuu" + tab)
                    {
                        ctrl.Enabled = true;
                    }
                    if (ctrl.Name == "btnCancel" + tab)
                    {
                        ctrl.Enabled = true;
                    }
                }
                if (bAdd_Change == false)
                {
                    ctrl.Enabled = true;
                    if (ctrl.Name == "btnLuu" + tab)
                    {
                        ctrl.Enabled = false;
                    }
                    if (ctrl.Name == "btnCancel" + tab)
                    {
                        ctrl.Enabled = false;
                    }
                }

            }
        }
        public static void Reset_Form(Control[] ctr, bool bAdd_Change, string tab)
        {
            for (int l = 0; l < ctr.Count(); l++)
            {
                Reset_Button(ctr[l], bAdd_Change,tab);
            }
        }

        private void btnCancelDL_Click(object sender, EventArgs e)
        {
            string tab = "DL";
            bAdd = false;
            GridDaiLy.Enabled = true;
            Reset_Form(buttonDaiLy, bAdd, tab);
            load_GridDaiLyDaiLy();
            Load_DataBinding(dtTBDaiLy, tmpCtrlDaiLy, strColumnDaiLy);
        }

        private void GridDaiLy_SelectionChanged(object sender, EventArgs e)
        {
            if (this.GridDaiLy.CurrentRow != null)
            {
                this.txtMaDL.Text = this.GridDaiLy.CurrentRow.Cells["MaDaiLy"].Value.ToString();
                this.txtTenDL.Text = this.GridDaiLy.CurrentRow.Cells["TenDaiLy"].Value.ToString();
                this.cbxMaLoaiDL.Text = this.GridDaiLy.CurrentRow.Cells["MaLoaiDaiLy"].Value.ToString();
                this.txtDienThoai.Text = this.GridDaiLy.CurrentRow.Cells["DienThoai"].Value.ToString();
                this.txtDiaChi.Text = this.GridDaiLy.CurrentRow.Cells["DiaChi"].Value.ToString();
                this.cbxMaQuan.Text = this.GridDaiLy.CurrentRow.Cells["MaQuan"].Value.ToString();
                this.dtpkNgayTiepNhan.Text = this.GridDaiLy.CurrentRow.Cells["NgayTiepNhan"].Value.ToString();
                this.txtEmail.Text = this.GridDaiLy.CurrentRow.Cells["Email"].Value.ToString();
                this.txtNoCuaDaiLy.Text = this.GridDaiLy.CurrentRow.Cells["NoCuaDaiLy"].Value.ToString();

            }
        }

        private void btnXoaDL_Click(object sender, EventArgs e)
        {
            string tab = "DL";
            DialogResult result = MessageBoxEx.Show("Bạn có muốn xóa đại lý '" + txtTenDL.Text + "' này không?", "Xóa Đại lý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int madaly = Convert.ToInt16(txtMaDL.Text);
                Clear_DataBinding(tmpCtrlDaiLy);
                DaiLyBUS.DeleteDaiLy(madaly);
                load_GridDaiLyDaiLy();
                Load_DataBinding(dtTBDaiLy, tmpCtrlDaiLy, strColumnDaiLy);
            }
        }

        private void btnSuaDL_Click(object sender, EventArgs e)
        {
            string tab = "DL";
            tmpOption = 2;
            bAdd = true;
            Reset_Form(buttonDaiLy, bAdd, tab);
            GridDaiLy.Enabled = false;
            
        }

        private void btnThoatDL_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNapLaiDL_Click(object sender, EventArgs e)
        {
            load_GridDaiLyDaiLy();
            Load_DataBinding(dtTBDaiLy, tmpCtrlDaiLy, strColumnDaiLy);
        }

        private void btnTenMien_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTabIndex = 2;
        }

        



    }
}
