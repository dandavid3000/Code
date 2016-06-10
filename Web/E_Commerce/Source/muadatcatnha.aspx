<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="muadatcatnha.aspx.cs" Inherits="muadatcatnha" Title="Untitled Page" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="contenedit">
                  <div class="center_box_content">
                  <%if (Session["login"] != null)
                    { %>
                  <table>
                  <tr>
                      <td>
                          <asp:Button ID="btngoi1" runat="server" Text="Gói 1" onclick="btngoi1_Click" />
                      </td>
                      <td>
                           <asp:Button ID="btngoi2" runat="server" Text="Gói 2" 
                               onclick="btngoi2_Click1"  /></td>
                  </tr>
                  </table>
                    <%if (Session["goi1"] != null)
                      {
                           %>
                      <%if (Session["goi2"] != null)
                        { %>
                      <div style="font-family: Arial; font-size: large; color: #FFFFFF; background-color: #33CC33">Danh mục vật liệu xây dựng từ công ty VLXD thành viện Sơn Châu</div>
                      
                      <asp:GridView ID="GridView1" runat="server">
                      </asp:GridView>
                      <asp:DropDownList runat="server" ID="drLoaivatlieu" 
                          DataSourceID="SqlDataSource5" DataTextField="ten" DataValueField="ten" >
                      </asp:DropDownList>
                      <%} %>
                   
                      <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                          ConnectionString="<%$ ConnectionStrings:xaydung %>" 
                          SelectCommand="SELECT * FROM [vatlieu]"></asp:SqlDataSource>
                          <div>Chọn vật liệu dựng<asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                                  ConnectionString="<%$ ConnectionStrings:xaydung %>" 
                                  SelectCommand="SELECT * FROM [vatlieu]"></asp:SqlDataSource>
                              <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
                                  ConnectionString="<%$ ConnectionStrings:xaydung %>" 
                                  SelectCommand="SELECT * FROM [LoaiVatLieu]"></asp:SqlDataSource>
                      </div>
                        <table>
                        <tr>
                        <td>&nbsp;</td> <td>số lầu</td>
                        </tr>
                       
                        <tr>
                        <td>
                            <asp:Button ID="btntongtien" runat="server" onclick="btntongtien_Click" 
                                Text="Tính Toán" />
                            </td>
                         <td> 
                             <asp:TextBox ID="txtsolau" runat="server"></asp:TextBox></td>
                        </tr>
                         <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                             </td>
                         <td> 
                             <asp:TextBox ID="txtlable1" runat="server"></asp:TextBox></td>
                        </tr>
                         <tr>
                        <td style="height: 22px">
                            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                             </td>
                         <td style="height: 22px"> 
                             <asp:TextBox ID="txtlble2" runat="server"></asp:TextBox></td>
                        </tr>
                         <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                             </td>
                         <td> 
                             <asp:TextBox ID="txtlble3" runat="server"></asp:TextBox></td>
                        </tr>
                     
                        <tr>
                        <td>
                            <asp:Button ID="btntongtien0" runat="server" onclick="btntongtien_Click" 
                                Text="Tổng tiền" />
                            </td> <td>
                                <asp:TextBox ID="txttongtien" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                        <td style="height: 28px">
                          
                            </td> <td style="height: 28px">
                         <%if (Session["goi2"] == null)
                           {%>
                                 <asp:Button ID="Butgoi1" runat="server" Text="Thanh toán gói 1" 
                                     onclick="Butgoi1_Click" />
                                 <%}
                           else
                           {%>
                                 <asp:Button ID="butgoi2" runat="server" Text="Thanh Toán goi 2" 
                                     onclick="butgoi2_Click" />
                                 <%} %>
                             </td>
                        </tr>
                        </table>  
                          
                 <%} %>
                 <%}
                    else
                    {%>
                    <div style="font-family: Arial; font-size: medium; font-weight: bold; color: #FFFFFF; background-color: #009933">Đây là trang web chỉ giành cho thành viên </div>
                 <%} %>
                  </div>
                  
</asp:Content>


