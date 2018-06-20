using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Message : BaseModel
    {
        private string messageId;
        private string sender;
        private string recipient;
        private string messageType;
        private string messageState;
        public string MessageId//消息编号
        {
            get { return messageId; }
            set
            {
                if (value.Length == 14)
                {
                    messageId = value;
                }
                else
                {
                    IsError = true;
                }
            }
        }
        public string Sender//发送者编号
        {
            get { return sender; }
            set
            {
                if (value.Length == 10)
                {
                    sender = value;
                }
                else
                {
                    IsError = true;
                }
            }
        }
        public string Recipient//接收者编号
        {
            get { return recipient; }
            set
            {
                if (value.Length == 10)
                {
                    recipient = value;
                }
                else
                {
                    IsError = true;
                }
            }
        }
        public string MessageType//消息类型
        {
            get { return messageType; }
            set
            {
                if (value == "请求" || value == "通知" || value == "普通" || value == "举报")
                {
                    messageType = value;
                }
                else
                {
                    IsError = true;
                }
            }
        }
        public string MessageState//消息状态
        {
            get { return messageState; }
            set
            {
                if (value == "已查看" || value == "未查看")
                {
                    messageState = value;
                }
                else
                {
                    IsError = true;
                }
            }
        }
        public string MessageText { get; set; }//消息内容
        public DateTime CreateTime { get; set; }//创建时间
    }
}
