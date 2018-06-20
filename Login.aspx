<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Login" %>

<%@ Register Assembly="Vincent.AutoAuthCode" Namespace="Vincent.AutoAuthCode" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="CSS/Login.css" rel="stylesheet" />
    <script src="js/login.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="page">
            <div id="header"></div>
            <div id="picture">
                <div id="login">
                    <div class="table" >用户登录</div>
                    <div class="table">
                        <img src="/Image/Login/user.png" /><input type="text" runat="server" id="txtUser" placeholder="帐号"/>
                    </div>
                    <div class="table">
                        <img src="/Image/Login/pwd.png" /><input type="password" runat="server" id="txtPwd" placeholder="密码"/>
                    </div>
                    <div class="table">
                        <img src="/Image/Login/IdentifyingCode.png" /><input type="text" runat="server" id="txtIdentifyingCode" placeholder="验证码" style="width:90px;"/>
                        <img src="~/VCode.aspx" id="imgIdentifyingCode"  runat="server" style="width:70px;" onclick="this.src=this.src+'?'" />
                    </div>
                    <div class="table">
                        <asp:CheckBox ID="cbRemember" runat="server" Text="记住密码" Height="10px" />&nbsp;&nbsp;&nbsp;
                        <a href="#">忘记密码？</a>
                    </div>
                    <div class="table">
                        <asp:Button ID="btnLogin" runat="server" Text="登录" style="background-color:rgba(0, 148, 255, 0.70);font-size:20px;color:white;" OnClick="btnLogin_Click" />
                    </div>
                    <br /><br />
                    <div class="table" style="text-align:right;">还没账号？<a href="Register.aspx">前往注册</a></div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
