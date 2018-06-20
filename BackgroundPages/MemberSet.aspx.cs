using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BLL;
using Model;

namespace Web
{
    public partial class MemberSet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SomeMethod.IfAdmin(this);
            if (!IsPostBack)
            {
                Bind();
            }
        }
        protected void Page_PreRender()
        {
            DataBind();
        }
        void Bind()
        {
            lvMember.DataSource = MemberManagement.ShowAll();
            lvMember.DataBind();
        }
        protected void lvMember_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            //获取点击按钮所在项的MemberId（会员编号）
            string MemberId = (lvMember.Items[(e.Item.DataItemIndex)].FindControl("lblMemberId") as Label).Text;
            if (e.CommandName == "Edit")
            {
                Response.Redirect("MemberManage.aspx?memberId=" + MemberId);
            }
            else if (e.CommandName == "Del")
            {
                string Msg = MemberManagement.Delete(MemberId);
                SomeMethod.PrintMsgToClient(this.ClientScript,Msg);
                Bind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (ddlMemberSearch.SelectedValue=="所有")
            {
                Bind();
            }
            else if (ddlMemberSearch.SelectedValue == "账号")
            {
                lvMember.DataSource = MemberManagement.Select(txtKey.Text.Trim());
                lvMember.DataBind();
            }
            else if (ddlMemberSearch.SelectedValue == "用户名")
            {
                Bind();
            }
        }
    }
}