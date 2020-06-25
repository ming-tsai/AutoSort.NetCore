using NetCore.AutoSort.Attributes;
using System.Reflection;

namespace NetCore.AutoSort
{
    public sealed class SortableProperty
    {
        public PropertyInfo Property { get; private set; }
        public SortAttribute Sort { get; private set; }
        public SortableProperty(PropertyInfo property, SortAttribute sort)
        {
            Property = property;
            Sort = sort;
        }
    }
}
