<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Show.aspx.cs" Inherits="ZhangWei.Web.Product.Show" Title="显示页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
        <tr>
            <td class="tdbg">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td height="25" width="30%" align="right">
                            编号 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblProduct_ID" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            类别 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblProductList_ID" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            名称 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            简称 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblshortname" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            拼音 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblspell" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            拼音首字母 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lbls_spell" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            规格 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblProductSpec_ID" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            单位 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblProductUnit_ID" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            进价 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblPrice" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            零售价 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblOffering_Price" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            操作员 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblEmployee_ID" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            创建时间 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblCreateDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            描述 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblRemark" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            &nbsp;
                        </td>
                        <td height="25" width="*" align="left">
                            <input id="Button3" onclick="javascript:history.go(-1)" type="button" value="返回" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>