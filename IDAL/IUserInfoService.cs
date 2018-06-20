using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
using System.Data;

namespace IDAL
{
    public interface IUserInfoService
    {
        /// <summary>
        /// 查询所有记录
        /// </summary>
        /// <returns>返回DataTable对象</returns>
        DataTable Select();
        /// <summary>
        /// 根据编号查询Member
        /// </summary>
        /// <param name="userInfo_id"></param>
        /// <returns>返回DataTable对象</returns>
        DataTable Select(string userInfo_id);
        /// <summary>
        /// 向UserInfo表中插入数据
        /// </summary>
        /// <param name="member">UserInfo</param>
        /// <returns>受影响的行数</returns>
        int Insert(UserInfo userInfo);
        /// <summary>
        /// 根据userInfo_id查询记录数量
        /// </summary>
        /// <param name="userInfoId"></param>
        /// <returns></returns>
        int SelectNum(string userInfoId);
        /// <summary>
        /// 由用户编号删除用户记录
        /// </summary>
        /// <param name="userInfoId">用户编号</param>
        /// <returns
        int Delete(string userInfoId);
        /// <summary>
        /// 修改用户个人信息
        /// </summary>
        /// <param name="userInfo">会员Member</param>
        /// <returns>受影响的行数</returns>
        int Update(UserInfo userInfo);
        /// <summary>
        /// 查找用户编号
        /// </summary>
        /// <returns></returns>
        DataTable SelectId();
        /// <summary>
        /// 根据会员编号查询用户信息
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns>返回DataTable对象</returns>
        DataTable SelectInfo(string memberId);
    }
}
