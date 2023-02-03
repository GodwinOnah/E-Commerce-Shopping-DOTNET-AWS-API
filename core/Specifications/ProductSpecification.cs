using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using core.Interfaces;

namespace infrastructure.data
{
    public class ProductSpecification<T> : ISpecificationProducts<T>
    {
        public Expression<Func<T, bool>> productCriteria {get;}
       
         public Expression<Func<T, object>> OrderBy  {get; private set;}

        public Expression<Func<T, object>> OrderByDescending {get; private set;}

        public ProductSpecification()//Parameterless constructor
        {
            
        } 

        public ProductSpecification(Expression<Func<T, bool>> productCriteria)//parameterized constructor
        {
            this.productCriteria = productCriteria;          
        }

        public List<Expression<Func<T, object>>> productIncludes  {get;}= 
        new List<Expression<Func<T, object>>>();//Include List

        public int Skip {get; private set;}

        public bool IsPageEnables {get; private set;}

        public int Take {get; private set;}

        protected void AddProdInclude(Expression<Func<T, object>> includes)
        {
                productIncludes.Add(includes);
        }

        protected void AddOrderBy(Expression<Func<T, object>> OrderByExp)
        {
                OrderBy = OrderByExp;
        }

        protected void AddOrderByDescending(Expression<Func<T, object>> OrderByDescendingExp)
        {
                OrderByDescending = OrderByDescendingExp;
        }

         protected void ApplyPagging(int skip, int take )
        {          
                Skip=skip;
                Take=take;
                IsPageEnables =true;
        }

        
       
    }
}