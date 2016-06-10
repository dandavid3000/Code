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
	/// This class is the base class for any <see cref="BangThamSoProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class BangThamSoProviderBase : BangThamSoProviderBaseCore
	{
        public void CapNhat(BangThamSo bts)
        {
            String strSQL = "update BangThamSo set sotuoitoithieu = '" + bts.SoTuoiToiThieu + "' , sotuoitoida = '" + bts.SoTuoiToiDa + "' , sisotoida = '" + bts.SiSoToiDa + "' , somonhoc = '" + bts.SoMonHoc + "' , diemchuan = '" + bts.DiemChuan + "' , soquanlytoida = '" + bts.SoQuanLyToiDa + "' , sotiethoclientiep = '" + bts.SoTietHocLienTiep + "' where mabangthamso = '" + bts.MaBangThamSo + "'";
            DataRepository.Provider.ExecuteNonQuery(CommandType.Text, strSQL);            
        }
	} // end class
} // end namespace
