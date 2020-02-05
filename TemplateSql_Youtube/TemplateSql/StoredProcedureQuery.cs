using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateSql
{
    public class StoredProcedureSelectQuery<T> : QueryExecutorBase<T> where T : new()
    {

        protected string storedProcedureName;
        protected Dictionary<string, object> storedProcedureParams;

        public StoredProcedureSelectQuery(string storedProcedureName, Dictionary<string, object> storedProcedureParams)
        {
            this.storedProcedureName = storedProcedureName;
            this.storedProcedureParams = storedProcedureParams;
        }

        protected override void CreateDbConnection()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["employeedb"].ConnectionString);
            cmd = new SqlCommand(storedProcedureName, conn);

            foreach (var pair in storedProcedureParams)
            {
                cmd.Parameters.Add(new SqlParameter($"@{pair.Key}", pair.Value));
            }
        }

        protected override void OpenDbConnection()
        {
            cmd.Connection.Open();
            cmd.CommandType = CommandType.StoredProcedure;
        }

        protected override List<T> ExecuteQuery()
        {
            Type type_of_record = typeof(T);


            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            List<T> list = new List<T>();
            while (reader.Read() == true)
            {
                T read_item = new T();
                foreach (var prop in type_of_record.GetProperties())
                {
                    prop.SetValue(read_item, reader[prop.Name]);
                }

                list.Add(read_item);
            }

            return list;
        }
    }
}
