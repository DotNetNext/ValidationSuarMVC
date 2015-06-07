<%@ Page Language="C#" AutoEventWireup="true" CodeFile="v2.aspx.cs" Inherits="demo2_v2" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="/Content/jquery-validation-1.13.1/lib/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="/Content/jquery-validation-1.13.1/dist/jquery.validate.js" type="text/javascript"></script>
    <script src="/Content/validation.sugar.js" type="text/javascript"></script>
    <script src="/Content/jquery-validation-1.13.1/lib/jquery.form.js" type="text/javascript"></script>
    <link href="/Content/jquery-validation-1.13.1/validation.sugar.css" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript">
        $(function () {
            var factory = new validateFactory($("form"), "<img src=\"/Content/jquery-validation-1.13.1/error.png\" />");
            factory.init();

            $("#btnSubmit").click(function () {
                //异步方式
                factory.ajaxSubmit(function () {
                    $("form").ajaxSubmit({
                        type: "post",
                        url: "/home/postlogin",
                        dataType: "json",
                        success: function (msg) {
                            alert(msg.Message)
                        }
                    })
                });
            });



        });
        function checkUserName() {
            var userName = $("[name=userName]").val();
            if (userName == "admin1" || userName == "admin2") {
                return true;
            }
            return false;
        }
    </script>
    <style>
        td
        {
            height: 30px;
            padding:5px;
        }
    </style>
</head>
<body>
    <h3>
        基于jquery.validate的前后台双验证</h3>
    <form method="post" class="form" id="form1"  action="/home/postlogin">
    <table>
        <tr>
            <td>
                name
            </td>
            <td>
                <input type="text" name="userName">
            </td>
        </tr>
        <tr>
            <td>
                password
            </td>
            <td>
                <input type="password" name="password" />
            </td>
        </tr>
    </table>
    <button id="btnSubmit" type="button">
        ajax提交</button> 
         <%=ViewState["validationBind"]%>
    </form>
</body>
</html>