﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransferRecord.aspx.cs"
    Inherits="ZhangWei.Web.warehouse.TransferRecord" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
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
                    仓库调拔记录
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" cellpadding="0" BorderWidth="1px" RowStyle-HorizontalAlign="Center" CssClass="gridview_m">
                        <Columns>
                            <asp:BoundField DataField="LeaveStock_ID" HeaderText="编号" />
                            <asp:BoundField DataField="LeaveDate" HeaderText="日期" />
                            <asp:HyperLinkField DataNavigateUrlFields="LeaveStock_ID" 
                                DataNavigateUrlFormatString="/warehouse/TransferDtl.aspx?LeaveStock_ID={0}" 
                                HeaderText="详细" Text="查看" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="尾页"
                        NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged" PageIndexBoxType="TextBox"
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
