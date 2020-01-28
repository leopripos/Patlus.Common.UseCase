using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Patlus.Common.UseCase.Queries.Count
{
    public abstract class BaseCountQueryHandler<TQuery, TEntity> : IQueryFeatureHandler<TQuery, int>
        where TQuery : BaseCountQuery<TEntity>
        where TEntity : class
    {
        protected IQueryable<TEntity> Source { get; }

        protected BaseCountQueryHandler(IQueryable<TEntity> source)
        {
            this.Source = source;
        }

        public Task<int> Handle(TQuery request, CancellationToken cancellationToken)
        {
            if (request.RequestorId is null) throw new ArgumentNullException(nameof(request.RequestorId));

            var query = Source;

            if (!(request.Condition is null))
            {
                query = Source.Where(request.Condition);
            }

            return Task.FromResult(query.Count());
        }
    }
}
