using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplatePr
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MyTableNameAttribute : Attribute
    {
        public string TableName { get; set; }
        public MyTableNameAttribute(string tableName) { this.TableName = tableName; }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class MyFieldNameAttribute : Attribute
    {
        public string ColumnName { get; set; }
    }

    //[MyTableNameAttribute] you can write with/without the attribute keyword
    [MyTableName("Employees")]
    public class Employee
    {
        public void foo()
        {

        }
        public Employee()
        {

        }
        public Employee(int id)
        {

        }
        public int Id { get; set; }

        [MyFieldName(ColumnName = "FirstName")]
        public string fname { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
