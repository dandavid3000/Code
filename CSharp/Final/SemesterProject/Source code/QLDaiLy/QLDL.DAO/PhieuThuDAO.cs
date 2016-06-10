using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using QLDL.DTO;
using System.Data;

namespace QLDL.DAO
{
   public  static class PhieuThuDAO
    {
       public static bool InsertPhieuThu(PhieuThuTienDTO dl)
       {
           bool result = false;
           try
           {
               // Create List Sql Parameter
               List<OleDbParameter> oleParams = new List<OleDbParameter>();
               oleParams.Add(new OleDbParameter("@MaDaiLy", dl.Madaily));
               oleParams.Add(new OleDbParameter("@NgayThuTien", dl.Ngaythutien.ToString("yyyy-MM-dd")));
               oleParams.Add(new OleDbParameter("@SoTien", dl.Sotien));
               // Call Store Procedure
               int n = OleDbDataAccessHelper.ExecuteNoneQuery("insert into PhieuThuTien (MaDaiLy,NgayThuTien, SoTien) values(?,?,?)", oleParams);
               if (n == 1)
                   result = true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
           return result;
       }
       public static DataTable TongGiaTriPTTrongThang(int thang, int nam)
       {

           string query = "Select dl.MaDaiLy, sum(pt.Sotien) from PhieuThuTien pt, DaiLy dl where month(pt.NgayThuTien)=" + thang +
                          " and year(pt.NgayThuTien) = " + nam + " and pt.MaDaiLy = dl.MaDaiLy Group by dl.MaDaiLy";
           DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);

           return dt;
       }
    }
}
