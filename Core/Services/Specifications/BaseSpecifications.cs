﻿using Domain.Contracts;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    public abstract class BaseSpecifications<TEntity, Tkey> : ISpecifications<TEntity, Tkey>
        where TEntity : ModelBase<Tkey>
    {

        #region Criteria
        public BaseSpecifications(Expression<Func<TEntity, bool>>? PassedExpression)
        {
            Criteria = PassedExpression;

        }
        public Expression<Func<TEntity, bool>>? Criteria { get; private set; } 
        #endregion

        #region Includes

        public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; } = new List<Expression<Func<TEntity, object>>>();

        protected void AddInclude(Expression<Func<TEntity, object>> IncludeExp)
        {
            IncludeExpressions.Add(IncludeExp);
        }
        #endregion

        #region Sorting

        public Expression<Func<TEntity, object>> OrderBy { get; private set; }

        public Expression<Func<TEntity, object>> OrderByDesc { get; private set; }

        protected void AddOrderBy(Expression<Func<TEntity, object>> OrderByExpression) => OrderBy =OrderByExpression;

        protected void AddOrderByDesc(Expression<Func<TEntity, object>> OrderByDescExpression) => OrderByDesc = OrderByDescExpression;
        #endregion
    }
}
