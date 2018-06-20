using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
using System.Data;

namespace IDAL
{
    public interface IConcernService
    {
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        int insertConcern(Concern con);
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        int delete(string concernMember, string concernTo);
        /// <summary>
        /// 查询所有已存在的关注编号
        /// </summary>
        /// <returns></returns>
        DataTable select();
        /// <summary>
        /// 查询关注关系是否存在
        /// </summary>
        /// <param name="concernMember">会员账号</param>
        /// <param name="themeId">主题编号</param>
        /// <returns></returns>
        int SelectNum(string concernMember, string themeId);
        /// <summary>
        /// 查询我关注的会员的编号、头像和用户名
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        DataTable SelectMember(string memberId);
    }
}
