using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;
using core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.data
{
    public class ProductSpecictaionEvaluator<T> where T :ProductEntities
    {
        public static IQueryable<T> GetQuery(
                                            IQueryable<T> inputQuery, 
                                            ISpecificationProducts<T> specification)
        {

                if(specification.productCriteria!=null)
                {
                   inputQuery=inputQuery.Where(specification.productCriteria);
                }

                if(specification.OrderBy!=null)
                {
                   inputQuery=inputQuery.OrderBy(specification.OrderBy);
                }

                if(specification.OrderByDescending!=null)
                {
                   inputQuery=inputQuery.OrderByDescending(specification.OrderByDescending);
                }

                if(specification.IsPageEnables)
                {
                    inputQuery=inputQuery.Skip(specification.Skip).Take(specification.Take);

                }

                inputQuery=specification.productIncludes
                .Aggregate(inputQuery,(current,productIncludes)=>current.Include(productIncludes));

                return inputQuery;
                

        }
    }
}