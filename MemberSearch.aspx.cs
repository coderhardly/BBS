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
    public partial class MemberSearch : System.Web.UI.Page
    {
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }
        void printMsgToClient(string Msg)
        {
            SomeMethod.PrintMsgToClient(Page.ClientScript, Msg);
        }
        public string GetSexImg(object sex)
        {
            if (Convert.ToString(sex) == "男")
            {
                return "/Image/Public/men_01.png";
            }
            else if (Convert.ToString(sex) == "女")
            {
                return "/Image/Public/women_01.png";
            }
            return "/Image/Public/sexNull_01.png";
        }
        void Bind()
        {
            //【1】若从其他页面转到此页面
            if (Request["key"] != null)
            {
                search(Convert.ToString(Request["key"]));
                txtSearch.Text = Request["key"];
            }
        }
        void search(string key)
        {
            dt = MemberManagement.SelectMember(key);
            if (dt == null)
            {
                printMsgToClient("搜索的值不允许为空");
                return;
            }
            lvMember.DataSource = dt;
            lvMember.DataBind();
        }
        protected void lvMember_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            SomeMethod.IfLogin(this);
            string memberId = (lvMember.Items[e.Item.DataItemIndex].FindControl("hidMemberId") as HiddenField).Value.Trim();
            if (e.CommandName == "Concern")
            {
                Concern con = new Concern()
                {
                    ConcernId = ConcernManagement.CreatConcernId(),
                    ConcernMember = Convert.ToString(Session["memberId"]),
                    ConcernTo = memberId
                };
                printMsgToClient(ConcernManagement.AddConcern(con));
            }
            else if (e.CommandName == "MsgSend")
            {
                Response.Redirect("~/MyMessage.aspx?recipient=" + memberId);
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)//查询
        {
            search(txtSearch.Text.Trim());
        }

        protected void lkConcern_Click(object sender, EventArgs e)
        {
            
        }

        protected void lkMsgSend_Click(object sender, EventArgs e)
        {

        }

        protected void lkReport_Click(object sender, EventArgs e)
        {

        }
    }
}