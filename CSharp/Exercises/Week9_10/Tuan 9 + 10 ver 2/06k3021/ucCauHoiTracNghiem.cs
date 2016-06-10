using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace _6k3021
{
    public partial class ucCauHoiTracNghiem : UserControl
    {
        public ucCauHoiTracNghiem()
        {
            InitializeComponent();
        }

        public string CauHoi
        {
            get { return txtCauHoi.Text; }
            set { txtCauHoi.Text = value; }

        }

        public string DapAnA
        {
            get { return txtDapAnA.Text; }
            set { txtDapAnA.Text = value; }
        }

        public string DapAnB
        {
            get { return txtDapAnB.Text; }
            set { txtDapAnB.Text = value; }
        }

        public string DapAnC
        {
            get { return txtDapAnC.Text; }
            set { txtDapAnC.Text = value; }
        }

        public string DapAnD
        {
            get { return txtDapAnD.Text; }
            set { txtDapAnD.Text = value; }
        }

        public string DapAnDuocChon
        {
            get
            {
                string Answer = string.Empty;

                if (rdA.Checked == true) Answer = "a";
                
                else if (rdB.Checked == true)Answer = "b";
               
                else if (rdC.Checked == true) Answer = "c";
               
                else if (rdD.Checked == true) Answer = "d";

                return Answer;
              
            }

            set
            {
                if (value == "a") rdA.Checked = true;
                else if (value == "a")
                {
                    rdA.Checked = false;
                    txtDapAnA.BackColor = Color.Green;
                }

                if (value == "b") rdB.Checked = true;
                else if (value == "b")
                {
                    rdB.Checked = false;
                    txtDapAnB.BackColor = Color.Blue;
                }

                if (value == "c") rdB.Checked = true;
                else if (value == "c")
                {
                    rdC.Checked = false;
                    txtDapAnC.BackColor = Color.Red;
                }

                if (value == "d") rdB.Checked = true;
                else if (value == "d")
                {
                    rdA.Checked = false;
                    txtDapAnD.BackColor = Color.Yellow;
                }
            }
        }

        public void KiemTra(string daDung, string daChon)
        {   //Neu chon dung dap an thi dong se chuyen sang mau hong
            if (daDung == "a") txtDapAnA.BackColor = Color.Pink;
            if (daDung == "b") txtDapAnB.BackColor = Color.Pink;
            if (daDung == "c") txtDapAnC.BackColor = Color.Pink;
            if (daDung == "d") txtDapAnD.BackColor = Color.Pink;
            //Chon dap an nao thi dong do se co mau trang
            if (daChon == "a") txtDapAnA.BackColor = Color.White;
            if (daChon == "b") txtDapAnB.BackColor = Color.White;
            if (daChon == "c") txtDapAnC.BackColor = Color.White;
            if (daChon == "d") txtDapAnD.BackColor = Color.White;
        }

        public void XemDA(string daChon)
        {
            rdA.Checked = false;
            rdB.Checked = false;
            rdC.Checked = false;
            rdC.Checked = false;

            if (daChon == "a") rdA.Checked = true;
            if (daChon == "b") rdB.Checked = true;
            if (daChon == "c") rdC.Checked = true;
            if (daChon == "d") rdD.Checked = true;
        }

  }

}
