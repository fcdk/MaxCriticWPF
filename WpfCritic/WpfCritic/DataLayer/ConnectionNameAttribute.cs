using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCritic.DataLayer
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    class ConnectionNameAttribute : Attribute
    {
        public string Name;
        public ConnectionNameAttribute(string name)
        {
            Name = name;
        }
    }
}
