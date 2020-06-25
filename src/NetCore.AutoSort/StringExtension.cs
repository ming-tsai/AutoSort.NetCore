using System.Collections.Generic;
using System;
using System.Linq;
using System.Reflection;
using NetCore.AutoSort.Enums;

namespace NetCore.AutoSort
{
    internal static class StringExtension
    {
        internal static IEnumerable<SortableProperty> AsSortables(this string source, Type type)
        {
            var values = source.Split(',').Select(p => p.Trim());
            var properties = type.GetProperties();
            var result = new List<SortableProperty>();
            foreach (var value in values)
            {
                result.Add(value.AsSortable(properties));
            }

            return result;
        }

        internal static SortableProperty AsSortable(this string source, PropertyInfo[] properties)
        {
            SortableProperty sortable = null;

            if (GetAscending(source, properties) is SortableProperty asc)
            {
                sortable = asc;
            }
            else
            {
                if (GetDescending(source, properties) is SortableProperty desc)
                {
                    sortable = desc;
                }
            }

            if (sortable == null)
            {
                throw new InvalidOperationException("property no exits");
            }

            return sortable;
        }


        private static SortableProperty GetAscending(string value, PropertyInfo[] properties)
        {
            var patterns = new List<string>() { " ascending", "_asc", " asc" };
            return GetSortable(value, properties, patterns);
        }

        private static SortableProperty GetDescending(string value, PropertyInfo[] properties)
        {
            return GetSortable(value, properties, new List<string>() { " descending", "_desc", " desc" });
        }

        private static SortableProperty GetSortable(string value, PropertyInfo[] properties, IEnumerable<string> patterns)
        {
            SortableProperty result = null;
            foreach (var pattern in patterns)
            {
                var direction = pattern.ToLower().Contains("asc") ? SortDirection.Ascending : SortDirection.Descending;
                result = properties.Where(p =>
                        p.Name.Equals(value, StringComparison.InvariantCultureIgnoreCase)
                        || ($"{p.Name}{pattern}").Equals(value, StringComparison.InvariantCultureIgnoreCase))
                        .Select(p => new SortableProperty(p, direction)).FirstOrDefault();
                if (result != null)
                {
                    break;
                }
            }

            return result;
        }
    }
}