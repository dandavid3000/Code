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
	/// This class is the base class for any <see cref="ThoiKhoaBieuProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ThoiKhoaBieuProviderBaseCore : EntityProviderBase<PTNK.Entities.ThoiKhoaBieu, PTNK.Entities.ThoiKhoaBieuKey>
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
		public override bool Delete(TransactionManager transactionManager, PTNK.Entities.ThoiKhoaBieuKey key)
		{
			return Delete(transactionManager, key.MaThoiKhoaBieu);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="maThoiKhoaBieu">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String maThoiKhoaBieu)
		{
			return Delete(null, maThoiKhoaBieu);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maThoiKhoaBieu">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String maThoiKhoaBieu);		
		
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
		public override PTNK.Entities.ThoiKhoaBieu Get(TransactionManager transactionManager, PTNK.Entities.ThoiKhoaBieuKey key, int start, int pageLength)
		{
			return GetByMaThoiKhoaBieu(transactionManager, key.MaThoiKhoaBieu, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key ThoiKhoaBieu$PrimaryKey index.
		/// </summary>
		/// <param name="maThoiKhoaBieu"></param>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.ThoiKhoaBieu"/> class.</returns>
		public PTNK.Entities.ThoiKhoaBieu GetByMaThoiKhoaBieu(System.String maThoiKhoaBieu)
		{
			int count = -1;
			return GetByMaThoiKhoaBieu(null,maThoiKhoaBieu, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ThoiKhoaBieu$PrimaryKey index.
		/// </summary>
		/// <param name="maThoiKhoaBieu"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.ThoiKhoaBieu"/> class.</returns>
		public PTNK.Entities.ThoiKhoaBieu GetByMaThoiKhoaBieu(System.String maThoiKhoaBieu, int start, int pageLength)
		{
			int count = -1;
			return GetByMaThoiKhoaBieu(null, maThoiKhoaBieu, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ThoiKhoaBieu$PrimaryKey index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maThoiKhoaBieu"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.ThoiKhoaBieu"/> class.</returns>
		public PTNK.Entities.ThoiKhoaBieu GetByMaThoiKhoaBieu(TransactionManager transactionManager, System.String maThoiKhoaBieu)
		{
			int count = -1;
			return GetByMaThoiKhoaBieu(transactionManager, maThoiKhoaBieu, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ThoiKhoaBieu$PrimaryKey index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maThoiKhoaBieu"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.ThoiKhoaBieu"/> class.</returns>
		public PTNK.Entities.ThoiKhoaBieu GetByMaThoiKhoaBieu(TransactionManager transactionManager, System.String maThoiKhoaBieu, int start, int pageLength)
		{
			int count = -1;
			return GetByMaThoiKhoaBieu(transactionManager, maThoiKhoaBieu, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ThoiKhoaBieu$PrimaryKey index.
		/// </summary>
		/// <param name="maThoiKhoaBieu"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.ThoiKhoaBieu"/> class.</returns>
		public PTNK.Entities.ThoiKhoaBieu GetByMaThoiKhoaBieu(System.String maThoiKhoaBieu, int start, int pageLength, out int count)
		{
			return GetByMaThoiKhoaBieu(null, maThoiKhoaBieu, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the ThoiKhoaBieu$PrimaryKey index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maThoiKhoaBieu"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.ThoiKhoaBieu"/> class.</returns>
		public abstract PTNK.Entities.ThoiKhoaBieu GetByMaThoiKhoaBieu(TransactionManager transactionManager, System.String maThoiKhoaBieu, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a PTNK.Entities.TList&lt;ThoiKhoaBieu&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="PTNK.Entities.TList&lt;ThoiKhoaBieu&gt;"/></returns>
		public static PTNK.Entities.TList<ThoiKhoaBieu> Fill(IDataReader reader, PTNK.Entities.TList<ThoiKhoaBieu> rows, int start, int pageLength)
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
			
			PTNK.Entities.ThoiKhoaBieu c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("ThoiKhoaBieu")
			.Append("|").Append((reader.IsDBNull(((int)PTNK.Entities.ThoiKhoaBieuColumn.MaThoiKhoaBieu - 1))?string.Empty:(System.String)reader[((int)PTNK.Entities.ThoiKhoaBieuColumn.MaThoiKhoaBieu - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<ThoiKhoaBieu>(
			key.ToString(), // EntityTrackingKey
			"ThoiKhoaBieu",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new PTNK.Entities.ThoiKhoaBieu();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.MaThoiKhoaBieu = (System.String)reader["MaThoiKhoaBieu"];
			c.OriginalMaThoiKhoaBieu = c.MaThoiKhoaBieu;
			c.MaPhanCong = reader.IsDBNull(reader.GetOrdinal("MaPhanCong")) ? null : (System.String)reader["MaPhanCong"];
			c.MaLopHoc = reader.IsDBNull(reader.GetOrdinal("MaLopHoc")) ? null : (System.String)reader["MaLopHoc"];
			c.PhuTrach = reader.IsDBNull(reader.GetOrdinal("PhuTrach")) ? null : (System.String)reader["PhuTrach"];
			c.Thu = reader.IsDBNull(reader.GetOrdinal("Thu")) ? null : (System.Int32?)reader["Thu"];
			c.TietHoc = reader.IsDBNull(reader.GetOrdinal("TietHoc")) ? null : (System.Int32?)reader["TietHoc"];
			c.EntityTrackingKey = key;
			c.AcceptChanges();
			c.SuppressEntityEvents = false;
			}
			rows.Add(c);
		}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="PTNK.Entities.ThoiKhoaBieu"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="PTNK.Entities.ThoiKhoaBieu"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, PTNK.Entities.ThoiKhoaBieu entity)
		{
			if (!reader.Read()) return;
			
			entity.MaThoiKhoaBieu = (System.String)reader["MaThoiKhoaBieu"];
			entity.OriginalMaThoiKhoaBieu = (System.String)reader["MaThoiKhoaBieu"];
			entity.MaPhanCong = reader.IsDBNull(reader.GetOrdinal("MaPhanCong")) ? null : (System.String)reader["MaPhanCong"];
			entity.MaLopHoc = reader.IsDBNull(reader.GetOrdinal("MaLopHoc")) ? null : (System.String)reader["MaLopHoc"];
			entity.PhuTrach = reader.IsDBNull(reader.GetOrdinal("PhuTrach")) ? null : (System.String)reader["PhuTrach"];
			entity.Thu = reader.IsDBNull(reader.GetOrdinal("Thu")) ? null : (System.Int32?)reader["Thu"];
			entity.TietHoc = reader.IsDBNull(reader.GetOrdinal("TietHoc")) ? null : (System.Int32?)reader["TietHoc"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="PTNK.Entities.ThoiKhoaBieu"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="PTNK.Entities.ThoiKhoaBieu"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, PTNK.Entities.ThoiKhoaBieu entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.MaThoiKhoaBieu = (System.String)dataRow["MaThoiKhoaBieu"];
			entity.OriginalMaThoiKhoaBieu = (System.String)dataRow["MaThoiKhoaBieu"];
			entity.MaPhanCong = Convert.IsDBNull(dataRow["MaPhanCong"]) ? null : (System.String)dataRow["MaPhanCong"];
			entity.MaLopHoc = Convert.IsDBNull(dataRow["MaLopHoc"]) ? null : (System.String)dataRow["MaLopHoc"];
			entity.PhuTrach = Convert.IsDBNull(dataRow["PhuTrach"]) ? null : (System.String)dataRow["PhuTrach"];
			entity.Thu = Convert.IsDBNull(dataRow["Thu"]) ? null : (System.Int32?)dataRow["Thu"];
			entity.TietHoc = Convert.IsDBNull(dataRow["TietHoc"]) ? null : (System.Int32?)dataRow["TietHoc"];
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
		/// <param name="entity">The <see cref="PTNK.Entities.ThoiKhoaBieu"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">PTNK.Entities.ThoiKhoaBieu Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, PTNK.Entities.ThoiKhoaBieu entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
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
		/// Deep Save the entire object graph of the PTNK.Entities.ThoiKhoaBieu object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">PTNK.Entities.ThoiKhoaBieu instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">PTNK.Entities.ThoiKhoaBieu Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, PTNK.Entities.ThoiKhoaBieu entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region ThoiKhoaBieuChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>PTNK.Entities.ThoiKhoaBieu</c>
	///</summary>
	public enum ThoiKhoaBieuChildEntityTypes
	{
	}
	
	#endregion ThoiKhoaBieuChildEntityTypes
	
	#region ThoiKhoaBieuFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ThoiKhoaBieuColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ThoiKhoaBieu"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ThoiKhoaBieuFilterBuilder : SqlFilterBuilder<ThoiKhoaBieuColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ThoiKhoaBieuFilterBuilder class.
		/// </summary>
		public ThoiKhoaBieuFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ThoiKhoaBieuFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ThoiKhoaBieuFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ThoiKhoaBieuFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ThoiKhoaBieuFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ThoiKhoaBieuFilterBuilder
	
	#region ThoiKhoaBieuParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ThoiKhoaBieuColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ThoiKhoaBieu"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ThoiKhoaBieuParameterBuilder : ParameterizedSqlFilterBuilder<ThoiKhoaBieuColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ThoiKhoaBieuParameterBuilder class.
		/// </summary>
		public ThoiKhoaBieuParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ThoiKhoaBieuParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ThoiKhoaBieuParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ThoiKhoaBieuParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ThoiKhoaBieuParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ThoiKhoaBieuParameterBuilder
} // end namespace
