using System;
using System.Collections.Generic;
using System.Text;
using QuanLyHocSinhPTNK.Services;
using QuanLyHocSinhPTNK.Entities;
using System.Collections;
using System.Data;

namespace BUSLayer
{
    public class LopHocBUS
    {
        public TList<LopHoc> LayBang()
        {
            LopHocService lhService = new LopHocService();
            TList<LopHoc> ds = new TList<LopHoc>();
            ds = lhService.GetAll();
            return ds;
        }
       
        public TList<LopHoc> LayBangTheoMaKhoi(string makhoi)
        {
            LopHocService lhService = new LopHocService();
            TList<LopHoc> ds = new TList<LopHoc>();
            ds = lhService.GetByMaKhoi(makhoi);
            return ds;
        }

        public ArrayList LayTenLop(string mamon, string mahk)
        {
            HocSinhBUS hsBUS = new HocSinhBUS();
            ArrayList dsMaLop = hsBUS.LayMaLop(mamon,mahk);
            ArrayList dsTenLop = new ArrayList();
            LopHocService lhService = new LopHocService();
            for (int i = 0; i < dsMaLop.Count; i++)
            {
                LopHoc lh = new LopHoc();
                lh = lhService.GetByMaLop((string)dsMaLop[i]);
                dsTenLop.Add(lh.TenLop);
            }
            return dsTenLop;
        }

        public ArrayList LaySiSo(string mamon, string mahk)
        {
            HocSinhBUS hsBUS = new HocSinhBUS();
            ArrayList dsMaLop = hsBUS.LayMaLop(mamon, mahk);
            ArrayList dsSiSo = new ArrayList();            
            int siso;
            for (int i = 0; i < dsMaLop.Count; i++)
            {              
                LopHoc lh = new LopHoc();
                HocSinhBUS hs = new HocSinhBUS();
                TList<HocSinh> dsHS = new TList<HocSinh>();
                dsHS = hs.LayBangTheoMaLop((string)dsMaLop[i]);
                siso = dsHS.Count;
                dsSiSo.Add(siso);
            }
            return dsSiSo;
        }

        public ArrayList LaySoLuongDat(string mamon, string mahk)
        {
            HocSinhBUS hsBUS = new HocSinhBUS();           
            ArrayList dsMaLop = hsBUS.LayMaLopCuaHocSinhCoDiemDat(mamon, mahk);
            ArrayList dsSiSo = new ArrayList();
            int siso;
            for (int i = 0; i < dsMaLop.Count; i++)
            {
                LopHoc lh = new LopHoc();
                HocSinhBUS hs = new HocSinhBUS();
                TList<HocSinh> dsHS = new TList<HocSinh>();
                dsHS = hs.LayBangTheoMaLop((string)dsMaLop[i]);
                siso = dsHS.Count;
                dsSiSo.Add(siso);
            }
            return dsSiSo;
        }

        public ArrayList LayDSLopHoc(string maKH)
        {
            ArrayList dsLH = new ArrayList();
            DataSet ds = new DataSet();
            LopHocService lhService = new LopHocService();
            ds = lhService.LayDSLopHoc(maKH);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dsLH.Add(dt.Rows[i][0]);
            }
            return dsLH;
        }

        public ArrayList LayDSLopHoc(string mamon, string maKH)
        {
            ArrayList dsLH = new ArrayList();
            DataSet ds = new DataSet();
            LopHocService lhService = new LopHocService();
            ds = lhService.LayDSLopHoc(mamon,maKH);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dsLH.Add(dt.Rows[i][0]);
            }
            return dsLH;
        }

        public int DSSoLuongHS(string tenlop)
        {
            DataSet ds = new DataSet();
            LopHocService lhService = new LopHocService();
            ds = lhService.LaySoLuongHSTrongLop(tenlop);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            int siso = (int)dt.Rows[0][0];
            return siso;
        }

        public string LayMaLopHocLonNhat(string makhoi)
        {
            int solonnhat = 0;
            TList<LopHoc> ds = new TList<LopHoc>();
            ds = LayBangTheoMaKhoi(makhoi);
            for (int i = 0; i < ds.Count; i++)
            {
                string chuoi = ds[i].MaLop;
                string[] arr1 = chuoi.Split(' ');
                string arr = arr1[0].Substring(3);
                int SoTT = Convert.ToInt32(arr);
                solonnhat = SoTT;
                for (int j = 0; j < ds.Count; j++)
                {
                    string chuoi1 = ds[j].MaLop;
                    string[] arr2 = chuoi1.Split(' ');
                    string arr3 = arr2[0].Substring(3);
                    int SoTT1 = Convert.ToInt32(arr3);
                    if (SoTT < SoTT1)
                    {
                        solonnhat = SoTT1;
                    }
                }
            }
            solonnhat = solonnhat + 1;
            string malop = "";
            if (solonnhat < 10)
                malop = makhoi.Split('K')[1].Split(' ')[0] + "A" + solonnhat.ToString() + "      ";
            else if (solonnhat < 100)
                malop = makhoi.Split('K')[1].Split(' ')[0] + "A" + solonnhat.ToString() + "     ";
            else if (solonnhat < 1000)
                malop = makhoi.Split('K')[1].Split(' ')[0] + "A" + solonnhat.ToString() + "    ";
            return malop;
        }

        public bool ThemLop(LopHoc lh)
        {
            LopHocService lhService = new LopHocService();
            bool kq = lhService.Insert(lh);
            return kq;
        }

        public LopHoc LayLopHocTheoMaLop(string malop)
        {
            LopHocService lhService = new LopHocService();
            return lhService.GetByMaLop(malop);
        }

        public bool Xoa(LopHoc lh)
        {
            LopHocService lhService = new LopHocService();
            return lhService.Delete(lh);
        }
    }
}
