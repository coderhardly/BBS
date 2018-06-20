using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
using System.Data;

namespace IDAL
{
    public interface IThemeService
    {
        /// <summary>
        /// 查询所有主题
        /// </summary>
        /// <returns></returns>
        DataTable Select();
        /// <summary>
        /// 根据主题编号查询主题
        /// </summary>
        /// <param name="themeId">主题编号</param>
        /// <returns></returns>
        DataTable Select(string themeId);
        /// <summary>
        /// 根据主题编号修改主题
        /// </summary>
        /// <param name="themeId">主题编号</param>
        /// <param name="mode">0：置顶 1：取消置顶 2：设为精华 3：取消精华</param>
        /// <returns> 受影响的行数</returns>
        int Update(string themeId, int mode);
        /// <summary>
        /// 修改点击量
        /// </summary>
        /// <param name="themeId">主题编号</param>
        /// <param name="clicks">点击量</param>
        /// <returns></returns>
        int UpdateClicks(string themeId);
        /// <summary>
        /// 插入主题
        /// </summary>
        /// <param name="theme"></param>
        /// <returns></returns>
        int Insert(Theme theme);
        /// <summary>
        /// 根据编号删除主题
        /// </summary>
        /// <param name="themeId"></param>
        /// <returns></returns>
        int Delete(string themeId);
        /// <summary>
        /// 查询主题编号
        /// </summary>
        /// <param name="themeId">主题编号</param>
        /// <returns></returns>
        DataTable SelectId();
        DataTable SelectBy(string orderBy, string divisionName);
        /// <summary>
        /// 查询编号是否存在
        /// </summary>
        /// <param name="themeId">主题编号</param>
        /// <returns></returns>
        int SelectNum(string themeId);
        /// <summary>
        /// 查看我的收藏
        /// </summary>
        /// <param name="memberId">会员账号</param>
        /// <returns></returns>
        DataTable SelectMyCollect(string memberId);
        /// <summary>
        /// 查看我的主题
        /// </summary>
        /// <param name="creator">会员账号</param>
        /// <returns></returns>
        DataTable SelectMyTheme(string creator);
        /// <summary>
        /// 根据关键词匹配主题标题或内容（模糊查询）
        /// </summary>
        /// <param name="key">关键词</param>
        /// <returns></returns>
        DataTable SelectByKey(string key);
        /// <summary>
        /// 根据主题编号查找主题（与Member表连接查询）
        /// </summary>
        /// <param name="themeId"></param>
        /// <returns></returns>
        DataTable SelectByThemeId(string themeId);
    }
}
