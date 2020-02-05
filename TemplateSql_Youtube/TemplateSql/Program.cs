using Newtonsoft.Json;
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
    class Program
    {

        static void Main(string[] args)
        {
            List<Employee> result = new SelectQuery<Employee>().Run();
            result.ForEach(e => Console.WriteLine(e));

            Employee new_employee = new Employee()
            {
                FirstName = "Robin",
                LastName = "Hood",
                Gender = "Male",
                Salary = 100000
            };

            //new InsertQuery<Employee>(new_employee).Run();

            Console.WriteLine();
            Console.WriteLine("Stored procedure result:");
            // CREATE PROCEDURE SELECT_EMPLOYEES @id int
            // AS
            // SELECT * FROM EMPLOYEES WHERE Id = @id
            List<Employee> result2 = new StoredProcedureSelectQuery<Employee>("SELECT_EMPLOYEES", new Dictionary<string, object>()
            {
                { "id", 2 }
            }).Run();
            result2.ForEach(e => Console.WriteLine(e));
        }
    }
}
