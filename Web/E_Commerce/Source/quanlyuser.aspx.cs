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

public partial class quanlyuser : System.Web.UI.Page
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
        SqlCommand Cmd = new SqlCommand("INSERT INTO username( username, password, MaLoaiUser, Email, DienThoai, DiaChi) VALUES (@username,@password,@MaLoaiUser,@email,@DiaChi,@DienThoai)", Conn);
        //Cmd.Parameters.Add(new SqlParameter("@mauser", SqlDbType.Int, 8));
        Cmd.Parameters.Add(new SqlParameter("@username", SqlDbType.VarChar, 20));
        Cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 20));
        Cmd.Parameters.Add(new SqlParameter("@MaLoaiUser", SqlDbType.Int, 20));
        Cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 20));
        Cmd.Parameters.Add(new SqlParameter("@DiaChi", SqlDbType.VarChar, 20));
        Cmd.Parameters.Add(new SqlParameter("@DienThoai", SqlDbType.VarChar, 20));
       // Cmd.Parameters["@mauser"].Value = txtmauser.Text;
        Cmd.Parameters["@username"].Value = txtusername.Text;
        Cmd.Parameters["@password"].Value = txtpassword.Text;
        Cmd.Parameters["@MaLoaiUser"].Value = txtpassword.Text;
        Cmd.Parameters["@Email"].Value = txtpassword.Text;
        Cmd.Parameters["@diachi"].Value = txtpassword.Text;
        Cmd.Parameters["@dienthoai"].Value = txtpassword.Text;
        Cmd.ExecuteNonQuery();
        Conn.Close();

        Response.Redirect("quanlyuser.aspx");
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
