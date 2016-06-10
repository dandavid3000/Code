﻿using System;
using System.ComponentModel;

namespace PTNK.Entities
{
	/// <summary>
	///		The data structure representation of the 'LopHoc' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface ILopHoc 
	{
		/// <summary>			
		/// MaLopHoc : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "LopHoc"</remarks>
		System.String MaLopHoc { get; set; }
				
		/// <summary>
		/// keep a copy of the original so it can be used for editable primary keys.
		/// </summary>
		System.String OriginalMaLopHoc { get; set; }
			
		
		
		/// <summary>
		/// TenLopHoc : 
		/// </summary>
		System.String  TenLopHoc  { get; set; }
		
		/// <summary>
		/// MaKhoi : 
		/// </summary>
		System.String  MaKhoi  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation phanCongMaLopHoc
		/// </summary>	
		TList<PhanCong> PhanCongCollection {  get;  set;}	


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation rangBuocLopHocMaLopHoc
		/// </summary>	
		TList<RangBuocLopHoc> RangBuocLopHocCollection {  get;  set;}	

		#endregion Data Properties

	}
}

