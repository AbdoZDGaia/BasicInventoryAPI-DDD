using Inventory.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Domain.Specification
{
    public static class SpecificationExtensions
    {

        public static IQueryable<TSource> Where<TSource>(this IQueryable<TSource> query, ISpecification<TSource> spec)
            where TSource : class
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(query,
                    (current, include) => current.Include(include));

            return queryableResultWithIncludes
                .Where(spec.Criteria);
        }
    }
}
