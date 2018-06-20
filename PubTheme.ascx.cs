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
    public partial class PubTheme : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ddlDivision.Items.Clear();
            ddlDivision.DataSource = DivisionManagement.ShowAll();
            ddlDivision.DataTextField = "division_name";
            ddlDivision.DataValueField = "division_id";
            ddlDivision.DataBind();
        }
        void printMsgToClient(string Msg)
        {
            SomeMethod.PrintMsgToClient(this.Parent.Page.ClientScript, Msg);
        }
        protected void btnPubTheme_Click(object sender, EventArgs e)
        {
            //判断是否登录
            SomeMethod.IfLogin(this.Parent.Page);
            Theme theme = new Theme()
            {
                BelongToDivision = ddlDivision.SelectedValue.Trim(),
                Clicks = 0,
                Creator = Convert.ToString(Session["memberId"]),
                IsEssence = false,
                IsSettop = false,
                PublishTime = DateTime.Now,
                ThemeId = ThemeManagement.CreateThemeId(),
                ThemeText = Server.UrlDecode(hidContent.Value.Trim()),
                Title = txtTitle.Text.Trim()
            };
            printMsgToClient(ThemeManagement.CreateTheme(theme));
        }
    }
}