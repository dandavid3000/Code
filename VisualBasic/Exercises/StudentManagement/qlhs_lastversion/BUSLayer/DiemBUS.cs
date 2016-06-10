using System;
using System.Collections.Generic;
using System.Text;
using QuanLyHocSinhPTNK.Services;
using QuanLyHocSinhPTNK.Entities;
using System.Data;

namespace BUSLayer
{
    public class DiemBUS
    {
        public TList<Diem> LayBang()
        {
            TList<Diem> ds = new TList<Diem>();
            DiemService dSrevice = new DiemService();
            ds = dSrevice.GetAll();
            return ds;
        }

        public string LayMaDiemLonNhat()
        {
            int solonnhat = 0;
            TList<Diem> ds = new TList<Diem>();
            ds = LayBang();
            for (int i = 0; i < ds.Count; i++)
            {
                string chuoi = ds[i].MaDiem;
                string[] arr = chuoi.Split('D');
                int SoTT = Convert.ToInt32(arr[1]);
                solonnhat = SoTT;
                for (int j = 0; j < ds.Count; j++)
                {
                    string chuoi1 = ds[j].MaDiem;
                    string[] arr1 = chuoi1.Split('D');
                    int SoTT1 = Convert.ToInt32(arr1[1]);
                    if (SoTT < SoTT1)
                    {
                        solonnhat = SoTT1;
                    }
                }   
            }
            solonnhat = solonnhat + 1;
            string MaBD = "";
            if(solonnhat < 10)
                MaBD = "D00" + solonnhat.ToString() + "      ";
            else if(solonnhat < 100)
                MaBD = "D0" + solonnhat.ToString() + "      ";
            else if (solonnhat < 1000)
                MaBD = "D" + solonnhat.ToString() + "      ";
            return MaBD;
        }

        public double TinhDTB(double phut, double Tiet, double CuoiKy)
        {
            double dtbMon = ((Tiet * 2) + phut) / 3;
            double DTB = (dtbMon * 2 + CuoiKy) / 3;
            return DTB;
        }

        public void Them(Diem d)
        {
            DiemService dService = new DiemService();
            dService.Insert(d);
        }

        public bool Xoa(Diem d)
        {
            DiemService dService = new DiemService();
            return dService.Delete(d);
        }

        public DataSet LayMaBD(string mamon, string maHK)
        {
            DataSet dsD = new DataSet();
            DiemService dService = new DiemService();
            dsD = dService.LayMaBangDiem(mamon, maHK);
            return dsD;
        }

        public TList<Diem> LayDiemTheoMaBangDiem(string mabangdiem)
        {
            DiemService dService = new DiemService();
            return dService.GetByMaBangDiem(mabangdiem);
        }
    }
}
