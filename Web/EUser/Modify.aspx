<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Modify.aspx.cs" Inherits="ZhangWei.Web.EUser.Modify" Title="修改页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
        <tr>
            <td class="tdbg">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td height="25" width="30%" align="right">
                            UserId ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblUserId" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            UserName ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtUserName" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            PassWord ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtPassWord" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            Email ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtEmail" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            Name ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            Sex ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtSex" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            Age ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtAge" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            ID_Card ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtID_Card" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            Phone ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtPhone" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            MobilPhone ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtMobilPhone" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            Address ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtAddress" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            Postalcode ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtPostalcode" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            Work ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtWork" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            Income ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtIncome" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            Integral ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtIntegral" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            CreateTime ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtCreateTime" runat="server" Width="70px" onfocus="setday(this)"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            LaseLogin ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtLaseLogin" runat="server" Width="70px" onfocus="setday(this)"></asp:TextBox>
                        </td>
                    </tr>
                </table>

                <script src="/js/calendar1.js" type="text/javascript"></script>

            </td>
        </tr>
        <tr>
            <td class="tdbg" align="center" valign="bottom">
                <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" class="inputbutton"
                    onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'">
                </asp:Button>
                <input id="Button3" onclick="javascript:history.go(-1)" type="button" value="返回" />
            </td>
        </tr>
    </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>
