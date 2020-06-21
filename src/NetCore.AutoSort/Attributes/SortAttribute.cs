using NetCore.AutoSort.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace NetCore.AutoSort.Attributes
{
    [AttributeUsage(AttributeTargets.Property|AttributeTargets.Class)]
    public class SortAttribute : Attribute
    {
        public string PropertyName { get; private set; }
        public SortDirection Direction { get; private set; }
        public SortAttribute()
        {
        }

        public SortAttribute(string propertyName, SortDirection direction = SortDirection.Ascending)
        {
            PropertyName = propertyName;
            Direction = direction;
        }
    }
}
