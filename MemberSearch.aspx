<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberSearch.aspx.cs" Inherits="Web.MemberSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="CSS/MemberSearch.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="search">
                <img src="Image/MemberSearch/MemberSearch_01.png" style="width: 132px; height: 33px; position: relative; top: 12px;" />
                <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="会员搜索" OnClick="btnSearch_Click" />
            </div>
            <div class="list">
                <span>
                    <a href='<%= Web.SomeMethod.GetIndexPath() %>' >首页</a>->主题查询
                </span>
                <asp:ListView ID="lvMember" runat="server" OnItemCommand="lvMember_ItemCommand">
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
                        <tr>
                            <td class="pic">
                                <asp:HyperLink ID="hlkPic" runat="server" NavigateUrl='<%# "~/Others.aspx?memberId="+Eval("member_id") %>'><img src='<%# Web.SomeMethod.GetUserPicPath(Eval("picture")) %>' /></asp:HyperLink>
                            </td>
                            <td>
                                <div class="msg">
                                    <span>
                                        <asp:HiddenField ID="hidMemberId" runat="server" Value='<%#Eval("member_id") %>' />
                                        <asp:Label ID="lbl" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                                        <asp:Image ID="imgSex" runat="server" ImageUrl='<%# GetSexImg(Eval("sex")) %>' title="性别" Style="width: 20px; height: 20px; background-size: contain;" />
                                        <asp:Image ID="imgLevel" runat="server" ImageUrl='<%# Web.SomeMethod.GetLevelPicPath(Eval("sex")) %>' title="等级" Style="width: 50px; height: 20px; background-size: contain;" />
                                        <span class="hid">
                                            <asp:LinkButton ID="lkMsgSend" runat="server" CommandName="MsgSend"><img src="Image/MemberSearch/msgSend_01.png" title="发送消息" /></asp:LinkButton>
                                            <asp:LinkButton ID="lkConcern" runat="server" CommandName="Concern"><img src="Image/MemberSearch/concern_01.png" title="关注" /></asp:LinkButton>
                                        </span>
                                    </span>
                                    <br />
                                    <span class="count">
                                        <asp:Label ID="lblThemeNum" runat="server" Text='<%# "发表主题数："+Eval("themeNum") %>'></asp:Label>
                                        <asp:Label ID="lblCriticismNum" runat="server" Text='<%# "发表评论数："+Eval("criticismNum") %>'></asp:Label>
                                        <asp:Label ID="lblClickNum" runat="server" Text='<%# "主题总点击量："+Eval("clickNum") %>'></asp:Label>
                                    </span>
                                </div>
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
