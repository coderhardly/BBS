<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyConcern.aspx.cs" Inherits="Web.MyConcern" %>

<%@ Register Src="~/Header.ascx" TagPrefix="uc1" TagName="Header" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="CSS/MyConcern.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header runat="server" ID="Header" />
        <div class="list">
            <span>
                <a href='<%= Web.SomeMethod.GetIndexPath() %>'>首页</a>->我的关注
            </span>
            <asp:ListView ID="vwConcern" runat="server" GroupItemCount="3" OnItemCommand="vwConcern_ItemCommand">
                <LayoutTemplate>
                    <table runat="server" id="itemPlaceholderContainer">
                        <tr>
                            <td id="groupPlaceholder" runat="server"></td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <td>
                        <div class="person">
                            <asp:HiddenField ID="hfldMemberId" runat="server" Value='<%# Eval("member_id") %>' />
                            <div>
                                <asp:LinkButton ID="lbtnMore" runat="server" CommandName="More">
                                    <img class="userPic" src='<%# Web.SomeMethod.GetUserPicPath(Eval("picture")) %>'/>
                                </asp:LinkButton>
                            </div>
                            <span class="line"><%# Eval("name") %></span>
                            <asp:ImageButton ID="ibtnCancal" ImageUrl="/Image/MyConcern/delete_01.png" style="width:30px;height:25px;" runat="server" CommandName="Cancal" />
                        </div>
                    </td>
                </ItemTemplate>
                <GroupTemplate>
                    <td id="itemPlaceholder" runat="server"></td>
                </GroupTemplate>
            </asp:ListView>
        </div>
    </form>
</body>
</html>
