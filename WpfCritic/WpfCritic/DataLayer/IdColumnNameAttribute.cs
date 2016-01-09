using System;

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
