using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateSql
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DontIncludeInsertAttribute : Attribute
    {
    }
}
