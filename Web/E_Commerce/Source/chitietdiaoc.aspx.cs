﻿using System;
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

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btngoi2_Click(object sender, EventArgs e)
    {
        if (Session["login"] == null)//chua login
        {
            
            Response.Redirect("default.aspx");
        }
        else//login rùi cho phep mua
        {
            Response.Redirect("diachinganhang.aspx");
        }
    }
    protected void btnthanhtoan_Click(object sender, EventArgs e)
    {
        //check tai khoản ngân hàng services.
    }
    protected void btngoi3_Click(object sender, EventArgs e)
    {
       
        Response.Redirect("xaynha.aspx");
        
    }
}
