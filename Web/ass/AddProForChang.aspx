<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProForChang.aspx.cs"
    Inherits="ZhangWei.Web.ass.AddProForChang" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Style/Style.css" rel="stylesheet" type="text/css" />

    <script src="../js/jquery-1.4.3.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function() {
            siftSelect();
            $(".proClass").change(function() {
                siftSelect();
            });
            $("#TextBox3").focus();
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
        function transmit(obj) {
            window.parent.addForChange($(obj).find("td").eq(0).html().replace(/\s+/g, ""), $(obj).find("td").eq(2).html(), $(obj).find("td").eq(5).html(), $(obj).find("td").eq(8).html(), $(obj).find("td").eq(7).html().replace(/\s+/g, ""), $(obj).find("td").eq(9).html(), $(obj).find("td").eq(6).html());
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table id="sera" width="800" align="center">
            <tr align="center" valign="middle">
                <td width="80">
                    编号
                </td>
                <td width="300">
                    分类
                </td>
                <td width="100">
                    规格</td>
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
                    <asp:TextBox ID="TextBox5" runat="server" Width="100px"></asp:TextBox>
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
                    &nbsp;</td>
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
                <td colspan="6">
                    <table id="searchResu" cellspacing="0" cellpadding="0" rules="all" border="1" style="border-color: #000;
                        border-width: 1px; border-style: solid; width: 100%; border-collapse: collapse;">
                        <tr align="center" style="font-weight: 700; background: #CCC;">
                            <td width="60">
                                编号
                            </td>
                            <td width="100">
                                分类
                            </td>
                            <td width="140">
                                名称
                            </td>
                            <td width="80">
                                简称
                            </td>
                            <td width="80">
                                拼音
                            </td>
                            <td width="70">
                                规格
                            </td>
                            <td width="60">
                                单位
                            </td>
                            <td width="60">
                                零售价
                            </td>
                            <td width="90">
                                供应商
                            </td>
                        </tr>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <tr align="center" onclick="transmit(this);">
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
                                        <%#Eval("shortname")%>
                                    </td>
                                    <td>
                                        <div style="width: 80px; overflow: hidden">
                                            <%#Eval("spell")%></div>
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
                                    <td style="display: none">
                                        <%#Eval("Price")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="尾页"
                        NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged" PageIndexBoxType="TextBox"
                        PrevPageText="上一页" ShowPageIndexBox="Auto" SubmitButtonText="Go" TextAfterPageIndexBox="页"
                        TextBeforePageIndexBox="转到" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，共%RecordCount%条，每页%PageSize%条"
                        ShowBoxThreshold="10" ShowCustomInfoSection="Right" PageSize="40">
                    </webdiyer:AspNetPager>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
