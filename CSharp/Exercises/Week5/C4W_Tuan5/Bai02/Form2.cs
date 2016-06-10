using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Bai02
{
    public partial class Form2 : Form
    {
        //thu muc hien tai
        DirectoryInfo curDir;
        private Label lblView = new Label();

        public Form2()
        {
            InitializeComponent();
            
            //form
            this.StartPosition = FormStartPosition.CenterScreen;
            //lbxView
            this.lblView.Dock = DockStyle.Fill;
            this.lblView.AutoSize = true;

            // them cot vao listview
            lvwDir.Columns.Add("Name", 200, HorizontalAlignment.Left);
            lvwDir.Columns.Add("Size", 80, HorizontalAlignment.Right);
            lvwDir.Columns.Add("Type", 80, HorizontalAlignment.Left);
            lvwDir.Columns.Add("Date Modified", 160, HorizontalAlignment.Left);
            // hien thi theo dang chi tiet
            lvwDir.View = View.Details;
            // them danh sach hinh cho icon cua listview
            lvwDir.SmallImageList = new ImageList();
            lvwDir.SmallImageList.Images.Add(new Icon("../../icons/folder.ico"));
            lvwDir.SmallImageList.Images.Add(new Icon("../../icons/document.ico"));
        }

        private void OpenDirectory()
        {
            try
            {
                txtAddress.Text = curDir.FullName;
                lvwDir.Items.Clear();

                if (curDir.Parent != null)
                {
                    if (curDir.Root != null)
                    {
                        ListViewItem lvi2 = lvwDir.Items.Add(".");
                        lvi2.Tag = curDir.Root;
                        lvi2.ImageIndex = 0;
                        lvi2.SubItems.Add("");
                        lvi2.SubItems.Add("Folder");
                        lvi2.SubItems.Add(curDir.Root.LastWriteTime.ToString());
                    }
                    ListViewItem lvi1 = lvwDir.Items.Add("..");
                    lvi1.Tag = curDir.Parent;
                    lvi1.ImageIndex = 0;
                    lvi1.SubItems.Add("");
                    lvi1.SubItems.Add("Folder");
                    lvi1.SubItems.Add(curDir.Parent.LastWriteTime.ToString());
                }

                foreach (DirectoryInfo subDir in curDir.GetDirectories())
                {
                    ListViewItem lvi = lvwDir.Items.Add(subDir.Name);
                    lvi.Tag = subDir;
                    lvi.ImageIndex = 0;
                    lvi.SubItems.Add("");
                    lvi.SubItems.Add("Folder");
                    lvi.SubItems.Add(subDir.LastWriteTime.ToString());
                }

                foreach (FileInfo file in curDir.GetFiles())
                {
                    ListViewItem lvi = lvwDir.Items.Add(file.Name);
                    lvi.Tag = file;
                    lvi.ImageIndex = 1;
                    lvi.SubItems.Add(file.Length.ToString());
                    lvi.SubItems.Add("File");
                    lvi.SubItems.Add(file.LastWriteTime.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 

        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                curDir = new DirectoryInfo(txtAddress.Text);
                OpenDirectory();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }       

        void btnDrive_Click(object sender, EventArgs e)
        {
            Button btnDrive = (Button)sender;
            DriveInfo drive = (DriveInfo)btnDrive.Tag;
            if (drive.IsReady)
            {                
                txtAddress.Text = drive.Name;
                curDir = new DirectoryInfo(txtAddress.Text);
                OpenDirectory();
            }
            else
            {
                string alert = string.Format("Ổ đĩa {0} chưa sẵn sàng", drive.Name);
                MessageBox.Show(alert, "Thông Báo");
            }           
        }        

        private void Form2_Load(object sender, EventArgs e)
        {
            int i = 0;
            foreach (DriveInfo d in DriveInfo.GetDrives())
            {
                Button btnDrive = new Button();
                btnDrive.Text = d.Name;
                btnDrive.Tag = d;
                btnDrive.Size = new Size(50, 25);
                btnDrive.Location = new Point(50 * i + 60, 10);
                btnDrive.Click += new EventHandler(btnDrive_Click);
                pnlDrives.Controls.Add(btnDrive);
                i++;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                curDir = new DirectoryInfo(txtAddress.Text);
                curDir = curDir.Parent;
                OpenDirectory();
            }
            catch
            {
                MessageBox.Show("No files selected!", "Thông Báo");
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvwDir.SelectedItems[0].Tag.GetType() == typeof(DirectoryInfo))
                {
                    MessageBox.Show("No files selected!", "Thông Báo");
                }
                else
                {                    
                    FileInfo file = (FileInfo)lvwDir.SelectedItems[0].Tag;
                    FileStream f = File.Open(file.FullName, FileMode.Open, FileAccess.Read);
                    frmView frm = new frmView();
                    frm.Text = file.Name;                     
                    StreamReader reader = new StreamReader(f);                   
                    this.lblView.Text = reader.ReadToEnd();
                    frm.Controls.Add(lblView);
                    frm.ShowDialog();
                    reader.Close();
                    f.Close();
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvwDir.SelectedItems[0].Tag.GetType() == typeof(DirectoryInfo))
                {
                    curDir = (DirectoryInfo)lvwDir.SelectedItems[0].Tag;
                    curDir.Delete(true);
                }
                else
                {
                    FileInfo file = (FileInfo)lvwDir.SelectedItems[0].Tag;
                    file.Delete();
                }
                lvwDir.Items.Remove(lvwDir.SelectedItems[0]);
            }
            catch
            {
                MessageBox.Show("No files selected!","Thông Báo");
            }
        }

        private void btnNewFolder_Click(object sender, EventArgs e)
        {
            try
            {
                this.btnGo_Click(sender, e);
                int i = 2;
                string title = "New Folder";
                
                foreach (DirectoryInfo subDir in curDir.GetDirectories())
                {
                    if (subDir.Name == title)
                    {
                        string[] arr = subDir.Name.Split(' ');
                        if (arr[arr.Length - 1] == string.Format("({0})",i))
                            i++;                        
                        title = string.Format("New Folder ({0})", i);                        
                    }
                }
                if (i % 10 == 0)
                {
                    foreach (DirectoryInfo subDir1 in curDir.GetDirectories())
                    {
                        if (subDir1.Name == title)
                        {
                            string[] arr1 = subDir1.Name.Split(' ');
                            if (arr1[arr1.Length - 1] == string.Format("({0})", i))
                                i++;
                        }
                        title = string.Format("New Folder ({0})", i);
                    }
                }
                DirectoryInfo dir = curDir.CreateSubdirectory(title);                
               
                this.btnGo_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvwDir.SelectedItems[0].Tag.GetType() == typeof(DirectoryInfo))
                {
                    MessageBox.Show("No files selected!", "Thông Báo");
                }
                else
                {
                    FileInfo file = (FileInfo)lvwDir.SelectedItems[0].Tag;
                    Process proc = new Process();                    
                    proc.StartInfo.Arguments = file.FullName;
                    proc.Start();
                }
            }
            catch 
            {
                MessageBox.Show("No files selected!", "Thông Báo");
            }            
        }

        private void lvwDir_ItemActivate(object sender, EventArgs e)
        {
            if (lvwDir.SelectedItems[0].Tag.GetType() == typeof(DirectoryInfo))
            {
                curDir = (DirectoryInfo)lvwDir.SelectedItems[0].Tag;
                OpenDirectory();
            }
            else
            {
                FileInfo file = (FileInfo)lvwDir.SelectedItems[0].Tag;
                System.Diagnostics.Process.Start(file.FullName);
            }
        }        
    }
}