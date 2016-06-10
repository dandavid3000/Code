	

#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Data;

using QuanLyHocSinhPTNK.Entities;
using QuanLyHocSinhPTNK.Entities.Validation;

using QuanLyHocSinhPTNK.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;

#endregion

namespace QuanLyHocSinhPTNK.Services
{		
	
	///<summary>
	/// An component type implementation of the 'QuanLy' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class QuanLyService : QuanLyHocSinhPTNK.Services.QuanLyServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the QuanLyService class.
		/// </summary>
		public QuanLyService() : base()
		{
		}

        public DataSet LayQuanLyXoa(string machucdanh, string maphongban)
        {
            return ConnectionScope.Current.DataProvider.QuanLyProvider.LayQuanLyXoa(machucdanh, maphongban);
        }	
		
	}//End Class


} // end namespace
