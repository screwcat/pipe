<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransferDtl.aspx.cs" Inherits="ZhangWei.Web.warehouse.TransferDtl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="../js/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script src="../lhgdialog/lhgdialog.min.js?skin=chrome" type="text/javascript"></script>

    <link href="../Style/Style.css" rel="stylesheet" type="text/css" />

    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%">
            <tr>
                <td align="center" style="font-size: large">
                    仓库调拔详单
                </td>
            </tr>
            <tr>
                <td>
                    单号：<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
&nbsp;操作员：<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
&nbsp;日期：<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                &nbsp;共计：<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                    元 大写：<asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" Width="100%" cellpadding="0" 
                        BorderWidth="1px" RowStyle-HorizontalAlign="Center" AutoGenerateColumns="False" CssClass="gridview_m">
                        <RowStyle HorizontalAlign="Center" />
                        <Columns>
                            <asp:BoundField DataField="Product_ID" HeaderText="商品编号" />
                            <asp:BoundField DataField="ProductName" HeaderText="品名" />
                            <asp:BoundField DataField="shortname" HeaderText="简称" />
                            <asp:BoundField DataField="Name" HeaderText="分类" />
                            <asp:BoundField DataField="SpecName" HeaderText="规格" />
                            <asp:BoundField DataField="UnitName" HeaderText="单位" />
                            <asp:BoundField DataField="SupplierName" HeaderText="供应商" />
                            <asp:BoundField DataField="Price" HeaderText="价格" />
                            <asp:BoundField DataField="Quantity" HeaderText="数量" />
                            <asp:BoundField HeaderText="合计（元）" />
                            <asp:BoundField DataField="FromStock" HeaderText="调出仓库" />
                            <asp:BoundField DataField="ToStock" HeaderText="调入仓库" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                <input id="Button3" onclick="javascript:history.go(-1)" type="button" value="返回" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
