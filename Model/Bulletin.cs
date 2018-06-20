using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 公告栏
    /// </summary>
    public class Bulletin : BaseModel
    {
        private string bulletinId;//公告编号
        private string divisionId;//公告发布者
        public string BulletinId
        {
            get { return bulletinId; }
            set
            {
                if (value.Length == 5)
                {
                    bulletinId = value;
                }
                else
                {
                    IsError = true;
                }
            }
        }
        public string DivisionId
        {
            get { return divisionId; }
            set
            {
                if (value.Length == 2)
                {
                    divisionId = value;
                }
                else
                {
                    IsError = true;
                }
            }
        }
        public string Title { get; set; }//公告标题
        public string BulletinText { get; set; }//公告正文
        public DateTime CreatTime { get; set; }//发布时间
    }
}
