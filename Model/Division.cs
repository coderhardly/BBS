using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 版块
    /// </summary>
    public class Division : BaseModel
    {
        private string divisionId;//版块编号
        private string divisionPicture;//版块图片
        public string DivisionId
        {
            get { return divisionId; }
            set
            {
                if (value.Length==2)
                {
                    divisionId = value;
                }
                else
                {
                    IsError = true;
                }
            }
        }
        public string DivisionPicture
        {
            get { return divisionPicture; }
            set
            {
                if (value == "图片格式错误" || value == "未上传图片")
                {
                    IsError = true; 
                }
                else
                {
                    divisionPicture = value;
                }
            }
        }
        public string  DivisionName{ get; set; }//版块名称
    }
}
