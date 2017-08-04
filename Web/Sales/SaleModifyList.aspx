<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaleModifyList.aspx.cs"
    Inherits="ZhangWei.Web.Sales.SaleModifyList" %>
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
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%">
            <tr>
                <td align="center" style="font-size: large">
                    请选择要修改的售货单<span style="font-size: x-large"><uc2:checkright id="checkright1" runat="server"
                        permissionid="4" />
                    </span>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;起始日期：<asp:TextBox ID="TextBox1" runat="server" onclick="WdatePicker({maxDate:'%y-%M-%d'})" class="Wdate"></asp:TextBox>
                    截止日期：<asp:TextBox ID="TextBox2" runat="server" onclick="WdatePicker({minDate:'#F{$dp.$D(\'TextBox1\')}',maxDate:'%y-%M-%d'})" class="Wdate"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Text="按日期查找" OnClick="Button1_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
                        RowStyle-HorizontalAlign="Center" CssClass="gridview_m">
                        <RowStyle HorizontalAlign="Center" />
                        <Columns>
                            <asp:BoundField DataField="TradeNo" HeaderText="单号" />
                            <asp:BoundField DataField="SaleDate" HeaderText="日期" />
                            <asp:BoundField DataField="GatheringWay" HeaderText="收款方式" />
                            <asp:BoundField DataField="Account" HeaderText="收款帐户" />
                            <asp:BoundField DataField="Address" HeaderText="送货地址" />
                            <asp:BoundField DataField="Name" HeaderText="开单人" />
                            <asp:BoundField DataField="StoreAdd" HeaderText="出货仓" />
                            <asp:BoundField DataField="CustName" HeaderText="客户名" />
                            <asp:HyperLinkField DataNavigateUrlFields="Sale_ID" DataNavigateUrlFormatString="/Sales/SaleDtlModify.aspx?Sale_ID={0}"
                                HeaderText="修改" Text="进入修改" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <webdiyer:aspnetpager id="AspNetPager2" runat="server" firstpagetext="首页" lastpagetext="尾页"
                        nextpagetext="下一页" onpagechanged="AspNetPager2_PageChanged" pageindexboxtype="TextBox"
                        prevpagetext="上一页" showpageindexbox="Auto" submitbuttontext="Go" textafterpageindexbox="页"
                        textbeforepageindexbox="转到" custominfohtml="第%CurrentPageIndex%页，共%PageCount%页，共%RecordCount%条，每页%PageSize%条"
                        showboxthreshold="10" showcustominfosection="Right" pagesize="20">
        </webdiyer:aspnetpager>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
