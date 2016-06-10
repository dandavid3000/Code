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
	/// This class is the base class for any <see cref="LichLopHocProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class LichLopHocProviderBaseCore : EntityProviderBase<PTNK.Entities.LichLopHoc, PTNK.Entities.LichLopHocKey>
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
		public override bool Delete(TransactionManager transactionManager, PTNK.Entities.LichLopHocKey key)
		{
			return Delete(transactionManager, key.MaLichLopHoc);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="maLichLopHoc">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String maLichLopHoc)
		{
			return Delete(null, maLichLopHoc);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maLichLopHoc">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String maLichLopHoc);		
		
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
		public override PTNK.Entities.LichLopHoc Get(TransactionManager transactionManager, PTNK.Entities.LichLopHocKey key, int start, int pageLength)
		{
			return GetByMaLichLopHoc(transactionManager, key.MaLichLopHoc, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key LichLopHoc$PrimaryKey index.
		/// </summary>
		/// <param name="maLichLopHoc"></param>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.LichLopHoc"/> class.</returns>
		public PTNK.Entities.LichLopHoc GetByMaLichLopHoc(System.String maLichLopHoc)
		{
			int count = -1;
			return GetByMaLichLopHoc(null,maLichLopHoc, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the LichLopHoc$PrimaryKey index.
		/// </summary>
		/// <param name="maLichLopHoc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.LichLopHoc"/> class.</returns>
		public PTNK.Entities.LichLopHoc GetByMaLichLopHoc(System.String maLichLopHoc, int start, int pageLength)
		{
			int count = -1;
			return GetByMaLichLopHoc(null, maLichLopHoc, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the LichLopHoc$PrimaryKey index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maLichLopHoc"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.LichLopHoc"/> class.</returns>
		public PTNK.Entities.LichLopHoc GetByMaLichLopHoc(TransactionManager transactionManager, System.String maLichLopHoc)
		{
			int count = -1;
			return GetByMaLichLopHoc(transactionManager, maLichLopHoc, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the LichLopHoc$PrimaryKey index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maLichLopHoc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.LichLopHoc"/> class.</returns>
		public PTNK.Entities.LichLopHoc GetByMaLichLopHoc(TransactionManager transactionManager, System.String maLichLopHoc, int start, int pageLength)
		{
			int count = -1;
			return GetByMaLichLopHoc(transactionManager, maLichLopHoc, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the LichLopHoc$PrimaryKey index.
		/// </summary>
		/// <param name="maLichLopHoc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.LichLopHoc"/> class.</returns>
		public PTNK.Entities.LichLopHoc GetByMaLichLopHoc(System.String maLichLopHoc, int start, int pageLength, out int count)
		{
			return GetByMaLichLopHoc(null, maLichLopHoc, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the LichLopHoc$PrimaryKey index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maLichLopHoc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.LichLopHoc"/> class.</returns>
		public abstract PTNK.Entities.LichLopHoc GetByMaLichLopHoc(TransactionManager transactionManager, System.String maLichLopHoc, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key LichLopHoc$PhanCongLichLopHoc index.
		/// </summary>
		/// <param name="maPhanCong"></param>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;LichLopHoc&gt;"/> class.</returns>
		public PTNK.Entities.TList<LichLopHoc> GetByMaPhanCong(System.String maPhanCong)
		{
			int count = -1;
			return GetByMaPhanCong(null,maPhanCong, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the LichLopHoc$PhanCongLichLopHoc index.
		/// </summary>
		/// <param name="maPhanCong"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;LichLopHoc&gt;"/> class.</returns>
		public PTNK.Entities.TList<LichLopHoc> GetByMaPhanCong(System.String maPhanCong, int start, int pageLength)
		{
			int count = -1;
			return GetByMaPhanCong(null, maPhanCong, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the LichLopHoc$PhanCongLichLopHoc index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maPhanCong"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;LichLopHoc&gt;"/> class.</returns>
		public PTNK.Entities.TList<LichLopHoc> GetByMaPhanCong(TransactionManager transactionManager, System.String maPhanCong)
		{
			int count = -1;
			return GetByMaPhanCong(transactionManager, maPhanCong, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the LichLopHoc$PhanCongLichLopHoc index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maPhanCong"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;LichLopHoc&gt;"/> class.</returns>
		public PTNK.Entities.TList<LichLopHoc> GetByMaPhanCong(TransactionManager transactionManager, System.String maPhanCong, int start, int pageLength)
		{
			int count = -1;
			return GetByMaPhanCong(transactionManager, maPhanCong, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the LichLopHoc$PhanCongLichLopHoc index.
		/// </summary>
		/// <param name="maPhanCong"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;LichLopHoc&gt;"/> class.</returns>
		public PTNK.Entities.TList<LichLopHoc> GetByMaPhanCong(System.String maPhanCong, int start, int pageLength, out int count)
		{
			return GetByMaPhanCong(null, maPhanCong, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the LichLopHoc$PhanCongLichLopHoc index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maPhanCong"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;LichLopHoc&gt;"/> class.</returns>
		public abstract PTNK.Entities.TList<LichLopHoc> GetByMaPhanCong(TransactionManager transactionManager, System.String maPhanCong, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a PTNK.Entities.TList&lt;LichLopHoc&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="PTNK.Entities.TList&lt;LichLopHoc&gt;"/></returns>
		public static PTNK.Entities.TList<LichLopHoc> Fill(IDataReader reader, PTNK.Entities.TList<LichLopHoc> rows, int start, int pageLength)
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
			
			PTNK.Entities.LichLopHoc c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("LichLopHoc")
			.Append("|").Append((reader.IsDBNull(((int)PTNK.Entities.LichLopHocColumn.MaLichLopHoc - 1))?string.Empty:(System.String)reader[((int)PTNK.Entities.LichLopHocColumn.MaLichLopHoc - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<LichLopHoc>(
			key.ToString(), // EntityTrackingKey
			"LichLopHoc",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new PTNK.Entities.LichLopHoc();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.MaLichLopHoc = (System.String)reader["MaLichLopHoc"];
			c.OriginalMaLichLopHoc = c.MaLichLopHoc;
			c.MaPhanCong = reader.IsDBNull(reader.GetOrdinal("MaPhanCong")) ? null : (System.String)reader["MaPhanCong"];
			c.Thu = reader.IsDBNull(reader.GetOrdinal("Thu")) ? null : (System.String)reader["Thu"];
			c.TietHocBatDau = reader.IsDBNull(reader.GetOrdinal("TietHocBatDau")) ? null : (System.Byte?)reader["TietHocBatDau"];
			c.SoTietHoc = reader.IsDBNull(reader.GetOrdinal("SoTietHoc")) ? null : (System.Byte?)reader["SoTietHoc"];
			c.EntityTrackingKey = key;
			c.AcceptChanges();
			c.SuppressEntityEvents = false;
			}
			rows.Add(c);
		}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="PTNK.Entities.LichLopHoc"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="PTNK.Entities.LichLopHoc"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, PTNK.Entities.LichLopHoc entity)
		{
			if (!reader.Read()) return;
			
			entity.MaLichLopHoc = (System.String)reader["MaLichLopHoc"];
			entity.OriginalMaLichLopHoc = (System.String)reader["MaLichLopHoc"];
			entity.MaPhanCong = reader.IsDBNull(reader.GetOrdinal("MaPhanCong")) ? null : (System.String)reader["MaPhanCong"];
			entity.Thu = reader.IsDBNull(reader.GetOrdinal("Thu")) ? null : (System.String)reader["Thu"];
			entity.TietHocBatDau = reader.IsDBNull(reader.GetOrdinal("TietHocBatDau")) ? null : (System.Byte?)reader["TietHocBatDau"];
			entity.SoTietHoc = reader.IsDBNull(reader.GetOrdinal("SoTietHoc")) ? null : (System.Byte?)reader["SoTietHoc"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="PTNK.Entities.LichLopHoc"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="PTNK.Entities.LichLopHoc"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, PTNK.Entities.LichLopHoc entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.MaLichLopHoc = (System.String)dataRow["MaLichLopHoc"];
			entity.OriginalMaLichLopHoc = (System.String)dataRow["MaLichLopHoc"];
			entity.MaPhanCong = Convert.IsDBNull(dataRow["MaPhanCong"]) ? null : (System.String)dataRow["MaPhanCong"];
			entity.Thu = Convert.IsDBNull(dataRow["Thu"]) ? null : (System.String)dataRow["Thu"];
			entity.TietHocBatDau = Convert.IsDBNull(dataRow["TietHocBatDau"]) ? null : (System.Byte?)dataRow["TietHocBatDau"];
			entity.SoTietHoc = Convert.IsDBNull(dataRow["SoTietHoc"]) ? null : (System.Byte?)dataRow["SoTietHoc"];
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
		/// <param name="entity">The <see cref="PTNK.Entities.LichLopHoc"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">PTNK.Entities.LichLopHoc Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, PTNK.Entities.LichLopHoc entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region MaPhanCongSource	
			if (CanDeepLoad(entity, "PhanCong|MaPhanCongSource", deepLoadType, innerList) 
				&& entity.MaPhanCongSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.MaPhanCong ?? string.Empty);
				PhanCong tmpEntity = EntityManager.LocateEntity<PhanCong>(EntityLocator.ConstructKeyFromPkItems(typeof(PhanCong), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.MaPhanCongSource = tmpEntity;
				else
					entity.MaPhanCongSource = DataRepository.PhanCongProvider.GetByMaPhanCong(transactionManager, (entity.MaPhanCong ?? string.Empty));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MaPhanCongSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.MaPhanCongSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.PhanCongProvider.DeepLoad(transactionManager, entity.MaPhanCongSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion MaPhanCongSource
			
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
		/// Deep Save the entire object graph of the PTNK.Entities.LichLopHoc object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">PTNK.Entities.LichLopHoc instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">PTNK.Entities.LichLopHoc Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, PTNK.Entities.LichLopHoc entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region MaPhanCongSource
			if (CanDeepSave(entity, "PhanCong|MaPhanCongSource", deepSaveType, innerList) 
				&& entity.MaPhanCongSource != null)
			{
				DataRepository.PhanCongProvider.Save(transactionManager, entity.MaPhanCongSource);
				entity.MaPhanCong = entity.MaPhanCongSource.MaPhanCong;
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
	
	#region LichLopHocChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>PTNK.Entities.LichLopHoc</c>
	///</summary>
	public enum LichLopHocChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>PhanCong</c> at MaPhanCongSource
		///</summary>
		[ChildEntityType(typeof(PhanCong))]
		PhanCong,
		}
	
	#endregion LichLopHocChildEntityTypes
	
	#region LichLopHocFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;LichLopHocColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LichLopHoc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LichLopHocFilterBuilder : SqlFilterBuilder<LichLopHocColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LichLopHocFilterBuilder class.
		/// </summary>
		public LichLopHocFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LichLopHocFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LichLopHocFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LichLopHocFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LichLopHocFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LichLopHocFilterBuilder
	
	#region LichLopHocParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;LichLopHocColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LichLopHoc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LichLopHocParameterBuilder : ParameterizedSqlFilterBuilder<LichLopHocColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LichLopHocParameterBuilder class.
		/// </summary>
		public LichLopHocParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LichLopHocParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LichLopHocParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LichLopHocParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LichLopHocParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LichLopHocParameterBuilder
} // end namespace
