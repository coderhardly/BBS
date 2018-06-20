using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IDAL;
using Model;
using System.Data;

namespace BLL
{
    public class ModeratorManagement
    {
        static IModeratorService IMS;
        static ModeratorManagement()
        {
            IServiceFactory isf = new ServiceFactory();
            IMS = isf.createIModerator();
        }
        /// <summary>
        /// 查询编号是否存在
        /// </summary>
        /// <param name="moderatorId">版主编号</param>
        /// <returns></returns>
        static bool isExist(string moderatorId)
        {
            if (IMS.SelectNum(moderatorId) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 设置版主
        /// </summary>
        /// <param name="moderator">Moderator实体类</param>
        /// <returns></returns>
        public static string SetModerator(Moderator moderator)
        {
            if (moderator.IsError)
            {
                return moderator.GetErrorMsg();
            }
            if (isExist(moderator.ModeratorId))
            {
                return "版主编号已存在";
            }
            if (MemberManagement.IsExist(moderator.MemberId))
            {
                return "该会员账号不存在";
            }
            if (IMS.Insert(moderator) == 1)
            {
                return "设置版主成功";
            }
            else
            {
                return "设置版主失败";
            }
        }
        /// <summary>
        /// 查询版块的版主的编号和用户名
        /// </summary>
        /// <param name="divisionId">版块编号</param>
        /// <returns></returns>
        public static DataTable Select(string divisionId)
        {
            return IMS.Select(divisionId);
        }
        /// <summary>
        /// 查询版主信息：版主编号，版块名，会员用户名
        /// </summary>
        /// <returns></returns>
        public static DataTable Select()
        {
            return IMS.Select();
        }
        /// <summary>
        /// 根据版块编号查询版主信息：版主编号，版块名，会员用户名（联合查询）
        /// </summary>
        /// <returns></returns>
        public static DataTable SelectByDivisionId(string divisionId)
        {
            return IMS.SelectByDivisionId(divisionId);
        }
        /// <summary>
        /// 撤销版主
        /// </summary>
        /// <param name="memberId">会员编号</param>
        /// <param name="divisionId">版块编号</param>
        /// <returns></returns>
        public static string RevokeModerator(string memberId, string divisionId)
        {
            Moderator moderator = new Moderator()
            {
                MemberId = memberId,
                DivisionId = divisionId
            };
            if (moderator.IsError)
            {
                return moderator.GetErrorMsg();
            }
            if (IMS.Delete(memberId, divisionId)>0)
            {
                return "撤销成功";
            }
            else
            {
                return "撤销失败";
            }
        }
        /// <summary>
        /// 撤销版主
        /// </summary>
        /// <param name="moderatorId">版主编号</param>
        /// <returns></returns>
        public static string RevokeModerator(string moderatorId)
        {
            Moderator moderator = new Moderator()
            {
                ModeratorId=moderatorId
            };
            if (moderator.IsError)
            {
                return moderator.GetErrorMsg();
            }
            if (IMS.Delete(moderatorId) > 0)
            {
                return "撤销成功";
            }
            else
            {
                return "撤销失败";
            }
        }
        /// <summary>
        /// 生成版主编号
        /// </summary>
        /// <returns></returns>
        public static string CreateModeratorId()
        {
            return OtherMethod.CreateId(3, IMS.SelectId());
        }
        /// <summary>
        /// 查找会员账号外的其他信息
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public static DataTable SelectOther(string memberId)
        {
            //Moderator moderator = new Moderator()
            //{
            //    MemberId = memberId
            //};
            //if (moderator.IsError)
            //{
            //    return null;
            //}
            return IMS.SelectOther(memberId);
        }
        /// <summary>
        /// 根据版块名称查询所有版主的用户名
        /// </summary>
        /// <param name="divisionName">版块编号</param>
        /// <returns></returns>
        public static DataTable SelectAllModerator(string divisionName)
        {
            return IMS.SelectName(divisionName);
        }
    }
}
