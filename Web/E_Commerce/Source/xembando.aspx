<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="xembando.aspx.cs" Inherits="xembando" Title="Untitled Page" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="contenedit">
                  <div class="center_box_content">
                    <%
                        int madiaoc = int.Parse(Request.QueryString["madiaoc"].ToString());
                        Database db = new Database();

                        string diachi = db.getdiachi(madiaoc);
     Response.Write(db.tachchuoi(diachi)); %>
                   
                  </div>
                  
</asp:Content>


