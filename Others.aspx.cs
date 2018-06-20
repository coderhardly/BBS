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
    public partial class Others : System.Web.UI.Page
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
            string memberId = Convert.ToString(Request["memberId"]);
            DataTable dt;
            if (memberId!=null)
            {
                dt = MemberManagement.SelectSixTable(memberId);
                if (dt.Rows.Count==0)
                {
                    SomeMethod.PrintMsgToClient(this.ClientScript, "未查找到相关会员的信息");
                    return;
                }
                string pic= SomeMethod.GetUserPicPath(dt.Rows[0]["picture"]);//获取图片路径
                divPic.Attributes.Add("style", "background-image:url(" + pic+");");//添加背景图片

                hlkSendMsg.NavigateUrl = "~/MyMessage.aspx?recipient=" + Convert.ToString(dt.Rows[0]["member_id"]);
                lblConcernNum.Text = Convert.ToString(dt.Rows[0]["concern_num"]);
                lblFans.Text = Convert.ToString(dt.Rows[0]["fans"]);
                lblMotto.Text = Convert.ToString(dt.Rows[0]["motto"]);
                lblName.Text = Convert.ToString(dt.Rows[0]["name"]);
                lblPubCriticism.Text = "发表评论：" + Convert.ToString(dt.Rows[0]["criticism_num"])+"&nbsp;&nbsp;";
                lblPubTheme.Text = "发表主题：" + Convert.ToString(dt.Rows[0]["theme_num"]);
            }
            
        }

        protected void btnConcern_ServerClick(object sender, EventArgs e)
        {
            //判断是否登录
            SomeMethod.IfLogin(this);
            //关注，通过connectCriticism.value获取被关注的会员的id
            if (Session["memberId"] != null)
            {
                Concern con = new Concern()
                {
                    ConcernId = ConcernManagement.CreatConcernId(),
                    ConcernMember = Session["memberId"].ToString().Trim(),
                    ConcernTo = Request["memberId"].ToString().Trim()
                };
                SomeMethod.PrintMsgToClient(this.ClientScript, ConcernManagement.AddConcern(con));
            }
        }
    }
}