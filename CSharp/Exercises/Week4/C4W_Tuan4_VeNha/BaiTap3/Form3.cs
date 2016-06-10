using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace BaiTap3
{
    public partial class Form1 : Form
    {
        // luu danh sach hinh
        ArrayList dsHinh = new ArrayList();
        // bien thu tu hinh
        int iThuTu = 0;
        DirectoryInfo dir = new DirectoryInfo("image");

        public Form1()
        {
            InitializeComponent();
            this.Text = "Demo";
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.Opacity = 0.75;
        }

        void LayDanhSachHinh()
        {
            foreach (FileInfo file in dir.GetFiles())
            {
                if (file.Extension == ".jpg")
                {
                    dsHinh.Add(file.FullName);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LayDanhSachHinh();
            string url = (string)dsHinh[iThuTu];
            this.BackgroundImage = new Bitmap(url);       
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // bam nut esc
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            // bam nut qua trai
            else if (e.KeyCode == Keys.Left)
            {
                iThuTu = (iThuTu + 1) % dsHinh.Count;
                string url = (string)dsHinh[iThuTu];
                this.BackgroundImage = new Bitmap(url);
            }
            // bam nut qua phai
            else if (e.KeyCode == Keys.Right)
            {
                if (iThuTu == 0)
                {
                    string url = (string)dsHinh[dsHinh.Count - 1];
                    iThuTu = dsHinh.Count - 2;
                    this.BackgroundImage = new Bitmap(url);
                }
                else
                {
                    iThuTu = (iThuTu - 1) % dsHinh.Count;
                    string url = (string)dsHinh[iThuTu];
                    this.BackgroundImage = new Bitmap(url);
                }
            }
            else if (e.KeyCode == Keys.A)
            {
                Auto();
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                iThuTu = (iThuTu + 1) % dsHinh.Count;
                string url = (string)dsHinh[iThuTu];
                this.BackgroundImage = new Bitmap(url);
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (iThuTu == 0)
                {
                    string url = (string)dsHinh[dsHinh.Count - 1];
                    iThuTu = dsHinh.Count - 2;
                    this.BackgroundImage = new Bitmap(url);
                }
                else
                {
                    string url = (string)dsHinh[iThuTu];
                    this.BackgroundImage = new Bitmap(url);
                    iThuTu = (iThuTu - 1) % dsHinh.Count;
                }
            }
        }

        void Auto()
        {
            for (int i = 0; i < 1000000; i++)
            {
                if (i % 5000 == 0)
                {
                    iThuTu = (iThuTu + i) % dsHinh.Count;
                    string url = (string)dsHinh[iThuTu];
                    this.BackgroundImage = new Bitmap(url);
                }                
            }               
        }
    }
}