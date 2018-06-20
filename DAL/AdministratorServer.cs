using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IDAL;
using System.Data.SqlClient;

namespace DAL
{
    public class AdministratorServer:IAdministratorService
    {
        /// <summary>
        /// 根据会员编号查询管理员编号
        /// </summary>
        /// <param name="memberId">会员编号</param>
        /// <returns></returns>
        public object Select(string memberId)
        {
            string sql = "select admin_id from Administrator where member_id=@member_id";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@member_id",memberId) 
            };
            return SqlHelper.ExecuteScaler(sql, parameters);
        }
    }
}
