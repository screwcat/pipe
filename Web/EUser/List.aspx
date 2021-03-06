﻿<%@ Page Title="EUser" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="ZhangWei.Web.EUser.List" %>
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
                    BorderWidth="1px" DataKeyNames="UserId" OnRowDataBound="gridView_RowDataBound"
                    AutoGenerateColumns="false" PageSize="10"  RowStyle-HorizontalAlign="Center" OnRowCreated="gridView_OnRowCreated" CssClass="gridview_m">
                    <Columns>
                    <asp:TemplateField ControlStyle-Width="30" HeaderText="选择"    >
                                <ItemTemplate>
                                    <asp:CheckBox ID="DeleteThis" onclick="javascript:CCA(this);" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField> 
                            
		<asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="PassWord" HeaderText="PassWord" SortExpression="PassWord" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Sex" HeaderText="Sex" SortExpression="Sex" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="ID_Card" HeaderText="ID_Card" SortExpression="ID_Card" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="MobilPhone" HeaderText="MobilPhone" SortExpression="MobilPhone" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Postalcode" HeaderText="Postalcode" SortExpression="Postalcode" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Work" HeaderText="Work" SortExpression="Work" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Income" HeaderText="Income" SortExpression="Income" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Integral" HeaderText="Integral" SortExpression="Integral" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="CreateTime" HeaderText="CreateTime" SortExpression="CreateTime" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="LaseLogin" HeaderText="LaseLogin" SortExpression="LaseLogin" ItemStyle-HorizontalAlign="Center"  /> 
                            
                            <asp:HyperLinkField HeaderText="详细" ControlStyle-Width="50" DataNavigateUrlFields="UserId" DataNavigateUrlFormatString="Show.aspx?id={0}"
                                Text="详细"  />
                            <asp:HyperLinkField HeaderText="编辑" ControlStyle-Width="50" DataNavigateUrlFields="UserId" DataNavigateUrlFormatString="Modify.aspx?id={0}"
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
