using Patlus.Common.UseCase.Entities;
using System;

namespace Patlus.Common.UseCase.Notifications
{
    public abstract class BaseCreatedNotification<TEntity> : IFeatureNotification
        where TEntity : IEntity
    {
        public TEntity Entity { get; }
        public Guid? By { get; }
        public DateTimeOffset Time { get; }

        public virtual Guid OrderingGroup => Entity.Id;

        protected BaseCreatedNotification(TEntity entity, Guid? by, DateTimeOffset time)
        {
            Entity = entity;
            By = by;
            Time = time;
        }
    }
}
