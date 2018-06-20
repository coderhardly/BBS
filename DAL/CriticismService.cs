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
    public class CriticismService : ICriticismService
    {
        /// <summary>
        /// 查询所有评论
        /// </summary>
        /// <returns></returns>
        public DataTable Select()
        {
            string sql = "select * from Criticism order by publish_time desc";
            return SqlHelper.ExecuteReader(sql, null);
        }
        /// <summary>
        /// 根据编号查询评论
        /// </summary>
        /// <param name="criticismId">评论编号</param>
        /// <returns></returns>
        public DataTable Select(string criticismId)
        {
            string sql = "select * from Criticism where criticism_id=@criticism_id";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@criticism_id",criticismId)
            };
            return SqlHelper.ExecuteReader(sql, parameters);
        }
        /// <summary>
        /// 根据主题查询评论（新）
        /// </summary>
        /// <param name="themeId">主题编号</param>
        /// <returns></returns>
        public DataTable SelectByThemeId(string themeId)
        {
            string sql = "select criticism_id,criticism_text,publish_time,A.member_id member_id,name,xp,picture,connected_criticism,theme_id from (select *  from Criticism where theme_id=@theme_id) as A left join Member on A.member_id=Member.member_id order by publish_time desc";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@theme_id",themeId)
            };
            return SqlHelper.ExecuteReader(sql, parameters);
        }
        /// <summary>
        /// 根据会员查询评论
        /// </summary>
        /// <param name="memberId">会员编号</param>
        /// <returns></returns>
        public DataTable SeleteByMember(string memberId)
        {
            string sql = "select * from Criticism where member_id=@member_id order by publish_time desc";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@member_id",memberId)
            };
            return SqlHelper.GetTable(sql, parameters);
        }
        /// <summary>
        /// 查询所有已存在编号
        /// </summary>
        /// <returns></returns>
        public DataTable SelectId()
        {
            string sql = "select criticism_id from Criticism";
            return SqlHelper.GetTable(sql, null);
        }
        /// <summary>
        /// 插入评论(connected_criticism为空)
        /// </summary>
        /// <param name="criticism">Criticism实体类</param>
        /// <returns></returns>
        public int Insert(Criticism criticism)
        {
            string sql = "insert into Criticism(criticism_id,criticism_text,publish_time,member_id,theme_id) values(@criticism_id,@criticism_text,@publish_time,@member_id,@theme_id)";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@criticism_id",criticism.CriticismId),
                new SqlParameter("@criticism_text",criticism.CriticismText),
                new SqlParameter("@publish_time",criticism.PublishTime),
                new SqlParameter("@member_id",criticism.MemberId),
                new SqlParameter("@theme_id",criticism.ThemeId)
            };
            return SqlHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 插入回复
        /// </summary>
        /// <param name="criticism">Criticism实体类</param>
        /// <returns></returns>
        public int InsertReply(Criticism criticism)
        {
            string sql = "insert into Criticism(criticism_id,criticism_text,publish_time,member_id,theme_id,connected_criticism) values(@criticism_id,@criticism_text,@publish_time,@member_id,@theme_id,@connected_criticism)";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@criticism_id",criticism.CriticismId),
                new SqlParameter("@criticism_text",criticism.CriticismText),
                new SqlParameter("@publish_time",criticism.PublishTime),
                new SqlParameter("@member_id",criticism.MemberId),
                new SqlParameter("@theme_id",criticism.ThemeId),
                new SqlParameter("@connected_criticism",criticism.ConnectedCriticism)
            };
            return SqlHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 查找编号的数量
        /// </summary>
        /// <param name="criticismId"></param>
        /// <returns></returns>
        public int SelectNum(string criticismId)
        {
            string sql = "select count(*) from Criticism where criticism_id=@criticism_id";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@criticism_id",criticismId)
            };
            return (int)SqlHelper.ExecuteScaler(sql, parameters);
        }
        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="criticismId">评论编号</param>
        /// <returns></returns>
        public int Delete(string criticismId)
        {
            string sql = "delete Criticism where criticism_id=@criticism_id";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@criticism_id",criticismId)
            };
            return SqlHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 查询评论和会员表
        /// </summary>
        /// <param name="themeId">主题编号</param>
        /// <returns></returns>
        public DataTable SelectMC(string themeId)
        {
            string sql = "select criticism_id,criticism_text,publish_time,Criticism.member_id member_id,name,xp,Picture from Criticism,Member where theme_id=@theme_id and Member.member_id=Criticism.member_id order by publish_time desc";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@theme_id",themeId)
            };
            return SqlHelper.ExecuteReader(sql, parameters);
        }
        /// <summary>
        /// 查询二级回复相关信息
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public DataTable SelectCToC(string memberId)
        {
            //查询评论编号、内容、评论时间，主题编号、标题以及引用的评论的内容、评论者账号、用户名
            string sql = "select A.criticism_id criticism_id,A.criticism_text myCriticism,title,A.theme_id theme_id,A.publish_time publish_time,B.criticism_text toCriticism,name,Member.member_id from (select criticism_id,criticism_text,connected_criticism,theme_id,publish_time from Criticism where member_id=@member_id) as A left join Theme on A.theme_id=Theme.theme_id left join Criticism as B on A.connected_criticism=B.criticism_id and A.connected_criticism is not null left join Member on Member.member_id=B.member_id order by A.publish_time desc";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@member_id",memberId)
            };
            return SqlHelper.GetTable(sql, parameters);
        }
    }
}
