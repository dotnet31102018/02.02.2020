using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateSql
{
    public class SelectQuery<T> : QueryExecutorBase<T> where T : new()
    {
        protected override List<T> ExecuteQuery() 
        {

            Type type_of_record = typeof(T);
            string tableName = "";

            var customAttributes = (MyTableNameAttribute[])type_of_record.GetCustomAttributes(typeof(MyTableNameAttribute), true);
            if (customAttributes.Length > 0)
            {
                tableName = customAttributes[0].TableName;
            }
            else
                throw new ArgumentException($"Poco {type_of_record.FullName} does not contain MyTableNameAttribute");

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"SELECT * FROM {tableName}";

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            List<T> list = new List<T>();
            while (reader.Read() == true)
            {
                T read_item = new T();
                foreach(var prop in type_of_record.GetProperties())
                {
                    prop.SetValue(read_item, reader[prop.Name]);
                }

                list.Add(read_item);
            }

            return list;
        }
    }
}
