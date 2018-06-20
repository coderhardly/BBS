using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BLL;
using Model;
using System.Data;

namespace Web
{
    public partial class Login : System.Web.UI.Page
    {
        string Msg;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie cookie = Request.Cookies["Member"];
                if (cookie != null)
                {
                    txtUser.Value = Server.HtmlEncode(cookie.Values["MemberId"]);
                    txtPwd.Value = Server.HtmlEncode(cookie.Values["Pwd"]);
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //【1】检验验证码是否正确
                if (txtIdentifyingCode.Value.ToLower() != Convert.ToString(Session["CheckCode"]).ToLower())
                {
                    Msg = "验证码错误";
                    Response.Write(Msg);
                    return;
                }
                //【2】检验账号和密码格式是否正确
                Member member = new Member()
                {
                    MemberId = txtUser.Value.Trim(),
                    Pwd = txtPwd.Value.Trim()
                };
                if (member.IsError)
                {
                    Msg = "账号或密码错误";
                    Response.Write(Msg);
                    return;
                }
                //【3】检验账号密码是否正确
                Member dbMember = MemberManagement.ShowMember(member.MemberId);
                if (member.MemberId == dbMember.MemberId && member.Pwd == dbMember.Pwd)//若登录成功
                {
                    #region 登录处理
                    //更新客户端cookie
                    if (cbRemember.Checked)
                    {
                        HttpCookie cookie = new HttpCookie("Member");
                        cookie.Values["MemberId"] = member.MemberId;
                        cookie.Values["Pwd"] = member.Pwd;
                        cookie.Expires = DateTime.Now.AddDays(7);
                        Response.Cookies.Add(cookie);
                    }

                    //将用户角色【管理员，版主或会员】信息存入Session
                    Session["memberId"] = member.MemberId;
                    Session["UserName"] = member.Name;
                    string adminId = AdministratorManagement.SelectId(member.MemberId);
                    if (adminId != null)
                    {
                        Session["role"] = "管理员";
                        Session["admimId"] = adminId;
                        //Response.Redirect("~/BackgroundPages/Admin.aspx");
                    }
                    else if ((dt = ModeratorManagement.Select(member.MemberId)).Rows.Count == 1)
                    {
                        Session["role"] = "版主";
                        Session["moderatorId"] = dt.Rows[0]["moderatorId"];
                        Session["divisionId"] = dt.Rows[0]["division_id"];
                    }
                    else
                    {
                        Session["role"] = "会员";
                    }
                    Response.Redirect("~/Index.aspx"); 
                    #endregion
                }
                else
                {
                    Msg = "账号或密码错误";
                    SomeMethod.PrintMsgToClient(this.ClientScript, Msg);
                }
            }
            catch (Exception)
            {
                Msg="发生一个未知的异常";
                SomeMethod.PrintMsgToClient(this.ClientScript, Msg);
            }
        }
    }
}