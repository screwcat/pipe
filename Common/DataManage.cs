using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.Common
{
    public class DataManage
    {
        public Int32 DataBackup(string strSql)
        {
            return Maticsoft.DBUtility.DbHelperSQL.ExecuteSql(strSql);
        }
    }
}
