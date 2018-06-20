using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BLL;
using Model;
using System.Data;

namespace Web
{
    public partial class MyMessage : System.Web.UI.Page
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
            SomeMethod.IfLogin(this);
            vwNotView.DataSource = MessageManagement.SelectByRecipient(Convert.ToString(Session["memberId"]), "未查看");
            vwNotView.DataBind();
            vwSend.DataSource = MessageManagement.SelectBySender(Convert.ToString(Session["memberId"]));
            vwSend.DataBind();
            vwReview.DataSource = MessageManagement.SelectByRecipient(Convert.ToString(Session["memberId"]), "已查看");
            vwReview.DataBind();
            if (Request["recipient"] != null)
            {
                txtMemberId.Text = Convert.ToString(Request["recipient"]);
            }
        }

        protected void btnPubCriticism_Click(object sender, EventArgs e)
        {
            SomeMethod.IfLogin(this);
            Message message = new Message()
            {
                Sender = Convert.ToString(Session["memberId"]),
                Recipient = txtMemberId.Text.Trim(),
                CreateTime = DateTime.Now,
                MessageId = MessageManagement.CreateMessageId(),
                MessageState = "未查看",
                MessageText = Server.UrlDecode(hidContent.Value),
                MessageType = "普通",
            };
            SomeMethod.PrintMsgToClient(this.ClientScript, MessageManagement.Send(message));
        }
    }
}