using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    ///  收藏主题
    /// </summary>
    public class CollectTheme : BaseModel
    {
       private string collectId;//收藏编号
       private string themeId;//主题编号
       private string memberId;//发布者
       public string CollectId
       {
           get { return collectId; }
           set
           {
               if (value.Length == 12)
               {
                   collectId = value;
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
       public string Remark { get; set; }//备注
    }
}
