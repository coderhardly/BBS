<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Web.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Register</title>
    <link rel="stylesheet" href="CSS/Register.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="header"><h1>湖心小筑</h1></div>
        <div id="picture">
            <div id="register">
                <div id="rth">用户注册</div><hr />
                  <div class="rtd">
                    <div class="rtd-left">
                        <img src="Image/Register/用户.PNG" /></div>
                    <div class="rtd-right">
                        <asp:TextBox ID="txtuser" runat="server" Height="30px" Width="95%" placeholder="账号-10个数字"></asp:TextBox></div>
                </div>
                <div class="rtd">
                    <div class="rtd-left"><img src="Image/Register/密码.PNG" /></div>
                    <div class="rtd-right">
                        <asp:TextBox ID="txtpassword" runat="server" Height="30px" Width="95%" placeholder="密码"></asp:TextBox></div>
                </div>
                <div class="rtd">
                    <div class="rtd-left"><img src="Image/Register/密码.PNG" /></div>
                    <div class="rtd-right">
                        <asp:TextBox ID="txtcheckpwd" runat="server" Height="30px" Width="95%" placeholder="确认密码"></asp:TextBox></div>
                </div>
                <div class="rtd">
                    <div class="rtd-left"><img src="Image/Register/邮箱.PNG"/></div>
                    <div class="rtd-right">
                        <asp:TextBox ID="txtemail" runat="server" Height="30px" Width="95%" placeholder="邮箱"></asp:TextBox></div>
                </div>
                <div style="text-align:right">
                    <asp:Button ID="BtnRegister" runat="server" Text="提交" ForeColor="Black" float="right" Font-Size="Large" BorderWidth="1px" BorderColor="Black" Width="150px" Height="30px" OnClick="BtnRegister_Click" /></div>
                <div style="text-align:right">已有账号？<a href="Login.aspx">前往登录</a></div>
            </div>

        </div>
        <div id="footer">footer</div>
    
    
    </form>
</body>
</html>
