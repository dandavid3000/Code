<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DangKyTinRao.aspx.cs" Inherits="DangKyTinRao" Title="Untitled Page" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="contenedit">
                  <div class="center_box_content">
                                      
                      <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource3" 
                          DataKeyNames="MaLoaiDiaOc">
                          <ItemTemplate>
                              <tr style="background-color: #FFFBD6;color: #333333;">
                                 
                                  <td>
                                     <a href="chitietdangky.aspx?id=<%#Eval("MaLoaiDiaOc") %>"><asp:Label ID="TenLoaiDiaOcLabel" runat="server" 
                                          Text='<%# Eval("TenLoaiDiaOc") %>' /></a> 
                                  </td>
                              </tr>
                          </ItemTemplate>
                          <AlternatingItemTemplate>
                              <tr style="background-color: #FAFAD2;color: #284775;">
                                 
                                  <td>
                                     <a href="chitietdangky.aspx?id=<%#Eval("MaLoaiDiaOc") %>"><asp:Label ID="TenLoaiDiaOcLabel" runat="server" 
                                          Text='<%# Eval("TenLoaiDiaOc") %>' /></a> 
                                  </td>
                              </tr>
                          </AlternatingItemTemplate>
                          <EmptyDataTemplate>
                              <table runat="server" 
                                  style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                                  <tr>
                                      <td>
                                          No data was returned.</td>
                                  </tr>
                              </table>
                          </EmptyDataTemplate>
                          <InsertItemTemplate>
                              <tr style="">
                                  <td>
                                      <asp:Button ID="InsertButton" runat="server" CommandName="Insert" 
                                          Text="Insert" />
                                      <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                                          Text="Clear" />
                                  </td>
                                  <td>
                                      &nbsp;</td>
                                  <td>
                                      <asp:TextBox ID="TenLoaiDiaOcTextBox" runat="server" 
                                          Text='<%# Bind("TenLoaiDiaOc") %>' />
                                  </td>
                              </tr>
                          </InsertItemTemplate>
                          <LayoutTemplate>
                              <table runat="server">
                                  <tr runat="server">
                                      <td runat="server">
                                          <table ID="itemPlaceholderContainer" runat="server" border="1" 
                                              style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                              <tr runat="server" style="background-color: #FFFBD6;color: #333333;">
                                                
                                                  <th runat="server">
                                                      Loại Địa ốc Muốn Đăng Tin</th>
                                              </tr>
                                              <tr ID="itemPlaceholder" runat="server">
                                              </tr>
                                          </table>
                                      </td>
                                  </tr>
                                  <tr runat="server">
                                      <td runat="server" 
                                          style="text-align: center;background-color: #FFCC66;font-family: Verdana, Arial, Helvetica, sans-serif;color: #333333;">
                                      </td>
                                  </tr>
                              </table>
                          </LayoutTemplate>
                          <EditItemTemplate>
                              <tr style="background-color: #FFCC66;color: #000080;">
                                  <td>
                                      <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                                          Text="Update" />
                                      <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                                          Text="Cancel" />
                                  </td>
                                  <td>
                                    
                                  </td>
                                  <td>
                                      <asp:TextBox ID="TenLoaiDiaOcTextBox" runat="server" 
                                          Text='<%# Bind("TenLoaiDiaOc") %>' />
                                  </td>
                              </tr>
                          </EditItemTemplate>
                          <SelectedItemTemplate>
                              <tr style="background-color: #FFCC66;font-weight: bold;color: #000080;">
                                  
                                  <td>
                                      <asp:Label ID="TenLoaiDiaOcLabel" runat="server" 
                                          Text='<%# Eval("TenLoaiDiaOc") %>' />
                                  </td>
                              </tr>
                          </SelectedItemTemplate>
                      
                      </asp:ListView>
                                      
                      <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                          ConnectionString="<%$ ConnectionStrings:xaydung %>" 
                          SelectCommand="SELECT [MaLoaiDiaOc], [TenLoaiDiaOc] FROM [loaidiaoc]">
                      </asp:SqlDataSource>
                                      
                  </div>
                  
</asp:Content>


