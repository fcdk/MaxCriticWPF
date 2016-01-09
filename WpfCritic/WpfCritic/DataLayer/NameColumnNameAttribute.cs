using System;

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
