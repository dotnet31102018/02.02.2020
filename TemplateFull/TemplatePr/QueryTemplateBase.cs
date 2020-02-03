using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplatePr
{
    public abstract class QueryTemplateBase
    {
        protected SqlCommand Connect()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["employeedb"].ConnectionString);
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            return cmd;
        }
        abstract protected List<T> ExecuteQuery<T>(SqlCommand cmd, T item = default(T)) where T : new();
        protected void Close(SqlCommand cmd)
        {
            cmd.Connection.Close();
        }

        public List<T> Run<T>(T item = default(T)) where T : new()
        {
            SqlCommand cmd = Connect();
            List<T> result = ExecuteQuery<T>(cmd, item);
            Close(cmd);
            return result;
        }

    }
}
