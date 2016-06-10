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
	/// This class is the base class for any <see cref="QuanLyProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class QuanLyProviderBaseCore : EntityProviderBase<QuanLyHocSinhPTNK.Entities.QuanLy, QuanLyHocSinhPTNK.Entities.QuanLyKey>
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
		public override bool Delete(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.QuanLyKey key)
		{
			return Delete(transactionManager, key.MaQuanLy);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="maQuanLy">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String maQuanLy)
		{
			return Delete(null, maQuanLy);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maQuanLy">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String maQuanLy);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QuanLy_ChucDanh key.
		///		FK_QuanLy_ChucDanh Description: 
		/// </summary>
		/// <param name="maChucDanh"></param>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.QuanLy objects.</returns>
		public QuanLyHocSinhPTNK.Entities.TList<QuanLy> GetByMaChucDanh(System.String maChucDanh)
		{
			int count = -1;
			return GetByMaChucDanh(maChucDanh, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QuanLy_ChucDanh key.
		///		FK_QuanLy_ChucDanh Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maChucDanh"></param>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.QuanLy objects.</returns>
		/// <remarks></remarks>
		public QuanLyHocSinhPTNK.Entities.TList<QuanLy> GetByMaChucDanh(TransactionManager transactionManager, System.String maChucDanh)
		{
			int count = -1;
			return GetByMaChucDanh(transactionManager, maChucDanh, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_QuanLy_ChucDanh key.
		///		FK_QuanLy_ChucDanh Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maChucDanh"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.QuanLy objects.</returns>
		public QuanLyHocSinhPTNK.Entities.TList<QuanLy> GetByMaChucDanh(TransactionManager transactionManager, System.String maChucDanh, int start, int pageLength)
		{
			int count = -1;
			return GetByMaChucDanh(transactionManager, maChucDanh, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QuanLy_ChucDanh key.
		///		fkQuanLyChucDanh Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="maChucDanh"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.QuanLy objects.</returns>
		public QuanLyHocSinhPTNK.Entities.TList<QuanLy> GetByMaChucDanh(System.String maChucDanh, int start, int pageLength)
		{
			int count =  -1;
			return GetByMaChucDanh(null, maChucDanh, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QuanLy_ChucDanh key.
		///		fkQuanLyChucDanh Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="maChucDanh"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.QuanLy objects.</returns>
		public QuanLyHocSinhPTNK.Entities.TList<QuanLy> GetByMaChucDanh(System.String maChucDanh, int start, int pageLength,out int count)
		{
			return GetByMaChucDanh(null, maChucDanh, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QuanLy_ChucDanh key.
		///		FK_QuanLy_ChucDanh Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maChucDanh"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.QuanLy objects.</returns>
		public abstract QuanLyHocSinhPTNK.Entities.TList<QuanLy> GetByMaChucDanh(TransactionManager transactionManager, System.String maChucDanh, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QuanLy_PhongBan key.
		///		FK_QuanLy_PhongBan Description: 
		/// </summary>
		/// <param name="maPhongBan"></param>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.QuanLy objects.</returns>
		public QuanLyHocSinhPTNK.Entities.TList<QuanLy> GetByMaPhongBan(System.String maPhongBan)
		{
			int count = -1;
			return GetByMaPhongBan(maPhongBan, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QuanLy_PhongBan key.
		///		FK_QuanLy_PhongBan Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maPhongBan"></param>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.QuanLy objects.</returns>
		/// <remarks></remarks>
		public QuanLyHocSinhPTNK.Entities.TList<QuanLy> GetByMaPhongBan(TransactionManager transactionManager, System.String maPhongBan)
		{
			int count = -1;
			return GetByMaPhongBan(transactionManager, maPhongBan, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_QuanLy_PhongBan key.
		///		FK_QuanLy_PhongBan Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maPhongBan"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.QuanLy objects.</returns>
		public QuanLyHocSinhPTNK.Entities.TList<QuanLy> GetByMaPhongBan(TransactionManager transactionManager, System.String maPhongBan, int start, int pageLength)
		{
			int count = -1;
			return GetByMaPhongBan(transactionManager, maPhongBan, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QuanLy_PhongBan key.
		///		fkQuanLyPhongBan Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="maPhongBan"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.QuanLy objects.</returns>
		public QuanLyHocSinhPTNK.Entities.TList<QuanLy> GetByMaPhongBan(System.String maPhongBan, int start, int pageLength)
		{
			int count =  -1;
			return GetByMaPhongBan(null, maPhongBan, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QuanLy_PhongBan key.
		///		fkQuanLyPhongBan Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="maPhongBan"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.QuanLy objects.</returns>
		public QuanLyHocSinhPTNK.Entities.TList<QuanLy> GetByMaPhongBan(System.String maPhongBan, int start, int pageLength,out int count)
		{
			return GetByMaPhongBan(null, maPhongBan, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QuanLy_PhongBan key.
		///		FK_QuanLy_PhongBan Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maPhongBan"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.QuanLy objects.</returns>
		public abstract QuanLyHocSinhPTNK.Entities.TList<QuanLy> GetByMaPhongBan(TransactionManager transactionManager, System.String maPhongBan, int start, int pageLength, out int count);
		
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
		public override QuanLyHocSinhPTNK.Entities.QuanLy Get(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.QuanLyKey key, int start, int pageLength)
		{
			return GetByMaQuanLy(transactionManager, key.MaQuanLy, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_QuanLy index.
		/// </summary>
		/// <param name="maQuanLy"></param>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.QuanLy"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.QuanLy GetByMaQuanLy(System.String maQuanLy)
		{
			int count = -1;
			return GetByMaQuanLy(null,maQuanLy, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_QuanLy index.
		/// </summary>
		/// <param name="maQuanLy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.QuanLy"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.QuanLy GetByMaQuanLy(System.String maQuanLy, int start, int pageLength)
		{
			int count = -1;
			return GetByMaQuanLy(null, maQuanLy, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_QuanLy index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maQuanLy"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.QuanLy"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.QuanLy GetByMaQuanLy(TransactionManager transactionManager, System.String maQuanLy)
		{
			int count = -1;
			return GetByMaQuanLy(transactionManager, maQuanLy, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_QuanLy index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maQuanLy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.QuanLy"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.QuanLy GetByMaQuanLy(TransactionManager transactionManager, System.String maQuanLy, int start, int pageLength)
		{
			int count = -1;
			return GetByMaQuanLy(transactionManager, maQuanLy, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_QuanLy index.
		/// </summary>
		/// <param name="maQuanLy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.QuanLy"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.QuanLy GetByMaQuanLy(System.String maQuanLy, int start, int pageLength, out int count)
		{
			return GetByMaQuanLy(null, maQuanLy, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_QuanLy index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maQuanLy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.QuanLy"/> class.</returns>
		public abstract QuanLyHocSinhPTNK.Entities.QuanLy GetByMaQuanLy(TransactionManager transactionManager, System.String maQuanLy, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a QuanLyHocSinhPTNK.Entities.TList&lt;QuanLy&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="QuanLyHocSinhPTNK.Entities.TList&lt;QuanLy&gt;"/></returns>
		public static QuanLyHocSinhPTNK.Entities.TList<QuanLy> Fill(IDataReader reader, QuanLyHocSinhPTNK.Entities.TList<QuanLy> rows, int start, int pageLength)
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
			
			QuanLyHocSinhPTNK.Entities.QuanLy c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("QuanLy")
			.Append("|").Append((reader.IsDBNull(((int)QuanLyHocSinhPTNK.Entities.QuanLyColumn.MaQuanLy - 1))?string.Empty:(System.String)reader[((int)QuanLyHocSinhPTNK.Entities.QuanLyColumn.MaQuanLy - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<QuanLy>(
			key.ToString(), // EntityTrackingKey
			"QuanLy",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new QuanLyHocSinhPTNK.Entities.QuanLy();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.MaQuanLy = (System.String)reader["MaQuanLy"];
			c.OriginalMaQuanLy = c.MaQuanLy;
			c.HoTenQuanLy = (System.String)reader["HoTenQuanLy"];
			c.Password = (System.String)reader["Password"];
			c.MaChucDanh = (System.String)reader["MaChucDanh"];
			c.MaPhongBan = (System.String)reader["MaPhongBan"];
			c.EntityTrackingKey = key;
			c.AcceptChanges();
			c.SuppressEntityEvents = false;
			}
			rows.Add(c);
		}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="QuanLyHocSinhPTNK.Entities.QuanLy"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="QuanLyHocSinhPTNK.Entities.QuanLy"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, QuanLyHocSinhPTNK.Entities.QuanLy entity)
		{
			if (!reader.Read()) return;
			
			entity.MaQuanLy = (System.String)reader["MaQuanLy"];
			entity.OriginalMaQuanLy = (System.String)reader["MaQuanLy"];
			entity.HoTenQuanLy = (System.String)reader["HoTenQuanLy"];
			entity.Password = (System.String)reader["Password"];
			entity.MaChucDanh = (System.String)reader["MaChucDanh"];
			entity.MaPhongBan = (System.String)reader["MaPhongBan"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="QuanLyHocSinhPTNK.Entities.QuanLy"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="QuanLyHocSinhPTNK.Entities.QuanLy"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, QuanLyHocSinhPTNK.Entities.QuanLy entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.MaQuanLy = (System.String)dataRow["MaQuanLy"];
			entity.OriginalMaQuanLy = (System.String)dataRow["MaQuanLy"];
			entity.HoTenQuanLy = (System.String)dataRow["HoTenQuanLy"];
			entity.Password = (System.String)dataRow["Password"];
			entity.MaChucDanh = (System.String)dataRow["MaChucDanh"];
			entity.MaPhongBan = (System.String)dataRow["MaPhongBan"];
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
		/// <param name="entity">The <see cref="QuanLyHocSinhPTNK.Entities.QuanLy"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">QuanLyHocSinhPTNK.Entities.QuanLy Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.QuanLy entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region MaChucDanhSource	
			if (CanDeepLoad(entity, "ChucDanh|MaChucDanhSource", deepLoadType, innerList) 
				&& entity.MaChucDanhSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.MaChucDanh;
				ChucDanh tmpEntity = EntityManager.LocateEntity<ChucDanh>(EntityLocator.ConstructKeyFromPkItems(typeof(ChucDanh), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.MaChucDanhSource = tmpEntity;
				else
					entity.MaChucDanhSource = DataRepository.ChucDanhProvider.GetByMaChucDanh(transactionManager, entity.MaChucDanh);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MaChucDanhSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.MaChucDanhSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ChucDanhProvider.DeepLoad(transactionManager, entity.MaChucDanhSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion MaChucDanhSource

			#region MaPhongBanSource	
			if (CanDeepLoad(entity, "PhongBan|MaPhongBanSource", deepLoadType, innerList) 
				&& entity.MaPhongBanSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.MaPhongBan;
				PhongBan tmpEntity = EntityManager.LocateEntity<PhongBan>(EntityLocator.ConstructKeyFromPkItems(typeof(PhongBan), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.MaPhongBanSource = tmpEntity;
				else
					entity.MaPhongBanSource = DataRepository.PhongBanProvider.GetByMaPhongBan(transactionManager, entity.MaPhongBan);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MaPhongBanSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.MaPhongBanSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.PhongBanProvider.DeepLoad(transactionManager, entity.MaPhongBanSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion MaPhongBanSource
			
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
		/// Deep Save the entire object graph of the QuanLyHocSinhPTNK.Entities.QuanLy object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">QuanLyHocSinhPTNK.Entities.QuanLy instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">QuanLyHocSinhPTNK.Entities.QuanLy Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.QuanLy entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region MaChucDanhSource
			if (CanDeepSave(entity, "ChucDanh|MaChucDanhSource", deepSaveType, innerList) 
				&& entity.MaChucDanhSource != null)
			{
				DataRepository.ChucDanhProvider.Save(transactionManager, entity.MaChucDanhSource);
				entity.MaChucDanh = entity.MaChucDanhSource.MaChucDanh;
			}
			#endregion 
			
			#region MaPhongBanSource
			if (CanDeepSave(entity, "PhongBan|MaPhongBanSource", deepSaveType, innerList) 
				&& entity.MaPhongBanSource != null)
			{
				DataRepository.PhongBanProvider.Save(transactionManager, entity.MaPhongBanSource);
				entity.MaPhongBan = entity.MaPhongBanSource.MaPhongBan;
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
	
	#region QuanLyChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>QuanLyHocSinhPTNK.Entities.QuanLy</c>
	///</summary>
	public enum QuanLyChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>ChucDanh</c> at MaChucDanhSource
		///</summary>
		[ChildEntityType(typeof(ChucDanh))]
		ChucDanh,
			
		///<summary>
		/// Composite Property for <c>PhongBan</c> at MaPhongBanSource
		///</summary>
		[ChildEntityType(typeof(PhongBan))]
		PhongBan,
		}
	
	#endregion QuanLyChildEntityTypes
	
	#region QuanLyFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;QuanLyColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuanLy"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuanLyFilterBuilder : SqlFilterBuilder<QuanLyColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuanLyFilterBuilder class.
		/// </summary>
		public QuanLyFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuanLyFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuanLyFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuanLyFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuanLyFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuanLyFilterBuilder
	
	#region QuanLyParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;QuanLyColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuanLy"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuanLyParameterBuilder : ParameterizedSqlFilterBuilder<QuanLyColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuanLyParameterBuilder class.
		/// </summary>
		public QuanLyParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuanLyParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuanLyParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuanLyParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuanLyParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuanLyParameterBuilder
} // end namespace
