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
    public class DivisionService : IDivisionService
    {
        /// <summary>
        /// 插入版块记录
        /// </summary>
        /// <param name="division">Division实体类</param>
        /// <returns></returns>
        public int Insert(Division division)
        {
            string sql = "insert into Division values(@division_id,@division_name,@division_picture)";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@division_id",division.DivisionId),
                new SqlParameter("@division_name",division.DivisionName),
                new SqlParameter("@division_picture",division.DivisionPicture)
            };
            return SqlHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 更新版块信息
        /// </summary>
        /// <param name="division">Division实体类</param>
        /// <returns></returns>
        public int Update(Division division)
        {
            string sql = "update Division set division_name=@division_name,division_picture=@division_picture where division_id=@division_id";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@division_id",division.DivisionId),
                new SqlParameter("@division_name",division.DivisionName),
                new SqlParameter("@division_picture",division.DivisionPicture)
            };
            return SqlHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 删除版块
        /// </summary>
        /// <param name="divisionId">版块编号</param>
        /// <returns></returns>
        public int Delete(string divisionId)
        {
            string sql = "delete Division where division_id=@division_id";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@division_id",divisionId)
            };
            return SqlHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 根据版块编号查找版块数量
        /// </summary>
        /// <param name="divisionId">版块编号</param>
        /// <returns></returns>
        public int SelectNum(string divisionId)
        {
            string sql = "select count(*) from Division where division_id=@division_id";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@division_id",divisionId)
            };
            return (int)SqlHelper.ExecuteScaler(sql, parameters);
        }
        /// <summary>
        /// 查询所有版块信息
        /// </summary>
        /// <returns></returns>
        public DataTable Select()
        {
            string sql = "select * from Division";
            return SqlHelper.GetTable(sql, null);
        }
        /// <summary>
        /// 查找所有版块编号
        /// </summary>
        /// <returns></returns>
        public DataTable SelectId()
        {
            string sql = "select division_id from Division";
            return SqlHelper.GetTable(sql, null);
        }
    }
}
