using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
using System.Data;

namespace IDAL
{
    public interface IDivisionService
    {
        /// <summary>
        /// 插入版块记录
        /// </summary>
        /// <param name="division">Division实体类</param>
        /// <returns></returns>
        int Insert(Division division);
        /// <summary>
        /// 更新版块信息
        /// </summary>
        /// <param name="division">Division实体类</param>
        /// <returns></returns>
        int Update(Division division);
        /// <summary>
        /// 删除版块
        /// </summary>
        /// <param name="divisionId">版块编号</param>
        /// <returns></returns>
        int Delete(string divisionId);
        /// <summary>
        /// 根据版块编号查找版块数量
        /// </summary>
        /// <param name="divisionId">版块编号</param>
        /// <returns></returns>
        int SelectNum(string divisionId);
        /// <summary>
        /// 查询所有版块信息
        /// </summary>
        /// <returns></returns>
        DataTable Select();
        /// <summary>
        /// 查找所有版块编号
        /// </summary>
        /// <returns></returns>
        DataTable SelectId();
    }
}
