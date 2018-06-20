using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Criticism : BaseModel
    {
        /// <summary>
        ///  评论
        /// </summary>
        private string criticismId;//评论编号
        private string memberId;//评论者编号
        private string themeId;//所属主题编号
        private string connectedCriticism;//关联内容
        public string CriticismId
        {
            get { return criticismId; }
            set
            {
                if (value.Length == 15)
                {
                    criticismId = value;
                }
                else
                {
                    IsError = true;
                }
            }
        }
        public string MemberId
        {
            get { return memberId; }
            set
            {
                if (value.Length == 10)
                {
                    memberId = value;
                }
                else
                {
                    IsError = true;
                }
            }
        }
        public string ThemeId
        {
            get { return themeId; }
            set
            {
                if (value.Length == 11)
                {
                    themeId = value;
                }
                else
                {
                    IsError = true;
                }
            }
        }
        public string ConnectedCriticism
        {
            get { return connectedCriticism; }
            set
            {
                if (value.Length == 15)
                {
                    connectedCriticism = value;
                }
                else
                {
                    IsError = true;
                }
            }
        }
        public string CriticismText { get; set; }//评论正文
        public DateTime PublishTime { get; set; }//评论时间
    }
}
