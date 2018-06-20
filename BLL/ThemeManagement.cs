using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IDAL;
using Model;
using System.Data;

namespace BLL
{
    public class ThemeManagement
    {
        static IThemeService ITS;
        static ThemeManagement()
        {
            IServiceFactory isf = new ServiceFactory();
            ITS = isf.createIThemeService();
        }
        /// <summary>
        /// 置顶
        /// </summary>
        /// <param name="themeId"></param>
        /// <returns></returns>
        public static string SetTop(string themeId)
        {
            Theme theme = new Theme()
            {
                ThemeId = themeId
            };
            if (theme.IsError)
            {
                return theme.GetErrorMsg();
            }
            if (ITS.Update(themeId, 0) == 1)
            {
                return "置顶成功";
            }
            else
            {
                return "置顶失败";
            }
        }
        /// <summary>
        /// 查询主题编号是否存在
        /// </summary>
        /// <param name="themeId"></param>
        /// <returns></returns>
        static bool isExist(string themeId)
        {
            if (ITS.SelectNum(themeId) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 取消置顶
        /// </summary>
        /// <param name="themeId"></param>
        /// <returns></returns>
        public static string RevokeSetTop(string themeId)
        {
            Theme theme = new Theme()
            {
                ThemeId = themeId
            };
            if (theme.IsError)
            {
                return theme.GetErrorMsg();
            }
            if (ITS.Update(themeId, 1) == 1)
            {
                return "取消置顶成功";
            }
            else
            {
                return "取消置顶失败";
            }
        }
        /// <summary>
        /// 设置精华主题
        /// </summary>
        /// <param name="themeId"></param>
        /// <returns></returns>
        public static string SetEssence(string themeId)
        {
            Theme theme = new Theme()
            {
                ThemeId = themeId
            };
            if (theme.IsError)
            {
                return theme.GetErrorMsg();
            }
            if (ITS.Update(themeId,2) == 1)
            {
                return "设置精华成功";
            }
            else
            {
                return "设置精华失败";
            }
        }
        /// <summary>
        /// 取消精华主题
        /// </summary>
        /// <param name="themeId"></param>
        /// <returns></returns>
        public static string RevokeSetEssence(string themeId)
        {
            Theme theme = new Theme()
            {
                ThemeId = themeId
            };
            if (theme.IsError)
            {
                return theme.GetErrorMsg();
            }
            if (ITS.Update(themeId, 3) == 1)
            {
                return "取消精华成功";
            }
            else
            {
                return "该主题不是精华主题";
            }
        }
        /// <summary>
        /// 根据主题编号查询主题
        /// </summary>
        /// <param name="themeId">主题编号</param>
        /// <returns></returns>
        public static DataTable Select(string themeId)
        {
            return ITS.Select(themeId);
        }
        public static DataTable SelectByThemeId(string themeId)
        {
            return ITS.SelectByThemeId(themeId);
        }
        /// <summary>
        /// 查询所有主题
        /// </summary>
        /// <returns></returns>
        public static DataTable Select()
        {
            return ITS.Select();
        }
        /// <summary>
        /// 自动生成主题编号
        /// </summary>
        /// <returns></returns>
        public static string CreateThemeId()
        {
            return OtherMethod.CreateId(11, ITS.SelectId());
        }
        /// <summary>
        /// 根据编号删除主题
        /// </summary>
        /// <param name="themeId"></param>
        /// <returns></returns>
        public static string Delete(string themeId)
        {
            Theme theme = new Theme()
            {
                ThemeId = themeId
            };
            if (theme.IsError)
            {
                return theme.GetErrorMsg();
            }
            if (ITS.Delete(themeId) >0)
            {
                return "删除成功";
            }
            else
            {
                return "删除失败";
            }
        }
        /// <summary>
        /// 根据版块查询主题并按时间排序
        /// </summary>
        /// <returns></returns>
        public static DataTable SelectByTime(string divisionName)
        {
            return ITS.SelectBy("时间", divisionName);
        }
        /// <summary>
        /// 根据精华标记查询主题
        /// </summary>
        /// <returns></returns>
        public static DataTable SelectByEssence(string divisionName)
        {
            return ITS.SelectBy("精华", divisionName);
        }
        /// <summary>
        /// 创建主题
        /// </summary>
        /// <param name="theme"></param>
        /// <returns></returns>
        public static string CreateTheme(Theme theme)
        {
            if (theme.IsError)
            {
                return theme.GetErrorMsg();
            }
            if (isExist(theme.ThemeId))
            {
                return "主题编号已存在";
            }
            if (ITS.Insert(theme) == 1)
            {
                return "创建主题成功";
            }
            else
            {
                return "创建主题失败";
            }
        }
        /// <summary>
        /// 点击量+1
        /// </summary>
        /// <param name="themeId">主题编号</param>
        public static void Click(string themeId)
        {
            Theme theme = new Theme()
            {
                ThemeId = themeId
            };
            if (theme.IsError)
            {
                return;
            }
            ITS.UpdateClicks(themeId);
        }
        /// <summary>
        /// 查看我的收藏
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public static DataTable SelectMyCollect(string memberId)
        {
            return ITS.SelectMyCollect(memberId);
        }
        /// <summary>
        /// 查看我的主题
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public static DataTable SelectMyTheme(string memberId)
        {
            return ITS.SelectMyTheme(memberId);
        }
        /// <summary>
        /// 根据关键词匹配主题标题或内容（模糊查询）
        /// </summary>
        /// <param name="key">关键词</param>
        /// <returns></returns>
        public static DataTable SelectByKey(string key)
        {
            return ITS.SelectByKey(key);
        }
    }
}
