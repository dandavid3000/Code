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

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btntestthanhtoan_Click(object sender, EventArgs e)
    {
        Session["thanhtoan"] = "true";
      //  com.somee.kamnhattuan.WebService2 nh = new com.somee.kamnhattuan.WebService2();
      //  nh.chuyenkhoan(
      //  testthantoan.Text = "qui khac da thanh toan thanh cong";

    }
    protected void btnThanhtoan_Click(object sender, EventArgs e)
    {
        com.somee.kamnhattuan.WebService2 nh = new com.somee.kamnhattuan.WebService2();
     int gia=   nh.chuyenkhoan(int.Parse(txttaikhoannguoimua.Text), 1, Convert.ToDateTime(txtngaythanhtoan.Text));
        int gianha=int.Parse( Request.QueryString["gia"].ToString());
        if (gia >= gianha)
        {
            Database db = new Database();


            int mauser = db.getmauser(Session["user"].ToString());
            SqlConnection Conn = db.connect();
            string sql = "insert into bandiaoc(madiaoc,mauser,taikhoannguoithanhtoan,ngaythanhtoan)values(@madiaoc,@mauser,@taikhoannguoithanhtoan,@ngaythanhtoan)";
            if (Conn.State == ConnectionState.Closed)
            {
                Conn.Open();
            }
            SqlCommand Cmd = new SqlCommand(sql, Conn);

            //Cmd.Parameters.Add(new SqlParameter("@mauser", SqlDbType.Int, 8));
            Cmd.Parameters.Add(new SqlParameter("@madiaoc", SqlDbType.Int, 20));
            Cmd.Parameters.Add(new SqlParameter("@mauser", SqlDbType.Int, 20));
            Cmd.Parameters.Add(new SqlParameter("@taikhoannguoithanhtoan", SqlDbType.NVarChar, 20));
            Cmd.Parameters.Add(new SqlParameter("@ngaythanhtoan", SqlDbType.DateTime, 20));

            // Cmd.Parameters["@mauser"].Value = txtmauser.Text;
            Cmd.Parameters["@madiaoc"].Value = int.Parse(Request.QueryString["madiaoc"]);
            Cmd.Parameters["@mauser"].Value = mauser;
            Cmd.Parameters["@taikhoannguoithanhtoan"].Value = txttaikhoannguoimua.Text;
            Cmd.Parameters["@ngaythanhtoan"].Value = Convert.ToDateTime(txtngaythanhtoan.Text);

            Cmd.ExecuteNonQuery();

            Conn.Close();
            //sua lai daban trong ban dia oc
            
            string sql2 = "update diaoctheovitri set daban=1 where madiaoc=@madiaoc";
            if (Conn.State == ConnectionState.Closed)
            {
                Conn.Open();
            }
            SqlCommand Cmd2 = new SqlCommand(sql2, Conn);

            //Cmd.Parameters.Add(new SqlParameter("@mauser", SqlDbType.Int, 8));
            Cmd2.Parameters.Add(new SqlParameter("@madiaoc", SqlDbType.Int, 20));
        

            // Cmd.Parameters["@mauser"].Value = txtmauser.Text;
            Cmd2.Parameters["@madiaoc"].Value = int.Parse(Request.QueryString["madiaoc"]);
           
            Cmd2.ExecuteNonQuery();

            Conn.Close();
            Response.Redirect("Thanhtoanthanhcong.aspx");
        }
        else
        {
            testthanhtoan.Text = "Bạn Đả thanh toán không thành công Số tiền chuyển khoản không đủ.";
        }
       
    }
}
