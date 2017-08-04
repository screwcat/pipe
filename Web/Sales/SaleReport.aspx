<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaleReport.aspx.cs" Inherits="ZhangWei.Web.Report.SaleReport" %>

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
        $(document).ready(function() {
            //            var newDate = new Date();
            //            var myDate = newDate.getFullYear() + "-" + (newDate.getMonth() + 1) + "-" + newDate.getDate();
            //            $("#TextBox1").val(myDate);
            //            $("#TextBox2").val(myDate);
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%">
            <tr>
                <td align="center" style="font-size: large">
                    销售记录<span style="font-size: x-large"><uc2:checkright ID="checkright1" runat="server"
                        PermissionID="4" />
                    </span>
                </td>
            </tr>
            <tr style="display:none">
                <td>
                    起始日期：<asp:TextBox ID="TextBox1" runat="server" onclick="WdatePicker({maxDate:'%y-%M-%d'})" class="Wdate"></asp:TextBox>
                    截止日期：<asp:TextBox ID="TextBox2" runat="server" onclick="WdatePicker({minDate:'#F{$dp.$D(\'TextBox1\')}',maxDate:'%y-%M-%d'})" class="Wdate"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Text="按日期查找" OnClick="Button1_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    <asp:Button ID="Button2" runat="server" Text="按单号查找" onclick="Button2_Click" />
                    (支持模糊查找)</td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
                        cellpadding="0" BorderWidth="1px" RowStyle-HorizontalAlign="Center" CssClass="gridview_m">
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
                            <asp:HyperLinkField DataNavigateUrlFields="Sale_ID" DataNavigateUrlFormatString="/Sales/SaleDetail.aspx?Sale_ID={0}"
                                HeaderText="详细" Text="查看" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
        <webdiyer:AspNetPager ID="AspNetPager2" runat="server" FirstPageText="首页" LastPageText="尾页"
            NextPageText="下一页" OnPageChanged="AspNetPager2_PageChanged" PageIndexBoxType="TextBox"
            PrevPageText="上一页" ShowPageIndexBox="Auto" SubmitButtonText="Go" TextAfterPageIndexBox="页"
            TextBeforePageIndexBox="转到" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，共%RecordCount%条，每页%PageSize%条"
            ShowBoxThreshold="10" ShowCustomInfoSection="Right" PageSize="20">
        </webdiyer:AspNetPager>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
