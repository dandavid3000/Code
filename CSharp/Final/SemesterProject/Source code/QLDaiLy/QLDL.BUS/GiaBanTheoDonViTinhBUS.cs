using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLDL.DTO;
using QLDL.DAO;


namespace QLDL.BUS
{
   public static class GiaBanTheoDonViTinhBUS
    {
       public static System.Data.DataTable SelectAllGiaBan()
       {
           System.Data.DataTable dt = GiaBanTheoDVT.SelectAllGiaBan();
           return dt;
       }
        public static void InsertGiaBan(GiaBanTheoDonViTinhDTO dl)
        {
            
            GiaBanTheoDVT.InsertGiaBan(dl);
        }
        public static void DeleteGiaBan(int madaily)
        {
            GiaBanTheoDVT.DeleteGiaBan(madaily);
        }
        public static void updateGiaBan(GiaBanTheoDonViTinhDTO dl)
        {
            GiaBanTheoDVT.UpdateGiaBan(dl);
        }

       public static int SoLuongTheoDVT(int dv, int mh)
       {
           int sl = GiaBanTheoDVT.SoLuongTheoDVT(dv, mh);
           return sl;
       }
       public static int MaGiaBanTheo_MaDVT_maMH(int dv, int mh)
       {
           int ma = GiaBanTheoDVT.MaGiaBanTheo_maDVT_maMH_(dv, mh);
           return ma;
       }
    }
}
