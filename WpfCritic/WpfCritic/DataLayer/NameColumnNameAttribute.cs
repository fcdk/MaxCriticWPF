using System;
using WpfCritic.Core;

namespace WpfCritic.DataLayer
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    class NameColumnNameAttribute : Attribute
    {
        public string Name;
        public NameColumnNameAttribute(string name)
        {
            Name = name;

            Logger.Info("NameColumnNameAttribute.NameColumnNameAttribute", "Створено екземпляр атрибута NameColumnNameAttribute.");
        }
    }
}
