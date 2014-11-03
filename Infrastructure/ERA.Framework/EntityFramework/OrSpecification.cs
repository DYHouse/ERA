using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ERA.Framework
{
    public class OrSpecification<T> : CompositeSpecification<T>
    {
        private ISpecification<T> _Left;
        private ISpecification<T> _Right;

        public OrSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            _Left = left;
            _Right = right;
        }

        public override ISpecification<T> Left
        {
            get { return _Left; }
        }

        public override ISpecification<T> Right
        {
            get { return _Right; }
        }


        public override Expression<Func<T, bool>> IsSatisfiedBy()
        {
            return _Left.IsSatisfiedBy().Or(_Right.IsSatisfiedBy());
        }

    }
}
