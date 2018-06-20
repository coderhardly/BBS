using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IAdministratorService
    {
        /// <summary>
        /// 根据会员编号查询管理员编号
        /// </summary>
        /// <param name="memberId">会员编号</param>
        /// <returns></returns>
        object Select(string memberId);
    }
}
