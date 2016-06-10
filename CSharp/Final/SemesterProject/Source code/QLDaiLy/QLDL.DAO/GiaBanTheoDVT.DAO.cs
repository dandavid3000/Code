using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using QLDL.DTO;
using System.Data;
namespace QLDL.DAO
{
   public  static class GiaBanTheoDVT
    {
       public static bool InsertGiaBan(GiaBanTheoDonViTinhDTO dl)
       {
           bool result = false;
           try
           {
               // Create List Sql Parameter
               List<OleDbParameter> oleParams = new List<OleDbParameter>();
               oleParams.Add(new OleDbParameter("@MaDonViTinh", dl.Madonvitinh));
               oleParams.Add(new OleDbParameter("@MaMatHang", dl.Mamathang));
               oleParams.Add(new OleDbParameter("@SoLuongTheoDonViTinh", dl.SoluongtheoDvt));
               oleParams.Add(new OleDbParameter("@DonGiaBan", dl.Dongiaban));
               // Call Store Procedure
               int n = OleDbDataAccessHelper.ExecuteNoneQuery("insert into GiaBanTheoDonViTinh (MaDonViTinh,MaMatHang,SoLuongTheoDVT, DonGiaBan) values(?,?,?,?)", oleParams);
               if (n == 1)
                   result = true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
           return result;
       }
       public static DataTable SelectAllGiaBan()
       {

           string query = "Select * from GiaBanTheoDonViTinh";
           DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
           return dt;
       }
       public static int SoLuongTheoDVT(int dvt, int mh)
       {

           string query = "Select SoLuongTheoDVT from GiaBanTheoDonViTinh where MaDonViTinh = " + dvt +
                          " and MaMatHang = " + mh;
           DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
           return Convert.ToInt16(dt.Rows[0][0]);
       }
       public static int MaGiaBanTheo_maDVT_maMH_(int dvt, int mh)
       {

           string query = "Select maGiaBanTheoDVT from GiaBanTheoDonViTinh where MaDonViTinh = " + dvt +
                          " and MaMatHang = " + mh;
           DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
           int ma = 0;
           if (dt.Rows.Count != 0)
               ma = Convert.ToInt16(dt.Rows[0][0]);
           return ma;
       }
       public static bool UpdateGiaBan(GiaBanTheoDonViTinhDTO dl)
       {
           bool result = false;
           try
           {
               // Create List Sql Parameter
               List<OleDbParameter> oleParams = new List<OleDbParameter>();
               oleParams.Add(new OleDbParameter("@MaDonViTinh", dl.Madonvitinh));
               oleParams.Add(new OleDbParameter("@MaMatHang", dl.Mamathang));
               oleParams.Add(new OleDbParameter("@SoLuongTheoDonViTinh", dl.SoluongtheoDvt));
               oleParams.Add(new OleDbParameter("@DonGiaBan", dl.Dongiaban));
               oleParams.Add(new OleDbParameter("@MaGiaBanTheoDVT", dl.MagiabantheoDvt));
               // Call Store Procedure
               int n = OleDbDataAccessHelper.ExecuteNoneQuery("Update GiaBanTheoDonViTinh set MaDonViTinh = ?, MaMatHang = ?, SoLuongTheoDVT = ?, DonGiaBan = ? where MaGiaBanTheoDVT = ?", oleParams);
               if (n == 1)
                   result = true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
           return result;
       }
       public static bool DeleteGiaBan(int ma)
       {
           bool result = false;
           try
           {
               // Create List Sql Parameter
               List<OleDbParameter> oleParams = new List<OleDbParameter>();
               oleParams.Add(new OleDbParameter("@MaGiaBanTheoDVT",ma));
               // Call Store Procedure
               int n = OleDbDataAccessHelper.ExecuteNoneQuery("Delete from GiaBanTheoDonViTinh where MaGiaBanTheoDVT = ?", oleParams);
               if (n == 1)
                   result = true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
           return result;
       }
    }
}
