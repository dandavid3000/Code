#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using PTNK.Entities;
using PTNK.Data;

#endregion

namespace PTNK.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="PhanCongProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class PhanCongProviderBaseCore : EntityProviderBase<PTNK.Entities.PhanCong, PTNK.Entities.PhanCongKey>
	{		
		#region Get from Many To Many Relationship Functions
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, PTNK.Entities.PhanCongKey key)
		{
			return Delete(transactionManager, key.MaPhanCong);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="maPhanCong">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String maPhanCong)
		{
			return Delete(null, maPhanCong);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maPhanCong">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String maPhanCong);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
		#endregion

		#region Get By Index Functions
		
		/// <summary>
		/// 	Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		public override PTNK.Entities.PhanCong Get(TransactionManager transactionManager, PTNK.Entities.PhanCongKey key, int start, int pageLength)
		{
			return GetByMaPhanCong(transactionManager, key.MaPhanCong, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PhanCong$PrimaryKey index.
		/// </summary>
		/// <param name="maPhanCong"></param>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.PhanCong"/> class.</returns>
		public PTNK.Entities.PhanCong GetByMaPhanCong(System.String maPhanCong)
		{
			int count = -1;
			return GetByMaPhanCong(null,maPhanCong, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PhanCong$PrimaryKey index.
		/// </summary>
		/// <param name="maPhanCong"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.PhanCong"/> class.</returns>
		public PTNK.Entities.PhanCong GetByMaPhanCong(System.String maPhanCong, int start, int pageLength)
		{
			int count = -1;
			return GetByMaPhanCong(null, maPhanCong, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PhanCong$PrimaryKey index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maPhanCong"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.PhanCong"/> class.</returns>
		public PTNK.Entities.PhanCong GetByMaPhanCong(TransactionManager transactionManager, System.String maPhanCong)
		{
			int count = -1;
			return GetByMaPhanCong(transactionManager, maPhanCong, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PhanCong$PrimaryKey index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maPhanCong"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.PhanCong"/> class.</returns>
		public PTNK.Entities.PhanCong GetByMaPhanCong(TransactionManager transactionManager, System.String maPhanCong, int start, int pageLength)
		{
			int count = -1;
			return GetByMaPhanCong(transactionManager, maPhanCong, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PhanCong$PrimaryKey index.
		/// </summary>
		/// <param name="maPhanCong"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.PhanCong"/> class.</returns>
		public PTNK.Entities.PhanCong GetByMaPhanCong(System.String maPhanCong, int start, int pageLength, out int count)
		{
			return GetByMaPhanCong(null, maPhanCong, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PhanCong$PrimaryKey index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maPhanCong"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.PhanCong"/> class.</returns>
		public abstract PTNK.Entities.PhanCong GetByMaPhanCong(TransactionManager transactionManager, System.String maPhanCong, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PhanCong$GiaoVienPhanCong index.
		/// </summary>
		/// <param name="maGiaoVien"></param>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;PhanCong&gt;"/> class.</returns>
		public PTNK.Entities.TList<PhanCong> GetByMaGiaoVien(System.String maGiaoVien)
		{
			int count = -1;
			return GetByMaGiaoVien(null,maGiaoVien, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PhanCong$GiaoVienPhanCong index.
		/// </summary>
		/// <param name="maGiaoVien"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;PhanCong&gt;"/> class.</returns>
		public PTNK.Entities.TList<PhanCong> GetByMaGiaoVien(System.String maGiaoVien, int start, int pageLength)
		{
			int count = -1;
			return GetByMaGiaoVien(null, maGiaoVien, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PhanCong$GiaoVienPhanCong index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maGiaoVien"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;PhanCong&gt;"/> class.</returns>
		public PTNK.Entities.TList<PhanCong> GetByMaGiaoVien(TransactionManager transactionManager, System.String maGiaoVien)
		{
			int count = -1;
			return GetByMaGiaoVien(transactionManager, maGiaoVien, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PhanCong$GiaoVienPhanCong index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maGiaoVien"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;PhanCong&gt;"/> class.</returns>
		public PTNK.Entities.TList<PhanCong> GetByMaGiaoVien(TransactionManager transactionManager, System.String maGiaoVien, int start, int pageLength)
		{
			int count = -1;
			return GetByMaGiaoVien(transactionManager, maGiaoVien, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PhanCong$GiaoVienPhanCong index.
		/// </summary>
		/// <param name="maGiaoVien"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;PhanCong&gt;"/> class.</returns>
		public PTNK.Entities.TList<PhanCong> GetByMaGiaoVien(System.String maGiaoVien, int start, int pageLength, out int count)
		{
			return GetByMaGiaoVien(null, maGiaoVien, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PhanCong$GiaoVienPhanCong index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maGiaoVien"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;PhanCong&gt;"/> class.</returns>
		public abstract PTNK.Entities.TList<PhanCong> GetByMaGiaoVien(TransactionManager transactionManager, System.String maGiaoVien, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PhanCong$LopHocPhanCong index.
		/// </summary>
		/// <param name="maLopHoc"></param>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;PhanCong&gt;"/> class.</returns>
		public PTNK.Entities.TList<PhanCong> GetByMaLopHoc(System.String maLopHoc)
		{
			int count = -1;
			return GetByMaLopHoc(null,maLopHoc, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PhanCong$LopHocPhanCong index.
		/// </summary>
		/// <param name="maLopHoc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;PhanCong&gt;"/> class.</returns>
		public PTNK.Entities.TList<PhanCong> GetByMaLopHoc(System.String maLopHoc, int start, int pageLength)
		{
			int count = -1;
			return GetByMaLopHoc(null, maLopHoc, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PhanCong$LopHocPhanCong index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maLopHoc"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;PhanCong&gt;"/> class.</returns>
		public PTNK.Entities.TList<PhanCong> GetByMaLopHoc(TransactionManager transactionManager, System.String maLopHoc)
		{
			int count = -1;
			return GetByMaLopHoc(transactionManager, maLopHoc, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PhanCong$LopHocPhanCong index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maLopHoc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;PhanCong&gt;"/> class.</returns>
		public PTNK.Entities.TList<PhanCong> GetByMaLopHoc(TransactionManager transactionManager, System.String maLopHoc, int start, int pageLength)
		{
			int count = -1;
			return GetByMaLopHoc(transactionManager, maLopHoc, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PhanCong$LopHocPhanCong index.
		/// </summary>
		/// <param name="maLopHoc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;PhanCong&gt;"/> class.</returns>
		public PTNK.Entities.TList<PhanCong> GetByMaLopHoc(System.String maLopHoc, int start, int pageLength, out int count)
		{
			return GetByMaLopHoc(null, maLopHoc, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PhanCong$LopHocPhanCong index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maLopHoc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;PhanCong&gt;"/> class.</returns>
		public abstract PTNK.Entities.TList<PhanCong> GetByMaLopHoc(TransactionManager transactionManager, System.String maLopHoc, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PhanCong$MonHocPhanCong index.
		/// </summary>
		/// <param name="maMonHoc"></param>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;PhanCong&gt;"/> class.</returns>
		public PTNK.Entities.TList<PhanCong> GetByMaMonHoc(System.String maMonHoc)
		{
			int count = -1;
			return GetByMaMonHoc(null,maMonHoc, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PhanCong$MonHocPhanCong index.
		/// </summary>
		/// <param name="maMonHoc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;PhanCong&gt;"/> class.</returns>
		public PTNK.Entities.TList<PhanCong> GetByMaMonHoc(System.String maMonHoc, int start, int pageLength)
		{
			int count = -1;
			return GetByMaMonHoc(null, maMonHoc, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PhanCong$MonHocPhanCong index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maMonHoc"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;PhanCong&gt;"/> class.</returns>
		public PTNK.Entities.TList<PhanCong> GetByMaMonHoc(TransactionManager transactionManager, System.String maMonHoc)
		{
			int count = -1;
			return GetByMaMonHoc(transactionManager, maMonHoc, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PhanCong$MonHocPhanCong index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maMonHoc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;PhanCong&gt;"/> class.</returns>
		public PTNK.Entities.TList<PhanCong> GetByMaMonHoc(TransactionManager transactionManager, System.String maMonHoc, int start, int pageLength)
		{
			int count = -1;
			return GetByMaMonHoc(transactionManager, maMonHoc, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PhanCong$MonHocPhanCong index.
		/// </summary>
		/// <param name="maMonHoc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;PhanCong&gt;"/> class.</returns>
		public PTNK.Entities.TList<PhanCong> GetByMaMonHoc(System.String maMonHoc, int start, int pageLength, out int count)
		{
			return GetByMaMonHoc(null, maMonHoc, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PhanCong$MonHocPhanCong index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maMonHoc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;PhanCong&gt;"/> class.</returns>
		public abstract PTNK.Entities.TList<PhanCong> GetByMaMonHoc(TransactionManager transactionManager, System.String maMonHoc, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a PTNK.Entities.TList&lt;PhanCong&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="PTNK.Entities.TList&lt;PhanCong&gt;"/></returns>
		public static PTNK.Entities.TList<PhanCong> Fill(IDataReader reader, PTNK.Entities.TList<PhanCong> rows, int start, int pageLength)
		{
		// advance to the starting row
		for (int i = 0; i < start; i++)
		{
			if (!reader.Read())
			return rows; // not enough rows, just return
		}
		for (int i = 0; i < pageLength; i++)
		{
			if (!reader.Read())
			break; // we are done
			string key = null;
			
			PTNK.Entities.PhanCong c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("PhanCong")
			.Append("|").Append((reader.IsDBNull(((int)PTNK.Entities.PhanCongColumn.MaPhanCong - 1))?string.Empty:(System.String)reader[((int)PTNK.Entities.PhanCongColumn.MaPhanCong - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<PhanCong>(
			key.ToString(), // EntityTrackingKey
			"PhanCong",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new PTNK.Entities.PhanCong();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.MaPhanCong = (System.String)reader["MaPhanCong"];
			c.OriginalMaPhanCong = c.MaPhanCong;
			c.MaLopHoc = reader.IsDBNull(reader.GetOrdinal("MaLopHoc")) ? null : (System.String)reader["MaLopHoc"];
			c.MaMonHoc = reader.IsDBNull(reader.GetOrdinal("MaMonHoc")) ? null : (System.String)reader["MaMonHoc"];
			c.MaGiaoVien = reader.IsDBNull(reader.GetOrdinal("MaGiaoVien")) ? null : (System.String)reader["MaGiaoVien"];
			c.SoTietHocTuan = reader.IsDBNull(reader.GetOrdinal("SoTietHocTuan")) ? null : (System.Byte?)reader["SoTietHocTuan"];
			c.SoTietHocLienTiepToiThieu = reader.IsDBNull(reader.GetOrdinal("SoTietHocLienTiepToiThieu")) ? null : (System.Byte?)reader["SoTietHocLienTiepToiThieu"];
			c.SoTietHocLienTiepToiDa = reader.IsDBNull(reader.GetOrdinal("SoTietHocLienTiepToiDa")) ? null : (System.Byte?)reader["SoTietHocLienTiepToiDa"];
			c.SoBuoiHocToiThieu = reader.IsDBNull(reader.GetOrdinal("SoBuoiHocToiThieu")) ? null : (System.Byte?)reader["SoBuoiHocToiThieu"];
			c.SoBuoiHocToiDa = reader.IsDBNull(reader.GetOrdinal("SoBuoiHocToiDa")) ? null : (System.Byte?)reader["SoBuoiHocToiDa"];
			c.EntityTrackingKey = key;
			c.AcceptChanges();
			c.SuppressEntityEvents = false;
			}
			rows.Add(c);
		}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="PTNK.Entities.PhanCong"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="PTNK.Entities.PhanCong"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, PTNK.Entities.PhanCong entity)
		{
			if (!reader.Read()) return;
			
			entity.MaPhanCong = (System.String)reader["MaPhanCong"];
			entity.OriginalMaPhanCong = (System.String)reader["MaPhanCong"];
			entity.MaLopHoc = reader.IsDBNull(reader.GetOrdinal("MaLopHoc")) ? null : (System.String)reader["MaLopHoc"];
			entity.MaMonHoc = reader.IsDBNull(reader.GetOrdinal("MaMonHoc")) ? null : (System.String)reader["MaMonHoc"];
			entity.MaGiaoVien = reader.IsDBNull(reader.GetOrdinal("MaGiaoVien")) ? null : (System.String)reader["MaGiaoVien"];
			entity.SoTietHocTuan = reader.IsDBNull(reader.GetOrdinal("SoTietHocTuan")) ? null : (System.Byte?)reader["SoTietHocTuan"];
			entity.SoTietHocLienTiepToiThieu = reader.IsDBNull(reader.GetOrdinal("SoTietHocLienTiepToiThieu")) ? null : (System.Byte?)reader["SoTietHocLienTiepToiThieu"];
			entity.SoTietHocLienTiepToiDa = reader.IsDBNull(reader.GetOrdinal("SoTietHocLienTiepToiDa")) ? null : (System.Byte?)reader["SoTietHocLienTiepToiDa"];
			entity.SoBuoiHocToiThieu = reader.IsDBNull(reader.GetOrdinal("SoBuoiHocToiThieu")) ? null : (System.Byte?)reader["SoBuoiHocToiThieu"];
			entity.SoBuoiHocToiDa = reader.IsDBNull(reader.GetOrdinal("SoBuoiHocToiDa")) ? null : (System.Byte?)reader["SoBuoiHocToiDa"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="PTNK.Entities.PhanCong"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="PTNK.Entities.PhanCong"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, PTNK.Entities.PhanCong entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.MaPhanCong = (System.String)dataRow["MaPhanCong"];
			entity.OriginalMaPhanCong = (System.String)dataRow["MaPhanCong"];
			entity.MaLopHoc = Convert.IsDBNull(dataRow["MaLopHoc"]) ? null : (System.String)dataRow["MaLopHoc"];
			entity.MaMonHoc = Convert.IsDBNull(dataRow["MaMonHoc"]) ? null : (System.String)dataRow["MaMonHoc"];
			entity.MaGiaoVien = Convert.IsDBNull(dataRow["MaGiaoVien"]) ? null : (System.String)dataRow["MaGiaoVien"];
			entity.SoTietHocTuan = Convert.IsDBNull(dataRow["SoTietHocTuan"]) ? null : (System.Byte?)dataRow["SoTietHocTuan"];
			entity.SoTietHocLienTiepToiThieu = Convert.IsDBNull(dataRow["SoTietHocLienTiepToiThieu"]) ? null : (System.Byte?)dataRow["SoTietHocLienTiepToiThieu"];
			entity.SoTietHocLienTiepToiDa = Convert.IsDBNull(dataRow["SoTietHocLienTiepToiDa"]) ? null : (System.Byte?)dataRow["SoTietHocLienTiepToiDa"];
			entity.SoBuoiHocToiThieu = Convert.IsDBNull(dataRow["SoBuoiHocToiThieu"]) ? null : (System.Byte?)dataRow["SoBuoiHocToiThieu"];
			entity.SoBuoiHocToiDa = Convert.IsDBNull(dataRow["SoBuoiHocToiDa"]) ? null : (System.Byte?)dataRow["SoBuoiHocToiDa"];
			entity.AcceptChanges();
		}
		#endregion 
		
		#region DeepLoad Methods
		/// <summary>
		/// Deep Loads the <see cref="IEntity"/> object with criteria based of the child 
		/// property collections only N Levels Deep based on the <see cref="DeepLoadType"/>.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with Recursion and traverse an entire object graph.
		/// </remarks>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">The <see cref="PTNK.Entities.PhanCong"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">PTNK.Entities.PhanCong Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, PTNK.Entities.PhanCong entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region MaLopHocSource	
			if (CanDeepLoad(entity, "LopHoc|MaLopHocSource", deepLoadType, innerList) 
				&& entity.MaLopHocSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.MaLopHoc ?? string.Empty);
				LopHoc tmpEntity = EntityManager.LocateEntity<LopHoc>(EntityLocator.ConstructKeyFromPkItems(typeof(LopHoc), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.MaLopHocSource = tmpEntity;
				else
					entity.MaLopHocSource = DataRepository.LopHocProvider.GetByMaLopHoc(transactionManager, (entity.MaLopHoc ?? string.Empty));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MaLopHocSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.MaLopHocSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.LopHocProvider.DeepLoad(transactionManager, entity.MaLopHocSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion MaLopHocSource

			#region MaMonHocSource	
			if (CanDeepLoad(entity, "MonHoc|MaMonHocSource", deepLoadType, innerList) 
				&& entity.MaMonHocSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.MaMonHoc ?? string.Empty);
				MonHoc tmpEntity = EntityManager.LocateEntity<MonHoc>(EntityLocator.ConstructKeyFromPkItems(typeof(MonHoc), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.MaMonHocSource = tmpEntity;
				else
					entity.MaMonHocSource = DataRepository.MonHocProvider.GetByMaMonHoc(transactionManager, (entity.MaMonHoc ?? string.Empty));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MaMonHocSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.MaMonHocSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.MonHocProvider.DeepLoad(transactionManager, entity.MaMonHocSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion MaMonHocSource

			#region MaGiaoVienSource	
			if (CanDeepLoad(entity, "GiaoVien|MaGiaoVienSource", deepLoadType, innerList) 
				&& entity.MaGiaoVienSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.MaGiaoVien ?? string.Empty);
				GiaoVien tmpEntity = EntityManager.LocateEntity<GiaoVien>(EntityLocator.ConstructKeyFromPkItems(typeof(GiaoVien), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.MaGiaoVienSource = tmpEntity;
				else
					entity.MaGiaoVienSource = DataRepository.GiaoVienProvider.GetByMaGiaoVien(transactionManager, (entity.MaGiaoVien ?? string.Empty));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MaGiaoVienSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.MaGiaoVienSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.GiaoVienProvider.DeepLoad(transactionManager, entity.MaGiaoVienSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion MaGiaoVienSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByMaPhanCong methods when available
			
			#region LichLopHocCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<LichLopHoc>|LichLopHocCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LichLopHocCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.LichLopHocCollection = DataRepository.LichLopHocProvider.GetByMaPhanCong(transactionManager, entity.MaPhanCong);

				if (deep && entity.LichLopHocCollection.Count > 0)
				{
					deepHandles.Add("LichLopHocCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<LichLopHoc>) DataRepository.LichLopHocProvider.DeepLoad,
						new object[] { transactionManager, entity.LichLopHocCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			//Fire all DeepLoad Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			deepHandles = null;
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the PTNK.Entities.PhanCong object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">PTNK.Entities.PhanCong instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">PTNK.Entities.PhanCong Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, PTNK.Entities.PhanCong entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region MaLopHocSource
			if (CanDeepSave(entity, "LopHoc|MaLopHocSource", deepSaveType, innerList) 
				&& entity.MaLopHocSource != null)
			{
				DataRepository.LopHocProvider.Save(transactionManager, entity.MaLopHocSource);
				entity.MaLopHoc = entity.MaLopHocSource.MaLopHoc;
			}
			#endregion 
			
			#region MaMonHocSource
			if (CanDeepSave(entity, "MonHoc|MaMonHocSource", deepSaveType, innerList) 
				&& entity.MaMonHocSource != null)
			{
				DataRepository.MonHocProvider.Save(transactionManager, entity.MaMonHocSource);
				entity.MaMonHoc = entity.MaMonHocSource.MaMonHoc;
			}
			#endregion 
			
			#region MaGiaoVienSource
			if (CanDeepSave(entity, "GiaoVien|MaGiaoVienSource", deepSaveType, innerList) 
				&& entity.MaGiaoVienSource != null)
			{
				DataRepository.GiaoVienProvider.Save(transactionManager, entity.MaGiaoVienSource);
				entity.MaGiaoVien = entity.MaGiaoVienSource.MaGiaoVien;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<Delegate, object> deepHandles = new Dictionary<Delegate, object>();
	
			#region List<LichLopHoc>
				if (CanDeepSave(entity.LichLopHocCollection, "List<LichLopHoc>|LichLopHocCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(LichLopHoc child in entity.LichLopHocCollection)
					{
						if(child.MaPhanCongSource != null)
							child.MaPhanCong = child.MaPhanCongSource.MaPhanCong;
						else
							child.MaPhanCong = entity.MaPhanCong;

					}

					if (entity.LichLopHocCollection.Count > 0 || entity.LichLopHocCollection.DeletedItems.Count > 0)
					{
						DataRepository.LichLopHocProvider.Save(transactionManager, entity.LichLopHocCollection);
						
						deepHandles.Add(
							(DeepSaveHandle< LichLopHoc >) DataRepository.LichLopHocProvider.DeepSave,
							new object[] { transactionManager, entity.LichLopHocCollection, deepSaveType, childTypes, innerList }
						);
					}
				} 
			#endregion 
				
			//Fire all DeepSave Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			
			// Save Root Entity through Provider, if not already saved in delete mode
			if (entity.IsDeleted)
				this.Save(transactionManager, entity);
				

			deepHandles = null;
						
			return true;
		}
		#endregion
	} // end class
	
	#region PhanCongChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>PTNK.Entities.PhanCong</c>
	///</summary>
	public enum PhanCongChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>LopHoc</c> at MaLopHocSource
		///</summary>
		[ChildEntityType(typeof(LopHoc))]
		LopHoc,
			
		///<summary>
		/// Composite Property for <c>MonHoc</c> at MaMonHocSource
		///</summary>
		[ChildEntityType(typeof(MonHoc))]
		MonHoc,
			
		///<summary>
		/// Composite Property for <c>GiaoVien</c> at MaGiaoVienSource
		///</summary>
		[ChildEntityType(typeof(GiaoVien))]
		GiaoVien,
	
		///<summary>
		/// Collection of <c>PhanCong</c> as OneToMany for LichLopHocCollection
		///</summary>
		[ChildEntityType(typeof(TList<LichLopHoc>))]
		LichLopHocCollection,
	}
	
	#endregion PhanCongChildEntityTypes
	
	#region PhanCongFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;PhanCongColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PhanCong"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PhanCongFilterBuilder : SqlFilterBuilder<PhanCongColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PhanCongFilterBuilder class.
		/// </summary>
		public PhanCongFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the PhanCongFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PhanCongFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PhanCongFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PhanCongFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PhanCongFilterBuilder
	
	#region PhanCongParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;PhanCongColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PhanCong"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PhanCongParameterBuilder : ParameterizedSqlFilterBuilder<PhanCongColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PhanCongParameterBuilder class.
		/// </summary>
		public PhanCongParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the PhanCongParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PhanCongParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PhanCongParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PhanCongParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PhanCongParameterBuilder
} // end namespace
