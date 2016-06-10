<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="xemtinrao.aspx.cs" Inherits="xemtinrao" Title="Untitled Page" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="contenedit">
                  <div class="center_box_content">
                  
                   
                      <asp:ListView ID="ListView1" runat="server" DataKeyNames="MaTinRao" 
                          DataSourceID="SqlDataSource3">
                          <ItemTemplate>
                              <li style="background-color: #DCDCDC;color: #000000;">
                              
                                  TieuDe:
                                  <asp:Label ID="TieuDeLabel" runat="server" Text='<%# Eval("TieuDe") %>' />
                                  <br />
                                  DiaChi:
                                  <asp:Label ID="DiaChiLabel" runat="server" Text='<%# Eval("DiaChi") %>' />
                                  <br />
                                 
                                  Gia:
                                  <asp:Label ID="GiaLabel" runat="server" 
                                      Text='<%# Eval("Gia") %>' />
                                  <br />
                                  NgayHetHan:
                                  <asp:Label ID="NgayHetHanLabel" runat="server" 
                                      Text='<%# Eval("NgayHetHan") %>' />
                                  <br />
                                  
                                 
                                  <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Hinh") %>' /> 
                                  <br />
                                  NgayDang:
                                  <asp:Label ID="NgayDangLabel" runat="server" Text='<%# Eval("NgayDang") %>' />
                                  <br />
                                 
                                  TrangThaiTinRao:
                                  <asp:Label ID="TrangThaiTinRaoLabel" runat="server" 
                                      Text='<%# Eval("TrangThaiTinRao") %>' />
                                  <br />
                                  dientichkhuongvien:
                                  <asp:Label ID="dientichkhuongvienLabel" runat="server" 
                                      Text='<%# Eval("dientichkhuongvien") %>' />
                                  <br />
                                  dientichkhuvuc:
                                  <asp:Label ID="dientichkhuvucLabel" runat="server" 
                                      Text='<%# Eval("dientichkhuvuc") %>' />
                                  <br />
                                  huong:
                                  <asp:Label ID="huongLabel" runat="server" Text='<%# Eval("huong") %>' />
                                  <br />
                                  thongtinlienhe:
                                  <asp:Label ID="thongtinlienheLabel" runat="server" 
                                      Text='<%# Eval("thongtinlienhe") %>' />
                                  <br />
                                  dacdiemkhac:
                                  <asp:Label ID="dacdiemkhacLabel" runat="server" 
                                      Text='<%# Eval("dacdiemkhac") %>' />
                                  <br />
                              </li>
                          </ItemTemplate>
                          <AlternatingItemTemplate>
                                 TieuDe:
                                  <asp:Label ID="TieuDeLabel" runat="server" Text='<%# Eval("TieuDe") %>' />
                                  <br />
                                  DiaChi:
                                  <asp:Label ID="DiaChiLabel" runat="server" Text='<%# Eval("DiaChi") %>' />
                                  <br />
                                 
                                  Gia:
                                  <asp:Label ID="GiaLabel" runat="server" 
                                      Text='<%# Eval("Gia") %>' />
                                  <br />
                                  NgayHetHan:
                                  <asp:Label ID="NgayHetHanLabel" runat="server" 
                                      Text='<%# Eval("NgayHetHan") %>' />
                                  <br />
                                 
                                 
                                  <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Hinh") %>' /> 
                                  <br />
                                  NgayDang:
                                  <asp:Label ID="NgayDangLabel" runat="server" Text='<%# Eval("NgayDang") %>' />
                                  <br />
                                 
                                  TrangThaiTinRao:
                                  <asp:Label ID="TrangThaiTinRaoLabel" runat="server" 
                                      Text='<%# Eval("TrangThaiTinRao") %>' />
                                  <br />
                                  dientichkhuongvien:
                                  <asp:Label ID="dientichkhuongvienLabel" runat="server" 
                                      Text='<%# Eval("dientichkhuongvien") %>' />
                                  <br />
                                  dientichkhuvuc:
                                  <asp:Label ID="dientichkhuvucLabel" runat="server" 
                                      Text='<%# Eval("dientichkhuvuc") %>' />
                                  <br />
                                  huong:
                                  <asp:Label ID="huongLabel" runat="server" Text='<%# Eval("huong") %>' />
                                  <br />
                                  thongtinlienhe:
                                  <asp:Label ID="thongtinlienheLabel" runat="server" 
                                      Text='<%# Eval("thongtinlienhe") %>' />
                                  <br />
                                  dacdiemkhac:
                                  <asp:Label ID="dacdiemkhacLabel" runat="server" 
                                      Text='<%# Eval("dacdiemkhac") %>' />
                                  <br />
                              </li>
                          </AlternatingItemTemplate>
                          <EmptyDataTemplate>
                              No data was returned.
                          </EmptyDataTemplate>
                          <InsertItemTemplate>
                              <li style="">MaUser:
                                  <asp:TextBox ID="MaUserTextBox" runat="server" Text='<%# Bind("MaUser") %>' />
                                  <br />
                                  MaLoaiDat:
                                  <asp:TextBox ID="MaLoaiDatTextBox" runat="server" 
                                      Text='<%# Bind("MaLoaiDat") %>' />
                                  <br />
                                  MaLoaiDiaOc:
                                  <asp:TextBox ID="MaLoaiDiaOcTextBox" runat="server" 
                                      Text='<%# Bind("MaLoaiDiaOc") %>' />
                                  <br />
                                  MaLoaiTinRao:
                                  <asp:TextBox ID="MaLoaiTinRaoTextBox" runat="server" 
                                      Text='<%# Bind("MaLoaiTinRao") %>' />
                                  <br />
                                  TieuDe:
                                  <asp:TextBox ID="TieuDeTextBox" runat="server" Text='<%# Bind("TieuDe") %>' />
                                  <br />
                                  DiaChi:
                                  <asp:TextBox ID="DiaChiTextBox" runat="server" Text='<%# Bind("DiaChi") %>' />
                                  <br />
                                  Gia:
                                  <asp:TextBox ID="GiaTextBox" runat="server" Text='<%# Bind("Gia") %>' />
                                  <br />
                                  NgayHetHan:
                                  <asp:TextBox ID="NgayHetHanTextBox" runat="server" 
                                      Text='<%# Bind("NgayHetHan") %>' />
                                  <br />
                                  Hinh:
                                  <asp:TextBox ID="HinhTextBox" runat="server" Text='<%# Bind("Hinh") %>' />
                                  <br />
                                  NgayDang:
                                  <asp:TextBox ID="NgayDangTextBox" runat="server" 
                                      Text='<%# Bind("NgayDang") %>' />
                                  <br />
                                  MaViTri:
                                  <asp:TextBox ID="MaViTriTextBox" runat="server" Text='<%# Bind("MaViTri") %>' />
                                  <br />
                                  TrangThaiTinRao:
                                  <asp:TextBox ID="TrangThaiTinRaoTextBox" runat="server" 
                                      Text='<%# Bind("TrangThaiTinRao") %>' />
                                  <br />
                                  dientichkhuongvien:
                                  <asp:TextBox ID="dientichkhuongvienTextBox" runat="server" 
                                      Text='<%# Bind("dientichkhuongvien") %>' />
                                  <br />
                                  dientichkhuvuc:
                                  <asp:TextBox ID="dientichkhuvucTextBox" runat="server" 
                                      Text='<%# Bind("dientichkhuvuc") %>' />
                                  <br />
                                  huong:
                                  <asp:TextBox ID="huongTextBox" runat="server" Text='<%# Bind("huong") %>' />
                                  <br />
                                  thongtinlienhe:
                                  <asp:TextBox ID="thongtinlienheTextBox" runat="server" 
                                      Text='<%# Bind("thongtinlienhe") %>' />
                                  <br />
                                  dacdiemkhac:
                                  <asp:TextBox ID="dacdiemkhacTextBox" runat="server" 
                                      Text='<%# Bind("dacdiemkhac") %>' />
                                  <br />
                                  <asp:Button ID="InsertButton" runat="server" CommandName="Insert" 
                                      Text="Insert" />
                                  <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                                      Text="Clear" />
                              </li>
                          </InsertItemTemplate>
                          <LayoutTemplate>
                              <ul ID="itemPlaceholderContainer" runat="server" 
                                  style="font-family: Verdana, Arial, Helvetica, sans-serif;">
                                  <li ID="itemPlaceholder" runat="server" />
                                  </ul>
                                  <div style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                                      <asp:DataPager ID="DataPager1" runat="server">
                                          <Fields>
                                              <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                                                  ShowLastPageButton="True" />
                                          </Fields>
                                      </asp:DataPager>
                                  </div>
                          </LayoutTemplate>
                          <EditItemTemplate>
                              <li style="background-color: #008A8C;color: #FFFFFF;">MaTinRao:
                                  <asp:Label ID="MaTinRaoLabel1" runat="server" Text='<%# Eval("MaTinRao") %>' />
                                  <br />
                                  MaUser:
                                  <asp:TextBox ID="MaUserTextBox" runat="server" Text='<%# Bind("MaUser") %>' />
                                  <br />
                                  MaLoaiDat:
                                  <asp:TextBox ID="MaLoaiDatTextBox" runat="server" 
                                      Text='<%# Bind("MaLoaiDat") %>' />
                                  <br />
                                  MaLoaiDiaOc:
                                  <asp:TextBox ID="MaLoaiDiaOcTextBox" runat="server" 
                                      Text='<%# Bind("MaLoaiDiaOc") %>' />
                                  <br />
                                  MaLoaiTinRao:
                                  <asp:TextBox ID="MaLoaiTinRaoTextBox" runat="server" 
                                      Text='<%# Bind("MaLoaiTinRao") %>' />
                                  <br />
                                  TieuDe:
                                  <asp:TextBox ID="TieuDeTextBox" runat="server" Text='<%# Bind("TieuDe") %>' />
                                  <br />
                                  DiaChi:
                                  <asp:TextBox ID="DiaChiTextBox" runat="server" Text='<%# Bind("DiaChi") %>' />
                                  <br />
                                  Gia:
                                  <asp:TextBox ID="GiaTextBox" runat="server" Text='<%# Bind("Gia") %>' />
                                  <br />
                                  NgayHetHan:
                                  <asp:TextBox ID="NgayHetHanTextBox" runat="server" 
                                      Text='<%# Bind("NgayHetHan") %>' />
                                  <br />
                                  Hinh:
                                  <asp:TextBox ID="HinhTextBox" runat="server" Text='<%# Bind("Hinh") %>' />
                                  <br />
                                  NgayDang:
                                  <asp:TextBox ID="NgayDangTextBox" runat="server" 
                                      Text='<%# Bind("NgayDang") %>' />
                                  <br />
                                  MaViTri:
                                  <asp:TextBox ID="MaViTriTextBox" runat="server" Text='<%# Bind("MaViTri") %>' />
                                  <br />
                                  TrangThaiTinRao:
                                  <asp:TextBox ID="TrangThaiTinRaoTextBox" runat="server" 
                                      Text='<%# Bind("TrangThaiTinRao") %>' />
                                  <br />
                                  dientichkhuongvien:
                                  <asp:TextBox ID="dientichkhuongvienTextBox" runat="server" 
                                      Text='<%# Bind("dientichkhuongvien") %>' />
                                  <br />
                                  dientichkhuvuc:
                                  <asp:TextBox ID="dientichkhuvucTextBox" runat="server" 
                                      Text='<%# Bind("dientichkhuvuc") %>' />
                                  <br />
                                  huong:
                                  <asp:TextBox ID="huongTextBox" runat="server" Text='<%# Bind("huong") %>' />
                                  <br />
                                  thongtinlienhe:
                                  <asp:TextBox ID="thongtinlienheTextBox" runat="server" 
                                      Text='<%# Bind("thongtinlienhe") %>' />
                                  <br />
                                  dacdiemkhac:
                                  <asp:TextBox ID="dacdiemkhacTextBox" runat="server" 
                                      Text='<%# Bind("dacdiemkhac") %>' />
                                  <br />
                                  <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                                      Text="Update" />
                                  <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                                      Text="Cancel" />
                              </li>
                          </EditItemTemplate>
                              <ItemSeparatorTemplate>
                                  <br />
                              </ItemSeparatorTemplate>
                          <SelectedItemTemplate>
                              <li style="background-color: #008A8C;font-weight: bold;color: #FFFFFF;">MaTinRao:
                                  <asp:Label ID="MaTinRaoLabel" runat="server" Text='<%# Eval("MaTinRao") %>' />
                                  <br />
                                  MaUser:
                                  <asp:Label ID="MaUserLabel" runat="server" Text='<%# Eval("MaUser") %>' />
                                  <br />
                                  MaLoaiDat:
                                  <asp:Label ID="MaLoaiDatLabel" runat="server" Text='<%# Eval("MaLoaiDat") %>' />
                                  <br />
                                  MaLoaiDiaOc:
                                  <asp:Label ID="MaLoaiDiaOcLabel" runat="server" 
                                      Text='<%# Eval("MaLoaiDiaOc") %>' />
                                  <br />
                                  MaLoaiTinRao:
                                  <asp:Label ID="MaLoaiTinRaoLabel" runat="server" 
                                      Text='<%# Eval("MaLoaiTinRao") %>' />
                                  <br />
                                  TieuDe:
                                  <asp:Label ID="TieuDeLabel" runat="server" Text='<%# Eval("TieuDe") %>' />
                                  <br />
                                  DiaChi:
                                  <asp:Label ID="DiaChiLabel" runat="server" Text='<%# Eval("DiaChi") %>' />
                                  <br />
                                  Gia:
                                  <asp:Label ID="GiaLabel" runat="server" Text='<%# Eval("Gia") %>' />
                                  <br />
                                  NgayHetHan:
                                  <asp:Label ID="NgayHetHanLabel" runat="server" 
                                      Text='<%# Eval("NgayHetHan") %>' />
                                  <br />
                                  Hinh:
                                  <asp:Label ID="HinhLabel" runat="server" Text='<%# Eval("Hinh") %>' />
                                  <br />
                                  NgayDang:
                                  <asp:Label ID="NgayDangLabel" runat="server" Text='<%# Eval("NgayDang") %>' />
                                  <br />
                                  MaViTri:
                                  <asp:Label ID="MaViTriLabel" runat="server" Text='<%# Eval("MaViTri") %>' />
                                  <br />
                                  TrangThaiTinRao:
                                  <asp:Label ID="TrangThaiTinRaoLabel" runat="server" 
                                      Text='<%# Eval("TrangThaiTinRao") %>' />
                                  <br />
                                  dientichkhuongvien:
                                  <asp:Label ID="dientichkhuongvienLabel" runat="server" 
                                      Text='<%# Eval("dientichkhuongvien") %>' />
                                  <br />
                                  dientichkhuvuc:
                                  <asp:Label ID="dientichkhuvucLabel" runat="server" 
                                      Text='<%# Eval("dientichkhuvuc") %>' />
                                  <br />
                                  huong:
                                  <asp:Label ID="huongLabel" runat="server" Text='<%# Eval("huong") %>' />
                                  <br />
                                  thongtinlienhe:
                                  <asp:Label ID="thongtinlienheLabel" runat="server" 
                                      Text='<%# Eval("thongtinlienhe") %>' />
                                  <br />
                                  dacdiemkhac:
                                  <asp:Label ID="dacdiemkhacLabel" runat="server" 
                                      Text='<%# Eval("dacdiemkhac") %>' />
                                  <br />
                              </li>
                          </SelectedItemTemplate>
                      </asp:ListView>
                      <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                          ConnectionString="<%$ ConnectionStrings:xaydung %>" 
                          SelectCommand="SELECT * FROM [tinrao] WHERE ([TrangThaiTinRao] = @TrangThaiTinRao)">
                          <SelectParameters>
                              <asp:Parameter DefaultValue="1" Name="TrangThaiTinRao" Type="Int32" />
                          </SelectParameters>
                      </asp:SqlDataSource>
                  
                   
                  </div>
                  
</asp:Content>


