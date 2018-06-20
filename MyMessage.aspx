<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyMessage.aspx.cs" Inherits="Web.MyMessage" %>

<%@ Register Src="~/Header.ascx" TagPrefix="uc1" TagName="Header" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="CSS/MyMessage.css" rel="stylesheet" />
    <script src="Ueditor/ueditor.config.js"></script>
    <script src="Ueditor/ueditor.all.min.js"></script>
    <script src="Ueditor/ueditor.all.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header runat="server" ID="Header" />
        <div class="list">
            <div>
                <a href='<%= Web.SomeMethod.GetIndexPath() %>'>首页</a>-><span>我的消息</span>
            </div>
            <div>
                <div class="sel" onclick="divClick('vwNotView_itemPlaceholderContainer')" style="background-color: #1697ba;">我接收</div>
                <div class="sel" onclick="divClick('vwSend_itemPlaceholderContainer')">我发送</div>
                <div class="sel" onclick="divClick('vwReview_itemPlaceholderContainer')">已查看</div>
                <div class="sel" onclick="divClick('create');">编写消息</div>
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
            <asp:ListView ID="vwNotView" runat="server">
                <LayoutTemplate>
                    <table runat="server" id="itemPlaceholderContainer" class="vw">
                        <tr>
                            <td><span>发送者</span></td>
                            <td><span>消息内容</span></td>
                            <td><span>创建时间</span></td>
                            <td><span>操作</span></td>
                        </tr>
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:HiddenField ID="hfldMessageId" runat="server" />
                            <span><%#Eval("sender") %></span></td>
                        <td><span><%#Eval("message_text") %></span></td>
                        <td><span><%#Eval("create_time") %></span></td>
                        <td><span>
                            <asp:Button ID="btnReview" runat="server" Text="查看" /></span></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <asp:ListView ID="vwSend" runat="server" class="vw">
                <LayoutTemplate>
                    <table runat="server" id="itemPlaceholderContainer" class="vw" style="display: none;">
                        <tr>
                            <td><span>接收者</span></td>
                            <td><span>消息内容</span></td>
                            <td><span>创建时间</span></td>
                            <td><span>操作</span></td>
                        </tr>
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:HiddenField ID="hfldMessageId" runat="server" Value='<%#Eval("message_id") %>' />
                            <span><%#Eval("recipient") %></span></td>
                        <td><span><%#Eval("message_text") %></span></td>
                        <td><span><%#Eval("create_time") %></span></td>
                        <td><span>
                            <asp:Button ID="btnDel" runat="server" Text="删除" /></span></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <asp:ListView ID="vwReview" runat="server">
                <LayoutTemplate>
                    <table runat="server" id="itemPlaceholderContainer" class="vw" style="display: none;">
                        <tr>
                            <td><span>发送者</span></td>
                            <td><span>消息内容</span></td>
                            <td><span>创建时间</span></td>
                            <td><span>操作</span></td>
                        </tr>
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:HiddenField ID="hfldMessageId" runat="server" />
                            <span><%#Eval("sender") %></span></td>
                        <td><span><%#Eval("message_text") %></span></td>
                        <td><span><%#Eval("create_time") %></span></td>
                        <td><span>
                            <asp:Button ID="btnReview" runat="server" Text="查看" /></span></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <div id="create" class="vw" style="display: none; width: 100%;">
                <div style="background-color: #1697ba; height: 20px; padding: 10px 5%; color: #000000;">
                    接收者：<asp:TextBox ID="txtMemberId" runat="server" placeholder="用户账号"></asp:TextBox>
                </div>
                <div id="pubCriticism" class="pubCriticism">
                    <div>
                        <!-- 配置文件 -->
                        <script type="text/javascript" src="ueditor.config.js"></script>
                        <!-- 编辑器源码文件 -->
                        <script type="text/javascript" src="ueditor.all.js"></script>
                        <!-- 实例化编辑器 -->
                        <script type="text/javascript">
                            var ue = UE.getEditor('myEditor');
                        </script>
                    </div>
                    <asp:HiddenField ID="hidContent" runat="server"></asp:HiddenField>
                    <script id="myEditor" type="text/plain" style="width: 650px; height: 300px; margin: 10px auto;"></script>
                    <asp:Button ID="btnPubCriticism" runat="server" Text="发送消息" OnClientClick="getContent()" OnClick="btnPubCriticism_Click" Style="width: 80px; height: 30px; background-color: #0094ff;" />
                    <script type="text/javascript">
                        function getContent() {
                            document.getElementById("hidContent").value = encodeURIComponent(ue.getContent());
                        }
                        function hidpubCriticism() {
                            document.getElementById("pubCriticism").style.display = "none";
                        }
                    </script>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
