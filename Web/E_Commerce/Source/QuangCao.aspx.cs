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

public partial class QuangCao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        // SqlConnection Conn = new SqlConnection("server=DAN-PC;database=xaydung;integrated security=true");
        Database db = new Database();
        SqlConnection Conn = db.connect();

        if (Conn.State == ConnectionState.Closed)
        {
            Conn.Open();
        }
        SqlCommand Cmd = new SqlCommand("INSERT INTO Quangcao(TenQuangCao, MoTa, HinhAnh) VALUES (@TenQuangCao, @MoTa, @HinhAnh)", Conn);
        //Cmd.Parameters.Add(new SqlParameter("@mauser", SqlDbType.Int, 8));
        Cmd.Parameters.Add(new SqlParameter("@TenQuangCao", SqlDbType.VarChar, 50));
        Cmd.Parameters.Add(new SqlParameter("@MoTa", SqlDbType.VarChar, 250));
        Cmd.Parameters.Add(new SqlParameter("@HinhAnh", SqlDbType.VarChar, 50));
        // Cmd.Parameters["@mauser"].Value = txtmauser.Text;
        Cmd.Parameters["@TenQuangCao"].Value = txtTQC.Text;
        Cmd.Parameters["@MoTa"].Value = txtMT.Text;
        Cmd.Parameters["@HinhAnh"].Value = txtHA.Text;
        Cmd.ExecuteNonQuery();
        Conn.Close();

        Response.Redirect("QuangCao.aspx");
    }
}
