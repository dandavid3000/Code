<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Thanhtoanthanhcong.aspx.cs" Inherits="Thanhtoanthanhcong" Title="Untitled Page" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="contenedit">
                  <div class="center_box_content">
                   <%if (Session["login"] != null && Session["thanhtoan"] != null)
                     { %>
                     Cảm ởn quý khách. Quý khách đã thanh toán thành công.Hảy lại công ty mang theo bản in này để nhận hồ sơ.
                     <%}
                     else
                     { %>
                     Trang web chỉ giành cho thành viên.
                   <%} %>
                  </div>
                  
</asp:Content>


