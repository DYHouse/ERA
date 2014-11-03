using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERA.Framework
{
    public abstract class CompositeSpecification<T> : Specification<T>
    {
        public abstract ISpecification<T> Left { get; }

        public abstract ISpecification<T> Right { get; }

    }
}
