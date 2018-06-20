<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyTheme.aspx.cs" Inherits="Web.MyTheme" %>

<%@ Register Src="~/Header.ascx" TagPrefix="uc1" TagName="Header" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="CSS/List.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:Header runat="server" ID="Header" />
            <div class="list">
                <div>
                    <a href='<%= Web.SomeMethod.GetIndexPath() %>'>首页</a>-><asp:Label ID="lblPath" runat="server" Text="我的主题"></asp:Label>
                </div>
                <asp:ListView ID="lvTheme" runat="server" OnItemCommand="lvTheme_ItemCommand">
                    <LayoutTemplate>
                        <table runat="server" id="itemPlaceholderContainer">
                            <%--<tr class="th">
                                <td colspan="3">
                                    <span>排序方式：</span>
                                    <asp:LinkButton ID="lbTime" runat="server" OnClick="lbTime_Click"><img src="Image/ThemeList/time.png" />时间</a></asp:LinkButton>
                                    <asp:LinkButton ID="lbHot" runat="server" OnClick="lbHot_Click"><img src="Image/ThemeList/hot.png" />热门</asp:LinkButton>
                                    <asp:LinkButton ID="lbEssence" runat="server" OnClick="lbEssence_Click"><img src="Image/ThemeList/essence.png" />精华</asp:LinkButton>
                                    <a onclick="show()">
                                        <img src="Image/ThemeList/createTheme_1.png" title="发表主题" style="float: right;" /></a>
                                </td>
                            </tr>--%>
                            <tr>
                                <td colspan="3">
                                    <hr />
                                </td>
                            </tr>
                            <tr runat="server" id="itemPlaceholder"></tr>
                            <tr>
                                <td colspan="3">
                                    <hr />
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr class="text">
                            <td class="pic">
                                <div>
                                    <input id="themeId" type="hidden" runat="server" value='<%#Eval("theme_id") %>' />
                                    <input id="memberId" type="hidden" runat="server" value='<%#Eval("creator") %>' />
                                </div>
                                <a>
                                    <img src='<%# Web.SomeMethod.GetUserPicPath(Eval("picture")) %>' /></a>
                            </td>
                            <td class="middle">
                                <div>
                                    <div class="title">
                                        <span>
                                            <asp:LinkButton ID="lbTitle" runat="server" CommandName="Link"><%#Eval("title") %></asp:LinkButton>
                                        </span>
                                    </div>
                                    <span class="m_b">
                                        <span class="userName"><%#Eval("name") %></span>
                                        <span class="criticismNum">回复数：<%#Eval("criticism_num") %></span><span class="publishTime"><%#Eval("publish_time") %></span></span>
                                </div>
                            </td>
                            <td class="right">
                                <span>
                                    <span style="display:inline-block">
                                        <span class="r_t">
                                            <%# DisplayImg((bool)Eval("is_settop"),"/Image/ThemeList/hot_1.png") %>
                                            <%# DisplayImg((bool)Eval("is_essence"),"/Image/ThemeList/essence_1.png") %>
                                            <%# DisplayImg((bool)Eval("is_settop"),"/Image/ThemeList/settop_1.png") %>
                                        </span>
                                        <div class="click">点击量：<%#Eval("clicks") %></div>
                                    </span>
                                    <asp:LinkButton ID="lbDelTheme" runat="server" CssClass="del" style="display:inline-block;margin-left:20px;" CommandName="Del">
                                    <img src="Image/ThemeList/delCollect_01.png" title="删除收藏" />
                                    </asp:LinkButton>
                                </span>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <ItemSeparatorTemplate>
                        <tr>
                            <td colspan="3">
                                <hr />
                            </td>
                        </tr>
                    </ItemSeparatorTemplate>
                </asp:ListView>
            </div>
        </div>
    </form>
</body>
</html>
