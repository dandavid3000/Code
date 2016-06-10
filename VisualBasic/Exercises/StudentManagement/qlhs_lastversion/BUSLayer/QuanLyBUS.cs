using System;
using System.Collections.Generic;
using System.Text;
using QuanLyHocSinhPTNK.Entities;
using QuanLyHocSinhPTNK.Services;
using System.Data;

namespace BUSLayer
{
    public class QuanLyBUS
    {
        public bool KTTaiKhoan(string maql, string password)
        {
            bool kq = false;
            QuanLy ql = new QuanLy();
            QuanLyService qlService = new QuanLyService();
            ql = qlService.GetByMaQuanLy(maql);
            if (ql != null)          
                if ((ql.MaQuanLy != null) && (ql.Password == password))
                    kq = true;           
            return kq;
        }

        public QuanLy LayQuanLy(string maql)
        {
            QuanLy ql = new QuanLy();
            QuanLyService qlService = new QuanLyService();
            ql = qlService.GetByMaQuanLy(maql);
            return ql;
        }

        public void CapNhat(QuanLy ql)
        {
            QuanLyService qlService = new QuanLyService();
            qlService.Update(ql);
        }

        public TList<QuanLy> LayBang()
        {
            QuanLyService qlService = new QuanLyService();
            return qlService.GetAll();
        }

        public string LayMaQuanLyLonNhat()
        {
            int solonnhat = 0;
            TList<QuanLy> ds = new TList<QuanLy>();
            ds = LayBang();
            for (int i = 0; i < ds.Count; i++)
            {
                string chuoi = ds[i].MaQuanLy;                
                string arr = chuoi.Substring(2);
                int SoTT = Convert.ToInt32(arr);
                solonnhat = SoTT;
                for (int j = 0; j < ds.Count; j++)
                {
                    string chuoi1 = ds[j].MaQuanLy;                  
                    string arr3 = chuoi1.Substring(2);
                    int SoTT1 = Convert.ToInt32(arr3);
                    if (SoTT < SoTT1)
                    {
                        solonnhat = SoTT1;
                    }
                }
            }
            solonnhat = solonnhat + 1;
            string maquanly = "";
            if (solonnhat < 10)
                maquanly = "QL" + "00" + solonnhat.ToString() + "     ";
            else if (solonnhat < 100)
                maquanly = "QL" + "0" + solonnhat.ToString() + "     ";
            else if (solonnhat < 1000)
                maquanly = "QL" + solonnhat.ToString() + "     ";
            return maquanly;
        }

        public bool Them(QuanLy ql)
        {
            QuanLyService qlService = new QuanLyService();
            return qlService.Insert(ql);
        }

        public TList<QuanLy> LayDSQLTheoMaPhongBan(string mapb)
        {
            QuanLyService qlService = new QuanLyService();
            return qlService.GetByMaPhongBan(mapb);
        }

        public bool Xoa(QuanLy ql)
        {
            QuanLyService qlService = new QuanLyService();
            return qlService.Delete(ql);
        }

        public DataTable LayQuanLyXoa(string machucdanh, string maphongban)
        {
            QuanLyService qlService = new QuanLyService();
            DataSet ds = qlService.LayQuanLyXoa(machucdanh, maphongban);
            DataTable dt = ds.Tables[0];
            return dt;
        }
    }
}
