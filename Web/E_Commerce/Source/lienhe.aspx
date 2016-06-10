<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="lienhe.aspx.cs" Inherits="lienhe" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenedit" Runat="Server">
<div class="contact_news">

    <br />
    <br />

Cảm ơn quý khách hàng đã quan tâm đến sản phẩm, dịch vụ của Công ty Cổ
Phần Địa Ốc DND. 
    <br />
    <br />
    Quý khách liên hệ với chúng
tôi bằng cách điền vào mẫu Form dưới đây và gửi cho chúng tôi. Thông
tin của quý khách sẽ được xem xét và trả lời trong thời gian sớm nhất.<br />
                                        </div>
        <div class="contact_textline">
            <table width="500" border="0" cellpadding="0" cellspacing="0" height="175">
                <tbody><tr>
                    <td style="width: 139px">
                        Họ và tên<span class="mandatory">*</span>:
                    </td>
                    <td width="200">

                        <input name="ctl00$ContentPlaceHolder$ctl01$txtName" id="ctl00_ContentPlaceHolder_ctl01_txtName" type="text">
                        <span id="ctl00_ContentPlaceHolder_ctl01_inputName" class="error" style="color: Red; display: none;"><br>Vui lòng nhập họ tên của bạn.</span>
                    </td>
                    <td width="27">
                        &nbsp;
                    </td>
                    <td width="200">
                        Nội dung
                        <span class="mandatory">*</span>:
                    </td>

                </tr>
                <tr>
                    <td style="width: 139px">
                        Công ty:
                    </td>
                    <td>
                        <input name="ctl00$ContentPlaceHolder$ctl01$txtCompany" id="ctl00_ContentPlaceHolder_ctl01_txtCompany" type="text">
                    </td>
                    <td>

                        &nbsp;
                    </td>
                    <td rowspan="6">
                        <textarea name="ctl00$ContentPlaceHolder$ctl01$txtContent" rows="5" cols="30" id="ctl00_ContentPlaceHolder_ctl01_txtContent"></textarea>
                        <span id="ctl00_ContentPlaceHolder_ctl01_inputContent" class="error" style="color: Red; display: none;"><br>Vui lòng nhập nội dung.</span>
                    </td>
                </tr>
                <tr>

                    <td style="width: 139px">
                        Địa chỉ<span class="mandatory">*</span>:
                    </td>
                    <td>
                        <input name="ctl00$ContentPlaceHolder$ctl01$txtAddress" id="ctl00_ContentPlaceHolder_ctl01_txtAddress" type="text">
                    </td>
                    <td>
                        &nbsp;

                    </td>
                </tr>
                <tr>
                    <td style="width: 139px">
                        Điện thoại
                        <span class="mandatory">*</span>:
                    </td>
                    <td>
                        <input name="ctl00$ContentPlaceHolder$ctl01$txtPhone" id="ctl00_ContentPlaceHolder_ctl01_txtPhone" type="text">

                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 139px">
                        Fax:
                    </td>

                    <td>
                        <input type="text">
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 139px">

                        Email <span class="mandatory">*</span>:
                    </td>
                    <td>
                        <input name="ctl00$ContentPlaceHolder$ctl01$txtEmail" id="ctl00_ContentPlaceHolder_ctl01_txtEmail" type="text">
                        <span id="ctl00_ContentPlaceHolder_ctl01_inputEmail" class="error" style="color: Red; display: none;"><br>Vui lòng nhập email.</span>
                        <span id="ctl00_ContentPlaceHolder_ctl01_vdEmail" class="error" style="color: Red; display: none;"><br>Email nhập không đúng định dạng.</span>
                    </td>

                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td height="25" style="width: 139px">
                        Tiêu đề
                        <span class="mandatory">*</span>:
                    </td>

                    <td>
                        <input name="ctl00$ContentPlaceHolder$ctl01$txtTitle" size="30" id="ctl00_ContentPlaceHolder_ctl01_txtTitle" type="text">
                        <span id="ctl00_ContentPlaceHolder_ctl01_inputTitle" class="error" style="color: Red; display: none;"><br>Vui lòng nhập tiêu đề.</span>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>

            </tbody></table>
                                            <br />
            <div class="senitem">
                <div class="button">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input name="ctl00$ContentPlaceHolder$ctl01$btnSend" value="Gửi" onclick='javascript:WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions("ctl00$ContentPlaceHolder$ctl01$btnSend", "", true, "", "", false, false))' id="ctl00_ContentPlaceHolder_ctl01_btnSend" class="contact_3" type="submit">
                    <input name="ctl00$ContentPlaceHolder$ctl01$btnReset" value="Hủy bỏ" id="ctl00_ContentPlaceHolder_ctl01_btnReset" class="contact_3" type="submit">
                </div>
                <div class="chuthich">
                    <span class="mandatory">(*)</span>

                    Yêu cầu nhập thông tin.</div>
            </div>
        </div>
        <div style="clear: both;">
            <label id="ctl00_ContentPlaceHolder_ctl01_lblMsg" style="color: Red;">
            </label>
        </div>
    </div>

</asp:Content>

