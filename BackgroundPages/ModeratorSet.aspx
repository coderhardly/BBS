<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModeratorSet.aspx.cs" Inherits="Web.ModeratorSet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="CSS/ModeratorSet.css" rel="stylesheet" />
    <link href="../CSS/BackgroundPages/Public.css" rel="stylesheet" />
    <title>版主管理</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
            <fieldset>
                <legend>设置版主</legend>
                <span>
                    <asp:DropDownList ID="ddlDivision" runat="server"></asp:DropDownList>
                    <asp:TextBox ID="txtMemberId" runat="server"></asp:TextBox>
                    <asp:Button ID="btnSetModerator" runat="server" Text="设为版主" OnClick="btnSetModerator_Click" />
                    <asp:Button ID="btnSearch" runat="server" Text="查找" OnClick="btnSearch_Click" />
                </span>
            </fieldset>
            <asp:ListView ID="lvModerator" runat="server" OnItemCommand="lvModerator_ItemCommand">
                <LayoutTemplate>
                    <table class="table" id="itemPlaceholderContainer" runat="server">
                        <tr>
                            <th>版主编号</th>
                            <th>版块名称</th>
                            <th>用户名</th>
                            <th>操作</th>
                        </tr>
                        <tr id="itemPlaceholder"></tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td style="width:140px;">
                            <asp:Label ID="lblModeratorId" runat="server" Text='<%#Eval("moderator_id") %>'></asp:Label>
                        </td>
                        <td style="width:140px;">
                            <asp:Label ID="lblDivisionName" runat="server" Text='<%#Eval("division_name") %>'></asp:Label>
                        </td>
                        <td style="width:410px;word-break: break-all;">
                            <asp:Label ID="lblUserName" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                        </td>
                        <td style="width:140px;">
                            <asp:Button ID="btnDelModerator" runat="server" CommandName="Del" Text="撤销版主" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <asp:DataPager ID="dpModerator" runat="server" PagedControlID="lvModerator"></asp:DataPager>
        </div>
    </form>
</body>
</html>
