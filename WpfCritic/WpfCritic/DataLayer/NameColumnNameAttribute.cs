using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCritic.DataLayer
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    class NameColumnNameAttribute : Attribute
    {
        public string Name;
        public NameColumnNameAttribute(string name)
        {
            Name = name;
        }
    }
}
