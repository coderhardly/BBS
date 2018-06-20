using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BLL;
using System.Data;

namespace Web
{
    public partial class Header : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //【1】绑定头像
            if (Session["memberId"] != null)
            {
                DataTable dt = MemberManagement.SelectNPX(Convert.ToString(Session["memberId"]));
                if (dt.Rows.Count == 1)
                {
                    imgHeadPic.ImageUrl = SomeMethod.GetUserPicPath(dt.Rows[0]["picture"]);
                }
            }
        }
        protected void ibSearch_Click(object sender, ImageClickEventArgs e)//查找
        {
            if (txtKey.Text.Trim() == "")
            {
                return;
            }
            if (ddlMode.SelectedValue == "主题")
            {
                //主题模糊查找
                Response.Redirect("~/ThemeSearch.aspx?key=" + txtKey.Text.Trim());
            }
            else if (ddlMode.SelectedValue == "会员")
            {
                //会员用户名模糊查找
                Response.Redirect("~/MemberSearch.aspx?key=" + txtKey.Text.Trim());
            }
        }
    }
}