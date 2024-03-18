using System.Linq.Expressions;

namespace PhysiscalPersonDirectory.Application.Shared.Specification
{
    public abstract class Specification<T>
    {
        public abstract Expression<Func<T, bool>> ToExpression();
    }
}
