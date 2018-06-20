<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThemeList.aspx.cs" Inherits="Web.ThemeList" %>

<%@ Register Src="~/PubTheme.ascx" TagPrefix="uc1" TagName="PubTheme" %>
<%@ Register Src="~/Header.ascx" TagPrefix="uc1" TagName="Header" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="CSS/List.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="position: relative;">
        <uc1:Header runat="server" ID="Header" />
        <div class="divisionMsg">
            <span>
                <asp:Label ID="lblDivisionName" runat="server" Style="color: red;"></asp:Label>
                <asp:Label ID="lblModeratorName" runat="server" Text=""></asp:Label>
                <asp:Button ID="btnApply" runat="server" Text="申请版主" OnClick="btnApply_Click" Style="float: right; margin-left: 30px;" />
                <asp:Button ID="btnResign" runat="server" Text="辞去版主" OnClick="btnResign_Click" Style="float: right" />
            </span>
            <br />
            <asp:Label ID="lblBulletin" runat="server" Text=""></asp:Label>
        </div>
        <uc1:PubTheme runat="server" ID="PubTheme" />
        <div class="list">
            <div style="">
                <a href='<%# Web.SomeMethod.GetIndexPath() %>'>首页</a>-><asp:Label ID="lblDivision" runat="server"></asp:Label>
            </div>
            <div class="th">
                <span>排序方式：</span>
                <asp:LinkButton ID="lbTime" runat="server" OnClick="lbTime_Click"><img src="Image/ThemeList/time.png" />时间</asp:LinkButton>
                <asp:LinkButton ID="lbHot" runat="server" OnClick="lbHot_Click"><img src="Image/ThemeList/hot.png" />热门</asp:LinkButton>
                <asp:LinkButton ID="lbEssence" runat="server" OnClick="lbEssence_Click"><img src="Image/ThemeList/essence.png" />精华</asp:LinkButton>
                <a href="javascript:showPubTheme()">
                    <img src="Image/ThemeList/createTheme_1.png" title="发表主题" style="float: right;" /></a>
                <script type="text/javascript">
                    function showPubTheme() {
                        document.getElementById("pubTheme").style.display = "block";
                    }
                </script>
            </div>
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
                        <td>
                            <div>
                                <input id="themeId" type="hidden" runat="server" value='<%#Eval("theme_id") %>' />
                                <input id="memberId" type="hidden" runat="server" value='<%#Eval("creator") %>' />
                            </div>
                            <div>
                                <a href='<%# "Others.aspx?memberId="+Eval("creator") %>'>
                                    <img src='<%# Web.SomeMethod.GetUserPicPath(Eval("picture")) %>' class="pic" /></a>
                            </div>
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
    </form>
</body>
</html>
