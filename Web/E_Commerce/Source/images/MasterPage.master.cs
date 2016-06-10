using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btndangnhap_Click(object sender, EventArgs e)
    {
        if(checklogin(txtuser.Text,txtpass.Text))
        {
           int mauser = 0;
            Database db = new Database();
            string user = txtuser.Text;
            if (txtuser.Text != null)
           {
                mauser = db.getmauser(user);
            }
            Session["login"]="login";
            Session["user"]=txtuser.Text;
            Session["mauser"] = mauser.ToString();
            btndangnhap.Visible = false;
            btndangxuat.Visible = true;
            btnchangepass.Visible = true;
            
           // Response.Redirect("default.aspx");
           
        }
    }
    protected void btnchangepass_Click(object sender, EventArgs e)
    {
        Response.Redirect("doipass.aspx");
      
    }
    bool checklogin(string user, string pass)
    {

        //SqlConnection Conn = new SqlConnection("server=WIN7-PC\\SQLEXPRESS2;database=xaydung;integrated security=true");
        Database db =new Database();
        
        SqlConnection Conn = db.connect();
        if (Conn.State == ConnectionState.Closed)
        {
        Conn.Open();
        }
        SqlCommand Cmd = new SqlCommand("select * from username where username=@user and password=@pass", Conn);
        Cmd.Parameters.Add(new SqlParameter("@user", SqlDbType.VarChar, 8));
        Cmd.Parameters.Add(new SqlParameter("@pass", SqlDbType.VarChar, 8));
        Cmd.Parameters["@user"].Value = user;
        Cmd.Parameters["@pass"].Value = pass;
        SqlCommand cmd2 = new SqlCommand("select * from username where username=@user and password=@pass and maloaiuser=1", Conn);
        cmd2.Parameters.Add(new SqlParameter("@user", SqlDbType.VarChar, 8));
        cmd2.Parameters.Add(new SqlParameter("@pass", SqlDbType.VarChar, 8));
        cmd2.Parameters["@user"].Value = user;
        cmd2.Parameters["@pass"].Value = pass;
        if (cmd2.ExecuteReader().HasRows)
        {
            Session["admin"] = "admin";
            return true;
        }
        else
            Conn.Close();
        if (Conn.State == ConnectionState.Closed)
        {
            Conn.Open();
        }
        if (Cmd.ExecuteReader().HasRows)
        return true;
        else
        return false;
     }

    protected void btndangxuat_Click(object sender, EventArgs e)
    {
        btndangxuat.Visible = false;
        Session["login"] = null;
        Session["admin"] = null;
        Session["mauser"] = null;
        btndangnhap.Visible = true;
        btndangxuat.Visible = false;
       // Response.Redirect("default.aspx");
        
    }
}
