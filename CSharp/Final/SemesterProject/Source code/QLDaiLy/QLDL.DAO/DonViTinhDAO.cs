using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using QLDL.DTO;
using QLDL.DAO;
using System.Data;


namespace QLDL.DAO
{
  public  static class DonViTinhDAO
    {
        public static bool InsertDonViTinh(DonViTinhDTO dvt)
        {
            bool result = false;
            try
            {
                // Create List Sql Parameter
                List<OleDbParameter> oleParams = new List<OleDbParameter>();
                //oleParams.Add(new OleDbParameter("@MaDonViTinh", dvt.MaDonViTinh));
                oleParams.Add(new OleDbParameter("@TenDonViTinh", dvt.Tendonvitinh));
                // Call Store Procedure
                int n = OleDbDataAccessHelper.ExecuteNoneQuery("insert into DonViTinh(TenDonViTinh) values(?)", oleParams);
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
        public static bool UpdateDonViTinh(DonViTinhDTO dv)
        {
            bool result = false;
            try
            {
                // Create List Sql Parameter
                List<OleDbParameter> oleParams = new List<OleDbParameter>();
                oleParams.Add(new OleDbParameter("@TenDonViTinh", dv.Tendonvitinh));
                oleParams.Add(new OleDbParameter("@MaDonViTinh", dv.Madonvitinh));
                // Call Store Procedure
                int n = OleDbDataAccessHelper.ExecuteNoneQuery("Update DonViTinh set TenDonViTinh = ? where MaDonViTinh = ?", oleParams);
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
        public static bool DeleteDonViTinhByMaDonViTinh(int MaDonViTinh)
        {
            bool result = false;
            try
            {
                // Create List Sql Parameter
                List<OleDbParameter> oleParams = new List<OleDbParameter>();
                oleParams.Add(new OleDbParameter("@MaDonViTinh", MaDonViTinh));
                // Call Store Procedure
                int n = OleDbDataAccessHelper.ExecuteNoneQuery("Delete from DonViTinh where MaDonViTinh = ?", oleParams);
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
        public static List<DonViTinhDTO> SelectDonViTinhByDonViTinh(int donvitinh)
        {
            List<DonViTinhDTO> list = new List<DonViTinhDTO>();
            try
            {
                // Create List Sql Parameter
                List<OleDbParameter> oleParams = new List<OleDbParameter>();
                oleParams.Add(new OleDbParameter("@MaDonViTinh", donvitinh));
                //truy van voi tat ca DonViTinh voi ten DonViTinh duoc hien thi
                string query = "select * from DonViTinh dvt where dvt.MaDonViTinh = ?";
                DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query, oleParams);
                foreach (DataRow dr in dt.Rows)
                {
                    DonViTinhDTO dvt = new DonViTinhDTO();
                    dvt.Madonvitinh = int.Parse(dr["MaDonViTinh"].ToString());
                    dvt.Tendonvitinh = dr["TenDonViTinh"].ToString();

                    list.Add(dvt);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }

        public static List<DonViTinhDTO> SelectDonViTinhAllAsList()
        {
            List<DonViTinhDTO> list = new List<DonViTinhDTO>();
            try
            {
                DataTable dt = OleDbDataAccessHelper.ExecuteQuery("select * from DonViTinh");
                foreach (DataRow dr in dt.Rows)
                {
                    DonViTinhDTO dvt = new DonViTinhDTO();
                    dvt.Madonvitinh = int.Parse(dr["MaDonViTinh"].ToString());
                    dvt.Tendonvitinh = dr["TenDonViTinh"].ToString();

                    list.Add(dvt);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }

        public static DonViTinhDTO SelectDonViTinhByMaDonViTinh(int madonvitinh)
        {
            DonViTinhDTO dvt = new DonViTinhDTO();
            try
            {
                // Create List Sql Parameter
                List<OleDbParameter> oleParams = new List<OleDbParameter>();
                oleParams.Add(new OleDbParameter("@MaDonViTinh", madonvitinh));
                string query = "select * from DonViTinh dvt where dvt.MaDonViTinh = ?";
                DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query, oleParams);
                DataRow dr = dt.Rows[0];
                dvt.Madonvitinh = int.Parse(dr["MaDonViTinh"].ToString());
                dvt.Tendonvitinh = dr["TenDonViTinh"].ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dvt;
        }

        //public static DataTable SelectAllDonViTinh()
        //{
        //    string query = "Select * from DonViTinh";
        //    DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
        //    return dt;
        //}

        //public List<DonViTinhDTO> DanhSachDonViTinh()
        //{
        //    string query = "Select * from DonViTinh";
        //    DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
        //    List<DonViTinhDTO> ds = new List<DonViTinhDTO>();

        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        //khoi tao doi tuong : LoaiBenh
        //        DonViTinhDTO lb = new DonViTinhDTO();
        //        //gan thuoc tinh cho doi tuong: LoaiBenh
        //        lb.Madonvitinh = Convert.ToInt32(dt.Rows[i]["MaDonViTinh"].ToString());
        //        lb.Tendonvitinh = dt.Rows[i]["TenDonViTinh"].ToString();
        //        //them loai benh vao danh sach
        //        ds.Add(lb);
        //    }
        //    return ds;
        //}

        public static DataTable SelectAllDonViTinh()
        {

            string query = "Select * from DonViTinh";
            DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
            return dt;
        }
        public static int SelectMaQuanBytenDonViTinh(string tenquan)
        {

            string query = "Select  ldl. maquan from Quan ldl where ldl.TenQuan =" + tenquan;
            DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
            int temp = Convert.ToInt16(dt.Rows[0][0]);
            return temp;
        }
        public static int Dem_DVT()
        {

            string query = "Select Count(MaDonViTinh) from DonViTinh ";
            DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query);
            int temp = Convert.ToInt32(dt.Rows[0][0]);
            return temp;
        }
    }
}
