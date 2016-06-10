using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using QLDL.DTO;
using System.Data;

namespace QLDL.DAO
{
   public static class ChiTietPhieuXuatDAO
    {
       public static bool InsertChiTietPhieuXuat(ChiTietPhieuXuatDTO dl)
       {
           bool result = false;
           try
           {
               // Create List Sql Parameter
               List<OleDbParameter> oleParams = new List<OleDbParameter>();
               oleParams.Add(new OleDbParameter("@PhieuXuat", dl.Maphieuxuat));
               oleParams.Add(new OleDbParameter("@MaMatHang", dl.Mamathang));
               oleParams.Add(new OleDbParameter("@MaDonViTinh", dl.Madonvitinh));
               oleParams.Add(new OleDbParameter("@DonGiaXuat", dl.Dongiaxuat));
               oleParams.Add(new OleDbParameter("@SoLuongXuat", dl.Soluongxuat));
               oleParams.Add(new OleDbParameter("@ThanhTien", dl.Thanhtien));
               // Call Store Procedure
               int n = OleDbDataAccessHelper.ExecuteNoneQuery("insert into ChiTietPhieuXuat(MaPhieuXuat, MaMatHang, MaDonViTinh, DonGiaXuat, SoLuongXuat, ThanhTien) values(?,?,?,?,?,?)", oleParams);
               if (n == 1)
                   result = true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
           return result;
       }
       public static DataTable SelectAllChiTietPhieuXuatByMaPhieuXuat( int ma)
       {

           string query = "Select * from ChiTietPhieuXuat ct where ct.MaPhieuXuat =" + ma ;
           DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
           return dt;
       }

    }
}
