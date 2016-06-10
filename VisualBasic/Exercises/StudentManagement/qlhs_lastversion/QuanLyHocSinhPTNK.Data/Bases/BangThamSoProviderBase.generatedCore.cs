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
	/// This class is the base class for any <see cref="BangThamSoProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class BangThamSoProviderBaseCore : EntityProviderBase<QuanLyHocSinhPTNK.Entities.BangThamSo, QuanLyHocSinhPTNK.Entities.BangThamSoKey>
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
		public override bool Delete(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.BangThamSoKey key)
		{
			return Delete(transactionManager, key.MaBangThamSo);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="maBangThamSo">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String maBangThamSo)
		{
			return Delete(null, maBangThamSo);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maBangThamSo">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String maBangThamSo);		
		
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
		public override QuanLyHocSinhPTNK.Entities.BangThamSo Get(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.BangThamSoKey key, int start, int pageLength)
		{
			return GetByMaBangThamSo(transactionManager, key.MaBangThamSo, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_BangThamSo index.
		/// </summary>
		/// <param name="maBangThamSo"></param>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.BangThamSo"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.BangThamSo GetByMaBangThamSo(System.String maBangThamSo)
		{
			int count = -1;
			return GetByMaBangThamSo(null,maBangThamSo, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_BangThamSo index.
		/// </summary>
		/// <param name="maBangThamSo"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.BangThamSo"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.BangThamSo GetByMaBangThamSo(System.String maBangThamSo, int start, int pageLength)
		{
			int count = -1;
			return GetByMaBangThamSo(null, maBangThamSo, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_BangThamSo index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maBangThamSo"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.BangThamSo"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.BangThamSo GetByMaBangThamSo(TransactionManager transactionManager, System.String maBangThamSo)
		{
			int count = -1;
			return GetByMaBangThamSo(transactionManager, maBangThamSo, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_BangThamSo index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maBangThamSo"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.BangThamSo"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.BangThamSo GetByMaBangThamSo(TransactionManager transactionManager, System.String maBangThamSo, int start, int pageLength)
		{
			int count = -1;
			return GetByMaBangThamSo(transactionManager, maBangThamSo, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_BangThamSo index.
		/// </summary>
		/// <param name="maBangThamSo"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.BangThamSo"/> class.</returns>
		public QuanLyHocSinhPTNK.Entities.BangThamSo GetByMaBangThamSo(System.String maBangThamSo, int start, int pageLength, out int count)
		{
			return GetByMaBangThamSo(null, maBangThamSo, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_BangThamSo index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="maBangThamSo"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="QuanLyHocSinhPTNK.Entities.BangThamSo"/> class.</returns>
		public abstract QuanLyHocSinhPTNK.Entities.BangThamSo GetByMaBangThamSo(TransactionManager transactionManager, System.String maBangThamSo, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a QuanLyHocSinhPTNK.Entities.TList&lt;BangThamSo&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="QuanLyHocSinhPTNK.Entities.TList&lt;BangThamSo&gt;"/></returns>
		public static QuanLyHocSinhPTNK.Entities.TList<BangThamSo> Fill(IDataReader reader, QuanLyHocSinhPTNK.Entities.TList<BangThamSo> rows, int start, int pageLength)
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
			
			QuanLyHocSinhPTNK.Entities.BangThamSo c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("BangThamSo")
			.Append("|").Append((reader.IsDBNull(((int)QuanLyHocSinhPTNK.Entities.BangThamSoColumn.MaBangThamSo - 1))?string.Empty:(System.String)reader[((int)QuanLyHocSinhPTNK.Entities.BangThamSoColumn.MaBangThamSo - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<BangThamSo>(
			key.ToString(), // EntityTrackingKey
			"BangThamSo",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new QuanLyHocSinhPTNK.Entities.BangThamSo();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.MaBangThamSo = (System.String)reader["MaBangThamSo"];
			c.OriginalMaBangThamSo = c.MaBangThamSo;
			c.SoTuoiToiThieu = (System.Int32)reader["SoTuoiToiThieu"];
			c.SoTuoiToiDa = (System.Int32)reader["SoTuoiToiDa"];
			c.SiSoToiDa = (System.Int32)reader["SiSoToiDa"];
			c.SoMonHoc = (System.Int32)reader["SoMonHoc"];
			c.DiemChuan = (System.Double)reader["DiemChuan"];
			c.SoQuanLyToiDa = (System.Int32)reader["SoQuanLyToiDa"];
			c.SoTietHocLienTiep = (System.Int32)reader["SoTietHocLienTiep"];
			c.EntityTrackingKey = key;
			c.AcceptChanges();
			c.SuppressEntityEvents = false;
			}
			rows.Add(c);
		}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="QuanLyHocSinhPTNK.Entities.BangThamSo"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="QuanLyHocSinhPTNK.Entities.BangThamSo"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, QuanLyHocSinhPTNK.Entities.BangThamSo entity)
		{
			if (!reader.Read()) return;
			
			entity.MaBangThamSo = (System.String)reader["MaBangThamSo"];
			entity.OriginalMaBangThamSo = (System.String)reader["MaBangThamSo"];
			entity.SoTuoiToiThieu = (System.Int32)reader["SoTuoiToiThieu"];
			entity.SoTuoiToiDa = (System.Int32)reader["SoTuoiToiDa"];
			entity.SiSoToiDa = (System.Int32)reader["SiSoToiDa"];
			entity.SoMonHoc = (System.Int32)reader["SoMonHoc"];
			entity.DiemChuan = (System.Double)reader["DiemChuan"];
			entity.SoQuanLyToiDa = (System.Int32)reader["SoQuanLyToiDa"];
			entity.SoTietHocLienTiep = (System.Int32)reader["SoTietHocLienTiep"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="QuanLyHocSinhPTNK.Entities.BangThamSo"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="QuanLyHocSinhPTNK.Entities.BangThamSo"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, QuanLyHocSinhPTNK.Entities.BangThamSo entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.MaBangThamSo = (System.String)dataRow["MaBangThamSo"];
			entity.OriginalMaBangThamSo = (System.String)dataRow["MaBangThamSo"];
			entity.SoTuoiToiThieu = (System.Int32)dataRow["SoTuoiToiThieu"];
			entity.SoTuoiToiDa = (System.Int32)dataRow["SoTuoiToiDa"];
			entity.SiSoToiDa = (System.Int32)dataRow["SiSoToiDa"];
			entity.SoMonHoc = (System.Int32)dataRow["SoMonHoc"];
			entity.DiemChuan = (System.Double)dataRow["DiemChuan"];
			entity.SoQuanLyToiDa = (System.Int32)dataRow["SoQuanLyToiDa"];
			entity.SoTietHocLienTiep = (System.Int32)dataRow["SoTietHocLienTiep"];
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
		/// <param name="entity">The <see cref="QuanLyHocSinhPTNK.Entities.BangThamSo"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">QuanLyHocSinhPTNK.Entities.BangThamSo Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.BangThamSo entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the QuanLyHocSinhPTNK.Entities.BangThamSo object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">QuanLyHocSinhPTNK.Entities.BangThamSo instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">QuanLyHocSinhPTNK.Entities.BangThamSo Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, QuanLyHocSinhPTNK.Entities.BangThamSo entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region BangThamSoChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>QuanLyHocSinhPTNK.Entities.BangThamSo</c>
	///</summary>
	public enum BangThamSoChildEntityTypes
	{
	}
	
	#endregion BangThamSoChildEntityTypes
	
	#region BangThamSoFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;BangThamSoColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BangThamSo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BangThamSoFilterBuilder : SqlFilterBuilder<BangThamSoColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BangThamSoFilterBuilder class.
		/// </summary>
		public BangThamSoFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the BangThamSoFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BangThamSoFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BangThamSoFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BangThamSoFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BangThamSoFilterBuilder
	
	#region BangThamSoParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;BangThamSoColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BangThamSo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BangThamSoParameterBuilder : ParameterizedSqlFilterBuilder<BangThamSoColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BangThamSoParameterBuilder class.
		/// </summary>
		public BangThamSoParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the BangThamSoParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BangThamSoParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BangThamSoParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BangThamSoParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BangThamSoParameterBuilder
} // end namespace
