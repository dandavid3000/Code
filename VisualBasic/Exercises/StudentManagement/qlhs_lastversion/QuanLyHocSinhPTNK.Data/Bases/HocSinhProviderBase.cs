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
	/// This class is the base class for any <see cref="HocSinhProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class HocSinhProviderBase : HocSinhProviderBaseCore
	{
        public DataSet LayDSTenHS(string maHK, string tenlophoc)
        {
            String strSQL = "Select hs.HoTenHocSinh From Diem d, BangDiem bd, HocSinh hs, LopHoc lh Where MaHocKy = " + "'" + maHK + "'" + "and d.MaBangDiem = bd.MaBangDiem and bd.MaHocSinh = hs.MaHocSinh and lh.MaLop = hs.MaLop and lh.TenLop = " + "'" + tenlophoc + "'" + "and d.DTB >= 5 " + "Group by hs.HoTenHocSinh";
            DataSet dsResult = DataRepository.Provider.ExecuteDataSet(CommandType.Text, strSQL);
            return dsResult;
        }

        public DataSet LayDSTenHS(string mamon, string maHK, string tenlophoc)
        {
            String strSQL = "Select hs.HoTenHocSinh From Diem d, BangDiem bd, HocSinh hs, LopHoc lh Where MaHocKy = " + "'" + maHK + "'" + "and d.MaBangDiem = bd.MaBangDiem and bd.MaHocSinh = hs.MaHocSinh and lh.MaLop = hs.MaLop and lh.TenLop = " + "'" + tenlophoc + "'" + "and d.DTB >= 5 " + "and d.MaMon = " + "'" + mamon + "'" + "Group by hs.HoTenHocSinh";
            DataSet dsResult = DataRepository.Provider.ExecuteDataSet(CommandType.Text, strSQL);
            return dsResult;
        }

        public DataSet LayThongTinHocSinh(string maHS, string tenHS,string ngaysinh, string diachi, string toan, string ly, string hoa, string sinh, string su, string dia, string van, string daoduc, string theduc, string DTB, string lop )
        {
            String strSQL = "select hs.MaHocSinh, hs.HoTenHocSinh, hs.GioiTinh, hs.NgaySinh, hs.DiaChi, hs.XepLoai, hs.HanhKiem, hs.MaLop from HocSinh hs, LopHoc lh, BangDiem bd, Diem d, MonHoc mh ";
            strSQL += "where hs.MaLop = lh.MaLop and hs.MaHocSinh = bd.MaHocSinh and bd.MaBangDiem = d.MaBangDiem and ";
            strSQL += maHS + "and" + tenHS + "and" + ngaysinh + "and" + diachi + "and" + toan + "and" + ly + "and" + hoa + "and" + sinh + "and" + su + "and" + dia + "and" + van + "and" + daoduc + "and" + theduc + "and" + DTB + "and" + lop;
            strSQL += "Group by hs.MaHocSinh, hs.HoTenHocSinh, hs.GioiTinh, hs.NgaySinh, hs.DiaChi, hs.XepLoai, hs.HanhKiem, hs.MaLop";
            DataSet dsResult = DataRepository.Provider.ExecuteDataSet(CommandType.Text, strSQL);
            return dsResult;
        }
	} // end class
} // end namespace
