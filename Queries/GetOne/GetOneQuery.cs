using System;
using System.Linq.Expressions;

namespace Patlus.Common.UseCase.Queries.GetOne
{
    public abstract class BaseGetOneQuery<TEntity> : IQueryFeature<TEntity> where TEntity : class
    {
        public Expression<Func<TEntity, bool>>? Condition { get; set; }
        public Guid? RequestorId { get; set; }
    }
}
