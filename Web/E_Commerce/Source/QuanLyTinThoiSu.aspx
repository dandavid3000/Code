<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="QuanLyTinThoiSu.aspx.cs" Inherits="QuanLyTinThoiSu" Title="Untitled Page" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="contenedit">
                  <div class="center_box_content" align="center">
                       <%
                     if (Session["admin"] != null)
                     { %> <div>
                      
                          <table style="width:100%;">
                          
                              <tr>
                                  <td style="height: 16px; font-size: x-large; color: #FF6600;" colspan="7"
                            align=center>
                            <b>Quản lý chi tiết tin tức thời sự</td>
                              </tr>
                          </table>
                      </div>
                    <p class="normal">
                        &nbsp;</p>
                      <p class="normal">
                    
                          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                              BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="3px" 
                              CellPadding="3" CellSpacing="3" DataKeyNames="MaTin" 
                              DataSourceID="SqlDataSource3" align="Center" HorizontalAlign="Center" 
                              meta:resourcekey="GridView1Resource1">
                              <RowStyle ForeColor="#000066" HorizontalAlign="Right" VerticalAlign="Middle" />
                              <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                              <Columns>
                                  <asp:BoundField DataField="MaTin" HeaderText="Mã tin" InsertVisible="False" 
                                      ReadOnly="True" SortExpression="MaTin" 
                                      meta:resourcekey="BoundFieldResource3" >
                                      
                                     
                                      
                                      <ControlStyle Width="40px" />
                                      
                                     
                                      
                                      <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                      <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                      <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40px"  />
                                  </asp:BoundField>
                                  <asp:BoundField DataField="MaLoaiTin" HeaderText="Mã loại tin" 
                                      SortExpression="MaLoaiTin" meta:resourcekey="BoundFieldResource4" >
                                     
                                      <ControlStyle Width="40px" />
                                     
                                      <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                      <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                      <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40px" />
                                  </asp:BoundField>
                                  <asp:BoundField DataField="TieuDeTin" HeaderText="Tiêu đề tin" 
                                      SortExpression="TieuDeTin" meta:resourcekey="BoundFieldResource5" >
                                      
                                      <ControlStyle Width="160px" />
                                      
                                      <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                      <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                      <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="160px" />
                                  </asp:BoundField>
                                  <asp:BoundField DataField="MoTa" HeaderText="Mô tả" SortExpression="MoTa" 
                                      meta:resourcekey="BoundFieldResource6" >
                                      
                                      <ControlStyle Width="160px" />
                                      
                                      <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                      <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                      <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="160px" />
                                  </asp:BoundField>
                                  <asp:CommandField CancelText="Thoát" DeleteText="Xóa" EditText="Sửa" 
                                      InsertText="Thêm" ShowEditButton="True" UpdateText="OK" 
                                      meta:resourcekey="CommandFieldResource3" >
                                     
                                      <ControlStyle ForeColor="#990000" Width="35px" />
                                      <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="#990000" 
                                          Width="35px" />
                                  </asp:CommandField>
                                  <asp:CommandField CancelText="Thoát" DeleteText="Xóa" ShowDeleteButton="True" 
                                      UpdateText="OK" meta:resourcekey="CommandFieldResource4" >
                                      
                                      <ControlStyle ForeColor="#990000" Width="35px" />
                                      
                                      <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                      <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="#990000" 
                                          Width="35px" />
                                  </asp:CommandField>
                              </Columns>
                              <FooterStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" 
                                  VerticalAlign="Middle" />
                              <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" 
                                  VerticalAlign="Middle" />
                              <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                              <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" 
                                  HorizontalAlign="Center" VerticalAlign="Middle" />
                              <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                          </asp:GridView>
                          
                          
                          
                          <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                              ConnectionString="<%$ ConnectionStrings:xaydung %>" 
                              SelectCommand="SELECT [MaTin], [MaLoaiTin], [TieuDeTin], [MoTa] FROM [chitiettin]" 
                              
                              UpdateCommand="UPDATE chitiettin SET TieuDeTin =@TieuDeTin, MoTa =@MoTa, MaLoaiTin =@MaLoaiTin WHERE MaTin=@MaTin" 
                              DeleteCommand="DELETE FROM chitiettin WHERE MaTin=@MaTin" 
                              InsertCommand="INSERT INTO chitiettin(MaLoaiTin, TieuDeTin, MoTa) VALUES (@MaLoaiTin,@TieuDeTin,@MoTa)">
                              <InsertParameters>
                                <asp:Parameter Name="MaLoaiTin" Type="int32" />
                                <asp:Parameter Name="TieuDeTin" Type="string" />
                                <asp:Parameter Name="MoTa" Type="String" />
                              </InsertParameters>
                             
                              <DeleteParameters>
                                <asp:Parameter Name="MaTin" Type="int32" />
                               
                              </DeleteParameters>
                              <UpdateParameters>
                                <asp:Parameter Name="TieuDeTin" Type="string" />
                                <asp:Parameter Name="MoTa" Type="string" />
                               
                                <asp:Parameter Name="MaLoaiTin" Type="int32" />
<asp:Parameter Name="MaTin"></asp:Parameter>
                               
                            </UpdateParameters>
                            
                              
                              </asp:SqlDataSource>
                              
                      </p>
                      <p class="normal">
                          &nbsp;</p>
                                            <p class="normal">
                                                &nbsp;</p>
                      <p class="normal">
                          <table style="width:100%;">
                              <tr align="center">
                                  <td style="width: 105px; color: #FFFFFF; height: 17px; background-color: #006699;">
                                      <b>Mã loại tin</b></td>
                                                        <td style="width: 175px; height: 17px; background-color: #006699">
                                                            <span style="color: #FFFFFF"><b>Tiêu đề tin&nbsp;</b></td>
                                                        <td style="height: 17px; background-color: #006699; color: #FFFFFF;">
                                                            <b><span style="background-color: #006699">Mô tả&nbsp;</span></b></span></td>
                                                    </tr>
                                                    <tr align="center">
                                                        <td style="width: 105px" class="style2">
                                                            <asp:TextBox ID="txtMLT" runat="server" Width="82px"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 175px">
                                                            <asp:TextBox ID="txtTDT" runat="server" Width="162px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtMT" runat="server" Width="200px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr align="center">
                                                        <td class="style2" colspan="3">
                                                            <asp:Button ID="btnThem" runat="server" Text="Thêm tin" 
                                                                onclick="btnThem_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                
                     
                                            </p>
                                        <p class="normal">
                                            &nbsp;</p>
                   
                      <hr />
                      <br />
                      <div><table style="width:100%;">
                              <tr>
                                  <td style="height: 16px; font-size: x-large; color: #FF6600;" colspan="7"
                            align=center>
                            <b>Quản lý loại tin tức thời sự</td>
                              </tr>
                          </table>
                      </div>
                      <br />
                      <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                          BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                          CellPadding="3" CellSpacing="3" DataKeyNames="MaLoaiTin" 
                          DataSourceID="SqlDataSource4" meta:resourcekey="GridView2Resource1">
                          <RowStyle ForeColor="#000066" />
                          <Columns>
                              <asp:BoundField DataField="MaLoaiTin" HeaderText="Mã loại tin" 
                                  InsertVisible="False" ReadOnly="True" SortExpression="MaLoaiTin" 
                                  ApplyFormatInEditMode="True" meta:resourcekey="BoundFieldResource1" >
                                  <ControlStyle Width="40px" />
                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40px" />
                              </asp:BoundField>
                              <asp:BoundField DataField="TenLoaiTin" HeaderText="Tên loại tin" 
                                  SortExpression="TenLoaiTin" ApplyFormatInEditMode="True" 
                                  meta:resourcekey="BoundFieldResource2" >
                                  <ControlStyle Width="200px" />
                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" />
                              </asp:BoundField>
                              <asp:CommandField ShowEditButton="True" CancelText="Thoát" DeleteText="Xóa" 
                                  EditText="Sửa" InsertText="Thêm" NewText="Mới" UpdateText="OK" 
                                  meta:resourcekey="CommandFieldResource1" >
                                  <ControlStyle ForeColor="#990000" Width="35px" />
                                  <ItemStyle ForeColor="#990000" HorizontalAlign="Center" VerticalAlign="Middle" 
                                      Width="35px" />
                              </asp:CommandField>
                              <asp:CommandField ShowDeleteButton="True" CancelText="Thoát" DeleteText="Xóa" 
                                  EditText="Sửa" InsertText="Thêm" UpdateText="OK" 
                                  meta:resourcekey="CommandFieldResource2" >
                                  <ControlStyle ForeColor="#990000" Width="35px" />
                                  <ItemStyle ForeColor="#990000" HorizontalAlign="Center" VerticalAlign="Middle" 
                                      Width="35px" />
                              </asp:CommandField>
                          </Columns>
                          <FooterStyle BackColor="White" ForeColor="#000066" />
                          <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                          <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                          <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                      </asp:GridView>
                      <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                          ConnectionString="<%$ ConnectionStrings:xaydung %>" 
                          SelectCommand="SELECT [MaLoaiTin], [TenLoaiTin] FROM [loaitintuc]" 
                          DeleteCommand="DELETE FROM loaitintuc WHERE MaLoaiTin = @MaLoaiTin" 
                          InsertCommand="INSERT INTO loaitintuc(TenLoaiTin) VALUES (@TenLoaiTin)" 
                          UpdateCommand="UPDATE loaitintuc SET TenLoaiTin = @TenLoaiTin WHERE MaLoaiTin = @MaLoaiTin">
                          
                          <UpdateParameters>
                                <asp:Parameter Name="TenLoaiTin" Type="string" />
                            </UpdateParameters>
                            
                            <DeleteParameters>
                                <asp:Parameter Name="MaTin" Type="int32" />
                               
                              </DeleteParameters>
                              
                              <InsertParameters>
                                <asp:Parameter Name="TenLoaiTin" Type="string" />
                              </InsertParameters>
                          
                          
                          </asp:SqlDataSource>
                   
                                            <br />
                   
                      <br />
                          <table style="width:40%;">
                              <tr align="center">
                                                        <td style="width: 175px; height: 17px; background-color: #006699">
                                                            <span style="color: #FFFFFF"><b>Tên loại tin</b></td>
                                                    </tr>
                                                    <tr align="center">
                                                        <td style="width: 175px">
                                                            <asp:TextBox ID="txtTLT" runat="server" Width="192px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr align="center">
                                                        <td class="style2">
                                                            <asp:Button ID="btnTLT" runat="server" Text="Thêm loại tin" 
                                                                onclick="btnThem_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                
                   <%}
                     else
                         Response.Write("cam hack tinh lam gi day may"); %>
                  </div>
                  
</asp:Content>


