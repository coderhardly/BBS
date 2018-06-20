<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThemeSearch.aspx.cs" Inherits="Web.ThemeSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="CSS/List.css" rel="stylesheet" />
    <title>主题搜索</title>
    <style>
        .search {
            width: 810px;
            background-color: #fff;
            margin: 10px auto;
            border-radius: 5px;
            padding: 20px 40px;
        }
        #txtSearch {
            width: 395px;
            height: 27px;
            /*margin-top:2px;*/
            padding-left: 20px;
            font-size: 17px;
            color: #000000;
            /*position:relative;*/
        }
        #btnSearch {
            width: 100px;
            height: 34px;
            border: 0px;
            background-color: #3385ff;
            color: #fff;
            font-size: 14px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="search">
                <img src="Image/ThemeList/themeSearch_01.png" style="width: 132px; height: 33px; position: relative; top: 12px;" />
                <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="主题搜索" OnClick="btnSearch_Click" />
            </div>
            <div class="list">
                <span>
                    <a href='<%= Web.SomeMethod.GetIndexPath() %>' >首页</a>-><asp:Label ID="lblPath" runat="server" Text="主题查询"></asp:Label>
                </span>
                <asp:ListView ID="lvTheme" runat="server" OnItemCommand="lvTheme_ItemCommand">
                    <LayoutTemplate>
                        <table runat="server" id="itemPlaceholderContainer">
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
                                    <img src='<%# Web.SomeMethod.GetUserPicPath(Eval("picture")) %>' class="pic" /></a>
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
                                <span class="r_t">
                                    <%# DisplayImg((bool)Eval("is_settop"),"/Image/ThemeList/hot_1.png") %>
                                    <%# DisplayImg((bool)Eval("is_essence"),"/Image/ThemeList/essence_1.png") %>
                                    <%# DisplayImg((bool)Eval("is_settop"),"/Image/ThemeList/settop_1.png") %>
                                </span>
                                <div class="click">点击量：<%#Eval("clicks") %></div>
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
                <%--<asp:DataPager ID="dpTheme" PagedControlID="lvTheme" runat="server" OnPreRender="dpTheme_PreRender">
                <Fields>
                    <asp:NextPreviousPagerField FirstPageText="首页" ShowFirstPageButton="True" ShowNextPageButton="False" />
                    <asp:NumericPagerField />
                    <asp:NextPreviousPagerField LastPageText="尾页" ShowLastPageButton="True" ShowPreviousPageButton="False" />
                </Fields>
            </asp:DataPager>--%>
            </div>
        </div>
    </form>
</body>
</html>
