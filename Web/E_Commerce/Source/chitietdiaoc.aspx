<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="chitietdiaoc.aspx.cs" Inherits="Default2" Title="Untitled Page" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="contenedit">
                  <div class="center_box_content">
                    <p class="normal">&nbsp;</p>
                    <p>
                    <div style="font-family: Arial; font-size: medium; color: #FFFFFF; background-color: #009900; font-weight: bold">
                        Mua Địa Óc</div>
                        <asp:ListView ID="ListView1" runat="server" DataKeyNames="MaDiaOc" 
                            DataSourceID="SqlDataSource3">
                            <ItemTemplate>
                                <tr style="">
                                    <td colspan="3">
                                        
                                        <asp:Image ID="cthinh" runat="server" Width="500" Height="400" ImageUrl='<%# Eval("Hinh") %>' />
                                    </td>
                                   
                                </tr>
                                <tr>
                                    <td>
                                        Giá:    <%# Eval("GiaCa") %>
                                    </td>
                                    <td>
                                        Ngày Đăng: <%#Eval("NgayDang") %>
                                    </td>
                                   
                                </tr>
                                 <tr>
                                    <td>
                                        Mô tả: <%#Eval("mota") %>
                                    </td>
                                    <td>
                                        Số ngừơi xem: <%#Eval("songuoixem") %>
                                    </td>
                                    <td>
                                  
                                        Tên Địa Óc:   <%#Eval("tendiaoc") %>
                                      
                                      
                                    </td>
                                </tr>
                                 <tr>
                                <td>
                                <% 
                                    Database db = new Database(); ;
                                    System.Data.DataTable Dt = new System.Data.DataTable();
                                    Dt = db.convertSQLToDatatable(SqlDataSource3);
                                   // int mauser = int.Parse(Dt.Rows[0]["MaLoaiuser"].ToString()); 
                                    int maloaidiaoc = 0;
                                   if (Request.QueryString["maloaidiaoc"] != null)
                                   {
                                       maloaidiaoc = int.Parse(Request.QueryString["maloaidiaoc"].ToString());
                                   }
                                   if (1 == 1)//nguoi dang tin la admin
                                   { %>
                                  <a href="MuaDiaOc.aspx?idgoi=1&&madiaoc=<%#Eval("madiaoc") %>" style="font-size: medium; font-weight: bold; color: #FF0000; background-color: #FFFFFF">
                                    Mua nhà theo gói 1 </a>  
                                  <%} %>
                                </td>
                                <td>
                                   
                              <%
                                 
                                 
                                //  int mauser=0;


                                // if (mauser == 1 && maloaidiaoc==1)//nguoi dang tin la admin
                                     if (maloaidiaoc == 1)
                                    {%>
                                   <a href="MuaDiaOc.aspx?idgoi=2&&madiaoc=<%#Eval("madiaoc") %>&&gia=<%#Eval("GiaCa") %>" style="font-size: medium; font-weight: bold; color: #FF0000; background-color: #FFFFFF">
                                    Mua nhà theo gói 2 </a>  
                                     <%} %>
                                </td>
                                <td>
                                
                                <%
                                    
                                  
                                //    if (maloaidiaoc == 2&& mauser==1)//dat do admin dang ban
                                    if (maloaidiaoc == 2 )
                                    {
                                     %>
                                    <a href="muadatcatnha.aspx?idgoi=3&&madiaoc=<%#Eval("madiaoc") %>" style="font-size: medium; font-weight: bold; color: #FF0000; background-color: #FFFFFF">
                                    Mua nhà theo gói 3 </a>  
                                    <%} %>
                                </td>
                            </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr style="">
                                    <td colspan="3">
                                        <asp:Image ID="cthinh" runat="server" Width="500" Height="400" ImageUrl='<%# Eval("Hinh") %>' />
                                    </td>
                                    
                                </tr>
                            </AlternatingItemTemplate>
                            <EmptyDataTemplate>
                                <table runat="server" style="">
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
                                        <asp:TextBox ID="HinhTextBox" runat="server" Text='<%# Bind("Hinh") %>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="MoTaTextBox" runat="server" Text='<%# Bind("MoTa") %>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="SoNguoiXemTextBox" runat="server" 
                                            Text='<%# Bind("SoNguoiXem") %>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="MaLoaiDiaOcTextBox" runat="server" 
                                            Text='<%# Bind("MaLoaiDiaOc") %>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="MaTinRaoTextBox" runat="server" 
                                            Text='<%# Bind("MaTinRao") %>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="GiaCaTextBox" runat="server" Text='<%# Bind("GiaCa") %>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="NoiDangTextBox" runat="server" Text='<%# Bind("NoiDang") %>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="NgayDangTextBox" runat="server" 
                                            Text='<%# Bind("NgayDang") %>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TenDiaOcTextBox" runat="server" 
                                            Text='<%# Bind("TenDiaOc") %>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="MaViTriTextBox" runat="server" Text='<%# Bind("MaViTri") %>' />
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </InsertItemTemplate>
                            <LayoutTemplate>
                                <table runat="server">
                                    <tr runat="server">
                                        <td runat="server">
                                            <table ID="itemPlaceholderContainer" runat="server" border="0" style="">
                                               
                                                <tr ID="itemPlaceholder" runat="server">
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr runat="server">
                                        <td runat="server" style="">
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
                                    <td>
                                        <asp:TextBox ID="HinhTextBox" runat="server" Text='<%# Bind("Hinh") %>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="MoTaTextBox" runat="server" Text='<%# Bind("MoTa") %>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="SoNguoiXemTextBox" runat="server" 
                                            Text='<%# Bind("SoNguoiXem") %>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="MaLoaiDiaOcTextBox" runat="server" 
                                            Text='<%# Bind("MaLoaiDiaOc") %>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="MaTinRaoTextBox" runat="server" 
                                            Text='<%# Bind("MaTinRao") %>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="GiaCaTextBox" runat="server" Text='<%# Bind("GiaCa") %>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="NoiDangTextBox" runat="server" Text='<%# Bind("NoiDang") %>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="NgayDangTextBox" runat="server" 
                                            Text='<%# Bind("NgayDang") %>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TenDiaOcTextBox" runat="server" 
                                            Text='<%# Bind("TenDiaOc") %>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="MaViTriTextBox" runat="server" Text='<%# Bind("MaViTri") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="MaDiaOcLabel1" runat="server" Text='<%# Eval("MaDiaOc") %>' />
                                    </td>
                                </tr>
                            </EditItemTemplate>
                            <SelectedItemTemplate>
                                <tr style="">
                                    <td>
                                        <asp:Label ID="HinhLabel" runat="server" Text='<%# Eval("Hinh") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="MoTaLabel" runat="server" Text='<%# Eval("MoTa") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="SoNguoiXemLabel" runat="server" 
                                            Text='<%# Eval("SoNguoiXem") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="MaLoaiDiaOcLabel" runat="server" 
                                            Text='<%# Eval("MaLoaiDiaOc") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="MaTinRaoLabel" runat="server" Text='<%# Eval("MaTinRao") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="GiaCaLabel" runat="server" Text='<%# Eval("GiaCa") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="NoiDangLabel" runat="server" Text='<%# Eval("NoiDang") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="NgayDangLabel" runat="server" Text='<%# Eval("NgayDang") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="TenDiaOcLabel" runat="server" Text='<%# Eval("TenDiaOc") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="MaViTriLabel" runat="server" Text='<%# Eval("MaViTri") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="MaDiaOcLabel" runat="server" Text='<%# Eval("MaDiaOc") %>' />
                                    </td>
                                </tr>
                            </SelectedItemTemplate>
                       
                       
                        </asp:ListView>
                        
                         <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:xaydung %>" 
                                
                          
                          SelectCommand="SELECT * FROM [diaoctheovitri] WHERE ([MaDiaOc] = @MaDiaOc)">
                                
                                <SelectParameters>
                                    <asp:QueryStringParameter Name="MaDiaOc" 
                                        QueryStringField="madiaoc" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                       
                        
                      </p>
                  </div>
                  
</asp:Content>


