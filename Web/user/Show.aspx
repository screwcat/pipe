<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="ZhangWei.Web.user.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		User_Id
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblUser_Id" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		User_Pwd
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblUser_Pwd" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Again_Pwd
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAgain_Pwd" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Bel_Group
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBel_Group" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Div_Type
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDiv_Type" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		User_Auth
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblUser_Auth" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Auth_Type
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAuth_Type" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		User_Status
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblUser_Status" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Create_User
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCreate_User" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Create_Date
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCreate_Date" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Create_Time
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCreate_Time" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Appr_User
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAppr_User" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Appr_Date
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAppr_Date" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Appr_Time
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAppr_Time" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Pwd_Date
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPwd_Date" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Err_Count
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblErr_Count" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Use_eJCIC
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblUse_eJCIC" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




