using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
using IDAL;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class UserInfoService : IUserInfoService
    {
        /// <summary>
        /// 查询所有记录
        /// </summary>
        /// <returns>返回DataTable对象</returns>
        public DataTable Select()
        {
            string sql = "select * from UserInfo";
            return SqlHelper.GetTable(sql, null);
        }
        /// <summary>
        /// 根据编号查询用户信息
        /// </summary>
        /// <param name="userInfo_id"></param>
        /// <returns>返回DataTable对象</returns>
        public DataTable Select(string userInfo_id)
        {
            string sql = "select * from UserInfo where userInfo_id=@userInfo_id";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@userInfo_id",userInfo_id)
            };
            return SqlHelper.GetTable(sql, parameters);
        }
        /// <summary>
        /// 向UserInfo表中插入数据
        /// </summary>
        /// <param name="member">UserInfo</param>
        /// <returns>受影响的行数</returns>
        public int Insert(UserInfo userInfo)
        {
            string sql = "insert into UserInfo values(@userInfo_id,@name,@sex,@age,@tel,@email,@job,@addr,@motto)";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@userInfo_id",userInfo.UserInfoId),
                new SqlParameter("@name",userInfo.Name),
                new SqlParameter("@sex",userInfo.Sex),
                new SqlParameter("@age",userInfo.Age),
                new SqlParameter("@tel",userInfo.Tel),
                new SqlParameter("@email",userInfo.Email),
                new SqlParameter("@job",userInfo.Job),
                new SqlParameter("@addr",userInfo.Addr),
                new SqlParameter("@motto",userInfo.Motto)
            };
            return SqlHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 根据userInfo_id查询记录数量
        /// </summary>
        /// <param name="userInfoId"></param>
        /// <returns></returns>
        public int SelectNum(string userInfoId)
        {
            string sql = "select count(*) from UserInfo where userInfo_id=@userInfo_id";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@userInfo_id",userInfoId)
            };
            return (int)SqlHelper.ExecuteScaler(sql, parameters);
        }
        /// <summary>
        /// 由用户编号删除用户记录
        /// </summary>
        /// <param name="userInfoId">用户编号</param>
        /// <returns>删除用户的数量</returns>
        public int Delete(string userInfoId)
        {
            string sql="delete from UserInfo where userInfo_id=@userInfo_id";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@userInfo_id",userInfoId)
            };
            return SqlHelper.ExecuteNonQuery(sql,parameters);
        }
        /// <summary>
        /// 修改用户个人信息
        /// </summary>
        /// <param name="userInfo">会员Member</param>
        /// <returns>受影响的行数</returns>
        public int Update(UserInfo userInfo)
        {
            string sql = "update UserInfo set name=@name,sex=@sex,age=@age,tel=@tel,email=@email,job=@job,addr=@addr,motto=@motto where userInfo_id=@userInfo_id";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@userInfo_id",userInfo.UserInfoId),
                new SqlParameter("@name",userInfo.Name),
                new SqlParameter("@sex",userInfo.Sex),
                new SqlParameter("@age",userInfo.Age),
                new SqlParameter("@tel",userInfo.Tel),
                new SqlParameter("@email",userInfo.Email),
                new SqlParameter("@job",userInfo.Job),
                new SqlParameter("@addr",userInfo.Addr),
                new SqlParameter("@motto",userInfo.Motto)
            };
            return SqlHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 查找用户编号
        /// </summary>
        /// <returns></returns>
        public DataTable SelectId()
        {
            string sql = "select userInfo_id from UserInfo";
            return SqlHelper.GetTable(sql, null);
        }
        /// <summary>
        /// 根据会员编号查询用户信息
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns>返回DataTable对象</returns>
        public DataTable SelectInfo(string memberId)
        {
            string sql = "select * from UserInfo,Member where UserInfo.userInfo_id=Member.userInfo_id and member_id=@member_id";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@member_id",memberId)
            };
            return SqlHelper.GetTable(sql, parameters);
        }
    }
}
