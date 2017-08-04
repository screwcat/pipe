<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Modify.aspx.cs" Inherits="ZhangWei.Web.Product.Modify" Title="修改页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
        <tr>
            <td class="tdbg">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td height="25" width="30%" align="right">
                            商品编号 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblProduct_ID" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            商品总分类：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:DropDownList ID="DropDownList5" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            商品细分类 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:DropDownList ID="DropDownList1" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            商品名称 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            简称：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            名称全拼：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="spell" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            全拼首字母：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="s_spell" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            供应商：</td>
                        <td height="25" width="*" align="left">
                            <asp:DropDownList ID="DropDownList6" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            规格 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:DropDownList ID="DropDownList2" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            计量单位 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:DropDownList ID="DropDownList3" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            进价 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtPrice" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            零售价：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="Offering_Price" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            操作员 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:DropDownList ID="DropDownList4" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            创建时间 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            描述 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtRemark" runat="server" Width="200px"></asp:TextBox>
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