<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="QuangCao.aspx.cs" Inherits="QuangCao" Title="Untitled Page" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="contenedit">
                  <div class="center_box_content" align="center">
                   <div>
                     <%
                     if (Session["admin"] != null)
                     { %>
                    <p class="normal">
                        &nbsp;<div>
                          <table style="width:100%;" >
                          
                              <tr align="center">
                                  <td style="height: 16px; font-size: x-large; color: #FF6600;" colspan="7"
                            >
                            <b>Quản lý thông tin quảng cáo</td>
                              </tr>
                          </table>
                      </div>
                      <p class="normal">
                          &nbsp;</p>
                      <p class="normal">
                          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                              DataKeyNames="MaQuangCao" DataSourceID="SqlDataSource3" BackColor="White" 
                              BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                              CellSpacing="3" HorizontalAlign="Center">
                              <RowStyle ForeColor="#000066" />
                              <Columns>
                                  <asp:BoundField DataField="MaQuangCao" HeaderText="Mã quảng cáo" 
                                      InsertVisible="False" ReadOnly="True" SortExpression="MaQuangCao" >
                                      <ControlStyle Width="80px" />
                                      <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                                  </asp:BoundField>
                                  <asp:BoundField DataField="TenQuangCao" HeaderText="Tên quảng cáo" 
                                      SortExpression="TenQuangCao" >
                                      <ControlStyle Width="150px" />
                                      <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                  </asp:BoundField>
                                  <asp:BoundField DataField="MoTa" HeaderText="Mô tả" SortExpression="MoTa" >
                                      <ControlStyle Width="150px" />
                                      <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                  </asp:BoundField>
                                  <asp:BoundField DataField="HinhAnh" HeaderText="Hình ảnh" 
                                      SortExpression="HinhAnh" >
                                      <ControlStyle Width="100px" />
                                      <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                                  </asp:BoundField>
                                  <asp:CommandField CancelText="Thoát" EditText="Sửa" InsertText="Thêm" 
                                      ShowEditButton="True" UpdateText="OK" >
                                      <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                  </asp:CommandField>
                                  <asp:CommandField DeleteText="Xóa" ShowDeleteButton="True" >
                                      <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                  </asp:CommandField>
                              </Columns>
                              <FooterStyle BackColor="White" ForeColor="#000066" />
                              <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                              <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                              <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" 
                                  HorizontalAlign="Center" VerticalAlign="Middle" />
                          </asp:GridView>
                          <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                              ConnectionString="<%$ ConnectionStrings:xaydung %>" 
                              DeleteCommand="DELETE FROM QuangCao WHERE MaQuangCao=@MaQuangCao" 
                              InsertCommand="INSERT INTO QuangCao(TenQuangCao, MoTa, HinhAnh) VALUES (@TenQuangCao,@MoTa,@HinhAnh)" 
                              SelectCommand="SELECT [MaQuangCao], [TenQuangCao], [MoTa], [HinhAnh] FROM [QuangCao]" 
                              UpdateCommand="UPDATE QuangCao SET TenQuangCao = @TenQuangCao, MoTa = @MoTa, HinhAnh = @HinhAnh WHERE MaQuangCao=@MaQuangCao">
                              
                              <InsertParameters>
                                <asp:Parameter Name="TenQuangCao" Type="string" />
                                <asp:Parameter Name="MoTa" Type="string" />
                                <asp:Parameter Name="HinhAnh" Type="string" />
                              </InsertParameters>
                              
                              <UpdateParameters>
                                <asp:Parameter Name="TenQuangCao" Type="string" />
                                <asp:Parameter Name="MoTa" Type="string" />
                                <asp:Parameter Name="HinhAnh" Type="String" />
                               
                            </UpdateParameters>
                            
                             <DeleteParameters>
                                <asp:Parameter Name="MaQuangCao" Type="int32" />
                               
                              </DeleteParameters>
                              
                              
                              </asp:SqlDataSource>
                      </p>
                        <p class="normal" align="center">
                            &nbsp;</p>
                                            <p class="normal" align="center">
                                                &nbsp;</p>
                        <div align = "center">
                            <table style="width:70%;">
                                <tr align="center">
                                    <td style="width: 106px; color: #FFFFFF; height: 17px; background-color: #006699;">
                                      <b>Tên quảng cáo</b></td>
                                    <td style="width: 130px; color: #FFFFFF; height: 17px; background-color: #006699;">
                                      <b>Mô tả</b></td>
                                    <td style="width: 105px; color: #FFFFFF; height: 17px; background-color: #006699;">
                                      <b>Hình ảnh</b></td>
                                </tr>
                                
                                <tr><td class="style2">
                                    <asp:TextBox ID="txtTQC" runat="server" Width="99px"></asp:TextBox>
                                    </td>
                                
                                    <td style="width: 130px">
                                        <asp:TextBox ID="txtMT" runat="server" Width="146px"></asp:TextBox>
                                    </td>
                                
                                    <td>
                                        <asp:TextBox ID="txtHA" runat="server"></asp:TextBox>
                                    </td>
                                
                                </tr>
                                
                                <tr><td colspan="3" align="center">
                                    <asp:Button ID= "Button1" runat="server" Text="Thêm quảng cáo" 
                                        onclick="Button1_Click" />
                                    </td>
                                
                                </tr>
                            </table>
                              
                        </div>
                        <p class="normal" align="center">
                            &nbsp;</p>
                            <%}
                     else
                         Response.Write("cam hack tinh lam gi day may"); %>
                   </div>
                  </div>
                  
</asp:Content>


