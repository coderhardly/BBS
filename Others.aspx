<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Others.aspx.cs" Inherits="Web.Others" %>

<%@ Register Src="~/Header.ascx" TagPrefix="uc1" TagName="Header" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="CSS/Others.css" rel="stylesheet" />
    <title>会员信息详情</title>
    <script>
        window.addEventListener("load", function () {
            var wrapper = document.getElementById("wrapper");
            document.body.removeChild(wrapper);
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header runat="server" ID="Header" />
        <div class="main">
            <div class="msg">
                <div class="hang">
                    <div class="pic" id="divPic" runat="server"></div>
                    <div class="p-right">
                        <div class="p-right-left">
                            <table>
                                <tr>
                                    <td>
                                        <h3>
                                            <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                                        </h3>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="motto"><asp:Label ID="lblMotto" runat="server" Text=""></asp:Label></td>
                                </tr>
                            </table>
                        </div>
                        <div class="p-right-right">
                            <div class="concern">
                                <input id="btnConcern" type="submit" value="关注" runat="server" onserverclick="btnConcern_ServerClick" style="width: 50px; height: 22px;" /></div>
                            <div class="sent">
                                <asp:HyperLink ID="hlkSendMsg" runat="server"><input type="button" value="私信" style="width: 50px; height: 22px;" /></asp:HyperLink></div>
                        </div>
                    </div>
                </div>
                <div class="btm">
                    <div class="num">
                        <asp:Label ID="lblPubTheme" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lblPubCriticism" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="like">
                        <table class="like-tab">
                            <tr>
                                <th>关注人数</th>
                                <th>粉丝数</th>
                            </tr>
                            <tr class="b-td">
                                <td><asp:Label ID="lblConcernNum" runat="server" Text=""></asp:Label></td>
                                <td><asp:Label ID="lblFans" runat="server" Text=""></asp:Label></td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <div class="active">
                他的全部动态
               <%-- <table>
                    <tr></tr>
                </table>--%>
            </div>
        </div>
    </form>
</body>
</html>
