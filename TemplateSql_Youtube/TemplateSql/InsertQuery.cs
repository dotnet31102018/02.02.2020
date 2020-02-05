using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateSql
{
    public class InsertQuery<T> : QueryExecutorBase<T> where T : new()
    {
        public InsertQuery(T item_to_add)
        {
            base.item = item_to_add;
        }

        private static string GetPropertyNames(Type type_of_record)
        {
            string insert_names = "";
            foreach (var oneProperty in type_of_record.GetProperties())
            {
                string columnName = oneProperty.Name;

                var customAttributes = (DontIncludeInsertAttribute[])oneProperty.GetCustomAttributes(typeof(DontIncludeInsertAttribute), true);
                if (customAttributes.Length > 0)
                {
                    continue;
                }

                insert_names += (insert_names != "" ? "," : "") + columnName;

            }

            return insert_names;
        }

        private static string GetPropertyValues(T item)
        {
            string values = "";
            Type type_of_record = typeof(T);
            foreach (var oneProperty in type_of_record.GetProperties())
            {
                string columnName = oneProperty.Name;

                var customAttributes = (DontIncludeInsertAttribute[])oneProperty.GetCustomAttributes(typeof(DontIncludeInsertAttribute), true);
                if (customAttributes.Length > 0)
                {
                    continue;
                }

                values += (values != "" ? "," : "") +
                          (oneProperty.PropertyType == typeof(string) ? "'" : "") +
                          oneProperty.GetValue(item) +
                          (oneProperty.PropertyType == typeof(string) ? "'" : "");

            }

            return values;
        }

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

            string insert_names = GetPropertyNames(type_of_record);

            string values = GetPropertyValues(item);

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"INSERT INTO {tableName} ({insert_names}) VALUES ({values})";

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            return null;
        }
    }
}