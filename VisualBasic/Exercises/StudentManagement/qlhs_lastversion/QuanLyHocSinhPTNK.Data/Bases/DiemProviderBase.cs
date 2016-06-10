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
	/// This class is the base class for any <see cref="DiemProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DiemProviderBase : DiemProviderBaseCore
	{
        public DataSet LayMaBangDiem(string mamon, string maHK)
        {
            String strSQL = "Select MaBangDiem From Diem Where MaMon = " + "'" + mamon + "'" + "and MaHocKy = " + "'" + maHK + "'" + "Group By MaBangDiem";
            DataSet dsResult = DataRepository.Provider.ExecuteDataSet(CommandType.Text, strSQL);
            return dsResult;
        }
	} // end class
} // end namespace
