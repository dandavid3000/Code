<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="tintheoloai.aspx.cs" Inherits="tintheoloai" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenedit" Runat="Server">
 <div class="center_box_content">
                  
          <% int idloaitin =int.Parse( Request.QueryString["idloaitin"]); 
              switch(idloaitin)
              {
                  case 1:
                  {
                      Response.Write("<h2>");
                      Response.Write("Loại tin:");
                      Response.Write(idloaitin.ToString());
                      Response.Write("</h2>");
                  }
                  break;
                      
              }
              %>
          
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                          ConnectionString="<%$ ConnectionStrings:xaydung %>" 
                          
                          
                          
                          
                          
                          SelectCommand="SELECT * FROM [chitiettin] WHERE ([MaLoaiTin] = @MaLoaiTin) ">
    <SelectParameters>
        <asp:QueryStringParameter Name="MaLoaiTin" QueryStringField="idloaitin" 
            Type="Int32" DefaultValue="1" />
       
    </SelectParameters>
                      </asp:SqlDataSource>
                   <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1" >
                          <ItemTemplate >
                          
                              <tr>
                                                                    
                                  <td width="100">
                                     <asp:Label ID="tenloaitinLabel" runat="server" Text='<%# Eval("tieudetin") %>' Height="250" />
                                  </td>
                                  <td width ="150">
                                      <asp:Label ID="motaLabel" runat="server" Text='<%# Eval("mota") %>' Height="250" /><br />
                                      
                                  </td>
                                  
                              </tr>
                            
                          </ItemTemplate>
                          
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
                                  
                                
                              </tr>
                          </InsertItemTemplate>
                          <LayoutTemplate>
                              <table id="Table2" runat="server" >
                                  <tr id="Tr1" runat="server">
                                      <td id="Td1" runat="server">
                                          <table ID="itemPlaceholderContainer" runat="server" border="0" style="" width="100%">
                                              <tr id="Tr2" runat="server" style="background-color: #009900; font-family: Arial; font-size: medium; font-weight: bold; color: #FFFFFF;">
                                                  
                                                  
                                                  <th id="Th1" runat="server" width="150" align="center">
                                                      Tiêu đề tin</th>
                                                  <th id="Th2" runat="server" width="350"  align="center" >
                                                      Mô tả</th>
                                                 
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
                                 
                               
                              </tr>
                          </EditItemTemplate>
                        
                      </asp:ListView>
                  </div>
</asp:Content>

