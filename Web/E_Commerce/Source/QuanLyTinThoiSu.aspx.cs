using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class QuanLyTinThoiSu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        // SqlConnection Conn = new SqlConnection("server=DAN-PC;database=xaydung;integrated security=true");
        Database db = new Database();
        SqlConnection Conn = db.connect();

        if (Conn.State == ConnectionState.Closed)
        {
            Conn.Open();
        }
        SqlCommand Cmd = new SqlCommand("INSERT INTO loaitintuc( TenLoaiTin) VALUES (@TenLoaiTin)", Conn);
        //Cmd.Parameters.Add(new SqlParameter("@mauser", SqlDbType.Int, 8));
        Cmd.Parameters.Add(new SqlParameter("@TenLoaiTin", SqlDbType.VarChar,50));
        // Cmd.Parameters["@mauser"].Value = txtmauser.Text;
        Cmd.Parameters["@TenLoaiTin"].Value = txtTLT.Text;
        Cmd.ExecuteNonQuery();
        Conn.Close();

        Response.Redirect("QuanLyTinThoiSu.aspx");
    }
}
