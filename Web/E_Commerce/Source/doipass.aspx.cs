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

public partial class doipass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btndoimatkhau_Click(object sender, EventArgs e)
    {
        string sql = "update username set password=@password where mauser=@mauser";
       
        Database db = new Database();
        SqlConnection Conn = db.connect();

        if (Conn.State == ConnectionState.Closed)
        {
            Conn.Open();
        }
        SqlCommand Cmd = new SqlCommand(sql, Conn);

        //Cmd.Parameters.Add(new SqlParameter("@mauser", SqlDbType.Int, 8));
        Cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 20));
        Cmd.Parameters.Add(new SqlParameter("@mauser", SqlDbType.Int, 20));


        // Cmd.Parameters["@mauser"].Value = txtmauser.Text;
        Cmd.Parameters["@password"].Value = txtmatkhaumoi.Text;
        Cmd.Parameters["@mauser"].Value = int.Parse(Session["mauser"].ToString());
        Cmd.ExecuteNonQuery();
        Label1.Text = "Ban Đã đổi mật khẩu thành công";
        Conn.Close();
        
        
    }
    protected void txtmatkhaumoi_TextChanged(object sender, EventArgs e)
    {
        if (txtmatkhaumoi.Text == txtmatkhaucu.Text)
        {
            Label1.Text = "Giống";
        }
    }
    protected void txtmatkhaumoi_Disposed(object sender, EventArgs e)
    {
        if (txtmatkhaumoi.Text == txtmatkhaucu.Text)
        {
            Label1.Text = "Giống";
        }
    }
    protected void txtmatkhaumoi_DataBinding(object sender, EventArgs e)
    {
        if (txtmatkhaumoi.Text == txtmatkhaucu.Text)
        {
            Label1.Text = "Giống";
        }
    }
}
