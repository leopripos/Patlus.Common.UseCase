using System;
using System.Linq.Expressions;

namespace Patlus.Common.UseCase.Queries.Count
{
    public abstract class BaseCountQuery<TEntity> : IQueryFeature<int> where TEntity : class
    {
        public Expression<Func<TEntity, bool>>? Condition { get; set; }
        public Guid? RequestorId { get; set; }
    }
}
