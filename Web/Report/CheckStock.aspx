<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckStock.aspx.cs" Inherits="ZhangWei.Web.Report.CheckStock" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="../js/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script src="../lhgdialog/lhgdialog.min.js?skin=chrome" type="text/javascript"></script>

    <link href="../Style/Style.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        $.dialog.setting.lock = true;
        function ExpToExcel() {
            $.dialog({
                title: '提示信息',
                content: '生成Excel需要一些时间，确定生成吗？',
                ok: function() {
                    startExcel();
                    //                    this.close();
                    return false;
                },
                id: "confirmExcel",
                max: false,
                min: false,
                //lock: true,
                width: 270,
                height: 80,
                cancelVal: '关闭',
                cancel: true /*为true等价于function(){}*/
            });

        }
        function startExcel() {
            var list = $.dialog.list;
            for (var i in list) {
                list[i].close();
            }
            $.ajax({
                type: "get",
                cache: false,
                url: "/ajax/ajax.ashx",
                data: { Command: "StockToExcel", StoreHouse_ID: $("#DropDownList1").val() },
                dataType: "text",
                beforeSend: function() {
                    $.dialog({
                        content: '正在努力生成中，请稍候。。。。。。',
                        lock: true,
                        max: false,
                        min: false,
                        cancel: false,
                        resize: false,
                        drag: false,
                        esc: false,
                        icon: 'loading.gif'
                    });
                },
                success: function(data) {
                    var list = $.dialog.list;
                    for (var i in list) {
                        list[i].close();
                    }
                    $.dialog({
                        content: '<b>生成成功！</b>',
                        max: false,
                        min: false,
                        cancel: false,
                        resize: false,
                        width: 200,
                        icon: 'face-smile.png',
                        button: [{ name: '打开文件', callback: function() {
                            window.open("/ExcelFiles/" + data);
                        }
                        }, { name: '查看以前生成的报表', callback: function() {
                            location.href = "/Report/HisTab.aspx";

                        } }],
                            cancel: true
                        });
                    },
                    complete: function() {

                    }
                });
            }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%">
            <tr>
                <td align="center" style="font-size: x-large">
                    库存盘点
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;选择仓库：<asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True">
                        <asp:ListItem Value="0">—所有—</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="Button1" runat="server" Text="生成报表" OnClick="Button1_Click" />
                    <input id="Button3" type="button" value="导出到Excel" onclick="ExpToExcel()" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
                        CellPadding="0" BorderWidth="1px" RowStyle-HorizontalAlign="Center" EmptyDataText="123"
                        CssClass="gridview_m">
                        <RowStyle HorizontalAlign="Center" />
                        <Columns>
                            <asp:TemplateField HeaderText="行号">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text="<%#Container.DataItemIndex + 1 %>"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Product_ID" HeaderText="商品编号" />
                            <asp:BoundField DataField="ProductName" HeaderText="品名" />
                            <asp:BoundField DataField="shortname" HeaderText="简称" />
                            <asp:BoundField DataField="ListName" HeaderText="分类" />
                            <asp:BoundField DataField="SpecName" HeaderText="规格" />
                            <asp:BoundField DataField="SupplierName" HeaderText="供应商" />
                            <asp:BoundField DataField="UnitName" HeaderText="单位" />
                            <asp:BoundField DataField="Address" HeaderText="仓库" />
                            <asp:BoundField DataField="Quantity" HeaderText="数量" />
                            <asp:BoundField DataField="LastLeaveDate" HeaderText="最后一次出库时间" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
