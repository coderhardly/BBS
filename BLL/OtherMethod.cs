using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace BLL
{
    public class OtherMethod
    {
        /// <summary>
        /// 自动生成未使用过的编号
        /// </summary>
        /// <param name="figures">编号长度</param>
        /// <param name="dt">已存在的编号</param>
        /// <returns>合法的编号</returns>
        public static string CreateId(int figures,DataTable dt)
        {
            int t = figures;
            if (figures > 9)
            {
                t=9;
            }
            int max = (int)Math.Pow(10, t);
            Random random = new Random();
            string id = random.Next(0,max).ToString().PadLeft(figures, '0');
            dt.PrimaryKey = new DataColumn[] { dt.Columns[0] };
            //根据表的主键查找指定编号
            while (dt.Rows.Find(id) != null)
            {
                id = random.Next(0, max).ToString().PadLeft(figures, '0');
            }
            return id;
        }
    }
}
