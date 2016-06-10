using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace QLDL.DAO
{
   public class DataProvider
    {
       public static OleDbConnection ConnectionData()
       {
           string cnStr;
           cnStr = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = ../../Database/QLDaiLy.mdb";
           OleDbConnection cn = new OleDbConnection(cnStr);
           cn.Open();
           return cn;

       }
    }
}
