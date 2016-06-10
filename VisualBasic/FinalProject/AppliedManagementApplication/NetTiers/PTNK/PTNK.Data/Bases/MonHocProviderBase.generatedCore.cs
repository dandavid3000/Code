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
	/// This class is the base class for any <see cref="MonHocProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class MonHocProviderBaseCore : EntityProviderBase<PTNK.Entities.MonHoc, PTNK.Entities.MonHocKey>
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
		public override bool Delete(TransactionManager transactionManager, PTNK.Entities.MonHocKey key)
		{
			return Delete(transactionManager, key.MaMonHoc);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="maMonHoc">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String maMonHoc)
		{
			return Delete(null, maMonHoc);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maMonHoc">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String maMonHoc);		
		
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
		public override PTNK.Entities.MonHoc Get(TransactionManager transactionManager, PTNK.Entities.MonHocKey key, int start, int pageLength)
		{
			return GetByMaMonHoc(transactionManager, key.MaMonHoc, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key MonHoc$PrimaryKey index.
		/// </summary>
		/// <param name="maMonHoc"></param>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.MonHoc"/> class.</returns>
		public PTNK.Entities.MonHoc GetByMaMonHoc(System.String maMonHoc)
		{
			int count = -1;
			return GetByMaMonHoc(null,maMonHoc, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the MonHoc$PrimaryKey index.
		/// </summary>
		/// <param name="maMonHoc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.MonHoc"/> class.</returns>
		public PTNK.Entities.MonHoc GetByMaMonHoc(System.String maMonHoc, int start, int pageLength)
		{
			int count = -1;
			return GetByMaMonHoc(null, maMonHoc, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the MonHoc$PrimaryKey index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maMonHoc"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.MonHoc"/> class.</returns>
		public PTNK.Entities.MonHoc GetByMaMonHoc(TransactionManager transactionManager, System.String maMonHoc)
		{
			int count = -1;
			return GetByMaMonHoc(transactionManager, maMonHoc, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the MonHoc$PrimaryKey index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maMonHoc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.MonHoc"/> class.</returns>
		public PTNK.Entities.MonHoc GetByMaMonHoc(TransactionManager transactionManager, System.String maMonHoc, int start, int pageLength)
		{
			int count = -1;
			return GetByMaMonHoc(transactionManager, maMonHoc, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the MonHoc$PrimaryKey index.
		/// </summary>
		/// <param name="maMonHoc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.MonHoc"/> class.</returns>
		public PTNK.Entities.MonHoc GetByMaMonHoc(System.String maMonHoc, int start, int pageLength, out int count)
		{
			return GetByMaMonHoc(null, maMonHoc, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the MonHoc$PrimaryKey index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maMonHoc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.MonHoc"/> class.</returns>
		public abstract PTNK.Entities.MonHoc GetByMaMonHoc(TransactionManager transactionManager, System.String maMonHoc, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a PTNK.Entities.TList&lt;MonHoc&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="PTNK.Entities.TList&lt;MonHoc&gt;"/></returns>
		public static PTNK.Entities.TList<MonHoc> Fill(IDataReader reader, PTNK.Entities.TList<MonHoc> rows, int start, int pageLength)
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
			
			PTNK.Entities.MonHoc c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("MonHoc")
			.Append("|").Append((reader.IsDBNull(((int)PTNK.Entities.MonHocColumn.MaMonHoc - 1))?string.Empty:(System.String)reader[((int)PTNK.Entities.MonHocColumn.MaMonHoc - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<MonHoc>(
			key.ToString(), // EntityTrackingKey
			"MonHoc",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new PTNK.Entities.MonHoc();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.MaMonHoc = (System.String)reader["MaMonHoc"];
			c.OriginalMaMonHoc = c.MaMonHoc;
			c.TenMonHoc = reader.IsDBNull(reader.GetOrdinal("TenMonHoc")) ? null : (System.String)reader["TenMonHoc"];
			c.QuiDinhSoTietHocLienTiepToiThieu = reader.IsDBNull(reader.GetOrdinal("QuiDinhSoTietHocLienTiepToiThieu")) ? null : (System.Byte?)reader["QuiDinhSoTietHocLienTiepToiThieu"];
			c.QuiDinhSoTietHocLienTiepToiDa = reader.IsDBNull(reader.GetOrdinal("QuiDinhSoTietHocLienTiepToiDa")) ? null : (System.Byte?)reader["QuiDinhSoTietHocLienTiepToiDa"];
			c.EntityTrackingKey = key;
			c.AcceptChanges();
			c.SuppressEntityEvents = false;
			}
			rows.Add(c);
		}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="PTNK.Entities.MonHoc"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="PTNK.Entities.MonHoc"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, PTNK.Entities.MonHoc entity)
		{
			if (!reader.Read()) return;
			
			entity.MaMonHoc = (System.String)reader["MaMonHoc"];
			entity.OriginalMaMonHoc = (System.String)reader["MaMonHoc"];
			entity.TenMonHoc = reader.IsDBNull(reader.GetOrdinal("TenMonHoc")) ? null : (System.String)reader["TenMonHoc"];
			entity.QuiDinhSoTietHocLienTiepToiThieu = reader.IsDBNull(reader.GetOrdinal("QuiDinhSoTietHocLienTiepToiThieu")) ? null : (System.Byte?)reader["QuiDinhSoTietHocLienTiepToiThieu"];
			entity.QuiDinhSoTietHocLienTiepToiDa = reader.IsDBNull(reader.GetOrdinal("QuiDinhSoTietHocLienTiepToiDa")) ? null : (System.Byte?)reader["QuiDinhSoTietHocLienTiepToiDa"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="PTNK.Entities.MonHoc"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="PTNK.Entities.MonHoc"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, PTNK.Entities.MonHoc entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.MaMonHoc = (System.String)dataRow["MaMonHoc"];
			entity.OriginalMaMonHoc = (System.String)dataRow["MaMonHoc"];
			entity.TenMonHoc = Convert.IsDBNull(dataRow["TenMonHoc"]) ? null : (System.String)dataRow["TenMonHoc"];
			entity.QuiDinhSoTietHocLienTiepToiThieu = Convert.IsDBNull(dataRow["QuiDinhSoTietHocLienTiepToiThieu"]) ? null : (System.Byte?)dataRow["QuiDinhSoTietHocLienTiepToiThieu"];
			entity.QuiDinhSoTietHocLienTiepToiDa = Convert.IsDBNull(dataRow["QuiDinhSoTietHocLienTiepToiDa"]) ? null : (System.Byte?)dataRow["QuiDinhSoTietHocLienTiepToiDa"];
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
		/// <param name="entity">The <see cref="PTNK.Entities.MonHoc"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">PTNK.Entities.MonHoc Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, PTNK.Entities.MonHoc entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByMaMonHoc methods when available
			
			#region PhuTrachCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<PhuTrach>|PhuTrachCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'PhuTrachCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.PhuTrachCollection = DataRepository.PhuTrachProvider.GetByMaMonHoc(transactionManager, entity.MaMonHoc);

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

				entity.PhanCongCollection = DataRepository.PhanCongProvider.GetByMaMonHoc(transactionManager, entity.MaMonHoc);

				if (deep && entity.PhanCongCollection.Count > 0)
				{
					deepHandles.Add("PhanCongCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<PhanCong>) DataRepository.PhanCongProvider.DeepLoad,
						new object[] { transactionManager, entity.PhanCongCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the PTNK.Entities.MonHoc object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">PTNK.Entities.MonHoc instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">PTNK.Entities.MonHoc Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, PTNK.Entities.MonHoc entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
						if(child.MaMonHocSource != null)
							child.MaMonHoc = child.MaMonHocSource.MaMonHoc;
						else
							child.MaMonHoc = entity.MaMonHoc;

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
						if(child.MaMonHocSource != null)
							child.MaMonHoc = child.MaMonHocSource.MaMonHoc;
						else
							child.MaMonHoc = entity.MaMonHoc;

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
	
	#region MonHocChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>PTNK.Entities.MonHoc</c>
	///</summary>
	public enum MonHocChildEntityTypes
	{

		///<summary>
		/// Collection of <c>MonHoc</c> as OneToMany for PhuTrachCollection
		///</summary>
		[ChildEntityType(typeof(TList<PhuTrach>))]
		PhuTrachCollection,

		///<summary>
		/// Collection of <c>MonHoc</c> as OneToMany for PhanCongCollection
		///</summary>
		[ChildEntityType(typeof(TList<PhanCong>))]
		PhanCongCollection,
	}
	
	#endregion MonHocChildEntityTypes
	
	#region MonHocFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;MonHocColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MonHoc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MonHocFilterBuilder : SqlFilterBuilder<MonHocColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MonHocFilterBuilder class.
		/// </summary>
		public MonHocFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the MonHocFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MonHocFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MonHocFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MonHocFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MonHocFilterBuilder
	
	#region MonHocParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;MonHocColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MonHoc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MonHocParameterBuilder : ParameterizedSqlFilterBuilder<MonHocColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MonHocParameterBuilder class.
		/// </summary>
		public MonHocParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the MonHocParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MonHocParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MonHocParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MonHocParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MonHocParameterBuilder
} // end namespace
