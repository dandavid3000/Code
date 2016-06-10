	

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
	/// An component type implementation of the 'PhongBan' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class PhongBanService : QuanLyHocSinhPTNK.Services.PhongBanServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the PhongBanService class.
		/// </summary>
		public PhongBanService() : base()
		{
		}
		
	}//End Class


} // end namespace
