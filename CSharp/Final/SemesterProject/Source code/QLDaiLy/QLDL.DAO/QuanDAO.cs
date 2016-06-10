using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLDL.DTO;
using System.Data;
using System.Data.OleDb;

namespace QLDL.DAO
{
   public class QuanDAO
    {
       public static DataTable SelectAllQuan()
       {

           string query = "Select * from Quan";
           DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
           return dt;
       }
       public static int DemSoDaiLyMoiQuan(int ma)
       {

           string query = "Select Count(dl.MaDaiLy) from daily dl where dl.MaQuan = " + ma;
           DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
           return Convert.ToInt16(dt.Rows[0][0]);
       }
       public static int SelectMaQuanBytenQuan(string tenquan)
       {

           string query = "Select  ldl. maquan from Quan ldl where ldl.TenQuan =" + tenquan;
           DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
           int temp = Convert.ToInt16(dt.Rows[0][0]);
           return temp;
       }
       public static bool InsertQuan(QuanDTO quan)
       {
           bool result = false;
           try
           {
               // Create List Sql Parameter
               List<OleDbParameter> oleParams = new List<OleDbParameter>();
               //oleParams.Add(new OleDbParameter("@MaLoaiLoaiDaiLy", ldl.MaLoaiLoaiDaiLy));
               oleParams.Add(new OleDbParameter("@TenQuan", quan.Tenquan));
               // Call Store Procedure
               int n = OleDbDataAccessHelper.ExecuteNoneQuery("insert into Quan(TenQuan ) values(?)", oleParams);
               if (n == 1)
                   result = true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
           return result;
       }
       //Updating
       public static bool UpdateQuan(QuanDTO q)
       {
           bool result = false;
           try
           {
               // Create List Sql Parameter
               List<OleDbParameter> oleParams = new List<OleDbParameter>();
               oleParams.Add(new OleDbParameter("@TenQuan", q.Tenquan));
               oleParams.Add(new OleDbParameter("@MaQuan", q.Maquan));
               // Call Store Procedure
               int n = OleDbDataAccessHelper.ExecuteNoneQuery("Update Quan set TenQuan = ? where MaQuans = ?", oleParams);
               if (n == 1)
                   result = true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
           return result;
       }
       // Deleting
       public static bool DeleteQuanByMaQuan(int MaQuan)
       {
           bool result = false;
           try
           {
               // Create List Sql Parameter
               List<OleDbParameter> oleParams = new List<OleDbParameter>();
               oleParams.Add(new OleDbParameter("@MaQuan", MaQuan));
               // Call Store Procedure
               int n = OleDbDataAccessHelper.ExecuteNoneQuery("Delete from Quan where MaQuan = ?", oleParams);
               if (n == 1)
                   result = true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
           return result;
       }
       // Retrieving
       public static List<QuanDTO> SelectQuanByTenQuan(int quan)
       {
           List<QuanDTO> list = new List<QuanDTO>();
           try
           {
               // Create List Sql Parameter
               List<OleDbParameter> oleParams = new List<OleDbParameter>();
               oleParams.Add(new OleDbParameter("@MaQuan", quan));
               //truy van voi tat ca Quan voi TenQuan duoc hien thi
               string query = "select * from Quan quan where quan.MaQuan = ?";
               DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query, oleParams);
               foreach (DataRow dr in dt.Rows)
               {
                   QuanDTO q = new QuanDTO();
                   q.Maquan = int.Parse(dr["MaQuan"].ToString());
                   q.Tenquan = dr["TenQuan"].ToString();

                   list.Add(q);
               }

           }
           catch (Exception ex)
           {
               throw ex;
           }
           return list;
       }


       public static List<QuanDTO> SelectQuanAllAsList()
       {
           List<QuanDTO> list = new List<QuanDTO>();
           try
           {
               DataTable dt = OleDbDataAccessHelper.ExecuteQuery("select * from Quan");
               foreach (DataRow dr in dt.Rows)
               {
                   QuanDTO quan = new QuanDTO();
                   quan.Maquan = int.Parse(dr["MaQuan"].ToString());
                   quan.Tenquan = dr["TenQuan"].ToString();

                   list.Add(quan);
               }
           }
           catch (Exception ex)
           {
               throw ex;
           }
           return list;
       }

       public static QuanDTO SelectQuanByMaQuan(int maquan)
       {
           QuanDTO quan = new QuanDTO();
           try
           {
               // Create List Sql Parameter
               List<OleDbParameter> oleParams = new List<OleDbParameter>();
               oleParams.Add(new OleDbParameter("@MaQuan", maquan));
               string query = "select * from Quan quan where quan.MaQuan = ?";
               DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query, oleParams);
               DataRow dr = dt.Rows[0];
               quan.Maquan = int.Parse(dr["MaQuan"].ToString());
               quan.Tenquan = dr["TenQuan"].ToString();
           }
           catch (Exception ex)
           {
               throw ex;
           }
           return quan;
       }

       public List<QuanDTO> DanhSachQuan()
       {
           string query = "Select * from Quan";
           DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
           List<QuanDTO> ds = new List<QuanDTO>();

           for (int i = 0; i < dt.Rows.Count; i++)
           {

               QuanDTO lb = new QuanDTO();

               lb.Maquan = Convert.ToInt32(dt.Rows[i]["MaQuan"].ToString());
               lb.Tenquan = dt.Rows[i]["TenQuan"].ToString();

               ds.Add(lb);
           }
           return ds;
       }
    }
}
