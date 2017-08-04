<%@ Page Title="1" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="ZhangWei.Web.user.List" %>
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
                        
                    </td>
                    <td class="tdbg">
                    </td>
                </tr>
            </table>
            <!--Search end-->
            <br />
            <asp:GridView ID="gridView" runat="server" AllowPaging="True" Width="100%" cellpadding="0"  OnPageIndexChanging ="gridView_PageIndexChanging"
                    BorderWidth="1px" DataKeyNames="" OnRowDataBound="gridView_RowDataBound"
                    AutoGenerateColumns="false" PageSize="10"  RowStyle-HorizontalAlign="Center" OnRowCreated="gridView_OnRowCreated" CssClass="gridview_m">
                    <Columns>
                    <asp:TemplateField ControlStyle-Width="30" HeaderText="选择"    >
                                <ItemTemplate>
                                    <asp:CheckBox ID="DeleteThis" onclick="javascript:CCA(this);" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField> 
                            
		<asp:BoundField DataField="User_Id" HeaderText="User_Id" SortExpression="User_Id" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="User_Pwd" HeaderText="User_Pwd" SortExpression="User_Pwd" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Again_Pwd" HeaderText="Again_Pwd" SortExpression="Again_Pwd" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Bel_Group" HeaderText="Bel_Group" SortExpression="Bel_Group" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Div_Type" HeaderText="Div_Type" SortExpression="Div_Type" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="User_Auth" HeaderText="User_Auth" SortExpression="User_Auth" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Auth_Type" HeaderText="Auth_Type" SortExpression="Auth_Type" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="User_Status" HeaderText="User_Status" SortExpression="User_Status" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Create_User" HeaderText="Create_User" SortExpression="Create_User" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Create_Date" HeaderText="Create_Date" SortExpression="Create_Date" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Create_Time" HeaderText="Create_Time" SortExpression="Create_Time" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Appr_User" HeaderText="Appr_User" SortExpression="Appr_User" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Appr_Date" HeaderText="Appr_Date" SortExpression="Appr_Date" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Appr_Time" HeaderText="Appr_Time" SortExpression="Appr_Time" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Pwd_Date" HeaderText="Pwd_Date" SortExpression="Pwd_Date" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Err_Count" HeaderText="Err_Count" SortExpression="Err_Count" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Use_eJCIC" HeaderText="Use_eJCIC" SortExpression="Use_eJCIC" ItemStyle-HorizontalAlign="Center"  /> 
                            
                            <asp:HyperLinkField HeaderText="详细" ControlStyle-Width="50" DataNavigateUrlFields="" DataNavigateUrlFormatString="Show.aspx?"
                                Text="详细"  />
                            <asp:HyperLinkField HeaderText="编辑" ControlStyle-Width="50" DataNavigateUrlFields="" DataNavigateUrlFormatString="Modify.aspx?"
                                Text="编辑"  />
                            <asp:TemplateField ControlStyle-Width="50" HeaderText="删除"   Visible="false"  >
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                         Text="删除"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                </asp:GridView>
               <table border="0" cellpadding="0" cellspacing="1" style="width: 100%;">
                <tr>
                    <td style="width: 1px;">                        
                    </td>
                    <td align="left">
                        <asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click"/>                       
                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>
