<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberManage.aspx.cs" Inherits="Web.AddMember" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../CSS/BackgroundPages/Public.css" rel="stylesheet" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 214px;
        }
        .auto-style2 {
            height: 41px;
        }
        .auto-style3 {
            width: 319px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="main">
            <div>
                <asp:TextBox ID="txtPicture" runat="server" Visible="false"></asp:TextBox>
            </div>
            <fieldset>
                <legend style="color:#0094ff;font-size:20px; text-align:left;">会员账号信息</legend>
                <table style="width: 794px; height: 132px; margin-bottom: 24px" >
                    <tr>
                        <td>
                            <asp:Label ID="lblMemberId" runat="server" Text="帐号："></asp:Label>
                            <asp:TextBox ID="txtMemberId" runat="server"></asp:TextBox>
                        </td>
                        <td class="auto-style3">
                            <asp:Label ID="lblName" runat="server" Text="用户名："></asp:Label>
                            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="lblPwd" runat="server" Text="密码："></asp:Label>
                            <asp:TextBox ID="txtPwd" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblXp" runat="server" Text="经验值："></asp:Label>
                            <asp:TextBox ID="txtXp" runat="server"></asp:TextBox>
                        </td>
                        <td class="auto-style3">
                            <asp:Label ID="lblMemberState" runat="server" Text="账号状态："></asp:Label>
                            <asp:TextBox ID="txtMemberState" runat="server"></asp:TextBox>
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="lblFreezeDeadtime" runat="server" Text="冻结到："></asp:Label>
                            <asp:TextBox ID="txtFreezeDeadtime" runat="server" Width="136px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <div>
                   
                    <asp:Button ID="btnEditMember" runat="server" Text="修改" OnClick="btnEditMember_Click" />
                    <asp:Button ID="btnDeleteMember" runat="server" Text="删除" OnClick="btnDeleteMember_Click" />
                    <asp:Button ID="btnEmpty" runat="server" Text="清空" />
                </div>
            </fieldset>
            <fieldset>
                <legend style="color:#0094ff;font-size:20px;">&nbsp;用户个人信息</legend>
                <table style="width: 776px; height: 167px; margin-bottom: 32px">
                    <tr>
                        <td>
                            <asp:Label ID="lblUesrinfoId" runat="server" Text="编号："></asp:Label>
                            <asp:TextBox ID="txtUserinfoId" runat="server" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblUserName" runat="server" Text="姓名："></asp:Label>
                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblAge" runat="server" Text="年龄："></asp:Label>
                            <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblAddr" runat="server" Text="地址："></asp:Label>
                            <asp:TextBox ID="txtAddr" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblSex" runat="server" Text="性别："></asp:Label>
                            <asp:TextBox ID="txtSex" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblTel" runat="server" Text="电话："></asp:Label>
                            <asp:TextBox ID="txtTel" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="lblJob" runat="server" Text="职业："></asp:Label>
                            <asp:TextBox ID="txtJob" runat="server"></asp:TextBox>
                        </td>
                        <td class="auto-style2">
                            <asp:Label ID="lblEmail" runat="server" Text="邮箱："></asp:Label>
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        </td>
                        <td class="auto-style2">
                            <asp:Label ID="lblMotto" runat="server" Text="座右铭："></asp:Label>
                            <asp:TextBox ID="txtMotto" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <div>
                    <asp:Button ID="btnEditUserInfo" runat="server" Text="修改" OnClick="btnEditUserInfo_Click" />
                    <asp:Button ID="btnDeleteUserInfo" runat="server" Text="删除" OnClick="btnDeleteUserInfo_Click" />
                    <asp:Button ID="btnCreateUserInfoId" runat="server" Text="生成编号" OnClick="btnCreateUserInfoId_Click" />
                </div>
            </fieldset>
        </div>
    </form>
</body>
</html>
