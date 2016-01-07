using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCritic.DataLayer
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class IdColumnNameAttribute : Attribute
    {
        public string Name;
        public IdColumnNameAttribute(string name)
        {
            Name = name;
        }
    }
}
