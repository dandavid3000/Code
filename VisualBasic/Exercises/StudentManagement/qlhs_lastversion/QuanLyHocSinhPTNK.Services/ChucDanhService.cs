	

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
	/// An component type implementation of the 'ChucDanh' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class ChucDanhService : QuanLyHocSinhPTNK.Services.ChucDanhServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the ChucDanhService class.
		/// </summary>
		public ChucDanhService() : base()
		{
		}
		
	}//End Class


} // end namespace
