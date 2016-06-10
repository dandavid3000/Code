using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Collections;

namespace WindowExplorer
{
    public partial class frmMain : Form
    {
        ///////////////////////////////
        private ArrayList arrNode_temp = new ArrayList();        

        ///////////////////////////////

        //thu muc hien tai
        private DirectoryInfo curDir;
        //private TreeNode curNode;
        private Label lblView = new Label();
        private Form frmView = new Form();

        public frmMain()
        {
            InitializeComponent();
            //label
            lblView.AutoSize = true;

            //formview
            frmView.StartPosition = FormStartPosition.CenterScreen;
            frmView.AutoSize = true;           

            //treenode   
            //curNode = new TreeNode();

            //treeview
            tvwDir.ImageList = new ImageList();
            tvwDir.ImageList.Images.Add(new Icon("../../icons/mycomputer.ico"));
            tvwDir.ImageList.Images.Add(new Icon("../../icons/drive.ico"));
            tvwDir.ImageList.Images.Add(new Icon("../../icons/folder_close.ico"));
            tvwDir.ImageList.Images.Add(new Icon("../../icons/folder_open.ico"));
            tvwDir.ImageList.Images.Add(new Icon("../../icons/document.ico"));

            //listview
            lvwDir.Columns.Add("Name", 200, HorizontalAlignment.Left);
            lvwDir.Columns.Add("Size", 80, HorizontalAlignment.Right);
            lvwDir.Columns.Add("Type", 80, HorizontalAlignment.Left);
            lvwDir.Columns.Add("Date Modified", 160, HorizontalAlignment.Left);

            // hien thi theo dang chi tiet
            lvwDir.View = View.Details;
            // them danh sach hinh cho icon cua listview
            lvwDir.SmallImageList = new ImageList();
            lvwDir.SmallImageList.Images.Add(new Icon("../../icons/folder_close.ico"));
            lvwDir.SmallImageList.Images.Add(new Icon("../../icons/document.ico"));

            // them nut My computer va cac o dia
            TreeNode myComputerNode = new TreeNode("My computer");
            myComputerNode.Tag = "My computer";
            myComputerNode.ImageIndex = 0;
            myComputerNode.SelectedImageIndex = 0;
            tvwDir.Nodes.Add(myComputerNode);
            // them cac node o dia vao mycomputer node
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                TreeNode driveNode = new TreeNode(drive.Name);
                driveNode.Tag = drive.RootDirectory;
                driveNode.ImageIndex = 1;
                driveNode.SelectedImageIndex = 1;
                myComputerNode.Nodes.Add(driveNode);
            }
        }

        private void tvwDir_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                // lay node dang duoc chon              
                TreeNode selectedNode = tvwDir.SelectedNode;

                //////////////////////////////////
                //curNode = selectedNode;     // ko
                arrNode_temp.Clear();
                ////////////////////////////////

                if (selectedNode.Tag.GetType() == typeof(DirectoryInfo))
                {
                    // xoa danh sach node da co
                    selectedNode.Nodes.Clear();
                    // them cac node thu muc con
                    DirectoryInfo dir = (DirectoryInfo)selectedNode.Tag;
                    foreach (DirectoryInfo subDir in dir.GetDirectories())
                    {
                        TreeNode dirNode = new TreeNode(subDir.Name);
                        dirNode.Tag = subDir;
                        dirNode.ImageIndex = 2;
                        dirNode.SelectedImageIndex = 3;
                        selectedNode.Nodes.Add(dirNode);

                        /////////////////////////////
                        arrNode_temp.Add(dirNode);
                        /////////////////////////////
                    }
                    // hien thi ben listview
                    curDir = dir;
                    OpenDirectory();
                }
                // mo rong node
                selectedNode.Expand();             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Thông Báo");
            }
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

        private void frmMain_Load(object sender, EventArgs e)
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

        private void lvwDir_ItemActivate(object sender, EventArgs e)
        {
            if (lvwDir.SelectedItems[0].Tag.GetType() == typeof(DirectoryInfo))
            {
                curDir = (DirectoryInfo)lvwDir.SelectedItems[0].Tag;
                //curNode.Tag = (DirectoryInfo)lvwDir.SelectedItems[0].Tag;
                //curNode.Expand();
                OpenDirectory();

                // lay node dang duoc chon              
                TreeNode selectedNode = tvwDir.SelectedNode;

                ////////////////////
                TreeNode tempNode = null;
                for (int i = 0; i < arrNode_temp.Count; i++)
                {
                    TreeNode node = (TreeNode)arrNode_temp[i];
                    DirectoryInfo selectedNodeDir = (DirectoryInfo)node.Tag;
                    if (selectedNodeDir.FullName == curDir.FullName)
                    {
                        tempNode = node;
                        break;
                    }
                }

                if (tempNode != null)
                {
                    tvwDir.SelectedNode = tempNode;
                    tvwDir_AfterSelect(null, null);
                }
                ///////////////////
            }
            else
            {
                FileInfo file = (FileInfo)lvwDir.SelectedItems[0].Tag;
                System.Diagnostics.Process.Start(file.FullName);
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
                    frmView.Text = file.Name;
                    StreamReader reader = new StreamReader(f);
                    this.lblView.Text = reader.ReadToEnd();
                    frmView.Controls.Add(lblView);
                    frmView.ShowDialog();
                    reader.Close();
                    f.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Thông Báo");
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
                    proc.StartInfo.FileName = "notepad";
                    proc.StartInfo.Arguments = file.FullName;
                    proc.Start();
                }
            }
            catch
            {
                MessageBox.Show("No files selected!", "Thông Báo");
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
                        if (arr[arr.Length - 1] == string.Format("({0})", i))
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
                MessageBox.Show("No files selected!", "Thông Báo");
            }
        }      
    }
}