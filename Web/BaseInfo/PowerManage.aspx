<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PowerManage.aspx.cs" Inherits="ZhangWei.Web.BaseInfo.PowerManage" %>

<%@ Register src="../Controls/checkright.ascx" tagname="checkright" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1 { font-size: x-large; }
        .style2 { text-align: center; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="style2">
            <span class="style1">权限管理<uc2:checkright ID="checkright1" runat="server" PermissionID="0" />
            </span></div>
        <table cellspacing="0" cellpadding="0" rules="all" border="1" style="border-color: #000;
                        border-width: 1px; border-style: solid; width: 100%; border-collapse: collapse;">
                        <thead>
                <tr style="font-size:12px">
                    <th>
                        用户姓名</th>
                    <th>
                        进货合同
                    </th>
                    <th>
                        销售开单
                    </th>
                    <th>
                        销售退货
                    </th>
                    <th>
                        销售记录
                    </th>
                    <th>
                        物品入库
                    </th>
                    <th>
                        物品出库
                    </th>
                    <th>
                        仓库调拔
                    </th>
                    <th>
                        客户资料
                    </th>
                    <th>
                        供应商管理
                    </th>
                    <th>
                        商品资料
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("Name")%>' Font-Size="12px"></asp:Label><asp:Label
                                    ID="Label2" runat="server" Text='<%#Eval("Employee_ID")%>' style="display:none"></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBox1" runat="server" Text="1" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBox2" runat="server" Text="2" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBox3" runat="server" Text="3" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBox4" runat="server" Text="4" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBox5" runat="server" Text="5" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBox6" runat="server" Text="6" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBox7" runat="server" Text="7" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBox8" runat="server" Text="8" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBox9" runat="server" Text="9" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBox10" runat="server" Text="10" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
    <br />
    <asp:Button ID="Button1" runat="server" Font-Size="Large" Height="32px" 
        Text="保存" Width="73px" onclick="Button1_Click" />
    </form>
</body>
</html>
