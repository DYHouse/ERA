using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ERA.Framework
{
    public static class ExpressionExtension
    {
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            return left.Compose(right, Expression.And);
        }
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            return left.Compose(right, Expression.Or);
        }
        public static Expression<T> Compose<T>(this Expression<T> left, Expression<T> right, Func<Expression, Expression, Expression> merge)
        {
            var params1 = left.Parameters;
            var params2 = right.Parameters;
            var map = params1.Select((p, i) => new { p, s = params2[i] }).ToDictionary(p => p.s, p => p.p);
            var rightBody = ParameterRebinder.ReplaceParameters(map, right.Body);
            return Expression.Lambda<T>(merge(left.Body, rightBody), left.Parameters);
        }
    }
}
