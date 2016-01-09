using System;

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
