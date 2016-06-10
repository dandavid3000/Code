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

public partial class DuyetTinRao : System.Web.UI.Page
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
        SqlCommand Cmd = new SqlCommand("INSERT INTO tinrao( MaUser, MaLoaiDiaOc, MaLoaiTinRao, TieuDe, DiaChi, Gia, NgayHetHan, Hinh, TrangThaiTinRao) VALUES (1,@MaLoaiDiaOc,@MaLoaiTinRao,@TieuDe,@DiaChi,@Gia,@NgayHetHan,@Hinh,1)", Conn);
       // SqlCommand Cmd = new SqlCommand("INSERT INTO diaoctheovitri( MaUser, MaLoaiDiaOc, MaLoaiTinRao, TieuDe, DiaChi, Gia, NgayHetHan, Hinh, TrangThaiTinRao) VALUES (1,@MaLoaiDiaOc,@MaLoaiTinRao,@TieuDe,@DiaChi,@Gia,@NgayHetHan,@Hinh,1)", Conn);
     
        Cmd.Parameters.Add(new SqlParameter("@MaLoaiDiaOc", SqlDbType.Int));
        Cmd.Parameters.Add(new SqlParameter("@MaLoaiTinRao", SqlDbType.Int));
        Cmd.Parameters.Add(new SqlParameter("@TieuDe", SqlDbType.NVarChar, 50));
        Cmd.Parameters.Add(new SqlParameter("@DiaChi", SqlDbType.NVarChar, 50));
        Cmd.Parameters.Add(new SqlParameter("@Gia", SqlDbType.Int));
        Cmd.Parameters.Add(new SqlParameter("@NgayHetHan", SqlDbType.DateTime));
        Cmd.Parameters.Add(new SqlParameter("@Hinh", SqlDbType.VarChar, 50));
      
        // Cmd.Parameters["@mauser"].Value = txtmauser.Text;
        Cmd.Parameters["@MaLoaiDiaoc"].Value = txtMLDO.Text;
        Cmd.Parameters["@MaLoaiTinRao"].Value = txtMLTR.Text;
        Cmd.Parameters["@TieuDe"].Value = txtTD.Text;
        Cmd.Parameters["@DiaChi"].Value = txtDC.Text;
        Cmd.Parameters["@Gia"].Value = txtG.Text;
        Cmd.Parameters["@NgayHetHan"].Value = txtNHH.Text;
        Cmd.Parameters["@Hinh"].Value = txtH.Text;
        Cmd.ExecuteNonQuery();
        Conn.Close();

        Response.Redirect("DuyetTinRao.aspx");
    }
    protected void txtH_TextChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void SqlDataSource3_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
}
