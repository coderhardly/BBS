<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PubTheme.ascx.cs" Inherits="Web.PubTheme" %>
<script src="Ueditor/ueditor.config.js"></script>
<script src="Ueditor/ueditor.all.min.js"></script>
<script src="Ueditor/ueditor.all.js"></script>
<style>
    .pubTheme {
        width: 810px;
        background-color: #babbb8;
        margin: 10px auto;
        border-radius: 5px;
        padding: 20px 40px;
        min-height: 450px;
        position:relative;
        text-align:center;
    }
</style>
<div id="pubTheme" class="pubTheme" style="display: none;">
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
    <span>版块：<asp:DropDownList ID="ddlDivision" runat="server"></asp:DropDownList></span>
    <span>标题：<asp:TextBox ID="txtTitle" runat="server" Width="400px"></asp:TextBox></span>
    <script id="myEditor" type="text/plain" style="width:650px;height:300px;margin:10px auto;"></script>
    <asp:Button ID="btnPubTheme" runat="server" Text="发布主题" OnClientClick="getContent()" OnClick="btnPubTheme_Click" Style="width: 80px; height: 30px; background-color: #0094ff;" />
    <input type="button" value="取消" onclick="hidPubTheme()" Style="width: 80px; height: 30px; background-color: #0094ff;"  />
    <script type="text/javascript">
        function getContent() {
            document.getElementById("PubTheme_hidContent").value = encodeURIComponent(ue.getContent());
        }
        function hidPubTheme() {
            document.getElementById("pubTheme").style.display = "none";
        }
    </script>
</div>
