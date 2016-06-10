using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLDL.DTO;
using System.Data;
using System.Data.OleDb;


namespace QLDL.DAO
{
   public class MatHangDAO
    {
        public static DataTable SelectAllMatHang()
        {

            string query = "Select * from MatHang";
            DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
            return dt;
        }
        public static int SelectMamatHangbyTenMatHang(string tenmathang)
        {

            string query = "Select  ldl. mamathang from MatHang ldl where ldl.Tenmathang =" + tenmathang;
            DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
            int temp = Convert.ToInt16(dt.Rows[0][0]);
            return temp;
        }
        public static bool InsertMatHang(MatHangDTO mh)
        {
            bool result = false;
            try
            {
                // Create List Sql Parameter
                List<OleDbParameter> oleParams = new List<OleDbParameter>();
                //oleParams.Add(new OleDbParameter("@MaMatHang", ldl.MaMatHang));
                oleParams.Add(new OleDbParameter("@TenMatHang", mh.Tenmathang));
                oleParams.Add(new OleDbParameter("@SoLuongTon", mh.Soluongton));
                // Call Store Procedure
                int n = OleDbDataAccessHelper.ExecuteNoneQuery("insert into MatHang(TenMatHang,SoLuongTon ) values(?,?)", oleParams);
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
        public static bool UpdateMatHang(MatHangDTO mh)
        {
            bool result = false;
            try
            {
                // Create List Sql Parameter
                List<OleDbParameter> oleParams = new List<OleDbParameter>();
                oleParams.Add(new OleDbParameter("@TenMatHang", mh.Tenmathang));
                oleParams.Add(new OleDbParameter("@SoLuongTon", mh.Soluongton));
                oleParams.Add(new OleDbParameter("@MaMatHang", mh.Mamathang));
                // Call Store Procedure
                int n = OleDbDataAccessHelper.ExecuteNoneQuery("Update MatHang set TenMatHang = ?, SoLuongTon = ? where MaMatHang = ?", oleParams);
                if (n == 1)
                    result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public static int DemMatHang()
        {

            string query = "Select Count(MaMatHang) from MatHang ";
            DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
            int temp = Convert.ToInt32(dt.Rows[0][0]);
            return temp;
        }
        public static bool UpdateSLTon(int ma,int slton)
        {
            bool result = false;
            try
            {
                // Create List Sql Parameter
                List<OleDbParameter> oleParams = new List<OleDbParameter>();
                oleParams.Add(new OleDbParameter("@SoLuongTon", slton));
                oleParams.Add(new OleDbParameter("@MaMatHang",ma));
                // Call Store Procedure
                int n = OleDbDataAccessHelper.ExecuteNoneQuery("Update MatHang set SoLuongTon = ? where MaMatHang = ?", oleParams);
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
        public static bool DeleteMatHangByMaMatHang(int MaMatHang)
        {
            bool result = false;
            try
            {
                // Create List Sql Parameter
                List<OleDbParameter> oleParams = new List<OleDbParameter>();
                oleParams.Add(new OleDbParameter("@MaMatHang", MaMatHang));
                // Call Store Procedure
                int n = OleDbDataAccessHelper.ExecuteNoneQuery("Delete from MatHang where MaMatHang = ?", oleParams);
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
        public static List<MatHangDTO> SelectMatHangByMatHang(int mathang)
        {
            List<MatHangDTO> list = new List<MatHangDTO>();
            try
            {
                // Create List Sql Parameter
                List<OleDbParameter> oleParams = new List<OleDbParameter>();
                oleParams.Add(new OleDbParameter("@MaMatHang", mathang));
                //truy van voi tat ca LoaiDaiLy voi ten LoaiDaiLy duoc hien thi
                string query = "select * from MatHang mh where mh.MaMatHang = ?";
                DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query, oleParams);
                foreach (DataRow dr in dt.Rows)
                {
                    MatHangDTO mh = new MatHangDTO();
                    mh.Mamathang = int.Parse(dr["MaMatHang"].ToString());
                    mh.Tenmathang = dr["TenMatHang"].ToString();
                    mh.Soluongton = int.Parse(dr["SoLuongTon"].ToString());


                    list.Add(mh);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }

        public static List<MatHangDTO> SelectMatHangAllAsList()
        {
            List<MatHangDTO> list = new List<MatHangDTO>();
            try
            {
                DataTable dt = OleDbDataAccessHelper.ExecuteQuery("select * from MatHang");
                foreach (DataRow dr in dt.Rows)
                {
                    MatHangDTO mh = new MatHangDTO();
                    mh.Mamathang = int.Parse(dr["MaMatHang"].ToString());
                    mh.Tenmathang = dr["TenMatHang"].ToString();
                    mh.Soluongton = int.Parse(dr["SoLuongTon"].ToString());
                    list.Add(mh);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }

        public static MatHangDTO SelectMatHangByMaMatHang(int mamathang)
        {
            MatHangDTO mh = new MatHangDTO();
            try
            {
                // Create List Sql Parameter
                List<OleDbParameter> oleParams = new List<OleDbParameter>();
                oleParams.Add(new OleDbParameter("@MaLMatHang", mamathang));
                string query = "select * from LoaiDaiLy mh where mh.MaMatHang = ?";
                DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query, oleParams);
                DataRow dr = dt.Rows[0];
                mh.Mamathang = int.Parse(dr["MaMatHang"].ToString());
                mh.Tenmathang = dr["TenMatHang"].ToString();
                mh.Soluongton = int.Parse(dr["SoLuongTon"].ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mh;
        }

        public List<MatHangDTO> DanhSachMatHang()
        {
            string query = "Select * from MatHang";
            DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
            List<MatHangDTO> ds = new List<MatHangDTO>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                MatHangDTO lb = new MatHangDTO();

                lb.Mamathang = Convert.ToInt32(dt.Rows[i]["MaMatHang"].ToString());
                lb.Tenmathang = dt.Rows[i]["TenMatHang"].ToString();
                lb.Soluongton = Convert.ToInt32(dt.Rows[i]["SoLuongTon"].ToString());

                ds.Add(lb);
            }
            return ds;
        }
       public static int SSLTon(int ma)
       {
           string query = "Select SoLuongTon from MatHang where MaMatHang = " + ma;
           DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
           return Convert.ToInt16(dt.Rows[0][0]);
       }

    }

}
