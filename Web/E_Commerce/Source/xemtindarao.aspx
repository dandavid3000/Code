<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="xemtindarao.aspx.cs" Inherits="xemtindarao" Title="Untitled Page" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="contenedit">
                  <div class="center_box_content">
                   <%if (Session["login"] != null)
                     {
                    %>
                    
                       <div style="font-family: Arial; font-size: medium; font-weight: bold; color: #FFFFFF; background-color: #009900">
                           Tin Rao chưa duyệt</div>
                      <asp:ListView ID="ListView1" runat="server" DataKeyNames="MaTinRao" 
                          DataSourceID="SqlDataSource1">
                          <ItemTemplate>
                              <li style="">
                                 
                                 
                                 
                                
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
                                    <asp:Image ID="Image2" runat="server" ImageUrl='<%# Eval("hinh") %>'/>
                                  <br />
                                  NgayDang:
                                  <asp:Label ID="NgayDangLabel" runat="server" Text='<%# Eval("NgayDang") %>' />
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
                              <li style="">
                                 
                                 
                                 
                                 
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
                                  <asp:Image ID="Image2" runat="server" ImageUrl='<%# Eval("hinh") %>'/>
                                  <br />
                                  NgayDang:
                                  <asp:Label ID="NgayDangLabel" runat="server" Text='<%# Eval("NgayDang") %>' />
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
                              <ul ID="itemPlaceholderContainer" runat="server" style="">
                                  <li ID="itemPlaceholder" runat="server" />
                                  </ul>
                                  <div style="">
                                  </div>
                          </LayoutTemplate>
                          <EditItemTemplate>
                              <li style="">MaTinRao:
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
                              <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
                                  <td>
                                      <asp:Label ID="MaTinRaoLabel" runat="server" Text='<%# Eval("MaTinRao") %>' />
                                  </td>
                                  <td>
                                      <asp:Label ID="MaUserLabel" runat="server" Text='<%# Eval("MaUser") %>' />
                                  </td>
                                  <td>
                                      <asp:Label ID="MaLoaiDatLabel" runat="server" Text='<%# Eval("MaLoaiDat") %>' />
                                  </td>
                                  <td>
                                      <asp:Label ID="MaLoaiDiaOcLabel" runat="server" 
                                          Text='<%# Eval("MaLoaiDiaOc") %>' />
                                  </td>
                                  <td>
                                      <asp:Label ID="MaLoaiTinRaoLabel" runat="server" 
                                          Text='<%# Eval("MaLoaiTinRao") %>' />
                                  </td>
                                  <td>
                                      <asp:Label ID="TieuDeLabel" runat="server" Text='<%# Eval("TieuDe") %>' />
                                  </td>
                                  <td>
                                      <asp:Label ID="DiaChiLabel" runat="server" Text='<%# Eval("DiaChi") %>' />
                                  </td>
                                  <td>
                                      <asp:Label ID="GiaLabel" runat="server" Text='<%# Eval("Gia") %>' />
                                  </td>
                                  <td>
                                      <asp:Label ID="NgayHetHanLabel" runat="server" 
                                          Text='<%# Eval("NgayHetHan") %>' />
                                  </td>
                                  <td>
                                      <asp:Label ID="HinhLabel" runat="server" Text='<%# Eval("Hinh") %>' />
                                  </td>
                                  <td>
                                      <asp:Label ID="NgayDangLabel" runat="server" Text='<%# Eval("NgayDang") %>' />
                                  </td>
                                  <td>
                                      <asp:Label ID="MaViTriLabel" runat="server" Text='<%# Eval("MaViTri") %>' />
                                  </td>
                                  <td>
                                      <asp:Label ID="TrangThaiTinRaoLabel" runat="server" 
                                          Text='<%# Eval("TrangThaiTinRao") %>' />
                                  </td>
                                  <td>
                                      <asp:Label ID="dientichkhuongvienLabel" runat="server" 
                                          Text='<%# Eval("dientichkhuongvien") %>' />
                                  </td>
                                  <td>
                                      <asp:Label ID="dientichkhuvucLabel" runat="server" 
                                          Text='<%# Eval("dientichkhuvuc") %>' />
                                  </td>
                                  <td>
                                      <asp:Label ID="huongLabel" runat="server" Text='<%# Eval("huong") %>' />
                                  </td>
                                  <td>
                                      <asp:Label ID="thongtinlienheLabel" runat="server" 
                                          Text='<%# Eval("thongtinlienhe") %>' />
                                  </td>
                                  <td>
                                      <asp:Label ID="dacdiemkhacLabel" runat="server" 
                                          Text='<%# Eval("dacdiemkhac") %>' />
                                  </td>
                              </tr>
                          </SelectedItemTemplate>
                      </asp:ListView>
                      <div style="font-family: Arial; font-size: medium; font-weight: bold; color: #FFFFFF; background-color: #009900">
                          Tin Rao Đã duyệt</div>
                      <asp:ListView ID="ListView2" runat="server" DataKeyNames="MaTinRao" 
                              DataSourceID="SqlDataSource3">
                          <ItemTemplate>
                              <li style="">
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
                                  
                                  <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Hinh") %>'/>
                                  <br />
                                  NgayDang:
                                  <asp:Label ID="NgayDangLabel" runat="server" Text='<%# Eval("NgayDang") %>' />
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
                              <li style="">
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
                                  <asp:Image ID="Image3" runat="server" ImageUrl='<%# Eval("Hinh") %>'/>
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
                              <ul ID="itemPlaceholderContainer" runat="server" style="">
                                  <li ID="itemPlaceholder" runat="server" />
                                  </ul>
                                  <div style="">
                                  </div>
                              </LayoutTemplate>
                              <EditItemTemplate>
                                  <li style="">MaTinRao:
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
                                  <li style="">MaTinRao:
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
                          <div style="font-family: Arial; font-size: medium; font-weight: bold; color: #FFFFFF; background-color: #009900">
                          Tin Rao Hết Hạn</div>
                      <asp:DataList ID="DataList1" runat="server" DataKeyField="MaTinRao" 
                              DataSourceID="SqlDataSource5">
                          <ItemTemplate>
                             
                             
                             
                             
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
                             
                              <asp:Image ID="Image4" runat="server" ImageUrl='<%# Eval("Hinh") %>' />
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
                              <br />
                          </ItemTemplate>
                      </asp:DataList>
                    <%}

                     else
                     {
                         
                     %>
                     
                     <div>Trang web chi gianh cho thành viên đăng ký</div>
                     
                     <%} %>
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                          ConnectionString="<%$ ConnectionStrings:xaydung %>" 
                          
                          SelectCommand="SELECT MaTinRao, MaUser, MaLoaiDat, MaLoaiDiaOc, MaLoaiTinRao, TieuDe, DiaChi, Gia, NgayHetHan, Hinh, NgayDang, MaViTri, TrangThaiTinRao, dientichkhuongvien, dientichkhuvuc, huong, thongtinlienhe, dacdiemkhac FROM tinrao WHERE (MaUser = @mauser) AND (TrangThaiTinRao = 0)">
                          <SelectParameters>
                              <asp:SessionParameter DefaultValue="" Name="mauser" SessionField="mauser" />
                          </SelectParameters>
                      </asp:SqlDataSource>
                      <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                          ConnectionString="<%$ ConnectionStrings:xaydung %>" 
                          SelectCommand="SELECT MaTinRao, MaUser, MaLoaiDat, MaLoaiDiaOc, MaLoaiTinRao, TieuDe, DiaChi, Gia, NgayHetHan, Hinh, NgayDang, MaViTri, TrangThaiTinRao, dientichkhuongvien, dientichkhuvuc, huong, thongtinlienhe, dacdiemkhac FROM tinrao WHERE (MaUser = @mauser) AND (TrangThaiTinRao = 1)">
                          <SelectParameters>
                              <asp:SessionParameter Name="mauser" SessionField="mauser" />
                          </SelectParameters>
                      </asp:SqlDataSource>
                      <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
                          ConnectionString="<%$ ConnectionStrings:xaydung %>" 
                          
                              SelectCommand="SELECT MaTinRao, MaUser, MaLoaiDat, MaLoaiDiaOc, MaLoaiTinRao, TieuDe, DiaChi, Gia, NgayHetHan, Hinh, NgayDang, MaViTri, TrangThaiTinRao, dientichkhuongvien, dientichkhuvuc, huong, thongtinlienhe, dacdiemkhac FROM tinrao WHERE (MaUser = @mauser) AND (TrangThaiTinRao = 2)">
                          <SelectParameters>
                              <asp:SessionParameter Name="mauser" SessionField="mauser" />
                          </SelectParameters>
                      </asp:SqlDataSource>
                      </div>
                  
</asp:Content>


