using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
using System.Data;

namespace IDAL
{
    public interface IMessageService
    {
        /// <summary>
        /// 查询收到的消息
        /// </summary>
        /// <param name="recipient">接收者编号</param>
        /// <param name="messageState">“已查看” 或“未查看”</param>
        /// <returns></returns>
        DataTable Select(string recipient, string messageState);
        /// <summary>
        /// 查找会员收到的消息
        /// </summary>
        /// <param name="recipient">接收者编号</param>
        /// <param name="messageState">消息状态：“未查看”，“已查看”</param>
        /// <param name="messageType">消息类型：“举报”，“普通”等</param>
        /// <returns></returns>
        DataTable SelectByRecipient(string recipient, string messageState, string messageType);
        /// <summary>
        /// 查找会员发送的消息
        /// </summary>
        /// <param name="sender">发送者编号</param>
        /// <param name="messageType">消息类型：“举报”，“普通”等</param>
        /// <returns></returns>
        DataTable SelectBySender(string sender, string messageType);
        /// <summary>
        /// 插入消息
        /// </summary>
        /// <param name="message">Message实体类对象</param>
        /// <returns></returns>
        int Insert(Message message);
        /// <summary>
        /// 设置消息为已查看
        /// </summary>
        /// <param name="messageId">接收者编号</param>
        /// <returns></returns>
        int Update(string messageId);
        /// <summary>
        /// 删除消息
        /// </summary>
        /// <param name="messageId">接收者编号</param>
        /// <returns></returns>
        int Delete(string messageId);
        
        /// <summary>
        /// 查找用户编号
        /// </summary>
        /// <returns></returns>
        DataTable SelectId();
    }
}
