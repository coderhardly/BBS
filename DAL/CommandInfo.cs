using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// 执行事务操作时command对象需要的参数信息
    /// </summary>
    public class CommandInfo
    {
        public string CommandText { get; set; }
        public SqlParameter[] parameters { get; set; }
        public CommandInfo(string CommandText, params SqlParameter[] parameters)
        {
            this.CommandText = CommandText;
            this.parameters = parameters;
        }
    }
}
