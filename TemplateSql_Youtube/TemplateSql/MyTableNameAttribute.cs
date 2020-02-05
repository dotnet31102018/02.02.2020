using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateSql
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MyTableNameAttribute : Attribute
    {
        public string TableName { get; set; }
        public MyTableNameAttribute(string tableName) { this.TableName = tableName; }
    }
}
