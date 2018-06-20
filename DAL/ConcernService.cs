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
    public class ConcernService:IConcernService
    {
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        public int insertConcern(Concern con)
        {
            string sql = "insert into Concern(concern_id,concern_member,concern_to) values(@concernId,@concernMember,@concernTo)";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@concernId",con.ConcernId),
                new SqlParameter("@concernMember",con.ConcernMember),
                new SqlParameter("@concernTo",con.ConcernTo)
            };
            return SqlHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 删除关注关系
        /// </summary>
        /// <param name="concernMember"></param>
        /// <param name="concernTo"></param>
        /// <returns></returns>
        public int delete(string concernMember, string concernTo)
        {
            string sql = "delete from concern where concern_member=@concern_member and concern_to=@concernTo";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@concern_member", concernMember),
                new SqlParameter("@concernTo", concernTo)
            };
            return SqlHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 查询所有已存在的关注编号
        /// </summary>
        /// <returns></returns>
        public DataTable select()
        {
            string sql = "select concern_id from concern";
            return SqlHelper.GetTable(sql, null);
        }
        /// <summary>
        /// 查询关注关系是否存在
        /// </summary>
        /// <param name="memberId">会员账号</param>
        /// <param name="themeId">主题编号</param>
        /// <returns></returns>
        public int SelectNum(string concernMember, string concernTo)
        {
            string sql = "select count(*) from concern where concern_member=@concern_member and concern_to=@concernTo";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@concern_member", concernMember),
                new SqlParameter("@concernTo", concernTo)
            };
            return (int)SqlHelper.ExecuteScaler(sql, parameters);
        }
        /// <summary>
        /// 查询我关注的会员的编号、头像和用户名
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public DataTable SelectMember(string memberId)
        {
            string sql = "select member_id,name,picture from concern,Member where concern_to=member_id and concern_member=@concern_member";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@concern_member", memberId)
            };
            return SqlHelper.GetTable(sql, parameters);
        }
    }
}
