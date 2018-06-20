using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
using IDAL;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class MessageService : IMessageService
    {
        /// <summary>
        /// 查询收到的消息
        /// </summary>
        /// <param name="recipient">接收者编号</param>
        /// <param name="messageState">“已查看” 或“未查看”</param>
        /// <returns></returns>
        public DataTable Select(string recipient, string messageState)
        {
            string sql = "select message_id,message_text,create_time,sender,name from (select * from Msg where recipient=@recipient and message_state=@message_state) A left join Member on A.sender=Member.member_id order by create_time desc";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@message_state",messageState),
                new SqlParameter("@recipient",recipient)
            };
            return SqlHelper.GetTable(sql, parameters);
        }
        /// <summary>
        /// 查找会员收到的消息
        /// </summary>
        /// <param name="recipient">接收者编号</param>
        /// <param name="messageState">消息状态：“未查看”，“已查看”</param>
        /// <param name="messageType">消息类型：“举报”，“普通”等</param>
        /// <returns></returns>
        public DataTable SelectByRecipient(string recipient, string messageState, string messageType)
        {
            string sql = "select message_id,message_text,create_time,sender,name from (select * from Msg where recipient=@recipient and message_state=@message_state and message_type=@message_type) A left join Member on A.sender=Member.member_id order by create_time desc";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@message_state",messageState),
                new SqlParameter("@recipient",recipient),
                new SqlParameter("message_type",messageType)
            };
            return SqlHelper.GetTable(sql, parameters);
        }
        /// <summary>
        /// 查找会员发送的消息
        /// </summary>
        /// <param name="sender">发送者编号</param>
        /// <param name="messageType">消息类型：“举报”，“普通”等</param>
        /// <returns></returns>
        public DataTable SelectBySender(string sender, string messageType)
        {
            string sql = "select message_id,message_text,create_time,recipient,name from (select * from Msg where sender=@sender and message_type=@message_type) A left join Member on A.recipient=Member.member_id order by create_time desc";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@sender",sender),
                new SqlParameter("message_type",messageType)
            };
            return SqlHelper.GetTable(sql, parameters);
        }
        /// <summary>
        /// 插入消息
        /// </summary>
        /// <param name="message">Message实体类对象</param>
        /// <returns></returns>
        public int Insert(Message message)
        {
            string sql = "insert into Msg values(@message_id,@message_text,@create_time,@message_type,@message_state,@sender,@recipient)";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@message_id",message.MessageId),
                new SqlParameter("@message_text",message.MessageText),
                new SqlParameter("@create_time",message.CreateTime),
                new SqlParameter("@message_type",message.MessageType),
                new SqlParameter("@message_state",message.MessageState),
                new SqlParameter("@sender",message.Sender),
                new SqlParameter("@recipient",message.Recipient)
            };
            return SqlHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 设置消息为已查看
        /// </summary>
        /// <param name="messageId">接收者编号</param>
        /// <returns></returns>
        public int Update(string messageId)
        {
            string sql = "update Msg set message_state='已查看' where message_id=@message_id";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@message_id",messageId)
            };
            return SqlHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 删除消息
        /// </summary>
        /// <param name="messageId">接收者编号</param>
        /// <returns></returns>
        public int Delete(string messageId)
        {
            string sql = "delete Msg where message_id=@message_id";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@message_id",messageId)
            };
            return SqlHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 查找用户编号
        /// </summary>
        /// <returns></returns>
        public DataTable SelectId()
        {
            string sql = "select message_id from Msg";
            return SqlHelper.GetTable(sql, null);
        }
    }
}
