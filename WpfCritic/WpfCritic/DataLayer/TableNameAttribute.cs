﻿using System;

namespace WpfCritic.DataLayer
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class TableNameAttribute : Attribute
    {
        public string Name;
        public TableNameAttribute(string name)
        {
            Name = name;
        }
    }
}
