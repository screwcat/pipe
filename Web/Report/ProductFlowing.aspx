<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductFlowing.aspx.cs"
    Inherits="ZhangWei.Web.Report.ProductFlowing" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="/js/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script src="/lhgdialog/lhgdialog.min.js?skin=chrome" type="text/javascript"></script>

    <link href="/Style/flexigrid.css" rel="stylesheet" type="text/css" />
    <link href="/Style/Style.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript">
// <!CDATA[

        function Button1_onclick() {
            $.dialog({ title: '请选择商品',
                id: 'testID2',
                width: 850,
                height: 440,
                content: 'url:/ass/SearchProducts.aspx'
            });
        }

        function add_line(Product_ID, Name, ProductSpec_ID, Supplier_ID, Offering_Price, Price, Unit) {
            var list = $.dialog.list;
            for (var i in list) {
                list[i].close();
            }
            $("#HiddenField1").val(Product_ID);
            $("#Button2").click();

        }

// ]]>
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table Width="100%">
            <tr>
                <td align="center" style="font-size: x-large">
                    查询出入记录
                </td>
            </tr>
            <tr>
                <td>
                    <input id="Button1" type="button" value="选择商品" onclick="return Button1_onclick()" /><asp:Panel
                        ID="Panel1" runat="server" Visible="False">
                        商品当前库存情况：
                        <table id="searchResu" cellspacing="0" cellpadding="0" rules="all" border="1" style="border-color: #000;
                            border-width: 1px; border-style: solid; width: 100%; border-collapse: collapse;">
                            <tr align="center" style="font-weight: 700; background: #CCC;">
                                <td Width="60">
                                    编号
                                </td>
                                <td Width="100">
                                    分类
                                </td>
                                <td Width="140">
                                    名称
                                </td>
                                <td Width="80">
                                    拼音
                                </td>
                                <td Width="80">
                                    拼音简写
                                </td>
                                <td Width="70">
                                    规格
                                </td>
                                <td Width="60">
                                    单位
                                </td>
                                <td Width="60">
                                    零售价
                                </td>
                                <td Width="150">
                                    供应商
                                </td>
                                <td Width="150">
                                    仓库名
                                </td>
                                <td Width="150">
                                    库存
                                </td>
                            </tr>
                            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                    <tr align="center">
                                        <td>
                                            <%#Eval("Product_ID")%>
                                        </td>
                                        <td>
                                            <%#Eval("ProductListName")%>
                                        </td>
                                        <td>
                                            <%#Eval("Name")%>
                                        </td>
                                        <td>
                                            <%#Eval("spell")%>
                                        </td>
                                        <td>
                                            <%#Eval("s_spell")%>
                                        </td>
                                        <td>
                                            <%#Eval("SpecName")%>
                                        </td>
                                        <td>
                                            <%#Eval("UnitName")%>
                                        </td>
                                        <td>
                                            <%#Eval("Offering_Price")%>
                                        </td>
                                        <td>
                                            <%#Eval("SupplierName")%>
                                        </td>
                                        <td>
                                            <%#Eval("Address")%>
                                        </td>
                                        <td>
                                            <%#Eval("Quantity")%>
                                        </td>
                                        <%--<td style="display:none">
                                        <%#Eval("Price")%>
                                    </td>--%>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </asp:Panel>
                    <br />
                    <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" CssClass="gridview_m">
                        <Columns>
                            <asp:BoundField DataField="Date" DataFormatString="{0:yyyy年M月d日 H:mm:ss}" HeaderText="日期">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="action" HeaderText="事件">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Quantity" HeaderText="数量">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Price" HeaderText="单价">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Address" HeaderText="仓库">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ID" HeaderText="单号">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="总库存" >
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                    &nbsp;<asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" Style="display: none" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
