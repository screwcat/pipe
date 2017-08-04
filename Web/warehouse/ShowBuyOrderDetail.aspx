<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowBuyOrderDetail.aspx.cs"
    Inherits="ZhangWei.Web.warehouse.ShowBuyOrderDetail" %>

<%@ Register src="../Controls/checkright.ascx" tagname="checkright" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <link href="../Style/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="0" bordercolor="#000" cellpadding="0" cellspacing="0" style="height: 97px"
            valign="middle">
            <tr>
                <td align="center" colspan="6" height="70" style="font-size: xx-large">
                    确认入库
                    <asp:Label ID="lblBuyOrder_ID" runat="server" Font-Size="14pt" Text="Label"></asp:Label>
        <uc2:checkright ID="checkright1" runat="server" PermissionID="5" />
                </td>
            </tr>
            <tr height="40">
                <td align="right" width="150">
                    签订日期 ：
                </td>
                <td width="200">
                    <asp:Label ID="txtWriteDate" runat="server" Text="Label"></asp:Label>
                </td>
                <td align="right" width="150">
                    生效日期 ：
                </td>
                <td width="200">
                    <asp:Label ID="txtInsureDate" runat="server" Text="Label"></asp:Label>
                </td>
                <td width="150">
                    合同到期日期 ：
                </td>
                <td width="200">
                    <asp:Label ID="txtEndDate" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr height="40">
                <td align="right">
                    &nbsp;签定部门 ：
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                    <a href="../BaseInfo/Dept/list.aspx">编辑选项</a>
                </td>
                <td align="right">
                    合同主要负责人：
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList3" runat="server">
                    </asp:DropDownList>
                    <a href="../BaseInfo/Employee/list.aspx">编辑选项</a>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
        <table id="searchResu" cellspacing="0" cellpadding="0" rules="all" border="1" style="border-color: #000;
            border-width: 1px; border-style: solid; width: 100%; border-collapse: collapse;">
            <thead>
                <tr>
                    <th width="120">
                        商品编号
                    </th>
                    <th width="120">
                        商品名称
                    </th>
                    <th width="120">
                        规格
                    </th>
                    <th width="120">
                        厂商
                    </th>
                    <th width="120">
                        进价
                    </th>
                    <th width="120">
                        数量
                    </th>
                    <th width="120">
                        单位
                    </th>
                    <th width="120">
                        合计
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("Product_ID")%>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("SpecName")%>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("SupplierName")%>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text='<%#Eval("Price")%>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("Quantity")%>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label10" runat="server" Text='<%#Eval("UnitName")%>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="合计"></asp:Label>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
            <tfoot>
            </tfoot>
        </table>
        共计：<asp:Label ID="Label8" runat="server" Text="Label" Style="font-weight: 700"></asp:Label>&nbsp;元&nbsp;
        大写：<asp:Label ID="Label9" runat="server" Text="Label" Font-Bold="True"></asp:Label>
        <br />
        <div style="text-align: center">
            <br />
            <asp:DropDownList ID="DropDownList4" runat="server" AppendDataBoundItems="True">
                <asp:ListItem Value="0">—请选择仓库—</asp:ListItem>
            </asp:DropDownList>
            <a href="/BaseInfo/StoreHouse/List.aspx">管理仓库</a>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="确认入库" Height="33px" Width="109px" Font-Size="Large"
                Font-Names="黑体" OnClick="Button1_Click" />
            <input id="Button3" onclick="javascript:history.go(-1)" type="button" value="返回" /></div>
    </div>
    </form>
</body>
</html>
