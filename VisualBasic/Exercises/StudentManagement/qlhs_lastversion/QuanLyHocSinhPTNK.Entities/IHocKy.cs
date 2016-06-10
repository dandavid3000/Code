﻿using System;
using System.ComponentModel;

namespace QuanLyHocSinhPTNK.Entities
{
	/// <summary>
	///		The data structure representation of the 'HocKy' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IHocKy 
	{
		/// <summary>			
		/// MaHocKy : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "HocKy"</remarks>
		System.String MaHocKy { get; set; }
				
		/// <summary>
		/// keep a copy of the original so it can be used for editable primary keys.
		/// </summary>
		System.String OriginalMaHocKy { get; set; }
			
		
		
		/// <summary>
		/// TenHocKy : 
		/// </summary>
		System.String  TenHocKy  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation diemMaHocKy
		/// </summary>	
		TList<Diem> DiemCollection {  get;  set;}	

		#endregion Data Properties

	}
}

