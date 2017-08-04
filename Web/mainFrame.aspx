<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mainFrame.aspx.cs" Inherits="ZhangWei.Web.mainFrame" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="/js/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script src="/lhgdialog/lhgdialog.min.js?skin=chrome" type="text/javascript"></script>

    <link href="/Style/Style.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        function confirmCheck() {
            var nTime = new Date();
            var year1 = nTime.getFullYear();
            var month1 = nTime.getMonth() + 1;
            var day1 = nTime.getDate();
            var strTime = year1 + "年" + month1 + "月" + day1 + "日";
            $.dialog({
                title: '提示信息',
                content: '今天是' + strTime + "，从上个月底到现在，您还没生成过库存盘点表，现在去生成吗？",
                ok: function() {
                    this.close();
                    location.href = "/Report/CheckStock.aspx";
                    return false;
                },
                id: "confirmExcel",
                max: false,
                min: false,
                width: 270,
                height: 80,
                cancelVal: '关闭',
                cancel: true, /*为true等价于function(){}*/
                icon: "prompt.gif",
                lock: true
            });
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        用户 
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
&nbsp;登录成功，抚顺金牛地暖工程有限公司</div>
    </form>
</body>
</html>
