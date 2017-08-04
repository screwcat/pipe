<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Modify.aspx.cs" Inherits="ZhangWei.Web.BuyOrder.Modify" Title="修改页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
        <tr>
            <td class="tdbg">

                <script src="../../My97DatePicker/WdatePicker.js" type="text/javascript"></script>

                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td height="25" width="30%" align="right">
                            编号：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblBuyOrder_ID" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            合同签订日期 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtWriteDate" runat="server" Width="120px" onClick="WdatePicker()"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            合同生效日期 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtInsureDate" runat="server" Width="120px" onClick="WdatePicker()"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            合同到期日期 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtEndDate" runat="server" Width="120px" onClick="WdatePicker()"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            签订部门 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:DropDownList ID="DropDownList1" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            供应商 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:DropDownList ID="DropDownList2" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            合同主要负责人 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:DropDownList ID="DropDownList3" runat="server">
                            </asp:DropDownList>
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