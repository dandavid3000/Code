using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace QuanLy_IO
{
    public partial class frmQuanLy : Form
    {
        private ArrayList arrlist = new ArrayList();
        private Users _user;

        public Users User
        {
            get { return _user; }
            set { _user = value; }
        }

        public frmQuanLy()
        {
            InitializeComponent();

            lvwQuanLyNguoiDung.Columns.Add("STT");
            lvwQuanLyNguoiDung.Columns.Add("Tài khoản",200);
            lvwQuanLyNguoiDung.Columns.Add("Họ và Tên",200);
            lvwQuanLyNguoiDung.Columns.Add("Quyền",100);

            lvwQuanLyNguoiDung.View = View.Details;
            
        }

        private void frmQuanLy_Load(object sender, EventArgs e)
        {
            frmDangNhap frm = new frmDangNhap();
            frm.ShowDialog();
            if (frm.DangNhapThanhCong)
            {               
                _user = frm.User;
                lblTenNguoiDung.Text = "Xin chao : " + _user.FullName;
                // kiem tra group de phan quyen
                if (_user.Group == "admin")
                {
                    quanLyNguoiDungToolStripMenuItem.Visible = true;
                    quanLyNghiepVuToolStripMenuItem.Visible = false;
                }
                else if (_user.Group == "user")
                {
                    quanLyNguoiDungToolStripMenuItem.Visible = false;
                    quanLyNghiepVuToolStripMenuItem.Visible = true;
                }

                txtTaiKhoan.Text = _user.UserName;
                txtHovaTen.Text = _user.FullName;
                lvwQuanLyNguoiDung.Items.Clear();

                DirectoryInfo dir = new DirectoryInfo("../../users");                
                int i = 1;
                bool b = false;
                foreach (FileInfo file in dir.GetFiles())
                {
                    string[] arr = file.Name.Split('.');
                    Users user = new Users(arr[0]);
                    ListViewItem lvi = lvwQuanLyNguoiDung.Items.Add(i.ToString());
                    lvi.Tag = user;                    
                    lvi.SubItems.Add(user.UserName);
                    lvi.SubItems.Add(user.FullName);
                    lvi.SubItems.Add(user.Group);

                    user.Group = user.Group.ToLower();
                    for (int j = i; j < dir.GetFiles().Length; j++)
                    {
                        FileInfo f = dir.GetFiles()[j];
                        string[] a = f.Name.Split('.');
                        Users u = new Users(a[0]);
                        if (user.Group.ToLower() == u.Group.ToLower())                       
                            b = true;                  
                    }
                    if (b == false)
                        arrlist.Add(user);
                    b = false;
                    i++;
                }

                cbxQuyen.DataSource = arrlist;
                cbxQuyen.DisplayMember = "Group";
            }
            else
            {
                this.Close();
            }
        }

        private void ThayDoiMKtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThayDoiMatKhau frm = new frmThayDoiMatKhau();
            frm.User = this.User;
            frm.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvwQuanLyNguoiDung_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (lvwQuanLyNguoiDung.SelectedItems.Count > 0)
            {               
                _user = (Users)lvwQuanLyNguoiDung.SelectedItems[0].Tag;
                txtTaiKhoan.Text = _user.UserName;
                txtHovaTen.Text = _user.FullName;
                for (int i = 0; i < arrlist.Count; i++)
                {
                    Users u = (Users) arrlist[i];
                    if (_user.Group.ToLower() == u.Group.ToLower())
                    {
                        cbxQuyen.SelectedItem = u;
                    }
                }
                
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {   
            _user.UserName = txtTaiKhoan.Text;
            _user.Password = "";
            Users selectedUser = (Users)cbxQuyen.SelectedItem;
            _user.Group = selectedUser.Group;
            _user.FullName = txtHovaTen.Text;
            GhiFile(_user);
        }

        public void GhiFile(Users user)
        {
            FileStream theFile = File.Open("../../users/" + user.UserName + ".txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(theFile);
            writer.WriteLine(user.UserName);
            writer.WriteLine(user.Password);
            writer.WriteLine(user.FullName);
            writer.WriteLine(user.Group);          

            writer.Close();
            theFile.Close();
        }

        private void cbxQuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            Users selecteduser = (Users) cbxQuyen.SelectedItem;
            _user.Group = selecteduser.Group;
        }
    }
}