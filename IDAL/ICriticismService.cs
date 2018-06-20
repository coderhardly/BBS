using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
using System.Data;

namespace IDAL
{
    public interface ICriticismService
    {
        /// <summary>
        /// 查询所有评论
        /// </summary>
        /// <returns></returns>
        DataTable Select();
        /// <summary>
        /// 根据编号查询评论
        /// </summary>
        /// <param name="criticismId">评论编号</param>
        /// <returns></returns>
        DataTable Select(string criticismId);
        /// <summary>
        /// 根据主题查询评论（新）
        /// </summary>
        /// <param name="themeId">主题编号</param>
        /// <returns></returns>
        DataTable SelectByThemeId(string themeId);
        /// <summary>
        /// 根据会员查询评论
        /// </summary>
        /// <param name="memberId">会员编号</param>
        /// <returns></returns>
        DataTable SeleteByMember(string memberId);
        /// <summary>
        /// 查询所有已存在编号
        /// </summary>
        /// <returns></returns>
        DataTable SelectId();
        /// <summary>
        /// 插入评论(connected_criticism为空)
        /// </summary>
        /// <param name="criticism">Criticism实体类</param>
        /// <returns></returns>
        int Insert(Criticism criticism);
        /// <summary>
        /// 插入回复
        /// </summary>
        /// <param name="criticism">Criticism实体类</param>
        /// <returns></returns>
        int InsertReply(Criticism criticism);
        /// <summary>
        /// 查找编号的数量
        /// </summary>
        /// <param name="criticismId"></param>
        /// <returns></returns>
        int SelectNum(string criticismId);
        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="criticismId">评论编号</param>
        /// <returns></returns>
        int Delete(string criticismId);
        /// <summary>
        /// 查询评论和会员表
        /// </summary>
        /// <param name="themeId">主题编号</param>
        /// <returns></returns>
        DataTable SelectMC(string themeId);
        
        /// <summary>
        /// 查询二级回复相关信息
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        DataTable SelectCToC(string memberId);
    }
}
