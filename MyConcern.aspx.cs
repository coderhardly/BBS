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
    public partial class MyConcern : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }
        void Bind()
        {
            SomeMethod.IfLogin(this.Page);
            DataTable dt = ConcernManagement.SelectMember(Convert.ToString(Session["memberId"]));
            vwConcern.DataSource = dt;
            vwConcern.DataBind();
        }

        protected void vwConcern_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            SomeMethod.IfLogin(this.Page);
            string memberId = (vwConcern.Items[e.Item.DataItemIndex].FindControl("hfldMemberId") as HiddenField).Value.Trim();
            if (e.CommandName == "Cancal")//取消关注
            {
                string Msg = ConcernManagement.UnConcern(Convert.ToString(Session["memberId"]), memberId);
                SomeMethod.PrintMsgToClient(this.ClientScript, Msg);
                Bind();
            }
            else if (e.CommandName == "More")
            {
                Response.Redirect("~/Others.aspx?memberId=" + memberId);
            }
        }
    }
}