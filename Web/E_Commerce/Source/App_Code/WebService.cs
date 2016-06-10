using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    public WebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
 
       public long thanhtoan(int mataikhoannguoigui, int mataikhoannguoinhan, DateTime D)
    {
        long t = 0;
        long sotien = 0;
        string sql = "select tien from chitietgiaodich where matknguoinhan=@mataikhoannguoinhan and manguoigui=@mataikhoannguoigui and ngay=@ngay ";
        Database db = new Database();
        SqlConnection Conn = db.connect();

        if (Conn.State == ConnectionState.Closed)
        {
            Conn.Open();
        }
        SqlCommand Cmd = new SqlCommand(sql, Conn);

        //Cmd.Parameters.Add(new SqlParameter("@mauser", SqlDbType.Int, 8));
        Cmd.Parameters.Add(new SqlParameter("@mataikhoannguoinhan", SqlDbType.Int));
        Cmd.Parameters.Add(new SqlParameter("@mataikhoannguoigui", SqlDbType.Int));
        Cmd.Parameters.Add(new SqlParameter("@ngay", SqlDbType.DateTime));


        // Cmd.Parameters["@mauser"].Value = txtmauser.Text;
        Cmd.Parameters["@mataikhoannguoinhan"].Value = mataikhoannguoinhan;
        Cmd.Parameters["@mataikhoannguoigui"].Value = mataikhoannguoigui;
        Cmd.Parameters["@ngay"].Value = D;

        SqlDataReader sqlreader = Cmd.ExecuteReader();
        while (sqlreader.Read())
        {
            sotien = long.Parse(sqlreader["tien"].ToString());

        }

        Conn.Close();
        return sotien;
    }
    
}
