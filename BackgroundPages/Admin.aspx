<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Web.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../CSS/BackgroundPages/Admin.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="head">
                <div class="head-pic" id="pic" runat="server">
                </div>
                <h2 style="float: left; color: #000000;">后台管理界面</h2>
                <div class="back">
                    <a href="../Index.aspx" target="_blank"><img src="../Image/Admin/返回首页.png" /></a>
                </div>
                <div class="off">
                    <asp:ImageButton ID="ibtnExit" runat="server" ImageUrl="../Image/Admin/退出登录.png" OnClick="ibtnExit_Click" style="width:35px;
     height:35px;" />
                </div>
            </div>
            <div class="all">
                <div id="menu">
                    <div class="menu-name">
                    </div>
                    <asp:TreeView runat="server" ID="tvRoute">
                        <Nodes>
                            <asp:TreeNode Text="&nbsp;&nbsp;&nbsp;会员管理" Value="会员管理" NavigateUrl="~/BackgroundPages/MemberSet.aspx" ImageUrl="../Image/Admin/会员管理.png" Target="main"></asp:TreeNode>
                            <asp:TreeNode Text="&nbsp;&nbsp;&nbsp;版块管理" Value="版块管理" NavigateUrl="~/BackgroundPages/DivisionSet.aspx" ImageUrl="../Image/Admin/版块管理.png" Target="main"></asp:TreeNode>
                            <asp:TreeNode Text="&nbsp;&nbsp;&nbsp;版主管理" Value="版主管理" NavigateUrl="~/BackgroundPages/ModeratorSet.aspx" ImageUrl="../Image/Admin/会员管理.png" Target="main"></asp:TreeNode>
                            <asp:TreeNode Text="&nbsp;&nbsp;&nbsp;主题管理" Value="主题管理" NavigateUrl="~/BackgroundPages/ThemeSet.aspx" ImageUrl="../Image/Admin/主题管理.png" Target="main"></asp:TreeNode>
                            <asp:TreeNode Text="&nbsp;&nbsp;&nbsp;查看消息" Value="消息管理" NavigateUrl="~/BackgroundPages/MessageSet.aspx" ImageUrl="../Image/Admin/消息管理.png" Target="main"></asp:TreeNode>
                            <asp:TreeNode Text="&nbsp;&nbsp;&nbsp;评论管理" Value="评论管理" NavigateUrl="~/BackgroundPages/CriticismSet.aspx" ImageUrl="../Image/Admin/评论管理.png" Target="main"></asp:TreeNode>
                        </Nodes>
                    </asp:TreeView>
                </div>
                <iframe name="main" id="main" frameborder="0"></iframe>
            </div>
        </div>
    </form>
</body>
</html>
