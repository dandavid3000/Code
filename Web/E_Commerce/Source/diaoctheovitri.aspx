<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="diaoctheovitri.aspx.cs" Inherits="Default2" Title="Untitled Page" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="contenedit">
                  <div class="center_box_content">
                  
          <% int idvitri =int.Parse( Request.QueryString["idvitri"]); 
              switch(idvitri)
              {
                  case 1:
                  {
                      Response.Write("<h2>");
                      Response.Write("Nhà ở quận:");
                      Response.Write(idvitri.ToString());
                      Response.Write("</h2>");
                  }
                  break;
                      
              }
              %>
          
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                          ConnectionString="<%$ ConnectionStrings:xaydung %>" 
                          
                          
                          
                          
                          
                          SelectCommand="SELECT * FROM [diaoctheovitri] WHERE (([MaViTri] = @MaViTri) AND ([Daban] = @Daban))">
    <SelectParameters>
        <asp:QueryStringParameter Name="MaViTri" QueryStringField="idvitri" 
            Type="Int32" DefaultValue="1" />
        <asp:Parameter DefaultValue="0" Name="Daban" Type="Int32" />
    </SelectParameters>
                      </asp:SqlDataSource>
                   <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1" >
                          <ItemTemplate >
                          
                              <tr>
                                                                    
                                  <td width="100" style="font-size: large; font-weight: bold; color: #008000">
                                     <asp:Label ID="tendiaocLabel" runat="server" Text='<%# Eval("tendiaoc") %>' Font-Bold="True" />
                                  </td>
                                  <td width ="150">
                                      <asp:Label ID="motaLabel" runat="server" Text='<%# Eval("mota") %>' /><br />
                                   
                                      <a href="chitietdiaoc.aspx?madiaoc=<%#Eval("madiaoc") %>&&MaLoaiDiaOc=<%# Eval("MaLoaiDiaOc") %>"> chi tiết.... </a>
                                      <a href="xembando.aspx?madiaoc=<%#Eval("madiaoc") %>&&MaLoaiDiaOc=<%# Eval("MaLoaiDiaOc") %>"> Xem Bản Đồ.... </a>
                                  </td>
                                  <td width="200">
                                      <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("hinh") %>' Width="100%" Height="100%" />
                                  </td>
                              </tr>
                            
                          </ItemTemplate>
                          <AlternatingItemTemplate>
                              <tr style="">
                                 
                                  <td width="100" style="font-size: large; font-weight: bold; color: #008000">
                                      <asp:Label ID="tendiaocLabel" runat="server" Text='<%# Eval("tendiaoc") %>' />
                                  </td>
                                  <td width="150">
                                      <asp:Label ID="motaLabel" runat="server" Text='<%# Eval("mota") %>' /><br />
                                     
                                        <a href="chitietdiaoc.aspx?madiaoc=<%#Eval("madiaoc") %>&&maloaidiaoc=<%# Eval("MaLoaiDiaOc") %>"> 
                                      chi tiết.... </a>
                                      <a href="xembando.aspx?madiaoc=<%#Eval("madiaoc") %>&&MaLoaiDiaOc=<%# Eval("MaLoaiDiaOc") %>"> Xem Bản Đồ.... </a>
                                  </td>
                                  <td width="200">
                                      <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("hinh") %>' Width="100%" Height="100%"/>
                                      
                                      
                                  </td>
                              </tr>
                          </AlternatingItemTemplate>
                          <EmptyDataTemplate>
                              <table id="Table1" runat="server" style="">
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
                                  
                                  <td width="100">
                                      <asp:TextBox ID="tendiaocTextBox" runat="server" 
                                          Text='<%# Bind("tendiaoc") %>' />
                                  </td>
                                  <td width="100">
                                      <asp:TextBox ID="motaTextBox" runat="server" Text='<%# Bind("mota") %>' />
                                  </td>
                                  <td width="150">
                                      <asp:TextBox ID="urlhinhTextBox" runat="server" text='<%# Bind("hinh") %>' />
                                  </td>
                              </tr>
                          </InsertItemTemplate>
                          <LayoutTemplate>
                              <table id="Table2" runat="server" >
                                  <tr id="Tr1" runat="server">
                                      <td id="Td1" runat="server">
                                          <table ID="itemPlaceholderContainer" runat="server" border="0" style="" width="100%">
                                              <tr id="Tr2" runat="server" style="background-color: #009900; font-family: Arial; font-size: medium; font-weight: bold; color: #FFFFFF;">
                                                  
                                                  
                                                  <th id="Th1" runat="server" width="100" height="30" align="center">
                                                      Tên địa ốc</th>
                                                  <th id="Th2" runat="server" width="150" height="30" align="center" >
                                                      Mô tả</th>
                                                  <th id="Th3" runat="server" width="250" height="30" align="center">
                                                     <center>Hình</center> </th>
                                              </tr>
                                              <tr ID="itemPlaceholder" runat="server">
                                              </tr>
                                          </table>
                                      </td>
                                  </tr>
                                  <tr id="Tr3" runat="server">
                                      <td id="Td2" runat="server" style="">
                                          <asp:DataPager ID="DataPager1" runat="server">
                                              <Fields>
                                                  <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                                                      ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                                  <asp:NumericPagerField />
                                                  <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" 
                                                      ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                              </Fields>
                                          </asp:DataPager>
                                      </td>
                                  </tr>
                              </table>
                          </LayoutTemplate>
                          <EditItemTemplate>
                              <tr style="">
                                  <td>
                                      <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                                          Text="Update" />
                                      <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                                          Text="Cancel" />
                                  </td>
                                 
                                  <td width="100">
                                      <asp:TextBox ID="tendiaocTextBox" runat="server" 
                                          Text='<%# Bind("tendiaoc") %>' />
                                  </td>
                                  <td width="100">
                                      <asp:TextBox ID="motaTextBox" runat="server" Text='<%# Bind("mota") %>' />
                                  </td>
                                  <td width="150">
                                      <asp:TextBox ID="urlhinhTextBox" runat="server" text='<%# Bind("urlhinh") %>' />
                                  </td>
                              </tr>
                          </EditItemTemplate>
                          <SelectedItemTemplate>
                              <tr style="">
                                  
                                  <td width="100">
                                      <asp:Label ID="tendiaocLabel" runat="server" Text='<%# Eval("tendiaoc") %>' />
                                  </td>
                                  <td width="100">
                                      <asp:Label ID="motaLabel" runat="server" Text='<%# Eval("mota") %>' />
                                  </td>
                                  <td width="150">
                                      <asp:Label ID="urlhinhLabel" runat="server" ImageUrl='<%# Eval("hinh") %>' />
                                  </td>
                              </tr>
                          </SelectedItemTemplate>
                      </asp:ListView>
                  </div>
                  
</asp:Content>


