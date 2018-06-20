<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CriticismSet.aspx.cs" Inherits="Web.CriticismSet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../CSS/BackgroundPages/Public.css" rel="stylesheet" />
    <title>评论管理</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
            <fieldset>
                <legend>评论查找</legend>
                <asp:DropDownList ID="ddlKey" runat="server">
                    <asp:ListItem Value="所有" Selected="True">所有</asp:ListItem>
                    <asp:ListItem Value="主题">主题</asp:ListItem>
                    <asp:ListItem Value="会员">会员</asp:ListItem>
                    <asp:ListItem Value="编号">编号</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtKey" runat="server"></asp:TextBox>
                <asp:Button ID="btnSelect" runat="server" Text="查找" OnClick="btnSelect_Click" />
            </fieldset>
            <asp:ListView ID="lvCriticism" runat="server" OnItemCommand="lvCriticism_ItemCommand">
                <LayoutTemplate>
                    <table class="table" runat="server" id="itemPlaceholderContainer">
                        <tr>
                            <%--<th>评论编号</th>--%>
                            <th>内容</th>
                            <th>操作</th>
                            <%--<th>创建者</th>
                            <th>所属主题</th>
                            <th>关联评论</th>
                            <th>发布时间</th>--%>
                        </tr>
                        <tr id="itemPlaceholder" runat="server"></tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <%--<td>
                            <asp:Label ID="lblCriticismId" runat="server" Text='<%#Eval("criticism_id") %>'></asp:Label>
                        </td>--%>
                        <td style="width:650px;word-break:break-all;">
                            <asp:HiddenField ID="hfldCriticismId" runat="server" Value='<%#Eval("criticism_id") %>' />
                            <asp:Label ID="lblCriticismText" runat="server" Text='<%#Eval("criticism_text") %>'></asp:Label>
                        </td>
                        <td style="width:180px;">
                            <a href='<%# "MemberManage.aspx?memberId="+ Eval("member_id") %>'><input type="button" value="查看会员" /></a>
                            <asp:Button ID="btnDel" runat="server" CommandName="Del" Text="删除" />
                        </td>
                        <%--<td>
                            <asp:Label ID="lblThemeId" runat="server" Text='<%#Eval("theme_id") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="lblConnectedCriticism" runat="server" Text='<%#Eval("connected_criticism") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPublishTime" runat="server" Text='<%#Eval("publish_time") %>'></asp:Label>
                        </td>--%>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </form>
</body>
</html>
