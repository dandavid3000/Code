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
	/// This class is the base class for any <see cref="ThamSoProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ThamSoProviderBaseCore : EntityProviderBase<PTNK.Entities.ThamSo, PTNK.Entities.ThamSoKey>
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
		public override bool Delete(TransactionManager transactionManager, PTNK.Entities.ThamSoKey key)
		{
			return Delete(transactionManager, key.SoTietToiDaTrongNgay, key.TietGay, key.SoTietToiDaDuocHocTrongNgay);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="soTietToiDaTrongNgay">. Primary Key.</param>
		/// <param name="tietGay">. Primary Key.</param>
		/// <param name="soTietToiDaDuocHocTrongNgay">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Byte soTietToiDaTrongNgay, System.Byte tietGay, System.Int16 soTietToiDaDuocHocTrongNgay)
		{
			return Delete(null, soTietToiDaTrongNgay, tietGay, soTietToiDaDuocHocTrongNgay);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="soTietToiDaTrongNgay">. Primary Key.</param>
		/// <param name="tietGay">. Primary Key.</param>
		/// <param name="soTietToiDaDuocHocTrongNgay">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Byte soTietToiDaTrongNgay, System.Byte tietGay, System.Int16 soTietToiDaDuocHocTrongNgay);		
		
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
		public override PTNK.Entities.ThamSo Get(TransactionManager transactionManager, PTNK.Entities.ThamSoKey key, int start, int pageLength)
		{
			return GetBySoTietToiDaTrongNgayTietGaySoTietToiDaDuocHocTrongNgay(transactionManager, key.SoTietToiDaTrongNgay, key.TietGay, key.SoTietToiDaDuocHocTrongNgay, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key ThamSo$PrimaryKey index.
		/// </summary>
		/// <param name="soTietToiDaTrongNgay"></param>
		/// <param name="tietGay"></param>
		/// <param name="soTietToiDaDuocHocTrongNgay"></param>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.ThamSo"/> class.</returns>
		public PTNK.Entities.ThamSo GetBySoTietToiDaTrongNgayTietGaySoTietToiDaDuocHocTrongNgay(System.Byte soTietToiDaTrongNgay, System.Byte tietGay, System.Int16 soTietToiDaDuocHocTrongNgay)
		{
			int count = -1;
			return GetBySoTietToiDaTrongNgayTietGaySoTietToiDaDuocHocTrongNgay(null,soTietToiDaTrongNgay, tietGay, soTietToiDaDuocHocTrongNgay, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ThamSo$PrimaryKey index.
		/// </summary>
		/// <param name="soTietToiDaTrongNgay"></param>
		/// <param name="tietGay"></param>
		/// <param name="soTietToiDaDuocHocTrongNgay"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.ThamSo"/> class.</returns>
		public PTNK.Entities.ThamSo GetBySoTietToiDaTrongNgayTietGaySoTietToiDaDuocHocTrongNgay(System.Byte soTietToiDaTrongNgay, System.Byte tietGay, System.Int16 soTietToiDaDuocHocTrongNgay, int start, int pageLength)
		{
			int count = -1;
			return GetBySoTietToiDaTrongNgayTietGaySoTietToiDaDuocHocTrongNgay(null, soTietToiDaTrongNgay, tietGay, soTietToiDaDuocHocTrongNgay, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ThamSo$PrimaryKey index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="soTietToiDaTrongNgay"></param>
		/// <param name="tietGay"></param>
		/// <param name="soTietToiDaDuocHocTrongNgay"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.ThamSo"/> class.</returns>
		public PTNK.Entities.ThamSo GetBySoTietToiDaTrongNgayTietGaySoTietToiDaDuocHocTrongNgay(TransactionManager transactionManager, System.Byte soTietToiDaTrongNgay, System.Byte tietGay, System.Int16 soTietToiDaDuocHocTrongNgay)
		{
			int count = -1;
			return GetBySoTietToiDaTrongNgayTietGaySoTietToiDaDuocHocTrongNgay(transactionManager, soTietToiDaTrongNgay, tietGay, soTietToiDaDuocHocTrongNgay, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ThamSo$PrimaryKey index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="soTietToiDaTrongNgay"></param>
		/// <param name="tietGay"></param>
		/// <param name="soTietToiDaDuocHocTrongNgay"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.ThamSo"/> class.</returns>
		public PTNK.Entities.ThamSo GetBySoTietToiDaTrongNgayTietGaySoTietToiDaDuocHocTrongNgay(TransactionManager transactionManager, System.Byte soTietToiDaTrongNgay, System.Byte tietGay, System.Int16 soTietToiDaDuocHocTrongNgay, int start, int pageLength)
		{
			int count = -1;
			return GetBySoTietToiDaTrongNgayTietGaySoTietToiDaDuocHocTrongNgay(transactionManager, soTietToiDaTrongNgay, tietGay, soTietToiDaDuocHocTrongNgay, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ThamSo$PrimaryKey index.
		/// </summary>
		/// <param name="soTietToiDaTrongNgay"></param>
		/// <param name="tietGay"></param>
		/// <param name="soTietToiDaDuocHocTrongNgay"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.ThamSo"/> class.</returns>
		public PTNK.Entities.ThamSo GetBySoTietToiDaTrongNgayTietGaySoTietToiDaDuocHocTrongNgay(System.Byte soTietToiDaTrongNgay, System.Byte tietGay, System.Int16 soTietToiDaDuocHocTrongNgay, int start, int pageLength, out int count)
		{
			return GetBySoTietToiDaTrongNgayTietGaySoTietToiDaDuocHocTrongNgay(null, soTietToiDaTrongNgay, tietGay, soTietToiDaDuocHocTrongNgay, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the ThamSo$PrimaryKey index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="soTietToiDaTrongNgay"></param>
		/// <param name="tietGay"></param>
		/// <param name="soTietToiDaDuocHocTrongNgay"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="PTNK.Entities.ThamSo"/> class.</returns>
		public abstract PTNK.Entities.ThamSo GetBySoTietToiDaTrongNgayTietGaySoTietToiDaDuocHocTrongNgay(TransactionManager transactionManager, System.Byte soTietToiDaTrongNgay, System.Byte tietGay, System.Int16 soTietToiDaDuocHocTrongNgay, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a PTNK.Entities.TList&lt;ThamSo&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="PTNK.Entities.TList&lt;ThamSo&gt;"/></returns>
		public static PTNK.Entities.TList<ThamSo> Fill(IDataReader reader, PTNK.Entities.TList<ThamSo> rows, int start, int pageLength)
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
			
			PTNK.Entities.ThamSo c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("ThamSo")
			.Append("|").Append((reader.IsDBNull(((int)PTNK.Entities.ThamSoColumn.SoTietToiDaTrongNgay - 1))?(byte)0:(System.Byte)reader[((int)PTNK.Entities.ThamSoColumn.SoTietToiDaTrongNgay - 1)]).ToString())
			.Append("|").Append((reader.IsDBNull(((int)PTNK.Entities.ThamSoColumn.TietGay - 1))?(byte)0:(System.Byte)reader[((int)PTNK.Entities.ThamSoColumn.TietGay - 1)]).ToString())
			.Append("|").Append((reader.IsDBNull(((int)PTNK.Entities.ThamSoColumn.SoTietToiDaDuocHocTrongNgay - 1))?(short)0:(System.Int16)reader[((int)PTNK.Entities.ThamSoColumn.SoTietToiDaDuocHocTrongNgay - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<ThamSo>(
			key.ToString(), // EntityTrackingKey
			"ThamSo",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new PTNK.Entities.ThamSo();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.SoTietToiDaTrongNgay = (System.Byte)reader["SoTietToiDaTrongNgay"];
			c.OriginalSoTietToiDaTrongNgay = c.SoTietToiDaTrongNgay;
			c.TietGay = (System.Byte)reader["TietGay"];
			c.OriginalTietGay = c.TietGay;
			c.SoTietToiDaDuocHocTrongNgay = (System.Int16)reader["SoTietToiDaDuocHocTrongNgay"];
			c.OriginalSoTietToiDaDuocHocTrongNgay = c.SoTietToiDaDuocHocTrongNgay;
			c.EntityTrackingKey = key;
			c.AcceptChanges();
			c.SuppressEntityEvents = false;
			}
			rows.Add(c);
		}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="PTNK.Entities.ThamSo"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="PTNK.Entities.ThamSo"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, PTNK.Entities.ThamSo entity)
		{
			if (!reader.Read()) return;
			
			entity.SoTietToiDaTrongNgay = (System.Byte)reader["SoTietToiDaTrongNgay"];
			entity.OriginalSoTietToiDaTrongNgay = (System.Byte)reader["SoTietToiDaTrongNgay"];
			entity.TietGay = (System.Byte)reader["TietGay"];
			entity.OriginalTietGay = (System.Byte)reader["TietGay"];
			entity.SoTietToiDaDuocHocTrongNgay = (System.Int16)reader["SoTietToiDaDuocHocTrongNgay"];
			entity.OriginalSoTietToiDaDuocHocTrongNgay = (System.Int16)reader["SoTietToiDaDuocHocTrongNgay"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="PTNK.Entities.ThamSo"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="PTNK.Entities.ThamSo"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, PTNK.Entities.ThamSo entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SoTietToiDaTrongNgay = (System.Byte)dataRow["SoTietToiDaTrongNgay"];
			entity.OriginalSoTietToiDaTrongNgay = (System.Byte)dataRow["SoTietToiDaTrongNgay"];
			entity.TietGay = (System.Byte)dataRow["TietGay"];
			entity.OriginalTietGay = (System.Byte)dataRow["TietGay"];
			entity.SoTietToiDaDuocHocTrongNgay = (System.Int16)dataRow["SoTietToiDaDuocHocTrongNgay"];
			entity.OriginalSoTietToiDaDuocHocTrongNgay = (System.Int16)dataRow["SoTietToiDaDuocHocTrongNgay"];
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
		/// <param name="entity">The <see cref="PTNK.Entities.ThamSo"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">PTNK.Entities.ThamSo Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, PTNK.Entities.ThamSo entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the PTNK.Entities.ThamSo object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">PTNK.Entities.ThamSo instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">PTNK.Entities.ThamSo Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, PTNK.Entities.ThamSo entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region ThamSoChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>PTNK.Entities.ThamSo</c>
	///</summary>
	public enum ThamSoChildEntityTypes
	{
	}
	
	#endregion ThamSoChildEntityTypes
	
	#region ThamSoFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ThamSoColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ThamSo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ThamSoFilterBuilder : SqlFilterBuilder<ThamSoColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ThamSoFilterBuilder class.
		/// </summary>
		public ThamSoFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ThamSoFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ThamSoFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ThamSoFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ThamSoFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ThamSoFilterBuilder
	
	#region ThamSoParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ThamSoColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ThamSo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ThamSoParameterBuilder : ParameterizedSqlFilterBuilder<ThamSoColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ThamSoParameterBuilder class.
		/// </summary>
		public ThamSoParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ThamSoParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ThamSoParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ThamSoParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ThamSoParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ThamSoParameterBuilder
} // end namespace
