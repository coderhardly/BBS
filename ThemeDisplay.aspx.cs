using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using BLL;
using Model;
using System.Data;
using System.Text;
using Web;

namespace Web
{
    public partial class ThemeDisplay : System.Web.UI.Page
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
        protected void Page_Prerender(object sender, EventArgs e)
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
        void Bind()//绑定数据
        {
            if (Request.QueryString["themeId"] != null)
            {
                if (Request["path"] != null)
                {
                    lbtnPath.Text = Convert.ToString(Request["path"]).Trim();//设置上一级的路径
                }
                Theme theme = new Theme()
                {
                    ThemeId = Convert.ToString(Request.QueryString["themeId"])
                };
                if (theme.IsError)
                {
                    Msg = "参数格式错误";
                    printMsgToClient();
                    return;
                }
                #region 动态生成主题
                dt = ThemeManagement.SelectByThemeId(theme.ThemeId);
                if (dt.Rows.Count == 1)
                {
                    ThemeId.Text = "【" + Convert.ToString(dt.Rows[0]["theme_id"]) + "】" + Convert.ToString(dt.Rows[0]["title"]);//标题
                    MemberId.InnerHtml = Convert.ToString(dt.Rows[0]["creator"]);
                    MemberId.HRef = "~/Others.aspx?memberId=" + Convert.ToString(dt.Rows[0]["creator"]);
                    xp.Attributes["style"] = "background-image:url(" + SomeMethod.GetLevelPicPath(dt.Rows[0]["xp"]) + ");";//等级图标
                    text.InnerHtml = Server.UrlDecode(Convert.ToString(dt.Rows[0]["theme_text"]));//主题内容
                    lblPublishiTime.Text = "发表于：" + Convert.ToString(dt.Rows[0]["publish_time"]);//发布时间
                    picture.Attributes["style"] = "background-image:url(" + SomeMethod.GetUserPicPath(dt.Rows[0]["picture"]) + ");";//头像

                    UserName.InnerHtml = Convert.ToString(dt.Rows[0]["name"]);//查找用户名
                }
                else
                {
                    Msg = "主题不存在";
                    printMsgToClient();
                    return;
                }
                #endregion
                #region 动态生成评论
                dt = CriticismManagement.SelectByThemeId(theme.ThemeId);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    #region 生成一条评论并显示
                    //生成如下html代码
                    //<div class="tr">
                    //<div class="left">
                    //    <img class="pic" src="头像路径">
                    //    <div class="person">
                    //        <a href="#">账号</a>
                    //        <a href="javascript:__doPostBack('addConcern','');" onclick="concernClick()" runat="server" onserverclick="Unnamed_ServerClick"><img src="Image/ThemeDisplay/关注.png" style="width: 40px; height: 20px;" /></a>
                    //    </div>
                    //    <div>
                    //        <div class="name" style="text-align: left;">用户名</div>
                    //        <img class="lv" src="等级图片路径"/>
                    //    </div>
                    //</div>
                    //<div class="right">
                    //    <div class="text"></div>
                    //    <div class="operate">
                    //        <input type="hidden" value="评论的编号" />
                    //        <div class="lblPublishiTime">发布时间</div>
                    //        <a class="pic1" href="javascript:void(0)" onclick="reportClick()"><img src="Image/ThemeDisplay/举报.png"/></a>
                    //        <a class="pic2" href="javascript:void(0)" onclick="criticismClick()"><img src="Image/ThemeDisplay/评论.png"/></a>
                    //    </div>
                    //</div>
                    //</div>

                    sb.Append("<div class=\"tr\">");
                    sb.Append("<div class=\"left\"><img class=\"pic\" src=\"");
                    sb.Append(SomeMethod.GetUserPicPath(dt.Rows[i]["picture"]));          //头像路径
                    sb.Append("\"/><div class=\"person\"><a href=\"");
                    sb.Append("Others.aspx?memberId=" + Convert.ToString(dt.Rows[0]["member_id"]));//账号链接路径
                    sb.Append("\">");
                    sb.Append(dt.Rows[i]["member_id"]);         //账号
                    sb.Append("</a><a href=\"javascript:__doPostBack('addConcern','');\" onclick=\"concernClick()\" runat=\"server\" onserverclick=\"Unnamed_ServerClick\"><img src=\"Image/ThemeDisplay/关注.png\" style=\"width: 40px; height: 20px;\" /></a></div><div><div class=\"name\" style=\"text-align: left;\">");
                    sb.Append(Convert.ToString(dt.Rows[0]["name"]));             //用户名
                    sb.Append("</div><img class=\"lv\" src=\"");
                    sb.Append(SomeMethod.GetLevelPicPath(dt.Rows[i]["xp"]));      //等级图片路径
                    sb.Append("\"/></div></div><div class=\"right\"><div class=\"text\"><p>");
                    sb.Append(Server.UrlDecode(Convert.ToString(dt.Rows[i]["criticism_text"])));       //评论
                    sb.Append("</p></div><div class=\"operate\"><input type=\"hidden\" value=\"");
                    sb.Append(dt.Rows[i]["criticism_id"]);          //评论编号
                    sb.Append("\" /><div class=\"lblPublishiTime\">发表于：");
                    sb.Append(dt.Rows[i]["publish_time"]);     //发布时间
                    sb.Append("</div><a class=\"pic1\" href=\"javascript:void(0)\" onclick=\"reportClick()\"><img src=\"Image/ThemeDisplay/举报.png\" style=\"width: 30px; height: 30px\"/></a><a href=\"javascript:void(0)\" onclick=\"criticismClick()\"><img class=\"pic2\" src=\"Image/ThemeDisplay/评论.png\" style=\"width: 30px; height: 30px\" /></a></div></div></div>");
                    #endregion
                }
                criticisms.InnerHtml = sb.ToString();
                #endregion
            }
        }

        protected void btnSubmit_ServerClick(object sender, EventArgs e)//评论
        {
            //判断是否登录
            //if (Session["role"] == null)
            //{
            //    Response.Redirect("~/Login.aspx");
            //}
            //Criticism criticism = new Criticism()
            //{
            //    CriticismId = CriticismManagement.CreateCriticismId(),
            //    MemberId = Session["memberId"].ToString().Trim(),
            //    ThemeId = Request["themeId"].ToString(),
            //    CriticismText = content.Value.Trim(),
            //    PublishTime = DateTime.Now
            //};
            //if (connectCriticism.Value.Trim() == "Theme")
            //{
            //    if (criticism.IsError)
            //    {
            //        Msg = "参数格式错误";
            //        printMsgToClient();
            //        return;
            //    }
            //    Msg = CriticismManagement.PublishCriticism(criticism);
            //}
            //else
            //{
            //    criticism.ConnectedCriticism = connectCriticism.Value.Trim();
            //    if (criticism.IsError)
            //    {
            //        Msg = "参数格式错误";
            //        printMsgToClient();
            //        return;
            //    }
            //    Msg = CriticismManagement.ReplyCriticism(criticism);
            //}
            //printMsgToClient();
            Bind();
        }

        protected void btnReport_ServerClick(object sender, EventArgs e)//举报
        {
            //举报，通过connectCriticism.value获取被举报的评论的id（举报的框在页面最下面，还没样式）

            //判断是否登录
            SomeMethod.IfLogin(this);
            Message message = new Message()
            {
                Sender = Convert.ToString(Session["memberId"]),
                Recipient = "0000000000",
                MessageId = MessageManagement.CreateMessageId(),
                CreateTime = DateTime.Now,
                MessageType = "举报",
                MessageState = "未查看"
            };
            //获取被举报者编号
            if (connectCriticism.Value.Trim() == "Theme")
            {
                message.MessageText = "【主题" + Request["themeid"] + "】" + reportText.Value.Trim();
            }
            else
            {
                message.MessageText = "【评论" + connectCriticism.Value.Trim() + "】" + reportText.Value.Trim();
            }
            if (message.IsError)
            {
                Msg = "参数格式错误";
                printMsgToClient();
                return;
            }
            Msg = MessageManagement.Send(message);
            printMsgToClient();
        }

        protected void addConcern_ServerClick(object sender, EventArgs e)//关注
        {
            //判断是否登录
            if (Session["role"] == null)
            {
                Response.Redirect("~/Login.aspx");
                return;
            }
            //关注，通过connectCriticism.value获取被关注的会员的id
            if (Session["memberId"] != null)
            {
                Concern con = new Concern()
                {
                      ConcernId = ConcernManagement.CreatConcernId(),
                      ConcernMember = Session["memberId"].ToString().Trim(),
                      ConcernTo = connectCriticism.Value.ToString().Trim()
                };

                Msg = ConcernManagement.AddConcern(con);
            }
            printMsgToClient();
        }

        protected void collect_ServerClick(object sender, EventArgs e)//收藏
        {
            //判断是否登录
            if (Session["role"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }

            //收藏,主题id通过Request.QueryString["themeId"]获取
            CollectTheme col = new CollectTheme();
            col.CollectId = CollectThemeManagement.CreatCollectId();
            col.ThemeId = Request.QueryString["themeId"].ToString().Trim();
            col.MemberId = Session["memberId"].ToString().Trim();
            col.Remark = "备注";
            Msg = CollectThemeManagement.CollectTheme(col);
            printMsgToClient();
        }

        protected void btnPubCriticism_Click(object sender, EventArgs e)//评论
        {
            //判断是否登录
            SomeMethod.IfLogin(this);
            Criticism criticism = new Criticism()
            {
                CriticismId = CriticismManagement.CreateCriticismId(),
                MemberId = Session["memberId"].ToString().Trim(),
                ThemeId = Request["themeId"].ToString(),
                CriticismText = Server.UrlDecode(hidContent.Value.Trim()),
                PublishTime = DateTime.Now
            };
            if (connectCriticism.Value.Trim() == "Theme")
            {
                if (criticism.IsError)
                {
                    Msg = "参数格式错误";
                    printMsgToClient();
                    return;
                }
                Msg = CriticismManagement.PublishCriticism(criticism);
            }
            else
            {
                criticism.ConnectedCriticism = connectCriticism.Value.Trim();
                if (criticism.IsError)
                {
                    Msg = "参数格式错误";
                    printMsgToClient();
                    return;
                }
                Msg = CriticismManagement.ReplyCriticism(criticism);
            }
            printMsgToClient();
            Bind();
        }

        protected void lbtnPath_Click(object sender, EventArgs e)//重定向到进入此页面之前的页面
        {
            if (lbtnPath.Text == "我的主题")
            {
                Response.Redirect("~/MyTheme.aspx");
            }
            else if (lbtnPath.Text == "我的收藏")
            {
                Response.Redirect("~/MyCollect.aspx");
            }
            else if (lbtnPath.Text == "我的评论")
            {
                Response.Redirect("~/MyCriticism.aspx");
            }
            else if (lbtnPath.Text == "主题查找")
            {
                Response.Redirect("~/ThemeSearch.aspx");
            }
            else
            {
                Response.Redirect("~/ThemeList.aspx?divisionName="+lbtnPath.Text);
            }
        }
    }
}