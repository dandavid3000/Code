<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="chitietdangky.aspx.cs" Inherits="chitietdangky" Title="Untitled Page" %>



<asp:Content ID="Content1" runat="server" contentplaceholderid="contenedit">
    <%if (Session["login"] != null)
  { %>
                  <div class="center_box_content">
                   
                   <% 
    int idloaidiaoc = 0;
    if (Request.QueryString["id"] != null)
    {
        idloaidiaoc = int.Parse(Request.QueryString["id"]);
    }
                       %>
                     <center> 
                      <table id="BaoHet" >
                       <tr >
                       <td >
                         <table width="300">
                              <tr>
                                   <td style="font-family: Arial; font-size: medium; background-color: #009933; color: #FFFFFF; font-weight: bold;" 
                                      colspan="2" width="200">
                                       Thông Tin Chung
                                    </td>
                             </tr>
                             <tr>
                                     <td>Loại Tin Rao</td>
                                    <td style="height: 16px">
                                           <asp:DropDownList ID="Drloaitinrao" runat="server" 
                                               DataSourceID="SqlDataSource3" DataTextField="TenLoaiTinRao" 
                                               DataValueField="MaLoaiTinRao">
                                                </asp:DropDownList> 
                                     </td>
                              
                             </tr>
                             <tr>
                                <td>Tiêu đề</td>
                                 <td>
                                      <asp:TextBox ID="txttieude" runat="server"></asp:TextBox>  
                                 </td>
                             </tr>
                             <tr>
                                    <td>Địa Chỉ</td>
                                     <td>
                                        <asp:TextBox ID="txtdiachi" runat="server"></asp:TextBox>  
                                     </td>
                             </tr>
                            <tr>
                                 <td>Giá</td>
                                  <td>
                                     <asp:TextBox ID="txtgia" runat="server"></asp:TextBox>  
                                 </td>
                            </tr>
                            <tr>
                                <td> Giá Cho thuê</td>
                                 <td>
                                     <asp:TextBox ID="txtgiachothue" runat="server"></asp:TextBox>  
                                 </td>
                            </tr>
                     <tr>
                     <td style="height: 22px">Ngày Đăng tin</td>
                        <td style="height: 22px">
                            <asp:TextBox ID="txtngaydangtin" runat="server"></asp:TextBox>   
                        </td>
                     </tr>
                     <tr>
                     <td> Ngày hết hạn</td>
                        <td>
                           <asp:TextBox ID="txtngayhethan" runat="server"></asp:TextBox>  
                        </td>
                     </tr>
                      <tr>
                     <td> Hình</td>
                        <td>
                           <asp:TextBox ID="txthinh" runat="server"></asp:TextBox>  
                        </td>
                     </tr>
                        <tr>
                     <td> Vị Trí</td>
                        <td>
                           <asp:DropDownList runat="server" DataSourceID="SqlDataSource6" 
                                DataTextField="TenViTri" DataValueField="MaViTri" ID="drmavitri"></asp:DropDownList> 
                            <asp:SqlDataSource ID="SqlDataSource6" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:xaydung %>" 
                                SelectCommand="SELECT * FROM [vitri]"></asp:SqlDataSource>
                        </td>
                     </tr>
                     
                   </table>
                   </td>
                  
                   
                   
                   </tr>
                   <tr >
                   <td >
                  
                    <table id="phanrieng"width="300">
                   <tr>
                        <td style="font-family: Arial; font-size: medium; background-color: #009933; color: #FFFFFF; font-weight: bold;" 
                            colspan="2" width="300">
                             Phần Riêng<%
    if (idloaidiaoc == 1)
    {
        Response.Write("Nhà");
    }
    else if (idloaidiaoc == 2)
        Response.Write("Đất");
    else if (idloaidiaoc == 3)
        Response.Write("Căn Hộ");
    else
        Response.Write("Loai Địa ốc khác");%>
                        </td>
                     </tr>
                     <% if (idloaidiaoc == 1)//nhà
                        { %>
                     <tr>
                     <td style="width: 98px" class="style2">Loại Địa ốc Nhà</td>
                        <td style="height: 16px">
                                           
                                     
                             <asp:DropDownList ID="Drloaidiaocnha" runat="server" 
                                               DataSourceID="SqlDataSource5" DataTextField="TenLoaiDiaOcNha" 
                                               DataValueField="MaLoaiDiaOcNha">
                                                </asp:DropDownList>           
                        </td>
                     </tr>
                      <tr>
                      <td style="width: 98px" class="style2">Tình trạng pháp lý</td>
                        <td>
                            <asp:TextBox ID="txtTinhtrangphaply" runat="server"></asp:TextBox>  
                        </td>
                     </tr>
                      <tr>
                      <td style="width: 98px" class="style2">Đặc Điểm khác</td>
                        <td>
                            <asp:TextBox ID="txtddkhac" runat="server"></asp:TextBox>  
                        </td>
                     </tr>
                     <%} %>
                      <% if (idloaidiaoc == 2)//dat
                         { %>
                     <tr>
                     <td style="width: 98px" class="style2">Loại Đất</td>
                        <td style="height: 16px">
                             <asp:DropDownList ID="DrLoaidat" runat="server" 
                                               DataSourceID="SqlDataSource4" DataTextField="TenLoaiDat" 
                                               DataValueField="MaLoaiDat">
                                                </asp:DropDownList>&nbsp;</td>
                     </tr>
                      <tr>
                      <td style="width: 98px" class="style2">Diện Tích khuôn viên</td>
                        <td>
                            <asp:TextBox ID="txtDientichkhuonvien" runat="server"></asp:TextBox>  
                        </td>
                     </tr>
                      <tr>
                      <td style="width: 98px" class="style2">Diện Tích khu vực</td>
                        <td>
                            <asp:TextBox ID="txtdientichkhuvuc" runat="server"> </asp:TextBox>  
                        </td>
                     </tr>
                      <tr>
                      <td style="width: 98px" class="style2"> Hướng </td>
                        <td>
                            <asp:TextBox ID="txtHuong" runat="server"></asp:TextBox>  
                        </td>
                     </tr>
                      <tr>
                      <td style="width: 98px" class="style2"> Thông Tin liên hệ </td>
                        <td>
                            <asp:TextBox ID="txtthongtinlienhe" runat="server"></asp:TextBox>  
                        </td>
                     </tr>
                     <td style="width: 98px" class="style2"> Đặc Điểm khác </td>
                        <td>
                           <asp:TextBox ID="txtdacdiemdat" runat="server"></asp:TextBox>  
                        </td>
                     </tr>
                     <%} %>
                     <tr>
                         <td colspan="2" align="center">
                             <asp:Button ID="Button1" runat="server" Text="Đăng Ký" Width="121px" 
                                 onclick="Button1_Click" />
                         </td>
                         
                        
                     </tr>
                   </table>
                    </td>
                   </tr>
                          <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                              ConnectionString="<%$ ConnectionStrings:xaydung %>" 
                              SelectCommand="SELECT [MaLoaiTinRao], [TenLoaiTinRao] FROM [LoaiTinRao]">
                          </asp:SqlDataSource>
                          <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
                              ConnectionString="<%$ ConnectionStrings:xaydung %>" 
                              SelectCommand="SELECT [MaLoaiDiaOcNha], [TenLoaiDiaOcNha] FROM [LoaiDiaOcNha]">
                          </asp:SqlDataSource>
                          <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                              ConnectionString="<%$ ConnectionStrings:xaydung %>" 
                              SelectCommand="SELECT [MaLoaiDat], [TenLoaiDat] FROM [LoaiDat]">
                          </asp:SqlDataSource>
                    </table>
                    </center>
                  </div>
 <%}
  else
      Response.Write("Chỉ dành cho user đăng nhập"); %> 
</asp:Content>


