﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Patlus.Common.UseCase.Queries.GetAll
{
    public abstract class BaseGetAllQueryHandler<TQuery, TEntity> : IQueryFeatureHandler<TQuery, TEntity[]>
        where TQuery : BaseGetAllQuery<TEntity>
        where TEntity : class
    {
        protected IQueryable<TEntity> Source { get; }

        protected BaseGetAllQueryHandler(IQueryable<TEntity> source)
        {
            this.Source = source;
        }

        public Task<TEntity[]> Handle(TQuery request, CancellationToken cancellationToken)
        {
            if (request.RequestorId is null) throw new ArgumentNullException(nameof(request.RequestorId));

            var query = Source;

            if (!(request.Condition is null))
            {
                query = query.Where(request.Condition);
            }

            var includes = request.GetInclude();
            if (includes != null && includes.Length > 0)
            {
                foreach (var path in includes)
                {
                    query = query.Include(path);
                }
            }

            return query.ToArrayAsync(cancellationToken);
        }
    }
}
