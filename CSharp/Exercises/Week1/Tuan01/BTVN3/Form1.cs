using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BTVN3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnTinhTBC_Click(object sender, EventArgs e)
        {
            string strDaySo = txtDaySo.Text;
            string[] arrChuoiPS = strDaySo.Split(',');

            PhanSo[] arrPhanSo = new PhanSo[50];

            int n = arrChuoiPS.Length;
            for (int i = 0; i < n; i++)
            {
                PhanSo a;
                a = new PhanSo();
                string[] arrTemp =  arrChuoiPS[i].Split('/');
                int b = arrTemp.Length;

                if (b == 1) //Tuc la chi co tu so
                {
                    
                }

                
            }
           
           
        }
    }
}