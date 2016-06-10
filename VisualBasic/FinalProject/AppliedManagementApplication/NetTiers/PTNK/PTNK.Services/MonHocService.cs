	

#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Data;

using PTNK.Entities;
using PTNK.Entities.Validation;

using PTNK.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;

#endregion

namespace PTNK.Services
{		
	
	///<summary>
	/// An component type implementation of the 'MonHoc' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class MonHocService : PTNK.Services.MonHocServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the MonHocService class.
		/// </summary>
		public MonHocService() : base()
		{
		}
		
	}//End Class


} // end namespace
