using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using QLDL.DTO;
using System.Data;

namespace QLDL.DAO
{
    public static class DaiLyDAO
    {
        public static bool Insertdaily(DaiLyDTO dl)
        {
            bool result = false;
            try
            {
                // Create List Sql Parameter
                List<OleDbParameter> oleParams = new List<OleDbParameter>();
                //oleParams.Add(new OleDbParameter("@MaLoaidaily", ldl.MaLoaidaily));
                oleParams.Add(new OleDbParameter("@Tendaily", dl.Tendaily));
                oleParams.Add(new OleDbParameter("@Maloaidaily", dl.Maloaidaily));
                oleParams.Add(new OleDbParameter("@Dienthoai", dl.Dienthoai));
                oleParams.Add(new OleDbParameter("@Diachi", dl.Diachi));
                oleParams.Add(new OleDbParameter("@Maquan", dl.Maquan));
                oleParams.Add(new OleDbParameter("@Ngaytiepnhan", dl.Ngaytiepnhan));
                oleParams.Add(new OleDbParameter("@Email", dl.Email));
               // oleParams.Add(new OleDbParameter("@Nocuadaily", dl.Nocuadaily));
                // Call Store Procedure
                int n = OleDbDataAccessHelper.ExecuteNoneQuery("insert into daily(TenDaiLy, MaLoaiDaiLy, DienThoai, DiaChi, MaQuan, NgayTiepNhan, Email,NoCuaDaiLy ) values(?,?,?,?,?,?,?,0 )", oleParams);
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
        public static bool Updatedaily(DaiLyDTO dl)
        {
           bool result = false;
            try
            {
                // Create List Sql Parameter
                List<OleDbParameter> oleParams = new List<OleDbParameter>();
                oleParams.Add(new OleDbParameter("@Tendaily", dl.Tendaily));
                oleParams.Add(new OleDbParameter("@Maloaidaily", dl.Maloaidaily));
                oleParams.Add(new OleDbParameter("@Dienthoai", dl.Dienthoai));
                oleParams.Add(new OleDbParameter("@Diachi", dl.Diachi));
                oleParams.Add(new OleDbParameter("@Maquan", dl.Maquan));
                oleParams.Add(new OleDbParameter("@Ngaytiepnhan", dl.Ngaytiepnhan.ToShortDateString()));
                oleParams.Add(new OleDbParameter("@Email", dl.Email));
                oleParams.Add(new OleDbParameter("@Nocuadaily", dl.Nocuadaily));
                oleParams.Add(new OleDbParameter("@Madaily", dl.Madaily));
                // Call Store Procedure
                int n = OleDbDataAccessHelper.ExecuteNoneQuery("Update daily set TenDaiLy = ?, MaLoaiDaiLy = ?, DienThoai = ?, DiaChi = ?, MaQuan = ?, NgayTiepNhan = ?, Email = ?, NoCuaDaiLy = ? where MaDaiLy = ?", oleParams);
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
        public static bool DeletedailyByMadaily(int Madaily)
        {
            bool result = false;
            try
            {
                // Create List Sql Parameter
                List<OleDbParameter> oleParams = new List<OleDbParameter>();
                oleParams.Add(new OleDbParameter("@Madaily", Madaily));
                // Call Store Procedure
                int n = OleDbDataAccessHelper.ExecuteNoneQuery("Delete from daily where Madaily = ?", oleParams);
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
        public static List<DaiLyDTO> SelectDaiLyByLoaiDaiLy(int loaidaily)
        {
            List<DaiLyDTO> list = new List<DaiLyDTO>();
            try
            {
                // Create List Sql Parameter
                List<OleDbParameter> oleParams = new List<OleDbParameter>();
                oleParams.Add(new OleDbParameter("@Maloaidaily", loaidaily));
                //truy van voi tat ca daily voi ten daily duoc hien thi
                string query = "select * from daily dl where dl.MaLoaiDaiLy = ?";
                DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query, oleParams);
                foreach (DataRow dr in dt.Rows)
                {
                    DaiLyDTO dl = new DaiLyDTO();
                    dl.Madaily = int.Parse(dr["Madaily"].ToString());
                    dl.Tendaily = dr["Tendaily"].ToString();
                    dl.Maloaidaily = int.Parse(dr["Maloaidaily"].ToString());
                    dl.Dienthoai = dr["Dienthoai"].ToString();
                    dl.Diachi= dr["Diachi"].ToString();
                    dl.Maquan = int.Parse(dr["Maquan"].ToString());
                    dl.Ngaytiepnhan = DateTime.Parse(dr["Ngaytiepnhan"].ToString());
                    dl.Email = dr["Email"].ToString();
                    dl.Nocuadaily = int.Parse(dr["Nocuadaily"].ToString());

                    list.Add(dl);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }

        public static List<DaiLyDTO> SelectdailyAllAsList()
        {
            List<DaiLyDTO> list = new List<DaiLyDTO>();
            try
            {
                DataTable dt = OleDbDataAccessHelper.ExecuteQuery("select * from daily");
                foreach (DataRow dr in dt.Rows)
                {
                    DaiLyDTO dl = new DaiLyDTO();
                    dl.Madaily = int.Parse(dr["Madaily"].ToString());
                    dl.Tendaily = dr["Tendaily"].ToString();
                    dl.Maloaidaily = int.Parse(dr["Maloaidaily"].ToString());
                    dl.Dienthoai = dr["Dienthoai"].ToString();
                    dl.Diachi = dr["Diachi"].ToString();
                    dl.Maquan = int.Parse(dr["Maquan"].ToString());
                    dl.Ngaytiepnhan = DateTime.Parse(dr["Ngaytiepnhan"].ToString());
                    dl.Email = dr["Email"].ToString();
                    dl.Nocuadaily  = int.Parse(dr["Nocuadaily"].ToString());
                    list.Add(dl);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }

        public static DataTable SelectdailyAllAsDataTable()
        {
            DataTable dt = new DataTable();
            try
            {
                //truy van voi tat ca daily voi ten daily duoc hien thi
                string query = "select dl.MaDaiLy, dl.TenDaiLy, dl.MaLoaiDaiLy, dl.DiemThoai, dl.DiaChi, dl.MaQuan, dl.NgayTiepNhan, dl.Email, dl.NoCuaDaiLy  from daily dl, Loaidaily ldl where dl.MaLoaidaily = ldl.MaLoaidaily";
                dt = OleDbDataAccessHelper.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public static DaiLyDTO SelectdailyByMadaily(int madaily)
        {
            DaiLyDTO dl = new DaiLyDTO();
            try
            {
                // Create List Sql Parameter
                List<OleDbParameter> oleParams = new List<OleDbParameter>();
                oleParams.Add(new OleDbParameter("@Madaily", madaily));
                string query = "select * from daily dl where dl.MaDaiLy = ?";
                DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query, oleParams);
                DataRow dr = dt.Rows[0];
                dl.Madaily = int.Parse(dr["Madaily"].ToString());
                dl.Tendaily = dr["Tendaily"].ToString();
                dl.Maloaidaily = int.Parse(dr["Maloaidaily"].ToString());
                dl.Dienthoai = dr["Dienthoai"].ToString();
                dl.Diachi = dr["Diachi"].ToString();
                dl.Maquan = int.Parse(dr["Maquan"].ToString());
                dl.Ngaytiepnhan = DateTime.Parse(dr["Ngaytiepnhan"].ToString());
                dl.Email = dr["Email"].ToString();
                dl.Nocuadaily = int.Parse(dr["Nocuadaily"].ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dl;
        }
        public static DataTable SelectAllDaiLy()
        {

            string query = "Select * from DaiLy";
            DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
            return dt;
        }

       

    }
}
