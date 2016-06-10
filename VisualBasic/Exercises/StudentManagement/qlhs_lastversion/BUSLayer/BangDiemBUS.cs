using System;
using System.Collections.Generic;
using System.Text;
using QuanLyHocSinhPTNK.Services;
using QuanLyHocSinhPTNK.Entities;
using System.Data;
using System.Collections;

namespace BUSLayer
{
    public class BangDiemBUS
    {
        public void Them(BangDiem bangdiem)
        {
            BangDiemService bdService = new BangDiemService();           
            bdService.Insert(bangdiem);
        }

        public void CapNhat(BangDiem bangdiem)
        {
            BangDiemService bdService = new BangDiemService();
            bdService.Update(bangdiem);
        }

        public TList<BangDiem> LayBang()
        {
            TList<BangDiem> ds = new TList<BangDiem>();
            BangDiemService bdService = new BangDiemService();
            ds = bdService.GetAll();
            return ds;
        }

        public string LayMaLonNhat()
        {
            int solonnhat = 0;
            TList<BangDiem> ds = new TList<BangDiem>();
            ds = LayBang();
            for (int i = 0; i < ds.Count; i++)
            {
                string chuoi = ds[i].MaBangDiem;
                string[] arr = chuoi.Split('D');
                int SoTT = Convert.ToInt32(arr[1]);
                solonnhat = SoTT;
                for (int j = 0; j < ds.Count; j++)
                {
                    string chuoi1 = ds[j].MaBangDiem;
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
            if (solonnhat < 10)
                MaBD = "BD00" + solonnhat.ToString() + "     ";
            else if (solonnhat < 100)
                MaBD = "BD0" + solonnhat.ToString() + "     ";
            else if (solonnhat < 1000)
                MaBD = "BD" + solonnhat.ToString() + "     ";
            return MaBD;
        }

        public double TinhDTB(double toan, double ly, double hoa, double sinh, double su, double dia, double van, double daoduc, double theduc)
        {
            double dtb = 0;
            dtb = ((toan * 2) + (van * 2) + ly + hoa + sinh + su + dia + daoduc + theduc) / 11;
            return dtb;
        }

        public ArrayList LayMaHS(string mamon, string maHK)
        {
            BangDiemService BDService = new BangDiemService();            
            ArrayList ds = new ArrayList();
            DiemService dService = new DiemService();
            DataSet maBD = new DataSet();
            maBD = dService.LayMaBangDiem(mamon, maHK);
            DataTable dt = maBD.Tables[0];            
            for (int i = 0; i < dt.Rows.Count; i++)
            {                
                BangDiem bd = new BangDiem();
                bd = BDService.GetByMaBangDiem((string)dt.Rows[i][0]);
                ds.Add(bd.MaHocSinh);              
            }
            return ds;
        }

        public DataTable LayMaHSDat(string mamon, string maHK)
        {            
            BangDiemService bdService = new BangDiemService();
            DataSet maHSDat = new DataSet();
            maHSDat = bdService.LayMaHocSinhDat(mamon, maHK);
            DataTable dt = maHSDat.Tables[0];            
            return dt;           
        }

        public TList<BangDiem> LayBangDiemTheoMaHocSinh(string mahocsinh)
        {
            BangDiemService bdService = new BangDiemService();
            return bdService.GetByMaHocSinh(mahocsinh);
        }
       
        public bool Xoa(BangDiem bangdiem)
        {
            BangDiemService bdService = new BangDiemService();           
            return bdService.Delete(bangdiem);
        }
    }
}
