using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Concern : BaseModel
    {
        private string concernId;//关注号
        private string  concernMember;//关注者
        private string concernTo;//被关注者
        public string ConcernId
        {
            get { return concernId; }
            set
            {
                if (value.Length == 13)
                {
                    concernId = value;
                }
                else
                {
                    IsError = true;
                }
            }
        }
        public string ConcernMember
        {
            get { return concernMember; }
            set
            {
                if (value.Length == 10)
                {
                    concernMember = value;
                }
                else
                {
                    IsError = true;
                }
            }
        }
        public string ConcernTo
        {
            get { return concernTo; }
            set
            {
                if (value.Length == 10)
                {
                    concernTo= value;
                }
                else
                {
                    IsError = true;
                }
            }
        }
    }
}
