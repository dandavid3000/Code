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
	/// This class is the base class for any <see cref="LopHocProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class LopHocProviderBaseCore : EntityProviderBase<QuanLyHocSinhPTNK.Entities.LopHoc, QuanLyHocSinhPTNK.Entities.LopHocKey>
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
		public override bool Delete(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.LopHocKey key)
		{
			return Delete(transactionManager, key.MaLop);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="maLop">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String maLop)
		{
			return Delete(null, maLop);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maLop">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String maLop);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LopHoc_Khoi key.
		///		FK_LopHoc_Khoi Description: 
		/// </summary>
		/// <param name="maKhoi"></param>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.LopHoc objects.</returns>
		public QuanLyHocSinhPTNK.Entities.TList<LopHoc> GetByMaKhoi(System.String maKhoi)
		{
			int count = -1;
			return GetByMaKhoi(maKhoi, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LopHoc_Khoi key.
		///		FK_LopHoc_Khoi Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maKhoi"></param>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.LopHoc objects.</returns>
		/// <remarks></remarks>
		public QuanLyHocSinhPTNK.Entities.TList<LopHoc> GetByMaKhoi(TransactionManager transactionManager, System.String maKhoi)
		{
			int count = -1;
			return GetByMaKhoi(transactionManager, maKhoi, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_LopHoc_Khoi key.
		///		FK_LopHoc_Khoi Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maKhoi"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.LopHoc objects.</returns>
		public QuanLyHocSinhPTNK.Entities.TList<LopHoc> GetByMaKhoi(TransactionManager transactionManager, System.String maKhoi, int start, int pageLength)
		{
			int count = -1;
			return GetByMaKhoi(transactionManager, maKhoi, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LopHoc_Khoi key.
		///		fkLopHocKhoi Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="maKhoi"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.LopHoc objects.</returns>
		public QuanLyHocSinhPTNK.Entities.TList<LopHoc> GetByMaKhoi(System.String maKhoi, int start, int pageLength)
		{
			int count =  -1;
			return GetByMaKhoi(null, maKhoi, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LopHoc_Khoi key.
		///		fkLopHocKhoi Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="maKhoi"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.LopHoc objects.</returns>
		public QuanLyHocSinhPTNK.Entities.TList<LopHoc> GetByMaKhoi(System.String maKhoi, int start, int pageLength,out int count)
		{
			return GetByMaKhoi(null, maKhoi, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LopHoc_Khoi key.
		///		FK_LopHoc_Khoi Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maKhoi"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.LopHoc objects.</returns>
		public abstract QuanLyHocSinhPTNK.Entities.TList<LopHoc> GetByMaKhoi(TransactionManager transactionManager, System.String maKhoi, int start, int pageLength, out int count);
		
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
		public override QuanLyHocSinhPTNK.Entities.LopHoc Get(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.LopHocKey key, int start, int pageLength)
		{
			return GetByMaLop(transactionManager, key.MaLop, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_LopHoc index.
		/// </summary>
		/// <param name="maLop"></param>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.LopHoc"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.LopHoc GetByMaLop(System.String maLop)
		{
			int count = -1;
			return GetByMaLop(null,maLop, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_LopHoc index.
		/// </summary>
		/// <param name="maLop"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.LopHoc"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.LopHoc GetByMaLop(System.String maLop, int start, int pageLength)
		{
			int count = -1;
			return GetByMaLop(null, maLop, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_LopHoc index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maLop"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.LopHoc"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.LopHoc GetByMaLop(TransactionManager transactionManager, System.String maLop)
		{
			int count = -1;
			return GetByMaLop(transactionManager, maLop, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_LopHoc index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maLop"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.LopHoc"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.LopHoc GetByMaLop(TransactionManager transactionManager, System.String maLop, int start, int pageLength)
		{
			int count = -1;
			return GetByMaLop(transactionManager, maLop, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_LopHoc index.
		/// </summary>
		/// <param name="maLop"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.LopHoc"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.LopHoc GetByMaLop(System.String maLop, int start, int pageLength, out int count)
		{
			return GetByMaLop(null, maLop, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_LopHoc index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maLop"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.LopHoc"/> class.</returns>
		public abstract QuanLyHocSinhPTNK.Entities.LopHoc GetByMaLop(TransactionManager transactionManager, System.String maLop, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a QuanLyHocSinhPTNK.Entities.TList&lt;LopHoc&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="QuanLyHocSinhPTNK.Entities.TList&lt;LopHoc&gt;"/></returns>
		public static QuanLyHocSinhPTNK.Entities.TList<LopHoc> Fill(IDataReader reader, QuanLyHocSinhPTNK.Entities.TList<LopHoc> rows, int start, int pageLength)
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
			
			QuanLyHocSinhPTNK.Entities.LopHoc c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("LopHoc")
			.Append("|").Append((reader.IsDBNull(((int)QuanLyHocSinhPTNK.Entities.LopHocColumn.MaLop - 1))?string.Empty:(System.String)reader[((int)QuanLyHocSinhPTNK.Entities.LopHocColumn.MaLop - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<LopHoc>(
			key.ToString(), // EntityTrackingKey
			"LopHoc",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new QuanLyHocSinhPTNK.Entities.LopHoc();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.MaLop = (System.String)reader["MaLop"];
			c.OriginalMaLop = c.MaLop;
			c.TenLop = (System.String)reader["TenLop"];
			c.MaKhoi = (System.String)reader["MaKhoi"];
			c.EntityTrackingKey = key;
			c.AcceptChanges();
			c.SuppressEntityEvents = false;
			}
			rows.Add(c);
		}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="QuanLyHocSinhPTNK.Entities.LopHoc"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="QuanLyHocSinhPTNK.Entities.LopHoc"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, QuanLyHocSinhPTNK.Entities.LopHoc entity)
		{
			if (!reader.Read()) return;
			
			entity.MaLop = (System.String)reader["MaLop"];
			entity.OriginalMaLop = (System.String)reader["MaLop"];
			entity.TenLop = (System.String)reader["TenLop"];
			entity.MaKhoi = (System.String)reader["MaKhoi"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="QuanLyHocSinhPTNK.Entities.LopHoc"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="QuanLyHocSinhPTNK.Entities.LopHoc"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, QuanLyHocSinhPTNK.Entities.LopHoc entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.MaLop = (System.String)dataRow["MaLop"];
			entity.OriginalMaLop = (System.String)dataRow["MaLop"];
			entity.TenLop = (System.String)dataRow["TenLop"];
			entity.MaKhoi = (System.String)dataRow["MaKhoi"];
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
		/// <param name="entity">The <see cref="QuanLyHocSinhPTNK.Entities.LopHoc"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">QuanLyHocSinhPTNK.Entities.LopHoc Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.LopHoc entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region MaKhoiSource	
			if (CanDeepLoad(entity, "Khoi|MaKhoiSource", deepLoadType, innerList) 
				&& entity.MaKhoiSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.MaKhoi;
				Khoi tmpEntity = EntityManager.LocateEntity<Khoi>(EntityLocator.ConstructKeyFromPkItems(typeof(Khoi), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.MaKhoiSource = tmpEntity;
				else
					entity.MaKhoiSource = DataRepository.KhoiProvider.GetByMaKhoi(transactionManager, entity.MaKhoi);		
				
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
			// Deep load child collections  - Call GetByMaLop methods when available
			
			#region HocSinhCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<HocSinh>|HocSinhCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'HocSinhCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.HocSinhCollection = DataRepository.HocSinhProvider.GetByMaLop(transactionManager, entity.MaLop);

				if (deep && entity.HocSinhCollection.Count > 0)
				{
					deepHandles.Add("HocSinhCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<HocSinh>) DataRepository.HocSinhProvider.DeepLoad,
						new object[] { transactionManager, entity.HocSinhCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the QuanLyHocSinhPTNK.Entities.LopHoc object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">QuanLyHocSinhPTNK.Entities.LopHoc instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">QuanLyHocSinhPTNK.Entities.LopHoc Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.LopHoc entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<HocSinh>
				if (CanDeepSave(entity.HocSinhCollection, "List<HocSinh>|HocSinhCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(HocSinh child in entity.HocSinhCollection)
					{
						if(child.MaLopSource != null)
							child.MaLop = child.MaLopSource.MaLop;
						else
							child.MaLop = entity.MaLop;

					}

					if (entity.HocSinhCollection.Count > 0 || entity.HocSinhCollection.DeletedItems.Count > 0)
					{
						DataRepository.HocSinhProvider.Save(transactionManager, entity.HocSinhCollection);
						
						deepHandles.Add(
							(DeepSaveHandle< HocSinh >) DataRepository.HocSinhProvider.DeepSave,
							new object[] { transactionManager, entity.HocSinhCollection, deepSaveType, childTypes, innerList }
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
	/// for child properties in <c>QuanLyHocSinhPTNK.Entities.LopHoc</c>
	///</summary>
	public enum LopHocChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Khoi</c> at MaKhoiSource
		///</summary>
		[ChildEntityType(typeof(Khoi))]
		Khoi,
	
		///<summary>
		/// Collection of <c>LopHoc</c> as OneToMany for HocSinhCollection
		///</summary>
		[ChildEntityType(typeof(TList<HocSinh>))]
		HocSinhCollection,
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
