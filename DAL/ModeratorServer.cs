using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IDAL;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ModeratorServer:IModeratorService
    {
        /// <summary>
        /// 插入版主信息
        /// </summary>
        /// <param name="moderator">Moderator实体类</param>
        /// <returns></returns>
        public int Insert(Moderator moderator)
        {
            string sql = "insert into Moderator values(@moderator_id,@division_id,@member_id)";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@moderator_id",moderator.ModeratorId),
                new SqlParameter("@division_id",moderator.DivisionId),
                new SqlParameter("@member_id",moderator.MemberId)
            };
            return SqlHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 根据版主编号和版块编号删除版主
        /// </summary>
        /// <param name="moderator"></param>
        /// <returns></returns>
        public int Delete(string memberId, string divisionId)
        {
            string sql = "delete Moderator where division_id=@division_id and member_id=@member_id)";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@division_id",divisionId),
                new SqlParameter("@member_id",memberId)
            };
            return SqlHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 根据版主编号删除版主
        /// </summary>
        /// <param name="moderatorId">版主编号</param>
        /// <returns></returns>
        public int Delete(string moderatorId)
        {
            string sql = "delete Moderator where moderator_id=@moderator_id";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@moderator_id",moderatorId)
            };
            return SqlHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 根据版块编号查询版主的用户名（联合查询）
        /// </summary>
        /// <param name="divisionId">版块编号</param>
        /// <returns>版主的账号和用户名</returns>
        public DataTable Select(string divisionId)
        {
            string sql = "select Member.member_id member_id,name,xp,lasttime_online  from Member,Moderator where Member.member_id=Moderator.member_id and Moderator.division_id=@division_id";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@division_id",divisionId),
            };
            return SqlHelper.ExecuteReader(sql, parameters);
        }
        /// <summary>
        /// 查询版主信息：版主编号，版块名，会员用户名（联合查询）
        /// </summary>
        /// <returns></returns>
        public DataTable Select()
        {
            string sql = "select moderator_id,division_name,name from Moderator,Division,Member where Moderator.division_id=Division.division_id and Moderator.member_id=Member.member_id";
            return SqlHelper.ExecuteReader(sql, null);
        }
        /// <summary>
        /// 根据版块编号查询版主信息：版主编号，版块名，会员用户名（联合查询）
        /// </summary>
        /// <returns></returns>
        public DataTable SelectByDivisionId(string divisionId)
        {
            string sql = "select moderator_id,division_name,name from Moderator,Division,Member where Moderator.division_id=Division.division_id and Moderator.member_id=Member.member_id and Moderator.division_id=@division_id";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@division_id",divisionId),
            };
            return SqlHelper.ExecuteReader(sql, parameters);
        }
        /// <summary>
        /// 根据版主编号查询版主数量
        /// </summary>
        /// <param name="moderatorId">版主编号</param>
        /// <returns></returns>
        public int SelectNum(string moderatorId)
        {
            string sql = "select count(*) from Moderator where moderator_id=@moderator_id";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@moderator_id",moderatorId),
            };
            return (int)SqlHelper.ExecuteScaler(sql, parameters);
        }
        /// <summary>
        /// 查找所有版主编号
        /// </summary>
        /// <returns></returns>
        public DataTable SelectId()
        {
            string sql = "select moderator_id from Moderator";
            return SqlHelper.GetTable(sql, null);
        }
        /// <summary>
        /// 查找会员账号外的其他信息
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public DataTable SelectOther(string memberId)
        {
            string sql = "select moderator_id,division_id from Moderator where member_id=@member_id";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@member_id",memberId)
            };
            return SqlHelper.ExecuteReader(sql, parameters);
        }
        /// <summary>
        /// 根据版块名称查询所有版主的用户名
        /// </summary>
        /// <param name="divisionName">版块编号</param>
        /// <returns></returns>
        public DataTable SelectName(string divisionName)
        {
            string sql = "select name from Moderator,Member,Division where Moderator.member_id=Member.member_id and Division.division_id=Moderator.division_id and division_name=@division_name";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@division_name",divisionName)
            };
            return SqlHelper.GetTable(sql, parameters);
        }
    }
}
