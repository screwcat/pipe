<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataBackup.aspx.cs" Inherits="ZhangWei.Web.SysManage.DataBackup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>

    <script src="/js/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script src="/lhgdialog/lhgdialog.min.js?skin=chrome" type="text/javascript"></script>

    <link href="/Style/Style.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        $.dialog.setting.lock = true;
        function DataBackup() {
            $.dialog({
                title: '提示信息',
                content: '备份数据库需要一些时间，确定开始备份吗？',
                ok: function() {
                    startBackup();
                    return false;
                },
                id: "confirmExcel",
                max: false,
                min: false,
                width: 270,
                height: 80,
                cancelVal: '关闭',
                cancel: true, /*为true等价于function(){}*/
                icon: "prompt.gif"
            });

        }
        function startBackup() {
            var list = $.dialog.list;
            for (var i in list) {
                list[i].close();
            }
            $.ajax({
                type: "get",
                cache: false,
                url: "/ajax/ajax.ashx",
                data: { Command: "DataBackup" },
                dataType: "text",
                beforeSend: function() {
                    $.dialog({
                        content: '正在备份数据，请稍候。。。。。。',
                        max: false,
                        min: false,
                        cancel: false,
                        resize: false,
                        drag: false,
                        esc: false,
                        icon: 'loading.gif'
                    });
                },
                success: function(data) {
                    var list = $.dialog.list;
                    for (var i in list) {
                        list[i].close();
                    }
                    $.dialog({
                        content: '备份成功！为防止丢失请将文件下载到客户端计算机',
                        max: false,
                        min: false,
                        cancel: false,
                        resize: false,
                        width: 200,
                        icon: 'success.gif',
                        ok: function() {
                            location.reload();
                        }
                    });
                },
                complete: function() {

                }
            });
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input id="Button1" type="button" value="备份数据" onclick="DataBackup()" /><br />
        历史备份数据<br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting"
            Width="100%" CssClass="gridview_m">
            <Columns>
                <asp:TemplateField HeaderText="行号">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text="<%#Container.DataItemIndex + 1 %>"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:BoundField DataField="Name" HeaderText="文件名">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Length" HeaderText="文件大小">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="DirectoryName" HeaderText="存储路径">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="CreationTime" HeaderText="创建时间" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:HyperLinkField DataNavigateUrlFields="Name" DataNavigateUrlFormatString="/DataBackup/{0}"
                    DataTextField="Name" DataTextFormatString="{0}" HeaderText="链接" Target="_blank">
                    <ControlStyle Font-Bold="False" ForeColor="#FF6600" />
                    <ItemStyle Font-Bold="True" Font-Underline="True" HorizontalAlign="Center" />
                </asp:HyperLinkField>
                <asp:TemplateField HeaderText="删除" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                            Text="删除" OnClientClick="return confirm('确定删除该备份文件吗？')"></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
