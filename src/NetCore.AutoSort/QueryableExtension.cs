using NetCore.AutoSort.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace NetCore.AutoSort
{
    public static class QueryableExtension
    {
        public static IQueryable<T> ApplySort<T>(this IQueryable<T> source, string sortBy = "")
            where T : class
        {
            if (string.IsNullOrEmpty(sortBy))
            {
                source = ApplyDefault(source);
            }
            else
            {
                source = ApplyString<T>(source, sortBy);
            }

            return source;
        }

        private static IQueryable<T> ApplyDefault<T>(IQueryable<T> source) where T : class
        {
            var sortables = typeof(T)
                            .GetProperties()
                            .Where(p => p.GetCustomAttribute(typeof(SortAttribute)) != null)
                            .Select(p => new SortableProperty(p,
                                (SortAttribute)p.GetCustomAttribute(typeof(SortAttribute))))
                            .OrderBy(p => p.Sort.Order)
                            .AsEnumerable();
            if (sortables.Any())
            {
                source = ApplyOrderBy(source, sortables);
            }

            return source;
        }

        private static IQueryable<T> ApplyString<T>(IQueryable<T> source, string sortBy) where T : class
        {
            throw new NotImplementedException();
        }

        private static IQueryable<T> ApplyOrderBy<T>(IQueryable<T> source, IEnumerable<SortableProperty> sortables)
            where T : class
        {
            var query = source.AsQueryable();
            string methodAsc = "OrderBy";
            string methodDesc = "OrderByDescending";
            var expression = query.Expression;
            foreach (var sortable in sortables)
            {
                var method = sortable.Sort.Direction == Enums.SortDirection.Ascending ?
                                methodAsc : methodDesc;
                expression = GetExpression<T>(expression, sortable.Property, method);

                methodAsc = "ThenBy";
                methodDesc = "ThenByDescending";
            }
            return CreateQueryBy(query, expression);
        }

        private static Expression GetExpression<T>(Expression expression, PropertyInfo property, string method)
            where T : class
        {
            var type = typeof(T);
            var parameter = Expression.Parameter(type, property.Name);
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);

            return Expression.Call(
                        typeof(Queryable),
                        method,
                        new Type[] { type, property.PropertyType },
                        expression,
                        Expression.Quote(orderByExp)
                    );
        }

        private static IQueryable<T> CreateQueryBy<T>(IQueryable<T> result, Expression expression)
            where T : class
        {
            return result.Provider.CreateQuery<T>(expression);
        }
    }
}
