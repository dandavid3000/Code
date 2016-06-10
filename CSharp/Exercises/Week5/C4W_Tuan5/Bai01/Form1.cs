using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Bai01
{
    public partial class Form1 : Form
    {
        private Panel pnlDrives = new Panel();

        public Form1()
        {
            InitializeComponent();
            //panel
            this.pnlDrives.AutoSize = true;
            this.pnlDrives.Location = new Point(40, 40);
            //form
            this.AutoSize = true;
            this.Text = "Load dong o dia";
            this.Controls.Add(pnlDrives);  
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int i = 0;
            foreach (DriveInfo d in DriveInfo .GetDrives ())
            {
                Button btnDrive = new Button();
                btnDrive.Text = d.Name;
                btnDrive.Tag = d;
                btnDrive.Size = new Size(50, 25);
                btnDrive.Location = new Point(55 * i, 10);
                btnDrive.Click += new EventHandler(btnDrive_Click);
                pnlDrives.Controls.Add(btnDrive);
                i++;
            }           
        }

        void btnDrive_Click(object sender, EventArgs e)
        {
            try
            {
                Button btnDrive = (Button)sender;
                DriveInfo drive = (DriveInfo)btnDrive.Tag;

                string driveInfo = string.Format("Name : {0}\nVolumeLabel : {1}\nTotalSize : {2}", drive.Name, drive.VolumeLabel, drive.TotalSize);
                MessageBox.Show(driveInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Thông Báo");
            }         
        }
    }
}