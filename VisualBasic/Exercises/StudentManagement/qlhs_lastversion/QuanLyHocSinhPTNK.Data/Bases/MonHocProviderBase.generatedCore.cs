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
	/// This class is the base class for any <see cref="MonHocProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class MonHocProviderBaseCore : EntityProviderBase<QuanLyHocSinhPTNK.Entities.MonHoc, QuanLyHocSinhPTNK.Entities.MonHocKey>
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
		public override bool Delete(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.MonHocKey key)
		{
			return Delete(transactionManager, key.MaMon);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="maMon">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String maMon)
		{
			return Delete(null, maMon);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maMon">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String maMon);		
		
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
		public override QuanLyHocSinhPTNK.Entities.MonHoc Get(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.MonHocKey key, int start, int pageLength)
		{
			return GetByMaMon(transactionManager, key.MaMon, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_MonHoc_1 index.
		/// </summary>
		/// <param name="maMon"></param>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.MonHoc"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.MonHoc GetByMaMon(System.String maMon)
		{
			int count = -1;
			return GetByMaMon(null,maMon, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_MonHoc_1 index.
		/// </summary>
		/// <param name="maMon"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.MonHoc"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.MonHoc GetByMaMon(System.String maMon, int start, int pageLength)
		{
			int count = -1;
			return GetByMaMon(null, maMon, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_MonHoc_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maMon"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.MonHoc"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.MonHoc GetByMaMon(TransactionManager transactionManager, System.String maMon)
		{
			int count = -1;
			return GetByMaMon(transactionManager, maMon, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_MonHoc_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maMon"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.MonHoc"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.MonHoc GetByMaMon(TransactionManager transactionManager, System.String maMon, int start, int pageLength)
		{
			int count = -1;
			return GetByMaMon(transactionManager, maMon, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_MonHoc_1 index.
		/// </summary>
		/// <param name="maMon"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.MonHoc"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.MonHoc GetByMaMon(System.String maMon, int start, int pageLength, out int count)
		{
			return GetByMaMon(null, maMon, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_MonHoc_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maMon"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.MonHoc"/> class.</returns>
		public abstract QuanLyHocSinhPTNK.Entities.MonHoc GetByMaMon(TransactionManager transactionManager, System.String maMon, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a QuanLyHocSinhPTNK.Entities.TList&lt;MonHoc&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="QuanLyHocSinhPTNK.Entities.TList&lt;MonHoc&gt;"/></returns>
		public static QuanLyHocSinhPTNK.Entities.TList<MonHoc> Fill(IDataReader reader, QuanLyHocSinhPTNK.Entities.TList<MonHoc> rows, int start, int pageLength)
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
			
			QuanLyHocSinhPTNK.Entities.MonHoc c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("MonHoc")
			.Append("|").Append((reader.IsDBNull(((int)QuanLyHocSinhPTNK.Entities.MonHocColumn.MaMon - 1))?string.Empty:(System.String)reader[((int)QuanLyHocSinhPTNK.Entities.MonHocColumn.MaMon - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<MonHoc>(
			key.ToString(), // EntityTrackingKey
			"MonHoc",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new QuanLyHocSinhPTNK.Entities.MonHoc();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.MaMon = (System.String)reader["MaMon"];
			c.OriginalMaMon = c.MaMon;
			c.TenMon = (System.String)reader["TenMon"];
			c.EntityTrackingKey = key;
			c.AcceptChanges();
			c.SuppressEntityEvents = false;
			}
			rows.Add(c);
		}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="QuanLyHocSinhPTNK.Entities.MonHoc"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="QuanLyHocSinhPTNK.Entities.MonHoc"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, QuanLyHocSinhPTNK.Entities.MonHoc entity)
		{
			if (!reader.Read()) return;
			
			entity.MaMon = (System.String)reader["MaMon"];
			entity.OriginalMaMon = (System.String)reader["MaMon"];
			entity.TenMon = (System.String)reader["TenMon"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="QuanLyHocSinhPTNK.Entities.MonHoc"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="QuanLyHocSinhPTNK.Entities.MonHoc"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, QuanLyHocSinhPTNK.Entities.MonHoc entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.MaMon = (System.String)dataRow["MaMon"];
			entity.OriginalMaMon = (System.String)dataRow["MaMon"];
			entity.TenMon = (System.String)dataRow["TenMon"];
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
		/// <param name="entity">The <see cref="QuanLyHocSinhPTNK.Entities.MonHoc"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">QuanLyHocSinhPTNK.Entities.MonHoc Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.MonHoc entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByMaMon methods when available
			
			#region DiemCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Diem>|DiemCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DiemCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DiemCollection = DataRepository.DiemProvider.GetByMaMon(transactionManager, entity.MaMon);

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
		/// Deep Save the entire object graph of the QuanLyHocSinhPTNK.Entities.MonHoc object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">QuanLyHocSinhPTNK.Entities.MonHoc instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">QuanLyHocSinhPTNK.Entities.MonHoc Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.MonHoc entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<Diem>
				if (CanDeepSave(entity.DiemCollection, "List<Diem>|DiemCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Diem child in entity.DiemCollection)
					{
						if(child.MaMonSource != null)
							child.MaMon = child.MaMonSource.MaMon;
						else
							child.MaMon = entity.MaMon;

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
	
	#region MonHocChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>QuanLyHocSinhPTNK.Entities.MonHoc</c>
	///</summary>
	public enum MonHocChildEntityTypes
	{

		///<summary>
		/// Collection of <c>MonHoc</c> as OneToMany for DiemCollection
		///</summary>
		[ChildEntityType(typeof(TList<Diem>))]
		DiemCollection,
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
