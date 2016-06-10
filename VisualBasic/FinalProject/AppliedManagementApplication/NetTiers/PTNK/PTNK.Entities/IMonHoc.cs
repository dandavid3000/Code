﻿using System;
using System.ComponentModel;

namespace PTNK.Entities
{
	/// <summary>
	///		The data structure representation of the 'MonHoc' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IMonHoc 
	{
		/// <summary>			
		/// MaMonHoc : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "MonHoc"</remarks>
		System.String MaMonHoc { get; set; }
				
		/// <summary>
		/// keep a copy of the original so it can be used for editable primary keys.
		/// </summary>
		System.String OriginalMaMonHoc { get; set; }
			
		
		
		/// <summary>
		/// TenMonHoc : 
		/// </summary>
		System.String  TenMonHoc  { get; set; }
		
		/// <summary>
		/// QuiDinhSoTietHocLienTiepToiThieu : 
		/// </summary>
		System.Byte?  QuiDinhSoTietHocLienTiepToiThieu  { get; set; }
		
		/// <summary>
		/// QuiDinhSoTietHocLienTiepToiDa : 
		/// </summary>
		System.Byte?  QuiDinhSoTietHocLienTiepToiDa  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation phuTrachMaMonHoc
		/// </summary>	
		TList<PhuTrach> PhuTrachCollection {  get;  set;}	


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation phanCongMaMonHoc
		/// </summary>	
		TList<PhanCong> PhanCongCollection {  get;  set;}	

		#endregion Data Properties

	}
}


