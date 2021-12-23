using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specefication
{
    public interface ISpecefication<T>
    {
        Expression<Func<T, bool>> Predicate { get; }
        List<Expression<Func<T, object>>> Includes { get; }

    }
}