using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BaseModel
    {
        private bool isError=false;//判断数据装入是否出错
        public bool IsError
        {
            get { return isError; }
            set { isError = value; }
        }
        /// <summary>
        /// 获取错误原因
        /// </summary>
        /// <returns></returns>
        public string GetErrorMsg()
        {
            return "参数格式错误";
        }
    }
}
