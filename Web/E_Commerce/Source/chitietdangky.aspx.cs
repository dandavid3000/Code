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

public partial class chitietdangky : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    int getmauser(string user)
    {
        int mauser=0;
        string sql = "select MaUser from username where username=@username";
        Database db = new Database();
        SqlConnection Conn = db.connect();

        if (Conn.State == ConnectionState.Closed)
        {
            Conn.Open();
        }
        SqlCommand Cmd = new SqlCommand(sql, Conn);

        //Cmd.Parameters.Add(new SqlParameter("@mauser", SqlDbType.Int, 8));
        Cmd.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar, 20));
        
        // Cmd.Parameters["@mauser"].Value = txtmauser.Text;
        Cmd.Parameters["@username"].Value = user;
        SqlDataReader sqlreader= Cmd.ExecuteReader();
       while (sqlreader.Read())
       {
           mauser = int.Parse(sqlreader["MaUser"].ToString());
       }

        Conn.Close();
        return mauser;

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string sql1="";
        string sql2="";
        int idloaidiaoc = 0;
        string loaitinrao, tieude, diachi, giachothue;
        DateTime ngaydangtin, ngayhethang;
       // loaitinrao = idloaitinrao.ToString();
        tieude = txttieude.Text;
        diachi = txtdiachi.Text;
        giachothue = txtgiachothue.Text;
        ngaydangtin = Convert.ToDateTime(txtngaydangtin.Text);
       
        if (Request.QueryString["id"] != null)
        {
            idloaidiaoc = int.Parse(Request.QueryString["id"]);
            if (idloaidiaoc == 1)//nha
            {
                string loaidiaoc;
                string tinhtrangphaply, dacdiemkhac;
                //loaidiaoc = listLoaidiaoc.Text;
                tinhtrangphaply = txtTinhtrangphaply.Text;
                dacdiemkhac = txtddkhac.Text;
                sql1 = "insert into tinrao(mauser,MaLoaiDiaOc,maloaitinrao,tieude,diachi,gia,NgayHetHan,NgayDang,hinh,trangthaitinrao,MaViTri)values (@mauser,@maloaidiaoc,@maloaitinrao,@tieude,@diachi,@gia,@ngayhethan,@ngaydangtin,@hinh,@tranthaitinrao,@MaViTri)";
                Database db = new Database();
                SqlConnection Conn = db.connect();

                if (Conn.State == ConnectionState.Closed)
                {
                    Conn.Open();
                }
                SqlCommand Cmd = new SqlCommand(sql1, Conn);
                
                //Cmd.Parameters.Add(new SqlParameter("@mauser", SqlDbType.Int, 8));
                Cmd.Parameters.Add(new SqlParameter("@mauser", SqlDbType.Int, 20));
                Cmd.Parameters.Add(new SqlParameter("@maloaidiaoc", SqlDbType.Int, 20));
                Cmd.Parameters.Add(new SqlParameter("@maloaitinrao", SqlDbType.Int, 20));
                Cmd.Parameters.Add(new SqlParameter("@tieude", SqlDbType.VarChar, 20));
                Cmd.Parameters.Add(new SqlParameter("@diachi", SqlDbType.VarChar, 20));
                Cmd.Parameters.Add(new SqlParameter("@gia", SqlDbType.VarChar, 20));
                Cmd.Parameters.Add(new SqlParameter("@ngayhethan", SqlDbType.DateTime, 20));
                Cmd.Parameters.Add(new SqlParameter("@hinh", SqlDbType.VarChar, 20));
                Cmd.Parameters.Add(new SqlParameter("@tranthaitinrao", SqlDbType.Int, 20));
                Cmd.Parameters.Add(new SqlParameter("@ngaydangtin", SqlDbType.DateTime, 20));
                Cmd.Parameters.Add(new SqlParameter("@MaViTri", SqlDbType.Int, 20));
                // Cmd.Parameters["@mauser"].Value = txtmauser.Text;
                Cmd.Parameters["@mauser"].Value = getmauser(Session["user"].ToString());
                Cmd.Parameters["@maloaidiaoc"].Value = Drloaidiaocnha.SelectedValue;
                Cmd.Parameters["@maloaitinrao"].Value = Drloaitinrao.SelectedValue;
                Cmd.Parameters["@tieude"].Value = txttieude.Text;
                Cmd.Parameters["@diachi"].Value = txtdiachi.Text;
                Cmd.Parameters["@gia"].Value = txtgia.Text;
                Cmd.Parameters["@ngayhethan"].Value = Convert.ToDateTime(txtngaydangtin.Text);
                Cmd.Parameters["@hinh"].Value = txthinh.Text;
                Cmd.Parameters["@tranthaitinrao"].Value = 0;
                Cmd.Parameters["@ngaydangtin"].Value = DateTime.Now.ToString();
                Cmd.Parameters["@MaViTri"].Value = drmavitri.SelectedValue;
                Cmd.ExecuteNonQuery();
                
                Conn.Close();
                Response.Redirect("dangtinthanhcong.aspx");
            }
            else if (idloaidiaoc == 2)//dat
            {
               // int maloaidat;
                //string dientichkhuongvien, dientichkhuvuc;
                //loaidiaoc = listLoaidiaoc.Text;
               // tinhtrangphaply = txtTinhtrangphaply.Text;
              //  dacdiemkhac = txtddkhac.Text;
                sql1 = "insert into tinrao(mauser,MaLoaiDat,maloaitinrao,tieude,diachi,gia,NgayHetHan,NgayDang,hinh,trangthaitinrao,dientichkhuongvien,dientichkhuvuc,huong,thongtinlienhe,dacdiemkhac)values (@mauser,@maloaidat,@maloaitinrao,@tieude,@diachi,@gia,@ngay,@ngaydangtin,@hinh,@tranthaitinrao,@dientichkhuongvien,@dientichkhuvuc,@huong,@thongtinlienhe,@dacdiemkhac)";
                Database db = new Database();
                SqlConnection Conn = db.connect();

                if (Conn.State == ConnectionState.Closed)
                {
                    Conn.Open();
                }
                SqlCommand Cmd = new SqlCommand(sql1, Conn);

                //Cmd.Parameters.Add(new SqlParameter("@mauser", SqlDbType.Int, 8));
                Cmd.Parameters.Add(new SqlParameter("@mauser", SqlDbType.Int, 20));
                Cmd.Parameters.Add(new SqlParameter("@maloaidat", SqlDbType.Int, 20));
                Cmd.Parameters.Add(new SqlParameter("@maloaitinrao", SqlDbType.Int, 20));
                Cmd.Parameters.Add(new SqlParameter("@tieude", SqlDbType.VarChar, 20));
                Cmd.Parameters.Add(new SqlParameter("@diachi", SqlDbType.VarChar, 20));
                Cmd.Parameters.Add(new SqlParameter("@gia", SqlDbType.VarChar, 20));
                Cmd.Parameters.Add(new SqlParameter("@ngay", SqlDbType.DateTime, 20));
                Cmd.Parameters.Add(new SqlParameter("@hinh", SqlDbType.VarChar, 20));
                Cmd.Parameters.Add(new SqlParameter("@tranthaitinrao", SqlDbType.Int, 20));
                Cmd.Parameters.Add(new SqlParameter("@dientichkhuongvien", SqlDbType.Int, 20));
                Cmd.Parameters.Add(new SqlParameter("@dientichkhuvuc", SqlDbType.Int, 20));
                Cmd.Parameters.Add(new SqlParameter("@huong", SqlDbType.NVarChar, 20));
                Cmd.Parameters.Add(new SqlParameter("@thongtinlienhe", SqlDbType.NVarChar, 20));
                Cmd.Parameters.Add(new SqlParameter("@dacdiemkhac", SqlDbType.NVarChar, 20));
                Cmd.Parameters.Add(new SqlParameter("@ngaydangtin", SqlDbType.NVarChar, 20));
                // Cmd.Parameters["@mauser"].Value = txtmauser.Text;
                Cmd.Parameters["@mauser"].Value = getmauser(Session["user"].ToString());
                Cmd.Parameters["@maloaidat"].Value = idloaidiaoc;
                Cmd.Parameters["@maloaitinrao"].Value = Drloaitinrao.SelectedValue;
                Cmd.Parameters["@tieude"].Value = txttieude.Text;
                Cmd.Parameters["@diachi"].Value = txtdiachi.Text;
                Cmd.Parameters["@gia"].Value = txtgia.Text;
                Cmd.Parameters["@ngay"].Value = Convert.ToDateTime(txtngaydangtin.Text);
                Cmd.Parameters["@hinh"].Value = txthinh.Text;
                Cmd.Parameters["@tranthaitinrao"].Value = 0;
                Cmd.Parameters["@dientichkhuongvien"].Value = txtDientichkhuonvien.Text;
                Cmd.Parameters["@dientichkhuvuc"].Value = txtdientichkhuvuc.Text;
                Cmd.Parameters["@huong"].Value = txtHuong.Text;
                Cmd.Parameters["@thongtinlienhe"].Value = txtthongtinlienhe.Text;
                Cmd.Parameters["@dacdiemkhac"].Value = txtdacdiemdat.Text;
                Cmd.Parameters["@ngaydangtin"].Value = DateTime.Now.ToString();
                Cmd.ExecuteNonQuery();

                Conn.Close();
                Response.Redirect("dangtinthanhcong.aspx");
            }
        }
    }
}
