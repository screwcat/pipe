<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnterStockRecord.aspx.cs"
    Inherits="ZhangWei.Web.warehouse.EnterStockRecord" %>
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
                    入库记录
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <asp:Button ID="Button8" runat="server" Text="按单号查找" onclick="Button8_Click" />
                    （不填则查找所有）</td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        Width="100%" CssClass="gridview_m">
                        <Columns>
                            <asp:BoundField DataField="EnterStock_ID" HeaderText="编号">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EnterDate" HeaderText="填写日期" 
                                DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:HyperLinkField DataNavigateUrlFields="EnterStock_ID" 
                                DataNavigateUrlFormatString="EnterStockRecordDtl.aspx?EnterStock_ID={0}" 
                                HeaderText="查看" Text="查看">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:HyperLinkField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
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
