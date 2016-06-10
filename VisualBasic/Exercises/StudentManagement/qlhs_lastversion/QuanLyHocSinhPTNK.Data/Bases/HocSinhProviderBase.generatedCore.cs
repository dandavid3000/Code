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
	/// This class is the base class for any <see cref="HocSinhProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class HocSinhProviderBaseCore : EntityProviderBase<QuanLyHocSinhPTNK.Entities.HocSinh, QuanLyHocSinhPTNK.Entities.HocSinhKey>
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
		public override bool Delete(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.HocSinhKey key)
		{
			return Delete(transactionManager, key.MaHocSinh);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="maHocSinh">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String maHocSinh)
		{
			return Delete(null, maHocSinh);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maHocSinh">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String maHocSinh);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_HocSinh_LopHoc key.
		///		FK_HocSinh_LopHoc Description: 
		/// </summary>
		/// <param name="maLop"></param>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.HocSinh objects.</returns>
		public QuanLyHocSinhPTNK.Entities.TList<HocSinh> GetByMaLop(System.String maLop)
		{
			int count = -1;
			return GetByMaLop(maLop, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_HocSinh_LopHoc key.
		///		FK_HocSinh_LopHoc Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maLop"></param>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.HocSinh objects.</returns>
		/// <remarks></remarks>
		public QuanLyHocSinhPTNK.Entities.TList<HocSinh> GetByMaLop(TransactionManager transactionManager, System.String maLop)
		{
			int count = -1;
			return GetByMaLop(transactionManager, maLop, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_HocSinh_LopHoc key.
		///		FK_HocSinh_LopHoc Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maLop"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.HocSinh objects.</returns>
		public QuanLyHocSinhPTNK.Entities.TList<HocSinh> GetByMaLop(TransactionManager transactionManager, System.String maLop, int start, int pageLength)
		{
			int count = -1;
			return GetByMaLop(transactionManager, maLop, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_HocSinh_LopHoc key.
		///		fkHocSinhLopHoc Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="maLop"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.HocSinh objects.</returns>
		public QuanLyHocSinhPTNK.Entities.TList<HocSinh> GetByMaLop(System.String maLop, int start, int pageLength)
		{
			int count =  -1;
			return GetByMaLop(null, maLop, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_HocSinh_LopHoc key.
		///		fkHocSinhLopHoc Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="maLop"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.HocSinh objects.</returns>
		public QuanLyHocSinhPTNK.Entities.TList<HocSinh> GetByMaLop(System.String maLop, int start, int pageLength,out int count)
		{
			return GetByMaLop(null, maLop, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_HocSinh_LopHoc key.
		///		FK_HocSinh_LopHoc Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maLop"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.HocSinh objects.</returns>
		public abstract QuanLyHocSinhPTNK.Entities.TList<HocSinh> GetByMaLop(TransactionManager transactionManager, System.String maLop, int start, int pageLength, out int count);
		
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
		public override QuanLyHocSinhPTNK.Entities.HocSinh Get(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.HocSinhKey key, int start, int pageLength)
		{
			return GetByMaHocSinh(transactionManager, key.MaHocSinh, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_HocSinh index.
		/// </summary>
		/// <param name="maHocSinh"></param>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.HocSinh"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.HocSinh GetByMaHocSinh(System.String maHocSinh)
		{
			int count = -1;
			return GetByMaHocSinh(null,maHocSinh, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_HocSinh index.
		/// </summary>
		/// <param name="maHocSinh"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.HocSinh"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.HocSinh GetByMaHocSinh(System.String maHocSinh, int start, int pageLength)
		{
			int count = -1;
			return GetByMaHocSinh(null, maHocSinh, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_HocSinh index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maHocSinh"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.HocSinh"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.HocSinh GetByMaHocSinh(TransactionManager transactionManager, System.String maHocSinh)
		{
			int count = -1;
			return GetByMaHocSinh(transactionManager, maHocSinh, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_HocSinh index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maHocSinh"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.HocSinh"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.HocSinh GetByMaHocSinh(TransactionManager transactionManager, System.String maHocSinh, int start, int pageLength)
		{
			int count = -1;
			return GetByMaHocSinh(transactionManager, maHocSinh, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_HocSinh index.
		/// </summary>
		/// <param name="maHocSinh"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.HocSinh"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.HocSinh GetByMaHocSinh(System.String maHocSinh, int start, int pageLength, out int count)
		{
			return GetByMaHocSinh(null, maHocSinh, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_HocSinh index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maHocSinh"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.HocSinh"/> class.</returns>
		public abstract QuanLyHocSinhPTNK.Entities.HocSinh GetByMaHocSinh(TransactionManager transactionManager, System.String maHocSinh, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a QuanLyHocSinhPTNK.Entities.TList&lt;HocSinh&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="QuanLyHocSinhPTNK.Entities.TList&lt;HocSinh&gt;"/></returns>
		public static QuanLyHocSinhPTNK.Entities.TList<HocSinh> Fill(IDataReader reader, QuanLyHocSinhPTNK.Entities.TList<HocSinh> rows, int start, int pageLength)
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
			
			QuanLyHocSinhPTNK.Entities.HocSinh c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("HocSinh")
			.Append("|").Append((reader.IsDBNull(((int)QuanLyHocSinhPTNK.Entities.HocSinhColumn.MaHocSinh - 1))?string.Empty:(System.String)reader[((int)QuanLyHocSinhPTNK.Entities.HocSinhColumn.MaHocSinh - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<HocSinh>(
			key.ToString(), // EntityTrackingKey
			"HocSinh",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new QuanLyHocSinhPTNK.Entities.HocSinh();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.MaHocSinh = (System.String)reader["MaHocSinh"];
			c.OriginalMaHocSinh = c.MaHocSinh;
			c.HoTenHocSinh = (System.String)reader["HoTenHocSinh"];
			c.GioiTinh = (System.String)reader["GioiTinh"];
			c.NgaySinh = (System.DateTime)reader["NgaySinh"];
			c.DiaChi = (System.String)reader["DiaChi"];
			c.Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : (System.String)reader["Email"];
			c.XepLoai = (System.String)reader["XepLoai"];
			c.HanhKiem = (System.String)reader["HanhKiem"];
			c.Password = (System.String)reader["Password"];
			c.MaLop = (System.String)reader["MaLop"];
			c.EntityTrackingKey = key;
			c.AcceptChanges();
			c.SuppressEntityEvents = false;
			}
			rows.Add(c);
		}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="QuanLyHocSinhPTNK.Entities.HocSinh"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="QuanLyHocSinhPTNK.Entities.HocSinh"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, QuanLyHocSinhPTNK.Entities.HocSinh entity)
		{
			if (!reader.Read()) return;
			
			entity.MaHocSinh = (System.String)reader["MaHocSinh"];
			entity.OriginalMaHocSinh = (System.String)reader["MaHocSinh"];
			entity.HoTenHocSinh = (System.String)reader["HoTenHocSinh"];
			entity.GioiTinh = (System.String)reader["GioiTinh"];
			entity.NgaySinh = (System.DateTime)reader["NgaySinh"];
			entity.DiaChi = (System.String)reader["DiaChi"];
			entity.Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : (System.String)reader["Email"];
			entity.XepLoai = (System.String)reader["XepLoai"];
			entity.HanhKiem = (System.String)reader["HanhKiem"];
			entity.Password = (System.String)reader["Password"];
			entity.MaLop = (System.String)reader["MaLop"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="QuanLyHocSinhPTNK.Entities.HocSinh"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="QuanLyHocSinhPTNK.Entities.HocSinh"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, QuanLyHocSinhPTNK.Entities.HocSinh entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.MaHocSinh = (System.String)dataRow["MaHocSinh"];
			entity.OriginalMaHocSinh = (System.String)dataRow["MaHocSinh"];
			entity.HoTenHocSinh = (System.String)dataRow["HoTenHocSinh"];
			entity.GioiTinh = (System.String)dataRow["GioiTinh"];
			entity.NgaySinh = (System.DateTime)dataRow["NgaySinh"];
			entity.DiaChi = (System.String)dataRow["DiaChi"];
			entity.Email = Convert.IsDBNull(dataRow["Email"]) ? null : (System.String)dataRow["Email"];
			entity.XepLoai = (System.String)dataRow["XepLoai"];
			entity.HanhKiem = (System.String)dataRow["HanhKiem"];
			entity.Password = (System.String)dataRow["Password"];
			entity.MaLop = (System.String)dataRow["MaLop"];
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
		/// <param name="entity">The <see cref="QuanLyHocSinhPTNK.Entities.HocSinh"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">QuanLyHocSinhPTNK.Entities.HocSinh Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.HocSinh entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region MaLopSource	
			if (CanDeepLoad(entity, "LopHoc|MaLopSource", deepLoadType, innerList) 
				&& entity.MaLopSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.MaLop;
				LopHoc tmpEntity = EntityManager.LocateEntity<LopHoc>(EntityLocator.ConstructKeyFromPkItems(typeof(LopHoc), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.MaLopSource = tmpEntity;
				else
					entity.MaLopSource = DataRepository.LopHocProvider.GetByMaLop(transactionManager, entity.MaLop);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MaLopSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.MaLopSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.LopHocProvider.DeepLoad(transactionManager, entity.MaLopSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion MaLopSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByMaHocSinh methods when available
			
			#region BangDiemCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<BangDiem>|BangDiemCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'BangDiemCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.BangDiemCollection = DataRepository.BangDiemProvider.GetByMaHocSinh(transactionManager, entity.MaHocSinh);

				if (deep && entity.BangDiemCollection.Count > 0)
				{
					deepHandles.Add("BangDiemCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<BangDiem>) DataRepository.BangDiemProvider.DeepLoad,
						new object[] { transactionManager, entity.BangDiemCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the QuanLyHocSinhPTNK.Entities.HocSinh object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">QuanLyHocSinhPTNK.Entities.HocSinh instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">QuanLyHocSinhPTNK.Entities.HocSinh Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.HocSinh entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region MaLopSource
			if (CanDeepSave(entity, "LopHoc|MaLopSource", deepSaveType, innerList) 
				&& entity.MaLopSource != null)
			{
				DataRepository.LopHocProvider.Save(transactionManager, entity.MaLopSource);
				entity.MaLop = entity.MaLopSource.MaLop;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<Delegate, object> deepHandles = new Dictionary<Delegate, object>();
	
			#region List<BangDiem>
				if (CanDeepSave(entity.BangDiemCollection, "List<BangDiem>|BangDiemCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(BangDiem child in entity.BangDiemCollection)
					{
						if(child.MaHocSinhSource != null)
							child.MaHocSinh = child.MaHocSinhSource.MaHocSinh;
						else
							child.MaHocSinh = entity.MaHocSinh;

					}

					if (entity.BangDiemCollection.Count > 0 || entity.BangDiemCollection.DeletedItems.Count > 0)
					{
						DataRepository.BangDiemProvider.Save(transactionManager, entity.BangDiemCollection);
						
						deepHandles.Add(
							(DeepSaveHandle< BangDiem >) DataRepository.BangDiemProvider.DeepSave,
							new object[] { transactionManager, entity.BangDiemCollection, deepSaveType, childTypes, innerList }
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
	
	#region HocSinhChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>QuanLyHocSinhPTNK.Entities.HocSinh</c>
	///</summary>
	public enum HocSinhChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>LopHoc</c> at MaLopSource
		///</summary>
		[ChildEntityType(typeof(LopHoc))]
		LopHoc,
	
		///<summary>
		/// Collection of <c>HocSinh</c> as OneToMany for BangDiemCollection
		///</summary>
		[ChildEntityType(typeof(TList<BangDiem>))]
		BangDiemCollection,
	}
	
	#endregion HocSinhChildEntityTypes
	
	#region HocSinhFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;HocSinhColumn&gt;"/> class
	/// that is used exclusively with a <see cref="HocSinh"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class HocSinhFilterBuilder : SqlFilterBuilder<HocSinhColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the HocSinhFilterBuilder class.
		/// </summary>
		public HocSinhFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the HocSinhFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public HocSinhFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the HocSinhFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public HocSinhFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion HocSinhFilterBuilder
	
	#region HocSinhParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;HocSinhColumn&gt;"/> class
	/// that is used exclusively with a <see cref="HocSinh"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class HocSinhParameterBuilder : ParameterizedSqlFilterBuilder<HocSinhColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the HocSinhParameterBuilder class.
		/// </summary>
		public HocSinhParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the HocSinhParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public HocSinhParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the HocSinhParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public HocSinhParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion HocSinhParameterBuilder
} // end namespace
