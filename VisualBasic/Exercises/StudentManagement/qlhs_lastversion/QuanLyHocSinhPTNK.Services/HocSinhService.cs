	

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
	/// An component type implementation of the 'HocSinh' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class HocSinhService : QuanLyHocSinhPTNK.Services.HocSinhServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the HocSinhService class.
		/// </summary>
		public HocSinhService() : base()
		{
		}

        public DataSet LayDSTenHS(string maHK, string tenlophoc)
        {
            return ConnectionScope.Current.DataProvider.HocSinhProvider.LayDSTenHS(maHK, tenlophoc);
        }

        public DataSet LayDSTenHS(string mamon, string maHK, string tenlophoc)
        {
            return ConnectionScope.Current.DataProvider.HocSinhProvider.LayDSTenHS(mamon, maHK, tenlophoc);
        }

        public DataSet LayThongTinHocSinh(string maHS, string tenHS, string ngaysinh, string diachi, string toan, string ly, string hoa, string sinh, string su, string dia, string van, string daoduc, string theduc, string DTB, string lop)
        {
            return ConnectionScope.Current.DataProvider.HocSinhProvider.LayThongTinHocSinh(maHS, tenHS, ngaysinh, diachi, toan,ly, hoa, sinh, su, dia, van, daoduc, theduc, DTB, lop);
        }
	}//End Class


} // end namespace
