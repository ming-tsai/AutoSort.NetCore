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
        public int Order { get; private set; }
        public SortDirection Direction { get; private set; }

        public SortAttribute(int order = 0, SortDirection direction = SortDirection.Ascending)
        {
            Order = order;
            Direction = direction;
        }
    }
}
