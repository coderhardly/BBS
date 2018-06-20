<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MessageSet.aspx.cs" Inherits="Web.MessageSet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../CSS/BackgroundPages/Public.css" rel="stylesheet" />
    <title>消息管理</title>
    <style>
        .sel {
            width: 80px;
            height: 22px;
            padding: 10px 0px;
            line-height: 22px;
            text-align: center;
            display: inline-block;
            background-color: #f1f1f1;
            color: #000000;
            border-radius: 5px 5px 0px 0px;
            margin-bottom:-10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
            <div>
                <div class="sel">
                    <asp:LinkButton ID="lbtnNormal" runat="server" OnClick="lbtnNormal_Click">普通</asp:LinkButton>
                </div>
                <div class="sel">
                    <asp:LinkButton ID="lbtnReport" runat="server" OnClick="lbtnReport_Click">举报</asp:LinkButton>
                </div>
                <div class="sel">
                    <asp:LinkButton ID="lbtnRequestModerator" runat="server" OnClick="lbtnRequestModerator_Click">申请版主</asp:LinkButton>
                </div>
                <div class="sel">
                    <asp:LinkButton ID="lbtnResignModerator" runat="server" OnClick="lbtnResignModerator_Click">辞去版主</asp:LinkButton>
                </div>
                <asp:CheckBox ID="ckbShowViewed" runat="server" Text="显示已查看" Checked="false" style="float:right;margin-top:10px;margin-right:20px;" />
                <script>
                    function divClick(show) {
                        //设置所有选项卡的背景颜色
                        var all = document.getElementsByClassName("sel");
                        for (var i = 0; i < all.length; i++) {
                            all[i].style.backgroundColor = "#f1f1f1";
                        }
                        //隐藏所有listview
                        var vw = document.getElementsByClassName("vw");
                        for (var i = 0; i < vw.length; i++) {
                            vw[i].style.display = "none";
                        }
                        //获取触发事件的节点
                        event = event ? event : window.event;
                        var obj = event.srcElement ? event.srcElement : event.target;
                        obj.style.backgroundColor = "#1697ba";
                        //显示选项卡对应的listview
                        document.getElementById(show).style.display = "table";
                    }
                </script>
            </div>
            <asp:ListView ID="vwNormal" runat="server" OnItemCommand="vwNormal_ItemCommand">
                <LayoutTemplate>
                    <table runat="server" id="itemPlaceholderContainer" class="vw">
                        <tr>
                            <th><span>发送者</span></th>
                            <th><span>消息内容</span></th>
                            <th><span>创建时间</span></th>
                            <th><span>操作</span></th>
                        </tr>
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td style="width:90px;"><span><%#Eval("sender") %></span></td>
                        <td style="width:500px;"><span><%#Eval("message_text") %></span></td>
                        <td style="width:190px;"><span><%#Eval("create_time") %></span></td>
                        <td style="width:50px;">
                            <asp:HiddenField ID="hfldMessageId" runat="server" Value='<%#Eval("message_id") %>' />
                            <asp:Button ID="btnReview" runat="server" CommandName="View" Text="查看" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <asp:ListView ID="vwReport" runat="server" OnItemCommand="vwReport_ItemCommand">
                <LayoutTemplate>
                    <table runat="server" id="itemPlaceholderContainer" class="vw">
                        <tr>
                            <th><span>发送者</span></th>
                            <th><span>消息内容</span></th>
                            <th><span>创建时间</span></th>
                            <th><span>操作</span></th>
                        </tr>
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td style="width:90px;">
                            <asp:HiddenField ID="hfldBeReported" runat="server" Value="从消息中获取" />
                            <asp:Label ID="lblSender" runat="server" Text='<%#Eval("sender") %>'></asp:Label>
                        </td>
                        <td style="width:440px;"><span><%#Eval("message_text") %></span></td>
                        <td style="width:190px;"><span><%#Eval("create_time") %></span></td>
                        <td style="width:150px;">
                            <asp:HiddenField ID="hfldMessageId" runat="server" Value='<%#Eval("message_id") %>' />
                            <asp:Button ID="btnNot" runat="server" CommandName="Not" Text="内容不实" />
                            <asp:Button ID="btnYes" runat="server" CommandName="Yes" Text="前往处理" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <asp:ListView ID="vwRequestModerator" runat="server" OnItemCommand="vwRequestModerator_ItemCommand">
                <LayoutTemplate>
                    <table runat="server" id="itemPlaceholderContainer" class="vw">
                        <tr>
                            <th><span>发送者</span></th>
                            <th><span>消息内容</span></th>
                            <th><span>创建时间</span></th>
                            <th><span>操作</span></th>
                        </tr>
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:HiddenField ID="hfldBeReported" runat="server" Value="从消息中获取" />
                            <asp:Label ID="lblSender" runat="server" Text='<%#Eval("sender") %>'></asp:Label>
                        </td>
                        <td><span><%#Eval("message_text") %></span></td>
                        <td><span><%#Eval("create_time") %></span></td>
                        <td>
                            <asp:HiddenField ID="hfldMessageId" runat="server" Value='<%#Eval("message_id") %>' />
                            <asp:Button ID="btnAgree" runat="server" CommandName="Agree" Text="同意" />
                            <asp:Button ID="btnDisagree" runat="server" CommandName="Disagree" Text="拒绝" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <asp:ListView ID="vwResignModerator" runat="server" OnItemCommand="vwResignModerator_ItemCommand">
                <LayoutTemplate>
                    <table runat="server" id="itemPlaceholderContainer" class="vw">
                        <tr>
                            <th><span>发送者</span></th>
                            <th><span>消息内容</span></th>
                            <th><span>创建时间</span></th>
                            <th><span>操作</span></th>
                        </tr>
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:HiddenField ID="hfldBeReported" runat="server" Value="从消息中获取" />
                            <asp:Label ID="lblSender" runat="server" Text='<%#Eval("sender") %>'></asp:Label>
                        </td>
                        <td><span><%#Eval("message_text") %></span></td>
                        <td><span><%#Eval("create_time") %></span></td>
                        <td>
                            <asp:HiddenField ID="hfldMessageId" runat="server" Value='<%#Eval("message_id") %>' />
                            <asp:Button ID="btnAgree" runat="server" CommandName="Agree" Text="同意" />
                            <asp:Button ID="btnDisagree" runat="server" CommandName="Disagree" Text="拒绝" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </form>
</body>
</html>
