using System.Collections.Generic;
using System.Linq;
using Core.Entites;
using Core.Specefication;
using Microsoft.EntityFrameworkCore;
using static Core.Enums.Enums;

namespace Infrastructure.Data
{
    public class SpeceficationEveluator<TEntity> where TEntity : BaseEntity
    {

        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,
        ISpecefication<TEntity> spec)
        {
            var query = inputQuery;

            if (spec.Predicate != null)
                query = query.Where(spec.Predicate);

            if (spec.OrderBy != null)
                query = spec.orderTypeEnum == OrderTypeEnum.Acs ? query.OrderBy(spec.OrderBy) : query.OrderByDescending(spec.OrderBy);

            query = spec.Includes.Aggregate(query, (currnet, include) => currnet.Include(include));

            return query;


        }

    }
}
