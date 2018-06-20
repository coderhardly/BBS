using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using BLL;
using Model;
using System.Text;

namespace Web
{
    public partial class MyCriticism : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }
        public string ShowReplyTo(object obj)//显示二级回复
        {
            if (obj == DBNull.Value)
            {
                return "class=\"hid\"";
            }
            return "";
        }
        void Bind()
        {
            SomeMethod.IfLogin(this);
            DataTable dt = CriticismManagement.SelectCToC(Convert.ToString(Session["memberId"]));
            vwCriticism.DataSource = CriticismManagement.SelectCToC(Convert.ToString(Session["memberId"]));
            vwCriticism.DataBind();
        }

    }
}