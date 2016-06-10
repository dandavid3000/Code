using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BaiTap1
{
    public partial class Form1 : Form
    {
        private Button btnCong = new Button();
        private Button btnTru = new Button();
        private Button btnNhan = new Button();
        private Button btnChia = new Button();
        private TextBox txtSo1 = new TextBox();
        private TextBox txtSo2 = new TextBox();
        private TextBox txtKQ = new TextBox();
        private Label lblSo1 = new Label();
        private Label lblSo2 = new Label();
        private Label lblKQ = new Label();
        private Button btnThoat = new Button();

        public Form1()
        {
            InitializeComponent();

            //lblSo1
            this.lblSo1.Size = new Size(30, 20);
            this.lblSo1.Text = "Số 1";
            this.lblSo1.Location = new Point(20, 23);

            //lblSo2
            this.lblSo2.Size = new Size(30, 20);
            this.lblSo2.Text = "Số 2";
            this.lblSo2.Location = new Point(20, 53);

            //lblKQ
            this.lblKQ.Size = new Size(50, 20);
            this.lblKQ.Text = "Kết Quả";
            this.lblKQ.Location = new Point(20, 83);

            //txtSo1
            this.txtSo1.Size = new Size(100, 20);
            this.txtSo1.Location = new Point(80, 20);

            //txtSo2
            this.txtSo2.Size = new Size(100, 20);
            this.txtSo2.Location = new Point(80, 50);

            //txtKQ
            this.txtKQ.Size = new Size(100, 20);
            this.txtKQ.Location = new Point(80, 80);
            this.txtKQ.ReadOnly = true;

            //btnCong
            this.btnCong.Size = new Size(50, 25);
            this.btnCong.Location = new Point(200, 20);
            this.btnCong.Text = "Cộng";
            this.btnCong.Click += new EventHandler(btnCong_Click);           

            //btnTru
            this.btnTru.Size = new Size(50, 25);
            this.btnTru.Location = new Point(200, 50);
            this.btnTru.Text = "Trừ";
            this.btnTru.Click += new EventHandler(btnTru_Click);

            //btnNhan
            this.btnNhan.Size = new Size(50, 25);
            this.btnNhan.Location = new Point(200, 80);
            this.btnNhan.Text = "Nhân";
            this.btnNhan.Click += new EventHandler(btnNhan_Click);

            //btnChia
            this.btnChia.Size = new Size(50, 25);
            this.btnChia.Location = new Point(200, 110);
            this.btnChia.Text = "Chia";
            this.btnChia.Click += new EventHandler(btnChia_Click);

            //btnThoat
            this.btnThoat.Size = new Size(50, 25);
            this.btnThoat.Location = new Point(75, 110);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new EventHandler(btnThoat_Click);

            //form
            this.Text = "May Tinh";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(300, 180);
            this.CancelButton = btnThoat;
            this.Controls.Add(btnCong);
            this.Controls.Add(btnTru);
            this.Controls.Add(btnNhan);
            this.Controls.Add(btnChia);
            this.Controls.Add(txtSo1);
            this.Controls.Add(lblSo1);
            this.Controls.Add(txtSo2);
            this.Controls.Add(lblSo2);
            this.Controls.Add(txtKQ);
            this.Controls.Add(lblKQ);
            this.Controls.Add(btnThoat);
        }

        void btnCong_Click(object sender, EventArgs e)
        {
            if ((KiemTra(txtSo1.Text)) && (KiemTra(txtSo2.Text)))
            {
                double kq = Convert.ToDouble(txtSo1.Text) + Convert.ToDouble(txtSo2.Text);
                txtKQ.Text = kq.ToString();
            }
            else
                MessageBox.Show("Không hợp lệ", "Thông Báo");
        }

        void btnTru_Click(object sender, EventArgs e)
        {
            if ((KiemTra(txtSo1.Text)) && (KiemTra(txtSo2.Text)))
            {
                double kq = Convert.ToDouble(txtSo1.Text) - Convert.ToDouble(txtSo2.Text);
                txtKQ.Text = kq.ToString();
            }
            else
                MessageBox.Show("Không hợp lệ", "Thông Báo");
        }

        void btnNhan_Click(object sender, EventArgs e)
        {
            if ((KiemTra(txtSo1.Text)) && (KiemTra(txtSo2.Text)))
            {
                double kq = Convert.ToDouble(txtSo1.Text) * Convert.ToDouble(txtSo2.Text);
                txtKQ.Text = kq.ToString();
            }
            else
                MessageBox.Show("Không hợp lệ", "Thông Báo");
        }

        void btnChia_Click(object sender, EventArgs e)
        {
            if ((KiemTra(txtSo1.Text)) && (KiemTra(txtSo2.Text)))
            {
                double kq = Convert.ToDouble(txtSo1.Text) / Convert.ToDouble(txtSo2.Text);
                txtKQ.Text = kq.ToString();
            }
            else
                MessageBox.Show("Không hợp lệ", "Thông Báo");
        }

        void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool KiemTra(string a)
        {            
            double kq;
            if (double.TryParse(a, out kq))
                return true;            

            return false;
        }        
    }
}