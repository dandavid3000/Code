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

public partial class DangKy : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      
        if (txtCaptcha.Text.Equals(Session["Captcha"].ToString(), StringComparison.OrdinalIgnoreCase))
          
            lblMessage.Text = "d";
        else
            lblMessage.Text = "s";


        if (lblMessage.Text == "d" && Label2.Text == "Tên truy cập có thể sử dụng")
        {

            string sql = "insert into username(username,password,maloaiuser) values (@username,@password,2)";

            Database db = new Database();
            SqlConnection Conn = db.connect();

            if (Conn.State == ConnectionState.Closed)
            {
                Conn.Open();
            }
            SqlCommand Cmd = new SqlCommand(sql, Conn);

            //Cmd.Parameters.Add(new SqlParameter("@mauser", SqlDbType.Int, 8));
            Cmd.Parameters.Add(new SqlParameter("@username", SqlDbType.VarChar, 50));
            Cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 250));


            // Cmd.Parameters["@mauser"].Value = txtmauser.Text;
            Cmd.Parameters["@username"].Value = txtuser.Text;
            Cmd.Parameters["@password"].Value = txtpass.Text;
            Cmd.ExecuteNonQuery();

            Conn.Close();
            Response.Redirect("Default.aspx");

        }
        else
            Label1.Text = "Bạn đã nhập sai mã xác nhận";
    }



    protected void imbReLoad_Click(object sender, ImageClickEventArgs e)
    {

        imbReLoad.ImageUrl = "images/reload.jpg";


    }
    protected void btnKiemTra_Click(object sender, EventArgs e)
    {
        string sql = "Select username from username where username=@user";

        Database db = new Database();
        SqlConnection Conn = db.connect();

        if (Conn.State == ConnectionState.Closed)
        {
            Conn.Open();
        }
        SqlCommand Cmd = new SqlCommand(sql, Conn);
    
           Cmd.Parameters.Add(new SqlParameter("@user", SqlDbType.VarChar, 50));

            Cmd.Parameters["@user"].Value = txtuser.Text;
            SqlDataReader reader = Cmd.ExecuteReader();

            if (reader.HasRows == true)
            {
                Label2.Text = "Tên truy cập này đã tồn tại.";
            }
            else
                Label2.Text = "Tên truy cập có thể sử dụng";
            Conn.Close();
    }
}
