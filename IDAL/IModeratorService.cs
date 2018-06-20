using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;
using System.Data;

namespace IDAL
{
    public interface IModeratorService
    {
        /// <summary>
        /// 插入版主信息
        /// </summary>
        /// <param name="moderator">Moderator实体类</param>
        /// <returns></returns>
        int Insert(Moderator moderator);
        /// <summary>
        /// 根据会员编号和版块编号删除版主
        /// </summary>
        /// <param name="moderator"></param>
        /// <returns></returns>
        int Delete(string memberId, string divisionId);
        /// <summary>
        /// 根据版主编号删除版主
        /// </summary>
        /// <param name="moderatorId">版主编号</param>
        /// <returns></returns>
        int Delete(string moderatorId);
        /// <summary>
        /// 根据版块编号查询版主的用户名（联合查询）
        /// </summary>
        /// <param name="divisionId">版块编号</param>
        /// <returns>版主的账号和用户名</returns>
        DataTable Select(string divisionId);
        /// <summary>
        /// 查询版主信息：版主编号，版块名，会员用户名（联合查询）
        /// </summary>
        /// <returns></returns>
        DataTable Select();
        /// <summary>
        /// 根据版块编号查询版主信息：版主编号，版块名，会员用户名（联合查询）
        /// </summary>
        /// <returns></returns>
        DataTable SelectByDivisionId(string divisionId);
        /// <summary>
        /// 根据版主编号查询版主数量
        /// </summary>
        /// <param name="moderatorId">版主编号</param>
        /// <returns></returns>
        int SelectNum(string moderatorId);
        /// <summary>
        /// 查找用户编号
        /// </summary>
        /// <returns></returns>
        DataTable SelectId();
        /// <summary>
        /// 查找会员账号外的其他信息
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        DataTable SelectOther(string memberId);
        /// <summary>
        /// 根据版块名称查询所有版主的用户名
        /// </summary>
        /// <param name="divisionName">版块编号</param>
        /// <returns></returns>
        DataTable SelectName(string divisionName);
    }
}
