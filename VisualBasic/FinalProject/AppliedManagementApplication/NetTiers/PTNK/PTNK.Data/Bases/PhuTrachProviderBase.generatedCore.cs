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
	/// This class is the base class for any <see cref="PhuTrachProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class PhuTrachProviderBaseCore : EntityProviderBase<PTNK.Entities.PhuTrach, PTNK.Entities.PhuTrachKey>
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
		public override bool Delete(TransactionManager transactionManager, PTNK.Entities.PhuTrachKey key)
		{
			return Delete(transactionManager, key.MaPhuTrach);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="maPhuTrach">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String maPhuTrach)
		{
			return Delete(null, maPhuTrach);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maPhuTrach">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String maPhuTrach);		
		
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
		public override PTNK.Entities.PhuTrach Get(TransactionManager transactionManager, PTNK.Entities.PhuTrachKey key, int start, int pageLength)
		{
			return GetByMaPhuTrach(transactionManager, key.MaPhuTrach, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PhuTrach$PrimaryKey index.
		/// </summary>
		/// <param name="maPhuTrach"></param>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.PhuTrach"/> class.</returns>
		public PTNK.Entities.PhuTrach GetByMaPhuTrach(System.String maPhuTrach)
		{
			int count = -1;
			return GetByMaPhuTrach(null,maPhuTrach, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PhuTrach$PrimaryKey index.
		/// </summary>
		/// <param name="maPhuTrach"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.PhuTrach"/> class.</returns>
		public PTNK.Entities.PhuTrach GetByMaPhuTrach(System.String maPhuTrach, int start, int pageLength)
		{
			int count = -1;
			return GetByMaPhuTrach(null, maPhuTrach, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PhuTrach$PrimaryKey index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maPhuTrach"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.PhuTrach"/> class.</returns>
		public PTNK.Entities.PhuTrach GetByMaPhuTrach(TransactionManager transactionManager, System.String maPhuTrach)
		{
			int count = -1;
			return GetByMaPhuTrach(transactionManager, maPhuTrach, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PhuTrach$PrimaryKey index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maPhuTrach"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.PhuTrach"/> class.</returns>
		public PTNK.Entities.PhuTrach GetByMaPhuTrach(TransactionManager transactionManager, System.String maPhuTrach, int start, int pageLength)
		{
			int count = -1;
			return GetByMaPhuTrach(transactionManager, maPhuTrach, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PhuTrach$PrimaryKey index.
		/// </summary>
		/// <param name="maPhuTrach"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.PhuTrach"/> class.</returns>
		public PTNK.Entities.PhuTrach GetByMaPhuTrach(System.String maPhuTrach, int start, int pageLength, out int count)
		{
			return GetByMaPhuTrach(null, maPhuTrach, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PhuTrach$PrimaryKey index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maPhuTrach"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.PhuTrach"/> class.</returns>
		public abstract PTNK.Entities.PhuTrach GetByMaPhuTrach(TransactionManager transactionManager, System.String maPhuTrach, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PhuTrach$GiaoVienPhuTrach index.
		/// </summary>
		/// <param name="maGiaoVien"></param>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;PhuTrach&gt;"/> class.</returns>
		public PTNK.Entities.TList<PhuTrach> GetByMaGiaoVien(System.String maGiaoVien)
		{
			int count = -1;
			return GetByMaGiaoVien(null,maGiaoVien, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PhuTrach$GiaoVienPhuTrach index.
		/// </summary>
		/// <param name="maGiaoVien"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;PhuTrach&gt;"/> class.</returns>
		public PTNK.Entities.TList<PhuTrach> GetByMaGiaoVien(System.String maGiaoVien, int start, int pageLength)
		{
			int count = -1;
			return GetByMaGiaoVien(null, maGiaoVien, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PhuTrach$GiaoVienPhuTrach index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maGiaoVien"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;PhuTrach&gt;"/> class.</returns>
		public PTNK.Entities.TList<PhuTrach> GetByMaGiaoVien(TransactionManager transactionManager, System.String maGiaoVien)
		{
			int count = -1;
			return GetByMaGiaoVien(transactionManager, maGiaoVien, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PhuTrach$GiaoVienPhuTrach index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maGiaoVien"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;PhuTrach&gt;"/> class.</returns>
		public PTNK.Entities.TList<PhuTrach> GetByMaGiaoVien(TransactionManager transactionManager, System.String maGiaoVien, int start, int pageLength)
		{
			int count = -1;
			return GetByMaGiaoVien(transactionManager, maGiaoVien, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PhuTrach$GiaoVienPhuTrach index.
		/// </summary>
		/// <param name="maGiaoVien"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;PhuTrach&gt;"/> class.</returns>
		public PTNK.Entities.TList<PhuTrach> GetByMaGiaoVien(System.String maGiaoVien, int start, int pageLength, out int count)
		{
			return GetByMaGiaoVien(null, maGiaoVien, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PhuTrach$GiaoVienPhuTrach index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maGiaoVien"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;PhuTrach&gt;"/> class.</returns>
		public abstract PTNK.Entities.TList<PhuTrach> GetByMaGiaoVien(TransactionManager transactionManager, System.String maGiaoVien, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PhuTrach$MonHocPhuTrach index.
		/// </summary>
		/// <param name="maMonHoc"></param>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;PhuTrach&gt;"/> class.</returns>
		public PTNK.Entities.TList<PhuTrach> GetByMaMonHoc(System.String maMonHoc)
		{
			int count = -1;
			return GetByMaMonHoc(null,maMonHoc, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PhuTrach$MonHocPhuTrach index.
		/// </summary>
		/// <param name="maMonHoc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;PhuTrach&gt;"/> class.</returns>
		public PTNK.Entities.TList<PhuTrach> GetByMaMonHoc(System.String maMonHoc, int start, int pageLength)
		{
			int count = -1;
			return GetByMaMonHoc(null, maMonHoc, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PhuTrach$MonHocPhuTrach index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maMonHoc"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;PhuTrach&gt;"/> class.</returns>
		public PTNK.Entities.TList<PhuTrach> GetByMaMonHoc(TransactionManager transactionManager, System.String maMonHoc)
		{
			int count = -1;
			return GetByMaMonHoc(transactionManager, maMonHoc, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PhuTrach$MonHocPhuTrach index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maMonHoc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;PhuTrach&gt;"/> class.</returns>
		public PTNK.Entities.TList<PhuTrach> GetByMaMonHoc(TransactionManager transactionManager, System.String maMonHoc, int start, int pageLength)
		{
			int count = -1;
			return GetByMaMonHoc(transactionManager, maMonHoc, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PhuTrach$MonHocPhuTrach index.
		/// </summary>
		/// <param name="maMonHoc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;PhuTrach&gt;"/> class.</returns>
		public PTNK.Entities.TList<PhuTrach> GetByMaMonHoc(System.String maMonHoc, int start, int pageLength, out int count)
		{
			return GetByMaMonHoc(null, maMonHoc, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PhuTrach$MonHocPhuTrach index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maMonHoc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.TList&lt;PhuTrach&gt;"/> class.</returns>
		public abstract PTNK.Entities.TList<PhuTrach> GetByMaMonHoc(TransactionManager transactionManager, System.String maMonHoc, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a PTNK.Entities.TList&lt;PhuTrach&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="PTNK.Entities.TList&lt;PhuTrach&gt;"/></returns>
		public static PTNK.Entities.TList<PhuTrach> Fill(IDataReader reader, PTNK.Entities.TList<PhuTrach> rows, int start, int pageLength)
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
			
			PTNK.Entities.PhuTrach c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("PhuTrach")
			.Append("|").Append((reader.IsDBNull(((int)PTNK.Entities.PhuTrachColumn.MaPhuTrach - 1))?string.Empty:(System.String)reader[((int)PTNK.Entities.PhuTrachColumn.MaPhuTrach - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<PhuTrach>(
			key.ToString(), // EntityTrackingKey
			"PhuTrach",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new PTNK.Entities.PhuTrach();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.MaPhuTrach = (System.String)reader["MaPhuTrach"];
			c.OriginalMaPhuTrach = c.MaPhuTrach;
			c.MaGiaoVien = reader.IsDBNull(reader.GetOrdinal("MaGiaoVien")) ? null : (System.String)reader["MaGiaoVien"];
			c.MaMonHoc = reader.IsDBNull(reader.GetOrdinal("MaMonHoc")) ? null : (System.String)reader["MaMonHoc"];
			c.EntityTrackingKey = key;
			c.AcceptChanges();
			c.SuppressEntityEvents = false;
			}
			rows.Add(c);
		}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="PTNK.Entities.PhuTrach"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="PTNK.Entities.PhuTrach"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, PTNK.Entities.PhuTrach entity)
		{
			if (!reader.Read()) return;
			
			entity.MaPhuTrach = (System.String)reader["MaPhuTrach"];
			entity.OriginalMaPhuTrach = (System.String)reader["MaPhuTrach"];
			entity.MaGiaoVien = reader.IsDBNull(reader.GetOrdinal("MaGiaoVien")) ? null : (System.String)reader["MaGiaoVien"];
			entity.MaMonHoc = reader.IsDBNull(reader.GetOrdinal("MaMonHoc")) ? null : (System.String)reader["MaMonHoc"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="PTNK.Entities.PhuTrach"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="PTNK.Entities.PhuTrach"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, PTNK.Entities.PhuTrach entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.MaPhuTrach = (System.String)dataRow["MaPhuTrach"];
			entity.OriginalMaPhuTrach = (System.String)dataRow["MaPhuTrach"];
			entity.MaGiaoVien = Convert.IsDBNull(dataRow["MaGiaoVien"]) ? null : (System.String)dataRow["MaGiaoVien"];
			entity.MaMonHoc = Convert.IsDBNull(dataRow["MaMonHoc"]) ? null : (System.String)dataRow["MaMonHoc"];
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
		/// <param name="entity">The <see cref="PTNK.Entities.PhuTrach"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">PTNK.Entities.PhuTrach Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, PTNK.Entities.PhuTrach entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

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
		/// Deep Save the entire object graph of the PTNK.Entities.PhuTrach object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">PTNK.Entities.PhuTrach instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">PTNK.Entities.PhuTrach Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, PTNK.Entities.PhuTrach entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
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
	
	#region PhuTrachChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>PTNK.Entities.PhuTrach</c>
	///</summary>
	public enum PhuTrachChildEntityTypes
	{
		
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
		}
	
	#endregion PhuTrachChildEntityTypes
	
	#region PhuTrachFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;PhuTrachColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PhuTrach"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PhuTrachFilterBuilder : SqlFilterBuilder<PhuTrachColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PhuTrachFilterBuilder class.
		/// </summary>
		public PhuTrachFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the PhuTrachFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PhuTrachFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PhuTrachFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PhuTrachFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PhuTrachFilterBuilder
	
	#region PhuTrachParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;PhuTrachColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PhuTrach"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PhuTrachParameterBuilder : ParameterizedSqlFilterBuilder<PhuTrachColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PhuTrachParameterBuilder class.
		/// </summary>
		public PhuTrachParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the PhuTrachParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PhuTrachParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PhuTrachParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PhuTrachParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PhuTrachParameterBuilder
} // end namespace
