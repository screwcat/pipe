<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaleDtlModify.aspx.cs"
    Inherits="ZhangWei.Web.Sales.SaleDtlModify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="/js/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script src="/lhgdialog/lhgdialog.min.js?skin=chrome" type="text/javascript"></script>

    <link href="/Style/Style.css" rel="stylesheet" type="text/css" />

    <script src="/My97DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script type="text/javascript">

        function modifyInfo(obj) {
            var modiRow = $("#editTr");
            var clickRow = $(obj).parent().parent();
            modiRow.insertAfter(clickRow);
            var allRows = clickRow.parent().find("tr");
            allRows.show();
            $("#btnProId").val(clickRow.find("td").eq(0).html());
            $("#proName").html(clickRow.find("td").eq(1).html());
            $("#proPect").html(clickRow.find("td").eq(2).html());
            $("#proUnit").html(clickRow.find("td").eq(3).html());
            $("#proQty").val(clickRow.find("td").eq(4).html());
            $("#proPrice").val(clickRow.find("td").eq(5).html());
            $("#totaPrice").html(clickRow.find("td").eq(6).html());
            clickRow.hide();
        }
        function cancelEdit(obj) {
            $("#editTr").prev().show();
            $("#editTable").append($("#editTr"));
        }
        function openDialog() {
            $.dialog({ title: '请选择商品',
                id: 'testID2',
                width: 850,
                height: 440,
                content: 'url:/ass/SearchProducts.aspx'
            });
        }
        function add_line(Product_ID, Name, ProductSpec_ID, Supplier_ID, Offering_Price, Price, Unit) {
            $("#btnProId").val(Product_ID.replace(/\s+/g, ""));
            $("#proName").html(Name);
            $("#proPect").html(ProductSpec_ID);
            $("#proUnit").html(Unit);
            $("#proQty").val(1);
            $("#proPrice").val(Offering_Price.replace(/\s+/g, ""));
            $("#totaPrice").val(Offering_Price.replace(/\s+/g, ""));
            handlePrice();
            var list = $.dialog.list;
            for (var i in list) {
                list[i].close();
            }
        }
        function addHidden() {
            var ids = $(".eachId");
            var qtys = $(".eachQty");
            var Prices = $(".eachPrice");
            $("#newId").empty();
            $("#newPrice").empty();
            $("#newQty").empty();
            var bunchId = "";
            var bunchQty = "";
            var bunchPrice = "";
            for (var i = 0; i < ids.length; i++) {
                bunchId += ids.eq(i).html() + "|";
                bunchQty += qtys.eq(i).html() + "|";
                bunchPrice += Prices.eq(i).html() + "|";
            }
            $("#newId").val(bunchId);
            $("#newPrice").val(bunchPrice);
            $("#newQty").val(bunchQty);
        }
        function changRow(obj) {
            var clickRow = $("#editTr").prev();
            clickRow.find("td").eq(0).html($("#btnProId").val());
            clickRow.find("td").eq(1).html($("#proName").html());
            clickRow.find("td").eq(2).html($("#proPect").html());
            clickRow.find("td").eq(3).html($("#proUnit").html());
            clickRow.find("td").eq(4).html($("#proQty").val());
            clickRow.find("td").eq(5).html($("#proPrice").val());
            clickRow.find("td").eq(6).html($("#totaPrice").html());
            clickRow.show();
            $("#editTable").append($("#editTr"));
            addHidden();
            calcTotal();
        }
        function deleteRow(obj) {
            $.dialog({
                title: '提示信息',
                content: '确定删除该项吗？',
                ok: function() {
                    $(obj).parent().parent().remove();
                    addHidden();
                    this.close();
                    return false;
                },
                max: false,
                min: false,
                lock: true,
                width: 270,
                height: 80,
                cancelVal: '关闭',
                cancel: true /*为true等价于function(){}*/
            });
        }
        function addRow() {
            $.dialog({ title: '请选择商品',
                id: 'testID2',
                width: 850,
                height: 440,
                content: 'url:/ass/AddProForChang.aspx'
            });
        }
        function addForChange(Product_ID, Name, ProductSpec_ID, Supplier_ID, Offering_Price, Price, Unit) {
            $("#GridView1").append($("#addTr"));
            $("#btnProId1").val(Product_ID.replace(/\s+/g, ""));
            $("#proName1").html(Name);
            $("#proPect1").html(ProductSpec_ID);
            $("#proUnit1").html(Unit);
            $("#proQty1").val(1);
            $("#proPrice1").val(Offering_Price.replace(/\s+/g, ""));
            $("#totaPrice1").val(Offering_Price.replace(/\s+/g, ""));
            handlePrice();
            var list = $.dialog.list;
            for (var i in list) {
                list[i].close();
            }
        }
        function inserRow(obj) {
            var addRow = $("#addTr");
            $("#GridView1").append("<tr align='center'><td class='eachId'>" + $("#btnProId1").val() + "</td><td>" + $("#proName1").html() + "</td><td>" + $("#proPect1").html() + "</td><td>" + $("#proUnit1").html() + "</td><td class='eachQty'>" + $("#proQty1").val() + "</td><td class='eachPrice'>" + $("#proPrice1").val() + "</td><td class='eachTotal'>" + $("#totaPrice1").html() + "</td><td style='width:90px;'><a href='javascript:void(0)' onclick='modifyInfo(this)'>修改</a></td><td style='width:37px;'><img src='/Images/delete1.gif' title='删除该行' onclick='deleteRow(this)'></td></tr>");
            $("#addTable").append($("#addTr"));
            addHidden();
            calcTotal();
        }
        function cancelAdd(obj) {
            $("#addTable").append($("#addTr"));
        }
        function clearNoNum(obj) {
            obj.value = obj.value.replace(/[^\d.]/g, "");
            obj.value = obj.value.replace(/^\./g, "");
            obj.value = obj.value.replace(/\.{2,}/g, ".");
            obj.value = obj.value.replace(".", "$#$").replace(/\./g, "").replace("$#$", ".");
            handlePrice();
        }
        function clearNoNum1(obj) {
            obj.value = obj.value.replace(/[^\d.]/g, "");
            obj.value = obj.value.replace(/^\./g, "");
            obj.value = obj.value.replace(/\.{2,}/g, ".");
            obj.value = obj.value.replace(".", "$#$").replace(/\./g, "").replace("$#$", ".");
            handlePrice();
        }
        function handlePrice() {
            $("#totaPrice").html(($("#proQty").val() * $("#proPrice").val()).toFixed(3));
            $("#totaPrice1").html(($("#proQty1").val() * $("#proPrice1").val()).toFixed(3));
        }
        function calcTotal() {
            var eachTotal = $(".eachTotal");
            var totalPrice = 0;
            for (var i = 0; i < eachTotal.length; i++) {
                totalPrice += eval(eachTotal.eq(i).html());
            }
            $("#Label1").html(totalPrice);
            $("#Label2").html("");
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%">
            <tr>
                <td align="center" style="font-size: large" colspan="4">
                    修改售货单
                </td>
            </tr>
            <tr>
                <td align="right">
                    售货仓库：</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                </td>
                <td align="right">
                    部门：</td>
                <td>
                    <asp:DropDownList ID="DropDownList2" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    收款方式：</td>
                <td>
                    <asp:DropDownList ID="DropDownList6" runat="server">
                        <asp:ListItem Value="现金类">现金类</asp:ListItem>
                        <asp:ListItem Value="内部">内部</asp:ListItem>
                        <asp:ListItem Value="调货">调货</asp:ListItem>
                        <asp:ListItem>调出</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">
                    客户：</td>
                <td>
                    <asp:DropDownList ID="DropDownList5" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    收款帐户：</td>
                <td>
                    <asp:DropDownList ID="DropDownList4" runat="server">
                        <asp:ListItem>调入</asp:ListItem>
                        <asp:ListItem>现金</asp:ListItem>
                        <asp:ListItem>转</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">
                    送货地址：</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="GridView1" runat="server" cellpadding="0" rules="all" border="1"
                        Style="border-color: #000; border-width: 1px; border-style: solid; width: 100%;
                        border-collapse: collapse;" AutoGenerateColumns="False" CssClass="gridview_m">
                        <Columns>
                            <asp:BoundField DataField="Product_ID" HeaderText="商品号">
                                <ItemStyle HorizontalAlign="Center" CssClass="eachId" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Name" HeaderText="货品名称">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SpecName" HeaderText="规格">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="UnitName" HeaderText="单位">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Quantity" HeaderText="数量">
                                <ItemStyle HorizontalAlign="Center" CssClass="eachQty" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Price" HeaderText="单价">
                                <ItemStyle HorizontalAlign="Center" CssClass="eachPrice" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="货款">
                                <ItemStyle HorizontalAlign="Center" CssClass="eachTotal" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="编辑">
                                <ItemTemplate>
                                    <a href="javascript:void(0)" onclick="modifyInfo(this)">修改</a>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="90px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="删除">
                                <ItemTemplate>
                                    <img alt="删除行" src="../Images/delete1.gif" title="删除该行" onclick="deleteRow(this)" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="37px" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table cellspacing="0" cellpadding="0" rules="all" border="1" id="GridView1" style="border-collapse: collapse;
                                border-color: #000; border-width: 1px; border-style: solid; width: 100%; border-collapse: collapse;">
                                <thead>
                                    <tr>
                                        <th scope="col">
                                            商品号
                                        </th>
                                        <th scope="col">
                                            货品名称
                                        </th>
                                        <th scope="col">
                                            规格
                                        </th>
                                        <th scope="col">
                                            单位
                                        </th>
                                        <th scope="col">
                                            数量
                                        </th>
                                        <th scope="col">
                                            单价
                                        </th>
                                        <th scope="col">
                                            货款
                                        </th>
                                        <th scope="col">
                                            编辑
                                        </th>
                                        <th scope="col">
                                            删除
                                        </th>
                                    </tr>
                                </thead>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <table id="editTable" style="display: none">
                        <tr id="editTr" align="center">
                            <td>
                                <input id="btnProId" type="button" value="button" onclick="openDialog()" />
                            </td>
                            <td>
                                <span id="proName">货品名称</span>
                            </td>
                            <td>
                                <span id="proPect">规格</span>
                            </td>
                            <td>
                                <span id="proUnit">单位</span>
                            </td>
                            <td>
                                <input id="proQty" type="text" style="width: 80px" onkeyup="clearNoNum(this)" />
                            </td>
                            <td>
                                <input id="proPrice" type="text" style="width: 80px" onkeyup="clearNoNum1(this)" />
                            </td>
                            <td>
                                <span id="totaPrice">0</span>
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <input id="Button1" type="button" value="确定" onclick="changRow(this)" />
                                        </td>
                                        <td>
                                            <input id="Button4" type="button" value="取消" onclick="cancelEdit(this)" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table id="addTable" style="display: none">
                        <tr id="addTr" align="center">
                            <td>
                                <input id="btnProId1" type="button" value="button" onclick="addRow()" />
                            </td>
                            <td>
                                <span id="proName1">货品名称</span>
                            </td>
                            <td>
                                <span id="proPect1">规格</span>
                            </td>
                            <td>
                                <span id="proUnit1">单位</span>
                            </td>
                            <td>
                                <input id="proQty1" type="text" style="width: 80px" onkeyup="clearNoNum(this)" />
                            </td>
                            <td>
                                <input id="proPrice1" type="text" style="width: 80px" onkeyup="clearNoNum1(this)" />
                            </td>
                            <td>
                                <span id="totaPrice1">0</span>
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <input id="Button2" type="button" value="确定" onclick="inserRow(this)" />
                                        </td>
                                        <td>
                                            <input id="Button7" type="button" value="取消" onclick="cancelAdd(this)" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    共计：<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    元，大写：<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    <asp:HiddenField ID="oldId" runat="server" />
                    <asp:HiddenField ID="oldPrice" runat="server" />
                    <asp:HiddenField ID="oldQty" runat="server" />
                    <asp:HiddenField ID="newId" runat="server" />
                    <asp:HiddenField ID="newPrice" runat="server" />
                    <asp:HiddenField ID="newQty" runat="server" />
                    <br />
                    <input id="Button6" type="button" value="增加行" onclick="addRow()" /><asp:Button ID="Button5"
                        runat="server" Text="确定" Height="28px" OnClick="Button5_Click" Width="82px" />
                    <input id="Button3" onclick="javascript:history.go(-1)" type="button" value="返回" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
