using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IDAL;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class BulletinManagement
    {
        static IBulletinService IBS;
        static BulletinManagement()
        {
            IServiceFactory isf = new ServiceFactory();
            IBS = isf.createIBulletin();
        }
        static bool ifExist(string bulId)
        {
            if (IBS.selectNum(bulId) >= 1)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
        /// <summary>
        /// 添加公告
        /// </summary>
        /// <param name="bul"></param>
        /// <returns></returns>
        public static string addBulletin(Bulletin bul)
        {
            if (bul.IsError)
            {
                return bul.GetErrorMsg();
            }
            if (ifExist(bul.BulletinId))
            {
                return "公告已存在";
            }
            if (IBS.insert(bul) == 1)
            {
                return "创建成功";

            }
            else
            {
                return "创建失败";
            }

        }
        /// <summary>
        /// 删除单个公告
        /// </summary>
        /// <param name="bul"></param>
        /// <returns></returns>
        public static string delBulletin(string bulId)
        {
            if (!ifExist(bulId))
            {
                return "公告不存在";

            }
            if (IBS.delete(bulId) > 0)
            {
                return "创建成功";

            }
            else
            {
                return "创建失败";
            }



        }
        /// <summary>
        /// 查看单个公告内容
        /// </summary>
        /// <returns></returns>
        public static DataTable selectBul()
        {
            return IBS.select();
        }
        public static string CreateBulId()
        {
            return OtherMethod.CreateId(5, IBS.select());
        }
        /// <summary>
        /// 查询版块公告
        /// </summary>
        /// <param name="bulId"></param>
        /// <returns></returns>
        public static string selectBulletin(string divisionName)
        {
            return IBS.selectContent(divisionName);
        }
    }

}