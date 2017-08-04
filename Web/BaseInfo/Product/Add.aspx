<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Add.aspx.cs" Inherits="ZhangWei.Web.Product.Add" Title="增加页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    12345
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
        <tr>
            <td class="tdbg">

                <script src="/js/jquery-1.7.1.js" type="text/javascript"></script>

                <script type="text/javascript">
                    $(document).ready(function() {
                        bindSelect();
                        $(".DropDownList4").change(function() {
                            bindSelect();
                        });
                    });

                    function bindSelect() {
                        $.ajax({
                            type: "get",
                            cache: false,
                            url: "/ajax/ajax.ashx",
                            data: { Command: "getSelect", classId: $(".DropDownList4").val() },
                            dataType: "json",
                            beforeSend: function() {

                            },
                            success: function(data) {
                                $("#DropDownList1").empty();
                                for (var i = 0; i < data.data.length; i++) {
                                    $("#DropDownList1").append("<option value=" + data.data[i].value + ">" + data.data[i].text + "</option>");
                                }
                            },
                            complete: function() {

                            }
                        });
                    }

                    function clearNoNum(obj) {
                        obj.value = obj.value.replace(/[^\d.]/g, "");
                        obj.value = obj.value.replace(/^\./g, "");
                        obj.value = obj.value.replace(/\.{2,}/g, ".");
                        obj.value = obj.value.replace(".", "$#$").replace(/\./g, "").replace("$#$", ".");
                        handlePrice(obj);
                    }
                    
                </script>

                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td height="25" width="30%" align="right">
                            添加新产品
                        </td>
                        <td height="25" width="*" align="left">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            商品总分类：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:DropDownList ID="DropDownList4" runat="server" class="DropDownList4">
                            </asp:DropDownList>
                            <a href="/BaseInfo/ProductClass/List.aspx">管理选项</a>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            商品详细分类 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <select id="DropDownList1" name="DropDownList1">
                                <option></option>
                            </select><a href="/BaseInfo/ProductList/List.aspx">管理选项</a>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            商品名称 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            简称：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            规格 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:DropDownList ID="DropDownList2" runat="server">
                            </asp:DropDownList>
                            <a href="/BaseInfo/ProductSpec/List.aspx">管理选项</a>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            计量单位 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:DropDownList ID="DropDownList3" runat="server">
                            </asp:DropDownList>
                            <a href="/BaseInfo/ProductUnit/List.aspx">管理选项</a>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            供应商：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:DropDownList ID="DropDownList5" runat="server">
                            </asp:DropDownList>
                            <a href="/BaseInfo/Supplier/List.aspx">管理选项</a>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            进价 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtPrice" runat="server" Width="200px" onkeyup="clearNoNum(this)" onblur="clearNoNum(this)"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            零售价：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="Offering_Price" runat="server" Width="200px" onkeyup="clearNoNum(this)" onblur="clearNoNum(this)"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            描述 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtRemark" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                </table>

                <script src="/js/calendar1.js" type="text/javascript"></script>

            </td>
        </tr>
        <tr>
            <td class="tdbg" align="center" valign="bottom">
                <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" class="inputbutton"
                    onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'">
                </asp:Button>
                <input id="Button3" onclick="javascript:history.go(-1)" type="button" value="返回" />
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>