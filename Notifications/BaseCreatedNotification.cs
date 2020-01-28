using System;

namespace Patlus.Common.UseCase.Notifications
{
    public abstract class BaseCreatedNotification<TEntity> : IFeatureNotification
    {
        public TEntity Entity { get; }
        public Guid By { get; }
        public DateTimeOffset Time { get; }

        protected BaseCreatedNotification(TEntity entity, Guid by, DateTimeOffset time)
        {
            Entity = entity;
            By = by;
            Time = time;
        }
    }
}
