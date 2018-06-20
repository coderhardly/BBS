using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using Model;
using BLL;

namespace Web
{
    public partial class MessageSet : System.Web.UI.Page
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
        string getMessageState()
        {
            if (ckbShowViewed.Checked)
            {
                return "已查看";
            }
            else
            {
                return "未查看";
            }
        }
        /// <summary>
        /// 根据消息类型查找消息并绑定到相应的ListView控件
        /// </summary>
        /// <param name="messageType"></param>
        /// <param name="lv"></param>
        void selectMessage(string messageType,ListView vw)
        {
            dt = MessageManagement.SelectByRecipient("0000000000", getMessageState(), messageType);
            if (dt.Rows.Count == 0)
            {
                SomeMethod.PrintMsgToClient(this.ClientScript, "未查找到消息");
            }
            else
            {
                vw.DataSource = dt;
                vw.DataBind();
            }
        }
        void Bind()
        {
            selectMessage("普通", vwNormal);
        }

        protected void lbtnNormal_Click(object sender, EventArgs e)
        {
            selectMessage("普通", vwNormal);
        }

        protected void lbtnReport_Click(object sender, EventArgs e)
        {
            selectMessage("举报", vwReport);
        }

        protected void lbtnRequestModerator_Click(object sender, EventArgs e)
        {
            selectMessage("申请版主", vwRequestModerator);
        }

        protected void lbtnResignModerator_Click(object sender, EventArgs e)
        {
            selectMessage("辞去版主", vwRequestModerator);
        }

        protected void vwNormal_ItemCommand(object sender, ListViewCommandEventArgs e)//查看普通消息
        {
            string messageId = (vwNormal.Items[e.Item.DataItemIndex].FindControl("hfldMessageId") as HiddenField).Value.Trim();
            if (e.CommandName == "View")
            {
                MessageManagement.Review(messageId);
            }
        }

        protected void vwReport_ItemCommand(object sender, ListViewCommandEventArgs e)//处理举报
        {
            string messageId = (vwReport.Items[e.Item.DataItemIndex].FindControl("hfldMessageId") as HiddenField).Value.Trim();
            string memberId = (vwReport.Items[e.Item.DataItemIndex].FindControl("lblSender") as Label).Text.Trim();
            Message message = new Message()
            {
                CreateTime = DateTime.Now,
                MessageId = MessageManagement.CreateMessageId(),
                MessageState = "未查看",
                MessageType = "普通",
                Recipient = memberId,
                Sender = "0000000000"
            };
            if (e.CommandName == "Yes")
            {
                MessageManagement.Review(messageId);
                message.MessageText = "您的举报已受理，我们已对您举报的情况进行处理，感谢您的配合";
                MessageManagement.Send(message);
                Response.Redirect("~/BackgroundPages/MemberManage.aspx?memberId=" + memberId);
            }
            else if (e.CommandName == "Not")
            {
                MessageManagement.Review(messageId);
                message.MessageText = "您的举报已受理，感谢您的配合";
                MessageManagement.Send(message);
            }
        }

        protected void vwRequestModerator_ItemCommand(object sender, ListViewCommandEventArgs e)//处理申请版主
        {
            string messageId = (vwRequestModerator.Items[e.Item.DataItemIndex].FindControl("hfldMessageId") as HiddenField).Value.Trim();
            string memberId = (vwRequestModerator.Items[e.Item.DataItemIndex].FindControl("lblSender") as Label).Text.Trim();
            Message message = new Message()
            {
                CreateTime = DateTime.Now,
                MessageId = MessageManagement.CreateMessageId(),
                MessageState = "未查看",
                MessageType = "普通",
                Recipient = memberId,
                Sender = "0000000000"
            };
            if (e.CommandName == "Agree")
            {
                MessageManagement.Review(messageId);
                message.MessageText = "管理员同意了您的请求，你已经是版主了";
                MessageManagement.Send(message);
            }
            else if (e.CommandName == "Disagree")
            {
                MessageManagement.Review(messageId);
                message.MessageText = "管理员拒绝了您的请求，申请版主失败";
                MessageManagement.Send(message);
            }
        }

        protected void vwResignModerator_ItemCommand(object sender, ListViewCommandEventArgs e)//处理辞去版主
        {
            string messageId = (vwResignModerator.Items[e.Item.DataItemIndex].FindControl("hfldMessageId") as HiddenField).Value.Trim();
            string memberId = (vwResignModerator.Items[e.Item.DataItemIndex].FindControl("lblSender") as Label).Text.Trim();
            Message message = new Message()
            {
                CreateTime = DateTime.Now,
                MessageId = MessageManagement.CreateMessageId(),
                MessageState = "未查看",
                MessageType = "普通",
                Recipient = memberId,
                Sender = "0000000000"
            };
            if (e.CommandName == "Agree")
            {
                MessageManagement.Review(messageId);
                message.MessageText = "管理员同意了您的请求，您已经辞去了版主";
                MessageManagement.Send(message);
            }
            else if (e.CommandName == "Disagree")
            {
                MessageManagement.Review(messageId);
                message.MessageText = "管理员拒绝了您的请求，您目前还是版主";
                MessageManagement.Send(message);
            }
        }
    }
}