using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using QLDL.DTO;
using System.Data;

namespace QLDL.DAO
{
   public static class PhieuXuatDAO
    {
        public static bool InsertPhieuXuatHang(PhieuXuatHangDTO dl)
        {
            bool result = false;
            try
            {
                // Create List Sql Parameter
                List<OleDbParameter> oleParams = new List<OleDbParameter>();
                oleParams.Add(new OleDbParameter("@MaDaiLy", dl.Madaily));
                oleParams.Add(new OleDbParameter("@NgayLapPhieu", dl.Ngaylapphieu.ToString("yyyy-MM-dd")));
                oleParams.Add(new OleDbParameter("@TongGiaTri", dl.Tonggiatri));
                // Call Store Procedure
                int n = OleDbDataAccessHelper.ExecuteNoneQuery("insert into PhieuXuatHang(MaDaiLy,NgayLapPhieu, TongGiaTri) values(?,?,?)", oleParams);
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
        public static bool UpdatePhieuXuatHang(PhieuXuatHangDTO dl)
        {
            bool result = false;
            try
            {
                // Create List Sql Parameter
                List<OleDbParameter> oleParams = new List<OleDbParameter>();
                oleParams.Add(new OleDbParameter("@MaDaiLy", dl.Madaily));
                oleParams.Add(new OleDbParameter("@NgayLapPhieu", dl.Ngaylapphieu));
                oleParams.Add(new OleDbParameter("@TongGiaTri", dl.Tonggiatri));
                oleParams.Add(new OleDbParameter("@MaPhieuXuat", dl.Tonggiatri));
                // Call Store Procedure
                int n = OleDbDataAccessHelper.ExecuteNoneQuery("Update PhieuXuatHang set MaDaiLy = ?, DienThoai = ?, DiaChi = ?, MaQuan = ?, NgayTiepNhan = ?, Email = ?, NoCuaPhieuXuatHang = ? where MaPhieuXuatHang = ?", oleParams);
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
        public static bool DeletePhieuXuatHangByMaPhieuXuatHang(int MaPhieuXuatHang)
        {
            bool result = false;
            try
            {
                // Create List Sql Parameter
                List<OleDbParameter> oleParams = new List<OleDbParameter>();
                oleParams.Add(new OleDbParameter("@MaPhieuXuatHang", MaPhieuXuatHang));
                // Call Store Procedure
                int n = OleDbDataAccessHelper.ExecuteNoneQuery("Delete from PhieuXuatHang where MaPhieuXuatHang = ?", oleParams);
                if (n == 1)
                    result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public static DataTable SelectAllphieuXuat()
        {

            string query = "Select * from PhieuXuatHang";
            DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
            return dt;
        }
        public static DataTable TongGiaTriPXTrongThang(int thang, int nam)
        {

            string query = "Select dl.MaDaiLy, sum(px.TongGiaTri) from PhieuXuatHang px, DaiLy dl where month(px.NgayLapPhieu)=" + thang +
                           " and year(px.NgayLapPhieu) = " + nam + " and px.MaDaiLy = dl.MaDaiLy Group by dl.MaDaiLy";
            DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);

            return dt;
        }
        public static int TongGiaTriPX_Moi(int thang, int nam)
        {

            string query = "Select  sum(px.TongGiaTri) from PhieuXuatHang px where month(px.NgayLapPhieu)=" + thang +
                           " and year(px.NgayLapPhieu) = " + nam ;
            DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
            int gt = Convert.ToInt32(dt.Rows[0][0]);
            return gt;
        }


        //public static DataTable TongGiaTriPXTrongThang(int thang, int nam)
        //{

        //    string query = "Select dl.MaDaiLy, sum(px.TongGiaTri), dl.NoCuaDaiLy from PhieuXuatHang px, DaiLy dl where month(px.NgayLapPhieu)=" + thang +
        //                   " and year(px.NgayLapPhieu) = " + nam + " and px.MaDaiLy = dl.MaDaiLy Group by dl.MaDaiLy";
        //    DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);

        //    return dt;
        //}
        



        // Retrieving
        //public static List<PhieuXuatHangDTO> SelectPhieuXuatHangByLoaiPhieuXuatHang(int loaiPhieuXuatHang)
        //{
        //    List<PhieuXuatHangDTO> list = new List<PhieuXuatHangDTO>();
        //    try
        //    {
        //        // Create List Sql Parameter
        //        List<OleDbParameter> oleParams = new List<OleDbParameter>();
        //        oleParams.Add(new OleDbParameter("@MaloaiPhieuXuatHang", loaiPhieuXuatHang));
        //        //truy van voi tat ca PhieuXuatHang voi ten PhieuXuatHang duoc hien thi
        //        string query = "select * from PhieuXuatHang dl where dl.MaLoaiPhieuXuatHang = ?";
        //        DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query, oleParams);
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            PhieuXuatHangDTO dl = new PhieuXuatHangDTO();
        //            dl.MaPhieuXuatHang = int.Parse(dr["MaPhieuXuatHang"].ToString());
        //            dl.TenPhieuXuatHang = dr["TenPhieuXuatHang"].ToString();
        //            dl.MaloaiPhieuXuatHang = int.Parse(dr["MaloaiPhieuXuatHang"].ToString());
        //            dl.Dienthoai = dr["Dienthoai"].ToString();
        //            dl.Diachi= dr["Diachi"].ToString();
        //            dl.Maquan = int.Parse(dr["Maquan"].ToString());
        //            dl.Ngaytiepnhan = DateTime.Parse(dr["Ngaytiepnhan"].ToString());
        //            dl.Email = dr["Email"].ToString();
        //            dl.NocuaPhieuXuatHang = int.Parse(dr["NocuaPhieuXuatHang"].ToString());

        //            list.Add(dl);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return list;
        //}
        
        //public static List<PhieuXuatHangDTO> SelectPhieuXuatHangAllAsList()
        //{
        //    List<PhieuXuatHangDTO> list = new List<PhieuXuatHangDTO>();
        //    try
        //    {
        //        DataTable dt = OleDbDataAccessHelper.ExecuteQuery("select * from PhieuXuatHang");
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            PhieuXuatHangDTO dl = new PhieuXuatHangDTO();
        //            dl.MaPhieuXuatHang = int.Parse(dr["MaPhieuXuatHang"].ToString());
        //            dl.TenPhieuXuatHang = dr["TenPhieuXuatHang"].ToString();
        //            dl.MaloaiPhieuXuatHang = int.Parse(dr["MaloaiPhieuXuatHang"].ToString());
        //            dl.Dienthoai = dr["Dienthoai"].ToString();
        //            dl.Diachi = dr["Diachi"].ToString();
        //            dl.Maquan = int.Parse(dr["Maquan"].ToString());
        //            dl.Ngaytiepnhan = DateTime.Parse(dr["Ngaytiepnhan"].ToString());
        //            dl.Email = dr["Email"].ToString();
        //            dl.NocuaPhieuXuatHang  = int.Parse(dr["NocuaPhieuXuatHang"].ToString());
        //            list.Add(dl);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return list;
        //}

        //public static DataTable SelectPhieuXuatHangAllAsDataTable()
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        //truy van voi tat ca PhieuXuatHang voi ten PhieuXuatHang duoc hien thi
        //        string query = "select dl.MaPhieuXuatHang, dl.TenPhieuXuatHang, dl.MaLoaiPhieuXuatHang, dl.DiemThoai, dl.DiaChi, dl.MaQuan, dl.NgayTiepNhan, dl.Email, dl.NoCuaPhieuXuatHang  from PhieuXuatHang dl, LoaiPhieuXuatHang ldl where dl.MaLoaiPhieuXuatHang = ldl.MaLoaiPhieuXuatHang";
        //        dt = OleDbDataAccessHelper.ExecuteQuery(query);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return dt;
        //}

        //public static PhieuXuatHangDTO SelectPhieuXuatHangByMaPhieuXuatHang(int maPhieuXuatHang)
        //{
        //    PhieuXuatHangDTO dl = new PhieuXuatHangDTO();
        //    try
        //    {
        //        // Create List Sql Parameter
        //        List<OleDbParameter> oleParams = new List<OleDbParameter>();
        //        oleParams.Add(new OleDbParameter("@MaPhieuXuatHang", maPhieuXuatHang));
        //        string query = "select * from PhieuXuatHang dl where dl.MaPhieuXuatHang = ?";
        //        DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query, oleParams);
        //        DataRow dr = dt.Rows[0];
        //        dl.MaPhieuXuatHang = int.Parse(dr["MaPhieuXuatHang"].ToString());
        //        dl.TenPhieuXuatHang = dr["TenPhieuXuatHang"].ToString();
        //        dl.MaloaiPhieuXuatHang = int.Parse(dr["MaloaiPhieuXuatHang"].ToString());
        //        dl.Dienthoai = dr["Dienthoai"].ToString();
        //        dl.Diachi = dr["Diachi"].ToString();
        //        dl.Maquan = int.Parse(dr["Maquan"].ToString());
        //        dl.Ngaytiepnhan = DateTime.Parse(dr["Ngaytiepnhan"].ToString());
        //        dl.Email = dr["Email"].ToString();
        //        dl.NocuaPhieuXuatHang = int.Parse(dr["NocuaPhieuXuatHang"].ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return dl;
        //}
        //public static DataTable SelectAllPhieuXuatHang()
        //{

        //    string query = "Select * from PhieuXuatHang";
        //    DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
        //    return dt;
        //}
        //public static DataTable SelectPhieuXuatHang_TenLoaiPhieuXuatHang_TenQuan()
        //{
        //    string query ="Select dl.MaPhieuXuatHang,dl.TenPhieuXuatHang,ldl.TenLoaiPhieuXuatHang,dl.DienThoai,dl.DiaChi,q.TenQuan, dl.NgayTiepNhan, dl.Email. dl.NoCuaPhieuXuatHang from PhieuXuatHang dl, LoaiPhieuXuatHang ldl, Quan q where ldl.MaLoaiPhieuXuatHang = dl.MaLoaiPhieuXuatHang and q.MaQuan ";
        //    DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
        //    return dt;
        //}
    }
}
