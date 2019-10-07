using System;

namespace Patlus.Common.UseCase.Notifications
{
    public abstract class BaseActiveStatusUpdatedNotification<TEntity> : IFeatureNotification
    {
        public TEntity Entity { get; set; }
        public bool Old { get; set; }
        public bool New { get; set; }
        public Guid By { get; set; }
        public DateTime Time { get; set; }
    }
}
