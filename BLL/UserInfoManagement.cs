using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IDAL;
using Model;
using System.Data;

namespace BLL
{
    public class UserInfoManagement
    {
        static IUserInfoService IUIS;
        static UserInfoManagement()
        {
            IServiceFactory isf = new ServiceFactory();
            IUIS = isf.createIUserInfoService();
        }

        /// <summary>
        /// 查询编号为userInfoId的用户是否存在
        /// </summary>
        /// <param name="userInfoId">用户编号</param>
        /// <returns>是否存在的布尔值</returns>
        static bool isExist(string userInfoId)
        {
            if (IUIS.SelectNum(userInfoId) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns>返回DataTable对象</returns>
        public static DataTable ShowAll()
        {
            return IUIS.Select();
        }
        /// <summary>
        /// 查询指定编号的用户信息
        /// </summary>
        /// <param name="userInfoId"></param>
        /// <returns></returns>
        public static DataTable SelectById(string userInfoId)
        {
            return IUIS.Select(userInfoId);
        }
        /// <summary>
        /// 向UserInfo表中添加用户
        /// </summary>
        /// <param name="userInfo">UserInfo实体类</param>
        /// <returns>返回是否添加成功的布尔值</returns>
        public static string AddUserInfo(UserInfo userInfo)
        {
            if (userInfo.IsError)
            {
                return userInfo.GetErrorMsg();
            }
            if (isExist(userInfo.UserInfoId))
            {
                return "用户已存在";
            }
            if (IUIS.Insert(userInfo) == 1)
            {
                return "添加成功";
            }
            else
            {
                return "添加失败";
            }
        }
        /// <summary>
        /// 删除指定编号的用户信息
        /// </summary>
        /// <param name="userInfoId">用户编号</param>
        /// <returns>执行结果的string字符串提示</returns>
        public static string DeleteUserInfo(string userInfoId)
        {
            UserInfo userInfo = new UserInfo()
            {
                UserInfoId = userInfoId
            };
            if (userInfo.IsError)
            {
                return userInfo.GetErrorMsg();
            }
            if (isExist(userInfoId) == false)
                return "用户不存在";
            if (IUIS.Delete(userInfoId) == 1)
            {
                return "用户删除成功";
            }
            else
            {
                return "用户删除失败";
            }
        }
        /// <summary>
        /// 修改用户个人信息
        /// </summary>
        /// <param name="userInfo">用户编号</param>
        /// <returns>"用户信息不存在" "修改成功" "修改失败"</returns>
        public static string UpdateUserInfo(UserInfo userInfo)
        {
            if (userInfo.IsError)
            {
                return userInfo.GetErrorMsg();
            }
            if (!isExist(userInfo.UserInfoId))
            {
                return "用户信息不存在";
            }
            if (IUIS.Update(userInfo) == 1)
            {
                return "修改成功";
            }
            else
            {
                return "修改失败";
            }
        }
        /// <summary>
        /// 自动生成用户编号
        /// </summary>
        /// <returns></returns>
        public static string CreateUserInfoId()
        {
            return OtherMethod.CreateId(9, IUIS.SelectId());
        }
        
        /// <summary>
        /// 根据会员编号查询用户信息
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns>返回DataTable对象</returns>
        public static DataTable SelectInfo(string memberId)
        {
            return IUIS.SelectInfo(memberId);
        }
    }
}
