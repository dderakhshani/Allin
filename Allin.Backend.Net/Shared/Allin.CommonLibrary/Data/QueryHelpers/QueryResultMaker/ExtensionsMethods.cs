using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Allin.Common.Data.QueryHelpers;
using Microsoft.EntityFrameworkCore;

namespace Allin.Common.Data
{
    public static class QueryResultMakerExtensionMethods
    {

        public static PagedList<TSource> ToPagedList<TSource>(
            this IQueryable<TSource> query,
            QueryParamModel queryParam)
        {
            if (query == null)
            {
                throw new Exception("Query can't be null.");
            }

            query = query.WhereQueryMaker(queryParam.Conditions);

            var result = query
            .OrderByMultipleColumns(queryParam.OrderByProperties)
            .Paginate(queryParam.PagingProperties)
            .ToList()
            //.SetCalculateFieldsRequirements(queryParam.ColumnsNamesToUse)
            ;


            int totalCount;
            if (queryParam.PagingProperties == default)
            {
                totalCount = result.Count();
            }
            else
            {
                totalCount = query.Count();
            }

            var pageData = new PagedList<TSource>
            {
                Data = result,
                TotalCount = totalCount
            };

            return pageData;
        }


        public static async Task<PagedList<TSource>> ToPagedListAsync<TSource>(
            this IQueryable<TSource> query,
            QueryParamModel queryParam)
        {
            if (query == null)
            {
                throw new Exception("Query can't be null.");
            }

            query = query.WhereQueryMaker(queryParam.Conditions);

            var result = await query
            .OrderByMultipleColumns(queryParam.OrderByProperties)
            .Paginate(queryParam.PagingProperties)
            .ToListAsync()
            //.SetCalculateFieldsRequirements(queryParam.ColumnsNamesToUse)
            ;


            int totalCount;
            if (queryParam.PagingProperties == default)
            {
                totalCount = result.Count();
            }
            else
            {
                totalCount = await query.CountAsync();
            }

            var pageData = new PagedList<TSource>
            {
                Data = result,
                TotalCount = totalCount
            };

            return pageData;
        }
        public static IEnumerable<T> TopologicalSort<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> dependencies, bool throwOnCycle = true)
        {
            var sorted = new List<T>();
            var visited = new HashSet<T>();

            foreach (var item in source)
                Visit(item, visited, sorted, dependencies, throwOnCycle);

            return sorted;
        }

        private static void Visit<T>(T item, HashSet<T> visited, List<T> sorted, Func<T, IEnumerable<T>> dependencies, bool throwOnCycle)
        {
            if (!visited.Contains(item))
            {
                visited.Add(item);

                foreach (var dep in dependencies(item))
                    Visit(dep, visited, sorted, dependencies, throwOnCycle);

                sorted.Add(item);
            }
            else
            {
                if (throwOnCycle && !sorted.Contains(item))
                    throw new Exception("Cyclic dependency found");
            }
        }
    }



}