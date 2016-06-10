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
using System.Data.OleDb;

public partial class timkiem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnTimKiem_Click(object sender, EventArgs e)
    {
        string sql = "select tieude,diachi,gia,NgayHetHan,hinh,dientichkhuongvien,dientichkhuvuc,huong,thongtinlienhe from tinrao where MaLoaiDiaOc=@maloaidiaoc and MaLoaiTinRao=@maloaitinrao and MaViTri=@mavitri";

        Database db = new Database();
        SqlConnection Conn = db.connect();

        if (Conn.State == ConnectionState.Closed)
        {
            Conn.Open();
        }
        SqlCommand Cmd = new SqlCommand(sql, Conn);
              
        //Cmd.Parameters.Add(new SqlParameter("@mauser", SqlDbType.Int, 8));
        Cmd.Parameters.Add(new SqlParameter("@maloaidiaoc", SqlDbType.Int));
        Cmd.Parameters.Add(new SqlParameter("@maloaitinrao", SqlDbType.Int));
        Cmd.Parameters.Add(new SqlParameter("@mavitri", SqlDbType.Int));

        // Cmd.Parameters["@mauser"].Value = txtmauser.Text;
        Cmd.Parameters["@maloaidiaoc"].Value = List1.SelectedValue;
        Cmd.Parameters["@maloaitinrao"].Value = List2.SelectedValue;
        Cmd.Parameters["@mavitri"].Value =List3.SelectedValue;
       

        SqlDataAdapter da = new SqlDataAdapter(Cmd);
        DataTable dt=new DataTable();
        da.Fill(dt);
        dtgKetQua.DataSource = dt;
        
        
        
        Conn.Close();
        dtgKetQua.DataSource = dt;
        dtgKetQua.DataBind();
        
    }
    
    
}
