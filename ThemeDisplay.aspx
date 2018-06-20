<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThemeDisplay.aspx.cs" Inherits="Web.ThemeDisplay" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="CSS/ThemeDisplay.css" rel="stylesheet" />
    <script src="js/ThemeDisplay.js"></script>
    <link href="CSS/Jubao.css" rel="stylesheet" />

    <script src="Ueditor/ueditor.config.js"></script>
<script src="Ueditor/ueditor.all.min.js"></script>
<script src="Ueditor/ueditor.all.js"></script>
    <title>主题展示</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
        </div>
        <div class="navigation">
            <a href='<%# Web.SomeMethod.GetIndexPath() %>'>首页</a>->
            <%--<asp:HyperLink ID="preNode" runat="server" NavigateUrl="~/ThemeList.aspx?divisionName="></asp:HyperLink>->--%>
            <asp:LinkButton ID="lbtnPath" runat="server" OnClick="lbtnPath_Click"></asp:LinkButton>->
            <a>本文</a>
            <a href="javascript:void(0)" id="collect" runat="server" onserverclick="collect_ServerClick">
                <img src="Image/ThemeDisplay/收藏.png" style="width: 25px; height: 25px; float: right" /></a>
        </div>
        <div id="article">
            <div id="th">
                <asp:Label ID="ThemeId" runat="server" Text=""></asp:Label>
            </div>
            <div class="tr">
                <div class="left">
                    <div id="picture" runat="server" class="pic"></div>
                    <div class="person">
                        <a href="#" id="MemberId" runat="server"></a>
                        <a href="javascript:void(0)" id="addConcern" onclick="concernClick()" runat="server" onserverclick="addConcern_ServerClick">
                            <img src="Image/ThemeDisplay/关注.png" style="width: 40px; height: 20px;" /></a>
                    </div>
                    <div>
                        <div id="UserName" runat="server" class="name" style="text-align: left;"></div>
                        <div id="xp" class="lv" runat="server"></div>
                    </div>
                </div>
                <div class="right">
                    <div id="text" class="text" runat="server"></div>
                    <div class="operate">
                        <input type="hidden" value="Theme" />
                        <asp:Label ID="lblPublishiTime" runat="server" Text=""></asp:Label>
                        <a class="pic1" href="javascript:void(0)" onclick="reportClick()">
                            <img src="Image/ThemeDisplay/举报.png" style="width: 30px; height: 30px" />
                        </a>
                        <a class="pic2" href="javascript:void(0)" onclick="criticismClick()">
                            <img src="Image/ThemeDisplay/评论.png" style="width: 30px; height: 30px" />
                        </a>
                    </div>
                </div>
            </div>
            <div id="criticisms" runat="server">
            </div>
        </div>
        <input id="connectCriticism" runat="server" type="hidden" value="" />
        <%--<div id="comment">
            <div style="height: 15%">
                <span>匿名用户不能回复<a href="Login.aspx" target="_blank">登录</a>|<a href="Register.aspx" target="_blank">注册</a></span>
            </div>
            <textarea id="content" runat="server" class="content" placeholder="请输入..." style="width: 85%; height: 70%;"></textarea>
            <div runat="server">
                <input type="submit" id="btnSubmit" runat="server" value="提交评论" onserverclick="btnSubmit_ServerClick" onclick="document.getElementById('comment').style.display = 'none';" />
                <input type="button" value="取消" onclick="document.getElementById('comment').style.display = 'none';" />
            </div>
        </div>--%>
        <div id="pubCriticism" class="pubCriticism" style="display: none;">
            <div>
                <!-- 配置文件 -->
                <script type="text/javascript" src="ueditor.config.js"></script>
                <!-- 编辑器源码文件 -->
                <script type="text/javascript" src="ueditor.all.js"></script>
                <!-- 实例化编辑器 -->
                <script type="text/javascript">
                    var ue = UE.getEditor('myEditor');
                </script>
            </div>
            <asp:HiddenField ID="hidContent" runat="server"></asp:HiddenField>
            <script id="myEditor" type="text/plain" style="width: 650px; height: 300px; margin: 10px auto;"></script>
            <asp:Button ID="btnPubCriticism" runat="server" Text="发布评论" OnClientClick="getContent()" OnClick="btnPubCriticism_Click" Style="width: 80px; height: 30px; background-color: #0094ff;" />
            <input type="button" value="取消" onclick="hidpubCriticism()" style="width: 80px; height: 30px; background-color: #0094ff;" />
            <script type="text/javascript">
                function getContent() {
                    document.getElementById("hidContent").value = encodeURIComponent(ue.getContent());
                }
                function hidpubCriticism() {
                    document.getElementById("pubCriticism").style.display = "none";
                }
            </script>
        </div>
        <div id="report" style="display: none;">
            <div class="main">
                <div class="head">
                    <div class="font">主题举报</div>
                </div>
                <div class="msg">
                    <span>主题：<br />
                        <input type="text" class="input" />
                    </span>
                    <br />
                    <span>详细说明：<br />
                        <textarea class="textarea" runat="server" id="reportText"></textarea>
                    </span>
                </div>
                <div class="foot">
                    <input type="hidden" runat="server" id="reportCriticismId" value="" />
                    <input type="submit" class="btn" runat="server" id="btnReport" value="举报" onserverclick="btnReport_ServerClick" />
                    <button type="button" class="btn" onclick="document.getElementById('report').style.display = 'none';">取消</button>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
