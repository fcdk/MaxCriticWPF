using System;
using WpfCritic.Core;

namespace WpfCritic.DataLayer
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class IdColumnNameAttribute : Attribute
    {
        public string Name;
        public IdColumnNameAttribute(string name)
        {
            Name = name;

            Logger.Info("IdColumnNameAttribute.IdColumnNameAttribute", "Створено екземпляр атрибута IdColumnNameAttribute.");
        }
    }
}
