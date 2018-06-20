using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 管理员
    /// </summary>
    public class Administrator : BaseModel
    {
       private string administratorId;//管理员
       private string memberId;//会员账号
       public string AdministratorId
       {
           get { return administratorId; }
           set
           {
               if (value.Length == 1)
               {
                   administratorId = value;
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
    }
}
