using Microsoft.EntityFrameworkCore;
using NgGlobal.DatabaseModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NgGlobal.CoreServices.Extensions
{
    public static class EntityToolsExtensions
    {
        public static IQueryable<T> IncludeAll<T>(this IQueryable<T> queryable, List<Expression<Func<T, object>>> includes) where T : BaseEntity
        {
            foreach (var include in includes)
            {
                    queryable = queryable.Include(include);
            }


            return queryable;
        }

        public static IQueryable<T> IncludeAll<T>(this IQueryable<T> queryable, List<string> includes) where T : BaseEntity
        {
            foreach (var include in includes)
            {
                queryable = queryable.Include(include);
            }


            return queryable;
        }
    }
}
