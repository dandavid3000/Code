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
	/// This class is the base class for any <see cref="RangBuocLopHocProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class RangBuocLopHocProviderBaseCore : EntityProviderBase<PTNK.Entities.RangBuocLopHoc, PTNK.Entities.RangBuocLopHocKey>
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
		public override bool Delete(TransactionManager transactionManager, PTNK.Entities.RangBuocLopHocKey key)
		{
			return Delete(transactionManager, key.MaRangBuocLopHoc);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="maRangBuocLopHoc">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String maRangBuocLopHoc)
		{
			return Delete(null, maRangBuocLopHoc);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maRangBuocLopHoc">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String maRangBuocLopHoc);		
		
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
		public override PTNK.Entities.RangBuocLopHoc Get(TransactionManager transactionManager, PTNK.Entities.RangBuocLopHocKey key, int start, int pageLength)
		{
			return GetByMaRangBuocLopHoc(transactionManager, key.MaRangBuocLopHoc, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key RangBuocLopHoc$PrimaryKey index.
		/// </summary>
		/// <param name="maRangBuocLopHoc"></param>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.RangBuocLopHoc"/> class.</returns>
		public PTNK.Entities.RangBuocLopHoc GetByMaRangBuocLopHoc(System.String maRangBuocLopHoc)
		{
			int count = -1;
			return GetByMaRangBuocLopHoc(null,maRangBuocLopHoc, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the RangBuocLopHoc$PrimaryKey index.
		/// </summary>
		/// <param name="maRangBuocLopHoc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.RangBuocLopHoc"/> class.</returns>
		public PTNK.Entities.RangBuocLopHoc GetByMaRangBuocLopHoc(System.String maRangBuocLopHoc, int start, int pageLength)
		{
			int count = -1;
			return GetByMaRangBuocLopHoc(null, maRangBuocLopHoc, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the RangBuocLopHoc$PrimaryKey index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maRangBuocLopHoc"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.RangBuocLopHoc"/> class.</returns>
		public PTNK.Entities.RangBuocLopHoc GetByMaRangBuocLopHoc(TransactionManager transactionManager, System.String maRangBuocLopHoc)
		{
			int count = -1;
			return GetByMaRangBuocLopHoc(transactionManager, maRangBuocLopHoc, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the RangBuocLopHoc$PrimaryKey index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maRangBuocLopHoc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.RangBuocLopHoc"/> class.</returns>
		public PTNK.Entities.RangBuocLopHoc GetByMaRangBuocLopHoc(TransactionManager transactionManager, System.String maRangBuocLopHoc, int start, int pageLength)
		{
			int count = -1;
			return GetByMaRangBuocLopHoc(transactionManager, maRangBuocLopHoc, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the RangBuocLopHoc$PrimaryKey index.
		/// </summary>
		/// <param name="maRangBuocLopHoc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.RangBuocLopHoc"/> class.</returns>
		public PTNK.Entities.RangBuocLopHoc GetByMaRangBuocLopHoc(System.String maRangBuocLopHoc, int start, int pageLength, out int count)
		{
			return GetByMaRangBuocLopHoc(null, maRangBuocLopHoc, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the RangBuocLopHoc$PrimaryKey index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maRangBuocLopHoc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.RangBuocLopHoc"/> class.</returns>
		public abstract PTNK.Entities.RangBuocLopHoc GetByMaRangBuocLopHoc(TransactionManager transactionManager, System.String maRangBuocLopHoc, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key RangBuocLopHoc$LopHocRangBuocLopHoc index.
		/// </summary>
		/// <param name="maLopHoc"></param>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;RangBuocLopHoc&gt;"/> class.</returns>
		public PTNK.Entities.TList<RangBuocLopHoc> GetByMaLopHoc(System.String maLopHoc)
		{
			int count = -1;
			return GetByMaLopHoc(null,maLopHoc, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the RangBuocLopHoc$LopHocRangBuocLopHoc index.
		/// </summary>
		/// <param name="maLopHoc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;RangBuocLopHoc&gt;"/> class.</returns>
		public PTNK.Entities.TList<RangBuocLopHoc> GetByMaLopHoc(System.String maLopHoc, int start, int pageLength)
		{
			int count = -1;
			return GetByMaLopHoc(null, maLopHoc, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the RangBuocLopHoc$LopHocRangBuocLopHoc index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maLopHoc"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;RangBuocLopHoc&gt;"/> class.</returns>
		public PTNK.Entities.TList<RangBuocLopHoc> GetByMaLopHoc(TransactionManager transactionManager, System.String maLopHoc)
		{
			int count = -1;
			return GetByMaLopHoc(transactionManager, maLopHoc, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the RangBuocLopHoc$LopHocRangBuocLopHoc index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maLopHoc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;RangBuocLopHoc&gt;"/> class.</returns>
		public PTNK.Entities.TList<RangBuocLopHoc> GetByMaLopHoc(TransactionManager transactionManager, System.String maLopHoc, int start, int pageLength)
		{
			int count = -1;
			return GetByMaLopHoc(transactionManager, maLopHoc, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the RangBuocLopHoc$LopHocRangBuocLopHoc index.
		/// </summary>
		/// <param name="maLopHoc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;RangBuocLopHoc&gt;"/> class.</returns>
		public PTNK.Entities.TList<RangBuocLopHoc> GetByMaLopHoc(System.String maLopHoc, int start, int pageLength, out int count)
		{
			return GetByMaLopHoc(null, maLopHoc, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the RangBuocLopHoc$LopHocRangBuocLopHoc index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maLopHoc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;RangBuocLopHoc&gt;"/> class.</returns>
		public abstract PTNK.Entities.TList<RangBuocLopHoc> GetByMaLopHoc(TransactionManager transactionManager, System.String maLopHoc, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a PTNK.Entities.TList&lt;RangBuocLopHoc&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="PTNK.Entities.TList&lt;RangBuocLopHoc&gt;"/></returns>
		public static PTNK.Entities.TList<RangBuocLopHoc> Fill(IDataReader reader, PTNK.Entities.TList<RangBuocLopHoc> rows, int start, int pageLength)
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
			
			PTNK.Entities.RangBuocLopHoc c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("RangBuocLopHoc")
			.Append("|").Append((reader.IsDBNull(((int)PTNK.Entities.RangBuocLopHocColumn.MaRangBuocLopHoc - 1))?string.Empty:(System.String)reader[((int)PTNK.Entities.RangBuocLopHocColumn.MaRangBuocLopHoc - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<RangBuocLopHoc>(
			key.ToString(), // EntityTrackingKey
			"RangBuocLopHoc",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new PTNK.Entities.RangBuocLopHoc();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.MaRangBuocLopHoc = (System.String)reader["MaRangBuocLopHoc"];
			c.OriginalMaRangBuocLopHoc = c.MaRangBuocLopHoc;
			c.MaLopHoc = reader.IsDBNull(reader.GetOrdinal("MaLopHoc")) ? null : (System.String)reader["MaLopHoc"];
			c.Thu = reader.IsDBNull(reader.GetOrdinal("Thu")) ? null : (System.Byte?)reader["Thu"];
			c.TietHoc = reader.IsDBNull(reader.GetOrdinal("TietHoc")) ? null : (System.Byte?)reader["TietHoc"];
			c.TrangThai = reader.IsDBNull(reader.GetOrdinal("TrangThai")) ? null : (System.Byte?)reader["TrangThai"];
			c.EntityTrackingKey = key;
			c.AcceptChanges();
			c.SuppressEntityEvents = false;
			}
			rows.Add(c);
		}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="PTNK.Entities.RangBuocLopHoc"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="PTNK.Entities.RangBuocLopHoc"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, PTNK.Entities.RangBuocLopHoc entity)
		{
			if (!reader.Read()) return;
			
			entity.MaRangBuocLopHoc = (System.String)reader["MaRangBuocLopHoc"];
			entity.OriginalMaRangBuocLopHoc = (System.String)reader["MaRangBuocLopHoc"];
			entity.MaLopHoc = reader.IsDBNull(reader.GetOrdinal("MaLopHoc")) ? null : (System.String)reader["MaLopHoc"];
			entity.Thu = reader.IsDBNull(reader.GetOrdinal("Thu")) ? null : (System.Byte?)reader["Thu"];
			entity.TietHoc = reader.IsDBNull(reader.GetOrdinal("TietHoc")) ? null : (System.Byte?)reader["TietHoc"];
			entity.TrangThai = reader.IsDBNull(reader.GetOrdinal("TrangThai")) ? null : (System.Byte?)reader["TrangThai"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="PTNK.Entities.RangBuocLopHoc"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="PTNK.Entities.RangBuocLopHoc"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, PTNK.Entities.RangBuocLopHoc entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.MaRangBuocLopHoc = (System.String)dataRow["MaRangBuocLopHoc"];
			entity.OriginalMaRangBuocLopHoc = (System.String)dataRow["MaRangBuocLopHoc"];
			entity.MaLopHoc = Convert.IsDBNull(dataRow["MaLopHoc"]) ? null : (System.String)dataRow["MaLopHoc"];
			entity.Thu = Convert.IsDBNull(dataRow["Thu"]) ? null : (System.Byte?)dataRow["Thu"];
			entity.TietHoc = Convert.IsDBNull(dataRow["TietHoc"]) ? null : (System.Byte?)dataRow["TietHoc"];
			entity.TrangThai = Convert.IsDBNull(dataRow["TrangThai"]) ? null : (System.Byte?)dataRow["TrangThai"];
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
		/// <param name="entity">The <see cref="PTNK.Entities.RangBuocLopHoc"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">PTNK.Entities.RangBuocLopHoc Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, PTNK.Entities.RangBuocLopHoc entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the PTNK.Entities.RangBuocLopHoc object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">PTNK.Entities.RangBuocLopHoc instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">PTNK.Entities.RangBuocLopHoc Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, PTNK.Entities.RangBuocLopHoc entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region RangBuocLopHocChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>PTNK.Entities.RangBuocLopHoc</c>
	///</summary>
	public enum RangBuocLopHocChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>LopHoc</c> at MaLopHocSource
		///</summary>
		[ChildEntityType(typeof(LopHoc))]
		LopHoc,
		}
	
	#endregion RangBuocLopHocChildEntityTypes
	
	#region RangBuocLopHocFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;RangBuocLopHocColumn&gt;"/> class
	/// that is used exclusively with a <see cref="RangBuocLopHoc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RangBuocLopHocFilterBuilder : SqlFilterBuilder<RangBuocLopHocColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RangBuocLopHocFilterBuilder class.
		/// </summary>
		public RangBuocLopHocFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the RangBuocLopHocFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RangBuocLopHocFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RangBuocLopHocFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RangBuocLopHocFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RangBuocLopHocFilterBuilder
	
	#region RangBuocLopHocParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;RangBuocLopHocColumn&gt;"/> class
	/// that is used exclusively with a <see cref="RangBuocLopHoc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RangBuocLopHocParameterBuilder : ParameterizedSqlFilterBuilder<RangBuocLopHocColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RangBuocLopHocParameterBuilder class.
		/// </summary>
		public RangBuocLopHocParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the RangBuocLopHocParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RangBuocLopHocParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RangBuocLopHocParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RangBuocLopHocParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RangBuocLopHocParameterBuilder
} // end namespace
