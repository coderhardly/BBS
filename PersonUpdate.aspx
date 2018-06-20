<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonUpdate.aspx.cs" Inherits="Web.PersonUpdate" %>

<%@ Register Src="~/Header.ascx" TagPrefix="uc1" TagName="Header" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="CSS/PersonUpdate.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header runat="server" ID="Header" />
        <div id="edit">
            <div id="pic" runat="server" onmouseover="this.children[0].children[0].style.display='inline';" onmouseout="this.children[0].children[0].style.display='none';">
                <a onclick="show()">
                    <img class="picEdit" src="Image/EditInformation/edit.png" />
                </a>
                <script>
                    function show() {
                        document.getElementById("changePic").style.display = "inline";
                    }
                    function hid() {
                        document.getElementById("changePic").style.display = "none";
                    }
                </script>
            </div>
            <div id="changePic">
                <span>
                    <asp:FileUpload ID="pic_upload" runat="server" /></span>
                <div></div>
                <span>
                    <input id="subUpload" type="submit" value="上传" runat="server" onserverclick="subUpload_ServerClick" />
                    <input type="button" value="取消" onclick="hid()" />
                </span>
            </div>
            <fieldset class="ta">
                <legend>基本信息</legend>
                <table>
                    <tr>
                        <td>昵称: </td>
                        <td>
                            <input type="text" name="username" runat="server" id="username" /></td>
                    </tr>
                    <tr>
                        <td>真实姓名: </td>
                        <td>
                            <input type="text" name="realname" runat="server" id="realname" /></td>
                    </tr>
                    <tr>
                        <td>性别： </td>
                        <td>
                            <asp:RadioButtonList ID="radlSex" runat="server" style="display:table;">
                                <asp:ListItem Value="男"></asp:ListItem>
                                <asp:ListItem Value="女"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>年龄: </td>
                        <td>
                            <input type="text" name="age" runat="server" id="age" />
                        </td>
                    </tr>
                    <tr>
                        <td>所在地： </td>
                        <td>
                            <input type="text" name="adress" runat="server" id="adress" /></td>
                    </tr>
                    <tr>
                        <td>职业： </td>
                        <td>
                            <input type="text" name="job" runat="server" id="job" /></td>
                    </tr>
                    <tr>
                        <td>个性签名：
                        </td>
                        <td>
                            <textarea rows="3" cols="30" runat="server" id="motto">
					</textarea>
                        </td>
                    </tr>
                    <tr>
                        <td>邮箱地址： </td>
                        <td>
                            <input type="text" name="mail" runat="server" id="email" placeholder="student@bdqn.cn" /></td>
                    </tr>
                    <tr>
                        <td>电话号码： </td>
                        <td>
                            <input type="text" name="phone" runat="server" id="phone" /></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <input type="image" id="subEdit" src="../Image/Person/btn_save.gif" runat="server" onserverclick="subEdit_ServerClick" /></td>
                    </tr>
                </table>
            </fieldset>
            <fieldset class="ta">
                <legend>修改密码</legend>
                <table>
                    <tr>
                        <td>旧密码： </td>
                        <td>
                            <input type="text" name="oldPwd" runat="server" id="oldPwd" /></td>
                    </tr>
                    <tr>
                        <td>新密码： </td>
                        <td>
                            <input type="text" name="newPwd" runat="server" id="newpwd" /></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <input type="image" src="../Image/Person/btn_save.gif" id="ChangePwd" runat="server" onserverclick="ChangePwd_ServerClick" /></td>
                    </tr>
                </table>
            </fieldset>
        </div>
    </form>
</body>
</html>
