<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Web.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="CSS/index.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="head">
            <div runat="server" id="pic" style="background-image:url(Image/Login/bg.jpg);width:150px;height:150px;background-color:green;border-radius:100px;"></div>
            <div id="menu">
                <div>
                    <span><a>新闻资讯</a></span>
                </div>
                <div>
                    <span><a>与我有关</a></span>
                    <ul>
                        <li><a href="PersonUpdate.aspx">我的信息</a></li>
                        <li><a href="MyMessage.aspx">我的消息</a></li>
                        <li><a href="MyCriticism.aspx">我的评论</a></li>
                        <li><a href="MyCollect.aspx">我的收藏</a></li>
                        <li><a href="MyConcern.aspx">我的关注</a></li>
                    </ul>
                </div>
                <div>
                    <span><a>我的信息</a></span>
                    <ul>
                        <li><a href="PersonUpdate.aspx">修改信息</a></li>
                    </ul>
                </div>
                <div>
                    <span><a href="/BackgroundPages/Admin.aspx">后台管理</a></span>
                </div>
                <div style="width: 10%; font-size: 15px">
                    <span><a href="Login.aspx">登陆</a></span>

                </div>
                <div style="width: 1%; color: #ffffff">|</div>
                <div style="width: 10%; font-size: 15px">
                    <span><a href="Register.aspx">注册</a></span>
                </div>
            </div>
            <div class="rhead">湖心小筑</div>
        </div>
         <div class="clear"></div>
        <div runat="server" id="List" class="main"></div>
        <div class="footer">
            版权所属，江西师范大学软件学院
        </div>
    </form>
</body>
</html>
