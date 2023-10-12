using System.Linq.Expressions;

namespace core.Interfaces
{
    public interface ISpecificationProducts<T>
    {
        Expression<Func<T, bool>> productCriteria {get;}
        List<Expression<Func<T, object>>> productIncludes {get;}

        Expression<Func<T, object>> OrderBy {get;}

        Expression<Func<T, object>> OrderByDescending {get;}

        int Skip {get;}

         bool IsPageEnables {get;}

          int Take {get;}

    }
}