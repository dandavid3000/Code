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
	/// This class is the base class for any <see cref="KhoiProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class KhoiProviderBaseCore : EntityProviderBase<QuanLyHocSinhPTNK.Entities.Khoi, QuanLyHocSinhPTNK.Entities.KhoiKey>
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
		public override bool Delete(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.KhoiKey key)
		{
			return Delete(transactionManager, key.MaKhoi);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="maKhoi">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String maKhoi)
		{
			return Delete(null, maKhoi);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maKhoi">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String maKhoi);		
		
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
		public override QuanLyHocSinhPTNK.Entities.Khoi Get(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.KhoiKey key, int start, int pageLength)
		{
			return GetByMaKhoi(transactionManager, key.MaKhoi, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Khoi index.
		/// </summary>
		/// <param name="maKhoi"></param>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.Khoi"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.Khoi GetByMaKhoi(System.String maKhoi)
		{
			int count = -1;
			return GetByMaKhoi(null,maKhoi, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Khoi index.
		/// </summary>
		/// <param name="maKhoi"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.Khoi"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.Khoi GetByMaKhoi(System.String maKhoi, int start, int pageLength)
		{
			int count = -1;
			return GetByMaKhoi(null, maKhoi, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Khoi index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maKhoi"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.Khoi"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.Khoi GetByMaKhoi(TransactionManager transactionManager, System.String maKhoi)
		{
			int count = -1;
			return GetByMaKhoi(transactionManager, maKhoi, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Khoi index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maKhoi"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.Khoi"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.Khoi GetByMaKhoi(TransactionManager transactionManager, System.String maKhoi, int start, int pageLength)
		{
			int count = -1;
			return GetByMaKhoi(transactionManager, maKhoi, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Khoi index.
		/// </summary>
		/// <param name="maKhoi"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.Khoi"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.Khoi GetByMaKhoi(System.String maKhoi, int start, int pageLength, out int count)
		{
			return GetByMaKhoi(null, maKhoi, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Khoi index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maKhoi"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.Khoi"/> class.</returns>
		public abstract QuanLyHocSinhPTNK.Entities.Khoi GetByMaKhoi(TransactionManager transactionManager, System.String maKhoi, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a QuanLyHocSinhPTNK.Entities.TList&lt;Khoi&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="QuanLyHocSinhPTNK.Entities.TList&lt;Khoi&gt;"/></returns>
		public static QuanLyHocSinhPTNK.Entities.TList<Khoi> Fill(IDataReader reader, QuanLyHocSinhPTNK.Entities.TList<Khoi> rows, int start, int pageLength)
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
			
			QuanLyHocSinhPTNK.Entities.Khoi c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("Khoi")
			.Append("|").Append((reader.IsDBNull(((int)QuanLyHocSinhPTNK.Entities.KhoiColumn.MaKhoi - 1))?string.Empty:(System.String)reader[((int)QuanLyHocSinhPTNK.Entities.KhoiColumn.MaKhoi - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<Khoi>(
			key.ToString(), // EntityTrackingKey
			"Khoi",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new QuanLyHocSinhPTNK.Entities.Khoi();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.MaKhoi = (System.String)reader["MaKhoi"];
			c.OriginalMaKhoi = c.MaKhoi;
			c.TenKhoi = (System.String)reader["TenKhoi"];
			c.EntityTrackingKey = key;
			c.AcceptChanges();
			c.SuppressEntityEvents = false;
			}
			rows.Add(c);
		}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="QuanLyHocSinhPTNK.Entities.Khoi"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="QuanLyHocSinhPTNK.Entities.Khoi"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, QuanLyHocSinhPTNK.Entities.Khoi entity)
		{
			if (!reader.Read()) return;
			
			entity.MaKhoi = (System.String)reader["MaKhoi"];
			entity.OriginalMaKhoi = (System.String)reader["MaKhoi"];
			entity.TenKhoi = (System.String)reader["TenKhoi"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="QuanLyHocSinhPTNK.Entities.Khoi"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="QuanLyHocSinhPTNK.Entities.Khoi"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, QuanLyHocSinhPTNK.Entities.Khoi entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.MaKhoi = (System.String)dataRow["MaKhoi"];
			entity.OriginalMaKhoi = (System.String)dataRow["MaKhoi"];
			entity.TenKhoi = (System.String)dataRow["TenKhoi"];
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
		/// <param name="entity">The <see cref="QuanLyHocSinhPTNK.Entities.Khoi"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">QuanLyHocSinhPTNK.Entities.Khoi Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.Khoi entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByMaKhoi methods when available
			
			#region LopHocCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<LopHoc>|LopHocCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LopHocCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.LopHocCollection = DataRepository.LopHocProvider.GetByMaKhoi(transactionManager, entity.MaKhoi);

				if (deep && entity.LopHocCollection.Count > 0)
				{
					deepHandles.Add("LopHocCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<LopHoc>) DataRepository.LopHocProvider.DeepLoad,
						new object[] { transactionManager, entity.LopHocCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the QuanLyHocSinhPTNK.Entities.Khoi object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">QuanLyHocSinhPTNK.Entities.Khoi instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">QuanLyHocSinhPTNK.Entities.Khoi Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.Khoi entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<LopHoc>
				if (CanDeepSave(entity.LopHocCollection, "List<LopHoc>|LopHocCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(LopHoc child in entity.LopHocCollection)
					{
						if(child.MaKhoiSource != null)
							child.MaKhoi = child.MaKhoiSource.MaKhoi;
						else
							child.MaKhoi = entity.MaKhoi;

					}

					if (entity.LopHocCollection.Count > 0 || entity.LopHocCollection.DeletedItems.Count > 0)
					{
						DataRepository.LopHocProvider.Save(transactionManager, entity.LopHocCollection);
						
						deepHandles.Add(
							(DeepSaveHandle< LopHoc >) DataRepository.LopHocProvider.DeepSave,
							new object[] { transactionManager, entity.LopHocCollection, deepSaveType, childTypes, innerList }
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
	
	#region KhoiChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>QuanLyHocSinhPTNK.Entities.Khoi</c>
	///</summary>
	public enum KhoiChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Khoi</c> as OneToMany for LopHocCollection
		///</summary>
		[ChildEntityType(typeof(TList<LopHoc>))]
		LopHocCollection,
	}
	
	#endregion KhoiChildEntityTypes
	
	#region KhoiFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;KhoiColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Khoi"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KhoiFilterBuilder : SqlFilterBuilder<KhoiColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KhoiFilterBuilder class.
		/// </summary>
		public KhoiFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the KhoiFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public KhoiFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the KhoiFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public KhoiFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion KhoiFilterBuilder
	
	#region KhoiParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;KhoiColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Khoi"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KhoiParameterBuilder : ParameterizedSqlFilterBuilder<KhoiColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KhoiParameterBuilder class.
		/// </summary>
		public KhoiParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the KhoiParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public KhoiParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the KhoiParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public KhoiParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion KhoiParameterBuilder
} // end namespace
