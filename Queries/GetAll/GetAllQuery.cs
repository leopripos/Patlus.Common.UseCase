﻿using System;
using System.Linq.Expressions;

namespace Patlus.Common.UseCase.Queries.GetAll
{
    public abstract class BaseGetAllQuery<TEntity> : IQueryFeature<TEntity[]> where TEntity : class
    {
        private string[] _include;

        public Expression<Func<TEntity, bool>>? Condition { get; set; }
        public Guid? RequestorId { get; set; }

        public string[] GetInclude()
        {
            return _include;
        }

        public void SetInclude(params string[] fields)
        {
            _include = fields;
        }

    }
}
