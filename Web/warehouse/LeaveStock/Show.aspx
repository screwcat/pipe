﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="ZhangWei.Web.LeaveStock.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		LeaveStock_ID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblLeaveStock_ID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		LeaveDate
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblLeaveDate" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Dept_ID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDept_ID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		StoreHouse_ID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblStoreHouse_ID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ToStoreHouse_ID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblToStoreHouse_ID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Employee_ID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblEmployee_ID" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>



