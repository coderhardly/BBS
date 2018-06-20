using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using Model;
using BLL;

namespace Web
{
    public partial class Register : System.Web.UI.Page
    {
        string userInfoId;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        Member GetMember()
        {
            //DateTime a = new DateTime();
            Member member = new Member()
            {
                MemberId = txtuser.Text.Trim(),
                Pwd = txtpassword.Text.Trim(),
                Xp = 0,
                IsOnline = true,
                Picture = "/Default/003.png",
                FreezeDeadtime = DateTime.Now,
                LasttimeOnline = DateTime.Today,
                UserInfoId = userInfoId,
                //UserInfoId ="000010000",
                Name = "无",
                MemberState = "正常",
            };
            return member;
        }
        UserInfo GetUserInfo()
        {
            UserInfo userInfo = new UserInfo()
            {
                UserInfoId = userInfoId,
                Email = txtemail.Text.Trim(),
                Addr = "无",
                Tel = "无",
                Name = "无",
                Sex = "男",
                Age = 1,
                Motto = "无",
                Job = "无",

            };
            return userInfo;
        }
        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            string Msg;
            userInfoId = UserInfoManagement.CreateUserInfoId();
            UserInfo userInfo = GetUserInfo();
            if (userInfo.IsError)
            {
                Msg = "参数格式错误";
                SomeMethod.PrintMsgToClient(this.ClientScript, Msg);
                return;
            }
            UserInfoManagement.AddUserInfo(userInfo);
            //获取数据
            Member member = GetMember();

            //检验数据是否出错

            if (member.IsError)
            {
                Msg = "参数格式错误";
                SomeMethod.PrintMsgToClient(this.ClientScript, Msg);
                return;
            }
            //执行并返回执行结果
            MemberManagement.AddMember(member);
            SomeMethod.PrintMsgToClient(this.ClientScript,"注册成功");
        }
    }
}