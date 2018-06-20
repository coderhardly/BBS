using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using System.Data;
using Model;
using BLL;

namespace Web
{
    public partial class MyCollect : System.Web.UI.Page
    {
        DataTable dt;
        string Msg;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }

        /// <summary>
        /// 以弹窗的方式向客户端输出提示信息
        /// </summary>
        void printMsgToClient()
        {
            SomeMethod.PrintMsgToClient(Page.ClientScript, Msg);
        }
        void Bind()
        {
            SomeMethod.IfLogin(this);
            dt = ThemeManagement.SelectMyCollect(Convert.ToString(Session["memberId"]));
            if (dt.Rows.Count == 0)
            {
                Msg = "暂未收藏任何主题";
                printMsgToClient();
            }
            lvTheme.DataSource = dt;
            lvTheme.DataBind();
        }
        /// <summary>
        /// 在页面中调用以显示图片
        /// </summary>
        /// <param name="isDisplay"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public object DisplayImg(bool isDisplay, string path)
        {
            if (isDisplay)
            {
                return "<img src=\"" + path + "\"/>";
            }
            return "";
        }
        #region 主题排序
        protected void lbTime_Click(object sender, EventArgs e)
        {

        }

        protected void lbHot_Click(object sender, EventArgs e)
        {

        }

        protected void lbEssence_Click(object sender, EventArgs e)
        {

        }
        #endregion

        protected void lvTheme_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string themeId = (lvTheme.Items[(e.Item.DataItemIndex)].FindControl("themeId") as HtmlInputHidden).Value.Trim();
            if (e.CommandName == "Link")//点击主题标题链接时触发
            {
                Model.Theme theme = new Model.Theme()
                {
                    ThemeId = themeId
                };
                if (theme.IsError)
                {
                    Msg = "参数格式错误";
                    printMsgToClient();
                    return;
                }
                ThemeManagement.Click(theme.ThemeId);
                Response.Redirect("~/ThemeDisplay.aspx?themeId=" + themeId + "&path=" + lblPath.Text);
            }
            if (e.CommandName == "Del")
            {
                Msg=CollectThemeManagement.UncollectTheme(Convert.ToString(Session["memberId"]), themeId);
                printMsgToClient();
                Bind();
            }
        }

    }
}