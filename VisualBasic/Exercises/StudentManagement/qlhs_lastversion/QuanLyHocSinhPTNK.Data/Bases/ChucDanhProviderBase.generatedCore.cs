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
	/// This class is the base class for any <see cref="ChucDanhProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ChucDanhProviderBaseCore : EntityProviderBase<QuanLyHocSinhPTNK.Entities.ChucDanh, QuanLyHocSinhPTNK.Entities.ChucDanhKey>
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
		public override bool Delete(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.ChucDanhKey key)
		{
			return Delete(transactionManager, key.MaChucDanh);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="maChucDanh">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String maChucDanh)
		{
			return Delete(null, maChucDanh);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maChucDanh">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String maChucDanh);		
		
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
		public override QuanLyHocSinhPTNK.Entities.ChucDanh Get(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.ChucDanhKey key, int start, int pageLength)
		{
			return GetByMaChucDanh(transactionManager, key.MaChucDanh, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ChucDanh index.
		/// </summary>
		/// <param name="maChucDanh"></param>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.ChucDanh"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.ChucDanh GetByMaChucDanh(System.String maChucDanh)
		{
			int count = -1;
			return GetByMaChucDanh(null,maChucDanh, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ChucDanh index.
		/// </summary>
		/// <param name="maChucDanh"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.ChucDanh"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.ChucDanh GetByMaChucDanh(System.String maChucDanh, int start, int pageLength)
		{
			int count = -1;
			return GetByMaChucDanh(null, maChucDanh, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ChucDanh index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maChucDanh"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.ChucDanh"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.ChucDanh GetByMaChucDanh(TransactionManager transactionManager, System.String maChucDanh)
		{
			int count = -1;
			return GetByMaChucDanh(transactionManager, maChucDanh, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ChucDanh index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maChucDanh"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.ChucDanh"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.ChucDanh GetByMaChucDanh(TransactionManager transactionManager, System.String maChucDanh, int start, int pageLength)
		{
			int count = -1;
			return GetByMaChucDanh(transactionManager, maChucDanh, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ChucDanh index.
		/// </summary>
		/// <param name="maChucDanh"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.ChucDanh"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.ChucDanh GetByMaChucDanh(System.String maChucDanh, int start, int pageLength, out int count)
		{
			return GetByMaChucDanh(null, maChucDanh, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ChucDanh index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maChucDanh"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.ChucDanh"/> class.</returns>
		public abstract QuanLyHocSinhPTNK.Entities.ChucDanh GetByMaChucDanh(TransactionManager transactionManager, System.String maChucDanh, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a QuanLyHocSinhPTNK.Entities.TList&lt;ChucDanh&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="QuanLyHocSinhPTNK.Entities.TList&lt;ChucDanh&gt;"/></returns>
		public static QuanLyHocSinhPTNK.Entities.TList<ChucDanh> Fill(IDataReader reader, QuanLyHocSinhPTNK.Entities.TList<ChucDanh> rows, int start, int pageLength)
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
			
			QuanLyHocSinhPTNK.Entities.ChucDanh c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("ChucDanh")
			.Append("|").Append((reader.IsDBNull(((int)QuanLyHocSinhPTNK.Entities.ChucDanhColumn.MaChucDanh - 1))?string.Empty:(System.String)reader[((int)QuanLyHocSinhPTNK.Entities.ChucDanhColumn.MaChucDanh - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<ChucDanh>(
			key.ToString(), // EntityTrackingKey
			"ChucDanh",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new QuanLyHocSinhPTNK.Entities.ChucDanh();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.MaChucDanh = (System.String)reader["MaChucDanh"];
			c.OriginalMaChucDanh = c.MaChucDanh;
			c.TenChucDanh = (System.String)reader["TenChucDanh"];
			c.EntityTrackingKey = key;
			c.AcceptChanges();
			c.SuppressEntityEvents = false;
			}
			rows.Add(c);
		}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="QuanLyHocSinhPTNK.Entities.ChucDanh"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="QuanLyHocSinhPTNK.Entities.ChucDanh"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, QuanLyHocSinhPTNK.Entities.ChucDanh entity)
		{
			if (!reader.Read()) return;
			
			entity.MaChucDanh = (System.String)reader["MaChucDanh"];
			entity.OriginalMaChucDanh = (System.String)reader["MaChucDanh"];
			entity.TenChucDanh = (System.String)reader["TenChucDanh"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="QuanLyHocSinhPTNK.Entities.ChucDanh"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="QuanLyHocSinhPTNK.Entities.ChucDanh"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, QuanLyHocSinhPTNK.Entities.ChucDanh entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.MaChucDanh = (System.String)dataRow["MaChucDanh"];
			entity.OriginalMaChucDanh = (System.String)dataRow["MaChucDanh"];
			entity.TenChucDanh = (System.String)dataRow["TenChucDanh"];
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
		/// <param name="entity">The <see cref="QuanLyHocSinhPTNK.Entities.ChucDanh"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">QuanLyHocSinhPTNK.Entities.ChucDanh Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.ChucDanh entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByMaChucDanh methods when available
			
			#region QuanLyCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<QuanLy>|QuanLyCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'QuanLyCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.QuanLyCollection = DataRepository.QuanLyProvider.GetByMaChucDanh(transactionManager, entity.MaChucDanh);

				if (deep && entity.QuanLyCollection.Count > 0)
				{
					deepHandles.Add("QuanLyCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<QuanLy>) DataRepository.QuanLyProvider.DeepLoad,
						new object[] { transactionManager, entity.QuanLyCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the QuanLyHocSinhPTNK.Entities.ChucDanh object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">QuanLyHocSinhPTNK.Entities.ChucDanh instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">QuanLyHocSinhPTNK.Entities.ChucDanh Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.ChucDanh entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<QuanLy>
				if (CanDeepSave(entity.QuanLyCollection, "List<QuanLy>|QuanLyCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(QuanLy child in entity.QuanLyCollection)
					{
						if(child.MaChucDanhSource != null)
							child.MaChucDanh = child.MaChucDanhSource.MaChucDanh;
						else
							child.MaChucDanh = entity.MaChucDanh;

					}

					if (entity.QuanLyCollection.Count > 0 || entity.QuanLyCollection.DeletedItems.Count > 0)
					{
						DataRepository.QuanLyProvider.Save(transactionManager, entity.QuanLyCollection);
						
						deepHandles.Add(
							(DeepSaveHandle< QuanLy >) DataRepository.QuanLyProvider.DeepSave,
							new object[] { transactionManager, entity.QuanLyCollection, deepSaveType, childTypes, innerList }
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
	
	#region ChucDanhChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>QuanLyHocSinhPTNK.Entities.ChucDanh</c>
	///</summary>
	public enum ChucDanhChildEntityTypes
	{

		///<summary>
		/// Collection of <c>ChucDanh</c> as OneToMany for QuanLyCollection
		///</summary>
		[ChildEntityType(typeof(TList<QuanLy>))]
		QuanLyCollection,
	}
	
	#endregion ChucDanhChildEntityTypes
	
	#region ChucDanhFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ChucDanhColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ChucDanh"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ChucDanhFilterBuilder : SqlFilterBuilder<ChucDanhColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ChucDanhFilterBuilder class.
		/// </summary>
		public ChucDanhFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ChucDanhFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ChucDanhFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ChucDanhFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ChucDanhFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ChucDanhFilterBuilder
	
	#region ChucDanhParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ChucDanhColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ChucDanh"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ChucDanhParameterBuilder : ParameterizedSqlFilterBuilder<ChucDanhColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ChucDanhParameterBuilder class.
		/// </summary>
		public ChucDanhParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ChucDanhParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ChucDanhParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ChucDanhParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ChucDanhParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ChucDanhParameterBuilder
} // end namespace
