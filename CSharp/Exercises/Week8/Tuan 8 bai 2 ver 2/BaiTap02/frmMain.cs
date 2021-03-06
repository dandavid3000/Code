using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BaiTap02
{
    public partial class frmMain : Form
    {
        private SanDau _sd = new SanDau();
        private Bong _bong = new Bong();
        private NguoiChoi01 _nc01 = new NguoiChoi01();
        private NguoiChoi02 _nc02 = new NguoiChoi02();

        public frmMain()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmMain_Load);
            this.Paint += new PaintEventHandler(frmMain_Paint);
            this.KeyDown += new KeyEventHandler(frmMain_KeyDown);
            this.MouseWheel += new MouseEventHandler(frmMain_MouseWheel);
            this.myTimer.Tick += new EventHandler(myTimer_Tick);
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            frmUser user = new frmUser();
            if (user.ShowDialog() == DialogResult.OK)
            {
                _nc01.Ten = user.NguoiChoi01;
                _nc02.Ten = user.NguoiChoi02;
            }
            else
                Application.Exit();

          
            this.ClientSize = new Size(700, 525);
          
            this.BackColor = Color.Black;

          
            _sd.GanToaDo(175, 475, 100, 600);
          
            _nc01.GanToaDo(275, 375, 80, 100);
            _nc02.GanToaDo(275, 375, 600, 620);
           
            _bong.GanToaDo(315, 335, 340, 360);

          
            _bong.GanVectorDiChuyen(-10, 10);            

           
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }
        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            _sd.VeSanDau(e.Graphics);
            _nc01.VeNguoiChoi(e.Graphics);
            _nc02.VeNguoiChoi(e.Graphics);
            _bong.VeBong(e.Graphics);

            Font f = new Font("Times New Roman", 50, FontStyle.Bold, GraphicsUnit.Pixel);
            StringFormat strF = new StringFormat();

            strF.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(_nc01.Ten, f, Brushes.Yellow, 0, 75, strF);

            strF.Alignment = StringAlignment.Far;
            e.Graphics.DrawString(_nc02.Ten, f, Brushes.Yellow, this.Width, 75, strF);

            strF.Alignment = StringAlignment.Center;
            e.Graphics.DrawString("TỈ SỐ", f, Brushes.White, this.Width / 2, 50, strF);

            strF.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(
                _nc01.SoTranThang.ToString("0#") + "-" + _nc02.SoTranThang.ToString("0#"),
                f, Brushes.Green, this.Width / 2, 100, strF);
        }
        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.A && _nc01.Tren > _sd.Tren)
            {
                _nc01.DiChuyenLen();
                this.Invalidate();
            }
            else if (e.KeyData == Keys.Z && _nc01.Duoi < _sd.Duoi)
            {
                _nc01.DiChuyenXuong();
                this.Invalidate();
            }
            else if (e.KeyData == Keys.Space && myTimer.Enabled == false)
                myTimer.Enabled = true;
        }
        private void frmMain_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0 && _nc02.Tren > _sd.Tren) // scroll up
                _nc02.DiChuyenLen();
            if (e.Delta < 0 && _nc02.Duoi < _sd.Duoi) // scroll down
                _nc02.DiChuyenXuong();
            this.Invalidate();
        }
        private void myTimer_Tick(object sender, EventArgs e)
        {
            _bong.DiChuyen();
            this.Invalidate();

         
            if (_bong.Tren == _sd.Tren || _bong.Duoi == _sd.Duoi)
            {
                _bong.GanVectorDiChuyen(_bong.VectorDiChuyenX, -_bong.VectorDiChuyenY);
            }
          
            if (_bong.Trai == _sd.Trai || _bong.Phai == _sd.Phai)
            {
                float giuaY = _bong.Tren + (_bong.Duoi - _bong.Tren) / 2;
            
                if (_bong.Trai == _sd.Trai)
                {
                    if (giuaY < _nc01.Tren || giuaY > _nc01.Duoi)
                    {
                        _nc02.SoTranThang += 1;
                        goto reset;
                    }
                }
               
                if (_bong.Phai == _sd.Phai)
                {
                    if (giuaY < _nc02.Tren || giuaY > _nc02.Duoi)
                    {
                        _nc01.SoTranThang += 1;
                        goto reset;
                    }
                }
                _bong.GanVectorDiChuyen(-_bong.VectorDiChuyenX, _bong.VectorDiChuyenY);
                return;

            reset:
                _bong.GanToaDo(315, 335, 340, 360);
                _nc01.GanToaDo(275, 375, 80, 100);
                _nc02.GanToaDo(275, 375, 600, 620);
                myTimer.Enabled = false;
            }
        }
        private void btnPlay_Click(object sender, EventArgs e)
        {
           myTimer.Enabled = true;
        }

        private void btnHuongDan_Click(object sender, EventArgs e)
        {
          frmHuongDan hd = new frmHuongDan();
            hd.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}