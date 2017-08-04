<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Add.aspx.cs" Inherits="ZhangWei.Web.Employee.Add" Title="增加页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="../../My97DatePicker/WdatePicker.js" type="text/javascript"></script>

    <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
        <tr>
            <td class="tdbg">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td height="25" width="30%" align="right">
                            部门：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:DropDownList ID="DropDownList1" runat="server">
                            </asp:DropDownList>
                            <a href="/BaseInfo/Dept/list.aspx">编辑选项</a>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            姓名 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            职务 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtDuty" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            性别 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="男">男</asp:ListItem>
                                <asp:ListItem Value="女">女</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            生日 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtBirthDate" runat="server" Width="100px" onClick="WdatePicker()"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            合同签订日期 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtHireDate" runat="server" Width="100px" onClick="WdatePicker()"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            合同到期日 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtMatureDate" runat="server" Width="100px" onClick="WdatePicker()"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            身份证号 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtIdentityCard" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            住址 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtAddress" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            电话 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtPhone" runat="server" Width="200px"></asp:TextBox>
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
    <br />
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>