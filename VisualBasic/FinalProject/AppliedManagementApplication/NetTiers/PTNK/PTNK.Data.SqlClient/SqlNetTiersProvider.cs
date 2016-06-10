
#region Using directives

using System;
using System.Collections;
using System.Collections.Specialized;


using System.Web.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using PTNK.Entities;
using PTNK.Data;
using PTNK.Data.Bases;

#endregion

namespace PTNK.Data.SqlClient
{
	/// <summary>
	/// This class is the Sql implementation of the NetTiersProvider.
	/// </summary>
	public sealed class SqlNetTiersProvider : PTNK.Data.Bases.NetTiersProvider
	{
		private static object syncRoot = new Object();
		private string _applicationName;
        private string _connectionString;
        private bool _useStoredProcedure;
        string _providerInvariantName;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="SqlNetTiersProvider"/> class.
		///</summary>
		public SqlNetTiersProvider()
		{	
		}		
		
		/// <summary>
        /// Initializes the provider.
        /// </summary>
        /// <param name="name">The friendly name of the provider.</param>
        /// <param name="config">A collection of the name/value pairs representing the provider-specific attributes specified in the configuration for this provider.</param>
        /// <exception cref="T:System.ArgumentNullException">The name of the provider is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">An attempt is made to call <see cref="M:System.Configuration.Provider.ProviderBase.Initialize(System.String,System.Collections.Specialized.NameValueCollection)"></see> on a provider after the provider has already been initialized.</exception>
        /// <exception cref="T:System.ArgumentException">The name of the provider has a length of zero.</exception>
		public override void Initialize(string name, NameValueCollection config)
        {
            // Verify that config isn't null
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            // Assign the provider a default name if it doesn't have one
            if (String.IsNullOrEmpty(name))
            {
                name = "SqlNetTiersProvider";
            }

            // Add a default "description" attribute to config if the
            // attribute doesn't exist or is empty
            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "NetTiers Sql provider");
            }

            // Call the base class's Initialize method
            base.Initialize(name, config);

            // Initialize _applicationName
            _applicationName = config["applicationName"];

            if (string.IsNullOrEmpty(_applicationName))
            {
                _applicationName = "/";
            }
            config.Remove("applicationName");


            #region "Initialize UseStoredProcedure"
            string storedProcedure  = config["useStoredProcedure"];
           	if (string.IsNullOrEmpty(storedProcedure))
            {
                throw new ProviderException("Empty or missing useStoredProcedure");
            }
            this._useStoredProcedure = Convert.ToBoolean(config["useStoredProcedure"]);
            config.Remove("useStoredProcedure");
            #endregion

			#region ConnectionString

			// Initialize _connectionString
			_connectionString = config["connectionString"];
			config.Remove("connectionString");

			string connect = config["connectionStringName"];
			config.Remove("connectionStringName");

			if ( String.IsNullOrEmpty(_connectionString) )
			{
				if ( String.IsNullOrEmpty(connect) )
				{
					throw new ProviderException("Empty or missing connectionStringName");
				}

				if ( DataRepository.ConnectionStrings[connect] == null )
				{
					throw new ProviderException("Missing connection string");
				}

				_connectionString = DataRepository.ConnectionStrings[connect].ConnectionString;
			}

            if ( String.IsNullOrEmpty(_connectionString) )
            {
                throw new ProviderException("Empty connection string");
			}

			#endregion
            
             #region "_providerInvariantName"

            // initialize _providerInvariantName
            this._providerInvariantName = config["providerInvariantName"];

            if (String.IsNullOrEmpty(_providerInvariantName))
            {
                throw new ProviderException("Empty or missing providerInvariantName");
            }
            config.Remove("providerInvariantName");

            #endregion

        }
		
		/// <summary>
		/// Creates a new <c cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public override TransactionManager CreateTransaction()
		{
			return new TransactionManager(this._connectionString);
		}
		
		/// <summary>
		/// Gets a value indicating whether to use stored procedure or not.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this repository use stored procedures; otherwise, <c>false</c>.
		/// </value>
		public bool UseStoredProcedure
		{
			get {return this._useStoredProcedure;}
			set {this._useStoredProcedure = value;}
		}
		
		 /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
		public string ConnectionString
		{
			get {return this._connectionString;}
			set {this._connectionString = value;}
		}
		
		/// <summary>
	    /// Gets or sets the invariant provider name listed in the DbProviderFactories machine.config section.
	    /// </summary>
	    /// <value>The name of the provider invariant.</value>
	    public string ProviderInvariantName
	    {
	        get { return this._providerInvariantName; }
	        set { this._providerInvariantName = value; }
	    }		
		
		///<summary>
		/// Indicates if the current <c cref="NetTiersProvider"/> implementation supports Transacton.
		///</summary>
		public override bool IsTransactionSupported
		{
			get
			{
				return true;
			}
		}

		
		#region "RangBuocLopHocProvider"
			
		private SqlRangBuocLopHocProvider innerSqlRangBuocLopHocProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="RangBuocLopHoc"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override RangBuocLopHocProviderBase RangBuocLopHocProvider
		{
			get
			{
				if (innerSqlRangBuocLopHocProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlRangBuocLopHocProvider == null)
						{
							this.innerSqlRangBuocLopHocProvider = new SqlRangBuocLopHocProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlRangBuocLopHocProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlRangBuocLopHocProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlRangBuocLopHocProvider SqlRangBuocLopHocProvider
		{
			get {return RangBuocLopHocProvider as SqlRangBuocLopHocProvider;}
		}
		
		#endregion
		
		
		#region "MonHocProvider"
			
		private SqlMonHocProvider innerSqlMonHocProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="MonHoc"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override MonHocProviderBase MonHocProvider
		{
			get
			{
				if (innerSqlMonHocProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlMonHocProvider == null)
						{
							this.innerSqlMonHocProvider = new SqlMonHocProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlMonHocProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlMonHocProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlMonHocProvider SqlMonHocProvider
		{
			get {return MonHocProvider as SqlMonHocProvider;}
		}
		
		#endregion
		
		
		#region "ThoiKhoaBieuProvider"
			
		private SqlThoiKhoaBieuProvider innerSqlThoiKhoaBieuProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ThoiKhoaBieu"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ThoiKhoaBieuProviderBase ThoiKhoaBieuProvider
		{
			get
			{
				if (innerSqlThoiKhoaBieuProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlThoiKhoaBieuProvider == null)
						{
							this.innerSqlThoiKhoaBieuProvider = new SqlThoiKhoaBieuProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlThoiKhoaBieuProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlThoiKhoaBieuProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlThoiKhoaBieuProvider SqlThoiKhoaBieuProvider
		{
			get {return ThoiKhoaBieuProvider as SqlThoiKhoaBieuProvider;}
		}
		
		#endregion
		
		
		#region "ThamSoProvider"
			
		private SqlThamSoProvider innerSqlThamSoProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ThamSo"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ThamSoProviderBase ThamSoProvider
		{
			get
			{
				if (innerSqlThamSoProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlThamSoProvider == null)
						{
							this.innerSqlThamSoProvider = new SqlThamSoProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlThamSoProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlThamSoProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlThamSoProvider SqlThamSoProvider
		{
			get {return ThamSoProvider as SqlThamSoProvider;}
		}
		
		#endregion
		
		
		#region "KhoiProvider"
			
		private SqlKhoiProvider innerSqlKhoiProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Khoi"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override KhoiProviderBase KhoiProvider
		{
			get
			{
				if (innerSqlKhoiProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlKhoiProvider == null)
						{
							this.innerSqlKhoiProvider = new SqlKhoiProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlKhoiProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlKhoiProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlKhoiProvider SqlKhoiProvider
		{
			get {return KhoiProvider as SqlKhoiProvider;}
		}
		
		#endregion
		
		
		#region "GiaoVienProvider"
			
		private SqlGiaoVienProvider innerSqlGiaoVienProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="GiaoVien"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override GiaoVienProviderBase GiaoVienProvider
		{
			get
			{
				if (innerSqlGiaoVienProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlGiaoVienProvider == null)
						{
							this.innerSqlGiaoVienProvider = new SqlGiaoVienProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlGiaoVienProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlGiaoVienProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlGiaoVienProvider SqlGiaoVienProvider
		{
			get {return GiaoVienProvider as SqlGiaoVienProvider;}
		}
		
		#endregion
		
		
		#region "RangBuocGiaoVienProvider"
			
		private SqlRangBuocGiaoVienProvider innerSqlRangBuocGiaoVienProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="RangBuocGiaoVien"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override RangBuocGiaoVienProviderBase RangBuocGiaoVienProvider
		{
			get
			{
				if (innerSqlRangBuocGiaoVienProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlRangBuocGiaoVienProvider == null)
						{
							this.innerSqlRangBuocGiaoVienProvider = new SqlRangBuocGiaoVienProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlRangBuocGiaoVienProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlRangBuocGiaoVienProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlRangBuocGiaoVienProvider SqlRangBuocGiaoVienProvider
		{
			get {return RangBuocGiaoVienProvider as SqlRangBuocGiaoVienProvider;}
		}
		
		#endregion
		
		
		#region "LopHocProvider"
			
		private SqlLopHocProvider innerSqlLopHocProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="LopHoc"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override LopHocProviderBase LopHocProvider
		{
			get
			{
				if (innerSqlLopHocProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlLopHocProvider == null)
						{
							this.innerSqlLopHocProvider = new SqlLopHocProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlLopHocProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlLopHocProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlLopHocProvider SqlLopHocProvider
		{
			get {return LopHocProvider as SqlLopHocProvider;}
		}
		
		#endregion
		
		
		#region "PhanCongProvider"
			
		private SqlPhanCongProvider innerSqlPhanCongProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="PhanCong"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override PhanCongProviderBase PhanCongProvider
		{
			get
			{
				if (innerSqlPhanCongProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlPhanCongProvider == null)
						{
							this.innerSqlPhanCongProvider = new SqlPhanCongProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlPhanCongProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlPhanCongProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlPhanCongProvider SqlPhanCongProvider
		{
			get {return PhanCongProvider as SqlPhanCongProvider;}
		}
		
		#endregion
		
		
		#region "PhuTrachProvider"
			
		private SqlPhuTrachProvider innerSqlPhuTrachProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="PhuTrach"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override PhuTrachProviderBase PhuTrachProvider
		{
			get
			{
				if (innerSqlPhuTrachProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlPhuTrachProvider == null)
						{
							this.innerSqlPhuTrachProvider = new SqlPhuTrachProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlPhuTrachProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlPhuTrachProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlPhuTrachProvider SqlPhuTrachProvider
		{
			get {return PhuTrachProvider as SqlPhuTrachProvider;}
		}
		
		#endregion
		
		
		#region "LichLopHocProvider"
			
		private SqlLichLopHocProvider innerSqlLichLopHocProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="LichLopHoc"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override LichLopHocProviderBase LichLopHocProvider
		{
			get
			{
				if (innerSqlLichLopHocProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlLichLopHocProvider == null)
						{
							this.innerSqlLichLopHocProvider = new SqlLichLopHocProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlLichLopHocProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlLichLopHocProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlLichLopHocProvider SqlLichLopHocProvider
		{
			get {return LichLopHocProvider as SqlLichLopHocProvider;}
		}
		
		#endregion
		
		
		
		#region "General data access methods"

		#region "ExecuteNonQuery"
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			database.ExecuteNonQuery(commandWrapper);	
			
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			database.ExecuteNonQuery(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(commandType, commandText);	
		}
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteNonQuery(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteDataReader"
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteReader(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteReader(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteReader(commandWrapper);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteReader(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteReader(commandType, commandText);	
		}
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteReader(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteDataSet"
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteDataSet(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteDataSet(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteDataSet(commandWrapper);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteDataSet(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteDataSet(commandType, commandText);	
		}
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteDataSet(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteScalar"
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override object ExecuteScalar(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteScalar(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteScalar(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteScalar(commandWrapper);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteScalar(commandWrapper, transactionManager.TransactionObject);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteScalar(commandType, commandText);	
		}
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteScalar(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#endregion


	}
}
