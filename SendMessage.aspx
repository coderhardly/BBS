<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendMessage.aspx.cs" Inherits="Web.SendMessage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <span>接收者:<asp:TextBox ID="txtRecipient" runat="server"></asp:TextBox></span>
            <div>
                <asp:TextBox ID="txtMsg" runat="server"></asp:TextBox></div>
            <span>
                <asp:Button ID="btnSend" runat="server" Text="发送" OnClick="btnSend_Click" /></span>
        </div>
    </form>
</body>
</html>
