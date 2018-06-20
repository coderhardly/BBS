<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DivisionSet.aspx.cs" Inherits="Web.DivisionSet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../CSS/BackgroundPages/Public.css" rel="stylesheet" />
    <title>版块管理</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
            <fieldset>
                <legend>版块管理</legend>
                <span>
                    <asp:Label ID="lblDivisionId" runat="server" Text="版块编号："></asp:Label>
                    <asp:TextBox ID="txtDivisionId" runat="server"></asp:TextBox>
                </span>
                <span>
                    <asp:Label ID="lblDivisionName" runat="server" Text="版块名称："></asp:Label>
                    <asp:TextBox ID="txtDivisionName" runat="server"></asp:TextBox>
                </span>
                <span>
                    <asp:FileUpload ID="flulDivisionPicture" runat="server" />
                </span>
                <div style="margin-top:5px;">
                    <asp:Button ID="btnCreateDivision" runat="server" Text="新建" OnClick="btnCreateDivision_Click" />
                    <asp:Button ID="btnEditDivision" runat="server" Text="修改" OnClick="btnEditDivision_Click" />
                    <asp:Button ID="btnDeleteDivision" runat="server" Text="删除" OnClick="btnDeleteDivision_Click" />
                </div>


            </fieldset>
            <asp:ListView ID="lvDivision" runat="server" OnItemCommand="lvDivision_ItemCommand">
                <LayoutTemplate>
                    <table class="table" runat="server" id="itemPlaceholderContainer">
                        <tr>
                            <th>编号</th>
                            <th>名称</th>
                            <th>操作</th>
                        </tr>
                        <tr id="itemPlaceholder" runat="server"></tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td style="text-align: center">
                            <asp:Label ID="lblDivisionId" runat="server" Text='<%#Eval("division_id") %>'></asp:Label>
                        </td>
                        <td style="text-align: center">
                            <asp:Label ID="lblDivisionName" runat="server" Text='<%#Eval("division_name") %>'></asp:Label>
                        </td>
                        <td style="text-align: center;">
                            <asp:Button ID="btnSelect" runat="server" CommandName="Check" Text="选择" />
                            <asp:Button ID="btnDelete" runat="server" CommandName="Del" Text="删除" />
                            <asp:Button ID="btnModerator" runat="server" CommandName="FindModerator" Text="查看版主" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </form>
</body>
</html>
