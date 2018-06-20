using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
using System.Data;

namespace IDAL
{
    public interface ICollectThemeService
    {
        /// <summary>
        /// 添加收藏
        /// </summary>
        /// <param name="collect"></param>
        /// <returns></returns>
        int InsertTheme(CollectTheme collect);
        /// <summary>
        /// 取消收藏
        /// </summary>
        /// <param name="collect">主题编号</param>
        /// <returns></returns>
        int Delete(string collectId);
        /// <summary>
        /// 取消收藏
        /// </summary>
        /// <param name="memberId">会员账号</param>
        /// <param name="themeId">主题编号</param>
        /// <returns></returns>
        int Delete(string memberId, string themeId);
        /// <summary>
        /// 查询所有收藏编号
        /// </summary>
        /// <returns></returns>
        DataTable Select();
        /// <summary>
        /// 查询主题编号的数量
        /// </summary>
        /// <param name="collect"></param>
        /// <returns></returns>
        int SelectNum(string memberId, string themeId);
    }
}
