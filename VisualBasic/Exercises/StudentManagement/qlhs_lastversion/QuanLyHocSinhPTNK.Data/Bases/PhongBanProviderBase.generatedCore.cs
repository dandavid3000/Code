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
	/// This class is the base class for any <see cref="PhongBanProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class PhongBanProviderBaseCore : EntityProviderBase<QuanLyHocSinhPTNK.Entities.PhongBan, QuanLyHocSinhPTNK.Entities.PhongBanKey>
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
		public override bool Delete(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.PhongBanKey key)
		{
			return Delete(transactionManager, key.MaPhongBan);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="maPhongBan">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String maPhongBan)
		{
			return Delete(null, maPhongBan);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maPhongBan">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String maPhongBan);		
		
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
		public override QuanLyHocSinhPTNK.Entities.PhongBan Get(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.PhongBanKey key, int start, int pageLength)
		{
			return GetByMaPhongBan(transactionManager, key.MaPhongBan, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_PhongBan index.
		/// </summary>
		/// <param name="maPhongBan"></param>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.PhongBan"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.PhongBan GetByMaPhongBan(System.String maPhongBan)
		{
			int count = -1;
			return GetByMaPhongBan(null,maPhongBan, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_PhongBan index.
		/// </summary>
		/// <param name="maPhongBan"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.PhongBan"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.PhongBan GetByMaPhongBan(System.String maPhongBan, int start, int pageLength)
		{
			int count = -1;
			return GetByMaPhongBan(null, maPhongBan, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_PhongBan index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maPhongBan"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.PhongBan"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.PhongBan GetByMaPhongBan(TransactionManager transactionManager, System.String maPhongBan)
		{
			int count = -1;
			return GetByMaPhongBan(transactionManager, maPhongBan, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_PhongBan index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maPhongBan"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.PhongBan"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.PhongBan GetByMaPhongBan(TransactionManager transactionManager, System.String maPhongBan, int start, int pageLength)
		{
			int count = -1;
			return GetByMaPhongBan(transactionManager, maPhongBan, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_PhongBan index.
		/// </summary>
		/// <param name="maPhongBan"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.PhongBan"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.PhongBan GetByMaPhongBan(System.String maPhongBan, int start, int pageLength, out int count)
		{
			return GetByMaPhongBan(null, maPhongBan, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_PhongBan index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maPhongBan"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.PhongBan"/> class.</returns>
		public abstract QuanLyHocSinhPTNK.Entities.PhongBan GetByMaPhongBan(TransactionManager transactionManager, System.String maPhongBan, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a QuanLyHocSinhPTNK.Entities.TList&lt;PhongBan&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="QuanLyHocSinhPTNK.Entities.TList&lt;PhongBan&gt;"/></returns>
		public static QuanLyHocSinhPTNK.Entities.TList<PhongBan> Fill(IDataReader reader, QuanLyHocSinhPTNK.Entities.TList<PhongBan> rows, int start, int pageLength)
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
			
			QuanLyHocSinhPTNK.Entities.PhongBan c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("PhongBan")
			.Append("|").Append((reader.IsDBNull(((int)QuanLyHocSinhPTNK.Entities.PhongBanColumn.MaPhongBan - 1))?string.Empty:(System.String)reader[((int)QuanLyHocSinhPTNK.Entities.PhongBanColumn.MaPhongBan - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<PhongBan>(
			key.ToString(), // EntityTrackingKey
			"PhongBan",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new QuanLyHocSinhPTNK.Entities.PhongBan();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.MaPhongBan = (System.String)reader["MaPhongBan"];
			c.OriginalMaPhongBan = c.MaPhongBan;
			c.TenPhongBan = (System.String)reader["TenPhongBan"];
			c.EntityTrackingKey = key;
			c.AcceptChanges();
			c.SuppressEntityEvents = false;
			}
			rows.Add(c);
		}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="QuanLyHocSinhPTNK.Entities.PhongBan"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="QuanLyHocSinhPTNK.Entities.PhongBan"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, QuanLyHocSinhPTNK.Entities.PhongBan entity)
		{
			if (!reader.Read()) return;
			
			entity.MaPhongBan = (System.String)reader["MaPhongBan"];
			entity.OriginalMaPhongBan = (System.String)reader["MaPhongBan"];
			entity.TenPhongBan = (System.String)reader["TenPhongBan"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="QuanLyHocSinhPTNK.Entities.PhongBan"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="QuanLyHocSinhPTNK.Entities.PhongBan"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, QuanLyHocSinhPTNK.Entities.PhongBan entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.MaPhongBan = (System.String)dataRow["MaPhongBan"];
			entity.OriginalMaPhongBan = (System.String)dataRow["MaPhongBan"];
			entity.TenPhongBan = (System.String)dataRow["TenPhongBan"];
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
		/// <param name="entity">The <see cref="QuanLyHocSinhPTNK.Entities.PhongBan"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">QuanLyHocSinhPTNK.Entities.PhongBan Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.PhongBan entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByMaPhongBan methods when available
			
			#region QuanLyCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<QuanLy>|QuanLyCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'QuanLyCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.QuanLyCollection = DataRepository.QuanLyProvider.GetByMaPhongBan(transactionManager, entity.MaPhongBan);

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
		/// Deep Save the entire object graph of the QuanLyHocSinhPTNK.Entities.PhongBan object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">QuanLyHocSinhPTNK.Entities.PhongBan instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">QuanLyHocSinhPTNK.Entities.PhongBan Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.PhongBan entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
						if(child.MaPhongBanSource != null)
							child.MaPhongBan = child.MaPhongBanSource.MaPhongBan;
						else
							child.MaPhongBan = entity.MaPhongBan;

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
	
	#region PhongBanChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>QuanLyHocSinhPTNK.Entities.PhongBan</c>
	///</summary>
	public enum PhongBanChildEntityTypes
	{

		///<summary>
		/// Collection of <c>PhongBan</c> as OneToMany for QuanLyCollection
		///</summary>
		[ChildEntityType(typeof(TList<QuanLy>))]
		QuanLyCollection,
	}
	
	#endregion PhongBanChildEntityTypes
	
	#region PhongBanFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;PhongBanColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PhongBan"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PhongBanFilterBuilder : SqlFilterBuilder<PhongBanColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PhongBanFilterBuilder class.
		/// </summary>
		public PhongBanFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the PhongBanFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PhongBanFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PhongBanFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PhongBanFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PhongBanFilterBuilder
	
	#region PhongBanParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;PhongBanColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PhongBan"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PhongBanParameterBuilder : ParameterizedSqlFilterBuilder<PhongBanColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PhongBanParameterBuilder class.
		/// </summary>
		public PhongBanParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the PhongBanParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PhongBanParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PhongBanParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PhongBanParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PhongBanParameterBuilder
} // end namespace
