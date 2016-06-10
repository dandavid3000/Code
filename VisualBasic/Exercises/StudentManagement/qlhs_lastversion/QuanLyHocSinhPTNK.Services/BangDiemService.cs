	

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
	/// An component type implementation of the 'BangDiem' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class BangDiemService : QuanLyHocSinhPTNK.Services.BangDiemServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the BangDiemService class.
		/// </summary>
		public BangDiemService() : base()
		{
		}

        public DataSet LayMaHocSinhDat(string mamon, string maHK)
        {
            return ConnectionScope.Current.DataProvider.BangDiemProvider.LaySoHSCoDiemDat(mamon, maHK);
        }		
	}//End Class


} // end namespace
