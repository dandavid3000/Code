#region Using directives

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Configuration;
using System.Web;
using QuanLyHocSinhPTNK.Entities;
using QuanLyHocSinhPTNK.Data;
using QuanLyHocSinhPTNK.Data.Bases;

#endregion

namespace QuanLyHocSinhPTNK.Data
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
					_section = WebConfigurationManager.GetSection("QuanLyHocSinhPTNK.Data") as NetTiersServiceSection;
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
		
		#region PhongBanProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="PhongBan"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static PhongBanProviderBase PhongBanProvider
		{
			get 
			{
				LoadProviders();
				return _provider.PhongBanProvider;
			}
		}
		
		#endregion
		
		#region HocSinhProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="HocSinh"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static HocSinhProviderBase HocSinhProvider
		{
			get 
			{
				LoadProviders();
				return _provider.HocSinhProvider;
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
		
		#region QuanLyProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="QuanLy"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static QuanLyProviderBase QuanLyProvider
		{
			get 
			{
				LoadProviders();
				return _provider.QuanLyProvider;
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
		
		#region BangThamSoProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="BangThamSo"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static BangThamSoProviderBase BangThamSoProvider
		{
			get 
			{
				LoadProviders();
				return _provider.BangThamSoProvider;
			}
		}
		
		#endregion
		
		#region BangDiemProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="BangDiem"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static BangDiemProviderBase BangDiemProvider
		{
			get 
			{
				LoadProviders();
				return _provider.BangDiemProvider;
			}
		}
		
		#endregion
		
		#region ChucDanhProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ChucDanh"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ChucDanhProviderBase ChucDanhProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ChucDanhProvider;
			}
		}
		
		#endregion
		
		#region HocKyProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="HocKy"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static HocKyProviderBase HocKyProvider
		{
			get 
			{
				LoadProviders();
				return _provider.HocKyProvider;
			}
		}
		
		#endregion
		
		#region DiemProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Diem"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DiemProviderBase DiemProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DiemProvider;
			}
		}
		
		#endregion
		
		
		#endregion
	}
	
	#region Query/Filters
		
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
		
	#region PhongBanFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PhongBan"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PhongBanFilters : PhongBanFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PhongBanFilters class.
		/// </summary>
		public PhongBanFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the PhongBanFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PhongBanFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PhongBanFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PhongBanFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PhongBanFilters
	
	#region PhongBanQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="PhongBanParameterBuilder"/> class
	/// that is used exclusively with a <see cref="PhongBan"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PhongBanQuery : PhongBanParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PhongBanQuery class.
		/// </summary>
		public PhongBanQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the PhongBanQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PhongBanQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PhongBanQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PhongBanQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PhongBanQuery
		
	#region HocSinhFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="HocSinh"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class HocSinhFilters : HocSinhFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the HocSinhFilters class.
		/// </summary>
		public HocSinhFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the HocSinhFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public HocSinhFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the HocSinhFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public HocSinhFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion HocSinhFilters
	
	#region HocSinhQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="HocSinhParameterBuilder"/> class
	/// that is used exclusively with a <see cref="HocSinh"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class HocSinhQuery : HocSinhParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the HocSinhQuery class.
		/// </summary>
		public HocSinhQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the HocSinhQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public HocSinhQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the HocSinhQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public HocSinhQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion HocSinhQuery
		
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
		
	#region QuanLyFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuanLy"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuanLyFilters : QuanLyFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuanLyFilters class.
		/// </summary>
		public QuanLyFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuanLyFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuanLyFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuanLyFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuanLyFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuanLyFilters
	
	#region QuanLyQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="QuanLyParameterBuilder"/> class
	/// that is used exclusively with a <see cref="QuanLy"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuanLyQuery : QuanLyParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuanLyQuery class.
		/// </summary>
		public QuanLyQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuanLyQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuanLyQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuanLyQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuanLyQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuanLyQuery
		
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
		
	#region BangThamSoFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BangThamSo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BangThamSoFilters : BangThamSoFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BangThamSoFilters class.
		/// </summary>
		public BangThamSoFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the BangThamSoFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BangThamSoFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BangThamSoFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BangThamSoFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BangThamSoFilters
	
	#region BangThamSoQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="BangThamSoParameterBuilder"/> class
	/// that is used exclusively with a <see cref="BangThamSo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BangThamSoQuery : BangThamSoParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BangThamSoQuery class.
		/// </summary>
		public BangThamSoQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the BangThamSoQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BangThamSoQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BangThamSoQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BangThamSoQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BangThamSoQuery
		
	#region BangDiemFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BangDiem"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BangDiemFilters : BangDiemFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BangDiemFilters class.
		/// </summary>
		public BangDiemFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the BangDiemFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BangDiemFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BangDiemFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BangDiemFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BangDiemFilters
	
	#region BangDiemQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="BangDiemParameterBuilder"/> class
	/// that is used exclusively with a <see cref="BangDiem"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BangDiemQuery : BangDiemParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BangDiemQuery class.
		/// </summary>
		public BangDiemQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the BangDiemQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BangDiemQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BangDiemQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BangDiemQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BangDiemQuery
		
	#region ChucDanhFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ChucDanh"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ChucDanhFilters : ChucDanhFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ChucDanhFilters class.
		/// </summary>
		public ChucDanhFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ChucDanhFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ChucDanhFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ChucDanhFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ChucDanhFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ChucDanhFilters
	
	#region ChucDanhQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChucDanhParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ChucDanh"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ChucDanhQuery : ChucDanhParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ChucDanhQuery class.
		/// </summary>
		public ChucDanhQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ChucDanhQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ChucDanhQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ChucDanhQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ChucDanhQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ChucDanhQuery
		
	#region HocKyFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="HocKy"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class HocKyFilters : HocKyFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the HocKyFilters class.
		/// </summary>
		public HocKyFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the HocKyFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public HocKyFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the HocKyFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public HocKyFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion HocKyFilters
	
	#region HocKyQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="HocKyParameterBuilder"/> class
	/// that is used exclusively with a <see cref="HocKy"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class HocKyQuery : HocKyParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the HocKyQuery class.
		/// </summary>
		public HocKyQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the HocKyQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public HocKyQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the HocKyQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public HocKyQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion HocKyQuery
		
	#region DiemFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Diem"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DiemFilters : DiemFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DiemFilters class.
		/// </summary>
		public DiemFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DiemFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DiemFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DiemFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DiemFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DiemFilters
	
	#region DiemQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DiemParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Diem"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DiemQuery : DiemParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DiemQuery class.
		/// </summary>
		public DiemQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DiemQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DiemQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DiemQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DiemQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DiemQuery
	#endregion

	
}
