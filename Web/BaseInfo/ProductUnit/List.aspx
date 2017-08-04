<%@ Page Title="ProductUnit" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="ZhangWei.Web.ProductUnit.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script language="javascript" src="/js/CheckBox.js" type="text/javascript"></script>
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
                         <b>关键字：</b>
                    </td>
                    <td class="tdbg">                       
                    <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="查询"  OnClick="btnSearch_Click" >
                    </asp:Button>                    
                        
                        产品单位管理</td>
                    <td class="tdbg">
                    </td>
                </tr>
            </table>
            <!--Search end-->
            <br />
            <asp:GridView ID="gridView" runat="server" AllowPaging="True" 
        Width="100%" cellpadding="0"  OnPageIndexChanging ="gridView_PageIndexChanging"
                    BorderWidth="1px" DataKeyNames="ProductUnit_ID" OnRowDataBound="gridView_RowDataBound"
                    AutoGenerateColumns="False"  RowStyle-HorizontalAlign="Center" 
        OnRowCreated="gridView_OnRowCreated" CssClass="gridview_m" 
        onrowdeleting="gridView_RowDeleting" PageSize="20">
<RowStyle HorizontalAlign="Center"></RowStyle>
                    <Columns>
                            
		<asp:BoundField DataField="Name" HeaderText="单位名称" SortExpression="Name" 
                            ItemStyle-HorizontalAlign="Center"  > 
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
		<asp:BoundField DataField="Employee_ID" HeaderText="操作员" SortExpression="Employee_ID" 
                            ItemStyle-HorizontalAlign="Center"  > 
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
		<asp:BoundField DataField="CreateDate" HeaderText="创建时间" SortExpression="CreateDate" 
                            ItemStyle-HorizontalAlign="Center"  > 
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
		<asp:BoundField DataField="Remark" HeaderText="备注" SortExpression="Remark" 
                            ItemStyle-HorizontalAlign="Center"  > 
                            
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                            
                            <asp:HyperLinkField HeaderText="详细" ControlStyle-Width="50" 
                            DataNavigateUrlFields="ProductUnit_ID" DataNavigateUrlFormatString="Show.aspx?id={0}"
                                Text="详细"  >
<ControlStyle Width="50px"></ControlStyle>
                        </asp:HyperLinkField>
                            <asp:HyperLinkField HeaderText="编辑" ControlStyle-Width="50" 
                            DataNavigateUrlFields="ProductUnit_ID" DataNavigateUrlFormatString="Modify.aspx?id={0}"
                                Text="编辑"  >
<ControlStyle Width="50px"></ControlStyle>
                        </asp:HyperLinkField>
                        <asp:TemplateField HeaderText="删除" ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                    CommandName="Delete" Text="删除" OnClientClick="return confirm('确认删除吗？')"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        </Columns>
                </asp:GridView>
               <table border="0" cellpadding="0" cellspacing="1" style="width: 100%;">
                <tr>
                    <td style="width: 1px;">                        
                    </td>
                    <td align="left">
                        <input id="Button1" type="button" value="添加" onclick="javascript:window.location='add.aspx'" /><input 
                            id="Button2" type="button" value="返回" 
                            onclick="javascript:window.location='/BaseInfo/product/list.aspx'" /></td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>