<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyCriticism.aspx.cs" Inherits="Web.MyCriticism" %>

<%@ Register Src="~/Header.ascx" TagPrefix="uc1" TagName="Header" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="CSS/MyCriticism.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:Header runat="server" ID="Header" />
            <div class="list">
                <span>
                    <a href='<%= Web.SomeMethod.GetIndexPath() %>'>首页</a>->我的评论
                </span>
                <asp:ListView ID="vwCriticism" runat="server">
                    <LayoutTemplate>
                        <div id="itemPlaceholderContainer" runat="server">
                            <div id="itemPlaceholder" runat="server"></div>
                        </div>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <div class="tr">
                            <span class="title"><strong>主题标题：</strong>
                                <asp:HyperLink ID="hlkTitle" runat="server" NavigateUrl='<%# "~/ThemeDisplay.aspx?themeId="+Eval("theme_id") %>' ><%# Eval("title") %></asp:HyperLink>
                            </span>
                            <div class="text">
                                <asp:HiddenField ID="hfldCriticismId" runat="server" Value='<%# Eval("criticism_id") %>' />
                                <div><%# Eval("myCriticism") %></div>
                                <fieldset <%# ShowReplyTo(Eval("toCriticism")) %>>
                                    <legend>回复
                                        <asp:HyperLink ID="hlkMember" runat="server" NavigateUrl='<%# "Others.aspx?memberId="+Eval("member_id") %>' ><%# Eval("name") %></asp:HyperLink></legend>
                                    <div><%# Eval("toCriticism") %></div>
                                </fieldset>
                            </div>
                            <span class="time"><%# "发表于:"+Eval("publish_time") %></span>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
    </form>
</body>
</html>
