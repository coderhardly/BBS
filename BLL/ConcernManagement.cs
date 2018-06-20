using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IDAL;
using Model;
using System.Data;

namespace BLL
{
    public class ConcernManagement
    {
        static IConcernService ICS;
        static ConcernManagement()
        {
            IServiceFactory isf = new ServiceFactory();
            ICS = isf.createIConcernService();
        }
        static bool ifconcern(string concernMember, string concernTo)
        {
            if (ICS.SelectNum(concernMember, concernTo) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 添加关注
        /// </summary>
        /// <param name="ConcernId"></param>
        /// <returns>"已关注" "关注成功" "关注失败"</returns>
        public static string AddConcern(Concern con)
        {
            if (con.IsError)
            {
                return "参数格式错误";
            }
            if (ifconcern(con.ConcernMember,con.ConcernTo))
            {
                return "您之前已关注该会员，无法重复关注";
            }
            if (ICS.insertConcern(con) > 0)
            {
                return "关注成功";
            }
            else
            {
                return "关注失败";
            }
        }
        /// <summary>
        /// 取消关注
        /// </summary>
        /// <param name="concernID"></param>
        /// <returns>"未关注" "取消关注成功" "取消关注失败"</returns>
        public static string UnConcern(string concernMember, string concernTo)
        {
            Concern concern = new Concern()
            {
                ConcernMember = concernMember,
                ConcernTo = concernTo
            };
            if (concern.IsError)
            {
                return concern.GetErrorMsg();
            }
            if (!ifconcern(concernMember, concernTo))
            {
                return "您还未关注该会员";
            }
            if (ICS.delete(concernMember, concernTo) > 0)
            {
                return "取消关注成功";
            }
            else
            {
                return "取消关注失败";
            }
        }
        /// <summary>
        /// 生成未使用的编号
        /// </summary>
        /// <returns></returns>
        public static string CreatConcernId()
        {
            return OtherMethod.CreateId(13, ICS.select());
        }

        /// <summary>
        /// 查询我关注的会员的编号、头像和用户名
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public static DataTable SelectMember(string memberId)
        {
            return ICS.SelectMember(memberId);
        }
    }
}
