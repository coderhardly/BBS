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
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SomeMethod.IfMA(this);
            if (!IsPostBack)
            {
                Bind();
            }
        }

        void Bind()
        {
            DataTable dt = MemberManagement.SelectNPX(Convert.ToString(Session["memberId"]));
            if (dt.Rows.Count != 0)
            {
                pic.Attributes.Add("style", "background-image:url(../" + SomeMethod.GetUserPicPath(dt.Rows[0]["picture"]) + ");");
            }
        }

        protected void ibtnExit_Click(object sender, ImageClickEventArgs e)
        {
            Session["memberId"] = null;
            Session["UserName"] = null;
            Session["role"] = null;
        }
    }
}