using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IDAL;
using Model;
using System.Data;

namespace BLL
{
    public class DivisionManagement
    {
        static IDivisionService IDS;
        static DivisionManagement()
        {
            IServiceFactory isf = new ServiceFactory();
            IDS = isf.createIDivisionService();
        }
        /// <summary>
        /// 查询版块是否存在
        /// </summary>
        /// <param name="divisionId">版块编号</param>
        /// <returns></returns>
        static bool isExist(string divisionId)
        {
            if (IDS.SelectNum(divisionId) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 添加版块
        /// </summary>
        /// <param name="division">Division实体类</param>
        /// <returns>"版块已存在" "新建成功" "新建失败"</returns>
        public static string CreateDivision(Division division)
        {
            if (division.IsError)
            {
                return division.GetErrorMsg();
            }
            if (isExist(division.DivisionId))
            {
                return "版块已存在";
            }
            if (IDS.Insert(division) == 1)
            {
                return "新建成功";
            }
            else
            {
                return "新建失败";
            }
        }
        /// <summary>
        /// 删除版块
        /// </summary>
        /// <param name="divisionId">版块编号</param>
        /// <returns>"版块不存在" "删除成功" "删除失败"</returns>
        public static string DeleteDivision(string divisionId)
        {
            if (!isExist(divisionId))
            {
                return "版块不存在";
            }
            if (IDS.Delete(divisionId) == 1)
            {
                return "删除成功";
            }
            else
            {
                return "删除失败";
            }
        }
        /// <summary>
        /// 修改版块
        /// </summary>
        /// <param name="division">Division实体类</param>
        /// <returns></returns>
        public static string UpdateDivision(Division division)
        {
            if (division.IsError)
            {
                return division.GetErrorMsg();
            }
            if (!isExist(division.DivisionId))
            {
                return "版块不存在";
            }
            if (IDS.Update(division) == 1)
            {
                return "修改成功";
            }
            else
            {
                return "修改失败";
            }
        }
        /// <summary>
        /// 查询所有版块信息
        /// </summary>
        /// <returns></returns>
        public static DataTable ShowAll()
        {
            return IDS.Select();
        }
        /// <summary>
        /// 生成版块编号
        /// </summary>
        /// <returns></returns>
        public static string CreateDivisionId()
        {
            return OtherMethod.CreateId(2, IDS.SelectId());
        }
    }
}
