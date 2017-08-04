<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="terminate.aspx.cs" Inherits="ZhangWei.Web.terminate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        授权已到期，输入授权码继续使用<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="确定" onclick="Button1_Click" />
    </div>
    </form>
</body>
</html>
