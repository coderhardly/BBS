using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using System.Data;
using BLL;
using Model;

namespace Web
{
    public partial class ThemeList : System.Web.UI.Page
    {
        string Msg;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            DataBind();
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
            if (Request["divisionName"]!=null)
            {
                //【1】绑定公告栏中的信息
                lblDivisionName.Text = Convert.ToString(Request["divisionName"]);//版块名称
                dt = ModeratorManagement.SelectAllModerator(Request["divisionName"]);
                lblModeratorName.Text = "&nbsp;&nbsp;&nbsp;&nbsp;版主：";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lblModeratorName.Text += dt.Rows[i]["name"];
                }
                lblBulletin.Text = "版块公告：" + BulletinManagement.selectBulletin(Request["divisionName"]);
                //【2】绑定路径
                lblDivision.Text = Request["divisionName"].Trim();//路径
                //【3】绑定主题目录
                lvTheme.DataSource = ThemeManagement.SelectByTime(Request["divisionName"]);
                lvTheme.DataBind();
            }
        }
        /// <summary>
        /// 在页面中调用以显示图片
        /// </summary>
        /// <param name="isDisplay"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public object DisplayImg(bool isDisplay,string path)
        {
            if (isDisplay)
            {
                return "<img src=\"" + path + "\"/>";
            }
            return "";
        }
        protected void lvTheme_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName=="Link")//点击主题标题链接时触发
            {
                string themeId = (lvTheme.Items[(e.Item.DataItemIndex)].FindControl("themeId") as HtmlInputHidden).Value.Trim();
                Model.Theme theme=new Model.Theme(){
                    ThemeId=themeId
                };
                if(theme.IsError){
                    Msg = "参数格式错误";
                    printMsgToClient();
                    return;
                }
                ThemeManagement.Click(theme.ThemeId);
                Response.Redirect("~/ThemeDisplay.aspx?themeId=" + themeId + "&path=" + lblDivisionName.Text.Trim());
            }
        }

        protected void lbTime_Click(object sender, EventArgs e)//按时间
        {
            Bind();
        }

        protected void lbHot_Click(object sender, EventArgs e)//按热度
        {

        }

        protected void lbEssence_Click(object sender, EventArgs e)//按精华
        {
            lvTheme.DataSource = ThemeManagement.SelectByEssence(Convert.ToString(Request["divisionName"]));
            lvTheme.DataBind();
        }
        protected void btnApply_Click(object sender, EventArgs e)//申请版主
        {
            //判断是否登录
            if (Session["memberId"]==null)
            {
                SomeMethod.PrintMsgToClient(this.ClientScript, "只有会员才能申请版主");
                return;
            }
            if ((string)Session["role"]=="版主")
            {
                SomeMethod.PrintMsgToClient(this.ClientScript, "您已经是版主了，无法再申请");
                return;
            }
            if ((string)Session["role"] == "管理员")
            {
                Msg = "管理员无需申请版主";
                printMsgToClient();
                return;
            }
            Message message = new Message()
            {
                CreateTime = DateTime.Now,
                MessageId = MessageManagement.CreateMessageId(),
                MessageState = "未查看",
                MessageText = "会员【" + Convert.ToString(Session["UserName"]) + "】申请成为【" + Convert.ToString(Request["divisionName"]) + "】版块的版主",
                MessageType = "申请版主",
                Recipient = "0000000000",
                Sender = Convert.ToString(Session["memberId"])
            };
            if (message.IsError)
            {
                Msg = "参数格式错误";
                printMsgToClient();
                return;
            }
            Msg = MessageManagement.Send(message);
            printMsgToClient();
            Bind();
        }

        protected void btnResign_Click(object sender, EventArgs e)//辞去版主
        {
            //判断是否登录
            if ((string)Session["role"] != "版主")
            {
                Msg = "只有版主才能请求辞去版主职务，请登录版主账号！";
                printMsgToClient();
                return;
            }
            Message message = new Message()
            {
                CreateTime = DateTime.Now,
                MessageId = MessageManagement.CreateMessageId(),
                MessageState = "未查看",
                MessageText = "会员【" + Convert.ToString(Session["UserName"]) + "】申请辞去【" + Convert.ToString(Request["divisionName"]) + "】版块的版主",
                MessageType = "辞去版主",
                Recipient = "0000000000",
                Sender = Convert.ToString(Session["memberId"])
            };
            Msg = MessageManagement.Send(message);
            printMsgToClient();
            Bind();
        }
    }
}