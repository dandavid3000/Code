<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="quanlyuser.aspx.cs" Inherits="quanlyuser" Title="Untitled Page" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="contenedit">
                  <div class="center_box_content" align="center">
                    <p class="normal">
                   <%
                     if (Session["admin"] != null)
                     { %>
             
                    <table width="400px" id="user" >
                    <tr>
                    <td width="400px">
                        <div align="center"><table style="width:100%;">
                          
                              <tr align="center">
                                  <td style="height: 16px; font-size: x-large; color: #FF6600;" colspan="7"
                            >
                            <b>Quản lý tài khoản người dùng</td>
                              </tr>
                          </table>
                        </div>
                      <p class="normal">
                          &nbsp;</p>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                            DataKeyNames="MaUser" DataSourceID="SqlDataSource3" Height="153px" 
                            Width="387px" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" 
                            BorderStyle="None" BorderWidth="1px" 
                            onselectedindexchanged="GridView1_SelectedIndexChanged">
                          
                            <RowStyle ForeColor="#000066" />
                          
                            <Columns>
                                <asp:BoundField DataField="username" HeaderText="Tên" 
                                    SortExpression="username" >
                                    <ControlStyle Font-Size="Smaller" Width="50px" />
                                    <ItemStyle Width="70px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MaUser" HeaderText="Mã" InsertVisible="False" 
                                    SortExpression="MaUser" >
                                    <ControlStyle Width="30px" Font-Size="Smaller" />
                                    <ItemStyle Width="30px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="password" HeaderText="Mật khẩu" 
                                    SortExpression="password" >
                                    <ControlStyle Width="50px" Font-Size="Smaller" />
                                    <ItemStyle Width="50px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MaLoaiUser" HeaderText="Mã loại" 
                                    SortExpression="MaLoaiUser" >
                                    <ControlStyle Width="20px" Font-Size="Smaller" />
                                    <ItemStyle Width="25px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" >
                                    <ControlStyle Width="80px" Font-Size="Smaller" />
                                    <ItemStyle Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DiaChi" HeaderText="Địa chỉ" 
                                    SortExpression="DiaChi" >
                                    <ControlStyle Width="70px" Font-Size="Smaller" />
                                    <FooterStyle HorizontalAlign="Center" />
                                    <HeaderStyle Font-Size="Smaller" HorizontalAlign="Center" />
                                    <ItemStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DienThoai" HeaderText="Điện thoại" 
                                    SortExpression="DienThoai" >
                                    <ControlStyle Width="50px" Font-Size="Smaller" />
                                    <ItemStyle Width="70px" />
                                </asp:BoundField>
                                <asp:CommandField ShowEditButton="True" CancelText="Thoát" 
                                    DeleteText="Xóa" EditText="Sửa" InsertText="Thêm" UpdateText="OK" >
                                    <ControlStyle Width="70px" Font-Size="Smaller" ForeColor="Maroon" />
                                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                    <ItemStyle Width="70px" ForeColor="Maroon" />
                                </asp:CommandField>
                                <asp:CommandField ShowDeleteButton="True" 
                                    CancelText="Thoát" DeleteText="Xóa" EditText="Chấp nhận" InsertText="Thêm" 
                                    NewText="Mới" SelectText="Chọn" UpdateText="Cập nhật" >
                                    <ControlStyle Width="40px" Font-Size="Smaller" ForeColor="Maroon" />
                                    <ItemStyle Width="40px" ForeColor="Maroon" />
                                </asp:CommandField>
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                    </td>
                        
                        </tr>
                        </table>
                   
                      </p>
                      <p class="normal">
                        <%}
                     else
                         Response.Write("cam hack tinh lam gi day may"); %>
                         
                        </p>
                      <p class="normal">
                          &nbsp;</p>
                      <p class="normal">
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:xaydung %>" 
                            
                            SelectCommand="SELECT [username], [MaUser], [password], [MaLoaiUser], [Email], [DiaChi], [DienThoai] FROM [username]" 
                            
                              UpdateCommand="UPDATE username SET username =@username, password =@password, MaLoaiUser =@MaloaiUser, Email =@Email, DienThoai =@DienThoai, DiaChi =@DiaChi where Mauser=@mauser" 
                              InsertCommand="INSERT INTO username(MaUser, username, password, MaLoaiUser, Email, DienThoai, DiaChi) VALUES (@mauser,@password,@maloaiuser,@email,@dienthoai,@diachi)" 
                              DeleteCommand="DELETE FROM username where MaUser=@MaUser">
                              <DeleteParameters>
                                <asp:Parameter Name="MaUser" Type="int32" />
                               
                              </DeleteParameters>
                                
                              <InsertParameters>
                                <asp:Parameter Name="mauser" Type="int32" />
                                <asp:Parameter Name="password" Type="string" />
                                <asp:Parameter Name="MaloaiUser" Type="Int32" />
                                <asp:Parameter Name="Email" Type="String" />
                                <asp:Parameter Name="DienThoai" Type="string" />
                                <asp:Parameter Name="DiaChi" Type="string" />
                              </InsertParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="username" Type="string" />
                                <asp:Parameter Name="password" Type="string" />
                                <asp:Parameter Name="MaloaiUser" Type="int32" />
                                <asp:Parameter Name="Email" Type="string" />
                                <asp:Parameter Name="DienThoai" Type="string" />
                                <asp:Parameter Name="DiaChi" Type="string" />
                                <asp:Parameter Name="mauser" Type="int32" />
                            </UpdateParameters>
                           
                           
                        </asp:SqlDataSource>
                      </p>
                   
                  </div>
                  
                 
                 
                  <%
                     if (Session["admin"] != null)
                     { %>
                     
                  <div class="center_box_content">
                   <table style="width: 100%;">
                    <tr>
                        <td style="height: 16px; font-size: x-large; color: #FF6600;" colspan="7"
                            align=center>
                            <b>Thêm tài khoản mới</b></td>
                    </tr>
                    <tr>
                        <td style="width: 63px; height: 16px; background-color: #336699; color: #FFFFFF;" 
                            align=center>
                            <b>&nbsp; Tên </b>    
                        <td style="width: 50px; height: 16px; background-color: #336699;"align=center>
                            <span style="color: #FFFFFF; font-weight: bold;">Mã</td>
                        <td style="width: 57px; height: 16px; background-color: #336699;"align=center>
                            <span style="color: #FFFFFF; font-weight: bold;">Mật khẩu</td>
                        <td style="width: 51px; height: 16px; background-color: #336699;"align=center>
                            <span style="color: #FFFFFF"><b>Mã loại</b></td>
                        <td style="width: 54px; height: 16px; background-color: #336699;"align=center>
                            <span style="color: #FFFFFF"><b>Email</b></td>
                        <td style="width: 51px; height: 16px; background-color: #336699;"align=center>
                            <span style="color: #FFFFFF"><b>Địa chỉ</b></td>
                        <td style="width: 55px; height: 16px; background-color: #336699;"align=center>
                            <span style="color: #FFFFFF"><b>Điện thoại</b></td>
                    </tr>
                    <tr>
                        <td style="width: 63px">
                            <asp:TextBox ID="txtmauser" runat="server" Width="62px"></asp:TextBox>
                        </td>
                        <td style="width: 50px">
                            <asp:TextBox ID="txtusername" runat="server" Width="55px"></asp:TextBox>
                        </td>
                        <td style="width: 57px">
                            <asp:TextBox ID="txtpassword" runat="server" Width="61px"></asp:TextBox>
                        </td>
                        <td style="width: 51px">
                            <asp:TextBox ID="TextBox5" runat="server" Width="56px"></asp:TextBox>
                        </td>
                        <td style="width: 54px">
                            <asp:TextBox ID="TextBox6" runat="server" Width="61px"></asp:TextBox>
                        </td>
                        <td style="width: 51px">
                            <asp:TextBox ID="TextBox7" runat="server" Width="72px"></asp:TextBox>
                        </td>
                        <td style="width: 55px">
                            <asp:TextBox ID="TextBox8" runat="server" Width="63px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr align="center">
                        <td colspan="7">
                            <asp:Button ID="Button1" runat="server" Text="Thêm" Width="72px" 
                                onclick="Button1_Click" />
                        </td>
                    </tr>
                    </table>
                  </div>
                  
                      <%}
                     else
                         Response.Write("cam hack tinh lam gi day may"); %>
                        </p>
</asp:Content>



