<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaleDetail.aspx.cs" Inherits="ZhangWei.Web.Sales.SaleDetail" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Style/Style.css" rel="stylesheet" type="text/css" />

    <script src="../js/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script src="/js/LodopFuncs.js" type="text/javascript"></script>

    <object id="LODOP" classid="clsid:2105C259-1E0C-4534-8141-A753534CB4CA" Width="0"
        height="0">
        <embed id="LODOP_EM" type="application/x-print-lodop" Width="0" height="0"></embed>
    </object>

    <script language="javascript" type="text/javascript">


        var LODOP; //声明为全局变量
        function Button1_onclick() {
            //var printArea = $("#printArea").html();
            //var innerHTML  = document.body.innerHTML;
            //document.body.innerHTML = document.getElementById("printArea").innerHTML;
            $("#Button1").hide();
            $("#Button3").hide();
            window.print();
            //document.body.innerHTML = innerHTML; 
        }
        function doPrint(startLine, endLine) {
            bdhtml = window.document.body.innerHTML;
            sprnstr = startLine;
            eprnstr = endLine;
            prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr));
            prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
            window.document.body.innerHTML = prnhtml;
            window.print();
            location.reload();
        }
        function printTable() {
            //            LODOP = getLodop(document.getElementById('LODOP'), document.getElementById('LODOP_EM'));
            //            LODOP.PRINT_INIT("打印控件功能演示_Lodop功能_自定义纸张");
            //            LODOP.SET_PRINT_PAGESIZE(1, 0, 0, "A5");
            //            LODOP.ADD_PRINT_TABLE("2%", "1%", "96%", "98%", document.getElementById("tableContend").innerHTML);
            //            LODOP.SET_PREVIEW_WINDOW(0, 0, 0, 800, 600, "");
            //            LODOP.PREVIEW();
            LODOP = getLodop(document.getElementById('LODOP'), document.getElementById('LODOP_EM'));
            LODOP.PRINT_INIT("打印控件功能演示_Lodop功能_打印表格");
            //            LODOP.ADD_PRINT_HTM(88, 5, "490", "100%", document.getElementById("printTop").innerHTML);
            //            LODOP.ADD_PRINT_TABLE(500, 5, 500, "80%", document.getElementById("tableContend").innerHTML);
            //LODOP.ADD_PRINT_HTM(30, 35, "520", "90%", document.documentElement.innerHTML);
            LODOP.ADD_PRINT_HTM(30, 30, 490, "90%", document.getElementById("printArea").innerHTML);

            LODOP.SET_PRINT_PAGESIZE(1, 490, 0, "A5");
            LODOP.PREVIEW();
        }
        function printOdd() {
            CreatePrintPage();
            LODOP.PRINT();
        }
        function printPre() {
            CreatePrintPage();
            LODOP.PREVIEW();
        }
        function CreatePrintPage() {
            LODOP = getLodop(document.getElementById('LODOP'), document.getElementById('LODOP_EM'));
            LODOP.PRINT_INIT("打印售货单");
            var blankRow = $("<tr style='height:169px; font-weight: 700; font-size: 13px;'valign='bottom' align='center'><td nowrap='nowrap'>商品号</td><td>货品名称</td><td>规格</td><td>单位</td><td>数量</td><td>单价</td><td>货款</td></tr>");
            var bottomText = $("#tableBottom").clone();
            var tableBottom = $("<tr><td colspan='7'>" + bottomText.html() + "</td></tr>");
            var dataTable = $("#tableContend").clone();
            dataTable.find("tbody").prepend(blankRow);
            dataTable.find("tbody").append(tableBottom);
            LODOP.ADD_PRINT_TABLE(30, 11, 490, "90%", dataTable.html());
            LODOP.ADD_PRINT_HTM(30, 10, 490, "90%", $("#printTop").html());
            LODOP.SET_PRINT_PAGESIZE(1, 0, 0, "A5");
            LODOP.SET_PREVIEW_WINDOW(0, 2, 1, 600, 900, "销售单打印预览.打印该销售单")
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 490px; margin: 0" id="printArea">
        <div id="printTop">
            <div style="text-align: center; font-size: 24px">
                现款销售单
            </div>
            <table Width="490" style="font-size:13px">
                <tr>
                    <td Width="70">
                        开单日期：
                    </td>
                    <td Width="120">
                        <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td Width="70">
                        单　　号：
                    </td>
                    <td  Width="210">
                        <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        出&nbsp;货&nbsp;仓：
                    </td>
                    <td>
                        <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        整单折扣：
                    </td>
                    <td>
                        <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        收款方式：
                    </td>
                    <td>
                        <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        收款帐户：
                    </td>
                    <td>
                        <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        票　　号：
                    </td>
                    <td>
                        <asp:Label ID="Label16" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        送货地址：
                    </td>
                    <td>
                        <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>
            <table cellspacing="0" cellpadding="3" rules="all" border="1" style="border-color: #000;
                border-width: 1px; border-style: solid; border-collapse: collapse; margin-bottom: -1px; font-size:12px;"
                Width="490">
                <tr>
                    <td rowspan="2" align="center" valign="middle" Width="46px">
                        购货<br />
                        单位
                    </td>
                    <td align="center" Width="60px">
                        名称
                    </td>
                    <td>
                        &nbsp;
                        <asp:Label ID="Label18" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" Width="60px">
                        地址、电话
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <div id="tableContend">
            <table cellspacing="0" cellpadding="3" rules="all" border="1" style="border-color: #000;
                border-width: 1px; border-style: solid; border-collapse: collapse; font-size: 12px"
                Width="490">
                <thead id="tableHead">
                    <tr align="center" style="font-weight: 700; font-size: 13px">
                        <td Width="100">
                            商品号
                        </td>
                        <td Width="240">
                            货品名称
                        </td>
                        <td Width="150">
                            规格
                        </td>
                        <td Width="150">
                            单位
                        </td>
                        <td Width="150">
                            数量
                        </td>
                        <td Width="100">
                            单价
                        </td>
                        <td Width="100">
                            货款
                        </td>
                    </tr>
                </thead>
                <tbody id="tableBody">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td align="center" style="padding:8px 0 8px 0">
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("Product_ID")%>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="Label7" runat="server" Text='<%#Eval("SpecName")%>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="Label8" runat="server" Text='<%#Eval("UnitName")%>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="Label4" runat="server" Text='<%#Math.Round(Convert.ToDecimal(Eval("Quantity")),3)%>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="Label5" runat="server" Text='<%#Math.Round(Convert.ToDecimal(Eval("Price")),3)%>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="Label6" runat="server" Text='<%#Eval("Product_ID")%>'></asp:Label>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                <%--<tfoot>
                    <tr>
                        <td colspan="7">
                        </td>
                    </tr>
                </tfoot>--%>
            </table>
        </div>
        <div id="tableBottom">
            <table style="font-size: 12px">
                <tr>
                    <td Width="43">
                        合计：
                    </td>
                    <td Width="84">
                        <asp:Label ID="TotalPrice" runat="server" Text="Label" Font-Bold="True"></asp:Label>
                        元
                    </td>
                    <td Width="101">
                        &nbsp;
                    </td>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style3" colspan="2">
                        摘要
                    </td>
                    <td colspan="2">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        大写：<asp:Label ID="Label9" runat="server" Text="Label" Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style3" colspan="2">
                        仓管员：
                    </td>
                    <td colspan="2">
                        业务员：
                    </td>
                    <td>
                        开单人：
                        <asp:Label ID="Label19" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <p>
        <%--<input id="Button1" type="button" value="打印" onclick="return Button1_onclick()" />--%>
        <input id="Button3" onclick="javascript:history.go(-1)" type="button" value="返回" />
        <input id="Button2" type="button" value="打印预览" onclick="printPre()" />
        <input id="Button1" type="button" value="打印" onclick="printOdd()" />
    </p>
    </form>
</body>
</html>
