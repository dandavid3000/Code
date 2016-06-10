using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using _6k3021;
using System.Xml;


namespace _6k3021
{
    public partial class frmTaoDeThi : Form
    {
        public frmTaoDeThi()
        {
            InitializeComponent();
            lvwNoiDungCauHoi.Columns.Add("STT");
            lvwNoiDungCauHoi.Columns.Add("Nội dung câu hỏi");
            lvwNoiDungCauHoi.Columns[1].Width = 400;
        }

        private const string fileXML = "DeThi.xml";
        CDeThi deThi = new CDeThi();
        int ViTri = -1;



        private void LoadlwvNoiDungCauHoi(List<CCauTracNghiem> DanhSachCauHoi)
        {
            int STT = 0;
            //Xoa noi dung cua lvw noi dung cau hoi
            lvwNoiDungCauHoi.Items.Clear();

            foreach (CCauTracNghiem CauTracNghiem in DanhSachCauHoi)
            {
                string[] NDCH = new string[2];
                STT++;
                NDCH[0] = STT.ToString();
                NDCH[1] = CauTracNghiem.NoiDungCauHoi.ToString();
                ListViewItem lvi = new ListViewItem(NDCH);

                lvi.Tag = CauTracNghiem;
                lvwNoiDungCauHoi.Items.Add(lvi);
            }
        }
        
        private void lvwNoiDungCauHoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            CCauTracNghiem CauTracNghiem = (CCauTracNghiem)lvwNoiDungCauHoi.FocusedItem.Tag;

            ucCauHoiTracNghiem1.CauHoi = CauTracNghiem.NoiDungCauHoi;
            ucCauHoiTracNghiem1.DapAnA = CauTracNghiem.DapAnA;
            ucCauHoiTracNghiem1.DapAnB = CauTracNghiem.DapAnB;
            ucCauHoiTracNghiem1.DapAnC = CauTracNghiem.DapAnC;
            ucCauHoiTracNghiem1.DapAnD = CauTracNghiem.DapAnD;
            ucCauHoiTracNghiem1.DapAnDuocChon = CauTracNghiem.DapAnDung;

           ViTri = lvwNoiDungCauHoi.FocusedItem.Index;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            CCauTracNghiem CauTracNghiem = new CCauTracNghiem();

            CauTracNghiem.NoiDungCauHoi = ucCauHoiTracNghiem1.CauHoi;
            CauTracNghiem.DapAnA = ucCauHoiTracNghiem1.DapAnA;
            CauTracNghiem.DapAnB = ucCauHoiTracNghiem1.DapAnB;
            CauTracNghiem.DapAnC = ucCauHoiTracNghiem1.DapAnC;
            CauTracNghiem.DapAnD = ucCauHoiTracNghiem1.DapAnD;
            CauTracNghiem.DapAnDung = ucCauHoiTracNghiem1.DapAnDuocChon;

            deThi.DanhSachCauHoi.Add(CauTracNghiem);
            LoadlwvNoiDungCauHoi(deThi.DanhSachCauHoi);

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            CCauTracNghiem CauTracNghiem = (CCauTracNghiem)lvwNoiDungCauHoi.FocusedItem.Tag;
            while (deThi.DanhSachCauHoi.Count > 0)
            {
                deThi.DanhSachCauHoi.Remove(CauTracNghiem);
                lvwNoiDungCauHoi.FocusedItem.Remove();
                LoadlwvNoiDungCauHoi(deThi.DanhSachCauHoi);
            }
          
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            CCauTracNghiem CauTracNghiem = new CCauTracNghiem();

            CauTracNghiem.NoiDungCauHoi = ucCauHoiTracNghiem1.CauHoi;
            CauTracNghiem.DapAnA = ucCauHoiTracNghiem1.DapAnA;
            CauTracNghiem.DapAnB = ucCauHoiTracNghiem1.DapAnB;
            CauTracNghiem.DapAnC = ucCauHoiTracNghiem1.DapAnC;
            CauTracNghiem.DapAnD = ucCauHoiTracNghiem1.DapAnD;
            CauTracNghiem.DapAnDung = ucCauHoiTracNghiem1.DapAnDuocChon;
            deThi.DanhSachCauHoi[ViTri] = CauTracNghiem;
            LoadlwvNoiDungCauHoi(deThi.DanhSachCauHoi);
        }

        private void btnDoc_Click(object sender, EventArgs e)
        {
            deThi.DocFileXML(fileXML);
            //Doc xong thi xoa het cau hoi va load len lai
            lvwNoiDungCauHoi.Items.Clear();
            LoadlwvNoiDungCauHoi(deThi.DanhSachCauHoi);
         }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            deThi.GhiFileXML(fileXML);
            LoadlwvNoiDungCauHoi(deThi.DanhSachCauHoi);
        }

    }
}