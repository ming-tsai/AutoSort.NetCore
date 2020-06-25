using NetCore.AutoSort.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace NetCore.AutoSort.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
    public class SortAttribute : Attribute
    {
        public int Order { get; private set; }
        public SortDirection Direction { get; private set; }

        public SortAttribute([Range(0, int.MaxValue)] int order = 0,
            SortDirection direction = SortDirection.Ascending)
        {
            if (order < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(order));
            }

            Order = order;
            Direction = direction;
        }
    }
}
