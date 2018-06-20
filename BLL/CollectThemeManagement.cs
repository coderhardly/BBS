using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IDAL;
using Model;
using System.Data;

namespace BLL
{
    public class CollectThemeManagement
    {
        static ICollectThemeService ICTS;
        static CollectThemeManagement()
        {
            IServiceFactory isf = new ServiceFactory();
            ICTS = isf.createICollectThemeService();
        }
        /// <summary>
        /// 查询主题是否已收藏
        /// </summary>
        /// <param name="collectId"></param>
        /// <returns></returns>
        static bool ifExist(string memberId, string themeId)
        {
            Model.CollectTheme ct = new CollectTheme()
            {
                MemberId = memberId,
                ThemeId = themeId
            };
            if (ct.IsError)
            {
                return false;
            }
            if (ICTS.SelectNum(memberId,themeId) > 0)
            {
                return true;//已收藏
            }
            else
            {
                return false;//未收藏
            }
        }
        /// <summary>
        /// 收藏主题
        /// </summary>
        /// <returns></returns>
        public static string CollectTheme(CollectTheme collect)
        {
            if (collect.IsError)
            {
                return collect.GetErrorMsg();
            }
            if (ifExist(collect.MemberId,collect.ThemeId))
            {
                return "收藏已存在";
            }
            if (ICTS.InsertTheme(collect) > 0)
            {
                return "收藏成功";
            }
            else
            {
                return "收藏失败";
            }
        }
        /// <summary>
        /// 删除收藏
        /// </summary>
        /// <param name="collect"></param>
        /// <returns>"未收藏" "删除收藏成功" "删除收藏失败"</returns>
        public static string UncollectTheme(string memberId, string themeId)
        {
            Model.CollectTheme ct = new CollectTheme()
            {
                MemberId = memberId,
                ThemeId = themeId
            };
            if (ct.IsError)
            {
                return ct.GetErrorMsg();
            }
            if (!ifExist(memberId, themeId))
            {
                return "您还未收藏该主题";
            }
            if (ICTS.Delete(memberId, themeId) > 0)
            {
                return "删除收藏成功";
            }
            else
            {
                return "删除收藏失败";
            }
        }
        /// <summary>
        /// 生成未使用的收藏编号
        /// </summary>
        /// <returns></returns>
        public static string CreatCollectId()
        {
            return OtherMethod.CreateId(12, ICTS.Select());
        }
    }
    
}
