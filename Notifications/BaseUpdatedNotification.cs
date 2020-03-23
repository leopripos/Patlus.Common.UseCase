using Patlus.Common.UseCase.Entities;
using System;
using System.Collections.Generic;

namespace Patlus.Common.UseCase.Notifications
{
    public abstract class BaseUpdatedNotification<TEntity> : IFeatureNotification
        where TEntity: IEntity
    {
        public TEntity Entity { get; }
        public Dictionary<string, ValueChanged> Values { get; }
        public Guid By { get; }
        public DateTimeOffset Time { get; }

        public virtual Guid OrderingGroup => Entity.Id;

        protected BaseUpdatedNotification(TEntity entity, Dictionary<string, ValueChanged> values, Guid by, DateTimeOffset time)
        {
            Entity = entity;
            Values = values;
            By = by;
            Time = time;
        }
    }

    public class ValueChanged
    {
        public readonly object OldValue;
        public readonly object NewValue;
        public ValueChanged(object oldValue, object newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}
