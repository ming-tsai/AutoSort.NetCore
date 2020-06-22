using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using NetCore.AutoSort.Attributes;

namespace NetCore.AutoSort
{
    public static class Extension
    {
        public static IQueryable<T> ApplySort<T>(this IQueryable<T> query, string sortBy = "")
            where T : class
        {
            if (string.IsNullOrEmpty(sortBy))
            {
                query = ApplyDefault(query);
            }

            return query;
        }

        private static IQueryable<T> ApplyDefault<T>(this IQueryable<T> query)
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
                query = ApplyOrderBy(query, sortables);
            }

            return query;
        }

        private static IQueryable<T> ApplyOrderBy<T>(IQueryable<T> query, IEnumerable<SortableProperty> sortables)
        {
            var result = query.AsQueryable();
            string methodAsc = "OrderBy";
            string methodDesc = "OrderByDescending";
            var queryExpression = result.Expression;
            foreach (var sortable in sortables)
            {
                var sortExpression = GetLambda<T>(sortable.Property.Name);
                var method = sortable.Sort.Direction == Enums.SortDirection.Ascending ?
                     methodAsc : methodDesc;
                var type = typeof(T);
                var property = type.GetProperty(sortable.Property.Name);
                var parameter = Expression.Parameter(type, sortable.Property.Name);
                var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                var orderByExp = Expression.Lambda(propertyAccess, parameter);
                queryExpression = Expression.Call(typeof(Queryable), method, new Type[] { type, property.PropertyType }, queryExpression
                        , Expression.Quote(orderByExp));
                
                methodAsc = "ThenBy";
                methodDesc = "ThenByDescending";
            }

            return result.Provider.CreateQuery<T>(queryExpression);
        }

        private static Expression<Func<T, object>> GetLambda<T>(string propertyName)
        {
            var parameter = Expression.Parameter(typeof(T));
            var property = Expression.Property(parameter, propertyName);
            var converted = Expression.Convert(property, typeof(object));
            return Expression.Lambda<Func<T, object>>(converted, parameter);
        }
    }
}
