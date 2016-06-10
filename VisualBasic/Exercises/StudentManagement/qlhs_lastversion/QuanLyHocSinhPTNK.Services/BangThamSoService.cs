	

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
	/// An component type implementation of the 'BangThamSo' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class BangThamSoService : QuanLyHocSinhPTNK.Services.BangThamSoServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the BangThamSoService class.
		/// </summary>
		public BangThamSoService() : base()
		{
		}

        public void CapNhat(BangThamSo bts)
        {
            ConnectionScope.Current.DataProvider.BangThamSoProvider.CapNhat(bts);
        }
		
	}//End Class


} // end namespace
