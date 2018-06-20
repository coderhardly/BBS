using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using BLL;
using Model;

namespace Web
{
    public partial class CriticismSet : System.Web.UI.Page
    {
        string Msg;
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            SomeMethod.IfAdmin(this);
            if (!IsPostBack)
            {
                Bind();
            }
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            DataBind();
        }
        void Bind()
        {
            dt = CriticismManagement.ShowAll();
            lvCriticism.DataSource = dt;
            lvCriticism.DataBind();
        }
        void Bind(DataTable d)
        {
            lvCriticism.DataSource = d;
            lvCriticism.DataBind();
        }
        protected void lvCriticism_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string criticismId = (lvCriticism.Items[(e.Item.DataItemIndex)].FindControl("hfldCriticismId") as HiddenField).Value.Trim();
            if (e.CommandName == "Del")
            {
                SomeMethod.PrintMsgToClient(this.ClientScript, CriticismManagement.Delete(criticismId));
                Bind();
            }
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            if (ddlKey.SelectedValue == "所有")
            {
                Bind();
                return;
            }
            if (ddlKey.SelectedValue == "主题")
            {
                Theme theme = new Model.Theme()
                {
                    ThemeId = txtKey.Text.Trim()
                };
                if (theme.IsError)
                {
                    Msg = "参数格式错误";
                    SomeMethod.PrintMsgToClient(this.ClientScript, Msg);
                    return;
                }
                Bind(CriticismManagement.SelectByThemeId(theme.ThemeId));
                return;
            }
            if (ddlKey.SelectedValue == "会员")
            {
                Member member = new Member()
                {
                    MemberId = txtKey.Text.Trim()
                };
                if (member.IsError)
                {
                    Msg = "参数格式错误";
                    SomeMethod.PrintMsgToClient(this.ClientScript, Msg);
                    return;
                }
                Bind(CriticismManagement.SeleteByMemberId(member.MemberId));
                return;
            }
            if (ddlKey.SelectedValue == "编号")
            {
                Criticism criticism = new Criticism()
                {
                    CriticismId = txtKey.Text.Trim()
                };
                if (criticism.IsError)
                {
                    Msg = "参数格式错误";
                    SomeMethod.PrintMsgToClient(this.ClientScript, Msg);
                    return;
                }
                Bind(CriticismManagement.SelectByCriticismId(criticism.CriticismId));
                return;
            }
        }
    }
}