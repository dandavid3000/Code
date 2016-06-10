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
                oleParams.Add(new OleDbParameter("@Ngaytiepnhan", dl.Ngaytiepnhan));
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
        public static DataTable SelectAllCongNoDaiLy()
        {

            string query = "Select dl.TenDaiLy, dl.DiaChi, dl.DienThoai , dl.NoCuaDaiLy from DaiLy dl";
            DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
            return dt;
        }
        public static DataTable SelectDaiLy_TenLoaiDaiLy_TenQuan()
        {
            string query ="Select dl.MaDaiLy,dl.TenDaiLy,ldl.TenLoaiDaiLy,dl.DienThoai,dl.DiaChi,q.TenQuan, dl.NgayTiepNhan, dl.Email. dl.NoCuaDaiLy from DaiLy dl, LoaiDaiLy ldl, Quan q where ldl.MaLoaiDaiLy = dl.MaLoaiDaiLy and q.MaQuan ";
            DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
            return dt;
        }
        public static int SelectNoByMaDL(int ma)
        {
            int no = 0;
            //string query = "Select dl.NoCuaDaiLy from DaiLy dl where dl.maDaiLy =" + ma;
            //DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
            // no = Convert.ToInt32(dt.Rows[0][0]);
            return no;
        }
        public static int SelectNoByMaDaiLy_Moi(int ma)
        {
            int no = 0;
            string query = "Select dl.NoCuaDaiLy from DaiLy dl where dl.maDaiLy =" + ma;
            DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
            no = Convert.ToInt32(dt.Rows[0][0]);
            return no;
        }
        public static DataTable SelectTTDLByMa(int ma)
        {

            string query = "Select dl.DiaChi, dl.DienThoai, dl.Email, dl.NoCuaDaiLy from DaiLy dl where dl.MaDaiLy = "+ ma;
            DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
            return dt;
        }
        public static DataTable SelectAllMa_No_DaiLy()
        {

            string query = "Select dl.maDaiLy, dl.NoCuaDaiLy from DaiLy dl ";
            DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
            return dt;
        }
        public static DataTable SelectAllMa_No_DaiLy_Moi()
        {

            string query = "Select dl.maDaiLy, dl.TenDaiLy, dl.NoCuaDaiLy from DaiLy dl ";
            DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
            return dt;
        }
        public static DataTable SelectDemSoPhieuXuat(int thang, int nam)
        {

            string query = "Select dl.maDaiLy, dl.TenDaiLy, Count(pxh.MaPhieuXuat), Sum(pxh.TongGiaTri) from DaiLy dl, PhieuXuatHang pxh where month(pxh.NgayLapPhieu)=" + thang +
                          " and year(pxh.NgayLapPhieu) = " + nam + " and pxh.MaDaiLy = dl.MaDaiLy Group by dl.MaDaiLy, dl.TenDaiLy";
            DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
            return dt;
        }
        public static int LayLoaiDLByTenDL(string ten)
        {

            string query = "Select ldl.MaLoaiDaiLy from LoaiDaiLy ldl where ldl.TenloaiDaiLy = '" + ten + "'";
            DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
            return Convert.ToInt16(dt.Rows[0][0].ToString());
        }
        public static int LaymaLoaiDLByMaDL(int ma)
        {

            string query = "Select ldl.MaLoaiDaiLy from LoaiDaiLy ldl, DaiLy dl where ldl.MaLoaiDaiLy = dl.MaLoaiDaiLy and dl.MaDaiLy ="+ ma;
            DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
            return Convert.ToInt16(dt.Rows[0][0].ToString());
        }
        public static int LayMaQuanByTenDL(string ten)
        {

            string query = "Select q.MaQuan from Quan q where q.Tenquan = '" + ten + "'";
            DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
            return Convert.ToInt16(dt.Rows[0][0].ToString());
        }
        public static DataTable SelectDaiLyByMaQuan(int maquan)
        {

            string query = "Select * from DaiLy dl where dl.MaQuan = " + maquan;
            DataTable da = OleDbDataAccessHelper.ExecuteQuery(query);
            return da;
        }
        public static DataTable SelectTraCuu(string maDl, string tenDL, string malaoiDL, string dt, string dc, string quan, string ngaytiepnhan, string email, string no)
        {
           // string istruoc = " and ";
            if (maDl !="")
            {
                int madaily = Convert.ToInt16(maDl);
                maDl = "dl.MaDaily = " + madaily;
            }
            if (tenDL!="")
            {
                if (maDl != "")
                    tenDL = " and dl.tenDaily = '" + tenDL + "'";
                else
                    tenDL = " dl.tenDaily = '" + tenDL + "'";
                
            }
            // có tên  tìm loại
            if (malaoiDL !="")
            {

                int maloaiDL = LayLoaiDLByTenDL(malaoiDL);
               // int maloai = Convert.ToInt16(maloaiDL);
                if (maDl != "" || tenDL != "")
                    malaoiDL = " and dl.maLoaidaiLy = " + maloaiDL ;
                else
                {
                    malaoiDL = "dl.maLoaidaiLy = " + maloaiDL;
                }
            }
            if (dt !="")
            {
                if (maDl != "" || tenDL != "" || malaoiDL != "")
                    dt = " and dl.DienThoai = '" + dt + "'";
                else
                    dt = " dl.DienThoai = '" + dt + "'";
            }
            if (dc !="")
            {
                if (maDl != "" || tenDL != "" || malaoiDL != "" || dt != "")
                    dc = " and dl.DiaChi = '" + dc + "'";
                else
                {
                    dc = " dl.DiaChi = '" + dc + "'";
                }
            }
            if (quan !="")
            {
                int maquan = LayMaQuanByTenDL(quan);
                if (maDl != "" || tenDL != "" || malaoiDL != "" || dt != "" || dc != "")
                    quan = " and dl.MaQuan = " + maquan ;
                else
                {
                    quan = " dl.MaQuan = " + maquan;
                }
            }
            if (email !="")
            {
                if (maDl != "" || tenDL != "" || malaoiDL != "" || dt != "" || dc != "" || quan != "")
                    email = " and dl.Email = '" + email + "'";
                else
                {
                    email = " dl.Email = '" + email + "'";
                }
                
            }
            if (no !="")
            {
                int nodaily = Convert.ToInt32(no);
                if (maDl != "" || tenDL != "" || malaoiDL != "" || dt != "" || dc != "" || quan != "" || email != "")
                    no = " and dl.NoCuaDaiLy = " + nodaily ;
                else
                {
                    no = " dl.NoCuaDaiLy = " + nodaily ;
                }
            }

            // string madaily = "dl.MaDaiLy = "
            string query = "Select *  from DaiLy dl where " + maDl +  tenDL + malaoiDL +  dt +  dc  + quan + email +  no;
             DataTable da = OleDbDataAccessHelper.ExecuteQuery(query);
            return da;
        }

  
      }
}
