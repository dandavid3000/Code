using System;
using System.Collections;
using System.Text;
using System.Xml;

namespace MyClassLibrary
{
    public class DanhSachCacSach
    {
        private ArrayList _danhSachSach = new ArrayList();

        public ArrayList DanhSachSach
        {
            get { return _danhSachSach; }
            set { _danhSachSach = value; }
        }
        public Sach LaySach(int index)
        {
            Sach S = (Sach)_danhSachSach[index];
            return S;
        }
        public bool ThemSach(Sach S)
        {
            foreach (Sach sa in _danhSachSach)
            {
                if (sa.MaSach == S.MaSach) return false;
            }

            _danhSachSach.Add(S);
            return true;
        }

        public void DocDanhSachSach(string filePath)
        {
            // B1 : tao xml document, load noi dung tu tap tin xml
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            // B2 : tao the goc root
            XmlElement root = doc.DocumentElement;

            //Xoa het danh sach cau hoi hien co trong _danhSachCauHoi
            _danhSachSach.Clear();

            // B3 : lay gia tri trong cac attribute cua root
            foreach (XmlElement nodeSach in root.SelectNodes("Sach"))
            {
               
                Sach S = new Sach();

                XmlElement maSach = (XmlElement)nodeSach.SelectSingleNode("MaSach");
                S.MaSach= Convert.ToString(nodeSach.InnerText);

                XmlElement tenSach = (XmlElement)nodeSach.SelectSingleNode("TenSach");
                S.TenSach = Convert.ToString(nodeSach.InnerText);

                XmlElement nguon = (XmlElement)nodeSach.SelectSingleNode("Nguon");
                S.Nguon = Convert.ToString(nodeSach.InnerText);

                XmlElement tacGia = (XmlElement)nodeSach.SelectSingleNode("TacGia");
                S.TacGia = Convert.ToString(nodeSach.InnerText);

                this.DanhSachSach.Add(S);
            }

        }

        public void GhiDanhSachSach(string filePath)
        {
            // B1 : tao xml document
            XmlDocument doc = new XmlDocument();

            // B2 : tao the goc root, add root vao doc
            XmlElement root = doc.CreateElement("Sach");
            doc.AppendChild(root);
          

            foreach (Sach S in _danhSachSach)
            {
                XmlElement nodeCauHoi = doc.CreateElement("Sach");
                root.AppendChild(nodeCauHoi);

              
                XmlElement maSach = doc.CreateElement("MaSach");
                maSach.InnerText = S.MaSach;

                XmlElement tenSach = doc.CreateElement("TenSach");
                tenSach.InnerText= S.TenSach;

                XmlElement nguon = doc.CreateElement("Nguon");
                nguon.InnerText = S.Nguon;

                XmlElement tacGia = doc.CreateElement("TacGia");
                tacGia.InnerText = S.TacGia;
            }
            doc.Save(filePath);
        }
     
    }
}
