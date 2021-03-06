﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLDL.DTO;
using System.Data;
using System.Data.OleDb;

namespace QLDL.DAO
{
    public class LoaiLoaiDaiLyDAO
    {
        public static bool InsertLoaiDaiLy(LoaiDaiLyDTO ldl)
        {
            bool result = false;
            try
            {
                // Create List Sql Parameter
                List<OleDbParameter> oleParams = new List<OleDbParameter>();
                //oleParams.Add(new OleDbParameter("@MaLoaiLoaiDaiLy", ldl.MaLoaiLoaiDaiLy));
                oleParams.Add(new OleDbParameter("@TenLoaiDaiLy", ldl.Tenloaidaily));
                oleParams.Add(new OleDbParameter("@NoToiDa", ldl.Notoida));
                // Call Store Procedure
                int n = OleDbDataAccessHelper.ExecuteNoneQuery("insert into LoaiDaiLy(TenLoaiDaiLy,NoToiDa ) values(?,?)", oleParams);
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
        public static bool UpdateLoaiDaiLy(LoaiDaiLyDTO dl)
        {
            bool result = false;
            try
            {
                // Create List Sql Parameter
                List<OleDbParameter> oleParams = new List<OleDbParameter>();
                oleParams.Add(new OleDbParameter("@TenLoaiDaiLy", dl.Tenloaidaily));
                oleParams.Add(new OleDbParameter("@NoToiDa", dl.Notoida));
                oleParams.Add(new OleDbParameter("@MaLoaiDaiLy", dl.Maloaidaily));
                // Call Store Procedure
                int n = OleDbDataAccessHelper.ExecuteNoneQuery("Update LoaiDaiLy set TenLoaiDaiLy = ?, NoToiDa = ? where MaLoaiDaiLy = ?", oleParams);
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
        public static bool DeleteLoaiDaiLyByMaLoaiDaiLy(int MaLoaiDaiLy)
        {
            bool result = false;
            try
            {
                // Create List Sql Parameter
                List<OleDbParameter> oleParams = new List<OleDbParameter>();
                oleParams.Add(new OleDbParameter("@MaLoaiDaiLy", MaLoaiDaiLy));
                // Call Store Procedure
                int n = OleDbDataAccessHelper.ExecuteNoneQuery("Delete from LoaiDaiLy where MaLoaiDaiLy = ?", oleParams);
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
        public static List<LoaiDaiLyDTO> SelectLoaiDaiLyByLoaiDaiLy(int loaidaily)
        {
            List<LoaiDaiLyDTO> list = new List<LoaiDaiLyDTO>();
            try
            {
                // Create List Sql Parameter
                List<OleDbParameter> oleParams = new List<OleDbParameter>();
                oleParams.Add(new OleDbParameter("@MaLoaiDaiLy", loaidaily));
                //truy van voi tat ca LoaiDaiLy voi ten LoaiDaiLy duoc hien thi
                string query = "select * from LoaiDaiLy ldl where ldl.MaLoaiDaiLy = ?";
                DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query, oleParams);
                foreach (DataRow dr in dt.Rows)
                {
                    LoaiDaiLyDTO ldl = new LoaiDaiLyDTO();
                    ldl.Maloaidaily = int.Parse(dr["MaLoaiDaiLy"].ToString());
                    ldl.Tenloaidaily = dr["TenLoaiDaiLy"].ToString();
                    ldl.Notoida = int.Parse(dr["NoToiDa"].ToString());
                   

                    list.Add(ldl);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }

        public static List<LoaiDaiLyDTO> SelectLoaiDaiLyAllAsList()
        {
            List<LoaiDaiLyDTO> list = new List<LoaiDaiLyDTO>();
            try
            {
                DataTable dt = OleDbDataAccessHelper.ExecuteQuery("select * from LoaiDaiLy");
                foreach (DataRow dr in dt.Rows)
                {
                    LoaiDaiLyDTO ldl = new LoaiDaiLyDTO();
                    ldl.Maloaidaily = int.Parse(dr["MaLoaiDaiLy"].ToString());
                    ldl.Tenloaidaily = dr["TenLoaiDaiLy"].ToString();
                    ldl.Notoida = int.Parse(dr["NoToiDa"].ToString());
                    list.Add(ldl);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }

       public static LoaiDaiLyDTO SelectLoaiDaiLyByMaLoaiDaiLy(int maloaidaily)
        {
            LoaiDaiLyDTO ldl = new LoaiDaiLyDTO();
            try
            {
                // Create List Sql Parameter
                List<OleDbParameter> oleParams = new List<OleDbParameter>();
                oleParams.Add(new OleDbParameter("@MaLoaiDaiLy", maloaidaily));
                string query = "select * from LoaiDaiLy ldl where ldl.MaLoaiDaiLy = ?";
                DataTable dt = OleDbDataAccessHelper.ExecuteQuery(query, oleParams);
                DataRow dr = dt.Rows[0];
                ldl.Maloaidaily = int.Parse(dr["MaLoaiDaiLy"].ToString());
                ldl.Tenloaidaily= dr["TenLoaiDaiLy"].ToString();
                ldl.Notoida = int.Parse(dr["MaToiDa"].ToString());
              }
            catch (Exception ex)
            {
                throw ex;
            }
            return ldl;
        }
        

    }
}
