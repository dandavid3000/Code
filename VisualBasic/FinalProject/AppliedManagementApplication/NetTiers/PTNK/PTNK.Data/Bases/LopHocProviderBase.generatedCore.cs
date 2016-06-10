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
	/// This class is the base class for any <see cref="LopHocProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class LopHocProviderBaseCore : EntityProviderBase<PTNK.Entities.LopHoc, PTNK.Entities.LopHocKey>
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
		public override bool Delete(TransactionManager transactionManager, PTNK.Entities.LopHocKey key)
		{
			return Delete(transactionManager, key.MaLopHoc);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="maLopHoc">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String maLopHoc)
		{
			return Delete(null, maLopHoc);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maLopHoc">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String maLopHoc);		
		
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
		public override PTNK.Entities.LopHoc Get(TransactionManager transactionManager, PTNK.Entities.LopHocKey key, int start, int pageLength)
		{
			return GetByMaLopHoc(transactionManager, key.MaLopHoc, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key LopHoc$PrimaryKey index.
		/// </summary>
		/// <param name="maLopHoc"></param>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.LopHoc"/> class.</returns>
		public PTNK.Entities.LopHoc GetByMaLopHoc(System.String maLopHoc)
		{
			int count = -1;
			return GetByMaLopHoc(null,maLopHoc, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the LopHoc$PrimaryKey index.
		/// </summary>
		/// <param name="maLopHoc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.LopHoc"/> class.</returns>
		public PTNK.Entities.LopHoc GetByMaLopHoc(System.String maLopHoc, int start, int pageLength)
		{
			int count = -1;
			return GetByMaLopHoc(null, maLopHoc, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the LopHoc$PrimaryKey index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maLopHoc"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.LopHoc"/> class.</returns>
		public PTNK.Entities.LopHoc GetByMaLopHoc(TransactionManager transactionManager, System.String maLopHoc)
		{
			int count = -1;
			return GetByMaLopHoc(transactionManager, maLopHoc, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the LopHoc$PrimaryKey index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maLopHoc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.LopHoc"/> class.</returns>
		public PTNK.Entities.LopHoc GetByMaLopHoc(TransactionManager transactionManager, System.String maLopHoc, int start, int pageLength)
		{
			int count = -1;
			return GetByMaLopHoc(transactionManager, maLopHoc, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the LopHoc$PrimaryKey index.
		/// </summary>
		/// <param name="maLopHoc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.LopHoc"/> class.</returns>
		public PTNK.Entities.LopHoc GetByMaLopHoc(System.String maLopHoc, int start, int pageLength, out int count)
		{
			return GetByMaLopHoc(null, maLopHoc, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the LopHoc$PrimaryKey index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maLopHoc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.LopHoc"/> class.</returns>
		public abstract PTNK.Entities.LopHoc GetByMaLopHoc(TransactionManager transactionManager, System.String maLopHoc, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key LopHoc$KhoiLopHoc index.
		/// </summary>
		/// <param name="maKhoi"></param>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;LopHoc&gt;"/> class.</returns>
		public PTNK.Entities.TList<LopHoc> GetByMaKhoi(System.String maKhoi)
		{
			int count = -1;
			return GetByMaKhoi(null,maKhoi, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the LopHoc$KhoiLopHoc index.
		/// </summary>
		/// <param name="maKhoi"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;LopHoc&gt;"/> class.</returns>
		public PTNK.Entities.TList<LopHoc> GetByMaKhoi(System.String maKhoi, int start, int pageLength)
		{
			int count = -1;
			return GetByMaKhoi(null, maKhoi, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the LopHoc$KhoiLopHoc index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maKhoi"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;LopHoc&gt;"/> class.</returns>
		public PTNK.Entities.TList<LopHoc> GetByMaKhoi(TransactionManager transactionManager, System.String maKhoi)
		{
			int count = -1;
			return GetByMaKhoi(transactionManager, maKhoi, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the LopHoc$KhoiLopHoc index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maKhoi"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;LopHoc&gt;"/> class.</returns>
		public PTNK.Entities.TList<LopHoc> GetByMaKhoi(TransactionManager transactionManager, System.String maKhoi, int start, int pageLength)
		{
			int count = -1;
			return GetByMaKhoi(transactionManager, maKhoi, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the LopHoc$KhoiLopHoc index.
		/// </summary>
		/// <param name="maKhoi"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;LopHoc&gt;"/> class.</returns>
		public PTNK.Entities.TList<LopHoc> GetByMaKhoi(System.String maKhoi, int start, int pageLength, out int count)
		{
			return GetByMaKhoi(null, maKhoi, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the LopHoc$KhoiLopHoc index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maKhoi"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;LopHoc&gt;"/> class.</returns>
		public abstract PTNK.Entities.TList<LopHoc> GetByMaKhoi(TransactionManager transactionManager, System.String maKhoi, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a PTNK.Entities.TList&lt;LopHoc&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="PTNK.Entities.TList&lt;LopHoc&gt;"/></returns>
		public static PTNK.Entities.TList<LopHoc> Fill(IDataReader reader, PTNK.Entities.TList<LopHoc> rows, int start, int pageLength)
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
			
			PTNK.Entities.LopHoc c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("LopHoc")
			.Append("|").Append((reader.IsDBNull(((int)PTNK.Entities.LopHocColumn.MaLopHoc - 1))?string.Empty:(System.String)reader[((int)PTNK.Entities.LopHocColumn.MaLopHoc - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<LopHoc>(
			key.ToString(), // EntityTrackingKey
			"LopHoc",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new PTNK.Entities.LopHoc();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.MaLopHoc = (System.String)reader["MaLopHoc"];
			c.OriginalMaLopHoc = c.MaLopHoc;
			c.TenLopHoc = reader.IsDBNull(reader.GetOrdinal("TenLopHoc")) ? null : (System.String)reader["TenLopHoc"];
			c.MaKhoi = reader.IsDBNull(reader.GetOrdinal("MaKhoi")) ? null : (System.String)reader["MaKhoi"];
			c.EntityTrackingKey = key;
			c.AcceptChanges();
			c.SuppressEntityEvents = false;
			}
			rows.Add(c);
		}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="PTNK.Entities.LopHoc"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="PTNK.Entities.LopHoc"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, PTNK.Entities.LopHoc entity)
		{
			if (!reader.Read()) return;
			
			entity.MaLopHoc = (System.String)reader["MaLopHoc"];
			entity.OriginalMaLopHoc = (System.String)reader["MaLopHoc"];
			entity.TenLopHoc = reader.IsDBNull(reader.GetOrdinal("TenLopHoc")) ? null : (System.String)reader["TenLopHoc"];
			entity.MaKhoi = reader.IsDBNull(reader.GetOrdinal("MaKhoi")) ? null : (System.String)reader["MaKhoi"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="PTNK.Entities.LopHoc"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="PTNK.Entities.LopHoc"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, PTNK.Entities.LopHoc entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.MaLopHoc = (System.String)dataRow["MaLopHoc"];
			entity.OriginalMaLopHoc = (System.String)dataRow["MaLopHoc"];
			entity.TenLopHoc = Convert.IsDBNull(dataRow["TenLopHoc"]) ? null : (System.String)dataRow["TenLopHoc"];
			entity.MaKhoi = Convert.IsDBNull(dataRow["MaKhoi"]) ? null : (System.String)dataRow["MaKhoi"];
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
		/// <param name="entity">The <see cref="PTNK.Entities.LopHoc"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">PTNK.Entities.LopHoc Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, PTNK.Entities.LopHoc entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region MaKhoiSource	
			if (CanDeepLoad(entity, "Khoi|MaKhoiSource", deepLoadType, innerList) 
				&& entity.MaKhoiSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.MaKhoi ?? string.Empty);
				Khoi tmpEntity = EntityManager.LocateEntity<Khoi>(EntityLocator.ConstructKeyFromPkItems(typeof(Khoi), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.MaKhoiSource = tmpEntity;
				else
					entity.MaKhoiSource = DataRepository.KhoiProvider.GetByMaKhoi(transactionManager, (entity.MaKhoi ?? string.Empty));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MaKhoiSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.MaKhoiSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.KhoiProvider.DeepLoad(transactionManager, entity.MaKhoiSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion MaKhoiSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByMaLopHoc methods when available
			
			#region PhanCongCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<PhanCong>|PhanCongCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'PhanCongCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.PhanCongCollection = DataRepository.PhanCongProvider.GetByMaLopHoc(transactionManager, entity.MaLopHoc);

				if (deep && entity.PhanCongCollection.Count > 0)
				{
					deepHandles.Add("PhanCongCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<PhanCong>) DataRepository.PhanCongProvider.DeepLoad,
						new object[] { transactionManager, entity.PhanCongCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region RangBuocLopHocCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<RangBuocLopHoc>|RangBuocLopHocCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'RangBuocLopHocCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.RangBuocLopHocCollection = DataRepository.RangBuocLopHocProvider.GetByMaLopHoc(transactionManager, entity.MaLopHoc);

				if (deep && entity.RangBuocLopHocCollection.Count > 0)
				{
					deepHandles.Add("RangBuocLopHocCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<RangBuocLopHoc>) DataRepository.RangBuocLopHocProvider.DeepLoad,
						new object[] { transactionManager, entity.RangBuocLopHocCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the PTNK.Entities.LopHoc object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">PTNK.Entities.LopHoc instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">PTNK.Entities.LopHoc Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, PTNK.Entities.LopHoc entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region MaKhoiSource
			if (CanDeepSave(entity, "Khoi|MaKhoiSource", deepSaveType, innerList) 
				&& entity.MaKhoiSource != null)
			{
				DataRepository.KhoiProvider.Save(transactionManager, entity.MaKhoiSource);
				entity.MaKhoi = entity.MaKhoiSource.MaKhoi;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<Delegate, object> deepHandles = new Dictionary<Delegate, object>();
	
			#region List<PhanCong>
				if (CanDeepSave(entity.PhanCongCollection, "List<PhanCong>|PhanCongCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(PhanCong child in entity.PhanCongCollection)
					{
						if(child.MaLopHocSource != null)
							child.MaLopHoc = child.MaLopHocSource.MaLopHoc;
						else
							child.MaLopHoc = entity.MaLopHoc;

					}

					if (entity.PhanCongCollection.Count > 0 || entity.PhanCongCollection.DeletedItems.Count > 0)
					{
						DataRepository.PhanCongProvider.Save(transactionManager, entity.PhanCongCollection);
						
						deepHandles.Add(
							(DeepSaveHandle< PhanCong >) DataRepository.PhanCongProvider.DeepSave,
							new object[] { transactionManager, entity.PhanCongCollection, deepSaveType, childTypes, innerList }
						);
					}
				} 
			#endregion 
				
	
			#region List<RangBuocLopHoc>
				if (CanDeepSave(entity.RangBuocLopHocCollection, "List<RangBuocLopHoc>|RangBuocLopHocCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(RangBuocLopHoc child in entity.RangBuocLopHocCollection)
					{
						if(child.MaLopHocSource != null)
							child.MaLopHoc = child.MaLopHocSource.MaLopHoc;
						else
							child.MaLopHoc = entity.MaLopHoc;

					}

					if (entity.RangBuocLopHocCollection.Count > 0 || entity.RangBuocLopHocCollection.DeletedItems.Count > 0)
					{
						DataRepository.RangBuocLopHocProvider.Save(transactionManager, entity.RangBuocLopHocCollection);
						
						deepHandles.Add(
							(DeepSaveHandle< RangBuocLopHoc >) DataRepository.RangBuocLopHocProvider.DeepSave,
							new object[] { transactionManager, entity.RangBuocLopHocCollection, deepSaveType, childTypes, innerList }
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
	
	#region LopHocChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>PTNK.Entities.LopHoc</c>
	///</summary>
	public enum LopHocChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Khoi</c> at MaKhoiSource
		///</summary>
		[ChildEntityType(typeof(Khoi))]
		Khoi,
	
		///<summary>
		/// Collection of <c>LopHoc</c> as OneToMany for PhanCongCollection
		///</summary>
		[ChildEntityType(typeof(TList<PhanCong>))]
		PhanCongCollection,

		///<summary>
		/// Collection of <c>LopHoc</c> as OneToMany for RangBuocLopHocCollection
		///</summary>
		[ChildEntityType(typeof(TList<RangBuocLopHoc>))]
		RangBuocLopHocCollection,
	}
	
	#endregion LopHocChildEntityTypes
	
	#region LopHocFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;LopHocColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LopHoc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LopHocFilterBuilder : SqlFilterBuilder<LopHocColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LopHocFilterBuilder class.
		/// </summary>
		public LopHocFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LopHocFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LopHocFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LopHocFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LopHocFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LopHocFilterBuilder
	
	#region LopHocParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;LopHocColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LopHoc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LopHocParameterBuilder : ParameterizedSqlFilterBuilder<LopHocColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LopHocParameterBuilder class.
		/// </summary>
		public LopHocParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LopHocParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LopHocParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LopHocParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LopHocParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LopHocParameterBuilder
} // end namespace
