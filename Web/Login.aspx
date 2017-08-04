<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Maticsoft.Web.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户登录</title>
    <link href="Style/Style.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery-1.7.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function() {
            $("#UserName").focus();
            $("#Button1").click(function() {
                if ($("#UserName").val() == "") {
                    $("#pointUN").html("用户名不能空！");
                    $("#pointPW").html("");
                }
                else if ($("#PassWord").val() == "") {
                    $("#pointPW").html("密码不能空！");
                } else {
                    CleckLogin();
                }
            });
            $("#UserName").blur(function() {
                if ($("#UserName").val() == "") {
                    $("#pointUN").html("用户名不能空！");
                    $("#pointPW").html("");
                } else {
                    ExistsUser();
                }
            });
            $("#UserName").focus(function() {
                $("#pointUN").html("");
                $("#pointPW").html("");
            });
            $("#PassWord").focus(function() {
                $("#pointPW").html("");
            });
        });
        function CleckLogin() {
            var myitem = $("input[name='cookieRadio']:checked").val();
            $.ajax({
                type: "get",
                cache: false,
                url: "/ajax/ajax.ashx",
                data: { Command: "CheckLogin", UserName: $("#UserName").val(), PassWord: $("#PassWord").val(), cookieTime: myitem },
                dataType: "text",
                beforeSend: function () {
                    $("#Button1").addClass("loadBtn");
                },
                success: function (data) {
                    if (data == "NoUser") {
                        $("#pointUN").html("用户名不存在！");
                        $("#pointPW").html("");
                    }
                    else {
                        if (data == "OK") {
                            window.location.href = "Default.html";
                        }
                        else {
                            $("#pointPW").html("密码不正确！");
                            $("#pointUN").html("");
                        }
                    }
                },
                complete: function () {
                    $("#Button1").removeClass("loadBtn");
                }
            });
        }
        function ExistsUser() {
            $.ajax({
                type: "get",
                cache: false,
                url: "/ajax/ajax.ashx",
                data: { Command: "ExistsUser", UserName: $("#UserName").val() },
                dataType: "text",
                beforeSend: function () {
                    $("#UNload").show();
                },
                success: function (data) {
                    if (data == "no") {
                        $("#pointUN").html("用户名不存在！");
                        $("#pointPW").html("");
                    }
                    else {
                        $("#pointUN").html("");
                    }
                },
                complete: function () {
                    $("#UNload").hide();
                }
            });
        }
        document.onkeydown = function (e) {
            var theEvent = window.event || e;
            var code = theEvent.keyCode || theEvent.which;
            if (code == 13) {
                $("#Button1").click();
            }
        }
    </script>
    <style type="text/css">
        #Button1 { height: 27px; width: 67px; border: none; cursor: pointer; }
        .style1 { width: 100%; height: 220px; }
        .style2 { width: 209px; }
        .style3 { }
        .style4 { height: 51px; border-bottom: solid 1px #CCC; }
        .style5 { color: #FFFFFF; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 780px; height: 411px; margin: 100px auto; background: url(Images/loginBg.gif);
        padding: 150px 0 0 0">
        <div style="width: 500px; height: 220px; margin: 0 auto; background: #FFF; border: 2px solid #CCC">
            <table class="style1">
                <tr>
                    <td rowspan="5" align="center" valign="middle" class="style2">
                        <img alt="a" src="/Images/loginBg1.jpg" />
                    </td>
                    <td class="style4">
                        &nbsp; <em style="font-size: 30px; color: #F90; font-family: '黑体';">登录</em>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                        <br />
                        &nbsp; 用户名：<input id="UserName" type="text" />
                        <span class="fontRed" id="pointUN"></span>
                        <img src="Images/loading2.gif" style="height: 20px; width: 20px; display: none" id="UNload" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp; 密<span class="style5">—</span>码：<input id="PassWord" type="password" /><span
                            class="fontRed" id="pointPW"></span>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style3" colspan="2">
                        &nbsp; &nbsp;
                        <table>
                            <tr>
                                <td>
                                    <label>
                                        <input id="Radio1" type="radio" checked="checked" name="cookieRadio" value="0" />不保存</label>
                                    <label>
                                        <input id="Radio2" type="radio" name="cookieRadio" value="1" />一天</label>
                                    <label>
                                        <input id="Radio3" type="radio" name="cookieRadio" value="30" />一个月</label>
                                </td>
                                <td>
                                    <input id="Button1" type="button" class="loginBtn" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
