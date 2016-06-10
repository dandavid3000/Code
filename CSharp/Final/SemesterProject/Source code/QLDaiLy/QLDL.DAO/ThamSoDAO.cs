using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLDL.DTO;
using System.Data;
using System.Data.OleDb;

namespace QLDL.DAO
{
    public class ThamSoDAO
    {

        //Updating
        public static bool UpdateThamSo(ThamSoDTO dl)
        {
            bool result = false;
            try
            {
                // Create List Sql Parameter
                List<OleDbParameter> oleParams = new List<OleDbParameter>();
                oleParams.Add(new OleDbParameter("@SoLuongDaiLyToiDaMoiQuan", dl.Soluongdailytoidamoiquan));
                oleParams.Add(new OleDbParameter("@SoLuongLoaiDaiLy", dl.Soluongloaidaily));
                oleParams.Add(new OleDbParameter("@SoLuongMatHang", dl.Soluongmathang));
                oleParams.Add(new OleDbParameter("@SoLuongDVT", dl.SoluongDvt));
                // Call Store Procedure
                int n = OleDbDataAccessHelper.ExecuteNoneQuery("Update ThamSo set SoLuongDaiLyToiDaMoiQuan = ?, SoLuongLoaiDaiLy = ?, SoLuongMatHang = ?, SoLuongDVT = ? ", oleParams);
                if (n == 1)
                    result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }


        public static List<ThamSoDTO> SelectThamSoAllAsList()
        {
            List<ThamSoDTO> list = new List<ThamSoDTO>();
            try
            {
                DataTable dt = OleDbDataAccessHelper.ExecuteQuery("select * from ThamSo");
                foreach (DataRow dr in dt.Rows)
                {
                    ThamSoDTO ldl = new ThamSoDTO();
                    ldl.Soluongdailytoidamoiquan = int.Parse(dr["SoLuongDaiLyToiDaMoiQuan"].ToString());
                    ldl.Soluongloaidaily = int.Parse(dr["SoLuongLoaiDaiLy"].ToString());
                    ldl.Soluongmathang = int.Parse(dr["SoLuongMatHang"].ToString());
                    ldl.SoluongDvt = int.Parse(dr["SoLuongDVT"].ToString());

                    list.Add(ldl);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }

        public List<ThamSoDTO> DanhSachThamSo()
        {
            string query = "Select * from ThamSo";
            DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
            List<ThamSoDTO> ds = new List<ThamSoDTO>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ThamSoDTO lb = new ThamSoDTO();
                lb.Soluongdailytoidamoiquan = Convert.ToInt32(dt.Rows[i]["SoLuongDaiLyToiDaMoiQuan"].ToString());
                lb.Soluongloaidaily = Convert.ToInt32(dt.Rows[i]["SoLuongLoaiDaiLy"].ToString());
                lb.Soluongmathang = Convert.ToInt32(dt.Rows[i]["SoLuongMatHang"].ToString());
                lb.SoluongDvt = Convert.ToInt32(dt.Rows[i]["SoLuongDVT"].ToString());

                ds.Add(lb);
            }
            return ds;
        }

        public static DataTable SelectAllThamSo()
        {
            string query = "Select * from ThamSo";
            DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
            return dt;
        }
        public static int SoDLToiDa()
        {
            string query = "Select ts.SoLuongDaiLyToiDaMoiQuan from ThamSo ts ";
            DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
            return Convert.ToInt16(dt.Rows[0][0]);
        }
        public static int SLloaiDL()
        {
            string query = "Select ts.SoLuongloaiDaiLy from ThamSo ts ";
            DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
            return Convert.ToInt16(dt.Rows[0][0]);
        }
        public static int SLMatHang()
        {
            string query = "Select ts.SoLuongMatHang from ThamSo ts ";
            DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
            return Convert.ToInt16(dt.Rows[0][0]);
        }
        public static int SL_DVT()
        {
            string query = "Select ts.SoLuongDVT from ThamSo ts ";
            DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
            return Convert.ToInt16(dt.Rows[0][0]);
        }
    }
}
