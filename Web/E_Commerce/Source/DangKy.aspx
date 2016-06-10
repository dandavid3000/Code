<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DangKy.aspx.cs" Inherits="DangKy" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenedit" Runat="Server">
    <br />
    <br />
    <table style="width: 100%;" align="center">
        <tr>
            <td colspan="3" 
                style="color: #008000; font-weight: bold; font-size: large; text-align: center;">
                &nbsp;
                &nbsp;
                &nbsp;
                Đăng ký tài khoản</td>
        </tr>
        <tr>
            <td>
                &nbsp;
                <br />
                Tên truy cập</td>
            <td>
                &nbsp;
                <br />
                <asp:TextBox  runat="Server" ID="txtuser" /><asp:Button ID="btnKiemTra" runat="server" 
                    Text="Kiểm tra" onclick="btnKiemTra_Click" />
                <asp:Label ID="Label2" runat="server" ForeColor="Red" ></asp:Label>
                                                </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
                <br />
                <br />
                Mật khẩu           &nbsp;
                <br />
                <br />
                <br />
                                                </td>
            <td>
               <asp:TextBox  runat="Server" ID="txtpass" /></td>
        </tr>
        
         <tr>
            <td>
                Mã xác thực    <td>
               <div>
               
              <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                  
              <ContentTemplate> 

             <asp:Image  ID="imgCaptcha" runat="server" ImageUrl="Captcha.aspx" Height="30px" 
                      Width="150px"  />
              

                      </ContentTemplate>
                      
               </asp:UpdatePanel>
            <asp:ImageButton ID="imbReLoad" runat="server"  ImageUrl="images/reload.jpg" 
                    onclick="imbReLoad_Click" Height="16px" Width="16px" /><br />
       
                                                        
          </div>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
         <tr>
            <td>
                &nbsp;<br />
                <br />
&nbsp;Nhập mã xác thực</td>
            <td>
                &nbsp;
                <br />
                <asp:TextBox  runat="Server" ID="txtCaptcha" /></asp:TextBox></td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;<asp:Label ID="lblMessage" runat="server"  ForeColor="Red" 
                    Visible="False"></asp:Label>
             </td>
            <td>
                &nbsp;
                <br />
                 <asp:Button ID="btnSubmit" runat="server" Text="Đăng ký" 
                              onclick="btnSubmit_Click" /><br />
                <asp:Label ID="Label1" runat="server" ForeColor="Red" ></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
<script language="javascript" type="text/javascript">

</script>
</asp:Content>

