using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;
using IDAL;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class BulletinServer:IBulletinService
    {    
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="bul"></param>
        /// <returns></returns>
        public  int insert(Bulletin bul)
        {
            string sql = "insert into Bulletin values(@bulletinId,@title,@bulletinText,@creatTime,@divisionId)";
            SqlParameter[] paramaters = new SqlParameter[]{
                new SqlParameter("@bulletinId",bul.BulletinId),
                new SqlParameter("@bulletinText",bul.BulletinText),
                new SqlParameter("@creatTime",bul.CreatTime),
                new SqlParameter("@divisionId",bul.DivisionId),
                new SqlParameter("@title",bul.Title)
            };
            return SqlHelper.ExecuteNonQuery(sql, paramaters);
        }
        /// <summary>
        ///删除单个公告
        /// </summary>
        /// <param name="bul"></param>
        /// <returns></returns>
        public  int delete(string  bulId)
        {
            string sql = "delete from Bulletin where bulletin_id=@bulletinId ";
            SqlParameter[] paramaters = new SqlParameter[]{
                new SqlParameter("@bulletinId",bulId),
              
            };
            return SqlHelper.ExecuteNonQuery(sql, paramaters);
        }
        /// <summary>
        /// 删除所有公告
        /// </summary>
        /// <returns></returns>
        public int delete()
        {
            string sql = "delete from Bulletin";
            return SqlHelper.ExecuteNonQuery(sql, null);
        }
        /// <summary>
        /// 查看公告所有内容
        /// </summary>
        /// <param name="bul"></param>
        /// <returns></returns>
        public  DataTable select()
        {
            string sql = "select * from Bulletin";
           
            return SqlHelper.GetTable(sql,null);
        }
       
        ///// <summary>
        // 查询公告数量
        // </summary>
        // <param name="bul"></param>
        // <returns></returns>
        public  int selectNum(string bulId)
        {
            string sql = "select count(*) from Bulletin where bulletin_id=@bulltinId";
            SqlParameter[] parameter = new SqlParameter[] { new SqlParameter("@bulltinId", bulId) };
            return (int)SqlHelper.ExecuteScaler(sql, parameter);
        }
        /// <summary>
        /// 根据版块名查询版块公告
        /// </summary>
        /// <param name="divisionName"></param>
        /// <returns></returns>
        public string selectContent(string divisionName)
        {
            string sql = "select bulletin_text from Bulletin,Division where division_Name=@divisionName and Bulletin.division_id=Division.division_id order by creat_time desc";
            SqlParameter[] parameter = new SqlParameter[] { new SqlParameter("@divisionName", divisionName) };
            return (string)SqlHelper.ExecuteScaler(sql, parameter);
        }
    }
}
