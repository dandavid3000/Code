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

public partial class KiemTraHangHoaDatHang : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnthem_Click(object sender, EventArgs e)
    {
         Database db = new Database();
        SqlConnection Conn = db.connect();

        if (Conn.State == ConnectionState.Closed)
        {
            Conn.Open();
        }

        SqlCommand Cmd = new SqlCommand("INSERT INTO vatlieu( Loaivatlieu, gia,soluong) VALUES (@Loaivatlieu,@gia,@soluong)", Conn);

        Cmd.Parameters.Add(new SqlParameter("@Loaivatlieu", SqlDbType.VarChar, 50));
        Cmd.Parameters.Add(new SqlParameter("@gia", SqlDbType.VarChar, 50));
        Cmd.Parameters.Add(new SqlParameter("@soluong", SqlDbType.Int, 20));

        // Cmd.Parameters["@mauser"].Value = txtmauser.Text;
        Cmd.Parameters["@Loaivatlieu"].Value = txtLVL.Text;
        Cmd.Parameters["@gia"].Value = txtG.Text;
        Cmd.Parameters["@soluong"].Value = txtSL.Text;
        Cmd.ExecuteNonQuery();
        Conn.Close();

        Response.Redirect("KiemTraHangHoaDatHang.aspx");
    }
}
