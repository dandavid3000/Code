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
	/// This class is the base class for any <see cref="QuanLyProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class QuanLyProviderBase : QuanLyProviderBaseCore
	{
        public DataSet LayQuanLyXoa(string machucdanh, string maphongban)
        {
            String strSQL = "Select MaQuanLy From QuanLy Where MaChucDanh = " + "'" + machucdanh + "'" + "and MaPhongBan = " + "'" + maphongban + "'";
            DataSet dsResult = DataRepository.Provider.ExecuteDataSet(CommandType.Text, strSQL);
            return dsResult;
        }
	} // end class
} // end namespace
