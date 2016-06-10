using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Collections;
using _6k3021;

namespace _6k3021
{
    class CDeThi
    {
        private List<CCauTracNghiem> _danhSachCauHoi = new List<CCauTracNghiem>();

        internal List<CCauTracNghiem> DanhSachCauHoi
        {
            get { return _danhSachCauHoi; }
            set { _danhSachCauHoi = value; }
        }

        //Ham doc file XML
        public void DocFileXML(string filePath)
        {
            // B1 : tao xml document, load noi dung tu tap tin xml
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            // B2 : tao the goc root
            XmlElement root = doc.DocumentElement;

            //Xoa het danh sach cau hoi hien co trong _danhSachCauHoi
            DanhSachCauHoi.Clear();

            // B3 : lay gia tri trong cac attribute cua root
            foreach (XmlElement nodeCauHoi in root.SelectNodes("CauHoi"))
            {
                CCauTracNghiem CauTracNghiem = new CCauTracNghiem();

                CauTracNghiem.NoiDungCauHoi = Convert.ToString(nodeCauHoi.GetAttribute("noiDung"));
                CauTracNghiem.DapAnDung = Convert.ToString(nodeCauHoi.GetAttribute("dapAnDung"));
                
                XmlElement DapAnA = (XmlElement)nodeCauHoi.SelectSingleNode("DapAnA");
                CauTracNghiem.DapAnB = Convert.ToString(nodeCauHoi.InnerText);

                XmlElement DapAnB = (XmlElement)nodeCauHoi.SelectSingleNode("DapAnB");
                CauTracNghiem.DapAnB = Convert.ToString(nodeCauHoi.InnerText);

                XmlElement DapAnC = (XmlElement)nodeCauHoi.SelectSingleNode("DapAnC");
                CauTracNghiem.DapAnC = Convert.ToString(nodeCauHoi.InnerText);

                XmlElement DapAnD = (XmlElement)nodeCauHoi.SelectSingleNode("DapAnD");
                CauTracNghiem.DapAnD = Convert.ToString(nodeCauHoi.InnerText);

                this.DanhSachCauHoi.Add(CauTracNghiem);
            }
        }

        //Ham ghi file XML
        public void GhiFileXML(string filePath)
        {
            // B1 : tao xml document
            XmlDocument doc = new XmlDocument();

            // B2 : tao the goc root, add root vao doc
            XmlElement root = doc.CreateElement("DeThi");
            doc.AppendChild(root);

            foreach (CCauTracNghiem CauTracNghiem in DanhSachCauHoi)
            {
                XmlElement nodeCauHoi = doc.CreateElement("CauHoi");
                root.AppendChild(nodeCauHoi);

                //Ghi noi dung
                nodeCauHoi.SetAttribute("noiDung", CauTracNghiem.NoiDungCauHoi);

                //Ghi dap an dung
                nodeCauHoi.SetAttribute("dapAnDung", CauTracNghiem.DapAnDung);

                //Dap an A B C D
                XmlElement nodeDapAnA = doc.CreateElement("DapAnA");
                nodeDapAnA.InnerText = CauTracNghiem.DapAnA;

                XmlElement nodeDapAnB = doc.CreateElement("DapAnB");
                nodeDapAnB.InnerText = CauTracNghiem.DapAnB;

                XmlElement nodeDapAnC = doc.CreateElement("DapAnC");
                nodeDapAnC.InnerText = CauTracNghiem.DapAnC;

                XmlElement nodeDapAnD = doc.CreateElement("DapAnD");
                nodeDapAnD.InnerText = CauTracNghiem.DapAnD;
            }

            doc.Save(filePath);
        }

    }
}
