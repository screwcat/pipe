<%@ Page Title="BuyOrder" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="ZhangWei.Web.BuyOrder.List" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
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
                        进货合同<uc2:checkright ID="checkright1" runat="server" PermissionID="1" />
                        
                    </td>
                    <td class="tdbg">
                    </td>
                </tr>
            </table>
            <!--Search end-->
            <br />
            <asp:GridView ID="gridView" runat="server" 
        Width="100%" cellpadding="0"  OnPageIndexChanging ="gridView_PageIndexChanging"
                    BorderWidth="1px" DataKeyNames="BuyOrder_ID" OnRowDataBound="gridView_RowDataBound"
                    AutoGenerateColumns="False"  RowStyle-HorizontalAlign="Center" 
        OnRowCreated="gridView_OnRowCreated" onrowcommand="gridView_RowCommand" CssClass="gridview_m">
<RowStyle HorizontalAlign="Center"></RowStyle>
                    <Columns>
                            
                        <asp:TemplateField ControlStyle-Width="30" HeaderText="编号">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("BuyOrder_ID") %>'></asp:Label>
                            </ItemTemplate>

<ControlStyle Width="30px"></ControlStyle>
                        </asp:TemplateField>
                            
		                <asp:BoundField DataField="WriteDate" HeaderText="创建日期" 
                            SortExpression="WriteDate" >
                            
		                <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                            
		<asp:BoundField DataField="Name" HeaderText="供应商" SortExpression="Supplier_ID" 
                            ItemStyle-HorizontalAlign="Center"  > 
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
		<asp:BoundField DataField="EmployeeName" HeaderText="负责人" SortExpression="Employee_ID" 
                            ItemStyle-HorizontalAlign="Center"  > 
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                            
                            <asp:TemplateField ControlStyle-Width="50" HeaderText="删除"   Visible="false"  >
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                         Text="删除"></asp:LinkButton>
                                </ItemTemplate>

<ControlStyle Width="50px"></ControlStyle>
                            </asp:TemplateField>
                        <asp:TemplateField HeaderText="详细">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%#Eval("BuyOrder_ID") %>'>详细</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="生成入库单">
                            <ItemTemplate>
                                <asp:Button ID="Button2" runat="server" Text="确定入库" 
                                    CommandArgument='<%#Eval("BuyOrder_ID") %>' Enabled='<%#Eval("Produced") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        </Columns>
                </asp:GridView>
    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="尾页"
                        NextPageText="下一页" 
        OnPageChanged="AspNetPager1_PageChanged" PageIndexBoxType="TextBox"
                        PrevPageText="上一页" ShowPageIndexBox="Auto" 
        SubmitButtonText="Go" TextAfterPageIndexBox="页"
                        TextBeforePageIndexBox="转到" 
                        CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，共%RecordCount%条，每页%PageSize%条" 
                        ShowBoxThreshold="10" ShowCustomInfoSection="Right" 
        PageSize="20">
                    </webdiyer:AspNetPager>
               <table border="0" cellpadding="0" cellspacing="1" style="width: 100%;">
                <tr>
                    <td style="width: 1px;">                        
                    </td>
                    <td align="left">
                        <%--<asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click"/>--%>                       
                        <input id="Button1" type="button" value="填写入库单" onclick="javascript:window.location='/warehouse/AddStockContract.aspx'" /></td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>