using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specefication
{
    public class BaseSpecefication<T> : ISpecefication<T>
    {

        public Expression<Func<T, bool>> Predicate { get; }

        public List<Expression<Func<T, object>>> Includes { get; } =
         new List<Expression<Func<T, object>>>();

        public BaseSpecefication()
        {

        }
        public BaseSpecefication(Expression<Func<T, bool>> predicate)
        {
            Predicate = predicate;
        }

        public BaseSpecefication(Expression<Func<T, bool>> predicate,
        List<Expression<Func<T, object>>> includes)
        {
            Predicate = predicate;
            foreach (var item in Includes)
            {
                AddInclude(item);
            }
        }

        protected void AddInclude(Expression<Func<T, object>> include)
        {
            Includes.Add(include);
        }

    }
}