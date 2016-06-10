	

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
	/// An component type implementation of the 'Khoi' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class KhoiService : QuanLyHocSinhPTNK.Services.KhoiServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the KhoiService class.
		/// </summary>
		public KhoiService() : base()
		{
		}
		
	}//End Class


} // end namespace
