using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using static Core.Enums.Enums;

namespace Core.Specefication
{
    public interface ISpecefication<T>
    {
        Expression<Func<T, bool>> Predicate { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        Expression<Func<T, object>> OrderBy { get; }
        OrderTypeEnum orderTypeEnum { get;}
    }
}