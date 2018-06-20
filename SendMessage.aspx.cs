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
    public partial class SendMessage : System.Web.UI.Page
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
            if (Request["recipient"]!=null)
            {
                txtRecipient.Text = Request["recipient"];
            }
        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            SomeMethod.IfLogin(this);
            Message message = new Message()
            {
                Sender = Convert.ToString(Session["memberId"]),
                Recipient = txtRecipient.Text.Trim(),
                MessageId = MessageManagement.CreateMessageId(),
                CreateTime = DateTime.Now,
                MessageType = "普通",
                MessageState = "未查看",
                MessageText=txtMsg.Text.Trim()
            };
            SomeMethod.PrintMsgToClient(this.ClientScript, MessageManagement.Send(message));
        }
    }
}