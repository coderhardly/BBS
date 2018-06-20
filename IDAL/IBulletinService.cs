using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using Model;

namespace IDAL
{
    public interface IBulletinService
    {
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="bul"></param>
        /// <returns></returns>
        int insert(Bulletin bul);
        /// <summary>
        ///删除
        /// </summary>
        /// <param name="bul"></param>
        /// <returns></returns>
        int delete(string bulId);
        /// <summary>
        /// 删除所有公告
        /// </summary>
        /// <returns></returns>
        int delete();
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="bul"></param>
        /// <returns></returns>
        DataTable select();
        /// <summary>
        /// 查询公告数量
        /// </summary>
        /// <param name="bul"></param>
        /// <returns></returns>
        int selectNum(string bulId);
        /// <summary>
        /// 根据版块名查询版块公告
        /// </summary>
        /// <param name="divisionName"></param>
        /// <returns></returns>
        string selectContent(string divisionName);
    }
}
