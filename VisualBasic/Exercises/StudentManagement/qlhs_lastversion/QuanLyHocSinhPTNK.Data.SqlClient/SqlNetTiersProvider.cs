
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

using QuanLyHocSinhPTNK.Entities;
using QuanLyHocSinhPTNK.Data;
using QuanLyHocSinhPTNK.Data.Bases;

#endregion

namespace QuanLyHocSinhPTNK.Data.SqlClient
{
	/// <summary>
	/// This class is the Sql implementation of the NetTiersProvider.
	/// </summary>
	public sealed class SqlNetTiersProvider : QuanLyHocSinhPTNK.Data.Bases.NetTiersProvider
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
		
		
		#region "PhongBanProvider"
			
		private SqlPhongBanProvider innerSqlPhongBanProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="PhongBan"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override PhongBanProviderBase PhongBanProvider
		{
			get
			{
				if (innerSqlPhongBanProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlPhongBanProvider == null)
						{
							this.innerSqlPhongBanProvider = new SqlPhongBanProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlPhongBanProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlPhongBanProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlPhongBanProvider SqlPhongBanProvider
		{
			get {return PhongBanProvider as SqlPhongBanProvider;}
		}
		
		#endregion
		
		
		#region "HocSinhProvider"
			
		private SqlHocSinhProvider innerSqlHocSinhProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="HocSinh"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override HocSinhProviderBase HocSinhProvider
		{
			get
			{
				if (innerSqlHocSinhProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlHocSinhProvider == null)
						{
							this.innerSqlHocSinhProvider = new SqlHocSinhProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlHocSinhProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlHocSinhProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlHocSinhProvider SqlHocSinhProvider
		{
			get {return HocSinhProvider as SqlHocSinhProvider;}
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
		
		
		#region "QuanLyProvider"
			
		private SqlQuanLyProvider innerSqlQuanLyProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="QuanLy"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override QuanLyProviderBase QuanLyProvider
		{
			get
			{
				if (innerSqlQuanLyProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlQuanLyProvider == null)
						{
							this.innerSqlQuanLyProvider = new SqlQuanLyProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlQuanLyProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlQuanLyProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlQuanLyProvider SqlQuanLyProvider
		{
			get {return QuanLyProvider as SqlQuanLyProvider;}
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
		
		
		#region "BangThamSoProvider"
			
		private SqlBangThamSoProvider innerSqlBangThamSoProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="BangThamSo"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override BangThamSoProviderBase BangThamSoProvider
		{
			get
			{
				if (innerSqlBangThamSoProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlBangThamSoProvider == null)
						{
							this.innerSqlBangThamSoProvider = new SqlBangThamSoProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlBangThamSoProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlBangThamSoProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlBangThamSoProvider SqlBangThamSoProvider
		{
			get {return BangThamSoProvider as SqlBangThamSoProvider;}
		}
		
		#endregion
		
		
		#region "BangDiemProvider"
			
		private SqlBangDiemProvider innerSqlBangDiemProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="BangDiem"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override BangDiemProviderBase BangDiemProvider
		{
			get
			{
				if (innerSqlBangDiemProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlBangDiemProvider == null)
						{
							this.innerSqlBangDiemProvider = new SqlBangDiemProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlBangDiemProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlBangDiemProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlBangDiemProvider SqlBangDiemProvider
		{
			get {return BangDiemProvider as SqlBangDiemProvider;}
		}
		
		#endregion
		
		
		#region "ChucDanhProvider"
			
		private SqlChucDanhProvider innerSqlChucDanhProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ChucDanh"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ChucDanhProviderBase ChucDanhProvider
		{
			get
			{
				if (innerSqlChucDanhProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlChucDanhProvider == null)
						{
							this.innerSqlChucDanhProvider = new SqlChucDanhProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlChucDanhProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlChucDanhProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlChucDanhProvider SqlChucDanhProvider
		{
			get {return ChucDanhProvider as SqlChucDanhProvider;}
		}
		
		#endregion
		
		
		#region "HocKyProvider"
			
		private SqlHocKyProvider innerSqlHocKyProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="HocKy"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override HocKyProviderBase HocKyProvider
		{
			get
			{
				if (innerSqlHocKyProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlHocKyProvider == null)
						{
							this.innerSqlHocKyProvider = new SqlHocKyProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlHocKyProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlHocKyProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlHocKyProvider SqlHocKyProvider
		{
			get {return HocKyProvider as SqlHocKyProvider;}
		}
		
		#endregion
		
		
		#region "DiemProvider"
			
		private SqlDiemProvider innerSqlDiemProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Diem"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DiemProviderBase DiemProvider
		{
			get
			{
				if (innerSqlDiemProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDiemProvider == null)
						{
							this.innerSqlDiemProvider = new SqlDiemProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDiemProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlDiemProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDiemProvider SqlDiemProvider
		{
			get {return DiemProvider as SqlDiemProvider;}
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
