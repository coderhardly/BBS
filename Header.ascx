<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Web.Header" %>

<style>
    body {
        margin: 0px;
        border: 0px;
        padding: 0px;
        text-align: left;
        position: relative;
        color: #919090;
        font-family: Tahoma,"微软雅黑","宋体";
        background-color: #f1f1f1;
    }
    .header {
        width: 810px;
        height: 90px;
        margin: 0px auto;
        margin-bottom: 10px;
        background-color: #fff;
        border-radius: 5px;
        padding: 20px 40px;
    }
    .header span {
        margin: 10px 20px 10px 0px;
        float: right;
    }
    .headerImg {
        width: 30px;
        height: 30px;
        margin-top: 10px;
        margin-right: 20px;
        float: right;
    }
</style>
<div class="header">
    <div style="width: 200px; height: 70px; background-color: #4cff00; float: left; margin: 10px;"></div>
    <div style="float: right;">
        <div>
            <a href="MyConcern.aspx">
                <img src="Image/ThemeList/concern_01.png" class="headerImg" title="我的关注" /></a>
            <a href="MyCriticism.aspx">
                <img src="Image/ThemeList/criticism_01.png" class="headerImg" title="我的评论" /></a>
            <a href="MyMessage.aspx">
                <img src="Image/ThemeList/message_01.png" class="headerImg" title="我的消息" /></a>
            <a href="MyCollect.aspx">
                <img src="Image/ThemeList/collect_01.png" class="headerImg" title="我的收藏" /></a>
            <a href="MyTheme.aspx">
                <img src="Image/ThemeList/myTheme_01.png" class="headerImg" title="我的主题" /></a>
            <a href="PersonUpdate.aspx">
                <asp:Image ID="imgHeadPic" runat="server" CssClass="headerImg" /></a>
        </div>
        <span style="float: right;">
            <asp:TextBox ID="txtKey" Style="height: 22px; width: 180px;" runat="server"></asp:TextBox>
            <asp:DropDownList ID="ddlMode" runat="server" Style="height: 28px; width: 60px;">
                <asp:ListItem Selected="True" Text="主题"></asp:ListItem>
                <asp:ListItem Text="会员"></asp:ListItem>
            </asp:DropDownList>
            <asp:ImageButton ID="ibSearch" Style="width: 24px; height: 24px; position: relative; top: 4px;" ImageUrl="Image/ThemeList/search_01.png" runat="server" OnClick="ibSearch_Click" />
        </span>
    </div>
</div>
