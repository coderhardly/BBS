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
    public class ThemeService : IThemeService
    {
        /// <summary>
        /// 查询所有主题
        /// </summary>
        /// <returns></returns>
        public DataTable Select()
        {
            string sql = "select * from Theme";
            return SqlHelper.ExecuteReader(sql, null);
        }
        /// <summary>
        /// 根据主题编号查询主题
        /// </summary>
        /// <param name="themeId">主题编号</param>
        /// <returns></returns>
        public DataTable Select(string themeId)
        {
            string sql = "select * from Theme where theme_id=@theme_id";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@theme_id",themeId)
            };
            return SqlHelper.ExecuteReader(sql, parameters);
        }
        /// <summary>
        /// 根据主题编号修改主题
        /// </summary>
        /// <param name="themeId">主题编号</param>
        /// <param name="mode">0：置顶 1：取消置顶 2：设为精华 3：取消精华</param>
        /// <returns> 受影响的行数</returns>
        public int Update(string themeId, int mode)
        {
            string operate;
            switch (mode)
            {
                case 0: operate = "is_settop=1"; break;
                case 1: operate = "is_settop=0"; break;
                case 2: operate = "is_essence=1"; break;
                case 3: operate = "is_essence=0"; break;
                default:
                    operate = null;
                    break;
            }
            if (operate != null)
            {
                string sql = "update Theme set " + operate + " where theme_id=@theme_id";
                SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@theme_id",themeId)
            };
                return SqlHelper.ExecuteNonQuery(sql, parameters);
            }
            return 0;
        }
        /// <summary>
        /// 修改点击量
        /// </summary>
        /// <param name="themeId">主题编号</param>
        /// <param name="clicks">点击量</param>
        /// <returns></returns>
        public int UpdateClicks(string themeId)
        {
            string sql = "update Theme set clicks=clicks+1 where theme_id=@theme_id";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@theme_id",themeId)
            };
            return SqlHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 插入主题
        /// </summary>
        /// <param name="theme"></param>
        /// <returns></returns>
        public int Insert(Theme theme)
        {
            string sql = "insert into Theme values(@theme_id,@publish_time,@title,@theme_text,@is_essence,@is_settop,@clicks,@creator,@belong_to_division)";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@theme_id",theme.ThemeId),
                new SqlParameter("@publish_time",theme.PublishTime),
                new SqlParameter("@title",theme.Title),
                new SqlParameter("@theme_text",theme.ThemeText),
                new SqlParameter("@is_essence",theme.IsEssence),
                new SqlParameter("@is_settop",theme.IsSettop),
                new SqlParameter("@clicks",theme.Clicks),
                new SqlParameter("@creator",theme.Creator),
                new SqlParameter("@belong_to_division",theme.BelongToDivision)
            };
            return SqlHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 根据编号删除主题
        /// </summary>
        /// <param name="themeId"></param>
        /// <returns></returns>
        public int Delete(string themeId)
        {
            string sql = "delete from Theme where theme_id=@theme_id";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@theme_id",themeId)
            };
            return SqlHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 查询主题编号
        /// </summary>
        /// <param name="themeId">主题编号</param>
        /// <returns></returns>
        public DataTable SelectId()
        {
            string sql = "select theme_id from Theme";
            return SqlHelper.GetTable(sql, null);
        }
        /// <summary>
        /// 查询主题并按要求排序
        /// </summary>
        /// <param name="orderBy">"时间" "精华"</param>
        /// <returns></returns>
        public DataTable SelectBy(string orderBy, string divisionName)
        {
            string sql = "select publish_time,title,A.theme_id theme_id,creator,is_essence,is_settop,clicks,picture,name,criticism_num from (select publish_time,title,theme_id,creator,is_essence,is_settop,clicks from Theme,Division where belong_to_division=Division.division_id and division_name=@division_name ";
            string part = ") as A left join Member on A.creator=Member.member_id left join (select theme_id,count(*) criticism_num from Criticism group by theme_id) as B on A.theme_id=B.theme_id";
            switch (orderBy)
            {
                case "时间":
                    part += " order by publish_time desc";
                    sql += part;
                    break;
                case "精华":
                    sql += "and is_essence=1";
                    part += " order by publish_time desc";
                    sql += part;
                    break;
                default:
                    break;
            }
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@division_name",divisionName)
            };
            return SqlHelper.GetTable(sql, parameters);
        }
        //public DataTable SelectBy(string orderBy, string divisionId,string key)
        //{
        //    string sql = "select publish_time,title,A.theme_id theme_id,creator,is_essence,is_settop,clicks,picture,name,criticism_num from (select publish_time,title,theme_id,creator,is_essence,is_settop,clicks from Theme where belong_to_division=@division_id ";
        //    string part = ") as A left join Member on A.creator=Member.member_id left join (select theme_id,count(*) criticism_num from Criticism group by theme_id) as B on A.theme_id=B.theme_id";
        //    switch (orderBy)
        //    {
        //        case "主题":
        //            part += " and title like '%@key%'";
        //            sql += part;
        //            break;
        //        default:
        //            break;
        //    }
        //    SqlParameter[] parameters = new SqlParameter[]{
        //        new SqlParameter("@division_id",divisionId),
        //        new SqlParameter("@key",key)
        //    };
        //    return SqlHelper.GetTable(sql, parameters);
        //}
        /// <summary>
        /// 查看我的收藏
        /// </summary>
        /// <param name="memberId">会员账号</param>
        /// <returns></returns>
        public DataTable SelectMyCollect(string memberId)
        {
            string sql = "select publish_time,title,A.theme_id theme_id,creator,is_essence,is_settop,clicks,picture,name,criticism_num from (select publish_time,title,theme_id theme_id,creator,is_essence,is_settop,clicks from Theme where theme_id in(select theme_id from Collect_theme where member_id=@memberId)) as A left join Member on A.creator=member_id left join (select theme_id,count(theme_id) criticism_num from Criticism group by theme_id) as B on A.theme_id=B.theme_id order by publish_time desc";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@memberId",memberId)
            };
            return SqlHelper.GetTable(sql, parameters);
        }
        /// <summary>
        /// 查看我的主题
        /// </summary>
        /// <param name="creator">会员账号</param>
        /// <returns></returns>
        public DataTable SelectMyTheme(string creator)
        {
            string sql = "select publish_time,title,A.theme_id theme_id,creator,is_essence,is_settop,clicks,picture,name,criticism_num from (select publish_time,title,theme_id theme_id,creator,is_essence,is_settop,clicks,name,picture from Theme,Member where creator=member_id and creator=@creator) as A left join (select theme_id,count(theme_id) criticism_num from Criticism group by theme_id) as B on A.theme_id=B.theme_id order by publish_time desc";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@creator",creator)
            };
            return SqlHelper.GetTable(sql, parameters);
        }
        /// <summary>
        /// 查询编号是否存在
        /// </summary>
        /// <param name="themeId">主题编号</param>
        /// <returns></returns>
        public int SelectNum(string themeId)
        {
            string sql = "select count(*) from Theme where theme_id=@theme_id";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@theme_id",themeId)
            };
            return (int)SqlHelper.ExecuteScaler(sql, parameters);
        }
        /// <summary>
        /// 根据关键词匹配主题标题或内容（模糊查询）
        /// </summary>
        /// <param name="key">关键词</param>
        /// <returns></returns>
        public DataTable SelectByKey(string key)
        {
            string sql = "select publish_time,title,A.theme_id theme_id,creator,is_essence,is_settop,clicks,picture,name,criticism_num from (select publish_time,title,theme_id,creator,is_essence,is_settop,clicks from Theme where title like '%'+@key+'%' or theme_text like '%'+@key+'%') as A left join Member on A.creator=member_id left join (select theme_id,count(theme_id) criticism_num from Criticism group by theme_id) as B on A.theme_id=B.theme_id";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@key",key)
            };
            return SqlHelper.GetTable(sql, parameters);
        }
        /// <summary>
        /// 根据主题编号查找主题（与Member表连接查询）
        /// </summary>
        /// <param name="themeId"></param>
        /// <returns></returns>
        public DataTable SelectByThemeId(string themeId)
        {
            string sql = "select theme_id,theme_text,publish_time,A.creator creator,name,xp,picture,title from (select * from Theme where theme_id=@theme_id) as A left join Member on A.creator=Member.member_id";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@theme_id",themeId)
            };
            return SqlHelper.GetTable(sql, parameters);
        }
    }
}
