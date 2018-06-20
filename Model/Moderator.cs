using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Moderator : BaseModel
    {
        private string moderatorId;
        private string divisionId;
        private string memberId;
        public string ModeratorId//版主编号
        {
            get { return moderatorId; }
            set
            {
                if (value.Length == 3)
                {
                    moderatorId = value;
                }
                else
                {
                    IsError = true;
                }
            }
        }
        public string DivisionId//版块编号
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
        public string MemberId//会员账号
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
    }
}
