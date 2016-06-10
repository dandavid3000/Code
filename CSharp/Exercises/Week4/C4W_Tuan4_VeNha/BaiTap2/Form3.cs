using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BaiTap2
{
    public partial class Form3 : Form
    {              
        private int iLuotDi = 0;
        private Button[,] arrButton;
        private MenuStrip MainMenu = new MenuStrip();
        private ToolStripMenuItem KichThuoc = new ToolStripMenuItem();
        private ToolStripMenuItem Bac1 = new ToolStripMenuItem();
        private ToolStripMenuItem Bac2 = new ToolStripMenuItem();
        private ToolStripMenuItem Bac3 = new ToolStripMenuItem();

        public Form3()
        {
            InitializeComponent();
            
            this.KichThuoc.Text = "Kích Thước";
            this.Bac1.Text = "10 X 10";
            this.Bac2.Text = "20 X 20";
            this.Bac3.Text = "30 X 30";
            this.MainMenu.Items.AddRange(new ToolStripMenuItem[] { KichThuoc });
            this.KichThuoc.DropDownItems.AddRange(new ToolStripMenuItem[] { Bac1 });
            this.KichThuoc.DropDownItems.AddRange(new ToolStripMenuItem[] { Bac2 });
            this.KichThuoc.DropDownItems.AddRange(new ToolStripMenuItem[] { Bac3 });

            this.Bac1.Click += new EventHandler(Bac1_Click);
            this.Bac2.Click += new EventHandler(Bac2_Click);
            this.Bac3.Click += new EventHandler(Bac3_Click);
            
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Controls.Add(MainMenu);                        
        }

        private int N = 0;

        void TaoButton(int n)
        {                       
            // ===============================               
            if (arrButton != null && arrButton[0, 0] != null)
            {
                int M = N;
                for (int i = 0; i < M; i++)
                    for (int j = 0; j < M; j++)
                    {
                        arrButton[i, j].Dispose();
                        arrButton[i, j] = null;
                    }
            }
            arrButton = new Button[n, n];
            N = n;
            // ================================
            //ArrayList arrList;
            // can can thiep [i,j]: arrList[i*N+j]
            // khi can phan tich: arrList[k] tuong ung [k div N, k mod N]

            // ===============================
            //Array.Clear(arrButton, 0, n * n - 1);            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {                   
                    arrButton[i, j] = new Button();
                    arrButton[i, j].Size = new Size(20, 20);                    
                    arrButton[i, j].Location = new Point(j * 20, i * 20 + 23);
                    arrButton[i, j].Click += new EventHandler(arrButton_Click);
                    this.Controls.Add(arrButton[i, j]);
                }
            }
            this.ClientSize = new Size(n * 20, n * 20 + 23);
        }

        void Bac1_Click(object sender, EventArgs e)
        {
           TaoButton(10);
        }

        void Bac2_Click(object sender, EventArgs e)
        {
            TaoButton(20);
        }

        void Bac3_Click(object sender, EventArgs e)
        {
            TaoButton(30);
        }

        void arrButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (iLuotDi == 0)
            {
                button.Text = "X";
                button.Enabled = false;
                iLuotDi = 1;
            }
            else
            {
                button.Text = "O";
                button.Enabled = false;
                iLuotDi = 0;
            }
        }        
    }
}