using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IDAL;
using Model;

namespace BLL
{
    public class AdministratorManagement
    {
        static IAdministratorService IAS;
        static AdministratorManagement()
        {
            IServiceFactory isf = new ServiceFactory();
            IAS = isf.createIAdministrator();
        }
        /// <summary>
        /// 返回管理员编号或null
        /// </summary>
        /// <param name="memberId">会员编号</param>
        /// <returns></returns>
        public static string SelectId(string memberId)
        {
            return (string)IAS.Select(memberId);
        }
    }
}
