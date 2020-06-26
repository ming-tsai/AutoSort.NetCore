using NetCore.AutoSort.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NetCore.AutoSort
{
    internal static class StringExtension
    {
        static int counter = 0;
        internal static IEnumerable<SortableProperty> AsSortables<T>(this string source)
            where T : class
        {
            var values = source.Split(',').Select(p => p.Trim());
            var type = typeof(T);
            var properties = type.GetProperties();
            var result = new List<SortableProperty>();
            foreach (var value in values)
            {
                foreach (var property in properties)
                {
                    var added = value.AsSortable(property);
                    if (added != null)
                    {
                        result.Add(added);
                        break;
                    }
                }
            }

            return result;
        }

        private static SortableProperty AsSortable(this string source, PropertyInfo property)
        {
            var sortable = GetAsync(source, property);
            if (sortable == null)
            {
                sortable = GetDesc(source, property);
            }
            return sortable;
        }

        private static SortableProperty GetAsync(string source, PropertyInfo property)
        {
            SortableProperty result = null;
            if (source.Equals(property.Name, StringComparison.InvariantCultureIgnoreCase) ||
                source.Equals($"{property.Name} asc", StringComparison.InvariantCultureIgnoreCase) ||
                source.Equals($"{property.Name}_asc", StringComparison.InvariantCultureIgnoreCase) ||
                source.Equals($"{property.Name} ascending", StringComparison.InvariantCultureIgnoreCase))
            {
                result = new SortableProperty(counter, property, SortDirection.Ascending);
                counter++;
            }
            return result;
        }

        private static SortableProperty GetDesc(string source, PropertyInfo property)
        {
            SortableProperty result = null;
            if (source.Equals($"{property.Name} desc", StringComparison.InvariantCultureIgnoreCase) ||
                source.Equals($"{property.Name}_desc", StringComparison.InvariantCultureIgnoreCase) ||
                source.Equals($"{property.Name} descending", StringComparison.InvariantCultureIgnoreCase))
            {
                result = new SortableProperty(counter, property, SortDirection.Descending);
                counter++;
            }
            return result;
        }
    }
}