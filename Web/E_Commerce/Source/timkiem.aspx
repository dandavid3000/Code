<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="timkiem.aspx.cs" Inherits="timkiem" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenedit" Runat="Server">

    <br />

    <table style="width:100%;">
        <tr>
            <td colspan="3" 
                style="color: #008000; font-size: large; font-weight: bold; text-align: center">
                Tìm kiếm</td>
        </tr>
        <tr>
            <td>
                Loại tin đăng</td>
                                                <td>
                                                    <br />
                                                    <asp:DropDownList ID="List1" runat="server" DataSourceID="xaydung" 
                                                        DataTextField="TenLoaiTinRao" DataValueField="MaLoaiTinRao">
                                                    </asp:DropDownList>
                                                    <asp:SqlDataSource ID="xaydung" runat="server" 
                                                        ConnectionString="<%$ ConnectionStrings:xaydung %>" 
                                                        SelectCommand="SELECT [TenLoaiTinRao], [MaLoaiTinRao] FROM [LoaiTinRao]">
                                                    </asp:SqlDataSource>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <br />
                                                    <br />
                                                    Loại địa ốc</td>
            <td>
                <br />
                <br />
                <asp:DropDownList ID="List2" runat="server" DataSourceID="xaydung1" 
                    DataTextField="TenLoaiDiaOc" DataValueField="MaLoaiDiaOc">
                </asp:DropDownList>
                <asp:SqlDataSource ID="xaydung1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:xaydung %>" 
                    SelectCommand="SELECT [MaLoaiDiaOc], [TenLoaiDiaOc] FROM [loaidiaoc]">
                </asp:SqlDataSource>
                                                </td>
            <td>
                &nbsp;</td>
        </tr>
        
        <tr>
        <td>
            <br />
            <br />
            Vị trí địa ốc</td>
        <td>
            <br />
            <br />
            <asp:DropDownList ID="List3" runat="server" DataSourceID="xaydung2" 
                DataTextField="TenViTri" DataValueField="MaViTri">
            </asp:DropDownList>
            <asp:SqlDataSource ID="xaydung2" runat="server" 
                ConnectionString="<%$ ConnectionStrings:xaydung %>" 
                SelectCommand="SELECT [MaViTri], [TenViTri] FROM [vitri]">
            </asp:SqlDataSource>
        </td>
        <td>
        </td>
        </tr>
        
        <tr>
        <td>
        </td>
        <td>
            <br />
            <asp:Button ID="btnTimKiem" runat="server" Text="Tìm kiếm" 
                onclick="btnTimKiem_Click" />
        </td>
        <td>
        </td>
        </tr>
        <asp:GridView ID="dtgKetQua" runat="server" BackColor="White" 
            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
            <RowStyle ForeColor="#000066" />
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
    </table>

    <br />
    <br />
    <br />
</asp:Content>

