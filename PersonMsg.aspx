<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonMsg.aspx.cs" Inherits="Web.PersonMsg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="CSS/PersonMsg.css" rel="stylesheet" />
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
            <div class="header">
                <input type="submit" value="我发送的" class="button"/>
                <div class="radio">
                    <input type="submit" value="未查看" class="button" />
                </div>
            </div>
            <table class="table">
                <tr>
                    <th>发送者</th>
                    <th>接收者</th>
                    <th>消息内容</th>
                    <th></th>
                </tr>
                <tr>
                    <td>葬爱罗少</td>
                    <td>葬爱晋少</td>
                    <td>晋少最帅，我罗少就是一个大傻逼，还很菜，真希望能够有你一样</td>
                    <td>
                        <input type="submit" value="查看" class="button" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
