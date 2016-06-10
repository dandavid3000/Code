#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using QuanLyHocSinhPTNK.Entities;
using QuanLyHocSinhPTNK.Data;

#endregion

namespace QuanLyHocSinhPTNK.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="DiemProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DiemProviderBaseCore : EntityProviderBase<QuanLyHocSinhPTNK.Entities.Diem, QuanLyHocSinhPTNK.Entities.DiemKey>
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
		public override bool Delete(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.DiemKey key)
		{
			return Delete(transactionManager, key.MaDiem);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="maDiem">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String maDiem)
		{
			return Delete(null, maDiem);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maDiem">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String maDiem);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Diem_MonHoc key.
		///		FK_Diem_MonHoc Description: 
		/// </summary>
		/// <param name="maMon"></param>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.Diem objects.</returns>
		public QuanLyHocSinhPTNK.Entities.TList<Diem> GetByMaMon(System.String maMon)
		{
			int count = -1;
			return GetByMaMon(maMon, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Diem_MonHoc key.
		///		FK_Diem_MonHoc Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maMon"></param>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.Diem objects.</returns>
		/// <remarks></remarks>
		public QuanLyHocSinhPTNK.Entities.TList<Diem> GetByMaMon(TransactionManager transactionManager, System.String maMon)
		{
			int count = -1;
			return GetByMaMon(transactionManager, maMon, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Diem_MonHoc key.
		///		FK_Diem_MonHoc Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maMon"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.Diem objects.</returns>
		public QuanLyHocSinhPTNK.Entities.TList<Diem> GetByMaMon(TransactionManager transactionManager, System.String maMon, int start, int pageLength)
		{
			int count = -1;
			return GetByMaMon(transactionManager, maMon, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Diem_MonHoc key.
		///		fkDiemMonHoc Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="maMon"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.Diem objects.</returns>
		public QuanLyHocSinhPTNK.Entities.TList<Diem> GetByMaMon(System.String maMon, int start, int pageLength)
		{
			int count =  -1;
			return GetByMaMon(null, maMon, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Diem_MonHoc key.
		///		fkDiemMonHoc Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="maMon"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.Diem objects.</returns>
		public QuanLyHocSinhPTNK.Entities.TList<Diem> GetByMaMon(System.String maMon, int start, int pageLength,out int count)
		{
			return GetByMaMon(null, maMon, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Diem_MonHoc key.
		///		FK_Diem_MonHoc Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maMon"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.Diem objects.</returns>
		public abstract QuanLyHocSinhPTNK.Entities.TList<Diem> GetByMaMon(TransactionManager transactionManager, System.String maMon, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Diem_HocKy key.
		///		FK_Diem_HocKy Description: 
		/// </summary>
		/// <param name="maHocKy"></param>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.Diem objects.</returns>
		public QuanLyHocSinhPTNK.Entities.TList<Diem> GetByMaHocKy(System.String maHocKy)
		{
			int count = -1;
			return GetByMaHocKy(maHocKy, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Diem_HocKy key.
		///		FK_Diem_HocKy Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maHocKy"></param>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.Diem objects.</returns>
		/// <remarks></remarks>
		public QuanLyHocSinhPTNK.Entities.TList<Diem> GetByMaHocKy(TransactionManager transactionManager, System.String maHocKy)
		{
			int count = -1;
			return GetByMaHocKy(transactionManager, maHocKy, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Diem_HocKy key.
		///		FK_Diem_HocKy Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maHocKy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.Diem objects.</returns>
		public QuanLyHocSinhPTNK.Entities.TList<Diem> GetByMaHocKy(TransactionManager transactionManager, System.String maHocKy, int start, int pageLength)
		{
			int count = -1;
			return GetByMaHocKy(transactionManager, maHocKy, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Diem_HocKy key.
		///		fkDiemHocKy Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="maHocKy"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.Diem objects.</returns>
		public QuanLyHocSinhPTNK.Entities.TList<Diem> GetByMaHocKy(System.String maHocKy, int start, int pageLength)
		{
			int count =  -1;
			return GetByMaHocKy(null, maHocKy, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Diem_HocKy key.
		///		fkDiemHocKy Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="maHocKy"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.Diem objects.</returns>
		public QuanLyHocSinhPTNK.Entities.TList<Diem> GetByMaHocKy(System.String maHocKy, int start, int pageLength,out int count)
		{
			return GetByMaHocKy(null, maHocKy, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Diem_HocKy key.
		///		FK_Diem_HocKy Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maHocKy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.Diem objects.</returns>
		public abstract QuanLyHocSinhPTNK.Entities.TList<Diem> GetByMaHocKy(TransactionManager transactionManager, System.String maHocKy, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Diem_BangDiem key.
		///		FK_Diem_BangDiem Description: 
		/// </summary>
		/// <param name="maBangDiem"></param>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.Diem objects.</returns>
		public QuanLyHocSinhPTNK.Entities.TList<Diem> GetByMaBangDiem(System.String maBangDiem)
		{
			int count = -1;
			return GetByMaBangDiem(maBangDiem, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Diem_BangDiem key.
		///		FK_Diem_BangDiem Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maBangDiem"></param>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.Diem objects.</returns>
		/// <remarks></remarks>
		public QuanLyHocSinhPTNK.Entities.TList<Diem> GetByMaBangDiem(TransactionManager transactionManager, System.String maBangDiem)
		{
			int count = -1;
			return GetByMaBangDiem(transactionManager, maBangDiem, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Diem_BangDiem key.
		///		FK_Diem_BangDiem Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maBangDiem"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.Diem objects.</returns>
		public QuanLyHocSinhPTNK.Entities.TList<Diem> GetByMaBangDiem(TransactionManager transactionManager, System.String maBangDiem, int start, int pageLength)
		{
			int count = -1;
			return GetByMaBangDiem(transactionManager, maBangDiem, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Diem_BangDiem key.
		///		fkDiemBangDiem Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="maBangDiem"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.Diem objects.</returns>
		public QuanLyHocSinhPTNK.Entities.TList<Diem> GetByMaBangDiem(System.String maBangDiem, int start, int pageLength)
		{
			int count =  -1;
			return GetByMaBangDiem(null, maBangDiem, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Diem_BangDiem key.
		///		fkDiemBangDiem Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="maBangDiem"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.Diem objects.</returns>
		public QuanLyHocSinhPTNK.Entities.TList<Diem> GetByMaBangDiem(System.String maBangDiem, int start, int pageLength,out int count)
		{
			return GetByMaBangDiem(null, maBangDiem, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Diem_BangDiem key.
		///		FK_Diem_BangDiem Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maBangDiem"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.Diem objects.</returns>
		public abstract QuanLyHocSinhPTNK.Entities.TList<Diem> GetByMaBangDiem(TransactionManager transactionManager, System.String maBangDiem, int start, int pageLength, out int count);
		
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
		public override QuanLyHocSinhPTNK.Entities.Diem Get(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.DiemKey key, int start, int pageLength)
		{
			return GetByMaDiem(transactionManager, key.MaDiem, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_MonHoc index.
		/// </summary>
		/// <param name="maDiem"></param>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.Diem"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.Diem GetByMaDiem(System.String maDiem)
		{
			int count = -1;
			return GetByMaDiem(null,maDiem, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_MonHoc index.
		/// </summary>
		/// <param name="maDiem"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.Diem"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.Diem GetByMaDiem(System.String maDiem, int start, int pageLength)
		{
			int count = -1;
			return GetByMaDiem(null, maDiem, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_MonHoc index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maDiem"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.Diem"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.Diem GetByMaDiem(TransactionManager transactionManager, System.String maDiem)
		{
			int count = -1;
			return GetByMaDiem(transactionManager, maDiem, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_MonHoc index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maDiem"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.Diem"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.Diem GetByMaDiem(TransactionManager transactionManager, System.String maDiem, int start, int pageLength)
		{
			int count = -1;
			return GetByMaDiem(transactionManager, maDiem, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_MonHoc index.
		/// </summary>
		/// <param name="maDiem"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.Diem"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.Diem GetByMaDiem(System.String maDiem, int start, int pageLength, out int count)
		{
			return GetByMaDiem(null, maDiem, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_MonHoc index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maDiem"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.Diem"/> class.</returns>
		public abstract QuanLyHocSinhPTNK.Entities.Diem GetByMaDiem(TransactionManager transactionManager, System.String maDiem, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a QuanLyHocSinhPTNK.Entities.TList&lt;Diem&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="QuanLyHocSinhPTNK.Entities.TList&lt;Diem&gt;"/></returns>
		public static QuanLyHocSinhPTNK.Entities.TList<Diem> Fill(IDataReader reader, QuanLyHocSinhPTNK.Entities.TList<Diem> rows, int start, int pageLength)
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
			
			QuanLyHocSinhPTNK.Entities.Diem c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("Diem")
			.Append("|").Append((reader.IsDBNull(((int)QuanLyHocSinhPTNK.Entities.DiemColumn.MaDiem - 1))?string.Empty:(System.String)reader[((int)QuanLyHocSinhPTNK.Entities.DiemColumn.MaDiem - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<Diem>(
			key.ToString(), // EntityTrackingKey
			"Diem",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new QuanLyHocSinhPTNK.Entities.Diem();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.MaDiem = (System.String)reader["MaDiem"];
			c.OriginalMaDiem = c.MaDiem;
			c.Diem15Phut = (System.Double)reader["Diem15Phut"];
			c.Diem1Tiet = (System.Double)reader["Diem1Tiet"];
			c.DiemCuoiKy = (System.Double)reader["DiemCuoiKy"];
			c.Dtb = (System.Double)reader["DTB"];
			c.MaMon = (System.String)reader["MaMon"];
			c.MaBangDiem = (System.String)reader["MaBangDiem"];
			c.MaHocKy = (System.String)reader["MaHocKy"];
			c.EntityTrackingKey = key;
			c.AcceptChanges();
			c.SuppressEntityEvents = false;
			}
			rows.Add(c);
		}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="QuanLyHocSinhPTNK.Entities.Diem"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="QuanLyHocSinhPTNK.Entities.Diem"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, QuanLyHocSinhPTNK.Entities.Diem entity)
		{
			if (!reader.Read()) return;
			
			entity.MaDiem = (System.String)reader["MaDiem"];
			entity.OriginalMaDiem = (System.String)reader["MaDiem"];
			entity.Diem15Phut = (System.Double)reader["Diem15Phut"];
			entity.Diem1Tiet = (System.Double)reader["Diem1Tiet"];
			entity.DiemCuoiKy = (System.Double)reader["DiemCuoiKy"];
			entity.Dtb = (System.Double)reader["DTB"];
			entity.MaMon = (System.String)reader["MaMon"];
			entity.MaBangDiem = (System.String)reader["MaBangDiem"];
			entity.MaHocKy = (System.String)reader["MaHocKy"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="QuanLyHocSinhPTNK.Entities.Diem"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="QuanLyHocSinhPTNK.Entities.Diem"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, QuanLyHocSinhPTNK.Entities.Diem entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.MaDiem = (System.String)dataRow["MaDiem"];
			entity.OriginalMaDiem = (System.String)dataRow["MaDiem"];
			entity.Diem15Phut = (System.Double)dataRow["Diem15Phut"];
			entity.Diem1Tiet = (System.Double)dataRow["Diem1Tiet"];
			entity.DiemCuoiKy = (System.Double)dataRow["DiemCuoiKy"];
			entity.Dtb = (System.Double)dataRow["DTB"];
			entity.MaMon = (System.String)dataRow["MaMon"];
			entity.MaBangDiem = (System.String)dataRow["MaBangDiem"];
			entity.MaHocKy = (System.String)dataRow["MaHocKy"];
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
		/// <param name="entity">The <see cref="QuanLyHocSinhPTNK.Entities.Diem"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">QuanLyHocSinhPTNK.Entities.Diem Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.Diem entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region MaMonSource	
			if (CanDeepLoad(entity, "MonHoc|MaMonSource", deepLoadType, innerList) 
				&& entity.MaMonSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.MaMon;
				MonHoc tmpEntity = EntityManager.LocateEntity<MonHoc>(EntityLocator.ConstructKeyFromPkItems(typeof(MonHoc), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.MaMonSource = tmpEntity;
				else
					entity.MaMonSource = DataRepository.MonHocProvider.GetByMaMon(transactionManager, entity.MaMon);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MaMonSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.MaMonSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.MonHocProvider.DeepLoad(transactionManager, entity.MaMonSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion MaMonSource

			#region MaHocKySource	
			if (CanDeepLoad(entity, "HocKy|MaHocKySource", deepLoadType, innerList) 
				&& entity.MaHocKySource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.MaHocKy;
				HocKy tmpEntity = EntityManager.LocateEntity<HocKy>(EntityLocator.ConstructKeyFromPkItems(typeof(HocKy), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.MaHocKySource = tmpEntity;
				else
					entity.MaHocKySource = DataRepository.HocKyProvider.GetByMaHocKy(transactionManager, entity.MaHocKy);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MaHocKySource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.MaHocKySource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.HocKyProvider.DeepLoad(transactionManager, entity.MaHocKySource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion MaHocKySource

			#region MaBangDiemSource	
			if (CanDeepLoad(entity, "BangDiem|MaBangDiemSource", deepLoadType, innerList) 
				&& entity.MaBangDiemSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.MaBangDiem;
				BangDiem tmpEntity = EntityManager.LocateEntity<BangDiem>(EntityLocator.ConstructKeyFromPkItems(typeof(BangDiem), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.MaBangDiemSource = tmpEntity;
				else
					entity.MaBangDiemSource = DataRepository.BangDiemProvider.GetByMaBangDiem(transactionManager, entity.MaBangDiem);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MaBangDiemSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.MaBangDiemSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.BangDiemProvider.DeepLoad(transactionManager, entity.MaBangDiemSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion MaBangDiemSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			
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
		/// Deep Save the entire object graph of the QuanLyHocSinhPTNK.Entities.Diem object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">QuanLyHocSinhPTNK.Entities.Diem instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">QuanLyHocSinhPTNK.Entities.Diem Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.Diem entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region MaMonSource
			if (CanDeepSave(entity, "MonHoc|MaMonSource", deepSaveType, innerList) 
				&& entity.MaMonSource != null)
			{
				DataRepository.MonHocProvider.Save(transactionManager, entity.MaMonSource);
				entity.MaMon = entity.MaMonSource.MaMon;
			}
			#endregion 
			
			#region MaHocKySource
			if (CanDeepSave(entity, "HocKy|MaHocKySource", deepSaveType, innerList) 
				&& entity.MaHocKySource != null)
			{
				DataRepository.HocKyProvider.Save(transactionManager, entity.MaHocKySource);
				entity.MaHocKy = entity.MaHocKySource.MaHocKy;
			}
			#endregion 
			
			#region MaBangDiemSource
			if (CanDeepSave(entity, "BangDiem|MaBangDiemSource", deepSaveType, innerList) 
				&& entity.MaBangDiemSource != null)
			{
				DataRepository.BangDiemProvider.Save(transactionManager, entity.MaBangDiemSource);
				entity.MaBangDiem = entity.MaBangDiemSource.MaBangDiem;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<Delegate, object> deepHandles = new Dictionary<Delegate, object>();
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
	
	#region DiemChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>QuanLyHocSinhPTNK.Entities.Diem</c>
	///</summary>
	public enum DiemChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>MonHoc</c> at MaMonSource
		///</summary>
		[ChildEntityType(typeof(MonHoc))]
		MonHoc,
			
		///<summary>
		/// Composite Property for <c>HocKy</c> at MaHocKySource
		///</summary>
		[ChildEntityType(typeof(HocKy))]
		HocKy,
			
		///<summary>
		/// Composite Property for <c>BangDiem</c> at MaBangDiemSource
		///</summary>
		[ChildEntityType(typeof(BangDiem))]
		BangDiem,
		}
	
	#endregion DiemChildEntityTypes
	
	#region DiemFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;DiemColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Diem"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DiemFilterBuilder : SqlFilterBuilder<DiemColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DiemFilterBuilder class.
		/// </summary>
		public DiemFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DiemFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DiemFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DiemFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DiemFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DiemFilterBuilder
	
	#region DiemParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;DiemColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Diem"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DiemParameterBuilder : ParameterizedSqlFilterBuilder<DiemColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DiemParameterBuilder class.
		/// </summary>
		public DiemParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DiemParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DiemParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DiemParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DiemParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DiemParameterBuilder
} // end namespace
