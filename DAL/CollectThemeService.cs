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
    public class CollectThemeService : ICollectThemeService
    { 
        /// <summary>
        /// 添加收藏
        /// </summary>
        /// <param name="collect"></param>
        /// <returns></returns>
        public int InsertTheme(CollectTheme collect)
        {
            string sql = "insert into Collect_theme values(@collect_id,@remark,@theme_id,@member_id)";
            SqlParameter[] parameters = new SqlParameter[]{
                    new SqlParameter("collect_id",collect.CollectId),
                    new SqlParameter("remark",collect.Remark),
                    new SqlParameter("theme_id",collect.ThemeId),
                    new SqlParameter("member_id",collect.MemberId)

                };
            return SqlHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 取消收藏
        /// </summary>
        /// <param name="collect">收藏编号</param>
        /// <returns></returns>
        public int Delete(string collectId)
        {
            string sql = "delete from Collect_theme where collect_id=@collectId ";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("collectId",collectId)
            };
            return SqlHelper.ExecuteNonQuery(sql, parameters);

        }
        /// <summary>
        /// 取消收藏
        /// </summary>
        /// <param name="memberId">会员账号</param>
        /// <param name="themeId">主题编号</param>
        /// <returns></returns>
        public int Delete(string memberId, string themeId)
        {
            string sql = "delete from Collect_theme where member_id=@member_id and theme_id=@theme_id";
            SqlParameter[] parameter = new SqlParameter[] { 
                new SqlParameter("@member_id", memberId),
                new SqlParameter("@theme_id", themeId),
            };
            return (int)SqlHelper.ExecuteNonQuery(sql, parameter);
        }
        /// <summary>
        /// 查询所有收藏编号
        /// </summary>
        /// <returns></returns>
        public DataTable Select()
        {
            string sql = "select collect_id from Collect_theme ";
            return SqlHelper.GetTable(sql, null);
        }
        /// <summary>
        /// 查询是否已收藏主题
        /// </summary>
        /// <param name="collect"></param>
        /// <returns></returns>
        public int SelectNum(string memberId,string themeId)
        {
            string sql = "select count(*) from Collect_theme where member_id=@member_id and theme_id=@theme_id";
            SqlParameter[] parameter = new SqlParameter[] { 
                new SqlParameter("@member_id", memberId),
                new SqlParameter("@theme_id", themeId),
            };
            return (int)SqlHelper.ExecuteScaler(sql, parameter);
        }
    }
}
