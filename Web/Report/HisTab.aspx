<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HisTab.aspx.cs" Inherits="ZhangWei.Web.Report.HisTab" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="/js/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script src="/lhgdialog/lhgdialog.min.js?skin=chrome" type="text/javascript"></script>

    <link href="/Style/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%">
            <tr>
                <td align="center" style="font-size: x-large">
                    历史Excel报表
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" OnRowDeleting="GridView1_RowDeleting"
                        Width="100%" CssClass="gridview_m" AutoGenerateColumns="False">
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
                            <asp:HyperLinkField DataNavigateUrlFields="Name" DataNavigateUrlFormatString="/ExcelFiles/{0}"
                                DataTextField="Name" DataTextFormatString="{0}" HeaderText="链接" Target="_blank">
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
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
