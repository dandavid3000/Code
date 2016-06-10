using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLDL.DTO;
using QLDL.DAO;


namespace QLDL.BUS
{
   public static class ChiTietPhieuXuatBUS
    {
       public static void InsertChiTietPhieuXuat(ChiTietPhieuXuatDTO dl)
       {
           ChiTietPhieuXuatDAO.InsertChiTietPhieuXuat(dl);
       }
       public static System.Data.DataTable SelectAllChiTietPhieuXuatByMaPhieuXuat(int ma)
       {
           System.Data.DataTable dttb = ChiTietPhieuXuatDAO.SelectAllChiTietPhieuXuatByMaPhieuXuat(ma);
           return dttb;
       }
      
    }
}
