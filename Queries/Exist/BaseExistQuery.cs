using System;
using System.Linq.Expressions;

namespace Patlus.Common.UseCase.Queries.Exist
{
    public abstract class BaseExistQuery<TEntity> : IQueryFeature<bool> where TEntity : class
    {
        public Expression<Func<TEntity, bool>>? Condition { get; set; }
        public Guid? RequestorId { get; set; }
    }
}
