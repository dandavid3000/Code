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
	/// This class is the base class for any <see cref="RangBuocGiaoVienProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class RangBuocGiaoVienProviderBaseCore : EntityProviderBase<PTNK.Entities.RangBuocGiaoVien, PTNK.Entities.RangBuocGiaoVienKey>
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
		public override bool Delete(TransactionManager transactionManager, PTNK.Entities.RangBuocGiaoVienKey key)
		{
			return Delete(transactionManager, key.MaRangBuocGiaoVien);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="maRangBuocGiaoVien">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String maRangBuocGiaoVien)
		{
			return Delete(null, maRangBuocGiaoVien);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maRangBuocGiaoVien">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String maRangBuocGiaoVien);		
		
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
		public override PTNK.Entities.RangBuocGiaoVien Get(TransactionManager transactionManager, PTNK.Entities.RangBuocGiaoVienKey key, int start, int pageLength)
		{
			return GetByMaRangBuocGiaoVien(transactionManager, key.MaRangBuocGiaoVien, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key RangBuocGiaoVien$PrimaryKey index.
		/// </summary>
		/// <param name="maRangBuocGiaoVien"></param>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.RangBuocGiaoVien"/> class.</returns>
		public PTNK.Entities.RangBuocGiaoVien GetByMaRangBuocGiaoVien(System.String maRangBuocGiaoVien)
		{
			int count = -1;
			return GetByMaRangBuocGiaoVien(null,maRangBuocGiaoVien, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the RangBuocGiaoVien$PrimaryKey index.
		/// </summary>
		/// <param name="maRangBuocGiaoVien"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.RangBuocGiaoVien"/> class.</returns>
		public PTNK.Entities.RangBuocGiaoVien GetByMaRangBuocGiaoVien(System.String maRangBuocGiaoVien, int start, int pageLength)
		{
			int count = -1;
			return GetByMaRangBuocGiaoVien(null, maRangBuocGiaoVien, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the RangBuocGiaoVien$PrimaryKey index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maRangBuocGiaoVien"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.RangBuocGiaoVien"/> class.</returns>
		public PTNK.Entities.RangBuocGiaoVien GetByMaRangBuocGiaoVien(TransactionManager transactionManager, System.String maRangBuocGiaoVien)
		{
			int count = -1;
			return GetByMaRangBuocGiaoVien(transactionManager, maRangBuocGiaoVien, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the RangBuocGiaoVien$PrimaryKey index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maRangBuocGiaoVien"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.RangBuocGiaoVien"/> class.</returns>
		public PTNK.Entities.RangBuocGiaoVien GetByMaRangBuocGiaoVien(TransactionManager transactionManager, System.String maRangBuocGiaoVien, int start, int pageLength)
		{
			int count = -1;
			return GetByMaRangBuocGiaoVien(transactionManager, maRangBuocGiaoVien, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the RangBuocGiaoVien$PrimaryKey index.
		/// </summary>
		/// <param name="maRangBuocGiaoVien"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.RangBuocGiaoVien"/> class.</returns>
		public PTNK.Entities.RangBuocGiaoVien GetByMaRangBuocGiaoVien(System.String maRangBuocGiaoVien, int start, int pageLength, out int count)
		{
			return GetByMaRangBuocGiaoVien(null, maRangBuocGiaoVien, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the RangBuocGiaoVien$PrimaryKey index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maRangBuocGiaoVien"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.RangBuocGiaoVien"/> class.</returns>
		public abstract PTNK.Entities.RangBuocGiaoVien GetByMaRangBuocGiaoVien(TransactionManager transactionManager, System.String maRangBuocGiaoVien, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key RangBuocGiaoVien$GiaoVienRangBuocGiaoVien index.
		/// </summary>
		/// <param name="maGiaoVien"></param>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;RangBuocGiaoVien&gt;"/> class.</returns>
		public PTNK.Entities.TList<RangBuocGiaoVien> GetByMaGiaoVien(System.String maGiaoVien)
		{
			int count = -1;
			return GetByMaGiaoVien(null,maGiaoVien, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the RangBuocGiaoVien$GiaoVienRangBuocGiaoVien index.
		/// </summary>
		/// <param name="maGiaoVien"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;RangBuocGiaoVien&gt;"/> class.</returns>
		public PTNK.Entities.TList<RangBuocGiaoVien> GetByMaGiaoVien(System.String maGiaoVien, int start, int pageLength)
		{
			int count = -1;
			return GetByMaGiaoVien(null, maGiaoVien, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the RangBuocGiaoVien$GiaoVienRangBuocGiaoVien index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maGiaoVien"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;RangBuocGiaoVien&gt;"/> class.</returns>
		public PTNK.Entities.TList<RangBuocGiaoVien> GetByMaGiaoVien(TransactionManager transactionManager, System.String maGiaoVien)
		{
			int count = -1;
			return GetByMaGiaoVien(transactionManager, maGiaoVien, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the RangBuocGiaoVien$GiaoVienRangBuocGiaoVien index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maGiaoVien"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;RangBuocGiaoVien&gt;"/> class.</returns>
		public PTNK.Entities.TList<RangBuocGiaoVien> GetByMaGiaoVien(TransactionManager transactionManager, System.String maGiaoVien, int start, int pageLength)
		{
			int count = -1;
			return GetByMaGiaoVien(transactionManager, maGiaoVien, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the RangBuocGiaoVien$GiaoVienRangBuocGiaoVien index.
		/// </summary>
		/// <param name="maGiaoVien"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;RangBuocGiaoVien&gt;"/> class.</returns>
		public PTNK.Entities.TList<RangBuocGiaoVien> GetByMaGiaoVien(System.String maGiaoVien, int start, int pageLength, out int count)
		{
			return GetByMaGiaoVien(null, maGiaoVien, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the RangBuocGiaoVien$GiaoVienRangBuocGiaoVien index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maGiaoVien"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;RangBuocGiaoVien&gt;"/> class.</returns>
		public abstract PTNK.Entities.TList<RangBuocGiaoVien> GetByMaGiaoVien(TransactionManager transactionManager, System.String maGiaoVien, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a PTNK.Entities.TList&lt;RangBuocGiaoVien&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="PTNK.Entities.TList&lt;RangBuocGiaoVien&gt;"/></returns>
		public static PTNK.Entities.TList<RangBuocGiaoVien> Fill(IDataReader reader, PTNK.Entities.TList<RangBuocGiaoVien> rows, int start, int pageLength)
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
			
			PTNK.Entities.RangBuocGiaoVien c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("RangBuocGiaoVien")
			.Append("|").Append((reader.IsDBNull(((int)PTNK.Entities.RangBuocGiaoVienColumn.MaRangBuocGiaoVien - 1))?string.Empty:(System.String)reader[((int)PTNK.Entities.RangBuocGiaoVienColumn.MaRangBuocGiaoVien - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<RangBuocGiaoVien>(
			key.ToString(), // EntityTrackingKey
			"RangBuocGiaoVien",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new PTNK.Entities.RangBuocGiaoVien();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.MaRangBuocGiaoVien = (System.String)reader["MaRangBuocGiaoVien"];
			c.OriginalMaRangBuocGiaoVien = c.MaRangBuocGiaoVien;
			c.MaGiaoVien = reader.IsDBNull(reader.GetOrdinal("MaGiaoVien")) ? null : (System.String)reader["MaGiaoVien"];
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
		/// Refreshes the <see cref="PTNK.Entities.RangBuocGiaoVien"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="PTNK.Entities.RangBuocGiaoVien"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, PTNK.Entities.RangBuocGiaoVien entity)
		{
			if (!reader.Read()) return;
			
			entity.MaRangBuocGiaoVien = (System.String)reader["MaRangBuocGiaoVien"];
			entity.OriginalMaRangBuocGiaoVien = (System.String)reader["MaRangBuocGiaoVien"];
			entity.MaGiaoVien = reader.IsDBNull(reader.GetOrdinal("MaGiaoVien")) ? null : (System.String)reader["MaGiaoVien"];
			entity.Thu = reader.IsDBNull(reader.GetOrdinal("Thu")) ? null : (System.Byte?)reader["Thu"];
			entity.TietHoc = reader.IsDBNull(reader.GetOrdinal("TietHoc")) ? null : (System.Byte?)reader["TietHoc"];
			entity.TrangThai = reader.IsDBNull(reader.GetOrdinal("TrangThai")) ? null : (System.Byte?)reader["TrangThai"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="PTNK.Entities.RangBuocGiaoVien"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="PTNK.Entities.RangBuocGiaoVien"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, PTNK.Entities.RangBuocGiaoVien entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.MaRangBuocGiaoVien = (System.String)dataRow["MaRangBuocGiaoVien"];
			entity.OriginalMaRangBuocGiaoVien = (System.String)dataRow["MaRangBuocGiaoVien"];
			entity.MaGiaoVien = Convert.IsDBNull(dataRow["MaGiaoVien"]) ? null : (System.String)dataRow["MaGiaoVien"];
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
		/// <param name="entity">The <see cref="PTNK.Entities.RangBuocGiaoVien"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">PTNK.Entities.RangBuocGiaoVien Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, PTNK.Entities.RangBuocGiaoVien entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

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
		/// Deep Save the entire object graph of the PTNK.Entities.RangBuocGiaoVien object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">PTNK.Entities.RangBuocGiaoVien instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">PTNK.Entities.RangBuocGiaoVien Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, PTNK.Entities.RangBuocGiaoVien entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
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
	
	#region RangBuocGiaoVienChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>PTNK.Entities.RangBuocGiaoVien</c>
	///</summary>
	public enum RangBuocGiaoVienChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>GiaoVien</c> at MaGiaoVienSource
		///</summary>
		[ChildEntityType(typeof(GiaoVien))]
		GiaoVien,
		}
	
	#endregion RangBuocGiaoVienChildEntityTypes
	
	#region RangBuocGiaoVienFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;RangBuocGiaoVienColumn&gt;"/> class
	/// that is used exclusively with a <see cref="RangBuocGiaoVien"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RangBuocGiaoVienFilterBuilder : SqlFilterBuilder<RangBuocGiaoVienColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RangBuocGiaoVienFilterBuilder class.
		/// </summary>
		public RangBuocGiaoVienFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the RangBuocGiaoVienFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RangBuocGiaoVienFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RangBuocGiaoVienFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RangBuocGiaoVienFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RangBuocGiaoVienFilterBuilder
	
	#region RangBuocGiaoVienParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;RangBuocGiaoVienColumn&gt;"/> class
	/// that is used exclusively with a <see cref="RangBuocGiaoVien"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RangBuocGiaoVienParameterBuilder : ParameterizedSqlFilterBuilder<RangBuocGiaoVienColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RangBuocGiaoVienParameterBuilder class.
		/// </summary>
		public RangBuocGiaoVienParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the RangBuocGiaoVienParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RangBuocGiaoVienParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RangBuocGiaoVienParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RangBuocGiaoVienParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RangBuocGiaoVienParameterBuilder
} // end namespace
