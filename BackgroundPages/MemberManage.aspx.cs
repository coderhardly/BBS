using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Model;
using BLL;
using System.Data;

namespace Web
{
    public partial class AddMember : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SomeMethod.IfAdmin(this);
            if (!IsPostBack)
            {
                Bind();
            }
        }
        void Bind()
        {
            if (Request.QueryString["memberId"] != null)
            {
                #region 显示会员信息
                //查找会员信息
                Member member = MemberManagement.ShowMember(Request.QueryString["memberId"]);
                //显示会员信息
                txtPicture.Text = member.Picture;
                txtMemberId.Text = member.MemberId;
                txtUserName.Text = member.Name;
                txtPwd.Text = member.Pwd;
                txtXp.Text = Convert.ToString(member.Xp);
                txtMemberState.Text = member.MemberState;
                txtFreezeDeadtime.Text = Convert.ToString(member.FreezeDeadtime);
                //查找用户个人信息
                DataTable dt = UserInfoManagement.SelectById(member.UserInfoId);
                txtUserinfoId.Text = Convert.ToString(dt.Rows[0][0]);
                txtName.Text = Convert.ToString(dt.Rows[0][1]);
                txtSex.Text = Convert.ToString(dt.Rows[0][2]);
                txtAge.Text = Convert.ToString(dt.Rows[0][3]);
                txtTel.Text = Convert.ToString(dt.Rows[0][4]);
                txtEmail.Text = Convert.ToString(dt.Rows[0][5]);
                txtJob.Text = Convert.ToString(dt.Rows[0][6]);
                txtAddr.Text = Convert.ToString(dt.Rows[0][7]);
                txtMotto.Text = Convert.ToString(dt.Rows[0][8]);
                #endregion
            }
        }
        Member GetMember()
        {
            Member member = new Member()
            {
                MemberId = txtMemberId.Text.Trim(),
                Name = txtUserName.Text.Trim(),
                Pwd = txtPwd.Text.Trim(),
                FreezeDeadtime = Convert.ToDateTime(txtFreezeDeadtime.Text.Trim()),
                MemberState = txtMemberState.Text.Trim(),
                Picture = txtPicture.Text.Trim(),
                UserInfoId = txtUserinfoId.Text.Trim(),
                Xp = Convert.ToInt32(txtXp.Text.Trim()),
            };
            return member;
        }
        UserInfo GetUserInfo()
        {
            UserInfo userInfo = new UserInfo()
            {
                UserInfoId = txtUserinfoId.Text.Trim(),
                Sex = txtSex.Text.Trim(),
                Addr = txtAddr.Text.Trim(),
                Age = Convert.ToInt32(txtAge.Text.Trim()),
                Email = txtEmail.Text.Trim(),
                Job = txtJob.Text.Trim(),
                Motto = txtMotto.Text.Trim(),
                Name = txtName.Text.Trim(),
                Tel = txtTel.Text.Trim(),
            };
            return userInfo;
        }

        protected void btnAddMember_Click(object sender, EventArgs e)
        {
            #region 封装参数
            Member member = new Member()
                {
                    MemberId = txtMemberId.Text.Trim(),
                    Name = txtUserName.Text.Trim(),
                    Pwd = txtPwd.Text.Trim(),
                    FreezeDeadtime = Convert.ToDateTime(txtFreezeDeadtime.Text.Trim()),
                    MemberState = txtMemberState.Text.Trim(),
                    Picture = txtPicture.Text.Trim(),
                    UserInfoId = txtUserinfoId.Text.Trim(),
                    Xp = Convert.ToInt32(txtXp.Text.Trim()),

                    IsOnline = false,
                    LasttimeOnline = DateTime.Parse("2017-12-8")
                };
            #endregion
            if (member.IsError == true)
            {
                //参数格式错误
                Response.Write("参数格式错误,添加失败");
            }
            else
            {
                string msg = MemberManagement.AddMember(member);
                Response.Write(msg);
            }
        }
        protected void btnEditMember_Click(object sender, EventArgs e)
        {
            Member member = GetMember();
            if (member.IsError == true)
            {
                //参数格式错误
                Response.Write("参数格式错误,添加失败");
            }
            else
            {
                string msg = MemberManagement.Update(member);
                Response.Write(msg);
            }
        }
        protected void btnDeleteMember_Click(object sender, EventArgs e)
        {
            Member member = new Member()
            {
                MemberId = txtMemberId.Text.Trim()
            };
            if (member.IsError == true)
            {
                //参数格式错误
                Response.Write("参数格式错误,添加失败");
            }
            else
            {
                string Msg = MemberManagement.Delete(member.MemberId);
                Response.Write(Msg);
            }
        }
        protected void btnAddUserInfo_Click(object sender, EventArgs e)
        {
            UserInfo userInfo = GetUserInfo();
            if (userInfo.IsError == true)
            {
                //参数格式错误
                Response.Write("参数格式错误,添加失败");
            }
            else
            {
                string msg = UserInfoManagement.AddUserInfo(userInfo);
                Response.Write(msg);
            }
        }
        protected void btnEditUserInfo_Click(object sender, EventArgs e)
        {
            UserInfo userInfo = GetUserInfo();
            if (userInfo.IsError)
            {
                //参数格式错误
                Response.Write("参数格式错误,添加失败");
            }
            else
            {
                string Msg = UserInfoManagement.UpdateUserInfo(userInfo);
                Response.Write(Msg);
            }
        }
        protected void btnDeleteUserInfo_Click(object sender, EventArgs e)
        {
            UserInfo userInfo = GetUserInfo();
            if (userInfo.IsError)
            {
                //参数格式错误
                Response.Write("参数格式错误,添加失败");
            }
            else
            {
                string Msg = UserInfoManagement.DeleteUserInfo(userInfo.UserInfoId);
                Response.Write(Msg);
            }
        }
        protected void btnCreateUserInfoId_Click(object sender, EventArgs e)
        {
            txtUserinfoId.Text = UserInfoManagement.CreateUserInfoId();
        }
    }
}