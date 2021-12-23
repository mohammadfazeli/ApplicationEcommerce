using System.Collections.Generic;
using System.Linq;
using Core.Entites;
using Core.Specefication;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpeceficationEveluator<TEntity> where TEntity : BaseEntity
    {

        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,
        ISpecefication<TEntity> spec)
        {
            var query = inputQuery;
            if (spec.Predicate != null)
            {
                query = query.Where(spec.Predicate);
            }

            //1
            // if (spec.Includes.Any())
            // {
            //     foreach (var item in spec.Includes)
            //     {
            //         query = query.Include(item);
            //     }
            // }
            //2
            query = spec.Includes.Aggregate(query, (currnet, include) => currnet.Include(include));

            return query;


        }

    }
}