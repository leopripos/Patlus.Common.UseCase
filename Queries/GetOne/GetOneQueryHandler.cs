using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Patlus.Common.UseCase.Queries.GetOne
{
    public abstract class BaseGetOneQueryHandler<TQuery, TEntity> : IQueryFeatureHandler<TQuery, TEntity>
        where TQuery : BaseGetOneQuery<TEntity>
        where TEntity : class
    {
        protected IQueryable<TEntity> Source { get; }

        protected BaseGetOneQueryHandler(IQueryable<TEntity> source)
        {
            this.Source = source;
        }

        public Task<TEntity> Handle(TQuery request, CancellationToken cancellationToken)
        {
            if (request.Condition is null) throw new ArgumentNullException(nameof(request.Condition));
            if (request.RequestorId is null) throw new ArgumentNullException(nameof(request.RequestorId));

            var query = Source;

            query = query.Where(request.Condition);

            if (request.Includes != null && request.Includes.Length > 0)
            {
                    foreach (var path in request.Includes)
                {
                    query = query.Include(path);
                }
            }

            return Task.FromResult(query.FirstOrDefault());
        }
    }
}
