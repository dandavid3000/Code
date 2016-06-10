	

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
	/// An component type implementation of the 'Diem' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class DiemService : QuanLyHocSinhPTNK.Services.DiemServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the DiemService class.
		/// </summary>
		public DiemService() : base()
		{
		}

        public DataSet LayMaBangDiem(string mamon, string maHK)
        {
            return ConnectionScope.Current.DataProvider.DiemProvider.LayMaBangDiem(mamon, maHK);
        }		
	}//End Class


} // end namespace
