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
	/// This class is the base class for any <see cref="GiaoVienProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class GiaoVienProviderBaseCore : EntityProviderBase<PTNK.Entities.GiaoVien, PTNK.Entities.GiaoVienKey>
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
		public override bool Delete(TransactionManager transactionManager, PTNK.Entities.GiaoVienKey key)
		{
			return Delete(transactionManager, key.MaGiaoVien);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="maGiaoVien">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String maGiaoVien)
		{
			return Delete(null, maGiaoVien);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maGiaoVien">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String maGiaoVien);		
		
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
		public override PTNK.Entities.GiaoVien Get(TransactionManager transactionManager, PTNK.Entities.GiaoVienKey key, int start, int pageLength)
		{
			return GetByMaGiaoVien(transactionManager, key.MaGiaoVien, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key GiaoVien$PrimaryKey index.
		/// </summary>
		/// <param name="maGiaoVien"></param>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.GiaoVien"/> class.</returns>
		public PTNK.Entities.GiaoVien GetByMaGiaoVien(System.String maGiaoVien)
		{
			int count = -1;
			return GetByMaGiaoVien(null,maGiaoVien, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the GiaoVien$PrimaryKey index.
		/// </summary>
		/// <param name="maGiaoVien"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.GiaoVien"/> class.</returns>
		public PTNK.Entities.GiaoVien GetByMaGiaoVien(System.String maGiaoVien, int start, int pageLength)
		{
			int count = -1;
			return GetByMaGiaoVien(null, maGiaoVien, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the GiaoVien$PrimaryKey index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maGiaoVien"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.GiaoVien"/> class.</returns>
		public PTNK.Entities.GiaoVien GetByMaGiaoVien(TransactionManager transactionManager, System.String maGiaoVien)
		{
			int count = -1;
			return GetByMaGiaoVien(transactionManager, maGiaoVien, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the GiaoVien$PrimaryKey index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maGiaoVien"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.GiaoVien"/> class.</returns>
		public PTNK.Entities.GiaoVien GetByMaGiaoVien(TransactionManager transactionManager, System.String maGiaoVien, int start, int pageLength)
		{
			int count = -1;
			return GetByMaGiaoVien(transactionManager, maGiaoVien, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the GiaoVien$PrimaryKey index.
		/// </summary>
		/// <param name="maGiaoVien"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.GiaoVien"/> class.</returns>
		public PTNK.Entities.GiaoVien GetByMaGiaoVien(System.String maGiaoVien, int start, int pageLength, out int count)
		{
			return GetByMaGiaoVien(null, maGiaoVien, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the GiaoVien$PrimaryKey index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maGiaoVien"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.GiaoVien"/> class.</returns>
		public abstract PTNK.Entities.GiaoVien GetByMaGiaoVien(TransactionManager transactionManager, System.String maGiaoVien, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a PTNK.Entities.TList&lt;GiaoVien&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="PTNK.Entities.TList&lt;GiaoVien&gt;"/></returns>
		public static PTNK.Entities.TList<GiaoVien> Fill(IDataReader reader, PTNK.Entities.TList<GiaoVien> rows, int start, int pageLength)
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
			
			PTNK.Entities.GiaoVien c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("GiaoVien")
			.Append("|").Append((reader.IsDBNull(((int)PTNK.Entities.GiaoVienColumn.MaGiaoVien - 1))?string.Empty:(System.String)reader[((int)PTNK.Entities.GiaoVienColumn.MaGiaoVien - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<GiaoVien>(
			key.ToString(), // EntityTrackingKey
			"GiaoVien",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new PTNK.Entities.GiaoVien();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.MaGiaoVien = (System.String)reader["MaGiaoVien"];
			c.OriginalMaGiaoVien = c.MaGiaoVien;
			c.HoTenGiaoVien = reader.IsDBNull(reader.GetOrdinal("HoTenGiaoVien")) ? null : (System.String)reader["HoTenGiaoVien"];
			c.TenTat = reader.IsDBNull(reader.GetOrdinal("TenTat")) ? null : (System.String)reader["TenTat"];
			c.DiaChi = reader.IsDBNull(reader.GetOrdinal("DiaChi")) ? null : (System.String)reader["DiaChi"];
			c.DienThoai = reader.IsDBNull(reader.GetOrdinal("DienThoai")) ? null : (System.String)reader["DienThoai"];
			c.EntityTrackingKey = key;
			c.AcceptChanges();
			c.SuppressEntityEvents = false;
			}
			rows.Add(c);
		}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="PTNK.Entities.GiaoVien"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="PTNK.Entities.GiaoVien"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, PTNK.Entities.GiaoVien entity)
		{
			if (!reader.Read()) return;
			
			entity.MaGiaoVien = (System.String)reader["MaGiaoVien"];
			entity.OriginalMaGiaoVien = (System.String)reader["MaGiaoVien"];
			entity.HoTenGiaoVien = reader.IsDBNull(reader.GetOrdinal("HoTenGiaoVien")) ? null : (System.String)reader["HoTenGiaoVien"];
			entity.TenTat = reader.IsDBNull(reader.GetOrdinal("TenTat")) ? null : (System.String)reader["TenTat"];
			entity.DiaChi = reader.IsDBNull(reader.GetOrdinal("DiaChi")) ? null : (System.String)reader["DiaChi"];
			entity.DienThoai = reader.IsDBNull(reader.GetOrdinal("DienThoai")) ? null : (System.String)reader["DienThoai"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="PTNK.Entities.GiaoVien"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="PTNK.Entities.GiaoVien"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, PTNK.Entities.GiaoVien entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.MaGiaoVien = (System.String)dataRow["MaGiaoVien"];
			entity.OriginalMaGiaoVien = (System.String)dataRow["MaGiaoVien"];
			entity.HoTenGiaoVien = Convert.IsDBNull(dataRow["HoTenGiaoVien"]) ? null : (System.String)dataRow["HoTenGiaoVien"];
			entity.TenTat = Convert.IsDBNull(dataRow["TenTat"]) ? null : (System.String)dataRow["TenTat"];
			entity.DiaChi = Convert.IsDBNull(dataRow["DiaChi"]) ? null : (System.String)dataRow["DiaChi"];
			entity.DienThoai = Convert.IsDBNull(dataRow["DienThoai"]) ? null : (System.String)dataRow["DienThoai"];
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
		/// <param name="entity">The <see cref="PTNK.Entities.GiaoVien"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">PTNK.Entities.GiaoVien Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, PTNK.Entities.GiaoVien entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByMaGiaoVien methods when available
			
			#region PhuTrachCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<PhuTrach>|PhuTrachCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'PhuTrachCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.PhuTrachCollection = DataRepository.PhuTrachProvider.GetByMaGiaoVien(transactionManager, entity.MaGiaoVien);

				if (deep && entity.PhuTrachCollection.Count > 0)
				{
					deepHandles.Add("PhuTrachCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<PhuTrach>) DataRepository.PhuTrachProvider.DeepLoad,
						new object[] { transactionManager, entity.PhuTrachCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region PhanCongCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<PhanCong>|PhanCongCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'PhanCongCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.PhanCongCollection = DataRepository.PhanCongProvider.GetByMaGiaoVien(transactionManager, entity.MaGiaoVien);

				if (deep && entity.PhanCongCollection.Count > 0)
				{
					deepHandles.Add("PhanCongCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<PhanCong>) DataRepository.PhanCongProvider.DeepLoad,
						new object[] { transactionManager, entity.PhanCongCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region RangBuocGiaoVienCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<RangBuocGiaoVien>|RangBuocGiaoVienCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'RangBuocGiaoVienCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.RangBuocGiaoVienCollection = DataRepository.RangBuocGiaoVienProvider.GetByMaGiaoVien(transactionManager, entity.MaGiaoVien);

				if (deep && entity.RangBuocGiaoVienCollection.Count > 0)
				{
					deepHandles.Add("RangBuocGiaoVienCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<RangBuocGiaoVien>) DataRepository.RangBuocGiaoVienProvider.DeepLoad,
						new object[] { transactionManager, entity.RangBuocGiaoVienCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the PTNK.Entities.GiaoVien object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">PTNK.Entities.GiaoVien instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">PTNK.Entities.GiaoVien Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, PTNK.Entities.GiaoVien entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<Delegate, object> deepHandles = new Dictionary<Delegate, object>();
	
			#region List<PhuTrach>
				if (CanDeepSave(entity.PhuTrachCollection, "List<PhuTrach>|PhuTrachCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(PhuTrach child in entity.PhuTrachCollection)
					{
						if(child.MaGiaoVienSource != null)
							child.MaGiaoVien = child.MaGiaoVienSource.MaGiaoVien;
						else
							child.MaGiaoVien = entity.MaGiaoVien;

					}

					if (entity.PhuTrachCollection.Count > 0 || entity.PhuTrachCollection.DeletedItems.Count > 0)
					{
						DataRepository.PhuTrachProvider.Save(transactionManager, entity.PhuTrachCollection);
						
						deepHandles.Add(
							(DeepSaveHandle< PhuTrach >) DataRepository.PhuTrachProvider.DeepSave,
							new object[] { transactionManager, entity.PhuTrachCollection, deepSaveType, childTypes, innerList }
						);
					}
				} 
			#endregion 
				
	
			#region List<PhanCong>
				if (CanDeepSave(entity.PhanCongCollection, "List<PhanCong>|PhanCongCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(PhanCong child in entity.PhanCongCollection)
					{
						if(child.MaGiaoVienSource != null)
							child.MaGiaoVien = child.MaGiaoVienSource.MaGiaoVien;
						else
							child.MaGiaoVien = entity.MaGiaoVien;

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
				
	
			#region List<RangBuocGiaoVien>
				if (CanDeepSave(entity.RangBuocGiaoVienCollection, "List<RangBuocGiaoVien>|RangBuocGiaoVienCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(RangBuocGiaoVien child in entity.RangBuocGiaoVienCollection)
					{
						if(child.MaGiaoVienSource != null)
							child.MaGiaoVien = child.MaGiaoVienSource.MaGiaoVien;
						else
							child.MaGiaoVien = entity.MaGiaoVien;

					}

					if (entity.RangBuocGiaoVienCollection.Count > 0 || entity.RangBuocGiaoVienCollection.DeletedItems.Count > 0)
					{
						DataRepository.RangBuocGiaoVienProvider.Save(transactionManager, entity.RangBuocGiaoVienCollection);
						
						deepHandles.Add(
							(DeepSaveHandle< RangBuocGiaoVien >) DataRepository.RangBuocGiaoVienProvider.DeepSave,
							new object[] { transactionManager, entity.RangBuocGiaoVienCollection, deepSaveType, childTypes, innerList }
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
	
	#region GiaoVienChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>PTNK.Entities.GiaoVien</c>
	///</summary>
	public enum GiaoVienChildEntityTypes
	{

		///<summary>
		/// Collection of <c>GiaoVien</c> as OneToMany for PhuTrachCollection
		///</summary>
		[ChildEntityType(typeof(TList<PhuTrach>))]
		PhuTrachCollection,

		///<summary>
		/// Collection of <c>GiaoVien</c> as OneToMany for PhanCongCollection
		///</summary>
		[ChildEntityType(typeof(TList<PhanCong>))]
		PhanCongCollection,

		///<summary>
		/// Collection of <c>GiaoVien</c> as OneToMany for RangBuocGiaoVienCollection
		///</summary>
		[ChildEntityType(typeof(TList<RangBuocGiaoVien>))]
		RangBuocGiaoVienCollection,
	}
	
	#endregion GiaoVienChildEntityTypes
	
	#region GiaoVienFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;GiaoVienColumn&gt;"/> class
	/// that is used exclusively with a <see cref="GiaoVien"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GiaoVienFilterBuilder : SqlFilterBuilder<GiaoVienColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GiaoVienFilterBuilder class.
		/// </summary>
		public GiaoVienFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the GiaoVienFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public GiaoVienFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the GiaoVienFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public GiaoVienFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion GiaoVienFilterBuilder
	
	#region GiaoVienParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;GiaoVienColumn&gt;"/> class
	/// that is used exclusively with a <see cref="GiaoVien"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GiaoVienParameterBuilder : ParameterizedSqlFilterBuilder<GiaoVienColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GiaoVienParameterBuilder class.
		/// </summary>
		public GiaoVienParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the GiaoVienParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public GiaoVienParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the GiaoVienParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public GiaoVienParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion GiaoVienParameterBuilder
} // end namespace
