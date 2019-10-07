using System;

namespace Patlus.Common.UseCase.Notifications
{
    public abstract class BaseCreatedNotification<TEntity> : IFeatureNotification
    {
        public TEntity Entity { get; set; }
        public Guid By { get; set; }
        public DateTime Time { get; set; }
    }
}
