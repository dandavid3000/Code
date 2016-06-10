<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="doipass.aspx.cs" Inherits="doipass" Title="Untitled Page" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="contenedit">
                  <div class="center_box_content">
                   
                   <% if(Session["login"]!=null){%>
                     
                    
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                          ConnectionString="<%$ ConnectionStrings:xaydung %>" 
                          SelectCommand="SELECT * FROM [username] WHERE ([MaUser] = @MaUser)" 
                          UpdateCommand="update username set password=@password where mauser=@mauser">
                          <SelectParameters>
                              <asp:SessionParameter Name="MaUser" SessionField="mauser" Type="Int32" />
                          </SelectParameters>
                          <UpdateParameters>
                              <asp:Parameter Name="password" />
                              <asp:Parameter Name="mauser" />
                          </UpdateParameters>
                      </asp:SqlDataSource>
                      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                          DataKeyNames="MaUser" DataSourceID="SqlDataSource3">
                          <Columns>
                              
                             
                              
                              <asp:BoundField DataField="username" HeaderText="username" 
                                  SortExpression="username" >
                                  <ControlStyle Width="80" />
                                </asp:BoundField>
                             
                              <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                              <asp:BoundField DataField="DiaChi" HeaderText="DiaChi" 
                                  SortExpression="DiaChi" >
                                    <ControlStyle Width="70" />
                                   </asp:BoundField>
                              <asp:BoundField DataField="DienThoai" HeaderText="DienThoai" 
                                  SortExpression="DienThoai" />
                              <asp:CommandField ShowEditButton="True" />
                          </Columns>
                      </asp:GridView>
                      <div style="font-family: Arial; font-size: medium; font-weight: bold; color: #FFFFFF; background-color: #009900">Đổi password</div>
                    
                       <table>
                  <tr>
                     <td style="font-size: medium; font-family: Arial; color: #000000">
                         mật khẩu cũ   
                      </td>
                      <td>
                          <asp:TextBox ID="txtmatkhaucu" runat="server" TextMode="Password"></asp:TextBox>
                     </td>
                     
                  </tr>
                     <tr>
                     <td style="font-size: medium; font-family: Arial; color: #000000">
                         Mật khẩu mới   
                      </td>
                      <td>
                          <asp:TextBox ID="txtmatkhaumoi" runat="server" 
                              ondatabinding="txtmatkhaumoi_DataBinding" ondisposed="txtmatkhaumoi_Disposed" 
                              ontextchanged="txtmatkhaumoi_TextChanged" TextMode="Password"></asp:TextBox>
                         
                              
                              
                     </td>
                     
                  </tr>
                   
                     <tr>
                   <td>
                       <asp:Button ID="Button1" runat="server" Text="kiểm tra" />
                   </td>
                      <td  >
                          <asp:Button ID="btndoimatkhau" runat="server" Text="Đổi Mật Khẩu" 
                              onclick="btndoimatkhau_Click" />
                     </td>
                     
                  </tr>
                  <tr>
                   <td>
                       
                   </td>
                      <td  >
                          <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
                     </td>
                     
                  </tr>
                  </table>
                     
                      
                 
                   <%}
    else{
         %>
         <div style="font-family: Arial; color: #000000; font-size: medium; font-weight: bold">Chỉ giành cho user đăng nhập</div>
         <%} %>
                  </div>
                  
</asp:Content>


