using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateSql
{
    public abstract class QueryExecutorBase<T> where T : new()
    {
        protected SqlCommand cmd;
        protected T item;

        protected virtual void CreateDbConnection()
        {
            cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["employeedb"].ConnectionString);
        }
        protected virtual void OpenDbConnection()
        {
            cmd.Connection.Open();
        }

        abstract protected List<T> ExecuteQuery();

        protected void CloseDbConnection()
        {
            cmd.Connection.Close();
        }
        public List<T> Run() 
        {
            CreateDbConnection();
            OpenDbConnection();
            List<T> result = ExecuteQuery();
            CloseDbConnection();

            return result;
        }

    }
}
