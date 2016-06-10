using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Database
/// </summary>
public class Database
{
	public Database()
	{
		//
		// TODO: Add constructor logic here
		//
      
       
	}
    public SqlConnection connect()
    {
        SqlConnection Conn = new SqlConnection("Data Source=xaydung2.mssql.somee.com;Initial Catalog=xaydung2;User ID=leminhdinh;Password=12345678");
        if (Conn != null)
        {
            return Conn;
        }
        return null;
    }
   public DataTable convertSQLToDatatable(SqlDataSource mySQLDataSource)
    {
        DataView dv = new DataView();
        DataTable dt = new DataTable();
        dv = (DataView)mySQLDataSource.Select(DataSourceSelectArguments.Empty);
        dt = dv.ToTable();
        return dt;
    }
   public  int getmauser(string user)
   {
       int mauser = 0;
       string sql = "select MaUser from username where username=@username";
       Database db = new Database();
       SqlConnection Conn = db.connect();

       if (Conn.State == ConnectionState.Closed)
       {
           Conn.Open();
       }
       SqlCommand Cmd = new SqlCommand(sql, Conn);

       //Cmd.Parameters.Add(new SqlParameter("@mauser", SqlDbType.Int, 8));
       Cmd.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar, 20));

       // Cmd.Parameters["@mauser"].Value = txtmauser.Text;
       Cmd.Parameters["@username"].Value = user;
       SqlDataReader sqlreader = Cmd.ExecuteReader();
       while (sqlreader.Read())
       {
           mauser = int.Parse(sqlreader["MaUser"].ToString());
       }

       Conn.Close();
       return mauser;

   }
  
  public bool kiemtradiaocdaban(int madiaoc)
   {
       
       string sql = "select * from bandiaoc where madiaoc=@madiaoc";
       Database db = new Database();
       SqlConnection Conn = db.connect();
      
       if (Conn.State == ConnectionState.Closed)
       {
           Conn.Open();
       }
       SqlCommand Cmd = new SqlCommand(sql, Conn);

       //Cmd.Parameters.Add(new SqlParameter("@mauser", SqlDbType.Int, 8));
       Cmd.Parameters.Add(new SqlParameter("@madiaoc", SqlDbType.Int, 20));

       // Cmd.Parameters["@mauser"].Value = txtmauser.Text;
       Cmd.Parameters["@madiaoc"].Value = madiaoc;
       SqlDataReader sqlreader = Cmd.ExecuteReader();
       if (sqlreader.HasRows)
       {
          Conn.Close(); 
           return true;//da ban roi
       }
       
       Conn.Close();
       return  false;
   }
  public DataSet getvatlieu()
  {
      vatlieu.CungCapVatLieuWS vl = new vatlieu.CungCapVatLieuWS();
      DataSet ds = vl.Doc_danh_sach_vat_lieu();
      return ds;
  }
  public string tachchuoi(string diachi)
  {
      string []catchuoi=diachi.Split(',');
      string s = "<iframe id ='1' width='425' height='350' frameborder='0' scrolling='no' marginheight='0' marginwidth='0' src='http://maps.google.com/maps?f=q&amp;source=s_q&amp;hl=en&amp;geocode=&amp;";
     // string s2 = "q=77 3 tháng 2,+Ho+Chi+Minh+City,+Vietnam";
      string s2 = "q="+catchuoi[0] + ',' + catchuoi[1] +','+ "+Ho+Chi+Minh+City,+Vietnam";
      string s3= "&amp;aq=&amp;sll=10.758901,106.644405&amp;sspn=0.009465,0.021136&amp;ie=UTF8&amp;hq=&amp;hnear=";
     // string s4="77,+3+tháng+2";
      string s4 = catchuoi[0] + ',' + catchuoi[1];
      string s5=",+Ho+Chi+Minh+City,+Vietnam&amp;z=14&amp;ll=10.758901,106.644405&amp;output=embed'>'";
     string s6="</iframe><br /> <small> <a href='http://maps.google.com/maps?f=q&amp;source=embed&amp;hl=en&amp;geocode=&amp;";
   
  // string s7 = "q=77 3 tháng 2,Ho Chi Minh City,+Vietnam";
     string s7 = "q="+catchuoi[0] + ',' + catchuoi[1] + ',' + "+Ho+Chi+Minh+City,+Vietnam";
   string s8 = "&amp;aq=&amp;sll=10.758901,106.644405&amp;sspn=0.009465,0.021136&amp;ie=UTF8&amp;hq=&amp;hnear=X%C3%B3m+%C4%90%E1%BA%A5t,+Ho+Chi+Minh+City,+Vietnam&amp;z=14&amp;ll=10.758901,106.644405' style='color:#0000FF;text-align:left' >View Larger Map</a></small>";
   return s + s2 + s3 + s4 + s5 + s6+s7+s8;
  }
  public string getdiachi(int madiaoc)
  {
      string noidang = "";
      string sql = "select noidang from diaoctheovitri where madiaoc=@madiaoc";
      Database db = new Database();
      SqlConnection Conn = db.connect();

      if (Conn.State == ConnectionState.Closed)
      {
          Conn.Open();
      }
      SqlCommand Cmd = new SqlCommand(sql, Conn);

      //Cmd.Parameters.Add(new SqlParameter("@mauser", SqlDbType.Int, 8));
      Cmd.Parameters.Add(new SqlParameter("@madiaoc", SqlDbType.Int, 20));

      // Cmd.Parameters["@mauser"].Value = txtmauser.Text;
      Cmd.Parameters["@madiaoc"].Value = madiaoc;
      SqlDataReader sqlreader = Cmd.ExecuteReader();
      while (sqlreader.Read())
      {
          noidang = sqlreader["noidang"].ToString();
      }

      Conn.Close();
      return noidang;

  }
}
