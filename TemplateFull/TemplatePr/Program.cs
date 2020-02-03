using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TemplatePr
{
    class Program
    {

        // old-way
        private static List<object> SelectAll(string tableName)
        {
            //Command and Data Reader
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["employeedb"].ConnectionString);
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"SELECT * FROM {tableName}";

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            List<Object> list = new List<object>();
            while (reader.Read() == true)
            {
                var e = new
                {
                    Id = reader["ID"],
                    firaName = reader["FIRSTNAME"]
                };
                list.Add(e);
            }

            cmd.Connection.Close();

            return list;
        }
        static void Main(string[] args)
        {
            //var result = SelectAll("Employees");
            //result.ForEach(e => Console.WriteLine(e));

            //List<Employee> employees = QueryExecutor.SelectAll<Employee>();
            //employees.ForEach(e => Console.WriteLine(e));

            List<Employee> employees = new QuerySelectAll().Run<Employee>();
            employees.ForEach(e => Console.WriteLine(e));

            Employee new_emp = new Employee() { fname = "Shimon", LastName = "Levi", Gender = "Male", Salary = 35000 };
            //new QueryInsertItem().Run<Employee>(new_emp);
        }
    }
}
