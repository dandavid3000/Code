using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Collections;
using MyClassLibrary;

namespace _6k3021
{
    public partial class Form1 : Form
    {
        private DanhSachCacSach dss = new DanhSachCacSach();
        public Form1()
        {
            InitializeComponent();
        }
       
        private const string fileXML = "nhanvien.xml";

        
        
        private void Form1_Load(object sender, EventArgs e)
        {
            rdbTrongNuoc.Checked = true;
            lvwDanhSach.Columns.Add("STT", 50);
            lvwDanhSach.Columns.Add("Ma Sach", 150);
            lvwDanhSach.Columns.Add("Ten Sach", 200);
            lvwDanhSach.View = View.Details;

            lvwDanhSach.Items.Clear();
            dss.DocDanhSachSach("nhanvien.xml");
            DocFile();
                    
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Sach S = new Sach();

           
            S.MaSach = txtMaSach.Text;
            S.TacGia = txtTacGia.Text;
            S.TenSach = txtTenSach.Text;

            if(rdbTrongNuoc.Checked==true)
                S.Nguon="TrongNuoc";
            else S.Nguon="NgoaiNuoc";
            
            dss.DanhSachSach.Add(S);
            dss.DocDanhSachSach("nhanvien.xml");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
          
            
        }

        public void DocFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Application.ExecutablePath;
            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //_danhMucSach.DanhSach.Clear();
                    //listView1.Items.Clear();
                    //dss.DocXML(dialog.FileName);



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


    }
}