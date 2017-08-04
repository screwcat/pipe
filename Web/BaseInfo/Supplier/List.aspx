<%@ Page Title="Supplier" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="ZhangWei.Web.Supplier.List" %>
<%@ Register src="../../Controls/checkright.ascx" tagname="checkright" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script language="javascript" src="/js/CheckBox.js" type="text/javascript"></script>
    <style type="text/css">
        .style1 { font-size: x-large; }
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
                         &nbsp;</td>
                    <td class="style1">                       
                        供应商列表<uc2:checkright ID="checkright1" runat="server" PermissionID="9" />
                    </td>
                    <td class="tdbg">
                        &nbsp;</td>
                </tr>
            </table>
            <!--Search end-->
            <br />
            <asp:GridView ID="gridView" runat="server" AllowPaging="True" 
        Width="100%" cellpadding="0"  OnPageIndexChanging ="gridView_PageIndexChanging"
                    BorderWidth="1px" DataKeyNames="Supplier_ID" OnRowDataBound="gridView_RowDataBound"
                    AutoGenerateColumns="False"  RowStyle-HorizontalAlign="Center" 
        OnRowCreated="gridView_OnRowCreated" CssClass="gridview_m" 
        onrowcommand="gridView_RowCommand" onrowdeleting="RowDeleting" 
        PageSize="20">
<RowStyle HorizontalAlign="Center"></RowStyle>
                    <Columns>
                            
		                <asp:BoundField DataField="Supplier_ID" HeaderText="编号" />
                            
		<asp:BoundField DataField="Name" HeaderText="供应商名称" SortExpression="Name" 
                            ItemStyle-HorizontalAlign="Center"  > 
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
		<asp:BoundField DataField="Address" HeaderText="地址" SortExpression="Address" 
                            ItemStyle-HorizontalAlign="Center"  > 
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
		<asp:BoundField DataField="Phone" HeaderText="电话" SortExpression="Phone" 
                            ItemStyle-HorizontalAlign="Center"  > 
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
		<asp:BoundField DataField="Fax" HeaderText="传真" SortExpression="Fax" 
                            ItemStyle-HorizontalAlign="Center"  > 
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
		<asp:BoundField DataField="PostalCode" HeaderText="邮编" SortExpression="PostalCode" 
                            ItemStyle-HorizontalAlign="Center"  > 
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
		<asp:BoundField DataField="ConstactPerson" HeaderText="联系人" SortExpression="ConstactPerson" 
                            ItemStyle-HorizontalAlign="Center"  > 
                            
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                            
                            <asp:HyperLinkField HeaderText="详细" ControlStyle-Width="50" 
                            DataNavigateUrlFields="Supplier_ID" DataNavigateUrlFormatString="Show.aspx?id={0}"
                                Text="详细"  >
<ControlStyle Width="50px"></ControlStyle>
                        </asp:HyperLinkField>
                            <asp:HyperLinkField HeaderText="编辑" ControlStyle-Width="50" 
                            DataNavigateUrlFields="Supplier_ID" DataNavigateUrlFormatString="Modify.aspx?id={0}"
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
                        <input id="Button1" type="button" value="添加供应商" onclick="javascript:window.location='add.aspx'" /></td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>