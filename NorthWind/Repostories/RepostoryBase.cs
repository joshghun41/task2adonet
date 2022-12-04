using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Repostories
{
    public abstract class RepostoryBase
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
        protected static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
