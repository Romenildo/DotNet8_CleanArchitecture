using System.Linq.Expressions;

namespace Projeto.Database.Util;

public static class Util
{
    public static IQueryable<T> AddCondition<T>(this IQueryable<T> queryable, Func<bool> predicate, Expression<Func<T, bool>> filter)
    {
        if (predicate())
            return queryable.Where(filter);
        else
            return queryable;
    }
}

