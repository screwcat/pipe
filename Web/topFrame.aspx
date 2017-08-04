<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="topFrame.aspx.cs" Inherits="Maticsoft.Web.leftFrame" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <style type="text/css">
body {
	background-image: url(images/200842182840682_1.gif);
	color:HighlightText;
}
        .style1 { width: 100%; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    农历：<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    当前用户：<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                </td>
                <td align="right">
                    <asp:Button ID="Button1" runat="server" Text="退出" onclick="Button1_Click" 
                        Width="82px" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
