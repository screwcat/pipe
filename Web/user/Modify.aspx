<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="ZhangWei.Web.user.Modify" Title="修改页" %>
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
		<asp:TextBox id="txtUser_Id" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		User_Pwd
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtUser_Pwd" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Again_Pwd
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtAgain_Pwd" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Bel_Group
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtBel_Group" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Div_Type
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtDiv_Type" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		User_Auth
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtUser_Auth" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Auth_Type
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtAuth_Type" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		User_Status
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtUser_Status" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Create_User
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtCreate_User" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Create_Date
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtCreate_Date" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Create_Time
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtCreate_Time" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Appr_User
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtAppr_User" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Appr_Date
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtAppr_Date" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Appr_Time
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtAppr_Time" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Pwd_Date
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPwd_Date" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Err_Count
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtErr_Count" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Use_eJCIC
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtUse_eJCIC" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
</table>

            </td>
        </tr>
        <tr>
            <td class="tdbg" align="center" valign="bottom">
                <asp:Button ID="btnSave" runat="server" Text="保存"
                    OnClick="btnSave_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
                <asp:Button ID="btnCancle" runat="server" Text="取消"
                    OnClick="btnCancle_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
            </td>
        </tr>
    </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>

