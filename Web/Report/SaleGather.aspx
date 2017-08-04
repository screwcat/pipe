<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaleGather.aspx.cs" Inherits="ZhangWei.Web.Sales.SaleGather" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="../js/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script src="../lhgdialog/lhgdialog.min.js?skin=chrome" type="text/javascript"></script>

    <link href="../Style/Style.css" rel="stylesheet" type="text/css" />

    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>

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
                data: { Command: "SaleGatToExcel", according: $("#DropDownList1").val(), BeginDate: $("#TextBox1").val(), EndDate: $("#TextBox2").val() },
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
                    销售汇总
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;起始日期：<asp:TextBox ID="TextBox1" runat="server" onclick="WdatePicker({maxDate:'%y-%M-%d'})"
                        class="Wdate"></asp:TextBox>
                    截止日期：<asp:TextBox ID="TextBox2" runat="server" onclick="WdatePicker({minDate:'#F{$dp.$D(\'TextBox1\')}',maxDate:'%y-%M-%d'})"
                        class="Wdate"></asp:TextBox>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem Value="1">按品种</asp:ListItem>
                        <asp:ListItem Value="2">按单号</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="Button1" runat="server" Text="生成报表" OnClick="Button1_Click" />
                    <input id="Button3" type="button" value="导出到Excel" onclick="ExpToExcel()" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
                        CellPadding="0" BorderWidth="1px" RowStyle-HorizontalAlign="Center" CssClass="gridview_m">
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
                            <asp:BoundField DataField="Name" HeaderText="类别" />
                            <asp:BoundField DataField="SpecName" HeaderText="规格" />
                            <asp:BoundField DataField="UnitName" HeaderText="单位" />
                            <asp:BoundField DataField="TotalQty" HeaderText="销售总数量" />
                        </Columns>
                    </asp:GridView>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="100%"
                        CellPadding="0" BorderWidth="1px" RowStyle-HorizontalAlign="Center" CssClass="gridview_m">
                        <RowStyle HorizontalAlign="Center" />
                        <Columns>
                            <asp:TemplateField HeaderText="行号">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text="<%#Container.DataItemIndex + 1 %>"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="TradeNo" HeaderText="售货单号" />
                            <asp:BoundField DataField="StoreAdd" HeaderText="售货仓库" />
                            <asp:BoundField DataField="TrCount" HeaderText="包含条数" />
                            <asp:BoundField DataField="totalPrice" HeaderText="总价" />
                            <asp:BoundField DataField="GatheringWay" HeaderText="收款方式" />
                            <asp:BoundField DataField="Account" HeaderText="收款帐户" />
                            <asp:BoundField DataField="Address" HeaderText="送货地址" />
                            <asp:BoundField DataField="SaleDate" HeaderText="售货日期" />
                            <asp:HyperLinkField DataNavigateUrlFields="Sale_ID" DataNavigateUrlFormatString="/Sales/SaleDetail.aspx?Sale_ID={0}"
                                HeaderText="详细" Text="查看" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
