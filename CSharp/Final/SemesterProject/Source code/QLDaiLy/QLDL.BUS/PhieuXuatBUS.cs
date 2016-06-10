using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLDL.DTO;
using QLDL.DAO;

namespace QLDL.BUS
{
   public static class PhieuXuatBUS
    {
       public static void InsertPhieuXuat(PhieuXuatHangDTO dl)
       {
           PhieuXuatDAO.InsertPhieuXuatHang(dl);
       }
        public static System.Data.DataTable SelectAllPhieuXuat()
       {
           System.Data.DataTable dt = PhieuXuatDAO.SelectAllphieuXuat();
           return dt;
       }
        public static System.Data.DataTable tongGiaTriPXTrongThang(int thang, int nam)
        {
            System.Data.DataTable dt = PhieuXuatDAO.TongGiaTriPXTrongThang(thang, nam);
            return dt;
        }
        public static int  TongGiaTriPX_Moi(int thang, int nam)
        {
            int dt = PhieuXuatDAO.TongGiaTriPX_Moi(thang, nam);
            return dt;
        }
    }
}
