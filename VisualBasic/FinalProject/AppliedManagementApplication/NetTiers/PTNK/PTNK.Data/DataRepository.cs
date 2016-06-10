#region Using directives

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Configuration;
using System.Web;
using PTNK.Entities;
using PTNK.Data;
using PTNK.Data.Bases;

#endregion

namespace PTNK.Data
{
	/// <summary>
	/// This class represents the Data source repository and gives access to all the underlying providers.
	/// </summary>
	[CLSCompliant(true)]
	public sealed class DataRepository 
	{
		private static volatile NetTiersProvider _provider = null;
        private static volatile NetTiersProviderCollection _providers = null;
		private static volatile NetTiersServiceSection _section = null;
        
        private static object SyncRoot = new object();
				
		private DataRepository()
		{
		}
		
		#region Public LoadProvider
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        public static void LoadProvider(NetTiersProvider provider)
        {
			LoadProvider(provider, false);
        }
		
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        /// <param name="setAsDefault">ability to set any valid provider as the default provider for the DataRepository.</param>
		public static void LoadProvider(NetTiersProvider provider, bool setAsDefault)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");

            if (_providers == null)
			{
				lock(SyncRoot)
				{
            		if (_providers == null)
						_providers = new NetTiersProviderCollection();
				}
			}
			
            if (_providers[provider.Name] == null)
            {
                lock (_providers.SyncRoot)
                {
                    _providers.Add(provider);
                }
            }

            if (_provider == null || setAsDefault)
            {
                lock (SyncRoot)
                {
                    if(_provider == null || setAsDefault)
                         _provider = provider;
                }
            }
        }
		#endregion 
		
		///<summary>
		/// Configuration based provider loading, will load the providers on first call.
		///</summary>
		private static void LoadProviders()
        {
            // Avoid claiming lock if providers are already loaded
            if (_provider == null)
            {
                lock (SyncRoot)
                {
                    // Do this again to make sure _provider is still null
                    if (_provider == null)
                    {
                        // Load registered providers and point _provider to the default provider
                        _providers = new NetTiersProviderCollection();

                        ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
						_provider = _providers[NetTiersSection.DefaultProvider];

                        if (_provider == null)
                        {
                            throw new ProviderException("Unable to load default NetTiersProvider");
                        }
                    }
                }
            }
        }

		/// <summary>
        /// Gets the provider.
        /// </summary>
        /// <value>The provider.</value>
        public static NetTiersProvider Provider
        {
            get { LoadProviders(); return _provider; }
        }

		/// <summary>
        /// Gets the provider collection.
        /// </summary>
        /// <value>The providers.</value>
        public static NetTiersProviderCollection Providers
        {
            get { LoadProviders(); return _providers; }
        }
		
		/// <summary>
		/// Creates a new <c cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public TransactionManager CreateTransaction()
		{
			return _provider.CreateTransaction();
		}

		#region Configuration

		/// <summary>
		/// Gets a reference to the configured NetTiersServiceSection object.
		/// </summary>
		public static NetTiersServiceSection NetTiersSection
		{
			get
			{
				// Try to get a reference to the default <netTiersService> section
				_section = WebConfigurationManager.GetSection("netTiersService") as NetTiersServiceSection;

				if ( _section == null )
				{
					// otherwise look for section based on the assembly name
					_section = WebConfigurationManager.GetSection("PTNK.Data") as NetTiersServiceSection;
				}

				if ( _section == null )
				{
					throw new ProviderException("Unable to load NetTiersServiceSection");
				}

				return _section;
			}
		}

		#endregion Configuration

		#region Connections

		/// <summary>
		/// Gets a reference to the ConnectionStringSettings collection.
		/// </summary>
		public static ConnectionStringSettingsCollection ConnectionStrings
		{
			get
			{
				return WebConfigurationManager.ConnectionStrings;
			}
		}

		// dictionary of connection providers
		private static Dictionary<String, ConnectionProvider> _connections;

		/// <summary>
		/// Gets the dictionary of connection providers.
		/// </summary>
		public static Dictionary<String, ConnectionProvider> Connections
		{
			get
			{
				if ( _connections == null )
				{
					lock (SyncRoot)
                	{
						if (_connections == null)
						{
							_connections = new Dictionary<String, ConnectionProvider>();
		
							// add a connection provider for each configured connection string
							foreach ( ConnectionStringSettings conn in ConnectionStrings )
							{
								_connections.Add(conn.Name, new ConnectionProvider(conn.Name));
							}
						}
					}
				}

				return _connections;
			}
		}

		/// <summary>
		/// Adds the specified connection string to the map of connection strings.
		/// </summary>
		/// <param name="connectionStringName">The connection string name.</param>
		/// <param name="connectionString">The provider specific connection information.</param>
		public static void AddConnection(String connectionStringName, String connectionString)
		{
			lock (SyncRoot)
            {
				Connections.Remove(connectionStringName);
				ConnectionProvider connection = new ConnectionProvider(connectionStringName, connectionString);
				Connections.Add(connectionStringName, connection);
			}
		}

		/// <summary>
		/// Provides ability to switch connection string at runtime.
		/// </summary>
		public sealed class ConnectionProvider
		{
			private NetTiersProvider _provider;
			private NetTiersProviderCollection _providers;
			private String _connectionStringName;
			private String _connectionString;

			/// <summary>
			/// Initializes a new instance of the ConnectionProvider class.
			/// </summary>
			/// <param name="connectionStringName">The connection string name.</param>
			public ConnectionProvider(String connectionStringName)
			{
				_connectionStringName = connectionStringName;
			}

			/// <summary>
			/// Initializes a new instance of the ConnectionProvider class.
			/// </summary>
			/// <param name="connectionStringName">The connection string name.</param>
			/// <param name="connectionString">The provider specific connection information.</param>
			public ConnectionProvider(String connectionStringName, String connectionString)
			{
				_connectionString = connectionString;
				_connectionStringName = connectionStringName;
			}

			/// <summary>
			/// Gets the provider.
			/// </summary>
			public NetTiersProvider Provider
			{
				get { LoadProviders(); return _provider; }
			}

			/// <summary>
			/// Gets the provider collection.
			/// </summary>
			public NetTiersProviderCollection Providers
			{
				get { LoadProviders(); return _providers; }
			}

			/// <summary>
			/// Instantiates the configured providers based on the supplied connection string.
			/// </summary>
			private void LoadProviders()
			{
				DataRepository.LoadProviders();

				// Avoid claiming lock if providers are already loaded
				if ( _providers == null )
				{
					lock ( SyncRoot )
					{
						// Do this again to make sure _provider is still null
						if ( _providers == null )
						{
							// apply connection information to each provider
							for ( int i = 0; i < NetTiersSection.Providers.Count; i++ )
							{
								NetTiersSection.Providers[i].Parameters["connectionStringName"] = _connectionStringName;
								// remove previous connection string, if any
								NetTiersSection.Providers[i].Parameters.Remove("connectionString");

								if ( !String.IsNullOrEmpty(_connectionString) )
								{
									NetTiersSection.Providers[i].Parameters["connectionString"] = _connectionString;
								}
							}

							// Load registered providers and point _provider to the default provider
							_providers = new NetTiersProviderCollection();

							ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
							_provider = _providers[NetTiersSection.DefaultProvider];
						}
					}
				}
			}
		}

		#endregion Connections

		#region Static properties
		
		#region RangBuocLopHocProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="RangBuocLopHoc"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static RangBuocLopHocProviderBase RangBuocLopHocProvider
		{
			get 
			{
				LoadProviders();
				return _provider.RangBuocLopHocProvider;
			}
		}
		
		#endregion
		
		#region MonHocProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="MonHoc"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static MonHocProviderBase MonHocProvider
		{
			get 
			{
				LoadProviders();
				return _provider.MonHocProvider;
			}
		}
		
		#endregion
		
		#region ThoiKhoaBieuProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ThoiKhoaBieu"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ThoiKhoaBieuProviderBase ThoiKhoaBieuProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ThoiKhoaBieuProvider;
			}
		}
		
		#endregion
		
		#region ThamSoProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ThamSo"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ThamSoProviderBase ThamSoProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ThamSoProvider;
			}
		}
		
		#endregion
		
		#region KhoiProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Khoi"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static KhoiProviderBase KhoiProvider
		{
			get 
			{
				LoadProviders();
				return _provider.KhoiProvider;
			}
		}
		
		#endregion
		
		#region GiaoVienProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="GiaoVien"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static GiaoVienProviderBase GiaoVienProvider
		{
			get 
			{
				LoadProviders();
				return _provider.GiaoVienProvider;
			}
		}
		
		#endregion
		
		#region RangBuocGiaoVienProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="RangBuocGiaoVien"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static RangBuocGiaoVienProviderBase RangBuocGiaoVienProvider
		{
			get 
			{
				LoadProviders();
				return _provider.RangBuocGiaoVienProvider;
			}
		}
		
		#endregion
		
		#region LopHocProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="LopHoc"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static LopHocProviderBase LopHocProvider
		{
			get 
			{
				LoadProviders();
				return _provider.LopHocProvider;
			}
		}
		
		#endregion
		
		#region PhanCongProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="PhanCong"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static PhanCongProviderBase PhanCongProvider
		{
			get 
			{
				LoadProviders();
				return _provider.PhanCongProvider;
			}
		}
		
		#endregion
		
		#region PhuTrachProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="PhuTrach"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static PhuTrachProviderBase PhuTrachProvider
		{
			get 
			{
				LoadProviders();
				return _provider.PhuTrachProvider;
			}
		}
		
		#endregion
		
		#region LichLopHocProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="LichLopHoc"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static LichLopHocProviderBase LichLopHocProvider
		{
			get 
			{
				LoadProviders();
				return _provider.LichLopHocProvider;
			}
		}
		
		#endregion
		
		
		#endregion
	}
	
	#region Query/Filters
		
	#region RangBuocLopHocFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="RangBuocLopHoc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RangBuocLopHocFilters : RangBuocLopHocFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RangBuocLopHocFilters class.
		/// </summary>
		public RangBuocLopHocFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the RangBuocLopHocFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RangBuocLopHocFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RangBuocLopHocFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RangBuocLopHocFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RangBuocLopHocFilters
	
	#region RangBuocLopHocQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="RangBuocLopHocParameterBuilder"/> class
	/// that is used exclusively with a <see cref="RangBuocLopHoc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RangBuocLopHocQuery : RangBuocLopHocParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RangBuocLopHocQuery class.
		/// </summary>
		public RangBuocLopHocQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the RangBuocLopHocQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RangBuocLopHocQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RangBuocLopHocQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RangBuocLopHocQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RangBuocLopHocQuery
		
	#region MonHocFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MonHoc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MonHocFilters : MonHocFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MonHocFilters class.
		/// </summary>
		public MonHocFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the MonHocFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MonHocFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MonHocFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MonHocFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MonHocFilters
	
	#region MonHocQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="MonHocParameterBuilder"/> class
	/// that is used exclusively with a <see cref="MonHoc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MonHocQuery : MonHocParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MonHocQuery class.
		/// </summary>
		public MonHocQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the MonHocQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MonHocQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MonHocQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MonHocQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MonHocQuery
		
	#region ThoiKhoaBieuFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ThoiKhoaBieu"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ThoiKhoaBieuFilters : ThoiKhoaBieuFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ThoiKhoaBieuFilters class.
		/// </summary>
		public ThoiKhoaBieuFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ThoiKhoaBieuFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ThoiKhoaBieuFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ThoiKhoaBieuFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ThoiKhoaBieuFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ThoiKhoaBieuFilters
	
	#region ThoiKhoaBieuQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ThoiKhoaBieuParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ThoiKhoaBieu"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ThoiKhoaBieuQuery : ThoiKhoaBieuParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ThoiKhoaBieuQuery class.
		/// </summary>
		public ThoiKhoaBieuQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ThoiKhoaBieuQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ThoiKhoaBieuQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ThoiKhoaBieuQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ThoiKhoaBieuQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ThoiKhoaBieuQuery
		
	#region ThamSoFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ThamSo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ThamSoFilters : ThamSoFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ThamSoFilters class.
		/// </summary>
		public ThamSoFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ThamSoFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ThamSoFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ThamSoFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ThamSoFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ThamSoFilters
	
	#region ThamSoQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ThamSoParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ThamSo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ThamSoQuery : ThamSoParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ThamSoQuery class.
		/// </summary>
		public ThamSoQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ThamSoQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ThamSoQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ThamSoQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ThamSoQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ThamSoQuery
		
	#region KhoiFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Khoi"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KhoiFilters : KhoiFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KhoiFilters class.
		/// </summary>
		public KhoiFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the KhoiFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public KhoiFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the KhoiFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public KhoiFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion KhoiFilters
	
	#region KhoiQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="KhoiParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Khoi"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KhoiQuery : KhoiParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KhoiQuery class.
		/// </summary>
		public KhoiQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the KhoiQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public KhoiQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the KhoiQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public KhoiQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion KhoiQuery
		
	#region GiaoVienFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="GiaoVien"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GiaoVienFilters : GiaoVienFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GiaoVienFilters class.
		/// </summary>
		public GiaoVienFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the GiaoVienFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public GiaoVienFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the GiaoVienFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public GiaoVienFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion GiaoVienFilters
	
	#region GiaoVienQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="GiaoVienParameterBuilder"/> class
	/// that is used exclusively with a <see cref="GiaoVien"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GiaoVienQuery : GiaoVienParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GiaoVienQuery class.
		/// </summary>
		public GiaoVienQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the GiaoVienQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public GiaoVienQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the GiaoVienQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public GiaoVienQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion GiaoVienQuery
		
	#region RangBuocGiaoVienFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="RangBuocGiaoVien"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RangBuocGiaoVienFilters : RangBuocGiaoVienFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RangBuocGiaoVienFilters class.
		/// </summary>
		public RangBuocGiaoVienFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the RangBuocGiaoVienFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RangBuocGiaoVienFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RangBuocGiaoVienFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RangBuocGiaoVienFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RangBuocGiaoVienFilters
	
	#region RangBuocGiaoVienQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="RangBuocGiaoVienParameterBuilder"/> class
	/// that is used exclusively with a <see cref="RangBuocGiaoVien"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RangBuocGiaoVienQuery : RangBuocGiaoVienParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RangBuocGiaoVienQuery class.
		/// </summary>
		public RangBuocGiaoVienQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the RangBuocGiaoVienQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RangBuocGiaoVienQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RangBuocGiaoVienQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RangBuocGiaoVienQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RangBuocGiaoVienQuery
		
	#region LopHocFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LopHoc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LopHocFilters : LopHocFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LopHocFilters class.
		/// </summary>
		public LopHocFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the LopHocFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LopHocFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LopHocFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LopHocFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LopHocFilters
	
	#region LopHocQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="LopHocParameterBuilder"/> class
	/// that is used exclusively with a <see cref="LopHoc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LopHocQuery : LopHocParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LopHocQuery class.
		/// </summary>
		public LopHocQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the LopHocQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LopHocQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LopHocQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LopHocQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LopHocQuery
		
	#region PhanCongFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PhanCong"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PhanCongFilters : PhanCongFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PhanCongFilters class.
		/// </summary>
		public PhanCongFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the PhanCongFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PhanCongFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PhanCongFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PhanCongFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PhanCongFilters
	
	#region PhanCongQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="PhanCongParameterBuilder"/> class
	/// that is used exclusively with a <see cref="PhanCong"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PhanCongQuery : PhanCongParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PhanCongQuery class.
		/// </summary>
		public PhanCongQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the PhanCongQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PhanCongQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PhanCongQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PhanCongQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PhanCongQuery
		
	#region PhuTrachFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PhuTrach"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PhuTrachFilters : PhuTrachFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PhuTrachFilters class.
		/// </summary>
		public PhuTrachFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the PhuTrachFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PhuTrachFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PhuTrachFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PhuTrachFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PhuTrachFilters
	
	#region PhuTrachQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="PhuTrachParameterBuilder"/> class
	/// that is used exclusively with a <see cref="PhuTrach"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PhuTrachQuery : PhuTrachParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PhuTrachQuery class.
		/// </summary>
		public PhuTrachQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the PhuTrachQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PhuTrachQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PhuTrachQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PhuTrachQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PhuTrachQuery
		
	#region LichLopHocFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LichLopHoc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LichLopHocFilters : LichLopHocFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LichLopHocFilters class.
		/// </summary>
		public LichLopHocFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the LichLopHocFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LichLopHocFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LichLopHocFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LichLopHocFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LichLopHocFilters
	
	#region LichLopHocQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="LichLopHocParameterBuilder"/> class
	/// that is used exclusively with a <see cref="LichLopHoc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LichLopHocQuery : LichLopHocParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LichLopHocQuery class.
		/// </summary>
		public LichLopHocQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the LichLopHocQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LichLopHocQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LichLopHocQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LichLopHocQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LichLopHocQuery
	#endregion

	
}
