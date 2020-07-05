using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;

namespace AutoSort.NetCore
{
    public static class QueryableExtension
    {
        public static IOrderedQueryable OrderBy<TSource>(this IQueryable<TSource> source, string ordering = null, params object[] args)
            where TSource : class
        {
            if (string.IsNullOrEmpty(ordering))
            {
                source = OrderByAttributes(source);
            }
            else
            {
                source = DynamicQueryableExtensions.OrderBy(source, ordering, args);
            }

            return (IOrderedQueryable)source;
        }

        private static IQueryable<TSource> OrderByAttributes<TSource>(IQueryable<TSource> source)
            where TSource : class
        {
            var sortProperty = typeof(TSource)
                            .GetProperties()
                            .Where(p => p.GetCustomAttribute(typeof(SortAttribute)) != null)
                            .Select(p => new
                            {
                                PropertyName = p.Name,
                                SortAttribute = (SortAttribute)p.GetCustomAttribute(typeof(SortAttribute))
                            })
                            .OrderBy(p => p.SortAttribute.Order)
                            .Select(p => $"{p.PropertyName} {p.SortAttribute.Direction}");
            return DynamicQueryableExtensions.OrderBy(source, string.Join(",", sortProperty));
        }
    }
}