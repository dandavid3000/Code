	

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
	/// An component type implementation of the 'LopHoc' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class LopHocService : QuanLyHocSinhPTNK.Services.LopHocServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the LopHocService class.
		/// </summary>
		public LopHocService() : base()
		{
		}

        public DataSet LayDSLopHoc(string maHK)
        {
            return ConnectionScope.Current.DataProvider.LopHocProvider.LayDSLopHoc(maHK);
        }

        public DataSet LayDSLopHoc(string mamon, string maHK)
        {
            return ConnectionScope.Current.DataProvider.LopHocProvider.LayDSLopHoc(mamon, maHK);
        }

        public DataSet LaySoLuongHSTrongLop(string tenlop)
        {
            return ConnectionScope.Current.DataProvider.LopHocProvider.LaySoLuongHS(tenlop);
        }
	}//End Class


} // end namespace
