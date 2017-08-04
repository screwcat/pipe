<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BackStockDetail.aspx.cs" Inherits="ZhangWei.Web.warehouse.BackStockDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <script src="../js/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script src="../lhgdialog/lhgdialog.min.js?skin=chrome" type="text/javascript"></script>

    <link href="../Style/Style.css" rel="stylesheet" type="text/css" />

    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            text-align: center;
            font-size: x-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <div class="style1">
            出库单名细
        </div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" cellpadding="0" BorderWidth="1px" RowStyle-HorizontalAlign="Center" CssClass="gridview_m">
            <Columns>
                <asp:BoundField DataField="BackStock_ID" HeaderText="出库单ID" />
                <asp:BoundField DataField="Quantity" HeaderText="数量" />
                <asp:BoundField DataField="Price" HeaderText="价格" />
                <asp:BoundField DataField="EmployeeName" HeaderText="操作员" />
                <asp:BoundField DataField="Name" HeaderText="商品类别" />
                <asp:BoundField DataField="ProductName" HeaderText="品名" />
                <asp:BoundField DataField="shortname" HeaderText="简称" />
                <asp:BoundField DataField="SpecName" HeaderText="规格" />
                <asp:BoundField DataField="UnitName" HeaderText="单位" />
                <asp:BoundField DataField="SupplierName" HeaderText="供应商" />
                <asp:BoundField DataField="Address" HeaderText="退货仓库" />
                <asp:BoundField DataField="BackDate" HeaderText="日期" />
            </Columns>
        </asp:GridView>
    
        <br />
                <input id="Button3" onclick="javascript:history.go(-1)" type="button" value="返回" /></div>
    </form>
</body>
</html>
