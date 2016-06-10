<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="KiemTraHangHoaDatHang.aspx.cs" Inherits="KiemTraHangHoaDatHang" Title="Untitled Page" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="contenedit">
                  <div class="center_box_content" align="center">
                    <p class="normal">
                    
                      <%
                     if (Session["admin"] != null)
                     { %>
                        &nbsp;</p>
                      <div>
                          <table style="width:100%;">
                              <tr>
                                  <td style="height: 16px; font-size: x-large; color: #FF6600;" colspan="7"
                            align=center>
                            <b>Quản lý Hàng hóa</b></td>
                              </tr>
                          </table>
                      </div>
                      <p class="normal">
                          &nbsp;</p>
                      <p class="normal" align="center">
                          <asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
                              AutoGenerateColumns="False" DataKeyNames="mavatlieu" 
                              DataSourceID="SqlDataSource3" BackColor="White" BorderColor="#CCCCCC" 
                              BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                              HorizontalAlign="Center" CellSpacing="3">
                              <RowStyle ForeColor="#000066" />
                              <Columns>
                                  <asp:BoundField DataField="mavatlieu" HeaderText="Mã vật liệu" 
                                      InsertVisible="False" ReadOnly="True" SortExpression="mavatlieu" />
                                  <asp:BoundField DataField="Loaivatlieu" HeaderText="Loại vật liệu" 
                                      SortExpression="Loaivatlieu" />
                                  <asp:BoundField DataField="gia" HeaderText="Giá" SortExpression="gia" />
                                  <asp:BoundField DataField="soluong" HeaderText="Số lượng" 
                                      SortExpression="soluong" />
                                  <asp:CommandField CancelText="Thoát" EditText="Sửa" ShowEditButton="True" 
                                      UpdateText="OK" />
                                  <asp:CommandField DeleteText="Xóa" ShowDeleteButton="True" />
                              </Columns>
                              <FooterStyle BackColor="White" ForeColor="#000066" />
                              <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                              <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                              <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                          </asp:GridView>
                      </p>
                      <p class="normal">
                          <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                              ConnectionString="<%$ ConnectionStrings:xaydung %>" 
                              DeleteCommand="DELETE FROM vatlieu WHERE mavatlieu=@mavatlieu" 
                              InsertCommand="INSERT INTO vatlieu(Loaivatlieu, gia, soluong) VALUES (@LoaiVatLieu,@gia,@soluong)" 
                              SelectCommand="SELECT vatlieu.* FROM vatlieu" 
                              UpdateCommand="UPDATE vatlieu SET Loaivatlieu =@Loaivatlieu, gia =@gia, soluong =@soluong WHERE mavatlieu=@Mavatlieu">
                              
                               <UpdateParameters>
                                <asp:Parameter Name="LoaiVatLieu" Type="string" />
                                <asp:Parameter Name="gia" Type="string" />
                                <asp:Parameter Name="soluong" Type="int32" />
                                
                               </UpdateParameters>
                               
                                <DeleteParameters>
                                <asp:Parameter Name="mavatlieu" Type="int32" />
                               
                              </DeleteParameters>
                              
                              <InsertParameters>
                                <asp:Parameter Name="LoaiVatLieu" Type="string" />
                                <asp:Parameter Name="gia" Type="string" />
                                <asp:Parameter Name="soluong" Type="int32" />
                              </InsertParameters>
                              
                              
                          </asp:SqlDataSource>
                      </p>
                      <p class="normal">
                          &nbsp;</p>
                      <div align="center">
                          <table style="width:50%;">
                              <tr align="center">
                                  <td style="width: 63px; height: 16px; background-color: #006699; color: #FFFFFF;" 
                            align=center>
                            <b>Loại vật liệu</b></td>
                                  <td style="width: 63px; height: 16px; background-color: #006699; color: #FFFFFF;" 
                            align=center>
                            <b>Giá</b></td>
                                  <td style="width: 63px; height: 16px; background-color: #006699; color: #FFFFFF;" 
                            align=center>
                            <b>Số lượng</b></td>
                              </tr>
                              <tr align="center">
                                  <td>
                                      <asp:TextBox ID="txtLVL" runat="server" Width="133px"></asp:TextBox>
                                  </td>
                                  <td>
                                      <asp:TextBox ID="txtG" runat="server" Width="113px"></asp:TextBox>
                                  </td>
                                  <td>
                                      <asp:TextBox ID="txtSL" runat="server" Width="104px"></asp:TextBox>
                                  </td>
                              </tr>
                              <tr align="center">
                                  <td colspan="3">
                                      <asp:Button ID="btnthem" runat="server" onclick="btnthem_Click" Text="Thêm " />
                                  </td>
                              </tr>
                          </table>
                      </div>
                      <p class="normal">
                          &nbsp;</p>
                      <p class="normal">
                          &nbsp;</p>
                      <hr noshade="noshade" />
                      <p class="normal">
                          &nbsp;</p>
                      <div>
                          <asp:Button ID="btnDatHang" runat="server" Font-Bold="True" ForeColor="#009900" 
                              Text="Đặt hàng" />
                      </div>
                      <p class="normal">
                          &nbsp;</p>
                    <%}
                     else
                         Response.Write("cam hack tinh lam gi day may"); %>
                  </div>
                  
</asp:Content>


