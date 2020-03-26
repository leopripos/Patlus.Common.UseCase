using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Patlus.Common.UseCase.Queries.Exist
{
    public abstract class BaseExistQueryHandler<TQuery, TEntity> : IQueryFeatureHandler<TQuery, bool>
        where TQuery : BaseExistQuery<TEntity>
        where TEntity : class
    {
        protected IQueryable<TEntity> Source { get; }

        protected BaseExistQueryHandler(IQueryable<TEntity> source)
        {
            this.Source = source;
        }

        public async Task<bool> Handle(TQuery request, CancellationToken cancellationToken)
        {
            if (request.Condition is null) throw new ArgumentNullException(nameof(request.Condition));
            if (request.RequestorId is null) throw new ArgumentNullException(nameof(request.RequestorId));

            var query = Source.Where(request.Condition);

            var includes = request.GetInclude();
            if (includes != null && includes.Length > 0)
            {
                foreach (var path in includes)
                {
                    query = query.Include(path);
                }
            }

            return await query.CountAsync(cancellationToken) > 0;
        }
    }
}
