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
	/// This class is the base class for any <see cref="BangDiemProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class BangDiemProviderBase : BangDiemProviderBaseCore
	{
        public DataSet LaySoHSCoDiemDat(string mamon, string maHK)
        {
            String strSQL = "Select bd.MaHocSinh From Diem d, BangDiem bd, BangThamSo bts Where MaMon = " + "'" + mamon + "'" + "and MaHocKy = " + "'" + maHK + "'" + "and d.DTB >= bts.DiemChuan" + " and d.MaBangDiem = bd.MaBangDiem";
            DataSet dsResult = DataRepository.Provider.ExecuteDataSet(CommandType.Text, strSQL);
            return dsResult;
        }
	} // end class
} // end namespace
