using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
            this.tabQLDL.SelectedTab = tabDaiLy;
            this.Ribbon.SelectedRibbonTabItem = ribbonHeThong;
            dtgvDSQ.DataSource = new QuanBUS().DanhSachQuan();
            dtgvDSMH.DataSource = MatHangBUS.DanhSachMatHang();
            dtgvThamSo.DataSource = new ThamSoBUS().DanhSachThamSo();
           // dtgvDSLDL.DataSource = new LoaiDaiLyBUS().DanhSachLoaiDaiLy();

        }
        Control[] tmpCtrlDaiLy = new Control[9];
        Control[] Ctr_En_DL = new Control[7];//Khai báo 2 phần tử từ 0 đến 1 chứa 2 control bao gồm TextBox ComboBox, ...
        string[] strColumnDaiLy = new string[9];
        private Control[] buttonDaiLy = new Control[7];
        DataTable dtTBDaiLy;

        Control[] tmpCtrlDVT = new Control[2];
        Control[] Ctr_En_DVT = new Control[1];//Khai báo 2 phần tử từ 0 đến 1 chứa 2 control bao gồm TextBox ComboBox, ...
        string[] strColumnDVT = new string[2];
        private Control[] buttonDVT = new Control[7];
        DataTable dtTBDVT;
        Control[] tmpCtrlPX = new Control[4];
        Control[] Ctr_En_PX = new Control[2];//Khai báo 2 phần tử từ 0 đến 1 chứa 2 control bao gồm TextBox ComboBox, ...
        string[] strColumnPX = new string[4];
        private Control[] buttonPX = new Control[5];
        DataTable dtTBPX;
        // DataTable dtTBDaiLy = DaiLyBUS.SelectAllDaiLy();

        bool bAdd = false;
        int tmpOption = 1;

        private void frmChinh_Load(object sender, EventArgs e)
        {
            //load_lvwPhieuXuatHang();
            load_TabDaiLy();
            load_TabPhieuXuat();
            load_TabPhieuThu();
            load_TabTimKiem();

            //load_lvwTimKiem();
            // load_lvwBaoCao();
            load_TabDonViTinh();
            load_TabBaoCao();
            load_TabDonGia();
            load_TabLoaiDaiLy();


        }
        private void load_lvwPhieuXuatHang()
        {
            lvwPhieuXuatHang.Items.Clear();
            lvwPhieuXuatHang.Columns.Clear();
            lvwPhieuXuatHang.Columns.Add("STT", 40, HorizontalAlignment.Left);
            lvwPhieuXuatHang.Columns.Add("Tên mặt hàng", 100, HorizontalAlignment.Left);
            lvwPhieuXuatHang.Columns.Add("Tên ĐVT", 75, HorizontalAlignment.Left);
            lvwPhieuXuatHang.Columns.Add("Số lượng", 70, HorizontalAlignment.Center);
            lvwPhieuXuatHang.Columns.Add("Đơn giá", 70, HorizontalAlignment.Center);
            lvwPhieuXuatHang.Columns.Add("Thành tiền", 120, HorizontalAlignment.Center);
            lvwPhieuXuatHang.FullRowSelect = true;
            lvwPhieuXuatHang.View = View.Details;
            lvwPhieuXuatHang.GridLines = true;
        }
        //private void load_lvwTimKiem()
        //{

        //    lvwTimKiem.Items.Clear();
        //    lvwTimKiem.Columns.Clear();
        //    lvwTimKiem.Columns.Add("STT", 40, HorizontalAlignment.Left);
        //    lvwTimKiem.Columns.Add("Đại Lý", 100, HorizontalAlignment.Left);
        //    lvwTimKiem.Columns.Add("Loại", 75, HorizontalAlignment.Left);
        //    lvwTimKiem.Columns.Add("Quận", 70, HorizontalAlignment.Center);
        //    lvwTimKiem.Columns.Add("Tiền nợ", 70, HorizontalAlignment.Center);
        //    lvwTimKiem.FullRowSelect = true;
        //    lvwTimKiem.View = View.Details;
        //    lvwTimKiem.GridLines = true;
        //}
        //private void load_lvwBaoCao()
        //{

        //    lvwBaoCao.Items.Clear();
        //    lvwBaoCao.Columns.Clear();
        //    lvwBaoCao.Columns.Add("STT", 40, HorizontalAlignment.Left);
        //    lvwBaoCao.Columns.Add("Đại Lý", 100, HorizontalAlignment.Left);
        //    lvwBaoCao.Columns.Add("Số phiếu xuất", 75, HorizontalAlignment.Left);
        //    lvwBaoCao.Columns.Add("Tổng giá trị", 70, HorizontalAlignment.Center);
        //    lvwBaoCao.Columns.Add("Tỷ lệ", 70, HorizontalAlignment.Center);
        //    lvwBaoCao.FullRowSelect = true;
        //    lvwBaoCao.View = View.Details;
        //    lvwBaoCao.GridLines = true;
        //}
        private List<DaiLyDTO> LayTenDaiLy()
        {
            throw new NotImplementedException();
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


            Ctr_En_DL[0] = this.txtTenDL;
            Ctr_En_DL[1] = this.cbxMaLoaiDL;
            Ctr_En_DL[2] = this.txtDienThoai;
            Ctr_En_DL[3] = this.txtDiaChi;
            Ctr_En_DL[4] = this.cbxMaQuan;
            Ctr_En_DL[5] = this.dtpkNgayTiepNhan;
            Ctr_En_DL[6] = this.txtEmail;

            buttonDaiLy[0] = this.btnThemDL;
            buttonDaiLy[1] = this.btnXoaDL;
            buttonDaiLy[2] = this.btnSuaDL;
            buttonDaiLy[3] = this.btnLuuDL;
            buttonDaiLy[4] = this.btnCancelDL;
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
            dtTBDaiLy = DaiLyBUS.SelectAllDaiLy();
            Load_DataBinding(dtTBDaiLy, tmpCtrlDaiLy, strColumnDaiLy);
            load_GridDaiLyDaiLy();

        }
        private void load_TabTimKiem()
        {
            DataTable da = DaiLyBUS.SelectAllDaiLy();
            load_GridTimKiem(da);
            Load_ComBo_TimKiem();

        }
        private void load_TabLoaiDaiLy()
        {
            load_GridLoaiDaiLy();
            txtMaLoaiDaiLy.Text = "";
            txtTenLoaiDaiLy.Text = "";
            txtNoToiDa.Text = "";
        }
        private void load_TabBaoCao()
        {
            DataTable da = DaiLyBUS.SelectAllDaiLy();
            load_GridBaoCao();
            Load_ComBo_TimKiem();

        }
        private void load_TabDonGia()
        {
            DataTable da = GiaBanTheoDonViTinhBUS.SelectAllGiaBan();
            load_GridDonGia();
           Load_ComBo_DonGia();

        }
        private void load_TabDonViTinh()
        {
            string tab = "DVT";
            tmpCtrlDVT[0] = this.txtmaDVT;
            tmpCtrlDVT[1] = this.txtTenDVT;

            Ctr_En_DVT[0] = this.txtTenDVT;


            buttonDVT[0] = this.btnThemDL;
            buttonDVT[1] = this.btnXoaDVT;
            buttonDVT[2] = this.btnSuaDVT;
            buttonDVT[3] = this.btnLuuDVT;
            buttonDVT[4] = this.btnCancelDVT;
            buttonDVT[5] = this.btnNapLaiDVT;
            buttonDVT[6] = this.btnThoatDVT;

            strColumnDVT[0] = "MaDVT";
            strColumnDVT[1] = "TenDVT";
            //dtTBDaiLy =  DaiLyBUS.SelectAllDaiLy();
            dtTBDVT = DonViTinhBUS.SelectAllDonViTinh();


            Load_DataBinding(dtTBDVT, tmpCtrlDVT, strColumnDVT);
            load_GridDaiLyDaDVT();
            bAdd = false;
            Reset_Form(buttonDVT, bAdd, tab);
            //Reset_Form(tmpCtrlDVT, bAdd, tab);

        }
        private void load_TabPhieuXuat()
        {
            string tab = "PX";
            tmpCtrlPX[0] = this.txtMaPhieuXuat;
            tmpCtrlPX[1] = this.cbxDL;
            tmpCtrlPX[2] = this.dtpkNgayLapPhieu;
            tmpCtrlPX[3] = this.txtTongGiaTri;

            Ctr_En_PX[0] = this.cbxDL;
            Ctr_En_PX[1] = this.dtpkNgayLapPhieu;



            buttonPX[0] = this.btnThemPX;
            //   buttonPX[1] = this.btnXoaPX;
            //   buttonPX[2] = this.btnSuaPX;
            buttonPX[1] = this.btnLuuPX;
            buttonPX[2] = this.btnCancelPX;
            buttonPX[3] = this.btnNapPX;
            buttonPX[4] = this.btnThoatPX;

            strColumnPX[0] = "MaPhieuXuat";
            strColumnPX[1] = "MaDaiLy";
            strColumnPX[2] = "NgayLapPhieu";
            strColumnPX[3] = "TongGiaTri";
            //dtTBDaiLy =  DaiLyBUS.SelectAllDaiLy();
            dtTBPX = PhieuXuatBUS.SelectAllPhieuXuat();


            Load_DataBinding(dtTBPX, tmpCtrlPX, strColumnPX);
            load_GridPhieuXuat();
            load_lvwPhieuXuatHang();
            bAdd = false;
            Reset_Form(buttonPX, bAdd, tab);
            //Reset_Form(tmpCtrlPX, bAdd, tab);

        }
        private void load_TabPhieuThu()
        {
            //string tab = "PX";
            //tmpCtrlPX[0] = this.txtMaPhieuXuat;
            //tmpCtrlPX[1] = this.cbxDL;
            //tmpCtrlPX[2] = this.dtpkNgayLapPhieu;
            //tmpCtrlPX[3] = this.txtTongGiaTri;

            //Ctr_En_PX[0] = this.cbxDL;
            //Ctr_En_PX[1] = this.dtpkNgayLapPhieu;



            //buttonPX[0] = this.btnThemPX;
            ////   buttonPX[1] = this.btnXoaPX;
            ////   buttonPX[2] = this.btnSuaPX;
            //buttonPX[1] = this.btnLuuPX;
            //buttonPX[2] = this.btnCancelPX;
            //buttonPX[3] = this.btnNapPX;
            //buttonPX[4] = this.btnThoatPX;

            //strColumnPX[0] = "MaPhieuXuat";
            //strColumnPX[1] = "MaDaiLy";
            //strColumnPX[2] = "NgayLapPhieu";
            //strColumnPX[3] = "TongGiaTri";
            ////dtTBDaiLy =  DaiLyBUS.SelectAllDaiLy();
            //dtTBPX = PhieuXuatBUS.SelectAllPhieuXuat();


            //Load_DataBinding(dtTBPX, tmpCtrlPX, strColumnPX);
            load_GridPhieuThu();
            Load_ComBo_PhieuThu();

            // load_lvwPhieuXuatHang();
            bAdd = false;
            // Reset_Form(buttonPX, bAdd, tab);
            //Reset_Form(tmpCtrlPX, bAdd, tab);

        }

        public void Enable_Control(Control[] ctr)
        {
            for (int l = 0; l < ctr.Count(); l++)
            {
                ctr[l].Enabled = false;
            }
        }
        public void Not_Enable_Control(Control[] ctr)
        {
            for (int l = 0; l < ctr.Count(); l++)
            {
                ctr[l].Enabled = true;
            }
        }
        private void load_GridDaiLyDaiLy()
        {
            Enable_Control(Ctr_En_DL);
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
        private void load_GridTimKiem(DataTable dtTBDaiLy)
        {

            //dtTBDaiLy = DaiLyBUS.SelectAllDaiLy();
            GridTimKiem.DataSource = dtTBDaiLy;
            GridTimKiem.Columns[0].Width = 10;
            GridTimKiem.Columns[1].Width = 110;
            GridTimKiem.Columns[2].Width = 80;
            GridTimKiem.Columns[3].Width = 70;
            GridTimKiem.Columns[4].Width = 225;
            GridTimKiem.Columns[5].Width = 80;
            GridTimKiem.Columns[6].Width = 100;
            GridTimKiem.Columns[7].Width = 155;
            GridTimKiem.Columns[8].Width = 120;
            //Đặt tên Columns
            GridTimKiem.Columns[0].Visible = false;
            GridTimKiem.Columns[1].HeaderText = "Tên đại lý";
            GridTimKiem.Columns[2].HeaderText = "Loại đại lý";
            GridTimKiem.Columns[3].HeaderText = "Điện thoại";
            GridTimKiem.Columns[4].HeaderText = "Địa chỉ";
            GridTimKiem.Columns[5].HeaderText = "Quận";
            GridTimKiem.Columns[6].HeaderText = "Ngày tiếp nhận";
            GridTimKiem.Columns[7].HeaderText = "Email";
            GridTimKiem.Columns[8].HeaderText = "Nợ đại lý";


        }
        private void load_GridPhieuXuat()
        {
            Enable_Control(Ctr_En_DL);
            dtTBPX = PhieuXuatBUS.SelectAllPhieuXuat();
            GridPhieuXuat1.DataSource = dtTBPX;
            GridPhieuXuat1.Columns[0].Width = 100;
            GridPhieuXuat1.Columns[1].Width = 100;
            GridPhieuXuat1.Columns[2].Width = 120;
            GridPhieuXuat1.Columns[3].Width = 125;
            //Đặt tên Columns
            GridPhieuXuat1.Columns[0].HeaderText = "Mã phiếu xuất";
            GridPhieuXuat1.Columns[1].HeaderText = "Đại lý";
            GridPhieuXuat1.Columns[2].HeaderText = "Ngày lập phiếu";
            GridPhieuXuat1.Columns[3].HeaderText = "Tổng giá trị";



        }
        private void load_GridPhieuThu()
        {

            DataTable dtTB_CongNo = DaiLyBUS.SelectAllCongNoDaiLy();
            GridPhieuThu.DataSource = dtTB_CongNo;
            GridPhieuThu.Columns[0].Width = 100;
            GridPhieuThu.Columns[1].Width = 170;
            GridPhieuThu.Columns[2].Width = 80;
            GridPhieuThu.Columns[3].Width = 100;
            //Đặt tên Columns
            GridPhieuThu.Columns[0].HeaderText = "Đại lý";
            GridPhieuThu.Columns[1].HeaderText = "Địa chỉ";
            GridPhieuThu.Columns[2].HeaderText = "Điện Thọai";
            GridPhieuThu.Columns[3].HeaderText = "Công nợ";



        }
        private void load_GridBaoCao()
        {
            DataTable dtTB_CongNo = DaiLyBUS.SelectAllCongNoDaiLy();
            GridBaoCao.DataSource = dtTB_CongNo;
            GridBaoCao.Columns[0].Width = 200;
            GridBaoCao.Columns[1].Width = 380;
            GridBaoCao.Columns[2].Width = 150;
            GridBaoCao.Columns[3].Width = 195;
            //Đặt tên Columns
            GridBaoCao.Columns[0].HeaderText = "Đại lý";
            GridBaoCao.Columns[1].HeaderText = "Địa chỉ";
            GridBaoCao.Columns[2].HeaderText = "Điện thoại";
            GridBaoCao.Columns[3].HeaderText = "Nợ";


        }
        private void load_GridMatHang()
        {
            DataTable dtTB = MatHangBUS.SelectAllmatHang();
            dtgvDSMH.DataSource = dtTB;
            dtgvDSMH.Columns[0].Width = 200;
            dtgvDSMH.Columns[1].Width = 380;
            dtgvDSMH.Columns[2].Width = 150;
            //Đặt tên Columns
            dtgvDSMH.Columns[0].HeaderText = "Mã mặt hàng ";
            dtgvDSMH.Columns[1].HeaderText = "Tên mặt hàng";
            dtgvDSMH.Columns[2].HeaderText = "Số lượng tồn";
            


        }
        private void load_GridBaoCao_CongNo(DataTable dtTB_CongNo)
        {

            //DataTable dtTB_CongNo = DaiLyBUS.SelectAllCongNoDaiLy();
            GridBaoCao.DataSource = dtTB_CongNo;
            GridBaoCao.Columns[0].Width = 250;
            GridBaoCao.Columns[1].Width = 220;
            GridBaoCao.Columns[2].Width = 220;
            GridBaoCao.Columns[3].Width = 225;
            //Đặt tên Columns
            GridBaoCao.Columns[0].HeaderText = "Đại lý";
            GridBaoCao.Columns[1].HeaderText = "Nợ đầu";
            GridBaoCao.Columns[2].HeaderText = "Phát sinh";
            GridBaoCao.Columns[3].HeaderText = "Nợ cuối";


        }
        private void load_GridBaoCao_DoanhSo(DataTable dtTB_DoanhSo)
        {

            //DataTable dtTB_CongNo = DaiLyBUS.SelectAllCongNoDaiLy();
            GridBaoCao.DataSource = dtTB_DoanhSo;
            GridBaoCao.Columns[0].Width = 250;
            GridBaoCao.Columns[1].Width = 220;
            GridBaoCao.Columns[2].Width = 220;
            GridBaoCao.Columns[3].Width = 225;
            //Đặt tên Columns
            GridBaoCao.Columns[0].HeaderText = "Đại lý";
            GridBaoCao.Columns[1].HeaderText = "Số phiếu xuất";
            GridBaoCao.Columns[2].HeaderText = "Tổng giá trị";
            GridBaoCao.Columns[3].HeaderText = "Tỷ lệ";


        }
        private void load_GridDonGia()
        {

            DataTable dtTB_CongNo = GiaBanTheoDonViTinhBUS.SelectAllGiaBan();
            GridDonGia.DataSource = dtTB_CongNo;
            GridDonGia.Columns[0].Width = 100;
            GridDonGia.Columns[1].Width = 170;
            GridDonGia.Columns[2].Width = 80;
            GridDonGia.Columns[3].Width = 100;
             GridDonGia.Columns[4].Width = 100;
            //Đặt tên Columns
            GridDonGia.Columns[0].HeaderText = "Mã giá bán";
            GridDonGia.Columns[1].HeaderText = "Đơn Vị Tính";
            GridDonGia.Columns[2].HeaderText = "Mặt Hàng";
            GridDonGia.Columns[3].HeaderText = "Số lượng theo ĐVT";
            GridDonGia.Columns[4].HeaderText = "Số lượng theo ĐVT";


        }
        private void load_GridLoaiDaiLy()
        {

            DataTable dtTB = LoaiDaiLyBUS.SelectAllLoaiDaiLy();
            dtgvDSLDL.DataSource = dtTB;
            dtgvDSLDL.Columns[0].Width = 100;
            dtgvDSLDL.Columns[1].Width =370;
            dtgvDSLDL.Columns[2].Width = 200;
            //Đặt tên Columns
            dtgvDSLDL.Columns[0].HeaderText = "Mã loai đại lý";
            dtgvDSLDL.Columns[1].HeaderText = "Tên loại đại lý";
            dtgvDSLDL.Columns[2].HeaderText = "Nợ tối da";
           


        }
        private void load_GridDaiLyDaDVT()
        {
            //string tab = "DVT";
            Enable_Control(Ctr_En_DVT);
            // Reset_Form(tmpCtrlDVT,bAdd,tab);
            dtTBDVT = DonViTinhBUS.SelectAllDonViTinh();
            gridDonViTinh.DataSource = dtTBDVT;
            gridDonViTinh.Columns[0].Width = 100;
            gridDonViTinh.Columns[1].Width = 800;
            //Đặt tên Columns
            // gridDonViTinh.Columns[0].Visible = false;
            gridDonViTinh.Columns[0].HeaderText = "Mã đơn vị tính";
            gridDonViTinh.Columns[1].HeaderText = "Tên đơn vị tính";


        }


        private string AutoResize()
        {
            throw new NotImplementedException();
        }

        private void buttonX12_Click(object sender, EventArgs e)
        {// them dai ly
            if (txtTenDL.Text != "" && cbxMaLoaiDL.Text != "" && txtDienThoai.Text != "" && txtDiaChi.Text != "" && cbxMaQuan.Text != "" && dtpkNgayTiepNhan.Text != "" && txtEmail.Text != "")
            {
                bAdd = true;
                tmpOption = 1;
                GridDaiLy.Enabled = false;
                Not_Enable_Control(Ctr_En_DL);
                string tab = "DL";
                //DataTable dt = LoaiDaiLyBUS.SelectAllLoaiDaiLy();
                //cbxMaLoaiDL.DataSource = dt;
                //cbxMaLoaiDL.DisplayMember = "TenLoaiDaiLy";
                //cbxMaLoaiDL.ValueMember = "MaLoaiDaiLy";
                //cbxMaLoaiDL.SelectedIndex = 1;
                Load_ComBo_DaiLy();
                Clear_DataBinding(tmpCtrlDaiLy);
                Reset_Form(buttonDaiLy, bAdd, tab);
            }
        }
        public void Load_ComBo_DaiLy()
        {
            DataTable dt = LoaiDaiLyBUS.SelectAllLoaiDaiLy();
            cbxMaLoaiDL.DisplayMember = "TenLoaiDaiLy";
            cbxMaLoaiDL.ValueMember = "MaLoaiDaiLy";
            cbxMaLoaiDL.DataSource = dt;
            cbxMaLoaiDL.SelectedIndex = 0;
            DataTable dtdt = QuanBUS.SelectAllQuan();
            cbxMaQuan.DisplayMember = "TenQuan";
            cbxMaQuan.ValueMember = "MaQuan";
            cbxMaQuan.DataSource = dtdt;
            cbxMaQuan.SelectedIndex = 0;

        }
        public void Load_ComBo_TimKiem()
        {
            DataTable dt = LoaiDaiLyBUS.SelectAllLoaiDaiLy();
            cbxTenLDL_TK.DisplayMember = "TenLoaiDaiLy";
            cbxTenLDL_TK.ValueMember = "MaLoaiDaiLy";
            cbxTenLDL_TK.DataSource = dt;
            cbxTenLDL_TK.SelectedIndex = -1;
            DataTable dtdt = QuanBUS.SelectAllQuan();
            cbxQuan_TK.DisplayMember = "TenQuan";
            cbxQuan_TK.ValueMember = "MaQuan";
            cbxQuan_TK.DataSource = dtdt;
            cbxQuan_TK.SelectedIndex = -1;
            txtMaDaiLy_TK.Text = "";
            txtDT_TK.Text = "";
            txtDiaChi_TK.Text = "";
            txtEmail_TK.Text = "";
            txtNoDaiLy_TK.Text = "";


        }
        public void Load_ComBo_PhieuXuatHang()
        {
            DataTable dt = DaiLyBUS.SelectAllDaiLy();
            cbxDL.DisplayMember = "TenDaiLy";
            cbxDL.ValueMember = "MaDaiLy";
            cbxDL.DataSource = dt;
            cbxDL.SelectedIndex = 0;
            DataTable dtdt = MatHangBUS.SelectAllmatHang();
            cbxMatHang.DisplayMember = "TenMatHang";
            cbxMatHang.ValueMember = "MaMatHang";
            cbxMatHang.DataSource = dtdt;
            cbxMatHang.SelectedIndex = 0;
            DataTable dttb = DonViTinhBUS.SelectAllDonViTinh();
            cbxDVT.DisplayMember = "TenDonViTinh";
            cbxDVT.ValueMember = "MaDonViTinh";
            cbxDVT.DataSource = dttb;
            cbxDVT.SelectedIndex = 0;

        }
        public void Load_ComBo_DonGia()
        {
           
            DataTable dtdt = MatHangBUS.SelectAllmatHang();
            cbxMH_DG.DisplayMember = "TenMatHang";
            cbxMH_DG.ValueMember = "MaMatHang";
            cbxMH_DG.DataSource = dtdt;
            cbxMH_DG.SelectedIndex = 0;
            DataTable dttb = DonViTinhBUS.SelectAllDonViTinh();
            cbxDonViTInh_DG.DisplayMember = "TenDonViTinh";
            cbxDonViTInh_DG.ValueMember = "MaDonViTinh";
            cbxDonViTInh_DG.DataSource = dttb;
            cbxDonViTInh_DG.SelectedIndex = 0;

        }
        public void Load_ComBo_PhieuThu()
        {
            DataTable dt = DaiLyBUS.SelectAllDaiLy();
            cbxDL_PT.DisplayMember = "TenDaiLy";
            cbxDL_PT.ValueMember = "MaDaiLy";
            cbxDL_PT.DataSource = dt;
            cbxDL_PT.SelectedIndex = 0;
            int ma = Convert.ToInt16(cbxDL_PT.SelectedValue);
            DataTable da = DaiLyBUS.SelectTTDLByMa(Convert.ToInt16(cbxDL_PT.SelectedValue));
            txtDiaChi_PT.Text = da.Rows[0][0].ToString();
            txtDienThoai.Text = da.Rows[0][1].ToString();
            txtEmail_PT.Text = da.Rows[0][2].ToString();
            txtSoTienThu_PT.Text = da.Rows[0][3].ToString();
        }

        private void buttonX9_Click(object sender, EventArgs e)
        {
            string tab = "DL";


            Reset_Button(this, bAdd, tab);
            //bool flagadd = false;
            if (tmpOption == 1)
            {
                int qu = Convert.ToInt16(cbxMaQuan.SelectedValue);
                 int slquan = QuanBUS.DemSoDLMoiQuan(qu);
                int soDltoida = ThamSoBUS.SoDLToiDa();
                if (slquan < soDltoida)
                {
                    string ten = txtTenDL.Text;
                    string tendaily = cbxMaLoaiDL.Text;
                    //int maloai = LoaiDaiLyBUS.SelectMaByTenLoai(tendaily); 
                    int maloai = Convert.ToInt16(cbxMaLoaiDL.SelectedValue);
                    string dt = txtDienThoai.Text;
                    string dc = txtDiaChi.Text;

                    // kiem tra so dai ly moi quan.

                    DateTime ngay = dtpkNgayTiepNhan.Value;
                    string em = txtEmail.Text;
                    DaiLyDTO dl = new DaiLyDTO(ten, maloai, dt, dc, qu, ngay, em);
                    DaiLyBUS.InsertDaiLy(dl);
                    load_GridDaiLyDaiLy();
                    GridDaiLy.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Quận này đã đủ số đại lý ==> Không thể tiếp nhận hồ sơ đại lý này");
                }
            }
            if (tmpOption == 2)
            {
                 int qu = Convert.ToInt16(cbxMaQuan.SelectedValue);
                 int slquan = QuanBUS.DemSoDLMoiQuan(qu);
                int soDltoida = ThamSoBUS.SoDLToiDa();
                if (slquan < soDltoida)
                {
                    int madaily = Convert.ToInt16(txtMaDL.Text);
                    string ten = txtTenDL.Text;
                    int maloai = Convert.ToInt16(cbxMaLoaiDL.SelectedValue);
                    string dt = txtDienThoai.Text;
                    string dc = txtDiaChi.Text;
                   // int qu = Convert.ToInt16(cbxMaQuan.Text);
                    DateTime ngay = dtpkNgayTiepNhan.Value;
                    // string ngay = dtpkNgayTiepNhan.Text;
                    string em = txtEmail.Text;
                    //int no = Convert.ToInt16(txtNoToiDa.Text);
                    DaiLyDTO dl = new DaiLyDTO(madaily, ten, maloai, dt, dc, qu, ngay, em);
                    DaiLyBUS.updateDaiLy(dl);
                    load_GridDaiLyDaiLy();
                    GridDaiLy.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Quận này đã đủ số đại lý ==> Chọn quận khác");
                }
            }
            bAdd = false;
            Reset_Form(buttonDaiLy, bAdd, tab);



        }
        public static void Load_DataBinding(DataTable dtTB, Control[] ctr, string[] col)
        {
            // dtTB = DaiLyBUS.SelectAllDaiLy();
            for (int i = 0; i < ctr.Count(); i++)
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
                Reset_Button(ctr[l], bAdd_Change, tab);
            }
        }

        private void btnCancelDL_Click(object sender, EventArgs e)
        {
            string tab = "DL";
            bAdd = false;
            GridDaiLy.Enabled = true;
            Reset_Form(buttonDaiLy, bAdd, tab);
            load_GridDaiLyDaiLy();
            dtTBDaiLy = DaiLyBUS.SelectAllDaiLy();
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
            //string tab = "DL";
            DaiLyDTO dl = DaiLyBUS.SelectDaiLyByMa(Convert.ToInt16(txtMaDL.Text));
            if (dl.Nocuadaily == 0)
            {
                // string tab = "DL";
                DialogResult result = MessageBoxEx.Show("Bạn có muốn xóa đại lý '" + txtTenDL.Text + "' này không?",
                                                        "Xóa Đại lý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int madaly = Convert.ToInt16(txtMaDL.Text);
                    Clear_DataBinding(tmpCtrlDaiLy);
                    DaiLyBUS.DeleteDaiLy(madaly);
                    load_GridDaiLyDaiLy();
                    dtTBDaiLy = DaiLyBUS.SelectAllDaiLy();
                    Load_DataBinding(dtTBDaiLy, tmpCtrlDaiLy, strColumnDaiLy);
                }
            }
            else
            {
                MessageBox.Show("Đại lý này còn nợ không xóa được");
            }
            load_GridDaiLyDaiLy();
            dtTBDaiLy = DaiLyBUS.SelectAllDaiLy();
            Load_DataBinding(dtTBDaiLy, tmpCtrlDaiLy, strColumnDaiLy);
        }

        private void btnSuaDL_Click(object sender, EventArgs e)
        {
            Not_Enable_Control(Ctr_En_DL);
            Load_ComBo_DaiLy();
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

        private void tbnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTenMien_Click(object sender, EventArgs e)
        {
            this.tabQLDL.SelectedTab = tabDaiLy;
        }

        private void buttonX57_Click(object sender, EventArgs e)
        {
            stt = 0;
            tongtien = 0;
            bAdd = true;
            tmpOption = 1;
            GridPhieuXuat1.Enabled = false;
            Not_Enable_Control(Ctr_En_PX);
            string tab = "PX";
            //DataTable dt = LoaiDaiLyBUS.SelectAllLoaiDaiLy();
            //cbxMaLoaiDL.DataSource = dt;
            //cbxMaLoaiDL.DisplayMember = "TenLoaiDaiLy";
            //cbxMaLoaiDL.ValueMember = "MaLoaiDaiLy";
            //cbxMaLoaiDL.SelectedIndex = 1;
            Clear_DataBinding(tmpCtrlPX);
            //cbxDL.SelectedIndex = 0;
            Load_ComBo_PhieuXuatHang();
            // Clear_DataBinding(tmpCtrlDaiLy);
            Reset_Form(buttonPX, bAdd, tab);
            // Load_ComBo_PhieuXuatHang();

        }

        int stt = 0;
        int tongtien = 0;
        ChiTietPhieuXuatDTO[] listChiTiet = new ChiTietPhieuXuatDTO[100];
        private void btnChon_Click(object sender, EventArgs e)
        {
           stt += 1;
            int madl = Convert.ToInt16(cbxDL.SelectedValue);
            int mathang = Convert.ToInt16(cbxMatHang.SelectedValue);
            int dvt = Convert.ToInt16(cbxDVT.SelectedValue);
            int tontaima = GiaBanTheoDonViTinhBUS.MaGiaBanTheo_MaDVT_maMH(dvt, mathang);
            if (tontaima!=0)
            {
                int sltheodvt = GiaBanTheoDonViTinhBUS.SoLuongTheoDVT(dvt, mathang);
                int sl = Convert.ToInt16(txtSoLuong.Text);
                int slxuatthat = sltheodvt*sl;
                int slton = MatHangBUS.SLTon(mathang);
                if (slxuatthat < slton)
                {
                    int dg = Convert.ToInt16(txtDonGia.Text);
                    int thanhtien = sl*dg;
                    tongtien += thanhtien;
                    int nodl = DaiLyBUS.selectNoByMaDL(madl);
                    nodl = DaiLyBUS.selectNoByMaDL_Moi(madl);
                    int loaidl = DaiLyBUS.layMaLoaiDLBymaDL(Convert.ToInt16(cbxDL.SelectedValue));
                    int notoida = LoaiDaiLyBUS.NoToiDaByMaLoaiDL(loaidl);
                    if (tongtien + nodl <= notoida)
                    {
                        string[] lv = new string[6];

                        lv[0] = stt.ToString();
                        lv[1] = mathang.ToString();
                        lv[2] = dvt.ToString();
                        lv[3] = sl.ToString();
                        lv[4] = dg.ToString();
                        //int thanhtien = sl*dg;
                        lv[5] = thanhtien.ToString();
                        lvwPhieuXuatHang.Items.Add(new ListViewItem(lv));
                        //tongtien += thanhtien;
                        txtTongGiaTri.Text = tongtien.ToString();
                        ChiTietPhieuXuatDTO temp = new ChiTietPhieuXuatDTO();
                        temp.Mamathang = Convert.ToInt16(cbxMatHang.SelectedValue);
                        temp.Madonvitinh = Convert.ToInt16(cbxDVT.SelectedValue);
                        temp.Maphieuxuat = Convert.ToInt16(cbxDL.SelectedValue);
                        temp.Soluongxuat = Convert.ToInt16(txtSoLuong.Text);
                        temp.Dongiaxuat = Convert.ToInt16(txtDonGia.Text);
                        temp.Thanhtien = thanhtien;

                        listChiTiet[stt - 1] = new ChiTietPhieuXuatDTO(temp);
                    }
                    else
                    {
                        MessageBox.Show("Đã vượt quá tiền nợ tối đa");
                    }
                }
                else
                {
                    MessageBox.Show("Số lượng tồn mặt hàng này không đủ yêu cầu");
                }
            }
            else
            {
                MessageBox.Show("Loại đơn vị tính không phù hợp");
            }


        }

        private void buttonX54_Click(object sender, EventArgs e)
        {
            string tab = "PX";


            //Reset_Button(this, bAdd, tab);
            //bool flagadd = false;

            int maDL = Convert.ToInt16(cbxDL.SelectedValue);
            DateTime ngaylapphieu = dtpkNgayLapPhieu.Value;
            int tonggiatri = Convert.ToInt16(txtTongGiaTri.Text);
            PhieuXuatHangDTO px = new PhieuXuatHangDTO(maDL, ngaylapphieu, tonggiatri);
            PhieuXuatBUS.InsertPhieuXuat(px);
            load_GridPhieuXuat();
            GridPhieuXuat1.Enabled = true;
            //  DataTable da = lvwPhieuXuatHang
            int i = 0;
            for (int l = 0; l < stt; l++)
            {
                int dvt = Convert.ToInt16(listChiTiet[i].Madonvitinh);
                int mh = Convert.ToInt16(listChiTiet[i].Mamathang);
                int sltheodvt = GiaBanTheoDonViTinhBUS.SoLuongTheoDVT(dvt,mh);
                int hihi = Convert.ToInt16(listChiTiet[i].Soluongxuat);
                int slxuatthatsu = hihi*sltheodvt;
                int slton = MatHangBUS.SLTon(Convert.ToInt16(listChiTiet[i].Mamathang));

                MatHangBUS.updateSLTon(Convert.ToInt16(listChiTiet[i].Mamathang),slton - slxuatthatsu);

                ChiTietPhieuXuatBUS.InsertChiTietPhieuXuat(listChiTiet[i]);
                i++;
            }


            bAdd = false;
            Reset_Form(buttonPX, bAdd, tab);
            btnThemPX.Enabled = true;
            lvwPhieuXuatHang.Items.Clear();

            DaiLyDTO dl = DaiLyBUS.SelectDaiLyByMa(maDL);
            dl.Nocuadaily = dl.Nocuadaily + tonggiatri;

            DaiLyBUS.updateDaiLy(dl);
            cbxMatHang.Text = "";
            cbxDVT.Text = "";
            txtSoLuong.Text = "";
            txtDonGia.Text = "";



        }

        public static void LoadLai_lvwPhieuXuat(int ma)
        {
            //string[] lv = new string[6];
            //DataTable chitiet = ChiTietPhieuXuatBUS.SelectAllChiTietPhieuXuatByMaPhieuXuat(ma);
            //for (int l = 0; l < chitiet.Rows.Count; l++)
            //{
            //    lv[0] = l + 1.ToString();
            //    lv[1] = chitiet.Rows[l][2].ToString();
            //    lv[2] = chitiet.Rows[l][3].ToString();
            //    lv[3] = chitiet.Rows[l][4].ToString();
            //    lv[4] = chitiet.Rows[l][5].ToString();
            //    lv[5] = chitiet.Rows[l][6].ToString();
            //    lvwPhieuXuatHang.Items.Add(new ListViewItem(lv));
            //}

        }


        private void buttonX29_Click(object sender, EventArgs e)
        {
            int sldvtquydinh = ThamSoBUS.SL_DVT();
            int sldvtdaco = DonViTinhBUS.Dem_DVT();
            if (sldvtdaco < sldvtquydinh)
            {
                if (txtTenDVT.Text != "")
                {
                    bAdd = true;
                    tmpOption = 1;
                    gridDonViTinh.Enabled = false;
                    Not_Enable_Control(Ctr_En_DVT);
                    btnThemDVT.Enabled = false;
                    string tab = "DVT";
                    Clear_DataBinding(tmpCtrlDVT);
                    Reset_Form(buttonDVT, bAdd, tab);
                }
               
            }
            else
            {
                MessageBox.Show("Đã đủ loại đơn vị tính không thêm được");
            }
                
           
        }

        private void gridDonViTinh_SelectionChanged(object sender, EventArgs e)
        {
            if (this.gridDonViTinh.CurrentRow != null)
            {
                this.txtmaDVT.Text = this.gridDonViTinh.CurrentRow.Cells["MaDonViTinh"].Value.ToString();
                this.txtTenDVT.Text = this.gridDonViTinh.CurrentRow.Cells["TenDonViTinh"].Value.ToString();

            }
        }

        private void btnLuuDVT_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveDVT_Click(object sender, EventArgs e)
        {
            string tab = "DVT";


            Reset_Button(this, bAdd, tab);
            //bool flagadd = false;
            if (tmpOption == 1)
            {
                string ten = txtTenDVT.Text;
                DonViTinhDTO dvt = new DonViTinhDTO(ten);
                DonViTinhBUS.InsertDonViTinh(dvt);
                load_GridDaiLyDaDVT();
                gridDonViTinh.Enabled = true;
            }
            if (tmpOption == 2)
            {
                int madaily = Convert.ToInt16(txtmaDVT.Text);
                string ten = txtTenDVT.Text;
                DonViTinhDTO dvt = new DonViTinhDTO(madaily, ten);
                DonViTinhBUS.CapNhatDonViTinh(dvt);

                load_GridDaiLyDaDVT();
                gridDonViTinh.Enabled = true;

            }
            bAdd = false;
            Reset_Form(buttonDVT, bAdd, tab);
            btnThemDVT.Enabled = true;
        }

        private void btnXoaDVT_Click(object sender, EventArgs e)
        {
            //string tab = "DVT";
            //if (dl.Nocuadaily == 0)
            //{
            // string tab = "DL";
            DialogResult result = MessageBoxEx.Show("Bạn có muốn xóa đơn vị tính '" + txtTenDVT.Text + "' này không?",
                                                    "Xóa Đơn vị tính", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int madaly = Convert.ToInt16(txtmaDVT.Text);
                Clear_DataBinding(tmpCtrlDVT);
                DonViTinhBUS.XoaDonViTinh(madaly);
                load_GridDaiLyDaDVT();
                dtTBDVT = DonViTinhBUS.SelectAllDonViTinh();
                Load_DataBinding(dtTBDVT, tmpCtrlDVT, strColumnDVT);
            }
            //}
            //else
            //{
            //    MessageBox.Show("Đại lý này còn nợ không xóa được");
            //}
            load_GridDaiLyDaiLy();
            dtTBDaiLy = DaiLyBUS.SelectAllDaiLy();
            Load_DataBinding(dtTBDaiLy, tmpCtrlDaiLy, strColumnDaiLy);

        }

        private void btnSuaDVT_Click(object sender, EventArgs e)
        {
            Not_Enable_Control(Ctr_En_DVT);
            string tab = "DVT";
            tmpOption = 2;
            bAdd = true;
            Reset_Form(buttonDVT, bAdd, tab);
            gridDonViTinh.Enabled = false;
        }

        private void btnCancelDVT_Click(object sender, EventArgs e)
        {
            string tab = "DVT";
            bAdd = false;
            gridDonViTinh.Enabled = true;
            Reset_Form(buttonDVT, bAdd, tab);
            load_GridDaiLyDaDVT();
            dtTBDaiLy = DonViTinhBUS.SelectAllDonViTinh();

            Load_DataBinding(dtTBDaiLy, tmpCtrlDVT, strColumnDVT);
            btnThemDVT.Enabled = true;
        }

        private void btnThoatDVT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThoatPX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GridPhieuXuat1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.GridPhieuXuat1.CurrentRow != null)
            {
                this.txtMaPhieuXuat.Text = this.GridPhieuXuat1.CurrentRow.Cells["MaPhieuXuat"].Value.ToString();
                this.cbxDL.Text = this.GridPhieuXuat1.CurrentRow.Cells["MaDaiLy"].Value.ToString();
                this.dtpkNgayLapPhieu.Text = this.GridPhieuXuat1.CurrentRow.Cells["NgayLapPhieu"].Value.ToString();
                this.txtTongGiaTri.Text = this.GridPhieuXuat1.CurrentRow.Cells["TongGiaTri"].Value.ToString();

            }
            //LoadLai_lvwPhieuXuat(Convert.ToInt16(txtMaPhieuXuat.Text));
        }

        private void btnCancelPX_Click(object sender, EventArgs e)
        {
            string tab = "PX";
            bAdd = false;
            GridPhieuXuat1.Enabled = true;
            Reset_Form(buttonPX, bAdd, tab);
            load_GridPhieuXuat();
            dtTBPX = PhieuXuatBUS.SelectAllPhieuXuat();
            Load_DataBinding(dtTBPX, tmpCtrlPX, strColumnPX);
            lvwPhieuXuatHang.Items.Clear();
            cbxMatHang.Text = "";
            cbxDVT.Text = "";
            txtSoLuong.Text = "";
            txtDonGia.Text = "";

        }

        private void cbxDL_SelectedIndexChanged(object sender, EventArgs e)
        {

            //int madl = Convert.ToInt16(cbxDL.SelectedValue);
            //int no = DaiLyBUS.selectNoByMaDL(int.Parse(cbxDL.SelectedValue.ToString()));
            //txtNoDL.Text = no.ToString();
        }

        private void cbxDL_TextChanged(object sender, EventArgs e)
        {
            int madl = Convert.ToInt16(cbxDL.SelectedValue);
            int no = DaiLyBUS.selectNoByMaDL(madl);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int maDL = Convert.ToInt16(cbxDL_PT.SelectedValue);
            DateTime ngaythutien = dtpkNgayThuTien_PT.Value;
            string tien = txtSoTienThu_PT.Text;
            int sotienthu = int.Parse(tien);
            DaiLyDTO dl = DaiLyBUS.SelectDaiLyByMa(maDL);
            //dl.Nocuadaily = dl.Nocuadaily - sotienthu;
            if (sotienthu <= dl.Nocuadaily)
            {
                PhieuThuTienDTO pt = new PhieuThuTienDTO(maDL, ngaythutien, sotienthu);
                PhieuThuTienBUS.InsertPhieuThu(pt);
                // DaiLyDTO dl = DaiLyBUS.SelectDaiLyByMa(maDL);
                dl.Nocuadaily = dl.Nocuadaily - sotienthu;
                DaiLyBUS.updateDaiLy(dl);
                load_GridPhieuThu();
                MessageBox.Show("Thành Công.");
                Load_ComBo_PhieuThu();

            }
            else
            {
                MessageBox.Show("Số tiền thu vượt quá tiền nợ");
            }


        }

        private void cbxDL_PT_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ma = Convert.ToInt16(cbxDL_PT.SelectedValue.ToString());
            DataTable da = DaiLyBUS.SelectTTDLByMa(ma);
            txtDiaChi_PT.Text = da.Rows[0][0].ToString();
            txtDienThoai_PT.Text = da.Rows[0][1].ToString();
            txtEmail_PT.Text = da.Rows[0][2].ToString();
            txtSoTienThu_PT.Text = da.Rows[0][3].ToString();

        }

        private void buttonX58_Click(object sender, EventArgs e)
        {
            string madaily = txtMaDaiLy_TK.Text;
            string tendaily = txtTenDaiLy_TK.Text;
            string maloaidaily = cbxTenLDL_TK.Text;
            string dienthoai = txtDT_TK.Text;
            string diachi = txtDiaChi_TK.Text;
            string maquan = cbxQuan_TK.Text;
            string ngaytiepnhan = dtpkNgayTiepNhan_TK.Text;
            string emaildaily = txtEmail_TK.Text;
            string nodaily = txtNoDaiLy_TK.Text;
            if (madaily != "" || tendaily != "" || maloaidaily != "" || dienthoai != "" || diachi != "" || maquan != "" || emaildaily != "" || nodaily != "")
            {
                DataTable da = DaiLyBUS.SelectTimKiem(madaily, tendaily, maloaidaily, dienthoai, diachi, maquan, ngaytiepnhan, emaildaily, nodaily);
                load_GridTimKiem(da);
                Load_ComBo_TimKiem();
            }
            else MessageBox.Show("Chưa có thông tin tìm kiếm");
        }


        private void btnThoi_Click(object sender, EventArgs e)
        {
            load_TabTimKiem();
        }

        private void buttonX12_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonX9_Click_1(object sender, EventArgs e)
        {
            //int thang = dtpkThang_BC.Value.Month;
            //int nam = dtpkThang_BC.Value.Year;
            if (rdbCongNo.Checked == true)
            {
                // DataTable PS = DaiLyBUS.SelectAllMa_No_DaiLy();
                //DataTable baocaocongno = new DataTable();
                //DataTable PX = PhieuXuatBUS.tongGiaTriPXTrongThang(thang, nam);
                //DataTable PT = PhieuThuTienBUS.tongGiaTriPTTrongThang(thang, nam);
                //// int phatsinh = tongPX - tongPT;
                //for (int h = 0; h < PS.Rows.Count; h++)
                //{
                //    baocaocongno.Rows[h][0] = PS.Rows[h][0];
                //}
                //for (int h = 0; h < PS.Rows.Count; h++)
                //{
                //    baocaocongno.Rows[h][1] = PS.Rows[h][1];
                //}
                //for (int l = 0; l < PS.Rows.Count; l++)
                //{

                //    for (int j = 0; j < PX.Rows.Count; j++)
                //    {
                //        if (PS.Rows[l][0].ToString() == PX.Rows[j][0].ToString())
                //        {
                //            baocaocongno.Rows[l][2] = PX.Rows[j][1];

                //        }

                //    }
                //    for (int k = 0; k < PT.Rows.Count; k++)
                //    {
                //        if (PS.Rows[l][0].ToString() == PT.Rows[k][0].ToString())
                //        {
                //            baocaocongno.Rows[l][3] = PX.Rows[k][1];

                //        }
                //    }
                //}
                //for (int m = 0; m < PS.Rows.Count; m++)
                //{
                //    int xuat = int.Parse(baocaocongno.Rows[m][2].ToString());
                //    int thu = int.Parse(baocaocongno.Rows[m][3].ToString());
                //    baocaocongno.Rows[m][4] = xuat - thu;
                //}
                //for (int h = 0; h < PS.Rows.Count; h++)
                //{
                //    int cuoi = int.Parse(baocaocongno.Rows[h][1].ToString());
                //    int phatsinh = int.Parse(baocaocongno.Rows[h][4].ToString());
                //    baocaocongno.Rows[h][4] = cuoi - phatsinh;
                //}

            }
            else
            {

            }
        }

        private void btnThemQuan_Click(object sender, EventArgs e)
        {
            if (txtTenQuan.Text != "")
            {

                QuanDTO dvt = new QuanDTO();
                dvt.Tenquan = txtTenQuan.Text;
                new QuanBUS().ThemQuan(dvt);

                dtgvDSQ.DataSource = new QuanBUS().DanhSachQuan();
                MessageBox.Show("Quận đã được thêm");
                txtTenQuan.Text = "";
                txtMaQuan.Text = "";
            }

        }

        private void btnXoaQuan_Click(object sender, EventArgs e)
        {
            QuanDTO dvt = new QuanDTO();
            int maQuan = Convert.ToInt32(dtgvDSQ.CurrentRow.Cells["MaQuan"].Value);
            DataTable dt = DaiLyBUS.SelectDaiLyByMaQuan(maQuan);
            if(dt.Rows.Count == 0)
            {
                new QuanBUS().XoaQuan(maQuan);

                dtgvDSQ.DataSource = new QuanBUS().DanhSachQuan();
                
                txtTenQuan.Text = "";
                txtMaQuan.Text = "";
            }
            else
            {
                MessageBox.Show("Còn Đại lý thuộc quận này không xóa được");
            }
          
        }

        private void btnSuaQuan_Click(object sender, EventArgs e)
        {
            if (txtTenQuan.Text != "")
            {
                QuanDTO dvt = new QuanDTO();
                dvt.Tenquan = txtTenQuan.Text;
                dvt.Maquan = Convert.ToInt32(dtgvDSQ.CurrentRow.Cells["MaQuan"].Value.ToString());
                new QuanBUS().CapNhatQuan(dvt);

                dtgvDSQ.DataSource = new QuanBUS().DanhSachQuan();
                MessageBox.Show("Quận đã được cập nhật!");
                txtTenQuan.Text = "";
                txtMaQuan.Text = "";
            }
        }

        private void panelEx26_Click(object sender, EventArgs e)
        {

        }

        private void btnNapLaiQuan_Click(object sender, EventArgs e)
        {
            dtgvDSQ.DataSource = new QuanBUS().DanhSachQuan();
            txtTenQuan.Text = "";
            txtMaQuan.Text = "";
        }

        private void dtgvDSQ_SelectionChanged(object sender, EventArgs e)
        {
            txtMaQuan.Text = dtgvDSQ.CurrentRow.Cells["MaQuan"].Value.ToString();
            txtTenQuan.Text = dtgvDSQ.CurrentRow.Cells["TenQuan"].Value.ToString();
        }

        private void btnThemMH_Click(object sender, EventArgs e)
        {
            if (txtTenMH.Text != "" && txtSLgMH.Text != "")
            {
                MatHangDTO dvt = new MatHangDTO();
                dvt.Tenmathang = txtTenMH.Text;
                dvt.Soluongton = Convert.ToInt32(txtSLgMH.Text);
                MatHangBUS.ThemMatHang(dvt);
                DataTable dt = MatHangBUS.SelectAllmatHang();
                load_GridMatHang();
               // dtgvDSMH.DataSource = MatHangBUS.DanhSachMatHang();
                MessageBox.Show("Mặt hàng đã được thêm");
                txtMaMH.Text = "";
                txtTenMH.Text = "";
                txtSLgMH.Text = "";
            }
        }

        private void btnXoaMH_Click(object sender, EventArgs e)
        {
            MatHangDTO dvt = new MatHangDTO();
            int maMatHang = Convert.ToInt32(dtgvDSMH.CurrentRow.Cells["MaMatHang"].Value);
            MatHangBUS.XoaMatHang(maMatHang);

            dtgvDSMH.DataSource = MatHangBUS.DanhSachMatHang();
            MessageBox.Show("Mặt hàng đã được xóa");
            txtMaMH.Text = "";
            txtTenMH.Text = "";
            txtSLgMH.Text = "";
        }

        private void btnSuaMH_Click(object sender, EventArgs e)
        {
            if (txtTenMH.Text != "" && txtSLgMH.Text != "")
            {
                MatHangDTO dvt = new MatHangDTO();
                dvt.Tenmathang = txtTenMH.Text;
                dvt.Mamathang = Convert.ToInt32(dtgvDSMH.CurrentRow.Cells["MaMatHang"].Value.ToString());
                dvt.Soluongton = Convert.ToInt32(txtSLgMH.Text);
                MatHangBUS.CapNhatMatHang(dvt);

                dtgvDSMH.DataSource = MatHangBUS.DanhSachMatHang();
                MessageBox.Show("Mặt hàng đã được cập nhật!");
                txtMaMH.Text = "";
                txtTenMH.Text = "";
                txtSLgMH.Text = "";
            }
        }

        private void buttonX35_Click(object sender, EventArgs e)
        {
            dtgvDSMH.DataSource = MatHangBUS.DanhSachMatHang();
            txtMaMH.Text = "";
            txtTenMH.Text = "";
            txtSLgMH.Text = "";
        }

        private void buttonX36_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgvDSMH_SelectionChanged(object sender, EventArgs e)
        {
            txtMaMH.Text = dtgvDSMH.CurrentRow.Cells["MaMatHang"].Value.ToString();
            txtTenMH.Text = dtgvDSMH.CurrentRow.Cells["TenMatHang"].Value.ToString();
            txtSLgMH.Text = dtgvDSMH.CurrentRow.Cells["SoLuongTon"].Value.ToString();
        }

        private void btnSuaQD_Click(object sender, EventArgs e)
        {
            if (txtSLDLToiDa.Text != "" && txtSLLoaiDL.Text != "" && txtSLMatHang.Text != "" && txtSLDVT.Text != "")
            {
                ThamSoDTO ts = new ThamSoDTO();
                ts.Soluongdailytoidamoiquan = Convert.ToInt32(txtSLDLToiDa.Text);
                ts.Soluongloaidaily = Convert.ToInt32(txtSLLoaiDL.Text);
                ts.Soluongmathang = Convert.ToInt32(txtSLMatHang.Text);
                ts.SoluongDvt = Convert.ToInt32(txtSLDVT.Text);

                new ThamSoBUS().CapNhatThamSo(ts);

                dtgvThamSo.DataSource = new ThamSoBUS().DanhSachThamSo();
                MessageBox.Show("Tham số đã được cập nhật!");

                txtSLDLToiDa.Text = "";
                txtSLLoaiDL.Text = "";
                txtSLMatHang.Text = "";
                txtSLDVT.Text = "";
            }
        }

        private void buttonX20_Click(object sender, EventArgs e)
        {
            dtgvThamSo.DataSource = new ThamSoBUS().DanhSachThamSo();
            txtSLDLToiDa.Text = "";
            txtSLLoaiDL.Text = "";
            txtSLMatHang.Text = "";
            txtSLDVT.Text = "";
        }

        private void buttonX27_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgvThamSo_SelectionChanged(object sender, EventArgs e)
        {
            txtSLDLToiDa.Text = dtgvThamSo.CurrentRow.Cells["SoLuongDaiLyToiDaMoiQuan"].Value.ToString();
            txtSLLoaiDL.Text = dtgvThamSo.CurrentRow.Cells["SoLuongLoaiDaiLy"].Value.ToString();
            txtSLMatHang.Text = dtgvThamSo.CurrentRow.Cells["SoLuongMatHang"].Value.ToString();
            txtSLDVT.Text = dtgvThamSo.CurrentRow.Cells["SoLuongDVT"].Value.ToString();
        }

        private void checkBoxSLDLToiDaTrongQuan_CheckedChangedEx(object sender, DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs e)
        {
            if (this.checkBoxSLDLToiDaTrongQuan.Checked)
                txtSLDLToiDa.ReadOnly = false;
            else txtSLDLToiDa.ReadOnly = true;
        }

        private void checkBoxSLLoaiDaiLy_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxSLLoaiDaiLy.Checked)
                txtSLLoaiDL.ReadOnly = false;
            else txtSLLoaiDL.ReadOnly = true;
        }

        private void checkBoxSLMatHang_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxSLMatHang.Checked)
                txtSLMatHang.ReadOnly = false;
            else txtSLMatHang.ReadOnly = true;

        }

        private void checkBoxSLDonViTinh_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxSLDonViTinh.Checked)
                txtSLDVT.ReadOnly = false;
            else txtSLDVT.ReadOnly = true;
        }

        private void buttonX46_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThemLoaiDL_Click(object sender, EventArgs e)
        {
            int slloaidldaco = LoaiDaiLyBUS.DemSoLoaiDL();
            int slloaidlquydinh = ThamSoBUS.SLLoaiDL();
            if (slloaidldaco < slloaidlquydinh)
            {
                txtMaLoaiDaiLy.Text = "";
                txtTenLoaiDaiLy.Text = "";
                txtTienNoToiDaDL.Text = "";
            }
            else
            {
                MessageBox.Show("Đã đủ loại đại lý không thêm được");
            }
        }

        private void btnXoaLoaiDL_Click(object sender, EventArgs e)
        {
            LoaiDaiLyDTO dvt = new LoaiDaiLyDTO();
            int maLoaiDaiLy = Convert.ToInt32(dtgvDSLDL.CurrentRow.Cells["MaLoaiDaiLy"].Value);
            new LoaiDaiLyBUS().XoaLoaiDaiLy(maLoaiDaiLy);

            dtgvDSLDL.DataSource = new LoaiDaiLyBUS().DanhSachLoaiDaiLy();
            MessageBox.Show("Loại đại lý đã được xóa");
            txtTenLoaiDaiLy.Text = "";
            txtTienNoToiDaDL.Text = "";
            txtMaLoaiDaiLy.Text = "";
        }

        private void btnSuaLoaiDL_Click(object sender, EventArgs e)
        {
            if (txtTenLoaiDaiLy.Text != "" && txtTienNoToiDaDL.Text != "")
            {
                LoaiDaiLyDTO dvt = new LoaiDaiLyDTO();
                dvt.Tenloaidaily = txtTenLoaiDaiLy.Text;
                dvt.Maloaidaily = Convert.ToInt32(dtgvDSLDL.CurrentRow.Cells["MaLoaiDaiLy"].Value.ToString());
                dvt.Notoida = Convert.ToInt32(txtNoCuaDaiLy.Text);
                new LoaiDaiLyBUS().CapNhatLoaiDaiLy(dvt);

                dtgvDSLDL.DataSource = new LoaiDaiLyBUS().DanhSachLoaiDaiLy();
                MessageBox.Show("Loại đại lý đã được cập nhật!");
                txtTenLoaiDaiLy.Text = "";
                txtTienNoToiDaDL.Text = "";
                txtMaLoaiDaiLy.Text = "";
            }
        }

        private void dtgvDSLDL_SelectionChanged(object sender, EventArgs e)
        {
            txtTenLoaiDaiLy.Text = dtgvDSLDL.CurrentRow.Cells["TenLoaiDaiLy"].Value.ToString();
            txtTienNoToiDaDL.Text = dtgvDSLDL.CurrentRow.Cells["NoToiDa"].Value.ToString();
            txtMaLoaiDaiLy.Text = dtgvDSLDL.CurrentRow.Cells["MaLoaiDaiLy"].Value.ToString();
        }

        private void btnHosting_Click(object sender, EventArgs e)
        {
            this.tabQLDL.SelectedTab = tabLoaiDaiLy;

        }

        private void buttonItem30_Click(object sender, EventArgs e)
        {
            this.tabQLDL.SelectedTab = tabMatHang;
        }

        private void buttonItem31_Click(object sender, EventArgs e)
        {
            this.tabQLDL.SelectedTab = tabDonViTinh;
        }

        private void buttonItem33_Click(object sender, EventArgs e)
        {
            this.tabQLDL.SelectedTab = tabQuan;
        }

        private void btnDKHosting_Click(object sender, EventArgs e)
        {
            this.tabQLDL.SelectedTab = tabPhieuXuatHang;
        }

        private void btnDKTenMien_Click(object sender, EventArgs e)
        {
            this.tabQLDL.SelectedTab = tabPhieuThuTien;
        }

        private void btnXemBaoCaoHostingThang_Click(object sender, EventArgs e)
        {
            this.tabQLDL.SelectedTab = tabLapBaoCao;
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            this.tabQLDL.SelectedTab = tabLapBaoCao;
        }



        private void buttonItem5_Click(object sender, EventArgs e)
        {
            this.tabQLDL.SelectedTab = tabTraCuuDaiLy;
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            //proc.EnableRaisingEvents = false;
            //proc.StartInfo.FileName = "H2Viewer";
            //proc.StartInfo.Arguments = "\"" +  + "\"";
            proc.StartInfo.FileName = "TroGiup.chm";
            proc.Start();
        }

        private void ribbonBar5_ItemClick(object sender, EventArgs e)
        {

        }

        private void buttonItem2_Click_1(object sender, EventArgs e)
        {
            this.tabQLDL.SelectedTab = tabThayDoiQuyDinh;
        }

        private void txtSLDLToiDa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;

        }

        private void txtSLLoaiDL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;

        }

        private void txtSLMatHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;

        }

        private void txtSLDVT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;


        }

        private void txtSLgMH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;

        }

        private void txtTienNoToiDaDL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;

        }

        private void txtDT_TK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;

        }

        private void txtNoDaiLy_TK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;

        }

        private void txtSoTienThu_PT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;

        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;

        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;

        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;

        }

        private void buttonItem23_Click(object sender, EventArgs e)
        {

            frmInfo info = new frmInfo();
            info.ShowDialog();
        }
        public static DateTime ngay;

        private void buttonX9_Click_2(object sender, EventArgs e)
        {
            ngay = Convert.ToDateTime(dtpkThang_BC.Value.ToShortDateString());
           int  thang = dtpkThang_BC.Value.Month;
            int nam = dtpkThang_BC.Value.Year;
            if (rdbCongNo.Checked == true)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("TenDaiLy", typeof(string)));
                dt.Columns.Add(new DataColumn("NoDau", typeof(int)));
                dt.Columns.Add(new DataColumn("PhatSinh", typeof(int)));
                dt.Columns.Add(new DataColumn("NoCuoi", typeof(int)));

                DataTable PS = DaiLyBUS.SelectAllMa_No_DaiLy_Moi();

                DataTable PX = PhieuXuatBUS.tongGiaTriPXTrongThang(thang, nam);
                DataTable PT = PhieuThuTienBUS.tongGiaTriPTTrongThang(thang, nam);

                DataRow dr;
                for (int i = 0; i < PS.Rows.Count; i++)
                {
                    int xuat = 0;
                    int thu = 0;
                    for (int j = 0; j < PX.Rows.Count; j++)
                    {
                        if (PS.Rows[i][0].ToString() == PX.Rows[j][0].ToString())
                            xuat = Convert.ToInt32(PX.Rows[j][1]);
                    }
                    for (int k = 0; k < PT.Rows.Count; k++)
                    {
                        if (PS.Rows[i][0].ToString() == PT.Rows[k][0].ToString())
                            thu = Convert.ToInt32(PT.Rows[k][1]);
                    }
                    int ps = xuat - thu;
                    int ma = Convert.ToInt16(PS.Rows[i][0]);
                    int nocuoi = DaiLyBUS.selectNoByMaDL_Moi(ma);
                    int nodau = nocuoi - ps;
                    dr = dt.NewRow();
                    dr["TenDaiLy"] = PS.Rows[i][1];
                    dr["NoDau"] = nodau.ToString();
                    dr["PhatSinh"] = ps;
                    dr["NoCuoi"] = nocuoi.ToString();
                    dt.Rows.Add(dr);
                    
                }
                load_GridBaoCao_CongNo(dt);
                //frmMainReCongNo frm = new frmMainReCongNo(dt);
                //frm.ShowDialog();
                
            }
            if (rdbDoanhSo.Checked == true)
            {
                DataTable dttb = new DataTable();
                dttb.Columns.Add(new DataColumn("TenDaiLy", typeof(string)));
                dttb.Columns.Add(new DataColumn("SoPhieuXuat", typeof(int)));
                dttb.Columns.Add(new DataColumn("TongGiaTri", typeof(int)));
                dttb.Columns.Add(new DataColumn("TyLe", typeof(int)));
                DataTable tatca = DaiLyBUS.SelectAllDaiLy();
                DataTable PP = DaiLyBUS.SelectDemSoPhieuXuat(thang, nam);
                int tong_gt_px = PhieuXuatBUS.TongGiaTriPX_Moi(thang, nam);
                DataRow drr;
                for (int i = 0; i < tatca.Rows.Count; i++)
                {
                    int sophieuxuat = 0;
                    int tonggiatri = 0;
                    double tyle = 0;
                    for (int j = 0; j < PP.Rows.Count; j++)
                    {
                        if (tatca.Rows[i][0].ToString() == PP.Rows[j][0].ToString())
                        {
                            sophieuxuat = Convert.ToInt16(PP.Rows[j][2]);
                            tonggiatri = Convert.ToInt32(PP.Rows[j][3]);
                            tyle = Convert.ToDouble(tonggiatri) / tong_gt_px * 100;
                        }
                    }
                    //string tl = Math.Round(tyle, 2).ToString() + "%";
                    double tl = Math.Round(tyle, 2);
                    drr = dttb.NewRow();
                    drr["TenDaiLy"] = tatca.Rows[i][1];
                    drr["SoPhieuXuat"] = sophieuxuat;
                    drr["TongGiaTri"] = tonggiatri;
                    //drr["TyLe"] = 34;
                    //drr["TyLe"] = 34.ToString();
                    drr["TyLe"] = tl;
                    dttb.Rows.Add(drr);
                   
                }
                //frmMainDoanhSo frm = new frmMainDoanhSo(dttb);
                //frm.ShowDialog();
                load_GridBaoCao_DoanhSo(dttb);
            }
             
        }

        private void buttonX23_Click(object sender, EventArgs e)
        {
            //int maDVT = Convert.ToInt16(cbxDonViTInh_DG.SelectedValue.ToString());
            //int maMH = Convert.ToInt16(cbxMH_DG.SelectedValue.ToString());
            //int sl =Convert.ToInt16(txtSLDVT_DG.Text);
            //int gia = Convert.ToInt32(txtGia_DG.Text);
            //GiaBanTheoDonViTinhDTO dl = new GiaBanTheoDonViTinhDTO(maDVT,maMH,sl,gia);
            //GiaBanTheoDonViTinhBUS.InsertGiaBan(dl);
            //load_GridDonGia();
            //txtSLDVT_DG.Text = "";
            //txtGia_DG.Text = "";
            txtMaGiaBan_DG.Text = "";
            Load_ComBo_DonGia();
            txtSLDVT_DG.Text = "";
            txtGia_DG.Text = "";

        }

        private void buttonX22_Click(object sender, EventArgs e)
        {
            int ma = Convert.ToInt16(txtMaGiaBan_DG.Text);
            GiaBanTheoDonViTinhBUS.DeleteGiaBan(ma);
            load_GridDonGia();
        }

        private void GridDonGia_SelectionChanged(object sender, EventArgs e)
        {
            
            txtMaGiaBan_DG.Text = GridDonGia.CurrentRow.Cells["MaGiaBanTheoDVT"].Value.ToString();
            cbxDonViTInh_DG.Text = GridDonGia.CurrentRow.Cells["MaDonViTinh"].Value.ToString();
            cbxMH_DG.Text = GridDonGia.CurrentRow.Cells["MaMatHang"].Value.ToString();
            txtSLDVT_DG.Text = GridDonGia.CurrentRow.Cells["SoLuongTheoDVT"].Value.ToString();
            txtGia_DG.Text = GridDonGia.CurrentRow.Cells["DonGiaBan"].Value.ToString();
        }

        private void buttonX28_Click(object sender, EventArgs e)
        {
            int maDVT = Convert.ToInt16(cbxDonViTInh_DG.SelectedValue.ToString());
            int maMH = Convert.ToInt16(cbxMH_DG.SelectedValue.ToString());
            int sl = Convert.ToInt16(txtSLDVT_DG.Text);
            int gia = Convert.ToInt32(txtGia_DG.Text);
            GiaBanTheoDonViTinhDTO dl = new GiaBanTheoDonViTinhDTO(maDVT, maMH, sl, gia);
            GiaBanTheoDonViTinhBUS.InsertGiaBan(dl);
            load_GridDonGia();
            //txtSLDVT_DG.Text = "";
            //txtGia_DG.Text = "";
        }

        private void txtSLDVT_DG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtGia_DG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void buttonX18_Click(object sender, EventArgs e)
        {
            int ma = Convert.ToInt16(txtMaGiaBan_DG.Text);
            int maDVT = Convert.ToInt16(cbxDonViTInh_DG.Text);
            int maMH = Convert.ToInt16(cbxMH_DG.Text);
            int sl = Convert.ToInt16(txtSLDVT_DG.Text);
            int gia = Convert.ToInt32(txtGia_DG.Text);
            GiaBanTheoDonViTinhDTO dl = new GiaBanTheoDonViTinhDTO(ma,maDVT, maMH, sl, gia);
            GiaBanTheoDonViTinhBUS.updateGiaBan(dl);
            load_GridDonGia();
            //txtSLDVT_DG.Text = "";
            //txtGia_DG.Text = "";
        }

        private void tabDaiLy_Click(object sender, EventArgs e)
        {
            load_TabDaiLy();
        }

        private void tabPhieuXuatHang_Click(object sender, EventArgs e)
        {
            load_lvwPhieuXuatHang();
        }

        private void tabPhieuThuTien_Click(object sender, EventArgs e)
        {
            load_TabPhieuThu();
        }

        private void tabTraCuuDaiLy_Click(object sender, EventArgs e)
        {
            load_TabTimKiem();
        }

        private void tabLapBaoCao_Click(object sender, EventArgs e)
        {
            load_TabBaoCao();
        }

       

        private void tabDonViTinh_Click(object sender, EventArgs e)
        {
            load_TabDonViTinh();
        }

        private void tabDonGia_Click(object sender, EventArgs e)
        {
            load_TabDonGia();
        }

        private void buttonX29_Click_1(object sender, EventArgs e)
        {
            ngay = Convert.ToDateTime(dtpkThang_BC.Value.ToShortDateString());
            int thang = dtpkThang_BC.Value.Month;
            int nam = dtpkThang_BC.Value.Year;
            if (rdbCongNo.Checked == true)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("TenDaiLy", typeof(string)));
                dt.Columns.Add(new DataColumn("NoDau", typeof(int)));
                dt.Columns.Add(new DataColumn("PhatSinh", typeof(int)));
                dt.Columns.Add(new DataColumn("NoCuoi", typeof(int)));

                DataTable PS = DaiLyBUS.SelectAllMa_No_DaiLy_Moi();

                DataTable PX = PhieuXuatBUS.tongGiaTriPXTrongThang(thang, nam);
                DataTable PT = PhieuThuTienBUS.tongGiaTriPTTrongThang(thang, nam);

                DataRow dr;
                for (int i = 0; i < PS.Rows.Count; i++)
                {
                    int xuat = 0;
                    int thu = 0;
                    for (int j = 0; j < PX.Rows.Count; j++)
                    {
                        if (PS.Rows[i][0].ToString() == PX.Rows[j][0].ToString())
                            xuat = Convert.ToInt32(PX.Rows[j][1]);
                    }
                    for (int k = 0; k < PT.Rows.Count; k++)
                    {
                        if (PS.Rows[i][0].ToString() == PT.Rows[k][0].ToString())
                            thu = Convert.ToInt32(PT.Rows[k][1]);
                    }
                    int ps = xuat - thu;
                    int ma = Convert.ToInt16(PS.Rows[i][0]);
                    int nocuoi = DaiLyBUS.selectNoByMaDL_Moi(ma);
                    int nodau = nocuoi - ps;
                    dr = dt.NewRow();
                    dr["TenDaiLy"] = PS.Rows[i][1];
                    dr["NoDau"] = nodau.ToString();
                    dr["PhatSinh"] = ps;
                    dr["NoCuoi"] = nocuoi.ToString();
                    dt.Rows.Add(dr);

                }
                frmMainReCongNo frm = new frmMainReCongNo(dt,ngay);
                frm.ShowDialog();

            }
            if (rdbDoanhSo.Checked == true)
            {
                DataTable dttb = new DataTable();
                dttb.Columns.Add(new DataColumn("TenDaiLy", typeof(string)));
                dttb.Columns.Add(new DataColumn("SoPhieuXuat", typeof(int)));
                dttb.Columns.Add(new DataColumn("TongGiaTri", typeof(int)));
                dttb.Columns.Add(new DataColumn("TyLe", typeof(int)));
                DataTable tatca = DaiLyBUS.SelectAllDaiLy();
                DataTable PP = DaiLyBUS.SelectDemSoPhieuXuat(thang, nam);
                int tong_gt_px = PhieuXuatBUS.TongGiaTriPX_Moi(thang, nam);
                DataRow drr;
                for (int i = 0; i < tatca.Rows.Count; i++)
                {
                    int sophieuxuat = 0;
                    int tonggiatri = 0;
                    double tyle = 0;
                    for (int j = 0; j < PP.Rows.Count; j++)
                    {
                        if (tatca.Rows[i][0].ToString() == PP.Rows[j][0].ToString())
                        {
                            sophieuxuat = Convert.ToInt16(PP.Rows[j][2]);
                            tonggiatri = Convert.ToInt32(PP.Rows[j][3]);
                            tyle = Convert.ToDouble(tonggiatri) / tong_gt_px * 100;
                        }
                    }
                    //string tl = Math.Round(tyle, 2).ToString() + "%";
                    double tl = Math.Round(tyle, 2);
                    drr = dttb.NewRow();
                    drr["TenDaiLy"] = tatca.Rows[i][1];
                    drr["SoPhieuXuat"] = sophieuxuat;
                    drr["TongGiaTri"] = tonggiatri;
                    //drr["TyLe"] = 34;
                    //drr["TyLe"] = 34.ToString();
                    drr["TyLe"] = tl;
                    dttb.Rows.Add(drr);

                }
               // frmMainDoanhSo frm = new frmMainDoanhSo(dttb, ngay);
                frmMainDoanhSo frm = new frmMainDoanhSo(dttb, ngay);
                frm.ShowDialog();
            }
             
        }

        private void buttonX34_Click(object sender, EventArgs e)
        {
            if (txtTenLoaiDaiLy.Text != "" && txtTienNoToiDaDL.Text != "")
            {
                LoaiDaiLyDTO dl = new LoaiDaiLyDTO();
                dl.Tenloaidaily = txtTenLoaiDaiLy.Text;
                dl.Notoida = Convert.ToInt32(txtTienNoToiDaDL.Text);

                new LoaiDaiLyBUS().ThemLoaiDaiLy(dl);

                // dtgvDSLDL.DataSource = new LoaiDaiLyBUS().DanhSachLoaiDaiLy();
                load_GridLoaiDaiLy();
                MessageBox.Show("Loại đại lý đã được thêm");
                txtTenLoaiDaiLy.Text = "";
                txtTienNoToiDaDL.Text = "";
                txtMaLoaiDaiLy.Text = "";
            }
        }

       
        
    }
}