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

public partial class muadatcatnha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["goi2"] != null)
        {

            vatlieu.CungCapVatLieuWS vl = new vatlieu.CungCapVatLieuWS();
            DataSet ds = vl.Doc_danh_sach_vat_lieu();
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            dt.Columns["MaVatLieu"].ColumnMapping = MappingType.Hidden;
            dt.Columns.Remove("HinhMinhHoa");
            dt.Columns.Remove("NgayCapNhat");
            dt.Columns[2].ColumnMapping = MappingType.Hidden;
            //   dt.Columns()
            //dt.Columns.Remove();

            GridView1.DataSource = dt;
            GridView1.Width = 400;
            GridView1.DataBind();
        }
    }
    protected void ListView1_Disposed(object sender, EventArgs e)
    {

    }
    protected void btnclick(object sender, EventArgs e)
    {
       
        

    }
    protected void btngoi1_Click(object sender, EventArgs e)
    {
        Session["goi1"] = "goi1";
        Session["goi2"] = null;
    }
    protected void btntongtien_Click(object sender, EventArgs e)
    {
        if (Session["goi1"] != null && Session["goi2"] == null)
        {
            if (int.Parse(txtsolau.Text) == 1)
            {
                Label1.Text = "Xi Măng";
                txtlable1.Text = "20";
                Label2.Text = "Cát";
                txtlble2.Text = "15";
                Label3.Text = "sắt";
                txtlble3.Text = "10";
                txttongtien.Text = "2250000";
            }
            if (int.Parse(txtsolau.Text) == 2)
            {
                Label1.Text = "Xi Măng";
                txtlable1.Text = "40";
                Label2.Text = "Cát";
                txtlble2.Text = "15";
                Label3.Text = "sắt";
                txtlble3.Text = "10";
                txttongtien.Text = "3250000";
            }
            if (int.Parse(txtsolau.Text) == 3)
            {
                Label1.Text = "Xi Măng";
                txtlable1.Text = "60";
                Label2.Text = "Cát";
                txtlble2.Text = "15";
                Label3.Text = "sắt";
                txtlble3.Text = "10";
                txttongtien.Text = "4250000";
            }
        }
        if (Session["goi2"] != null)
        {
            if (int.Parse(txtsolau.Text) == 1)
            {
                Label1.Text = "Xi Măng";
                txtlable1.Text = "40";
                Label2.Text = "Cát";
                txtlble2.Text = "30";
                Label3.Text = "sắt";
                txtlble3.Text = "20";
                int tinh = 40 * 50000 + 30 * 45000 + 20 * 40000;
                txttongtien.Text = tinh.ToString();
            }
         else   if (int.Parse(txtsolau.Text) == 2)
            {
                Label1.Text = "Xi Măng";
                txtlable1.Text = "80";
                Label2.Text = "Cát";
                txtlble2.Text = "60";
                Label3.Text = "sắt";
                txtlble3.Text = "40";
                int tinh = (40 * 50000 + 30 * 45000 + 20 * 40000)*2;
                txttongtien.Text = tinh.ToString();
            }
            else if (int.Parse(txtsolau.Text) == 3)
            {
                Label1.Text = "Xi Măng";
                txtlable1.Text = "120";
                Label2.Text = "Cát";
                txtlble2.Text = "90";
                Label3.Text = "sắt";
                txtlble3.Text = "60";
                int tinh = (40 * 50000 + 30 * 45000 + 20 * 40000) * 3;
                txttongtien.Text = tinh.ToString();
            }
            else
            {
                Label1.Text = "Xi Măng";
                txtlable1.Text = "160";
                Label2.Text = "Cát";
                txtlble2.Text = "1200";
                Label3.Text = "sắt";
                txtlble3.Text = "80";
                int tinh = (40 * 50000 + 30 * 45000 + 20 * 40000) * 4;
                txttongtien.Text = tinh.ToString();
            }


        }
    }
   
    protected void btngoi2_Click1(object sender, EventArgs e)
    {
        Session["goi1"] = "goi1";
        Session["goi2"] = "goi2";
    }
    protected void btnthanhtoan_Click(object sender, EventArgs e)
    {

    }
    protected void Butgoi1_Click(object sender, EventArgs e)
    {
        Database db = new Database();
       int mauser= db.getmauser(Session["user"].ToString());

        string sql = "insert into muadatcatnha(mauser,maloaigoi,solau) values(@mauser,@maloaigoi,@solau)";
       
        SqlConnection Conn = db.connect();

        if (Conn.State == ConnectionState.Closed)
        {
            Conn.Open();
        }
        SqlCommand Cmd = new SqlCommand(sql, Conn);

        //Cmd.Parameters.Add(new SqlParameter("@mauser", SqlDbType.Int, 8));
        Cmd.Parameters.Add(new SqlParameter("@mauser", SqlDbType.Int, 20));
        Cmd.Parameters.Add(new SqlParameter("@maloaigoi", SqlDbType.Int, 20));
        Cmd.Parameters.Add(new SqlParameter("@solau", SqlDbType.Int, 20));

        // Cmd.Parameters["@mauser"].Value = txtmauser.Text;
        Cmd.Parameters["@mauser"].Value = mauser;
        Cmd.Parameters["@maloaigoi"].Value = 1;
        Cmd.Parameters["@solau"].Value = int.Parse(txtsolau.Text);
        Cmd.ExecuteNonQuery();
     

        Conn.Close();
       
    }
    protected void butgoi2_Click(object sender, EventArgs e)
    {
        Database db = new Database();
        int mauser = db.getmauser(Session["user"].ToString());

        string sql = "insert into muadatcatnha(mauser,maloaigoi,solau,Vatlieu) values(@mauser,@maloaigoi,@solau,@Vatlieu)";

        SqlConnection Conn = db.connect();

        if (Conn.State == ConnectionState.Closed)
        {
            Conn.Open();
        }
        SqlCommand Cmd = new SqlCommand(sql, Conn);

        //Cmd.Parameters.Add(new SqlParameter("@mauser", SqlDbType.Int, 8));
        Cmd.Parameters.Add(new SqlParameter("@mauser", SqlDbType.Int, 20));
        Cmd.Parameters.Add(new SqlParameter("@maloaigoi", SqlDbType.Int, 20));
        Cmd.Parameters.Add(new SqlParameter("@solau", SqlDbType.Int, 20));
        Cmd.Parameters.Add(new SqlParameter("@Vatlieu", SqlDbType.NVarChar, 20));

        // Cmd.Parameters["@mauser"].Value = txtmauser.Text;
        Cmd.Parameters["@mauser"].Value = mauser;
        Cmd.Parameters["@maloaigoi"].Value = 2;
        Cmd.Parameters["@solau"].Value = int.Parse(txtsolau.Text);
        Cmd.Parameters["@Vatlieu"].Value = drLoaivatlieu.SelectedValue;
        Cmd.ExecuteNonQuery();


        Conn.Close();
        Session["muadatcatnhathanhcong"] = "1";
        Response.Redirect("muadatcatnhathanhcong.aspx");
    }
}
