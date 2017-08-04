<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductView.aspx.cs" Inherits="ZhangWei.Web.BaseInfo.Product.ProductView" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Style/Style.css" rel="stylesheet" type="text/css" />

    <script src="/js/jquery-1.4.3.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function() {
            siftSelect();
            $(".proClass").change(function() {
                siftSelect();
            });
            //$("#proList [value = " + selected + "]").attr("selected", "selected");
        });

        function siftSelect() {
            $.ajax({
                type: "get",
                cache: false,
                url: "/ajax/ajax.ashx",
                data: { Command: "getSelect", classId: $(".proClass").val() },
                dataType: "json",
                beforeSend: function() {

                },
                success: function(data) {
                    $("#proList").empty();
                    if (data.data.length == 0) {
                        $("#proList").append("<option value=0>—细分类—</option>");
                        return;
                    }
                    $("#proList").append("<option value=0>—请选择—</option>");
                    for (var i = 0; i < data.data.length; i++) {
                        if ($("#HiddenField1").val() == data.data[i].value) {
                            $("#proList").append("<option value=" + data.data[i].value + " selected='selected'>" + data.data[i].text + "</option>");
                        } else {
                            $("#proList").append("<option value=" + data.data[i].value + ">" + data.data[i].text + "</option>");
                        }
                    }
                },
                complete: function() {

                }
            });
        }
//        function transmit(obj) {
//            window.parent.add_line($(obj).find("td").eq(0).html(), $(obj).find("td").eq(2).html(), $(obj).find("td").eq(5).html(), $(obj).find("td").eq(8).html(), $(obj).find("td").eq(7).html(), $(obj).find("td").eq(9).html());
//        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table id="sera" align="center">
            <tr align="center" valign="middle">
                <td width="80">
                    编号
                </td>
                <td width="300">
                    分类
                </td>
                <td width="120">
                    品名
                </td>
                <td width="80">
                    拼音首字母
                </td>
                <td width="80">
                    全拼
                </td>
            </tr>
            <tr align="center" valign="middle">
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Width="80px"></asp:TextBox>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList2" runat="server" class="proClass" AppendDataBoundItems="True">
                        <asp:ListItem Value="0">—总分类—</asp:ListItem>
                    </asp:DropDownList>
                    <select id="proList" name="proList">
                        <option value="0">—细分类—</option>
                    </select>
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Width="120px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Width="80px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server" Width="100px"></asp:TextBox>
                </td>
            </tr>
            <tr align="center" valign="middle">
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="查找" OnClick="Button1_Click" />
                </td>
            </tr>
            <tr height="100" align="center" valign="top">
                <td colspan="5">
                    <table id="searchResu" cellspacing="0" cellpadding="0" rules="all" border="1" style="border-color: #000;
                        border-width: 1px; border-style: solid; width: 100%; border-collapse: collapse;">
                        <thead>
                            <tr>
                                <th>
                                    编号
                                </th>
                                <th>
                                    品名
                                </th>
                                <th>
                                    简称
                                </th>
                                <th>
                                    规格
                                </th>
                                <th>
                                    类别
                                </th>
                                <th>
                                    单位
                                </th>
                                <th>
                                    拼音
                                </th>
                                <th>
                                    供应商
                                </th>
                                <th>
                                    进价
                                </th>
                                <th>
                                    零售价
                                </th>
                                <th>
                                    仓库
                                </th>
                                <th>
                                    库存
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                    <tr align="center">
                                        <td>
                                            <%#Eval("Product_ID")%>
                                        </td>
                                        <td>
                                            <%#Eval("Name")%>
                                        </td>
                                        <td>
                                            <%#Eval("shortname")%>
                                        </td>
                                        <td>
                                            <%#Eval("SpecName")%>
                                        </td>
                                        <td>
                                            <%#Eval("ProductListName")%>
                                        </td>
                                        <td>
                                            <%#Eval("UnitName")%>
                                        </td>
                                        <td>
                                            <%#Eval("spell")%>
                                        </td>
                                        <td>
                                            <%#Eval("SupplierName")%>
                                        </td>
                                        <td>
                                            <%#Eval("Price")%>
                                        </td>
                                        <td>
                                            <%#Eval("Offering_Price")%>
                                        </td>
                                        <td>
                                            <%#Eval("Address")%>
                                        </td>
                                        <td>
                                            <%#Eval("Quantity")%>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="尾页"
                        NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged" PageIndexBoxType="TextBox"
                        PrevPageText="上一页" ShowPageIndexBox="Auto" SubmitButtonText="Go" TextAfterPageIndexBox="页"
                        TextBeforePageIndexBox="转到" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，共%RecordCount%条，每页%PageSize%条"
                        ShowBoxThreshold="10" ShowCustomInfoSection="Right">
                    </webdiyer:AspNetPager>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
