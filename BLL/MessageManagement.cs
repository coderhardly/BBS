using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IDAL;
using Model;
using System.Data;

namespace BLL
{
    public class MessageManagement
    {
        static IMessageService IMS;
        static MessageManagement(){
            IServiceFactory isf = new ServiceFactory();
            IMS = isf.createIMessageService();
        }
        /// <summary>
        /// 查询收到的消息
        /// </summary>
        /// <param name="recipient">接收者</param>
        /// <param name="messageState">消息状态：“已查看”“未查看”</param>
        /// <param name="messageType">消息类型：“举报”“普通”“申请”等</param>
        /// <returns></returns>
        public static DataTable SelectByRecipient(string recipient, string messageState, string messageType)
        {
            return IMS.SelectByRecipient(recipient, messageState, messageType);
        }
        public static DataTable SelectByRecipient(string recipient, string messageState)
        {
            return IMS.SelectByRecipient(recipient, messageState, "普通");
        }
        /// <summary>
        /// 查找会员发送的消息
        /// </summary>
        /// <param name="sender">发送者编号</param>
        /// <returns></returns>
        public static DataTable SelectBySender(string sender)
        {
            return IMS.SelectBySender(sender, "普通");
        }
        /// <summary>
        /// 将消息修改为已查看
        /// </summary>
        /// <param name="messageId"></param>
        public static void Review(string messageId)
        {
            IMS.Update(messageId);
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="message">Message实体类</param>
        /// <returns></returns>
        public static string Send(Message message)
        {
            if (message.IsError)
            {
                return message.GetErrorMsg();
            }
            if (IMS.Insert(message) == 1)
            {
                return "发送成功";
            }
            else
            {
                return "发送失败";
            }
        }
        /// <summary>
        /// 删除消息
        /// </summary>
        /// <param name="messageId">消息编号</param>
        /// <returns></returns>
        public static string Delete(string messageId)
        {
            if (IMS.Delete(messageId) > 0)
            {
                return "删除成功";
            }
            else
            {
                return "删除失败";
            }
        }
        /// <summary>
        /// 生成消息编号
        /// </summary>
        /// <returns></returns>
        public static string CreateMessageId()
        {
            return OtherMethod.CreateId(14, IMS.SelectId());
        }
    }
}
