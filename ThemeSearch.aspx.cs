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
    public partial class ThemeSearch : System.Web.UI.Page
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
            if (Request["key"]!=null)
            {
                search(Convert.ToString(Request["key"]));
            }
        }
        /// <summary>
        /// 根据关键词匹配主题标题或内容（模糊查询）并绑定
        /// </summary>
        /// <param name="key"></param>
        void search(string key)
        {
            dt = ThemeManagement.SelectByKey(key);
            if (dt.Rows.Count == 0)
            {
                Msg = "未查找到任何主题";
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
        protected void lvTheme_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Link")//点击主题标题链接时触发
            {
                string themeId = (lvTheme.Items[(e.Item.DataItemIndex)].FindControl("themeId") as HtmlInputHidden).Value.Trim();
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
                Response.Redirect("~/ThemeDisplay.aspx?themeId=" + themeId+"&path="+lblPath.Text);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            search(txtSearch.Text.Trim());
        }
    }
}