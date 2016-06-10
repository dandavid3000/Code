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
	/// This class is the base class for any <see cref="BangDiemProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class BangDiemProviderBaseCore : EntityProviderBase<QuanLyHocSinhPTNK.Entities.BangDiem, QuanLyHocSinhPTNK.Entities.BangDiemKey>
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
		public override bool Delete(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.BangDiemKey key)
		{
			return Delete(transactionManager, key.MaBangDiem);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="maBangDiem">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String maBangDiem)
		{
			return Delete(null, maBangDiem);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maBangDiem">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String maBangDiem);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_BangDiem_HocSinh key.
		///		FK_BangDiem_HocSinh Description: 
		/// </summary>
		/// <param name="maHocSinh"></param>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.BangDiem objects.</returns>
		public QuanLyHocSinhPTNK.Entities.TList<BangDiem> GetByMaHocSinh(System.String maHocSinh)
		{
			int count = -1;
			return GetByMaHocSinh(maHocSinh, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_BangDiem_HocSinh key.
		///		FK_BangDiem_HocSinh Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maHocSinh"></param>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.BangDiem objects.</returns>
		/// <remarks></remarks>
		public QuanLyHocSinhPTNK.Entities.TList<BangDiem> GetByMaHocSinh(TransactionManager transactionManager, System.String maHocSinh)
		{
			int count = -1;
			return GetByMaHocSinh(transactionManager, maHocSinh, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_BangDiem_HocSinh key.
		///		FK_BangDiem_HocSinh Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maHocSinh"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.BangDiem objects.</returns>
		public QuanLyHocSinhPTNK.Entities.TList<BangDiem> GetByMaHocSinh(TransactionManager transactionManager, System.String maHocSinh, int start, int pageLength)
		{
			int count = -1;
			return GetByMaHocSinh(transactionManager, maHocSinh, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_BangDiem_HocSinh key.
		///		fkBangDiemHocSinh Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="maHocSinh"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.BangDiem objects.</returns>
		public QuanLyHocSinhPTNK.Entities.TList<BangDiem> GetByMaHocSinh(System.String maHocSinh, int start, int pageLength)
		{
			int count =  -1;
			return GetByMaHocSinh(null, maHocSinh, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_BangDiem_HocSinh key.
		///		fkBangDiemHocSinh Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="maHocSinh"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.BangDiem objects.</returns>
		public QuanLyHocSinhPTNK.Entities.TList<BangDiem> GetByMaHocSinh(System.String maHocSinh, int start, int pageLength,out int count)
		{
			return GetByMaHocSinh(null, maHocSinh, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_BangDiem_HocSinh key.
		///		FK_BangDiem_HocSinh Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maHocSinh"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of QuanLyHocSinhPTNK.Entities.BangDiem objects.</returns>
		public abstract QuanLyHocSinhPTNK.Entities.TList<BangDiem> GetByMaHocSinh(TransactionManager transactionManager, System.String maHocSinh, int start, int pageLength, out int count);
		
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
		public override QuanLyHocSinhPTNK.Entities.BangDiem Get(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.BangDiemKey key, int start, int pageLength)
		{
			return GetByMaBangDiem(transactionManager, key.MaBangDiem, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_BangDiem index.
		/// </summary>
		/// <param name="maBangDiem"></param>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.BangDiem"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.BangDiem GetByMaBangDiem(System.String maBangDiem)
		{
			int count = -1;
			return GetByMaBangDiem(null,maBangDiem, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_BangDiem index.
		/// </summary>
		/// <param name="maBangDiem"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.BangDiem"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.BangDiem GetByMaBangDiem(System.String maBangDiem, int start, int pageLength)
		{
			int count = -1;
			return GetByMaBangDiem(null, maBangDiem, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_BangDiem index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maBangDiem"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.BangDiem"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.BangDiem GetByMaBangDiem(TransactionManager transactionManager, System.String maBangDiem)
		{
			int count = -1;
			return GetByMaBangDiem(transactionManager, maBangDiem, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_BangDiem index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maBangDiem"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.BangDiem"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.BangDiem GetByMaBangDiem(TransactionManager transactionManager, System.String maBangDiem, int start, int pageLength)
		{
			int count = -1;
			return GetByMaBangDiem(transactionManager, maBangDiem, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_BangDiem index.
		/// </summary>
		/// <param name="maBangDiem"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.BangDiem"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.BangDiem GetByMaBangDiem(System.String maBangDiem, int start, int pageLength, out int count)
		{
			return GetByMaBangDiem(null, maBangDiem, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_BangDiem index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maBangDiem"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.BangDiem"/> class.</returns>
		public abstract QuanLyHocSinhPTNK.Entities.BangDiem GetByMaBangDiem(TransactionManager transactionManager, System.String maBangDiem, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a QuanLyHocSinhPTNK.Entities.TList&lt;BangDiem&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="QuanLyHocSinhPTNK.Entities.TList&lt;BangDiem&gt;"/></returns>
		public static QuanLyHocSinhPTNK.Entities.TList<BangDiem> Fill(IDataReader reader, QuanLyHocSinhPTNK.Entities.TList<BangDiem> rows, int start, int pageLength)
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
			
			QuanLyHocSinhPTNK.Entities.BangDiem c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("BangDiem")
			.Append("|").Append((reader.IsDBNull(((int)QuanLyHocSinhPTNK.Entities.BangDiemColumn.MaBangDiem - 1))?string.Empty:(System.String)reader[((int)QuanLyHocSinhPTNK.Entities.BangDiemColumn.MaBangDiem - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<BangDiem>(
			key.ToString(), // EntityTrackingKey
			"BangDiem",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new QuanLyHocSinhPTNK.Entities.BangDiem();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.MaBangDiem = (System.String)reader["MaBangDiem"];
			c.OriginalMaBangDiem = c.MaBangDiem;
			c.Dtb = (System.Double)reader["DTB"];
			c.MaHocSinh = (System.String)reader["MaHocSinh"];
			c.EntityTrackingKey = key;
			c.AcceptChanges();
			c.SuppressEntityEvents = false;
			}
			rows.Add(c);
		}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="QuanLyHocSinhPTNK.Entities.BangDiem"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="QuanLyHocSinhPTNK.Entities.BangDiem"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, QuanLyHocSinhPTNK.Entities.BangDiem entity)
		{
			if (!reader.Read()) return;
			
			entity.MaBangDiem = (System.String)reader["MaBangDiem"];
			entity.OriginalMaBangDiem = (System.String)reader["MaBangDiem"];
			entity.Dtb = (System.Double)reader["DTB"];
			entity.MaHocSinh = (System.String)reader["MaHocSinh"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="QuanLyHocSinhPTNK.Entities.BangDiem"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="QuanLyHocSinhPTNK.Entities.BangDiem"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, QuanLyHocSinhPTNK.Entities.BangDiem entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.MaBangDiem = (System.String)dataRow["MaBangDiem"];
			entity.OriginalMaBangDiem = (System.String)dataRow["MaBangDiem"];
			entity.Dtb = (System.Double)dataRow["DTB"];
			entity.MaHocSinh = (System.String)dataRow["MaHocSinh"];
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
		/// <param name="entity">The <see cref="QuanLyHocSinhPTNK.Entities.BangDiem"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">QuanLyHocSinhPTNK.Entities.BangDiem Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.BangDiem entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region MaHocSinhSource	
			if (CanDeepLoad(entity, "HocSinh|MaHocSinhSource", deepLoadType, innerList) 
				&& entity.MaHocSinhSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.MaHocSinh;
				HocSinh tmpEntity = EntityManager.LocateEntity<HocSinh>(EntityLocator.ConstructKeyFromPkItems(typeof(HocSinh), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.MaHocSinhSource = tmpEntity;
				else
					entity.MaHocSinhSource = DataRepository.HocSinhProvider.GetByMaHocSinh(transactionManager, entity.MaHocSinh);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MaHocSinhSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.MaHocSinhSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.HocSinhProvider.DeepLoad(transactionManager, entity.MaHocSinhSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion MaHocSinhSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByMaBangDiem methods when available
			
			#region DiemCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Diem>|DiemCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DiemCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DiemCollection = DataRepository.DiemProvider.GetByMaBangDiem(transactionManager, entity.MaBangDiem);

				if (deep && entity.DiemCollection.Count > 0)
				{
					deepHandles.Add("DiemCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Diem>) DataRepository.DiemProvider.DeepLoad,
						new object[] { transactionManager, entity.DiemCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the QuanLyHocSinhPTNK.Entities.BangDiem object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">QuanLyHocSinhPTNK.Entities.BangDiem instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">QuanLyHocSinhPTNK.Entities.BangDiem Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.BangDiem entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region MaHocSinhSource
			if (CanDeepSave(entity, "HocSinh|MaHocSinhSource", deepSaveType, innerList) 
				&& entity.MaHocSinhSource != null)
			{
				DataRepository.HocSinhProvider.Save(transactionManager, entity.MaHocSinhSource);
				entity.MaHocSinh = entity.MaHocSinhSource.MaHocSinh;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<Delegate, object> deepHandles = new Dictionary<Delegate, object>();
	
			#region List<Diem>
				if (CanDeepSave(entity.DiemCollection, "List<Diem>|DiemCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Diem child in entity.DiemCollection)
					{
						if(child.MaBangDiemSource != null)
							child.MaBangDiem = child.MaBangDiemSource.MaBangDiem;
						else
							child.MaBangDiem = entity.MaBangDiem;

					}

					if (entity.DiemCollection.Count > 0 || entity.DiemCollection.DeletedItems.Count > 0)
					{
						DataRepository.DiemProvider.Save(transactionManager, entity.DiemCollection);
						
						deepHandles.Add(
							(DeepSaveHandle< Diem >) DataRepository.DiemProvider.DeepSave,
							new object[] { transactionManager, entity.DiemCollection, deepSaveType, childTypes, innerList }
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
	
	#region BangDiemChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>QuanLyHocSinhPTNK.Entities.BangDiem</c>
	///</summary>
	public enum BangDiemChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>HocSinh</c> at MaHocSinhSource
		///</summary>
		[ChildEntityType(typeof(HocSinh))]
		HocSinh,
	
		///<summary>
		/// Collection of <c>BangDiem</c> as OneToMany for DiemCollection
		///</summary>
		[ChildEntityType(typeof(TList<Diem>))]
		DiemCollection,
	}
	
	#endregion BangDiemChildEntityTypes
	
	#region BangDiemFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;BangDiemColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BangDiem"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BangDiemFilterBuilder : SqlFilterBuilder<BangDiemColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BangDiemFilterBuilder class.
		/// </summary>
		public BangDiemFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the BangDiemFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BangDiemFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BangDiemFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BangDiemFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BangDiemFilterBuilder
	
	#region BangDiemParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;BangDiemColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BangDiem"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BangDiemParameterBuilder : ParameterizedSqlFilterBuilder<BangDiemColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BangDiemParameterBuilder class.
		/// </summary>
		public BangDiemParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the BangDiemParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BangDiemParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BangDiemParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BangDiemParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BangDiemParameterBuilder
} // end namespace
