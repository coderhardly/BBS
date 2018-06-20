<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberSet.aspx.cs" Inherits="Web.MemberSet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../CSS/BackgroundPages/Public.css" rel="stylesheet" />
    <title>会员管理</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
            <fieldset>
                <legend>会员查找</legend>
                <asp:DropDownList ID="ddlMemberSearch" runat="server">
                    <asp:ListItem Value="所有"></asp:ListItem>
                    <asp:ListItem Value="账号"></asp:ListItem>
                    <asp:ListItem Value="用户名"></asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtKey" runat="server"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="查找" OnClick="btnSearch_Click" />
            </fieldset>
            <asp:ListView ID="lvMember" runat="server" OnItemCommand="lvMember_ItemCommand">
                <LayoutTemplate>
                    <table class="table" runat="server" id="itemPlaceholderContainer">
                        <tr>
                            <th style="width:90px;">账号</th>
                            <th>用户名</th>
                            <th style="width:85px;">经验值</th>
                            <th style="width:190px;">上次登录时间</th>
                            <th style="width:100px;">操作</th>
                        </tr>
                        <tr id="itemPlaceholder" runat="server"></tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr class="tr">
                        <td>
                            <asp:Label ID="lblMemberId" runat="server" Text='<%#Eval("member_id") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("name") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="lblXp" runat="server" Text='<%#Eval("xp") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="lblLastTimeOnline" runat="server" Text='<%#Eval("lasttime_online") %>'></asp:Label></td>
                        <td>
                            <asp:Button ID="btnEdit" runat="server" CommandName="Edit" Text="编辑" />
                            <asp:Button ID="btnDelete" runat="server" CommandName="Del" Text="删除" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </form>
</body>
</html>
