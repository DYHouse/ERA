using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ERA.Framework
{
    public class NotSpecification<T> : Specification<T>
    {
        private ISpecification<T> _Wrapped;

        public NotSpecification(ISpecification<T> wrapped)
        {
            _Wrapped = wrapped;
        }

        public override Expression<Func<T, bool>> IsSatisfiedBy()
        {
            return Expression.Lambda<Func<T, bool>>(Expression.Not(_Wrapped.IsSatisfiedBy().Body),
                                                         _Wrapped.IsSatisfiedBy().Parameters.Single());
        }
    }
}
