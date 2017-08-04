<%@ Page Title="Product" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="List.aspx.cs" Inherits="ZhangWei.Web.Product.List" %>

<%@ Register Src="../../Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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
                        if ($("#ctl00_ContentPlaceHolder1_HiddenField1").val() == data.data[i].value) {
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
    </script>
    <style type="text/css">
        #Button1
        {
            height: 27px;
            width: 92px;
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Title -->
    <!--Title end -->
    <!--Add  -->
    <!--Add end -->
    <!--Search -->
    <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
        <tr>
            <td style="width: 80px" align="right" class="tdbg">
                &nbsp;
            </td>
            <td class="tdbg">
                &nbsp;&nbsp;&nbsp;&nbsp; <span class="style1">产品列表<uc2:checkright ID="checkright1"
                    runat="server" PermissionID="10" />
                </span>
            </td>
            <td class="tdbg">
            </td>
        </tr>
    </table>
    <!--Search end-->
    <table id="sera" width="100%" align="center">
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
                <asp:Button ID="Button2" runat="server" Text="查找" OnClick="Button1_Click" />
            </td>
        </tr>
        <tr height="100" align="center" valign="top">
            <td colspan="5">
    <asp:GridView ID="gridView" runat="server" Width="100%" cellpadding="0" OnPageIndexChanging="gridView_PageIndexChanging"
        BorderWidth="1px" DataKeyNames="Product_ID" OnRowDataBound="gridView_RowDataBound"
        AutoGenerateColumns="False" RowStyle-HorizontalAlign="Center" 
                    OnRowCreated="gridView_OnRowCreated" CssClass="gridview_m" 
                    onrowdeleting="gridView_RowDeleting">
        <RowStyle HorizontalAlign="Center"></RowStyle>
        <Columns>
            <asp:BoundField DataField="Product_ID" HeaderText="编号" />
            <asp:BoundField DataField="Name" HeaderText="名称" SortExpression="Name" 
                ItemStyle-HorizontalAlign="Center">
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="shortname" HeaderText="简称" />
            <asp:BoundField DataField="ProductListName" HeaderText="分类" SortExpression="ProductList_ID"
                ItemStyle-HorizontalAlign="Center">
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="SpecName" HeaderText="规格" SortExpression="ProductSpec_ID"
                ItemStyle-HorizontalAlign="Center">
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="s_spell" HeaderText="名称首字母" />
            <asp:BoundField DataField="SupplierName" HeaderText="供应商" />
            <asp:BoundField DataField="UnitName" HeaderText="计量单位" SortExpression="ProductUnit_ID"
                ItemStyle-HorizontalAlign="Center">
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:HyperLinkField HeaderText="详细" ControlStyle-Width="50" DataNavigateUrlFields="Product_ID"
                DataNavigateUrlFormatString="Show.aspx?id={0}" Text="查看">
                <ControlStyle Width="50px"></ControlStyle>
            </asp:HyperLinkField>
            <asp:HyperLinkField HeaderText="编辑" ControlStyle-Width="50" DataNavigateUrlFields="Product_ID"
                DataNavigateUrlFormatString="Modify.aspx?id={0}" Text="编辑">
                <ControlStyle Width="50px"></ControlStyle>
            </asp:HyperLinkField>
            <asp:TemplateField ShowHeader="False" HeaderText="删除">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                        CommandName="Delete" Text="删除" OnClientClick="return confirm('确认删除吗？')"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="尾页"
                    NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged" PageIndexBoxType="TextBox"
                    PrevPageText="上一页" ShowPageIndexBox="Auto" SubmitButtonText="Go" TextAfterPageIndexBox="页"
                    TextBeforePageIndexBox="转到" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，共%RecordCount%条，每页%PageSize%条"
                    ShowBoxThreshold="10" ShowCustomInfoSection="Right" PageSize="20">
                </webdiyer:AspNetPager>
                <br/>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="5" align="left">
                <input id="Button1" type="button" value="添加新商品" onclick="javascript:window.location='add.aspx'" /></td>
        </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing="1" style="width: 100%;">
        <tr>
            <td style="width: 1px;">
            </td>
            <td align="left">
                <br />
                
            </td>
        </tr>
    </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>