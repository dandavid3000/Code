#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using System.Diagnostics;
using QuanLyHocSinhPTNK.Entities;
using QuanLyHocSinhPTNK.Data;

#endregion

namespace QuanLyHocSinhPTNK.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="LopHocProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class LopHocProviderBase : LopHocProviderBaseCore
	{
        public DataSet LayDSLopHoc(string maHK)
        {
            String strSQL = "Select lh.TenLop From Diem d, BangDiem bd, LopHoc lh, HocSinh hs Where MaHocKy = " + "'" + maHK + "'" + "and d.MaBangDiem = bd.MaBangDiem and bd.MaHocSinh = hs.MaHocSinh and hs.MaLop = lh.MaLop Group by lh.TenLop";
            DataSet dsResult = DataRepository.Provider.ExecuteDataSet(CommandType.Text, strSQL);
            return dsResult;
        }

        public DataSet LayDSLopHoc(string mamon, string maHK)
        {
            String strSQL = "Select lh.TenLop From Diem d, BangDiem bd, LopHoc lh, HocSinh hs Where MaHocKy = " + "'" + maHK + "'" + "and d.MaBangDiem = bd.MaBangDiem and bd.MaHocSinh = hs.MaHocSinh and hs.MaLop = lh.MaLop" + " and d.MaMon = " + "'" + mamon + "'" + " Group by lh.TenLop";
            DataSet dsResult = DataRepository.Provider.ExecuteDataSet(CommandType.Text, strSQL);
            return dsResult;
        }

        public DataSet LaySoLuongHS(string tenlop)
        {
            String strSQL = "Select count(MaHocSinh) From LopHoc lh, HocSinh hs Where lh.MaLop = hs.MaLop and lh.TenLop = " + "'" + tenlop + "'";
            DataSet dsResult = DataRepository.Provider.ExecuteDataSet(CommandType.Text, strSQL);
            return dsResult;
        }
	} // end class
} // end namespace
