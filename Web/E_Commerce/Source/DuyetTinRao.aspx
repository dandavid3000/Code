<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DuyetTinRao.aspx.cs" Inherits="DuyetTinRao" Title="Untitled Page" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="contenedit">
                  <div class="center_box_content" align="center">
                    <p class="normal">
                    
                      <%
                     if (Session["admin"] != null)
                     { %>
             
                                     </p>
                      <div>
                          <table style="width:100%;">
                              <tr>
                                  <td style="height: 16px; font-size: x-large; color: #FF6600;" colspan="7"
                            align=center>
                            <b>Duyệt tin rao</b></td>
                              </tr>
                          </table>
                      </div>
                      <p class="normal">
                    
                          &nbsp;</p>
                      <p class="normal">
                    
                                     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                            DataKeyNames="MaTinRao" DataSourceID="SqlDataSource3" Width="288px" 
                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                            CellPadding="3" onselectedindexchanged="GridView1_SelectedIndexChanged">
                            <RowStyle ForeColor="#000066" />
                            <Columns>
                                <asp:BoundField DataField="MaTinRao" HeaderText="Mã tin rao" 
                                    InsertVisible="False" ReadOnly="True" SortExpression="MaTinRao">
                                    <ControlStyle Width="30px" />
                                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Width="30px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MaUser" HeaderText="Mã user" InsertVisible="False" ReadOnly="True"  SortExpression="MaUser">
                                    <ControlStyle Width="30px" />
                                    
                                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    
                                    <ItemStyle Width="30px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    
                                </asp:BoundField>
                                <asp:BoundField DataField="MaLoaiDiaOc" HeaderText="Mã loại địa ốc " InsertVisible="False" ReadOnly="True" 
                                    SortExpression="MaLoaiDiaOc">
                                    <ControlStyle Width="30px" />
                                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Width="30px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MaLoaiTinRao" HeaderText="Mã loại tin rao" InsertVisible="False" ReadOnly="True" 
                                    SortExpression="MaLoaiTinRao">
                                    <ControlStyle Width="30px" />
                                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Width="30px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TieuDe" HeaderText="Tiêu đề" InsertVisible="False" ReadOnly="True" SortExpression="TieuDe">
                                    <ControlStyle Width="120px" />
                                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Width="120px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DiaChi" HeaderText="Địa chỉ" InsertVisible="False" ReadOnly="True" SortExpression="DiaChi">
                                    <ControlStyle Width="100px" />
                                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Width="100px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Gia" HeaderText="Giá" InsertVisible="False" ReadOnly="True" SortExpression="Gia">
                                    <ControlStyle Width="80px" />
                                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Width="80px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NgayHetHan" HeaderText="Ngày hết hạn" InsertVisible="False" ReadOnly="True" 
                                    SortExpression="NgayHetHan">
                                    <ControlStyle Width="50px" />
                                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Width="50px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Hinh" HeaderText="Hình" InsertVisible="False" ReadOnly="True" 
                                    SortExpression="Hinh">
                                    <ControlStyle Width="40px" />
                                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Width="40px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TrangThaiTinRao" HeaderText="Trạng thái tin rao" 
                                    SortExpression="TrangThaiTinRao" >
                                    <ControlStyle Width="30px" />
                                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Width="30px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:CommandField DeleteText="Xóa" EditText="Sửa" InsertText="Thêm" 
                                    ShowEditButton="True" UpdateText="OK" CancelText="Thoát" >
                                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:CommandField>
                                <asp:CommandField DeleteText="Xóa" ShowDeleteButton="True" />
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                      </p>
                      <p class="normal">
                      
                       <%}
                     else
                         Response.Write("cam hack tinh lam gi day may"); %>
                         
                          <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                              ConnectionString="<%$ ConnectionStrings:xaydung %>" 
                              
                              
                              SelectCommand="SELECT MaTinRao, MaUser, MaLoaiDiaOc, MaLoaiTinRao, TieuDe, DiaChi, Gia, NgayHetHan, Hinh, TrangThaiTinRao FROM tinrao" 
                              
                              UpdateCommand="UPDATE tinrao SET TrangThaiTinRao = @TrangThaiTinRao where MaTinRao=@MaTinRao" 
                              
                              InsertCommand="INSERT INTO tinrao(MaUser, MaLoaiDiaOc, MaLoaiTinRao, TieuDe, DiaChi, Gia, NgayHetHan, Hinh, TrangThaiTinRao) VALUES (1,@MaLoaiDiaOc,@MaLoaiTinRao,@TieuDe,@DiaChi,@Gia,@NgayHetHan,@Hinh,1)" 
                              DeleteCommand="DELETE FROM tinrao WHERE MaTinRao=@MaTinRao">
                              
                               <UpdateParameters>
                                <asp:Parameter Name="TrangThaiTinRao" Type="int32" />
                                
                                   <asp:Parameter Name="MaTinRao" />
                               </UpdateParameters>
                               
                                <DeleteParameters>
                                <asp:Parameter Name="MaTinRao" Type="int32" />
                               
                              </DeleteParameters>
                               
                               <InsertParameters>
                                <asp:Parameter Name="MaLoaiDiaOc" Type="int32" />
                                <asp:Parameter Name="MaLoaiTinRao" Type="Int32" />
                                <asp:Parameter Name="TieuDe" Type="String" />
                                <asp:Parameter Name="DiaChi" Type="string" />
                                <asp:Parameter Name="Gia" Type="int32" />
                                <asp:Parameter Name="NgayHetHan" Type="string" />
                                <asp:Parameter Name="Hinh" Type="string" />
                              </InsertParameters>
                              
                              </asp:SqlDataSource>
                          <br />
                      </p>
                      <hr />
                      <p class="normal">
                      
                          <br />
                          
                          
                  <%
                     if (Session["admin"] != null)
                     { %>
                   <table style="width: 100%;">
                    <tr>
                        <td style="height: 16px; font-size: x-large; color: #FF6600;" colspan="7"
                            align=center>
                            <b>Đăng tin địa ốc của công ty</b></td>
                    </tr>
                    <tr>
                        <td style="width: 63px; height: 16px; background-color: #006699; color: #FFFFFF;" 
                            align=center>
                            <b>Mã loại địa ốc</b><td 
                            style="width: 50px; height: 16px; background-color: #006699;"align=center>
                            <span style="color: #FFFFFF; font-weight: bold;">Mã loại tin rao</td>
                        <td style="width: 57px; height: 16px; background-color: #006699;"align=center>
                            <span style="color: #FFFFFF; font-weight: bold;">Tiêu đề</td>
                        <td style="width: 57px; height: 16px; background-color: #006699;"align=center>
                            <span style="color: #FFFFFF; font-weight: bold;">Địa chỉ</td>
                        <td style="width: 57px; height: 16px; background-color: #006699;"align=center>
                           <span style="color: #FFFFFF; font-weight: bold;"> Giá</td>
                        <td style="width: 57px; height: 16px; background-color: #006699;"align=center>
                           <span style="color: #FFFFFF; font-weight: bold;">&nbsp; Ngày hết<br />
                            &nbsp;&nbsp; hạn</td>
                        <td style="width: 57px; height: 16px; background-color: #006699;"align=center>
                            <span style="color: #FFFFFF"><b>Hình</span></span></b></span></td>
                    </tr>
                    <tr>
                        <td style="width: 63px">
                            <asp:TextBox ID="txtMLDO" runat="server" Width="60px"></asp:TextBox>
                        </td>
                        <td style="width: 50px">
                            <asp:TextBox ID="txtMLTR" runat="server" Width="51px"></asp:TextBox>
                        </td>
                        <td style="width: 57px">
                            <asp:TextBox ID="txtTD" runat="server" Width="59px"></asp:TextBox>
                        </td>
                        <td style="width: 51px">
                            <asp:TextBox ID="txtDC" runat="server" Width="73px"></asp:TextBox>
                        </td>
                        <td style="width: 54px">
                            <asp:TextBox ID="txtG" runat="server" Width="61px"></asp:TextBox>
                        </td>
                        <td style="width: 51px">
                            <asp:TextBox ID="txtNHH" runat="server" Width="81px"></asp:TextBox>
                        </td>
                        <td style="width: 55px">
                            <asp:TextBox ID="txtH" runat="server" Width="67px" 
                                ontextchanged="txtH_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 63px">
                            &nbsp;</td>
                        <td style="width: 50px">
                            &nbsp;</td>
                        <td style="width: 57px">
                            &nbsp;</td>
                        <td style="width: 51px">
                            <asp:Button ID="Button1" runat="server" Text="Thêm" Width="72px" 
                                onclick="Button1_Click" />
                        </td>
                        <td style="width: 54px">
                            &nbsp;</td>
                        <td style="width: 51px">
                            &nbsp;</td>
                        <td style="width: 55px">
                            &nbsp;</td>
                    </tr>
                    </table>
                      </p>
                     <%}
                     else
                         Response.Write("cam hack tinh lam gi day may"); %>
                  </div>
                  
</asp:Content>


