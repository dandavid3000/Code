<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MuaDiaOc.aspx.cs" Inherits="Default2" Title="Untitled Page" %>



<asp:Content ID="Content1" runat="server" contentplaceholderid="contenedit">
   <div class="center_box_content">
                   
                    
      <div style="font-family: Arial; font-size: medium; background-color: #009900; color: #FFFFFF; font-weight: bold; "> Mua Địa Óc</div>  
      
      <%if (Session["login"] != null)
        { %>
      <%
          int idgoi = 0;
          if (Request.QueryString["idgoi"] != null)
          {
              idgoi = int.Parse(Request.QueryString["idgoi"].ToString());
          }
          if (idgoi == 1)
          {
              %>
              
              <div style="color: #000000; font-size: medium; font-weight: bold; font-family: Arial"> Đây là hình thức mua nhà được khách hàng đăng tin trên website của công ty. Quý khách muốn mua nhà thì hảy liên hệ trực tiếp với khách hàng đăng tin qua số điện thọai...</div>
              
         <%  }

          if (idgoi == 2)
          {  %>
          <div> Đây là hình thức mua nhà của công ty.Không thương lương giá.Quý khách liên hệ với công ty để hòan tấc thủ tục và thanh khỏan qua ngần hàng.</div>
          <div style="color: #FF0000; font-family: Arial"> Lưu ý: quý khách phải thực hiện chuyển khoản qua ngần trước khi điền đầy đủ thông tin vào phiếu thanh toán.</div>
      
     
     
         <table>
          <tr>
          
            <td>
               <a href="nganhang.aspx">  Thanh Toán qua ngân hàng.</a>
            </td>
           
                        
             
            </tr>
            <tr>
            <td>
            
           
                <asp:Label ID="testthanhtoan" runat="server" Text="quý khách phải thanh toán trước"></asp:Label>
              
            </td>
            <td>
                <asp:Button ID="btntestthanhtoan" runat="server" Text="Kiểm tra thanh toán" 
                    onclick="btntestthanhtoan_Click" />
            </td>
            </tr>
          </table>
          <% if(Session["thanhtoan"]!=null){%>
           <table id="thanhtoan">
           <tr>
           <td colspan="2" style="font-family: Arial; font-size: medium; color: #FFFFFF; font-weight: bold; background-color: #009933">
           Thanh toán địa óc
           </td>
           </tr>
          <tr>
             <td>
                 Tài khoản người mua
             </td>
              <td>
                  <asp:TextBox ID="txttaikhoannguoimua" runat="server"></asp:TextBox>
             </td>
          </tr>
           <tr>
             <td>
                 ngày thanh toán
             </td>
              <td>
                  <asp:TextBox ID="txtngaythanhtoan" runat="server"></asp:TextBox>
             </td>
          </tr>
          </tr>
           <tr>
             <td>
                 <asp:Button ID="btnboqua" runat="server" Text="Bỏ Qua" />
             </td>
              <td>
                   <asp:Button ID="btnThanhtoan" runat="server" Text="Thanh Toán" 
                       onclick="btnThanhtoan_Click" />
             </td>
          </tr>
          </table>
          <% }%>
         
      
      
        
          <% }

          if (idgoi == 3)
          {
              %>
              
              <div style="font-family: Arial; color: #000000; font-size: medium"> Đây là dịch vụ hổ trợ mua đất cất nhà</div>
         <%
          }
              
             %>
             
         
         
           
               
          <%}
        else
        { %>  
        Đây là trang web giành cho user đăng kí
          <%} %>
                               
   </div>
                  
</asp:Content>


