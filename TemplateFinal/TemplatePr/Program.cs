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

        static void Main(string[] args)
        {

            Console.WriteLine("Select all employees: ");				
            List<Employee> employees = new QuerySelectAll().Run<Employee>();
            employees.ForEach(e => Console.WriteLine(e));

            Console.WriteLine();
            Console.WriteLine("Insert new employee: ");		
            Employee new_emp = new Employee() { fname = "Shimon", LastName = "Levi", Gender = "Male", Salary = 35000 };
            new QueryInsertItem().Run<Employee>(new_emp);

  	    // CREATE PROCEDURE SELECT_EMPLOYEES @id int
	    // AS
	    // SELECT * FROM EMPLOYEES WHERE Id = @id
            Console.WriteLine();
            Console.WriteLine("Run stored procedure: ");
            List<Employee> employees_stored = new QueryStoredSelect("SELECT_EMPLOYEES",
                                                        new Dictionary<string, object>() { { "id", 2 } }).Run<Employee>();

            employees_stored.ForEach(e => Console.WriteLine(e));

        }
    }
}
