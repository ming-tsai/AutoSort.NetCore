using NetCore.AutoSort.Attributes;
using NetCore.AutoSort.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace NetCore.AutoSort
{
    public sealed class SortableProperty
    {
        public PropertyInfo Property { get; private set; }
        public int Order { get; set; }
        public SortDirection Direction { get; private set; }

        public SortableProperty(
            [Range(0, int.MaxValue)] int order, PropertyInfo property, SortDirection direction)
        {
            if (order < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(order));
            }

            Order = order;
            Property = property;
            Direction = direction;
        }

        public SortableProperty(PropertyInfo property, SortAttribute sort)
        {
            if (sort == null)
            {
                throw new ArgumentNullException(nameof(sort));
            }

            Property = property;
            Order = sort.Order;
            Direction = sort.Direction;
        }
    }
}
