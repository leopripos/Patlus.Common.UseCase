﻿using System;
using System.Linq.Expressions;

namespace Patlus.Common.UseCase.Queries.GetAll
{
    public abstract class BaseGetAllQuery<TEntity> : IQueryFeature<TEntity[]> where TEntity : class
    {
        public Expression<Func<TEntity, bool>>? Condition { get; set; }
        public Guid? RequestorId { get; set; }
    }
}
