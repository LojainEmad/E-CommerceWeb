using Domain.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class SpecificationEvaluator
    {
        //create Query
        //context.Set<TEntity>().Where (Criteria);
        //context.Set<TEntity>(); =>Input query Param
        public static IQueryable<TEntity> CreateQuery<TEntity , Tkey>(IQueryable<TEntity>InputQuery,ISpecifications<TEntity,Tkey> Spec)
            where TEntity : ModelBase<Tkey>
        {
            var Query = InputQuery;

            if(Spec.Criteria is not null)
                Query = Query.Where(Spec.Criteria);

            if(Spec.OrderBy is not null)
                Query = Query.OrderBy(Spec.OrderBy);

            if(Spec.OrderByDesc is  not null)
                Query=Query.OrderByDescending(Spec.OrderByDesc);


            if(Spec.IncludeExpressions is not null && Spec.IncludeExpressions.Count > 0)
                //aggregate => but string in one sequence
                Query = Spec.IncludeExpressions.Aggregate(Query, (currentQuery, Exp) => currentQuery.Include(Exp));

            if(Spec.IsPaginated ==true)
            {
                Query=Query.Skip(Spec.Skip).Take(Spec.Take);    
            }


            return Query;
        }
    }
}
