using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IDAL;
using Model;
using System.Data;

namespace BLL
{
    public class CriticismManagement
    {
        static ICriticismService ICS;
        static CriticismManagement(){
            IServiceFactory isf = new ServiceFactory();
            ICS = isf.createICriticismService();
        }
        /// <summary>
        /// 判断评论是否存在
        /// </summary>
        /// <param name="criticismId">评论编号</param>
        /// <returns></returns>
        static bool isExist(string criticismId)
        {
            if (ICS.SelectNum(criticismId) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="criticismId">评论编号</param>
        /// <returns></returns>
        public static string Delete(string criticismId)
        {
            Criticism cri = new Criticism()
            {
                CriticismId = criticismId
            };
            if (cri.IsError)
            {
                return cri.GetErrorMsg();
            }
            if (ICS.Delete(criticismId) == 0)
            {
                return "删除失败";
            }
            else
            {
                return "删除成功";
            }
        }
        /// <summary>
        /// 对主题评论
        /// </summary>
        /// <param name="criticism"></param>
        /// <returns></returns>
        public static string PublishCriticism(Criticism criticism)
        {
            if (criticism.IsError)
            {
                return criticism.GetErrorMsg();
            }
            if (isExist(criticism.CriticismId))
            {
                return "评论编号已存在，请重试";
            }
            if (ICS.Insert(criticism) == 1)
            {
                return "评论成功";
            }
            else
            {
                return "评论失败";
            }
        }
        /// <summary>
        /// 回复评论
        /// </summary>
        /// <param name="criticism"></param>
        /// <returns></returns>
        public static string ReplyCriticism(Criticism criticism)
        {
            if (criticism.IsError)
            {
                return criticism.GetErrorMsg();
            }
            if (isExist(criticism.CriticismId))
            {
                return "评论编号已存在，请重试";
            }
            if (ICS.InsertReply(criticism) == 1)
            {
                return "评论成功";
            }
            else
            {
                return "评论失败";
            }
        }
        /// <summary>
        /// 生成评论编号
        /// </summary>
        /// <returns></returns>
        public static string CreateCriticismId()
        {
            return OtherMethod.CreateId((int)15, ICS.SelectId());
        }
        /// <summary>
        /// 查询所有评论
        /// </summary>
        /// <returns></returns>
        public static DataTable ShowAll()
        {
            return ICS.Select();
        }
        /// <summary>
        /// 根据编号查询评论
        /// </summary>
        /// <param name="criticismId">评论编号</param>
        /// <returns></returns>
        public static DataTable SelectByCriticismId(string criticismId)
        {
            return ICS.Select(criticismId);
        }
        /// <summary>
        /// 根据主题查询评论（新）
        /// </summary>
        /// <param name="themeId">主题编号</param>
        /// <returns></returns>
        public static DataTable SelectByThemeId(string themeId)
        {
            return ICS.SelectByThemeId(themeId);
        }
        /// <summary>
        /// 根据会员查询评论
        /// </summary>
        /// <param name="memberId">会员编号</param>
        /// <returns></returns>
        public static DataTable SeleteByMemberId(string memberId)
        {
            return ICS.SeleteByMember(memberId);
        }
        /// <summary>
        /// 同一主题下的所有评论级相关会员
        /// </summary>
        /// <param name="themeId">主题编号</param>
        /// <returns></returns>
        public static DataTable DisplayCriticism(string themeId)
        {
            return ICS.SelectMC(themeId);
        }
        /// <summary>
        /// 查询二级回复相关信息
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public static DataTable SelectCToC(string memberId)
        {
            return ICS.SelectCToC(memberId);
        }
    }
}
