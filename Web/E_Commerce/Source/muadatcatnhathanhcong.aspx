<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="muadatcatnhathanhcong.aspx.cs" Inherits="muadatcatnhathanhcong" Title="Untitled Page" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="contenedit">
                  <div class="center_box_content">
                  <%if (Session["muadatcatnhathanhcong"] != null)
                    { %>
                    <div style="font-family: Arial; font-size: large; font-weight: bold; color: #FFFFFF; background-color: #009900">Quí khách đã hoàn tấc thủ tục mua đất cất nhà</div>
                  <%}
                    else
                    {%>
                    <div style="font-family: Arial; color: #FF0000; font-size: large">Bạn hảy xem lại quá trình thanh toán thất bại.</div>
                   <%} %>
                  </div>
                  
</asp:Content>


