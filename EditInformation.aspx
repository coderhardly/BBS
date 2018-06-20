<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="EditInformation.aspx.cs" Inherits="Web.EditImformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server" style="">
    <link href="CSS/EditInformation.css" rel="stylesheet" />
    <link href="CSS/EditInformation/UploadPic.css" rel="stylesheet" />
    <div id="edit">
        <div id="pic" onmouseover="this.children[0].children[0].style.display='inline';" onmouseout="this.children[0].children[0].style.display='none';">
            <a onclick="">
                <img class="picEdit" src="Image/EditInformation/edit.png" style="display:none;width:30px;height:30px;" /></a>
        </div>
        <div id="changePic">
            <span>
                <asp:FileUpload ID="pic_upload" runat="server" /></span>
            <div></div>
            <span>
                <input id="subUpload" type="submit" value="上传" runat="server" onserverclick="subUpload_ServerClick" />
                <input type="button" value="取消" />
            </span>
        </div>
        <fieldset class="ta">
            <legend>基本信息</legend>
            <table>
                <tr>
                    <td>昵称: </td>
                    <td>
                        <input type="text" name="username" id="username" /></td>
                </tr>
                <tr>
                    <td>真实姓名: </td>
                    <td>
                        <input type="text" name="realname" id="realname" /></td>
                </tr>
                <tr>
                    <td>性别： </td>
                    <td>
                        <input type="radio" name="sex" id="man" />
                        男
                        <input type="radio" name="sex" id="woman" />
                        女 </td>
                </tr>
                <tr>
                    <td>生日: </td>
                    <td>
                        <select name="year" id="">
                            <option value="1990">1990</option>
                            <option value="1991">1991</option>
                            <option value="1992">1992</option>
                            <option value="1993">1993</option>
                            <option value="1994">1994</option>
                            <option value="1995">1995</option>
                            <option value="1996">1996</option>
                            <option value="1997">1997</option>
                            <option value="1998">1998</option>
                            <option value="1999">1999</option>
                            <option value="2000">2000</option>
                            <option value="2001">2001</option>
                            <option value="2002">2002</option>
                        </select>
                        <select name="mon">
                            <option value="01" selected="selected">01</option>
                            <option value="02">02</option>
                            <option value="03">03</option>
                            <option value="04">04</option>
                            <option value="05">05</option>
                            <option value="06">06</option>
                            <option value="07">07</option>
                            <option value="08">08</option>
                            <option value="09">09</option>
                            <option value="10">10</option>
                            <option value="11">11</option>
                            <option value="12">12</option>
                        </select>
                        <select name="day">
                            <option value="01">01</option>
                            <option value="02">02</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>所在地： </td>
                    <td>
                        <input type="text" name="adress" id="adress" /></td>
                </tr>
                <tr>
                    <td>职业： </td>
                    <td>
                        <input type="text" name="job" id="job" /></td>
                </tr>
                <tr>
                    <td>证件类型：
                    </td>
                    <td>
                        <select name="type" id="type">
                            <option value="ID">身份证</option>
                            <option value="StudentIDcard">学生证</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>个性签名：
                    </td>
                    <td>
                        <textarea rows="3" cols="30">
					</textarea>
                    </td>
                </tr>
            </table>
        </fieldset>
        <fieldset class="ta">
            <legend>联系方式</legend>
            <table>
                <tr>
                    <td>邮箱地址： </td>
                    <td>
                        <input type="text" name="mail" placeholder="student@bdqn.cn" /></td>
                </tr>
                <tr>
                    <td>电话号码： </td>
                    <td>
                        <input type="text" name="phone" id="phone" /></td>
                </tr>
                <tr>
                    <td>MSN： </td>
                    <td>
                        <input type="text" name="MSN" /></td>
                </tr>
            </table>
        </fieldset>
        <fieldset class="ta">
            <legend>工作信息</legend>
            <table>
                <tr>
                    <td>公司： </td>
                    <td>
                        <input type="text" name="company" /></td>
                </tr>
                <tr>
                    <td>所在地点： </td>
                    <td>
                        <input type="text" name="Company add" id="Company add" /></td>
                </tr>
                <tr>
                    <td>职位： </td>
                    <td>
                        <input type="text" name="position" id="position" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <input type="image" src="../Image/EditInformation/btn_save.gif" /></td>
                </tr>
            </table>
        </fieldset>
    </div>
</asp:Content>
