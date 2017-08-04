﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sell.aspx.cs" Inherits="ZhangWei.Web.Sales.sell" %>

<%@ Register Src="../Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        td { font-size: 9pt; }
        a { color: #000000; text-decoration: none; }
        #Button4 {}
    </style>
    <script src="/js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="/js/flexigrid.js" type="text/javascript"></script>
    <script src="/lhgdialog/lhgdialog.min.js?skin=chrome" type="text/javascript"></script>
    <link href="/Style/flexigrid.css" rel="stylesheet" type="text/css" />
    <link href="/Style/Style.css" rel="stylesheet" type="text/css" />
    <script src="/My97DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script type="text/javascript">
        document.onkeydown = function (e) {
            var event = event || window.event;
            if (event.keyCode == 13) {
                event.keyCode = 9;
            }
        }
        function SubmitBehavior() {
            $("#Button2").click();
        }
        $(document).ready(function () {
            $('.zhangwei').flexigrid();
            var newDate = new Date();
            var myDate = newDate.getFullYear() + "-" + (newDate.getMonth() + 1) + "-" + newDate.getDate() + " " + newDate.toLocaleTimeString();
            $("#TextBox1").val(myDate);
            $("#Button1").focus(function () {openDialog()});

        });

        function openDialog() {
            $.dialog({ title: '请选择商品',
                id: 'testID2',
                width: 850,
                height: 440,
                content: 'url:/ass/SearchProducts.aspx'
            });
        }
        function add_line(Product_ID, Name, ProductSpec_ID, Supplier_ID, Offering_Price, Price, Unit) {
            $('#zhangwei').append("<tr valign=\"middle\"><td><div style=\"width: 60px;\" class=\"eachId\">" + Product_ID + "</div></td><td><div style=\"width: 120px;\">" + Name + "</div></td><td><div style=\"width: 120px;\">" + ProductSpec_ID + "</div></td><td><div style=\"width: 90px;\">" + Supplier_ID + "</div></td><td><div style=\"width: 60px;\">" + Unit + "</div></td><td><div style=\"width: 100px;\"><input type=\"text\" class=\"proPrice\" value=\"" + Offering_Price.replace(new RegExp(" ", "g"), "") + "\" onkeyup=\"clearNoNum(this)\" /></div></td><td><div style=\"width: 100px;\"><input type=\"text\" class=\"proQty\" value=\"1\" onkeyup=\"clearNum(this,event)\" /></div></td><td><div class=\"eachTotal\" style=\"width: 100px;\">" + Offering_Price.replace(new RegExp(" ", "g"), "") + "</div></td><td><div style=\"width: 60px;\"><img src='/Images/delete1.gif' onclick='deleteItem(this)' /></div></td></tr>");
            //$("#HiddenField1").val($("#HiddenField1").val() + Product_ID + "|");
            countTotal();
            addHidden();
            couTot();
            var list = $.dialog.list;
            for (var i in list) {
                list[i].close();
            }
            $(".proPrice").focus();
            $(".proPrice").select();
        }
        function countTotal() {
            var qtyInput = $(".proQty");
            if (/msie/i.test(navigator.userAgent)) {                    //ie浏览器
                for (var i = 0; i < qtyInput.length; i++) {
                    $(".proQty")[i].onpropertychange = function () { handle(this) };
                    $(".proPrice")[i].onpropertychange = function () { handlePrice(this) };
//                    $(".proPrice")[i].onkeydown = function (e) {
//                        var theEvent = window.event || e;
//                        var code = theEvent.keyCode || theEvent.which;
//                        if (code == 13) {
//                            $(this).parent().parent().next().find(".proQty").focus();
//                        }
//                    }
                }

            } else {                                                                    //非ie浏览器，比如Firefox
                for (var i = 0; i < qtyInput.length; i++) {
                    $(".proQty")[i].addEventListener("input", function () { handle(this) }, false);
                    $(".proPrice")[i].addEventListener("input", function () { handlePrice(this) }, false);
                    $(".proPrice")[i].onkeydown = function (e) {
                        var theEvent = window.event || e;
                        var code = theEvent.keyCode || theEvent.which;
                        if (code == 13) {
                            $(this).parent().parent().next().find(".proQty").focus();
                        }
                    }
                }
            }
        }
        function handle(obj) {
            var price = $(obj).parent().parent().prev().find("input").val();
            var totoal = parseFloat(price * $(obj).val());
            $(obj).parent().parent().next().find("div").html(totoal.toFixed(3));
            couTot();
        }
        function handlePrice(obj) {
            var qty = $(obj).parent().parent().next().find("input").val();
            var totoal = parseFloat(qty * $(obj).val());
            $(obj).parent().parent().next().next().find("div").html(totoal.toFixed(3));
            couTot();
        }
        function couTot() {
            var totalPrice = 0;
            var eachTotal = $(".eachTotal");
            for (var i = 0; i < eachTotal.length; i++) {
                totalPrice += eval(eachTotal.eq(i).html());
            }
            $("#totalPrice").html(totalPrice.toFixed(3) + " 元");

            addHidden();
        }
        function addHidden() {
            var ids = $(".eachId");
            var qtys = $(".proQty");
            var Prices = $(".proPrice");
            $("#HiddenField1").empty();
            $("#HiddenField2").empty();
            $("#HiddenField3").empty();
            var bunchId = "";
            var bunchQty = "";
            var bunchPrice = "";
            for (var i = 0; i < ids.length; i++) {
                bunchId += ids.eq(i).html() + "|";
                bunchQty += qtys.eq(i).val() + "|";
                bunchPrice += Prices.eq(i).val() + "|";
            }
            $("#HiddenField1").val(bunchId.replace(new RegExp(" ", "g"), ""));
            $("#HiddenField2").val(bunchQty);
            $("#HiddenField3").val(bunchPrice);
        }
        function deleteItem(obj) {
            $.dialog({
                title: '提示信息',
                content: '确定删除该项吗？',
                ok: function () {
                    $(obj).parent().parent().parent().remove();
                    couTot();
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
        function clearNoNum(obj) {//验证数字和小数点
            //先把非数字的都替换掉，除了数字和.
            obj.value = obj.value.replace(/[^\d.]/g, "");
            //必须保证第一个为数字而不是.
            obj.value = obj.value.replace(/^\./g, "");
            //保证只有出现一个.而没有多个.
            obj.value = obj.value.replace(/\.{2,}/g, ".");
            //保证.只出现一次，而不能出现两次以上
            obj.value = obj.value.replace(".", "$#$").replace(/\./g, "").replace("$#$", ".");
            handlePrice(obj);
        }
        //        function clearNum(obj) {//纯数字
        //            obj.value = obj.value.replace(/[^\d]/g, "");
        //            handle(obj);
        //        }
        function clearNum(obj, event) {//验证数字和小数点
            var event = event || window.event;
            if (event.keyCode != 9 && event.keyCode != 13) {
                //先把非数字的都替换掉，除了数字和.
                obj.value = obj.value.replace(/[^\d.]/g, "");
                //必须保证第一个为数字而不是.
                obj.value = obj.value.replace(/^\./g, "");
                //保证只有出现一个.而没有多个.
                obj.value = obj.value.replace(/\.{2,}/g, ".");
                //保证.只出现一次，而不能出现两次以上
                obj.value = obj.value.replace(".", "$#$").replace(/\./g, "").replace("$#$", ".");
                handle(obj);
                obj.focus();
            }
            obj.onkeypress = function (event) {
                var event = event || window.event;
                if (event.keyCode == 13 || event.keyCode == 9) {
                    openDialog();
                }
            };
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="0" bordercolor="#000" cellpadding="0" cellspacing="0" style="height: 97px"
            valign="middle">
            <tr>
                <td align="center" colspan="6" height="70" style="font-size: xx-large">
                    销售开单<uc2:checkright ID="checkright1" runat="server" PermissionID="2" />
                </td>
            </tr>
            <tr height="40">
                <td align="right" width="10%">
                    销售时间：
                </td>
                <td width="20%">
                    <asp:TextBox ID="TextBox1" runat="server" onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"
                        class="Wdate"></asp:TextBox>
                </td>
                <td align="right" width="20%">
                    部门：
                </td>
                <td width="20%">
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                </td>
                <td align="right" width="10%">
                    售货人 ：
                </td>
                <td width="20%">
                    <asp:DropDownList ID="DropDownList2" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr height="40">
                <td align="right">
                    销售仓库：
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList3" runat="server">
                    </asp:DropDownList>
                </td>
                <td align="right">
                    收款方式：
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList6" runat="server">
                        <asp:ListItem Value="现金类">现金类</asp:ListItem>
                        <asp:ListItem Value="内部">内部</asp:ListItem>
                        <asp:ListItem Value="调货">调货</asp:ListItem>
                        <asp:ListItem>调出</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">
                    送货地址：
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr height="40">
                <td align="right">
                    客户：
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList5" runat="server">
                    </asp:DropDownList>
                </td>
                <td align="right">
                    收款帐户：
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList4" runat="server">
                        <asp:ListItem>调入</asp:ListItem>
                        <asp:ListItem>现金</asp:ListItem>
                        <asp:ListItem>转</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
        <table width="300" class="zhangwei" id="zhangwei">
            <thead>
                <tr valign="middle">
                    <th width="60">
                        商品编号
                    </th>
                    <th width="120">
                        商品名称
                    </th>
                    <th width="120">
                        规格
                    </th>
                    <th width="90">
                        厂商
                    </th>
                    <th width="60">
                        单位
                    </th>
                    <th width="100">
                        零售价
                    </th>
                    <th width="100">
                        数量
                    </th>
                    <th width="100">
                        合计（元）
                    </th>
                    <th width="60">
                        删除
                    </th>
                </tr>
            </thead>
            <tbody>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="6">
                        <input id="Button1" type="button" value="增加行" onclick="openDialog()" />
                    </td>
                    <td align="right">
                        <div style="float: right">
                            总计：</div>
                    </td>
                    <td>
                        <div id="totalPrice">
                            0</div>
                    </td>
                </tr>
            </tfoot>
        </table>
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="HiddenField2" runat="server" />
        <asp:HiddenField ID="HiddenField3" runat="server" />
        <div style="text-align: center">
            <%--<input id="Button4" type="button" value="保 存" onclick="SubmitBehavior()" />--%>
            <asp:Button
                ID="Button4" runat="server" Text="" Height="0px" Width="16px" 
                style="border:0;background:#FFF" /><asp:Button
                ID="Button2" runat="server" Text="保 存" Height="30px" Width="120px" Font-Size="15pt"
                OnClick="Button2_Click" />
            <input id="Button3" onclick="javascript:window.location='/Sales/SaleReport.aspx'"
                type="button" value="取消" /></div>
    </div>
    </form>
</body>
</html>
