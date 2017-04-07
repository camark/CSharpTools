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
            //m_host = "10.10.10.62";
            //m_db = "bpm";
            //m_user = "sa";
            //m_pass = "china2015";
            return new SqlConnection(@"Data Source=" + m_host + @";Initial Catalog=" + m_db + @";User ID=" + m_user + @";Password=" + m_pass);
        }
    }
}
