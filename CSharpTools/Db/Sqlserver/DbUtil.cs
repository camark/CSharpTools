using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTools.Db.Sqlserver
{
    class DbUtil
    {
        public static SqlConnection getCon(string m_host, string m_db, string m_user, string m_pass)
        {                      
            return new SqlConnection(@"Data Source=" + m_host + @";Initial Catalog=" + m_db + @";User ID=" + m_user + @";Password=" + m_pass);
        }
    }
}
