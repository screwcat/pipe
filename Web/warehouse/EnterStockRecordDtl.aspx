<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnterStockRecordDtl.aspx.cs"
    Inherits="ZhangWei.Web.warehouse.EnterStockRecordDtl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Style/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%">
            <tr>
                <td align="center" style="font-size: large">
                    进货记录
                    <asp:Label ID="Label3" runat="server" Font-Size="Small" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp; 进货仓库：<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" CellPadding="0" rules="all" border="1"
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
                            <asp:BoundField DataField="SupplierName" HeaderText="厂商">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Price" HeaderText="进价">
                                <ItemStyle HorizontalAlign="Center" CssClass="eachPrice" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Quantity" HeaderText="数量">
                                <ItemStyle HorizontalAlign="Center" CssClass="eachQty" />
                            </asp:BoundField>
                            <asp:BoundField DataField="UnitName" HeaderText="单位">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="货款">
                                <ItemStyle HorizontalAlign="Center" CssClass="eachTotal" />
                            </asp:BoundField>
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
                            <td class="style1">
                                <input id="btnProId" type="button" value="button" onclick="openDialog()" />
                            </td>
                            <td class="style1">
                                <span id="proName">货品名称</span>
                            </td>
                            <td class="style1">
                                <span id="proPect">规格</span>
                            </td>
                            <td class="style1">
                                <span id="supplier">厂商</span>
                            </td>
                            <td class="style1">
                                <input id="proPrice" type="text" style="width: 80px" onkeyup="clearNoNum1(this)" />
                            </td>
                            <td class="style1">
                                <input id="proQty" type="text" style="width: 80px" onkeyup="clearNoNum(this)" />
                            </td>
                            <td class="style1">
                                <span id="proUnit">单位</span>
                            </td>
                            <td class="style1">
                                <span id="totaPrice">0</span>
                            </td>
                            <td class="style1">
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
                            <td class="style1">
                                <span id="supplier1">厂商</span>
                            </td>
                            <td>
                                <input id="proPrice1" type="text" style="width: 80px" onkeyup="clearNoNum(this)" />
                            </td>
                            <td>
                                <input id="proQty1" type="text" style="width: 80px" onkeyup="clearNoNum1(this)" />
                            </td>
                            <td>
                                <span id="proUnit1">单位</span>
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
                <td>
                    共计：<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    元，大写：<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    <br />
                    <input id="Button3" onclick="javascript:history.go(-1)" type="button" value="返回" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
