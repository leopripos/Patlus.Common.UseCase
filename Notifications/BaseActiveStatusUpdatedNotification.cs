using System;

namespace Patlus.Common.UseCase.Notifications
{
    public abstract class BaseActiveStatusUpdatedNotification<TEntity> : IFeatureNotification
    {
        public TEntity Entity { get; }
        public bool OldVaiue { get; }
        public bool NewValue { get; }
        public Guid By { get; }
        public DateTimeOffset Time { get; }

        protected BaseActiveStatusUpdatedNotification(TEntity entity, bool oldValue, bool newValue, Guid by, DateTimeOffset time)
        {
            Entity = entity;
            OldVaiue = oldValue;
            NewValue = newValue;
            By = by;
            Time = time;
        }
    }
}
