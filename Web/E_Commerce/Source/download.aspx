<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="download.aspx.cs" Inherits="download" Title="Untitled Page" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="contenedit">
                  <div class="center_box_content">
                  <%
                       
                       if (Session["login"] == null)
                      {
                          Response.Write("xin lỗi bạn chức năng chỉ giành cho user login");
                      }
                      else
                      {
                       %> 
                      <table style="width:100%;">
                          <tr align="center">
                              <td style="width: 130px; color: #FFFFFF; height: 17px; background-color: #006699;">
                                      <b>Tải tài liệu Luật địa ốc</b></td>
                              &lt;<td style="width: 106px; color: #FFFFFF; height: 17px; background-color: #006699;">
                                      <b>Tải tài liệu ngân hàng</b></td>
                              <td style="width: 106px; color: #FFFFFF; height: 17px; background-color: #006699;">
                                      <b>Tải tài liệu pháp luật</b></td>
                          </tr>
                          <tr align="center">
                              <td style="width: 130px">
                              <a href="cuon1.pdf">   cuốn 1</a> </td>
                              <td style="width: 117px">
                              <a href="cuon1.pdf">     cuốn 1</a></td>
                              <td>
                               <a href="honnhan.pdf">    Hôn nhân và gia đình</a></td>
                          </tr>
                          <tr align="center"> 
                              <td style="width: 130px">
                                <a href="cuon2.pdf">   cuốn 2</a></td>
                              <td style="width: 117px">
                               <a href="cuon2.pdf">    cuốn 2</a></td>
                              <td>
                              <a href="giaothong.pdf">     Luật giao thông</a></td>
                          </tr>
                      </table>
                      <%} %>
                       
                  </div>
                  
</asp:Content>



