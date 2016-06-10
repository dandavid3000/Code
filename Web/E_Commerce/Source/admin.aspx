<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="admin" Title="Untitled Page" %>



<asp:Content ID="Content1" runat="server" contentplaceholderid="contenedit">

            <%
                     if (Session["admin"] != null)
                     { %>
                  <div class="center_box_content">
                      <div>
                          <div>
                          <table><tr>
                              <td style="height: 16px; width: 502px; color: #FF6600; font-size: xx-large;" 
                                  align="center">
                                  <b>Phân hệ quản trị&nbsp; </b> </table></td></tr></div>
                          <br />
                          <table style="width:100%;" cellpadding="2"; cellspacing="3">
                              <tr style="color: #000000">
                                  <td style="width: 163px; height: 16px; background-color: #336699; color: #FFFFFF; font-weight: bold; font-size: medium;"
                                      align="center">
                                      <a href="quanlyuser.aspx"><span style="color: #FFFFFF; font-weight: bold">Quản 
                                      lý tài khoản người dùng</span></a></td>
                                  <td style="width: 155px; height: 16px; background-color: #336699; font-size: medium;"
                                      align="center">
                                      <a href="DuyetTinRao.aspx"><span style="color: #FFFFFF; font-weight: bold">Duyệt 
                                      tin rao</span></a></td>
                                 <td style="width: 155px; height: 16px; background-color: #336699; font-size: medium;"
                                      align="center">
                                      <a href="KiemTraHangHoaDatHang.aspx"><span style="color: #FFFFFF; font-weight: bold">Kiểm tra hàng hóa & Đặt hàng</span></a></td>
                              </tr>
                              <tr style="color: #000000">
                                  <td style="width: 163px; background-color: #336699; color: #FFFFFF; font-size: medium;" 
                                      align="center">
                                      <a href="DuyetTinRao.aspx"><span style="color: #FFFFFF; font-weight: bold">Đăng tin địa ốc của công ty</span></a></td>
                                  <td style="width: 155px; background-color: #336699; color: #FFFFFF; font-size: medium;"
                                      align="center">
                                      <a href="QuanLyTinThoiSu.aspx"><span style="color: #FFFFFF; font-weight: bold">Quản lý tin thời sự</span></a></td>
                                  <td align="center" 
                                      style="background-color: #336699; color: #FFFFFF; font-size: medium;">
                                      <a href="QuangCao.aspx"><span style="color: #FFFFFF; font-weight: bold">Đăng thông tin quảng cáo</span></a></td>
                              </tr>
                              </table>
                      </div>
                    <p class="normal">
                        &nbsp;</p>
                      <p class="normal">
                          &nbsp;</p>
                   
                  </div>
                  <%}
                     else
                         Response.Write("Miễn phá đi bưỡi"); %>
                  
</asp:Content>
